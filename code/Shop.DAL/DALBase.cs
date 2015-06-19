using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Shop.Model;
using MySoft.Data;
using System.Data;
using System.Web;

namespace Shop.DAL
{
    /// <summary>
    /// 数据访问层基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DALBase<T> where T : Entity, IModel
    {
        private static DbSession _db;

        private static readonly object objLocker = new object();

        /// <summary>
        ///   MySql Dbsession 
        /// </summary>
        public static DbSession DB
        {
            get
            {
                if (_db == null)
                {
                    lock (objLocker)
                    {
                        if (_db == null)
                        {
                            var dbtype = ConfigurationManager.AppSettings["ConnectionType"];
                            if (dbtype.ToUpper().Equals("SQL"))
                            {
                                _db = new DbSession("SQLConn");
                            }
                            else if (dbtype.ToUpper().Equals("SQLITE"))
                            {
                                string conStr = string.Format(ConfigurationManager.ConnectionStrings["SQLiteConn"].ConnectionString, HttpRuntime.AppDomainAppPath);
                                DbProvider provider = ProviderFactory.CreateDbProvider(ProviderType.SQLite, conStr);
                                _db = new DbSession(provider);
                            }
                        }
                    }
                }
                return _db;
            }
        }

        #region 普通常用数据操作
        /// <summary>
        /// 数据是否存在
        /// </summary>
        public bool Exists(WhereClip where)
        {
            return DB.Exists<T>(where);
        }
        public bool Exists(int id)
        {
            return DB.Exists<T>(new WhereClip("id=@id", new SQLParameter("@id", id)));
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <returns>返回自增id</returns>
        public int Add(T model)
        {
            InsertCreator ic = InsertCreator.NewCreator().SetEntity<T>(model);
            int id = 0;
            DB.Excute(ic, out id);
            return id;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>	
        public bool Update(T model)
        {
            model.Attach();
            return DB.Save(model) > 0;
        }

        /// <summary>
        /// 跟新指定字段
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool Update(Dictionary<Field, object> fields, WhereClip where)
        {
            return DB.Update<T>(fields.Keys.ToArray(), fields.Values.ToArray(), where) > 0;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(WhereClip where)
        {
            return DB.Delete<T>(where);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            return Delete(new WhereClip("id=@id", new SQLParameter("@id", id))) > 0;
        }

        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int Delete(int[] ids)
        {
            return Delete(new Field("Id").In(ids));
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public T GetModel(WhereClip where)
        {
            return DB.From<T>().Where(where).ToSingle() ?? default(T);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public T GetModel(int id)
        {
            return GetModel(new WhereClip("id=@id", new SQLParameter("@id", id))) ?? default(T);
        }

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public List<T> GetList(WhereClip where = null, OrderByClip order = null)
        {
            return DB.From<T>().Where(where).OrderBy(order).ToList() as List<T>;
        }

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public List<T> GetTopList(int top, WhereClip where = null, OrderByClip order = null)
        {
            return DB.From<T>().Where(where).OrderBy(order).GetTop(top).ToList() as List<T>;
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
            return DB.From<T>().Where(where).OrderBy(order).ToListPage(pageSize, pageIndex);
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
            return DB.From<T>().Where(where).OrderBy(order).ToTablePage(pageSize, pageIndex);
        }

        /// <summary>
        /// 对datatable进行分页
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public  DataTable SplitDataTable(DataTable dt, int PageIndex, int PageSize)
        {
            if (PageIndex == 0)
                return dt;
            DataTable newdt = dt.Clone();
            //newdt.Clear();
            int rowbegin = (PageIndex - 1) * PageSize;
            int rowend = PageIndex * PageSize;

            if (rowbegin >= dt.Rows.Count)
                return newdt;

            if (rowend > dt.Rows.Count)
                rowend = dt.Rows.Count;
            for (int i = rowbegin; i <= rowend - 1; i++)
            {
                DataRow newdr = newdt.NewRow();
                DataRow dr = dt.Rows[i];
                foreach (DataColumn column in dt.Columns)
                {
                    newdr[column.ColumnName] = dr[column.ColumnName];
                }
                newdt.Rows.Add(newdr);
            }

            return newdt;
        }

        #endregion

    }
}
