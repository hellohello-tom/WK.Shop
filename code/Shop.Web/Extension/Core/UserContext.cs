using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Shop.Model;
using Shop.Common;
using Shop.BLL;

namespace Shop.Web
{

    /// <summary>
    /// 当前登录用户的上下文信息
    /// </summary>
    public class UserContext
    {
        private static string sessionKey = "SysAdminSession";
        private static string cookieKey = "SysAdminCookie";
        private static bool checkCookie = ConfigHelper.GetBool("AdminCookie");//当session验证失败时，是否从cookie中检查登录信息


        /// <summary>
        /// 当前登录用户
        /// </summary>
        public static SysAdmin CurUserInfo
        {
            get
            {
                SysAdmin user = SessionHelper.Get<SysAdmin>(sessionKey);
                //从session读取信息失败，尝试从cookies里读取加密数据
                if (user == null && checkCookie)
                {
                    HttpCookie cookie = CookieHelper.Get(cookieKey);
                    if (cookie != null)
                    {
                        string userName = (DESEncrypt.Decrypt(cookie["username"] ?? string.Empty)).GetSafe();//cookie用户名解密
                        string passWord = (cookie["password"] ?? string.Empty).GetSafe();
                        if (userName.Length > 1 && passWord.Length == 32)
                        {
                            user = ValidateLogin(userName, passWord, true, true);
                        }
                    }
                }
                return user;
            }
        }

        /// <summary>
        ///  检查用户名及密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="isEncrypted">密码是否已加密过</param>
        /// <param name="isFromCookie">是否是来自cookie</param>
        /// <returns></returns>
        public static SysAdmin ValidateLogin(string username, string password, bool isEncrypted = false, bool isFromCookie = false)
        {
            username = username.GetSafe();
            if (!isEncrypted) password = Md5.Encrypt(password);//没加密 进行md5加密   123456==83383A98B06DBA386BF5155DED9EFEDE

            SysAdminBLL bll = new SysAdminBLL();
            SysAdmin user = bll.GetModel(username, password);
            if (user != null)
            {
                //获取到用户信息了
                if (!isFromCookie)
                {
                    //不是来自cookie，更新登录记录
                    user.LastLoginTime = DateTime.Now;
                    user.LastLoginIP = WebHandle.UserIP;
                    user.LoginTimes += 1;
                    bll.Update(user);
                }

                //菜单模块
                var bllModule = new SysModuleBLL();
                if (user.UserName.ToLower() == "kingroad")
                {
                    user.ModuleList = bllModule.GetList(SysModule._.Enabled == 1, SysModule._.OrderNum.Asc);
                }
                else
                {
                    var roleList = new SysRoleBLL().GetList(SysRole._.Id.In(user.RoleIds.Split(',')));
                    var modeleIds = new List<string>();
                    foreach (var role in roleList)
                    {
                        modeleIds.AddRange(role.ModuleIds.Split(',').AsEnumerable());
                    }
                    user.RoleNames = String.Join<string>(",", roleList.Select(x => x.Code));
                    user.ModuleList = bllModule.GetList(SysModule._.Enabled == 1 && SysModule._.Id.In(modeleIds.ToArray()), SysModule._.OrderNum.Asc);
                }
                SetLoginSessionAndCookie(user);//保存登录信息
            }
            return user;
        }

        /// <summary>
        /// 设置登录 session
        /// </summary>
        /// <param name="user"></param>
        public static void SetLoginSessionAndCookie(SysAdmin user)
        {
            SessionHelper.Set(sessionKey, user);//session信息
            if (checkCookie)
            {//保存信息到cookie中
                HttpCookie cookie = CookieHelper.Set(cookieKey);
                cookie["username"] = DESEncrypt.Encrypt(user.UserName);//cookie用户名加密
                cookie["password"] = user.PassWord;
                CookieHelper.Save(cookie);
            }
        }

        /// <summary>
        /// 登出操作
        /// </summary>
        public static void LoginOut()
        {
            SessionHelper.Remove(sessionKey);

            HttpCookie cookie = CookieHelper.Get(cookieKey);
            if (cookie != null)
            {
                cookie["username"] = "";
                cookie["password"] = "";
                CookieHelper.Save(cookie);
                CookieHelper.Remove(cookie);
            }
        }

        /// <summary>
        ///  当前登录用户 对 某个操作是否有权限
        /// </summary>
        /// <param name="authCode"></param>
        /// <returns></returns>
        public static bool IsAuthorized(string authCode)
        {
            return CurUserInfo.ModuleList.Count(x => x.Code == authCode) > 0;
        }
    }
}