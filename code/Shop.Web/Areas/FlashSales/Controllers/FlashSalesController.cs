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

namespace Shop.Web.Areas.FlashSales.Controllers
{
	/// <summary>
	/// FlashSales控制器
	/// </summary>
	public class FlashSalesController:Controller
	{	     
		private readonly FlashSalesBLL bll=new FlashSalesBLL();
        private readonly MenuBLL _menuBLL = new MenuBLL();
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
            Model.FlashSales model = bll.GetModel(id);
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
        /// 选择特价商品
        /// </summary>
        /// <param name="navigationId"></param>
        /// <returns></returns>
        public ActionResult SelectCommdity(string commditys)
        {
            //string checkModuleIds = string.Format(",{0},", commditys.Trim(','));//已选择的模块

            ////----模块列表
            //var commdityList = moduleBll.GetList(SysModule._.Enabled == 1);

            //StringBuilder sbHtml = new StringBuilder();
            //var firstModuleList = moduleList.FindAll(x => x.ParentId == 0);//第一级
            //List<Shop.Model.SysModule> childModuleList = null;//子级 临时变量

            ////第1级
            //sbHtml.AppendFormat("<ul class='tree  expand treeCheck'>");
            //foreach (var root in firstModuleList)
            //{
            //    sbHtml.AppendFormat("<li><a href='javascript:;' {0} tname='selectModule' tvalue='{{\"Id\":\"{1}\",\"Name\":\"{2}\"}}' >{2}</a>{3}</li>",
            //                               checkModuleIds.Contains("," + root.Id + ",") ? "checked='checked'" : "",
            //                                root.Id,
            //                                root.Name,
            //                                GetChildHtml(moduleList, root.Id, checkModuleIds)
            //                           );
            //}
            //sbHtml.Append("</ul>");
            //ViewBag.ModuleHtml = sbHtml.ToString();

            return View();

            //----导航列表
            var menuList = _menuBLL.GetList(Menu._.Menu_IsDel == false
                  && Menu._.Menu_Type == MenuType.FlashSalues.ToString()
                  && Menu._.Menu_ParentId == 0, Menu._.Id.Desc);
            return View(menuList);
        }

        /// <summary>
        /// 添加 编辑操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Model.FlashSales model, int[] commdityIds)
        {
            bool flag = false;
            DWZCallbackInfo callback = null;
            if (ModelState.IsValid)
            {
                if (model.Id > 0)//修改
                    flag = bll.Update(model);
                else//添加
                    flag = bll.Add(model) > 0;
            }
            if (flag)
                callback = DWZMessage.Success();
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