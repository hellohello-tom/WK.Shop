using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Shop.Log;
using Shop.Model;
using Shop.BLL;

namespace Shop.Web
{
    public class BaseData
    {

        private static SysSiteConfig _siteConfig;
        private static readonly object objLocker = new object();
        private static SysSiteConfigBLL siteConfigBLL = new SysSiteConfigBLL();
        /// <summary>
        /// 站点配置
        /// </summary>
        public static SysSiteConfig SiteConfig
        {
            get
            {
                return siteConfigBLL.GetSiteConfig();
            }
        }
    }
}