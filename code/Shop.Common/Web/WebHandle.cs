using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Shop.Common
{
    /// <summary>
    /// WEB帮助类
    /// 
    /// ThinkWang
    /// 2014-3-10
    /// </summary>
     public class WebHandle
    {
         /// <summary>
         /// 获取用户客户端IP
         /// </summary>
         public static string UserIP
         {
             get
             {
                 string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                 if (string.IsNullOrEmpty(ip))
                 {
                     ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                 }
                
                 return ip;
             }
         }

         /// <summary>
         /// 获取物理路径
         /// </summary>
         /// <param name="?"></param>
         /// <returns></returns>
         public static string GetMapPath(string strPath)
         {
            if (!string.IsNullOrEmpty(strPath) && HttpContext.Current != null)
            {
                strPath= HttpContext.Current.Server.MapPath(strPath);
            }
            return strPath;
         }
    }
}
