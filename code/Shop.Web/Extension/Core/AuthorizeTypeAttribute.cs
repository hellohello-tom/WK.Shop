using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web
{

    /// <summary>
    ///  权限判断类型
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true)]
    public class AuthorizeTypeAttribute : Attribute
    {
        private bool _needLogin = true;
        private bool _needAuthorize = true;

        /// <summary>
        /// 需要判断登录
        /// </summary>
        public bool NeedLogin { get { return _needLogin; } set { _needLogin = value; } }

        /// <summary>
        /// 需要判断权限
        /// </summary>
        public bool NeedAuthorize { get { return _needAuthorize; } set { _needAuthorize = value; } }

    }
}
