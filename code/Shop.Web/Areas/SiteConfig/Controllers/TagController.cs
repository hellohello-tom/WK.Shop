// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：Tag 控制器
//  作    者：cat
//  添加时间：2015-06-08 17:34:39
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
using System.Text;

namespace Shop.Web.Areas.SiteConfig.Controllers
{
	/// <summary>
	/// Tag控制器
	/// </summary>
	public class TagController:Controller
	{
        private readonly MenuBLL bll = new MenuBLL();
        private readonly NavigationBLL navigationBLL = new NavigationBLL();
	
		/// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Index(DWZPageInfo page, string tagName = "", int navigationId = 0)
        {
            #region 搜索条件
            WhereClip where = Menu._.Menu_IsDel == false
                && Menu._.Menu_Type == MenuType.Tag.ToString()
                && Menu._.Menu_ParentId == 0;
            if (!string.IsNullOrEmpty(tagName))
                where &= Menu._.Menu_Name.Like("%" + tagName + "%");
            if (navigationId > 0)
                where &= Menu._.Menu_NavigationId == navigationId;
            ViewBag.Name = tagName;
            ViewBag.NavigationId = navigationId;
            #endregion
            var usersPage = bll.GetPageList(page.NumPerPage, page.PageNum, where, Menu._.Menu_Sort.Desc);
            return View(usersPage);
        }

        /// <summary>
        /// 选择导航
        /// </summary>
        /// <param name="navigationId"></param>
        /// <returns></returns>
        public ActionResult SelectNavigation(int navigationId=0)
        {
            //----导航列表
            var navigationList = navigationBLL.GetList(Navigation._.Navigation_IsDel == false);
            var sourceList = navigationList.Where(x => x.Navigation_Type == (int)Theme.Materials)
                .OrderByDescending(x => x.Navigation_Sort).ToList() 
                as List<Navigation>;
            ViewBag.NavigationList = sourceList;
            return View();
        }

        #region  添加 编辑
        /// <summary>
        /// 添加 编辑页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Create(int id = 0)
        {
            Model.Menu model = bll.GetModel(id) ?? new Menu();
            if (id > 0)
            {
                ViewBag.NavigationName = navigationBLL.GetModel(model.Menu_NavigationId).Navigation_Name;
            }
            else
            {
                model.Menu_Status = (int)Status.Show;
                model.Menu_Sort = 1;
                model.Menu_ImgPath = "/Content/web/images/NoPicture.png";
                model.Menu_Type = MenuType.Tag.ToString();
            }
            return View(model);
        }
        
        /// <summary>
        /// 添加 编辑操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Model.Menu model)
        {
            bool flag = false;
			DWZCallbackInfo callback=null;
            if (ModelState.IsValid)
            {
                if (model.Id > 0)//修改
                    flag = bll.Update(model);
                else//添加
                {
                    model.Menu_CreateTime = DateTime.Now;
                    model.Menu_IsDel = false;
                    model.Menu_CreateUser = UserContext.CurUserInfo.Id;
                    flag = bll.Add(model) > 0;
                }
            }
            if (flag)
                callback = DWZMessage.Success("操作成功", "SiteConfig_Tag", true);
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

            if (bll.Update(new Dictionary<Field, object> { { Menu._.Menu_IsDel, true } }, Menu._.Id == id))
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
            if (bll.Update(new Dictionary<Field, object> { { Menu._.Menu_IsDel, true } }, Menu._.Id.In(ids)))
            {
                callback = DWZMessage.Success(string.Format("删除成功！共删除{0}条！", ids.Length));
            }
            else
                callback = DWZMessage.Faild("删除失败!");

            return Json(callback);
        }
        
        #endregion
	}
}