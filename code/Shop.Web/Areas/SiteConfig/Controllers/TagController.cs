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
		private readonly TagBLL bll=new TagBLL();
        private readonly NavigationBLL navigationBLL = new NavigationBLL();
	
		/// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Index(DWZPageInfo page, string tagName = "", int navigationId=0)
        {
        	#region 搜索条件
            WhereClip where = Tag._.Tag_IsDel == false;
            if (!string.IsNullOrEmpty(tagName))
                where &= Tag._.Tag_Name.Like("%" + tagName + "%");
            if (navigationId > 0)
                where &= Tag._.Tag_NavigationId == navigationId;
            ViewBag.Name = tagName;
            ViewBag.NavigationId = navigationId;
            #endregion

            var usersPage = bll.GetPageList(page.NumPerPage, page.PageNum, where, Tag._.Tag_Sort.Desc);
            
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

            StringBuilder sbHtml = new StringBuilder();
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
            Model.Tag model = bll.GetModel(id) ?? new Tag();
            if (id > 0)
            {
                ViewBag.NavigationName = navigationBLL.GetModel(model.Tag_NavigationId).Navigation_Name;
            }
            else
            {
                model.Tag_Status = 0;
                model.Tag_Sort = 1;
                model.Tag_ImagePath = "/Content/web/images/NoPicture.png";
            }
            return View(model);
        }
        
        /// <summary>
        /// 添加 编辑操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Model.Tag model)
        {
            bool flag = false;
			DWZCallbackInfo callback=null;

            if (model.Id > 0)//修改
                flag = bll.Update(model);
            else//添加
            {
                model.Tag_CreateTime = DateTime.Now;
                model.Tag_IsDel = false;
                model.Tag_User = UserContext.CurUserInfo.Id;
                flag = bll.Add(model) > 0;
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

            if (bll.Update(new Dictionary<Field, object> { { Tag._.Tag_IsDel, true } }, Tag._.Id == id))
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
           if (bll.Update(new Dictionary<Field, object> { { Tag._.Tag_IsDel, true } }, Tag._.Id.In(ids)))
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