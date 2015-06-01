using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Shop.Common
{
    /// <summary>
    ///  MD5加密
    /// 
    /// Tom.Team
    /// 2012-1-26
    /// </summary>
    public static class Md5
    {
        /// <summary>
        /// MD5加密字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string Encrypt(string s, int length, string key)
        {
            if (length > 32) length = 32;
            MD5 md5 = MD5.Create();
            byte[] b = md5.ComputeHash(Encoding.Default.GetBytes(s + key));
            return BitConverter.ToString(b).Replace("-", "").Substring(0, length);

        }
        /// <summary>
        /// MD5加密字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Encrypt(string s, int length)
        {
            return Encrypt(s, length, "Tom.Team");
        }
        /// <summary>
        /// MD5加密字符串32位
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Encrypt(string s)
        {
            return Encrypt(s, 32);
        }
    }
}
