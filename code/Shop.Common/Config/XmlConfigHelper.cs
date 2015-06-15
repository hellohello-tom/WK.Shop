using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Common.Config
{
    public static class XmlConfigHelper
    {
        public static T ReadXml<T>(string path)
        {
            string key = typeof (T).FullName;
            var objcache = CacheHelper.Get<T>(key);
            if (objcache == null)
            {
                var obj = SerializationHelper.Load(typeof(T), path);
                CacheHelper.Set(key,obj,path);
                objcache = CacheHelper.Get<T>(key);
            }
            return objcache;
        }

        public static void WriteXml(object t, string path )
        {
            SerializationHelper.Save(t, path);
        }
    }
}
