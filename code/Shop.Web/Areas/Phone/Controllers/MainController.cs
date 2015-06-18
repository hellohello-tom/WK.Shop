using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySoft.Data;
using Shop.BLL;
using Shop.Common;
using Shop.Model;

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
              #region 搜索条件

            WhereClip where = Model.FlashSales._.FlashSales_IsDel == false
                &&Model.Realtion._.Realtion_IsDel==false
                &&Model.Commodity._.Commodity_IsDel==false;
            OrderByClip order = new OrderByClip("Realtion_IsTop Desc");

            #endregion

            var dt = FlashSalesBll.GetFlashSalesCommodityTable(where,order);
            return View(dt);
        }
    }
}
