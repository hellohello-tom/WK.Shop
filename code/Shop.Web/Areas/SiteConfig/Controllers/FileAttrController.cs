// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：FileAttr 控制器
//  作    者：cat
//  添加时间：2015-06-08 17:34:35
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

namespace Shop.Areas.SiteConfig.Controllers
{
	/// <summary>
	/// FileAttr控制器
	/// </summary>
	public class FileAttrController:Controller
	{	     
		private readonly FileAttrBLL bll=new FileAttrBLL();
	
		/// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Index(DWZPageInfo page)
        {
        	#region 搜索条件
            WhereClip where = null;
            //if (!string.IsNullOrEmpty(name))
            //    where &= FileAttr._.Name.Like("%" + name + "%");
            //ViewBag.Name = name;
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
            if (id > 0)
            {
                Model.FileAttr model = bll.GetModel(id);
                return View(model);
            }
            else
            {
                return View();
            }
        } 
        
        /// <summary>
        /// 添加 编辑操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Model.FileAttr model)
        {
            bool flag = false;
			DWZCallbackInfo callback=null;

            if (model.Id > 0)//修改
                flag=bll.Update(model);
            else//添加
                flag=bll.Add(model)>0;

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