// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：Config 控制器
//  作    者：cat
//  添加时间：2015-06-08 17:34:33
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
using System.Xml.Serialization;

namespace Shop.Web.Areas.SiteConfig.Controllers
{
	/// <summary>
	/// Config控制器
	/// </summary>
	public class ConfigController:Controller
	{	     
		private readonly ConfigBLL bll=new ConfigBLL();
	
		/// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Index()
        {
            var configModel = SerializationHelper.Load(typeof(Config), Server.MapPath("/Content/settings/siteConfig.xml")) as Config;
            return View(configModel);
        }

        
        #region  添加 编辑
        
        /// <summary>
        /// 添加 编辑操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Model.Config model)
        {
            DWZCallbackInfo callback = DWZMessage.Faild();
            try
            {
                if (ModelState.IsValid)
                {
                    SerializationHelper.Save(model, Server.MapPath("/Content/settings/siteConfig.xml"));
                    callback = DWZMessage.Success();
                }
            }
            catch(Exception ex)
            {
                callback = DWZMessage.Faild(ex.Message);
            }
            return Json(callback);
        }
        #endregion
        

	}
}