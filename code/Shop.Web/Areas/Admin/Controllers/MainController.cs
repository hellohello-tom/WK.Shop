using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace Shop.Web.Areas.Admin.Controllers
{

    [AuthorizeType(NeedAuthorize = false)]
    public class MainController : Controller
    {

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var moduleList = UserContext.CurUserInfo.ModuleList.FindAll(x=>x.IsShow==1);//当前用户可访问的模块

            StringBuilder sbHtml = new StringBuilder();
            var firstModuleList = moduleList.FindAll(x => x.ParentId == 0);//第一级
            List<Shop.Model.SysModule> childModuleList = null;//子级 临时变量

            //第1级
            foreach (var root in firstModuleList)
            {
                sbHtml.AppendFormat("<div class='accordionHeader'><h2><span>Folder</span>{0}</h2></div>", root.Name);
                sbHtml.AppendFormat("<div class='accordionContent'><ul class='tree'>");
                //第2级
                childModuleList = moduleList.FindAll(x => x.ParentId == root.Id);
                foreach (var item in childModuleList)
                {
                    sbHtml.AppendFormat("<li><a href='{0}' target='navTab' rel='{1}'>{2}</a>{3}</li>",
                                             item.Url,
                                             item.Code,
                                             item.Name,
                                             GetChildHtml(moduleList, item.Id)
                                        );
                }
                sbHtml.Append("</ul> </div>");
            }
            ViewBag.MenuHtml = sbHtml.ToString();

            ViewBag.UserAccount = string.Format("{0}({1})", UserContext.CurUserInfo.RealName, UserContext.CurUserInfo.UserName);
            return View();
        }

        /// <summary>
        /// 获取子菜单html
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        private string GetChildHtml(List<Shop.Model.SysModule> moduleList, int pid)
        {
            var childModuleList = moduleList.FindAll(x => x.ParentId == pid);//子集

            StringBuilder sbHtml = new StringBuilder();
            if (childModuleList.Count > 0)
            {
                sbHtml.Append("<ul>");
                foreach (var item in childModuleList)
                {
                    sbHtml.AppendFormat("<li><a href='{0}' target='navTab' rel='{1}'>{2}</a>{3}</li>",
                                             item.Url,
                                             item.Code,
                                             item.Name,
                                             GetChildHtml(moduleList, item.Id)
                                        );
                }
                sbHtml.Append("</ul>");
            }
            return sbHtml.ToString();
        }

    }
}
