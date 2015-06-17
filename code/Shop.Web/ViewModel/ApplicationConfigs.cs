using Shop.Common;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.ViewModel
{
    public class ApplicationConfigs
    {
        /// <summary>
        /// 获取用户站点配置的信息
        /// </summary>
        public static Config GetConfigInfo
        {
            get
            {
                var cofigModel = CacheHelper.Get<Config>("siteConfig");
                if (cofigModel == null)
                {
                    cofigModel = SerializationHelper.Load(typeof(Config),
                     HttpContext.Current.Server.MapPath("/Content/settings/siteConfig.xml")) as Config;
                    CacheHelper.Set("siteConfig", cofigModel);
                }
                return cofigModel;
            }
            set
            {
                CacheHelper.Set("siteConfig", value);
            }
        }
    }
}