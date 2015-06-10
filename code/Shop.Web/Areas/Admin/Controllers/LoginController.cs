using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using Shop.Model;

namespace Shop.Web.Areas.Admin.Controllers
{
    [AuthorizeType(NeedLogin = false)]
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录操作
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="passWord">密码</param>
        /// <param name="retrunUrl">登陆后跳转页面</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(string userName, string passWord, string code,string retrunUrl="")
        {
            TempData["msg"] = "";
            if(false)
            //if (!Common.VerifyCodeHelper.IsPass(code))
            {//验证码错误
                TempData["msg"] = "验证码错误";
            }
            else
            {//验证码正确
                SysAdmin user = UserContext.ValidateLogin(userName, passWord); //验证用户信息 并 记录登录用户session和cookie

                if (user != null)
                    return RedirectToAction("Index", "Main", new { area = "Admin" });
                else
                    TempData["msg"] = "用户名或密码错误";
            }

            return RedirectToAction("Index", "Login", new { area = "Admin" });
        }

        /// <summary>
        /// 登出操作
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            //清除session 和cookie
            UserContext.LoginOut();

            return RedirectToAction("Index", "Login", new { area = "Admin" });
        }
    }
}
