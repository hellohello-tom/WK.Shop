using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySoft.Data;
using Shop.BLL;
using Shop.Model;
using Shop.Common;

namespace Shop.Web.Areas.Phone.Controllers
{
    public class CommodityController : Controller
    {

        private readonly NavigationBLL navigationBLL = new NavigationBLL();
        private readonly MenuBLL menuBLL = new MenuBLL();
        private readonly CommodityBLL commodityBll = new CommodityBLL();
        private readonly FileAttrBLL fileAttrBll = new FileAttrBLL();
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
            var navList = navigationBLL.GetList(Navigation._.Navigation_IsDel == false && Navigation._.Navigation_Status == (int)Status.Show
                , Navigation._.Navigation_Sort.Asc && Navigation._.Navigation_CreateTime.Desc);
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
            WhereClip where = Menu._.Menu_IsDel == false && Menu._.Menu_Status == (int)Status.Show;
            if (navId != 0)
                where &= Menu._.Menu_NavigationId == navId;
            ViewBag.NavId = navId;
            #endregion
            var tagList = menuBLL.GetPageList(pi.NumPerPage, pi.PageNum, where).DataSource as List<Menu>;

            return View("Partial/TagList", tagList);
        }

        /// <summary>
        /// 药品列表页
        /// </summary>
        /// <param name="tagId"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public ActionResult CommodityList(int tagId,string search="")
        {
            if (tagId>0)
            {
                ViewBag.TagId = tagId;
                ViewBag.Tag = menuBLL.GetModelByCache(tagId);
            }
            
            if (!string.IsNullOrWhiteSpace(search))
            {
                ViewBag.SearchTitle = "搜索结果";
                ViewBag.Search = search;
            }
            
            return View();
        }

        /// <summary>
        /// 药品列表项
        /// </summary>
        /// <param name="tagId"></param>
        /// <param name="pi"></param>
        /// <param name="search"></param>
        /// <param name="notId">药品详情页（猜你喜欢的药品本身Id）</param>
        /// <returns></returns>
        public ActionResult CommodityItemList(int tagId, DWZPageInfo pi, string search,int notId=0)
        {
            #region 搜索条件

            WhereClip where = Commodity._.Commodity_IsDel == false &&
                WhereClip.Bracket(Commodity._.Commodity_Status == (int)Status.Show || Commodity._.Commodity_Status == (int)Status.View);
            if (tagId > 0)
            {
                where &= Commodity._.Commodity_TagId == tagId;
            }
                
            if (!string.IsNullOrEmpty(search))
            {
                where &=  WhereClip.Bracket(Commodity._.Commodity_Name.Like("%" + search + "%") || Commodity._.Commodity_Content.Like("%" + search + "%")
                || Commodity._.Commodity_Remind.Like("%" + search + "%"));
            }
            OrderByClip order = new OrderByClip("Commodity_CreateTime Desc");
            if (!string.IsNullOrEmpty(pi.SortOrder)&&!string.IsNullOrEmpty(pi.SortName))
            {
                order = order&new OrderByClip(pi.SortName + " " + pi.SortOrder);
            }
            if (notId!=0)
            {
                where &= Commodity._.Id != notId;
            }
            
            #endregion
            var commodityList = commodityBll.GetPageList(pi.NumPerPage, pi.PageNum, where, order).DataSource as List<Commodity>;
            if (commodityList!=null&&string.Equals("Commodity_CostPrice", pi.SortName))//如果是价格排序 要按照折后价进行排序
            {
                commodityList = string.IsNullOrEmpty(pi.SortOrder) || pi.SortOrder.ToLower() == "asc"
                    ? commodityList.OrderBy(c => c.Commodity_CostPrice*c.Commodity_Discount).ToList()
                    : commodityList.OrderByDescending(c => c.Commodity_CostPrice*c.Commodity_Discount).ToList();
            }
            if (notId != 0)
            {
                //返回关联药品
                return View("Partial/RelatedCommodityList", commodityList);
            }
            //返回该tag下的所有药品
            return View("Partial/CommodityItemList", commodityList);
        }

        /// <summary>
        /// 药品详情页
        /// </summary>
        /// <param name="id">药品Id</param>
        /// <returns></returns>
        public ActionResult CommodityDeatil(int id)
        {
            var commodity = commodityBll.GetModelByCache(id);
            if (commodity==null)
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

            var imgList = fileAttrBll.GetList(where, order);
            ViewBag.ImgList = imgList;
            return View(commodity);
        }

        /// <summary>
        /// 药品详情图片页
        /// </summary>
        /// <param name="id">关联药品Id</param>
        /// <param name="cimg"></param>
        /// <param name="bCode">关联商品代码</param>
        /// <returns></returns>
        public ActionResult CommodityImgList( int id, bool cimg = false, BizCode bCode = BizCode.Commodity )
        {
            #region 搜索条件

            WhereClip where = FileAttr._.FileAttr_IsDel == false;
            
            if (id > 0)
                where &= FileAttr._.FileAttr_BussinessId == id;
            where &= FileAttr._.FileAttr_BussinessCode == bCode.ToString();
            OrderByClip order = new OrderByClip("FileAttr_CreateTime Desc");

            #endregion

            var imgList = fileAttrBll.GetList(where, order);
            if (cimg)
            {
                return View("Partial/CImgList", imgList);
            }
            return View("Partial/ImgList", imgList);
        }
    }
}
