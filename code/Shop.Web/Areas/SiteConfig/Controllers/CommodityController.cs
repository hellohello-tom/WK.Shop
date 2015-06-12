// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：Commodity 控制器
//  作    者：cat
//  添加时间：2015-06-08 17:34:31
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
using System.IO;

namespace Shop.Web.Areas.SiteConfig.Controllers
{
	/// <summary>
	/// Commodity控制器
	/// </summary>
	public class CommodityController:Controller
	{	     
		private readonly CommodityBLL bll=new CommodityBLL();
        private readonly TagBLL _tagBLL = new TagBLL();
        private readonly FileAttrBLL _fileAttrBLL = new FileAttrBLL();
		/// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Index(DWZPageInfo page,string name="",int tagId=0)
        {
        	#region 搜索条件
            WhereClip where = null;
            if (!string.IsNullOrEmpty(name))
                where &= Commodity._.Commodity_Name.Like("%" + name + "%");
            if (tagId > 0)
                where &= Commodity._.Commodity_TagId == tagId;
            ViewBag.TagId = tagId;
            ViewBag.Name = name;
            #endregion
            var usersPage = bll.GetPageList(page.NumPerPage, page.PageNum, where,
                Commodity._.Commodity_CreateTime.Desc);
            return View(usersPage);
        }
        
        #region  添加 编辑
        /// <summary>
        /// 添加 编辑页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Create(int id = 0)
        {
            Model.Commodity model = bll.GetModel(id) ?? new Commodity();
            if (id > 0)
            {
                ViewBag.TagName = _tagBLL.GetModel(model.Commodity_TagId).Tag_Name;
            }
            else
            {
                model.Commodity_ImagePath = "/Content/web/images/NoPicture.png";
                model.Commodity_CostPrice = 1;
                model.Commodity_ResidueCount = 0;
            }
            ViewBag.FileAttrList = _fileAttrBLL.GetList(FileAttr._.FileAttr_IsDel == false
                && FileAttr._.FileAttr_BussinessId == model.Id && FileAttr._.FileAttr_BussinessId != 0
                && FileAttr._.FileAttr_BussinessCode == BizCode.Commodity.ToString(),
                FileAttr._.Id.Desc);
            return View(model);
        }

        public ActionResult SelectTag()
        {
            //----导航列表
            var tagList = _tagBLL.GetList(Tag._.Tag_IsDel == false);
            var sourceList = tagList.OrderByDescending(x => x.Tag_CreateTime).ToList()
                as List<Tag>;
            ViewBag.TagList = sourceList;
            return View();
        }


        /// <summary>
        /// 添加 编辑操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Model.Commodity model, int[] imageIds)
        {
            bool flag = false;
            DWZCallbackInfo callback = DWZMessage.Faild();
            if (ModelState.IsValid)
            {
                if (imageIds.Length <= 0)
                {
                    model.Commodity_ImagePath = "/Content/web/images/NoPicture.png";
                }
                if (model.Id > 0)//修改
                {
                    flag = bll.Update(model, imageIds);
                }
                else//添加
                {
                    model.Commodity_CreateTime = DateTime.Now;
                    model.Commodity_User = UserContext.CurUserInfo.Id;
                    model.Commodity_IsDel = false;
                    flag = bll.Add(model, imageIds) > 0;
                }

                if (flag)
                    callback = DWZMessage.Success("操作成功", "SiteConfig_Commodity", true);
                else
                    callback = DWZMessage.Faild();
            }
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