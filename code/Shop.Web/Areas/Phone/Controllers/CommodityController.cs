using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySoft.Data;
using Shop.BLL;
using Shop.Model;

namespace Shop.Web.Areas.Phone.Controllers
{
    public class CommodityController : Controller
    {

        private readonly NavigationBLL navigationBLL = new NavigationBLL();
        private readonly TagBLL tagBll = new TagBLL();
        private readonly CommodityBLL commodityBll = new CommodityBLL();
        /// <summary>
        /// 药店首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 首页导航列表
        /// </summary>
        /// <returns></returns>
        public ActionResult NavList()
        {
            var navList = navigationBLL.GetList(Navigation._.Navigation_IsDel == false, Navigation._.Navigation_Sort.Asc
                && Navigation._.Navigation_CreateTime.Desc);
            var firstOrDefault = navList.FirstOrDefault();
            if (firstOrDefault != null) ViewBag.NavId = firstOrDefault.Id;
            return View("Partial/NavList", navList);
        }
        /// <summary>
        /// 首页Tag列表
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="navId"></param>
        /// <returns></returns>
        public ActionResult TagList(DWZPageInfo pi, int navId)
        {
            #region 搜索条件
            WhereClip where = Tag._.Tag_IsDel == false;
            if (navId != 0)
                where &= Tag._.Tag_NavigationId == navId;
            ViewBag.NavId = navId;
            #endregion
            var tagList = tagBll.GetPageList(pi.NumPerPage, pi.PageNum, where).DataSource as List<Tag>;

            return View("Partial/TagList", tagList);
        }
        /// <summary>
        /// 药品列表页
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public ActionResult CommodityList(int tagId)
        {
            ViewBag.TagId = tagId;
            return View();
        }
        /// <summary>
        /// 药品列表项
        /// </summary>
        /// <param name="tagId"></param>
        /// <param name="pi"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public ActionResult CommodityItemList(int tagId, DWZPageInfo pi, string search)
        {
            #region 搜索条件

            WhereClip where = Commodity._.Commodity_IsDel == false;
            if (tagId > 0)
                where &= Commodity._.Commodity_TagId == tagId;
            if (!string.IsNullOrEmpty(search))
            {
                where &= (Commodity._.Commodity_Name.Like("%" + search + "%") || Commodity._.Commodity_Content.Like("%" + search + "%")
                || Commodity._.Commodity_Remind.Like("%" + search + "%"));
            }
            OrderByClip order = new OrderByClip("Commodity_CreateTime Desc");
            if (!string.IsNullOrEmpty(pi.SortOrder)&&!string.IsNullOrEmpty(pi.SortName))
            {
                order = order&new OrderByClip(pi.SortName + " " + pi.SortOrder);
            }
            
            #endregion
            var commodityList = commodityBll.GetPageList(pi.NumPerPage, pi.PageNum, where, order).DataSource as List<Commodity>;
            return View("Partial/CommodityItemList", commodityList);
        }
    }
}
