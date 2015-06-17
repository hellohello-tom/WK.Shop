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
       private static readonly FileAttrBLL FileAttrBll = new FileAttrBLL();

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
        /// 闪购首页 闪购项列表
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public ActionResult FlashSalesItemList( DWZPageInfo pi, int menuId )
        {
            #region 搜索条件
            WhereClip wc = Model.FlashSales._.FlashSales_MenuId == menuId;
            var salesList = FlashSalesBll.GetlistByCondition(wc);
            #endregion

            return View("Partial/SalesList", salesList);
        }

        /// <summary>
        /// 闪购药品列表页
        /// </summary>
        /// <returns></returns>
        public ActionResult CommodityList(int salesId)
        {
            #region 搜索条件

            WhereClip where = null;
            #endregion
            return View();
        }

        /// <summary>
        /// 药品列表项
        /// </summary>
        /// <param name="menuId"></param>
        /// <param name="pi"></param>
        /// <returns></returns>
        public ActionResult CommodityItemList( int menuId, DWZPageInfo pi)
        {
            #region 搜索条件

            WhereClip where = Commodity._.Commodity_IsDel == false &&
                WhereClip.Bracket(Commodity._.Commodity_Status == (int)Status.Show || Commodity._.Commodity_Status == (int)Status.View);
            if (menuId > 0)
            {
                where &= Commodity._.Commodity_TagId == menuId;
            }
            OrderByClip order = new OrderByClip("Commodity_CreateTime Desc");
            if (!string.IsNullOrEmpty(pi.SortOrder) && !string.IsNullOrEmpty(pi.SortName))
            {
                order = order & new OrderByClip(pi.SortName + " " + pi.SortOrder);
            }

            #endregion
            var commodityList = CommodityBll.GetPageList(pi.NumPerPage, pi.PageNum, where, order).DataSource as List<Commodity>;
            if (commodityList != null && string.Equals("Commodity_CostPrice", pi.SortName))//如果是价格排序 要按照折后价进行排序
            {
                commodityList = string.IsNullOrEmpty(pi.SortOrder) || pi.SortOrder.ToLower() == "asc"
                    ? commodityList.OrderBy(c => c.Commodity_CostPrice * c.Commodity_Discount).ToList()
                    : commodityList.OrderByDescending(c => c.Commodity_CostPrice * c.Commodity_Discount).ToList();
            }
            //返回该tag下的所有药品
            return View("Partial/CommodityItemList", commodityList);
        }
        /// <summary>
        /// 闪购药品详情页
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
