using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

//引用
using Shop.BLL;
using Shop.Model;
using Shop.Common;
using MySoft.Data;

namespace Shop.Web.Controllers
{
    /// <summary>
    /// 首页
    /// </summary>
    [AuthorizeType(NeedLogin = false)]
    public class HomeController : Controller
    {
        
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //通知公告
            return View();
           
        }
    }
}
