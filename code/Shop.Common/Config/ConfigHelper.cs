using System;
using System.Configuration;

namespace Shop.Common
{
    /// <summary>
    /// web.config操作类
    ///
    /// Tom.Team
    /// 2014-3-6
    /// </summary>
    public sealed class ConfigHelper
    {
        /// <summary>
        /// 得到AppSettings中的配置字符串信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        /// <summary>
        /// 得到ConnectionString中的配置连接字符串
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name == "" ? "SQLConnString" : name].ConnectionString;
        }
        /// <summary>
        /// 得到AppSettings中的配置Bool信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetBool(string key)
        {
            bool result = false;
            string cfgVal = Get(key);
            bool.TryParse(cfgVal, out result);
            return result;
        }
        /// <summary>
        /// 得到AppSettings中的配置Decimal信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static decimal GetDecimal(string key)
        {
            decimal result = 0;
            string cfgVal = Get(key);
            decimal.TryParse(cfgVal, out result);
            return result;
        }
        /// <summary>
        /// 得到AppSettings中的配置int信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetInt(string key)
        {
            int result = 0;
            string cfgVal = Get(key);
            int.TryParse(cfgVal, out result);
            return result;
        }
    }
}
