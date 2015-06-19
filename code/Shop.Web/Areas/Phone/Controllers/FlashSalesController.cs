using System;
using System.Collections.Generic;
using System.Data;
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
        private static readonly FlashSalesBLL FlashSalesBll = new FlashSalesBLL();
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

            WhereClip where = Menu._.Menu_IsDel == false && Menu._.Menu_Status == (int)Status.Show && Menu._.Menu_Type == MenuType.FlashSalues.ToString();
            #endregion
            var menuList = MenuBll.GetList(where, Menu._.Menu_Sort.Desc);
            WhereClip wc = FileAttr._.FileAttr_BussinessCode == BizCode.FlashSales.ToString();
            var dt = FlashSalesBll.GetlistByCondition(wc);
            ViewBag.FlashSalesDataTable = dt;
            return View(menuList);
        }

        /// <summary>
        /// 闪购首页 闪购项列表
        /// 局部视图
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public ActionResult FlashSalesItemList(int menuId )
        {
            #region 搜索条件
            WhereClip wc = FileAttr._.FileAttr_BussinessCode == BizCode.FlashSales.ToString();
            if (menuId!=0)
            {
                wc &= Model.FlashSales._.FlashSales_MenuId == menuId;
            }
            var salesDT = FlashSalesBll.GetlistByCondition(wc);
            #endregion

            return View("Partial/FlashSalesItemList", salesDT);
        }

        /// <summary>
        /// 闪购药品列表页
        /// </summary>
        /// <returns></returns>
        public ActionResult CommodityList( int Id )
        {
            if (Id > 0)
            {
                ViewBag.FalshSalesId = Id;
                ViewBag.FalshSales = FlashSalesBll.GetModelByCache(Id);
            }
            return View();
        }

        /// <summary>
        /// 闪购药品项列表
        /// 局部视图
        /// </summary>
        /// <param name="salesId"></param>
        /// <param name="pi"></param>
        /// <param name="search"></param>
        /// <param name="notId"></param>
        /// <returns></returns>
        public ActionResult CommodityItemList( int salesId, DWZPageInfo pi, string search, int notId = 0 )
        {
           DataTable commodityDataTable;
            #region 搜索条件

           WhereClip where = Realtion._.Realtion_IsDel == false &&Realtion._.Realtion_IsDel==false&&
                WhereClip.Bracket(Commodity._.Commodity_Status == (int)Status.Show || Commodity._.Commodity_Status == (int)Status.View);
            if (salesId > 0)
            {
                where &= Realtion._.Realtion_SaleId == salesId;
            }

            //if (!string.IsNullOrEmpty(search))
            //{
            //    where &= WhereClip.Bracket(Commodity._.Commodity_Name.Like("%" + search + "%") || Commodity._.Commodity_Remind.Like("%" + search + "%"));
            //}
            OrderByClip order = new OrderByClip("Realtion_CreateTime Desc");
            //关联药品 不包含自己
            if (notId != 0)
            {
                where &= Commodity._.Id != notId;
            }
            if (string.IsNullOrEmpty(pi.SortOrder) && !string.IsNullOrEmpty(pi.SortName)) //有排序字段
            {
                order = new OrderByClip(pi.SortName + " " + pi.SortOrder);
            }
            if (salesId != 0) //默认加载 
            {
                order = new OrderByClip(pi.SortName + " " + pi.SortOrder);
                if (pi.SortName.Equals("Commodity_CostPrice", StringComparison.OrdinalIgnoreCase))//如果是价格排序 要按照折后价进行排序
                {
                    commodityDataTable = CommodityBll.GetFlashSalesCommdityPageTable(salesId, pi.SortOrder, pi.PageNum, pi.NumPerPage);
                }
                else //其他正常排序
                {
                    commodityDataTable = CommodityBll.GetFlashSalesCommodityListByCondition(pi.NumPerPage, pi.PageNum, where, order).DataSource;
                }
            }
            else //搜索
            {
                commodityDataTable = CommodityBll.GetFlashSalesCommodityListByCondition(pi.NumPerPage, pi.PageNum, where, order).DataSource ;
            }

            #endregion


            if (notId != 0)
            {
                //返回关联药品
                return View("Partial/RelatedCommodityList", commodityDataTable);
            }
            //返回该tag下的所有药品
            return View("Partial/CommodityItemList", commodityDataTable);
        }
        /// <summary>
        /// 闪购药品详情页
        /// </summary>
        /// <returns></returns>
        public ActionResult CommodityDetail( int id )
        {
            var falshSalesCommodity = FlashSalesBll.GetFlashSalesCommodity(id);
            if (falshSalesCommodity == null)
            {
                return Redirect(string.Format("/PhoneError?title={0}&msg={1}", "未找到", "你要找的药品不存在"));

            }
            #region 搜索条件

            WhereClip where = FileAttr._.FileAttr_IsDel == false;

            if (id > 0)
                where &= FileAttr._.FileAttr_BussinessId == id;
            where &= FileAttr._.FileAttr_BussinessCode == BizCode.Commodity.ToString();
            OrderByClip order = new OrderByClip("FileAttr_CreateTime Desc");

            #endregion

            var imgList = FileAttrBll.GetList(where, order);
            ViewBag.ImgList = imgList;
            return View(falshSalesCommodity);
        }

    }
}
