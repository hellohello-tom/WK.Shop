using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Areas.Phone.Controllers
{
    public class WarnController : Controller
    {
        //
        // GET: /Phone/Warn/

        public ActionResult Error(string title="404",string msg="Sorry，站点错误")
        {
            ViewBag.Title = Server.UrlDecode(title);
            ViewBag.Msg = Server.UrlDecode(msg);
            return View();
        }

    }
}
