// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysLog 控制器
//  作    者：tomCat
//  添加时间：2014-03-06 16:36:10
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

namespace Shop.Web.Areas.SysManage.Controllers
{
	/// <summary>
	/// SysLog控制器
	/// </summary>
	public class SysLogController:Controller
	{	     
		private readonly SysLogBLL bll=new SysLogBLL();
	
		/// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="numPerPage"></param>
        /// <param name="pageNum"></param>
        /// <returns></returns>
        public ActionResult Index(DWZPageInfo page, string title = "", string level = "", string content = "", DateTime? beginTime = null, DateTime? endTime = null)
        {
            WhereClip where = null;
            //标题
            if(!string.IsNullOrEmpty(title))
                where&=SysLog._.Title.Like("%" + title + "%");
            //级别
            if (!string.IsNullOrEmpty(level))
                where &= SysLog._.Level==level;
            //内容
            if (!string.IsNullOrEmpty(content))
                where &= SysLog._.Content.Like("%" + content + "%");
            //时间段
            if (beginTime != null)
                where &= SysLog._.AddTime >= beginTime;
            if (endTime != null)
                where &= SysLog._.AddTime <= endTime;

            ViewBag.Title = title;
            ViewBag.Level = level;
            ViewBag.Content = content;
            ViewBag.BeginTime = beginTime;
            ViewBag.EndTime = endTime;

            var usersPage = bll.GetPageList(page.NumPerPage, page.PageNum,where,SysLog._.Id.Desc);
            
            return View(usersPage);
        }

        /// <summary>
        /// 详情页
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Show(int id)
        {
            var model = bll.GetModel(id);
            return View(model);
        }

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