using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Shop.Common
{
    public class CookieHelper
    {
        private static string appPrefix = ConfigHelper.Get("AppPrefix");

        public static HttpCookie Get(string name)
        {
            return HttpContext.Current.Request.Cookies[appPrefix + name];
        }

        public static void Remove(string name)
        {
            Remove(Get(name));
        }

        public static void Remove(HttpCookie cookie)
        {
            if (cookie != null)
            {
                cookie.Expires = new DateTime(0x7bf, 5, 0x15);
                HttpContext.Current.Response.Cookies.Set(cookie);
            }
        }

        public static void Save(HttpCookie cookie)
        {
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static HttpCookie Set(string name)
        {
            return new HttpCookie(appPrefix + name);
        }
    }
}
