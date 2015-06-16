using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySoft.Data;
using System.Data;
using Shop.DAL;
using Shop.Model;
using Shop.Common;

namespace Shop.BLL
{
    /// <summary>
    ///  业务逻辑层基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BLLBase<T> where T :Entity,IModel
    {
        public DALBase<T> dalBase = new DALBase<T>();

        /// <summary>
        /// 数据是否存在
        /// </summary>
		public bool Exists(WhereClip where)
		{
			return dalBase.Exists(where);
		}
        public bool Exists(int id)
        {
            return dalBase.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <returns>返回自增id</returns>
        public int Add(T model)
        {
           return dalBase.Add(model);
        }

        /// <summary>
        /// 批量更新部分字段
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool Update(Dictionary<Field, object> fields, WhereClip where)
        {
            return dalBase.Update(fields, where);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>	
        public bool Update(T model, bool isUpdateCache = false)
        {
            bool isOk = dalBase.Update(model);
            if (isOk && isUpdateCache)
            {
                string cacheKey = "SysDicDetailModel-" + model.Id;
                try
                {
                    object objModel = CacheHelper.Get(cacheKey);
                    if (objModel != null)
                    {
                        CacheHelper.Set(cacheKey, model);
                    }
                }
                catch(Exception ex) {
                    Log.Logger.Error(ex);
                }
            }
            return isOk;
        }


        /// <summary>
        /// 删除数据
        /// </summary>
        public bool Delete(int id)
        {
            return dalBase.Delete(id);
        }

        /// <summary>
        /// 删除多个数据
        /// </summary>
        public int Delete(int[] ids)
        {
            return dalBase.Delete(ids);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public T GetModel(int id)
        {
            return dalBase.GetModel(id);
        }

        public T GetModel(WhereClip where)
        {
            return dalBase.GetModel(where);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public T GetModelByCache(int id)
        {

            string cacheKey = "SysDicDetailModel-" + id;
            T objModel = CacheHelper.Get<T>(cacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dalBase.GetModel(id);
                    if (objModel != null)
                    {
                        CacheHelper.Set(cacheKey, objModel);
                    }
                }
                catch (Exception ex) { Log.Logger.Error(ex); }
            }
            return objModel;
        }

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public List<T> GetList(WhereClip where = null, OrderByClip order = null)
        {
            return dalBase.GetList(where,order);
        }

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public List<T> GetTopList(int top, WhereClip where = null, OrderByClip order = null)
        {
            return dalBase.GetTopList(top, where, order);
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns>IDataPage</returns>
        public IDataPage<IList<T>> GetPageList(int pageSize, int pageIndex, WhereClip where = null, OrderByClip order = null)
        {
            return dalBase.GetPageList(pageSize, pageIndex,where,order);
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns>IDataPage</returns>
        public IDataPage<DataTable> GetPageTable(int pageSize, int pageIndex, WhereClip where = null, OrderByClip order = null)
        {
            return dalBase.GetPageTable(pageSize, pageIndex, where, order);
        }
        
    }
}
