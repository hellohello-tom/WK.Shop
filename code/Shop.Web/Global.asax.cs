using Shop.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shop.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //载入日志文件
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(Server.MapPath("/Content/settings/log4net.config")));
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            if (!HttpContext.Current.IsCustomErrorEnabled) return;
            //记录异常
            var ex = Server.GetLastError();
            var httpEx = ex as HttpException;
            if (httpEx.GetHttpCode() == 500)
            {
                Logger.Fatal(ex);
                Server.ClearError();
            }
            else if (httpEx.GetHttpCode() == 404)
            {
                Logger.Warn("文件不存在", ex);
                Server.ClearError();
            }
            //跳转错误友好提示页面
            HttpContext.Current.Response.Clear();
            if (Request.Url.ToString().Contains("Phone"))
            {
                HttpContext.Current.Response.Redirect("/PhoneError");
            }
            HttpContext.Current.Response.End();
        }
    }
}