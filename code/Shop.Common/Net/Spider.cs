using System;
using System.IO;
using System.Net;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Collections.Generic;

namespace Shop.Common
{
    /// <summary>
    ///  采集器类
    ///  Tom.Team
    ///  2012-4-27
    ///  
    ///  添加对http代理的支持
    ///  Tom.Team
    ///  2013-8-26
    /// </summary>
    public class Spider
    {

        /// <summary>
        /// 浏览器标识(UA)
        /// </summary>
        private static string[] _userAgentList = new string[] { 
            "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; CIBA; MAXTHON 2.0)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; InfoPath.1)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Comcast Install 1.0; .NET CLR 1.0.3705; .NET CLR 1.1.4322; Media Center PC 4.0; .NET CLR 2.0.50727)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 2.0.50727)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Maxthon; .NET CLR 1.1.4322)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; CIBA)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; InfoPath.2; .NET CLR 3.0.04506.30)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; QQDownload 1.7; CIBA)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; InfoPath.1; CollapsarDSP; )", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; SLCC1; .NET CLR 2.0.50727; .NET CLR 3.0.04506; CIBA)", 
            "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; QQDownload 1.7; .NET CLR 1.1.4322)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; .NET CLR 1.1.4322)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; CIBA)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 3.0.04506.30; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; InfoPath.2; .NET CLR 2.0.50727)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; WOW64; Foxy/1; SLCC1; .NET CLR 2.0.50727; .NET CLR 3.0.04506; .NET CLR 1.1.4322; MAXTHON 2.0)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Avant Browser; InfoPath.1; .NET CLR 2.0.50727; .NET CLR1.1.4322)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; QQDownload 1.7)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; QQDownload 1.7; TencentTraveler 4.0)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Maxthon; .NET CLR 1.1.4322; InfoPath.1; .NET CLR 2.0.50727)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; CNCDialer; .NET CLR 2.0.50727)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; QQDownload 1.7; SLCC1; .NET CLR 2.0.50727; .NET CLR 3.0.04506; InfoPath.2)", 
            "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; SLCC1; .NET CLR 2.0.50727; .NET CLR 3.0.04506; .NET CLR 1.1.4322; CIBA)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; SLCC1; .NET CLR 2.0.50727; Media Center PC 5.0; .NET CLR 3.0.04506; InfoPath.2)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; QQDownload 1.7; .NET CLR 1.1.4322; CIBA)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; (R1 1.5))", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; CIBA)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; (R1 1.6))", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; MAXTHON 2.0)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727; MAXTHON 2.0)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; CNCDialer; QQDownload 1.7; Avant Browser)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Maxthon)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; MAXTHON 2.0)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 1.1.4322; InfoPath.2)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; InfoPath.1)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; QQDownload 1.7; TencentTraveler ; .NET CLR 1.1.4322; .NET CLR 2.0.50727)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; TencentTraveler 4.0;)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; InfoPath.1)", 
            "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; SLCC1; .NET CLR 2.0.50727; .NET CLR 3.0.04506; InfoPath.2)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727; InfoPath.1)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; SLCC1; .NET CLR 2.0.50727; .NET CLR 3.0.04506; InfoPath.1)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; SLCC1; .NET CLR 2.0.50727; Media Center PC 5.0; .NET CLR 3.0.04506; InfoPath.1)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; SLCC1; .NET CLR 2.0.50727; Media Center PC 5.0; .NET CLR 3.0.04506; InfoPath.1; CIBA)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; QQDownload 1.7; SLCC1; .NET CLR 2.0.50727; Media Center PC 5.0; .NET CLR 3.0.04506)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; CNCDialer; CIBA; .NET CLR 1.1.4322)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; QQDownload 1.7; TencentTraveler 4.0; CIBA)", "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0)"
         };
        public static string[] UserAgentList
        {
            get { return _userAgentList; }
        }
        
        /// <summary>
        /// Cookie容器
        /// </summary>
        private static CookieContainer _cookiesContainer = null;
        public static CookieContainer CookiesContainer
        {
            get
            {
                if (_cookiesContainer == null)
                {
                    _cookiesContainer = new CookieContainer();
                }
                return _cookiesContainer;
            }
            set
            {
                _cookiesContainer = value;

            }
        }
        /// <summary>
        ///  http代理
        /// </summary>
        private static List<string> _proxyList = null;
        public static List<string> ProxyList
        {
            get
            {
                if (_proxyList == null)
                {
                    _proxyList = new List<string>();
                }
                return _proxyList;
            }
            set
            {
                _proxyList= value;
            }
        }
		
        /// <summary>
        /// 获取网页的html
        /// CreatUser：Tom.Team
        /// CreatTime：2012-4-26
        /// 
        /// 添加对https(ssl协议)的支持
        /// EditUser：ThingWang
        /// EidtTime：2012-6-12
        /// 
        /// 修改为自动判断编码
        /// EditUser：Tom.Team
        /// EditTime：2012-10-7
        /// 
        /// 添加decode参数，如果此参数为空时，自动判断编码
        /// EditUser：Tom.Team
        /// EditTime：2012-12-8
        /// 
        /// 删除 方法签名中的 cookie，只能通过属性传递cookie参数。
        /// EditUser：hinkWang
        /// EditTime：2013-8-26
        /// 
        /// 添加对http代理的支持
        /// EditUser：hinkWang
        /// EditTime：2013-8-26
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method">get or post</param>
        /// <param name="argumentStr">a=1&b=2</param>
        /// <param name="decode"></param>
        /// <param name="referer">来源页</param>
        /// <param name="userAgent">userAgentList的索引值 或userAgent字符串</param>
        /// <param name="userAgent">proxyList的索引值 或Proxy url字符串</param>
        /// <returns></returns>
        public static string LoadUrl(string url, string method = "get", string argumentStr = "", string decode = "", string referer = "http://www.baidu.com", string userAgent = "0",string proxy="0")
        {
            string html = "";
            string contentType = "text/HTML";
            if (method.ToLower() == "get")
            {
                if (argumentStr != "")
                {
                    if (url.Contains("?"))
                        url += "&" + argumentStr;
                    else
                        url += "?" + argumentStr;
                }
            }
            else
            {
                contentType = "application/x-www-form-urlencoded";
            }

            if (char.IsNumber(userAgent, 0))
            {
                try
                {
                    userAgent = _userAgentList[int.Parse(userAgent)];
                }
                catch (Exception)
                {
                    userAgent = _userAgentList[0];
                }
            }

            if (char.IsNumber(proxy, 0))
            {
                try
                {
                    proxy = ProxyList.Count > 0 ? ProxyList[int.Parse(proxy)] : "";
                }
                catch (Exception)
                {
                    proxy = "";
                }
            }
           
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                if (url.StartsWith("https:", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                    //request.ProtocolVersion = HttpVersion.Version10;
                }
                request.ContentType = contentType;
                request.CookieContainer = CookiesContainer;
                request.Referer = referer;
                request.Method = method;
                request.UserAgent = userAgent;

                if (proxy!="")
                    request.Proxy = new WebProxy(proxy);

                if (method.ToLower() == "post" && argumentStr != "")
                {
                    byte[] bytes = Encoding.GetEncoding("utf-8").GetBytes(argumentStr);
                    request.ContentLength = bytes.Length;
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                CookiesContainer.Add(response.Cookies);
                html = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(decode == "" ? response.CharacterSet : decode)).ReadToEnd();
                response.Close();
            }
            catch (Exception ex)
            {

                html = "出错了！" + ex.ToString();
            }
            return html;
        }

        /// <summary>
        /// 验证证书 处理证书提示
        /// CreatUser：ThingWang
        /// CreatTime：2012-6-12
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
    }
}

