using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web
{
    /// <summary>
    /// 授权过滤器
    /// 
    /// tomCat
    /// 2014-2-27
    /// </summary>
    public class AuthorizeFilter : IAuthorizationFilter
    {
        /// <summary>
        /// 判断权限
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            var authorizeType = new AuthorizeTypeAttribute();

            #region 当前action是否需要进行权限判断
            string strArea = (filterContext.RouteData.Values["area"] ?? filterContext.RouteData.DataTokens["area"] ?? "").ToString();
            string strController = (filterContext.RouteData.Values["controller"] ?? filterContext.RouteData.DataTokens["controller"] ?? "").ToString();
            string strAction = (filterContext.RouteData.Values["action"] ?? filterContext.RouteData.DataTokens["action"] ?? "").ToString();

            var controller = ControllerBuilder.Current.GetControllerFactory().CreateController(filterContext.RequestContext, strController);
            object[] objs = controller.GetType().GetCustomAttributes(typeof(AuthorizeTypeAttribute), true);
            if (objs.Length > 0)
            {//controller上有标记
                authorizeType = objs[0] as AuthorizeTypeAttribute;
            }
            else
            {
                objs = controller.GetType().GetMethods().First(x => x.Name == strAction).GetCustomAttributes(typeof(AuthorizeTypeAttribute), true);
                if (objs != null && objs.Length > 0)
                {//action上有标记，
                    authorizeType = objs[0] as AuthorizeTypeAttribute;
                }
            }
            #endregion

            if (!authorizeType.NeedLogin)
                return;

            if (UserContext.CurUserInfo == null)
            {
                #region 登录超时 或未登录
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                { //如果是ajax操作，返回登录超时 json数据
                    var callback = DWZMessage.TimeOut();
                    var jsonResult = new JsonResult();
                    jsonResult.Data = callback;
                    jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    filterContext.Result = jsonResult;
                }
                else
                { //如果是直接访问页面的操作 ，跳转到登陆页
                    var view = new ViewResult();
                    view.ViewName = "~/Views/Shared/NoLogin.cshtml";
                    filterContext.Result = view;
                }
                #endregion
            }
            else
            {
                if (!authorizeType.NeedAuthorize)
                    return;

                return;
#warning 暂时不判断权限
                #region 如果登录了 判断有没有权限
                var authCode = string.Empty;
                if (!string.IsNullOrEmpty(strArea))
                    authCode += strArea + "_";
                authCode += strController;

                if (!UserContext.IsAuthorized(authCode))
                {
                    // 如果没有权限
                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        //如果是ajax操作，返回无权限提示json
                        var callback = DWZMessage.Faild("无操作权限，请与管理员联系!");
                        var jsonResult = new JsonResult();
                        jsonResult.Data = callback;
                        jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                        filterContext.Result = jsonResult;
                    }
                    else
                    {
                        //如果是直接访问页面的操作 ，跳转到无权限提示页面
                        var view = new ViewResult();
                        view.ViewName = "~/Views/Shared/NoAuthorize.cshtml";
                        filterContext.Result = view;
                    }
                }
                #endregion
            }
        }
    }

}
