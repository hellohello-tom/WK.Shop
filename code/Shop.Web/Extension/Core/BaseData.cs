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
        /// <summary>
        /// 返回对应的信用等级（AA  A  B  C  D）
        /// </summary>
        /// <param name="level">(信用等级  1 2  3  4  5)</param>
        /// <returns></returns>
        public static string ReturnCreditLevel(string level)
        {
            string creditLevel = "";
            switch (level)
            {
                case "1":
                    creditLevel = "AA";
                    break;
                case "2":
                    creditLevel = "A";
                    break;
                case "3":
                    creditLevel = "B";
                    break;
                case "4":
                    creditLevel = "C";
                    break;
                case "5":
                    creditLevel = "D";
                    break;
            }
            return creditLevel;
        }
    }
}