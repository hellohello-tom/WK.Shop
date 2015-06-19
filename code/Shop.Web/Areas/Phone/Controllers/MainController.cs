using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySoft.Data;
using Shop.BLL;
using MySoft.Data;
using Shop.Model;
using Shop.Common;

namespace Shop.Web.Areas.Phone.Controllers
{
    public class MainController : Controller
    {
        private static readonly FlashSalesBLL _flashSalesBLL = new FlashSalesBLL();
        private static readonly RealtionBLL _realtionBLL = new RealtionBLL();
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 网站首页 闪购导航项
        /// </summary>
        /// <returns></returns>
        public ActionResult FlashSalesItem(int topSize=9)
        {
            WhereClip where = Model.FlashSales._.FlashSales_IsDel == false && new WhereClip("Realtion.Id is not null")
                && Realtion._.Realtion_IsTop == true && Model.FlashSales._.FlashSales_EndTime > DateTime.Now;
            var table = _flashSalesBLL.GetFlashSales(topSize, where, Realtion._.Realtion_IsTop.Desc && Realtion._.Realtion_CreateTime.Desc);
            ViewBag.TopActive = _flashSalesBLL.GetTopList(1,Model.FlashSales._.FlashSales_EndTime > DateTime.Now && Model.FlashSales._.FlashSales_IsDel == false
                , Model.FlashSales._.FlashSales_EndTime.Desc).FirstOrDefault() ?? new Model.FlashSales();
            return View(table);
        }
    }
}
