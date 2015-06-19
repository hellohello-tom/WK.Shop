// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：FlashSales 控制器
//  作    者：cat
//  添加时间：2015-06-17 10:59:28
// ==========================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//引用
using Shop.BLL;
using Shop.Model;
using Shop.Common;
using MySoft.Data;
using Shop.Web;
using System.Text.RegularExpressions;

namespace Shop.Web.Areas.FlashSales.Controllers
{
	/// <summary>
	/// FlashSales控制器
	/// </summary>
	public class FlashSalesController:Controller
	{	     
		private readonly FlashSalesBLL bll=new FlashSalesBLL();
        private readonly MenuBLL _menuBLL = new MenuBLL();
        private readonly CommodityBLL _commodityBLL = new CommodityBLL();
        private readonly RealtionBLL _realtionBLL = new RealtionBLL();
        private readonly FileAttrBLL _fileAttrBLL = new FileAttrBLL();
		/// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Index(DWZPageInfo page,string name="")
        {
        	#region 搜索条件
            WhereClip where = null;
            if (!string.IsNullOrEmpty(name))
                where &= Model.FlashSales._.FlashSales_Name.Contains(name);
            ViewBag.Name = name;
            #endregion
            var usersPage = bll.GetPageList(page.NumPerPage, page.PageNum, where);
            return View(usersPage);
        }
        
        #region  添加 编辑
        /// <summary>
        /// 添加 编辑页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Create(int id=0)
        {
            Model.FlashSales model = bll.GetModel(id) ?? new Model.FlashSales();
            //获取图片信息
            ViewBag.FileModel = _fileAttrBLL.GetModel(FileAttr._.FileAttr_BussinessId == model.Id && FileAttr._.FileAttr_BussinessCode == BizCode.FlashSales.ToString())
                ?? new FileAttr
                {
                    FileAttr_Path = "/Content/web/images/NoPicture.png"
                };
            if (id > 0)
                ViewBag.MenuName = _menuBLL.GetModel(model.FlashSales_MenuId).Menu_Name;
            return View(model);
        }


        /// <summary>
        /// 选择二级菜单
        /// </summary>
        /// <param name="navigationId"></param>
        /// <returns></returns>
        public ActionResult SelectNavigation()
        {
            //----导航列表
          var menuList =   _menuBLL.GetList(Menu._.Menu_IsDel == false
                && Menu._.Menu_Type == MenuType.FlashSalues.ToString()
                && Menu._.Menu_ParentId == 0, Menu._.Id.Desc);
          return View(menuList);
        }



        /// <summary>
        /// 添加关系
        /// </summary>
        /// <param name="discount"></param>
        /// <param name="commdityIds"></param>
        /// <param name="flashSalesId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddRelation(decimal discount,int commdityIds, int flashSalesId)
        {
            DWZCallbackInfo callback = DWZMessage.Faild();
            try
            {
                if(!new Regex(@"^([1-9])(\.\d{1})?$").IsMatch(discount+""))
                {
                     callback = DWZMessage.Faild("请输入正确的折扣，最多保留一位小数！");
                }
                //判断商品是否已经添加过折扣
                else if (_realtionBLL.Exists(Realtion._.Realtion_CommodityId == commdityIds && Realtion._.Realtion_IsDel == false
                    && Realtion._.Realtion_SaleId == flashSalesId))
                {
                    callback = DWZMessage.Faild("该商品已经添加过了！");
                }
                else
                {
                    var model = new Realtion
                    {
                        Realtion_CommodityId = commdityIds,
                        Realtion_SaleId = flashSalesId,
                        Realtion_CreateTime = DateTime.Now,
                        Realtion_CreateUser = UserContext.CurUserInfo.Id,
                        Realtion_Discount = discount,
                        Realtion_IsDel = false,
                        Realtion_IsTop = false
                    };
                    if (_realtionBLL.Add(model) > 0) {
                        callback = DWZMessage.Success();
                    }
                }
            }
            catch (Exception ex)
            {
                callback = DWZMessage.Faild(ex.Message);
            }
            return Json(callback);
        }

        /// <summary>
        /// 选择特价商品
        /// </summary>
        /// <param name="navigationId"></param>
        /// <returns></returns>
        public ActionResult SelectCommdity(DWZPageInfo page, string name)
        {
            #region 搜索条件
            WhereClip where = Commodity._.Commodity_IsDel == false;
            if (!string.IsNullOrEmpty(name))
                where &= Commodity._.Commodity_Name.Like("%" + name + "%");
            ViewBag.Name = name;
            #endregion
            IDataPage<IList<Commodity>> sourcePage = new DataPage<IList<Commodity>>()
            {
                DataSource = new List<Commodity>()
            };
            if(!string.IsNullOrEmpty(name))
            sourcePage = _commodityBLL.GetPageList(page.NumPerPage, page.PageNum, where,
                Commodity._.Commodity_CreateTime.Desc);
            return View(sourcePage);
        }

        /// <summary>
        /// 添加 编辑操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Model.FlashSales model, int[] flashSalesImagesIds)
        {
            bool flag = false;
            DWZCallbackInfo callback = null;
            if (ModelState.IsValid)
            {
                if (model.Id > 0)//修改
                {
                    flag = bll.Update(model);
                }
                else//添加
                {
                    model.FlashSales_IsDel = false;
                    model.FlashSales_CreateTime = DateTime.Now;
                    model.FlashSales_CreateUser = UserContext.CurUserInfo.Id;
                    model.Id = bll.Add(model);
                    flag = model.Id > 0;
                }
                if (flag)
                {
                    _fileAttrBLL.Delete(FileAttr._.FileAttr_BussinessId == model.Id && FileAttr._.FileAttr_BussinessCode == BizCode.FlashSales.ToString());
                    _fileAttrBLL.Update(new Dictionary<Field, object>
                    {
                        {FileAttr._.FileAttr_BussinessId,model.Id},
                        {FileAttr._.FileAttr_BussinessCode, BizCode.FlashSales.ToString()}
                    }, FileAttr._.Id.In(flashSalesImagesIds));
                }
            }
            if (flag)
                callback = DWZMessage.Success(navTabId: "FlashSales_FlashSales");
            else
                callback = DWZMessage.Faild();

            return Json(callback);
        }
        #endregion
        
        #region 删除
        /// <summary>
        /// 删除单条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            DWZCallbackInfo callback = null;

            if (bll.Delete(id))
                callback = DWZMessage.Success("删除成功!");
            else
                callback = DWZMessage.Faild("删除失败!");

            return Json(callback);
        }

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteList(int[] ids)
        {
           DWZCallbackInfo callback = null;
           
            int count=bll.Delete(ids) ;
            if (count > 0)
                callback = DWZMessage.Success(string.Format("删除成功！共删除{0}条！", count));
            else
                callback = DWZMessage.Faild("删除失败!");

            return Json(callback);
        }
        
        #endregion
	}
}