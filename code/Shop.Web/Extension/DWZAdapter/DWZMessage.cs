using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Shop.Web
{
    /// <summary>
    /// DWZ ajax操作 返回消息
    /// 
    /// tomCat
    /// 2014-1-26
    /// </summary>
    public static class DWZMessage
    {
   
        /// <summary>
        /// 操作成功!
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <param name="navTabId"> 要刷新的navtabid,DWZForm表单的callback需为navTabAjaxDone或dialogAjaxDone</param>
        /// <param name="isCloseCurrent">是否关闭当前tab或dialog DWZForm表单的callback需为navTabAjaxDone或dialogAjaxDone</param>
        /// <returns></returns>
        public static DWZCallbackInfo Success(string msg = "操作成功!",string navTabId="",bool isCloseCurrent=false,object data=null)
        {
            var callback = new DWZCallbackInfo();
            callback.statusCode = DWZStatusCode.Ok;
            callback.message = msg;
            callback.navTabId = navTabId;
            callback.data = data;
            if(isCloseCurrent)
                callback.callbackType = "closeCurrent";
            
            return callback;
        }

        /// <summary>
        /// 操作失败!
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <returns></returns>
        public static DWZCallbackInfo Faild(string msg = "操作失败!")
        {
            var callback = new DWZCallbackInfo();
            callback.statusCode = DWZStatusCode.Error;
            callback.message = msg;
            return callback;
        }

        /// <summary>
        /// 登录超时!
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <returns></returns>
        public static DWZCallbackInfo TimeOut(string msg = "登录超时,请重新登录!")
        {
            var callback = new DWZCallbackInfo();
            callback.statusCode = DWZStatusCode.TimeOut;
            callback.message = msg;
            return callback;
        }

        /// <summary>
        /// 操作成功并跳转到指定页面。
        /// DWZForm表单的callback需为navTabAjaxDone
        /// </summary>
        /// <returns></returns>
        public static DWZCallbackInfo SuccessAndRedirect(string url, string msg = "操作成功!")
        {
            var callback = new DWZCallbackInfo();
            callback.statusCode = DWZStatusCode.Ok;
            callback.message = msg;
            callback.callbackType ="forward";
            callback.forwardUrl = url;
            return callback;
        }

        /// <summary>
        /// 操作成功并提示用户操作；
        /// 用户点是 跳转指定页面；
        /// 用户点否 关闭指定的navTab。
        /// DWZForm表单的callback需为navTabAjaxDone
        /// </summary>
        /// <param name="url">跳转url</param>
        /// <param name="navTabId">要关闭的navTabId</param>
        /// <param name="msg">提示信息</param>
        /// <returns></returns>
        public static DWZCallbackInfo SuccessAndRedirect(string url, string navTabId, string msg = "操作成功!跳转页面or关闭页面?")
        {
            var callback = new DWZCallbackInfo();
            callback.statusCode = DWZStatusCode.Ok;
            callback.message = msg;
            callback.callbackType = "forwardConfirm";
            callback.forwardUrl = url;
            callback.navTabId = navTabId;
            return callback;
        }

    }
}
