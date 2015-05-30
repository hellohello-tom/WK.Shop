// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysSiteConfig 控制器
//  作    者：tomCat
//  添加时间：2014-03-10 09:18:21
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
	/// 站点配置控制器
	/// </summary>
	public class SysSiteConfigController:Controller
	{	     
		private readonly SysSiteConfigBLL bll=new SysSiteConfigBLL();//参数配置信息
	
        
        /// <summary>
        ///  站点配置页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            SysSiteConfig model=bll.GetSiteConfig();
            ViewBag.id = model.Id;
            ViewBag.FileSize = BaseData.SiteConfig.AttachImgSize;
            return View(model);
        } 
        
        /// <summary>
        ///  保存操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(Model.SysSiteConfig model)
        {
			DWZCallbackInfo callback=null;
           
            if (bll.SaveSiteConfig(model))
                callback = DWZMessage.Success("操作成功！");
			else
                callback = DWZMessage.Faild();

             return Json(callback);
        }
	}
}