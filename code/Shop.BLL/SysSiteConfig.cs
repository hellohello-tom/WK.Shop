// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysSiteConfig 业务逻辑层
//  作    者：ThinkWang
//  添加时间：2014-03-20 10:23:40
// ==========================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//引用
using Shop.DAL;
using Shop.Model;
using Shop.Common;
using MySoft.Data;
using Shop.Log;

namespace Shop.BLL
{
    /// <summary>
    /// SysSiteConfig业务逻辑层
    /// </summary>
    public partial class SysSiteConfigBLL : BLLBase<SysSiteConfig>
    {
        private readonly SysSiteConfigDAL dal = new SysSiteConfigDAL();
        private readonly string cacheKey = "SysSiteConfig";

        /// <summary>
        /// 获取站点配置
        /// </summary>
        /// <returns></returns>
        public SysSiteConfig GetSiteConfig()
        {
            SysSiteConfig model = CacheHelper.Get<SysSiteConfig>(cacheKey);
            if (model == null)
            {
                try
                {
                    model = dal.GetSiteConfig();
                    if (model != null)
                    {
                        CacheHelper.Set(cacheKey, model);
                        Logger.Info("站点配置缓存成功！");
                    }
                }
                catch (Exception ex) { Logger.Fatal(ex); }
            }

            return model;
        }

        /// <summary>
        /// 保存站点配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveSiteConfig(SysSiteConfig model)
        {
            bool isOk = false;
            if (model.Id > 0)
            {
                isOk = dal.Update(model);
            }
            else
            {
                int id = dal.Add(model);
                model.Id = id;
                isOk = id > 0;
            }

            return isOk;
        }

    }
}