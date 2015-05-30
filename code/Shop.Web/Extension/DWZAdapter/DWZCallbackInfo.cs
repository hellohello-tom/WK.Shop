using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Web
{
    /// <summary>
    /// DWZajax操作返回消息实体
    /// 
    /// tomCat
    /// 2014-1-26
    /// </summary>
    public class DWZCallbackInfo
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public DWZStatusCode statusCode { get; set; }

        /// <summary>
        /// 提示语
        /// </summary>
        public string message{get;set;}

        /// <summary>
        /// 返回navTabId可以把那个navTab标记为reloadFlag=1, 下次切换到那个navTab时会重新载入内容.
        /// </summary>
        public string navTabId{get;set;}
        
       /// <summary>
        /// DWZajax操作回调
        /// <example>
        /// closeCurrent 关闭当前tab
        /// forward 会将当前tab重定向到ForwardUrl指定页面
        /// forwardConfirm 在将当前tab重定向到ForwardUrl指定页面前提示用户，用户点是将跳转页面，用户点否将关闭当前navTab
        /// </example>
       /// </summary>
        public string callbackType { get; set; }

        /// <summary>
        /// 只有callbackType为"forward"或"forwardConfirm"时,forwardUrl需要有值
        /// </summary>
        public string forwardUrl{get;set;}

        /// <summary>
        /// 返回前台的用户数据
        /// </summary>
        public object data { get; set; }
    }

    /// <summary>
    /// DWZajax操作状态码 
    /// 
    /// tomCat
    /// 2014-1-26
    /// </summary>
    public enum DWZStatusCode { 
        /// <summary>
        /// 成功
        /// </summary>
        Ok=200,
        /// <summary>
        /// 失败
        /// </summary>
        Error= 300,
        /// <summary>
        /// 登录超时
        /// </summary>
        TimeOut=301
    }
}
