using System;
using System.Web;
using System.Web.Caching;

namespace Shop.Common.Config
{
    /// <summary>
    /// 获取缓存的辅助信息
    /// </summary>
    public class CacheHelper
    {
        //private static string appPrefix = ConfigHelper.Get("AppPrefix");
        private static string appPrefix = "yaodian";

        #region 创建缓存
        /// <summary>
        /// 创建缓存项的文件依赖
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="obj">object对象</param>
        /// <param name="fileName">文件绝对路径</param>
        public static void Set(string key, object obj, string fileName)
        {
            //创建缓存依赖项
            CacheDependency dep = new CacheDependency(fileName);
            //创建缓存
            HttpRuntime.Cache.Insert(appPrefix + key, obj, dep);
        }

        /// <summary>
        /// 创建缓存项
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        public static void Set(string key, object obj)
        {
            HttpRuntime.Cache.Insert(appPrefix + key, obj);
        }

        /// <summary>
        /// 创建缓存项过期
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="obj">object对象</param>
        /// <param name="expires">过期时间(分钟)</param>
        public static void Set(string key, object obj, int expires)
        {
            HttpRuntime.Cache.Insert(appPrefix + key, obj, null, DateTime.Now.AddMinutes(expires), TimeSpan.Zero);
        }
        #endregion

        #region 获取缓存
        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns>object对象</returns>
        public static object Get(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }
            return HttpRuntime.Cache.Get(appPrefix + key);
        }

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <typeparam name="T">T对象</typeparam>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            object obj = Get(key);
            return obj == null ? default(T) : (T)obj;
        }

        #endregion

        #region 移除缓存
        public static void Remove(string key)
        {
            HttpRuntime.Cache.Remove(appPrefix + key);
        }
        #endregion
    }
}