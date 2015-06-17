using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MySoft.Data;
using Shop.BLL;
using Shop.Model;
using Shop.Common;

namespace Shop.Web.Areas.Phone.Controllers
{
    /// <summary>
    /// 闪购
    /// </summary>
    public class FlashSalesController : Controller
    {
       private static readonly FlashSalesBLL FlashSalesBll=new FlashSalesBLL();
       private static readonly MenuBLL MenuBll = new MenuBLL();
       private static readonly RealtionBLL RealtionBll = new RealtionBLL();
       private static readonly CommodityBLL CommodityBll = new CommodityBLL();

        /// <summary>
        /// 闪购首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            #region 搜索条件

            WhereClip where = Menu._.Menu_IsDel == false && Menu._.Menu_Status == (int)Status.Show&&Menu._.Menu_Type==MenuType.FlashSalues.ToString();
            #endregion
            var menuList = MenuBll.GetList(where, Menu._.Menu_Sort.Desc);
            var firstOrDefault = menuList.FirstOrDefault();
            if (firstOrDefault != null)
            {
                int defalutMenuId = firstOrDefault.Id;
                WhereClip wc = Model.FlashSales._.FlashSales_MenuId == defalutMenuId;
                var list = FlashSalesBll.GetlistByCondition(wc);
                ViewBag.FlashSalesList = list;
            }
            return View();
        }
        /// <summary>
        /// 闪购药品列表
        /// </summary>
        /// <returns></returns>
        public ActionResult CommodityList()
        {
            return View();
        }
        /// <summary>
        /// 闪购药品详情
        /// </summary>
        /// <returns></returns>
        public ActionResult CommodityDetail()
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
