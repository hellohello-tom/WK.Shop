using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.Web;
using System.Text;

namespace System.Web.Mvc
{
    /// <summary>
    /// html扩展类
    /// 
    /// tomCat
    /// </summary>
    public static class HtmlExtension
    {

        /// <summary>
        /// 权限按钮
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="authCode"></param>
        /// <param name="html"></param>
        /// <returns></returns>
        public static MvcHtmlString RightsButton(this HtmlHelper helper, string authCode, string html)
        {
            if (UserContext.CurUserInfo.UserName.ToLower() != "kingroad" && !UserContext.IsAuthorized(authCode))
            {
                html = string.Empty;
            }

            return MvcHtmlString.Create(html);
        }

        /// <summary>
        /// MVC分页
        /// </summary>
        /// <param name="helper">HtmlHelper类</param>
        /// <param name="totalPages">总页数</param>
        /// /// <param name="currentPage">当前页</param>
        /// <param name="pagesToShow">前后显示的页数</param>
        public static MvcHtmlString Pager(this HtmlHelper helper, int totalPages, int currentPage = 1, int pagesToShow = 5)
        {
            /*
             <div class="pg">
                 <a href="#" class="pgb"><i>&laquo;</i>返回列表</a>
                 <a class="prev" href="#">&laquo;</a>
                 <a href="#">1</a>
                 <a href="#">2</a>
                 <strong>3</strong>
                 <a href="#">4</a>
                 <a href="#">5</a>
                 <a href="#">6</a>
                 <a href="#">7</a>
                 <span>
                    <input name="custompage" title="输入页码，按回车快速跳转" class="px" type="text" size="2" value="3">
                    <em title="共 7 页"> / 7 页</em>
                 </span>
                 <a class="nxt" href="#">下一页<i>&raquo;</i></a>
             </div>
             */

            string url = helper.ViewContext.HttpContext.Request.Url.PathAndQuery;
            //判断有没有pageNum参数 如果有了，去掉
            int index = url.IndexOf("pageNum");
            if (index > -1) url = url.Substring(0, index - 1);

            //参数连接符
            string linkChr = string.Empty;
            if (url.Contains("?"))
                linkChr = "&";
            else
                linkChr = "?";


            if (currentPage > totalPages) currentPage = totalPages;
            else if (currentPage < 1) currentPage = 1;

            StringBuilder html = new StringBuilder("<div class=\"pg\"><a title=\"返回列表第一页\" href=\"" + url + "\" class=\"pgb\"><i>&laquo;</i>返回列表</a>");
            //上一页 按钮
            if (currentPage == 1 || currentPage == 0)
                html.AppendFormat("<a class=\"prev\" title=\"已经是第一页了\" href=\"javascript:;\">&laquo;</a>");
            else
                html.AppendFormat("<a class=\"prev\" title=\"上一页\" href=\"{0}{1}pageNum={2}\">&laquo;</a>", url, linkChr, currentPage - 1);

            //页码按钮
            int startPage = currentPage - pagesToShow;
            if (startPage < 1) startPage = 1;
            int count = pagesToShow * 2 + 1;
            //创建需要的列表
            html.Append(Enumerable.Range(startPage, count)
            .Where(i => { return i <= totalPages; })
            .Aggregate(new StringBuilder(), (seed, page) =>
            {
                //当前页
                if (page == currentPage)
                    seed.AppendFormat("<strong>{0}</strong>", page);
                else
                    seed.AppendFormat("<a title=\"跳转到第{2}页\"  href=\"{0}{1}pageNum={2}\">{2}</a>", url, linkChr, page);
                return seed;
            }));

            //goto
            html.AppendFormat("<span><input id=\"custompage\" name=\"custompage\" title=\"输入页码，按回车快速跳转\" class=\"px\" type=\"text\" size=\"5\" maxlength=\"5\" value=\"{0}\"/><em title=\"共 {1} 页\"> / {1} 页</em></span>", currentPage, totalPages);

            //下一页 按钮
            if (currentPage == totalPages)
                html.AppendFormat("<a class=\"nxt\" title=\"已经是最后一页了\" href=\"javascript:;\">下一页<i>&raquo;</i></a>");
            else
                html.AppendFormat("<a class=\"nxt\" title=\"下一页\" href=\"{0}{1}pageNum={2}\">下一页<i>&raquo;</i></a>", url, linkChr, currentPage + 1);

            //goto 的js
            html.AppendLine();
            html.AppendLine("<script type='text/javascript'>");
            html.AppendLine("$('#custompage').keydown(function(e){");
            html.AppendLine("  if(e.keyCode==13){ location.href='" + url + linkChr + "pageNum='+ $(this).val(); } ");
            html.AppendLine("})");
            html.AppendLine(".keyup(function(){ ");
            html.AppendLine("  this.value=this.value.replace(/[^\\d]/g,'')");
            html.AppendLine("  if(this.value<1){this.value=1;} else if(this.value>" + totalPages + "){this.value=" + totalPages + ";}");
            html.AppendLine("});");
            html.AppendLine("</script></div>");

            return MvcHtmlString.Create(html.ToString());
        }
    }
}