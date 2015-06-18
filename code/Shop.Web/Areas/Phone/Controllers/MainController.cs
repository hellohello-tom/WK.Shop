using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.BLL;

namespace Shop.Web.Areas.Phone.Controllers
{
    public class MainController : Controller
    {
        private static readonly FlashSalesBLL FlashSalesBll = new FlashSalesBLL();

        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 网站首页 闪购导航项
        /// </summary>
        /// <returns></returns>
        public ActionResult FlashSalesItem()
        {
            return View();
        }
    }
}
