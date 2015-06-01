using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Shop.Common
{
    /// <summary>
    /// 字符串操作帮助类
    /// 
    /// Tom.Team
    /// 2012-1-26
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="need"></param>
        /// <returns></returns>
        public static string Left(this string s, int need)
        {
            return Left(s, need, "");
        }
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="need"></param>
        /// <param name="encode"></param>
        /// <param name="endStr"></param>
        /// <returns></returns>
        public static string Left(this string s, int need, string endStr)
        {
            if (string.IsNullOrEmpty(s) ||s.Length <= need)
                return s;
            return s.Substring(0, need) + endStr;
        }
        /// <summary>
        /// 全角符号转半角符号
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDBC(this string value)
        {
            /****************************************
             * 全角空格为12288，半角空格为32
             * 其他字符半角(33-126)与全角(65281-65374)
             * 的对应关系是：均相差65248
             ****************************************
             */
            char[] chars = value.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == 12288)
                {
                    chars[i] = (char)32;
                    continue;
                }
                if (chars[i] > 65280 && chars[i] < 65375)
                    chars[i] = (char)(chars[i] - 65248);
            }
            return new string(chars);
        }


        /// <summary>
        /// 去除HTML
        /// </summary>
        /// <param name="htmlCode"></param>
        /// <returns></returns>
        public static string LoseHtml(this string htmlCode)
        {
            if ((htmlCode != null) && (htmlCode.Length != 0))
            {
                return Regex.Replace(htmlCode, "<[^>]+>", string.Empty, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取安全字符串(防止SQL注入)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetSafe(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            string[] strArray = @"'|;|/\*\*/|and|exec|insert|select|delete|update|master|truncate|declare|char".Split(new char[] { '|' });
            string[] strArray2 = "’|；|//|an&#100;|ex&#101;c|ins&#101;rt|sel&#101;ct|del&#101;te|up&#100;ate|mast&#101;r|truncat&#101;|declar&#101;|ch&#97;r".Split(new char[] { '|' });
            try
            {
                RegexOptions options = RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase;
                for (int i = 0; i < strArray.Length; i++)
                {
                    str = new Regex(string.Format("{0}", strArray[i]), options).Replace(str, strArray2[i]);
                }
            }
            catch (Exception exception)
            {
                str = string.Format("SQL注入检查出错了：", exception.Message);
            }
            return str;

        }

        /// <summary>
        /// 将字符串数组转换为 字符串
        /// </summary>
        /// <param name="strArr"></param>
        /// <param name="separator"></param>
        /// <param name="remoteEmpty"></param>
        /// <returns></returns>
        public static string Join(this string[] strArr, string separator, bool remoteEmpty = false, bool remoteRepeat=false)
        {
            StringBuilder sb = new StringBuilder();
            if (remoteRepeat)
            {
                strArr=strArr.Distinct().ToArray();
            }
            for (int i = 0; i < strArr.Length; i++)
            {
                if (remoteEmpty && string.IsNullOrEmpty(strArr[i]))
                    continue;
                sb.AppendFormat("{1}{0}",strArr[i],separator);
            }
            return sb.Remove(0, 1).ToString();
        }

        public static String ToUtf8String(String s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c >= 0 && c <= 255)
                {
                    sb.Append(c);
                }
                else
                {
                    byte[] b;
                    try
                    {
                        b = Encoding.UTF8.GetBytes(c.ToString());
                    }
                    catch (Exception ex)
                    {
                        b = new byte[0];
                    }
                    for (int j = 0; j < b.Length; j++)
                    {
                        int k = b[j];
                        if (k < 0) k += 256;

                        sb.Append("%" + Convert.ToString(k, 16).ToUpper());
                    }
                }
            }
            return sb.ToString();
        }
    }
}
