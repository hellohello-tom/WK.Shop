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
    public class NavigationController : Controller
    {
        private readonly TagBLL tagBll = new TagBLL();
        private readonly NavigationBLL navigationBLL = new NavigationBLL();


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NavList()
        {
            var navList = navigationBLL.GetList(Navigation._.Navigation_IsDel == false, Navigation._.Navigation_Sort.Asc 
                && Navigation._.Navigation_CreateTime.Desc);
            var firstOrDefault = navList.FirstOrDefault();
            if (firstOrDefault != null) ViewBag.NavId = firstOrDefault.Id;
            return View("Partial/NavList",navList);
        }

        public ActionResult TagList(DWZPageInfo pi,int navId)
        {
            #region 搜索条件
            WhereClip where = Tag._.Tag_IsDel == false;
            if (navId!=0)
                where &= Tag._.Tag_NavigationId == navId;
            ViewBag.NavId = navId;
            #endregion
            var tagList = tagBll.GetPageList(pi.NumPerPage, pi.PageNum, where).DataSource as List<Tag>;

            return View("Partial/TagList", tagList);
        }

    }
}
