using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.BLL;
using MySoft.Data;
using Shop.Model;
using Shop.Common;

namespace Shop.Web.Areas.Credit.Controllers
{
    [AuthorizeType(NeedLogin = false)]
    public class RegisterController : Controller
    {
        /// <summary>
        /// 登录操作
        /// </summary>
        /// <param name="retrunUrl">登陆后跳转页面</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(SysAdmin model)
        {
            SysAdmin user = UserContext.ValidateLogin(model.UserName, model.PassWord); //验证用户信息 并 记录登录用户session和cookie
            if (user == null)
            {
                TempData["msg"] = "用户名或密码错误";
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Main", new { @area = "Admin" });//成功登录，跳转
        }
    }
}



