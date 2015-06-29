// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：Commodity 数据访问层
//  作    者：cat
//  添加时间：2015-06-08 17:34:32
// ==========================================================================
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//引用
using Shop.Model;
using MySoft.Data;
using Shop.Common;

namespace Shop.DAL
{
    /// <summary>
    /// Commodity数据访问层
    /// </summary>
    public partial class CommodityDAL : DALBase<Commodity>
    {

        public bool Update( Commodity model, int[] imageIds )
        {
            var trans = DB.BeginTrans();
            try
            {
                model.Attach();
                if (imageIds != null && imageIds.Length > 0)
                {
                    trans.Update<FileAttr>(new Field[]{
                        FileAttr._.FileAttr_BussinessId,FileAttr._.FileAttr_BussinessCode},
                        new object[]{
                            model.Id,BizCode.Commodity.ToString()
                        }, FileAttr._.Id.In(imageIds));
                }
                trans.Save(model);
                trans.Commit();
                return true;
            }
            catch
            {
                trans.Rollback();
                return false;
            }
            finally
            {
                trans.Dispose();
            }
        }

        public int Add( Commodity model, int[] imageIds )
        {
            int id = 0;
            var trans = DB.BeginTrans();
            try
            {
                InsertCreator ic = InsertCreator.NewCreator().SetEntity<Commodity>(model);
                trans.Excute(ic, out id);
                if (imageIds.Length > 0)
                {
                    trans.Update<FileAttr>(new Field[]{
                        FileAttr._.FileAttr_BussinessId,FileAttr._.FileAttr_BussinessCode}, new object[]{
                            id,BizCode.Commodity.ToString()
                        }, FileAttr._.Id.In(imageIds));
                }
                trans.Commit();
            }
            catch
            {
                trans.Rollback();
            }
            finally
            {
                trans.Dispose();
            }
            return id;
        }
        /// <summary>
        /// 获取闪购药品详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Commodity GetFlashSalesCommodityById( int id )
        {
            return
                DB.From<Commodity>()
                    .LeftJoin<Realtion>(Commodity._.Id == Realtion._.Realtion_CommodityId).Where(Commodity._.Id == id)
                    .Select(Commodity._.All, Realtion._.Realtion_Discount, Realtion._.Realtion_SaleId)
                    .ToSingle<Commodity>();
        }

        /// <summary>
        /// 根据tag获取折扣过后的商品分页数据
        /// 排序字段 price
        /// </summary>
        /// <param name="tagId"></param>
        /// <param name="order"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IList<Commodity> GetCommdityListByTag( int tagId, string order = "asc", int pageIndex = 0, int pageSize = 20 )
        {
            string sql = string.Format(@"select top {3} * from Commodity where Id not in (select top (({2}-1)*{3}) id from commodity 
                                where Commodity_IsDel=0 and (Commodity_Status=0 or Commodity_Status=2) and Commodity_TagId={0}
                                order by Commodity.Commodity_Discount*(Commodity.Commodity_CostPrice/10) {1}) 
                                and  Commodity_IsDel=0 and (Commodity_Status=0 or Commodity_Status=2) and Commodity_TagId={0}
                                order by Commodity.Commodity_Discount*(Commodity.Commodity_CostPrice/10) {1}", tagId, order, pageIndex, pageSize);
            try
            {
                var list = DB.FromSql(sql).ToList<Commodity>();
                return list;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        ///  获取折扣过后的闪购商品分页数据//todo 待实现
        /// 排序字段 price
        /// </summary>
        /// <param name="salesId"></param>
        /// <param name="order"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public DataTable GetFlashSalesCommdityPageTable( int salesId, string order = "asc", int pageIndex = 1, int pageSize = 20 )
        {
            string sql = string.Format(@"
                    select top {3} Commodity.*,Realtion.Realtion_CommodityId,Realtion.Realtion_Discount from Realtion left join Commodity on Realtion.Realtion_CommodityId=Commodity.Id and Realtion_SaleId={0} and
                    Realtion.Realtion_CommodityId  not in(select top ({2}*{3}) r.Realtion_CommodityId from Realtion r 
                    left join Commodity c on r.Realtion_CommodityId=c.Id and r.Realtion_IsDel=0 
                    and c.Commodity_IsDel=0  and (c.Commodity_Status=0 or c.Commodity_Status=2)
                    and c.Commodity_Name is not null and r.Realtion_SaleId={0} order by c.Commodity_CostPrice*r.Realtion_Discount {1}) 
                    where  Realtion.Realtion_IsDel=0 and Commodity.Commodity_IsDel=0  
                    and (Commodity.Commodity_Status=0 or Commodity.Commodity_Status=2) 
                    and Commodity.Commodity_Name is not null order by Commodity.Commodity_CostPrice*Realtion.Realtion_Discount {1}", salesId, order, pageIndex - 1, pageSize);
            try
            {
                var dt = DB.FromSql(sql).ToTable() as DataTable;
                return dt;
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        /// <summary>
        /// 根据导航NavId 和 MenuId获取折扣过后的商品分页数据
        /// 排序字段 price
        /// </summary>
        /// <param name="navId"></param>
        /// <param name="menuId"></param>
        /// <param name="order"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IList<Commodity> GetCommdityListByNav( int navId=0,int menuId=0, string order = "asc", int pageIndex = 0, int pageSize = 20 )
        {
            string sql = string.Format(@"select top {3} Commodity.* from Commodity left join Menu on Commodity.Commodity_TagId=Menu.Id 
        where Commodity.Id not in (select top (({2}-1)*{3}) Commodity.id from commodity left join Menu on Commodity.Commodity_TagId=Menu.Id 
        where Commodity.Commodity_IsDel=0 and (Commodity.Commodity_Status=0 or Commodity.Commodity_Status=2) and Menu.Menu_IsDel=0
        and (Menu.Menu_Status=0 or Menu.Menu_Status=2) and {0} order by Commodity.Commodity_Discount*(Commodity.Commodity_CostPrice/10) {1}) 
        and  Commodity.Commodity_IsDel=0 and (Commodity.Commodity_Status=0 or Commodity.Commodity_Status=2) and Menu.Menu_IsDel=0 
        and (Menu.Menu_Status=0 or Menu.Menu_Status=2) and {0} order by Commodity.Commodity_Discount*(Commodity.Commodity_CostPrice/10) {1}", menuId == 0 ? string.Format(" Menu.Menu_NavigationId={0}", navId) : string.Format(" Menu.Menu_NavigationId={0} and Menu.Id={1}",navId, menuId), order, pageIndex, pageSize);
            try
            {
                var list = DB.FromSql(sql).ToList<Commodity>();
                return list;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        ///  根据导航Navigation获取折扣过后的商品分页数据
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public IList<Commodity> GetCommdityListByNav( int pageSize, int pageIndex, WhereClip where = null, OrderByClip order = null )
        {
            return
                DB.From<Commodity>()
                    .LeftJoin<Menu>(Commodity._.Commodity_TagId == Menu._.Id)
                    .Select(Commodity._.All)
                    .Where(where)
                    .OrderBy(order)
                    .ToList<Commodity>();

        }

        /// <summary>
        ///  根据条件获取闪购药品列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public IDataPage<DataTable> GetFlashSalesCommodityListByCondition( int pageSize, int pageIndex, WhereClip where = null, OrderByClip order = null )
        {
            return DB.From<Commodity>()
                .LeftJoin<Realtion>(Commodity._.Id==Realtion._.Realtion_CommodityId)
                .Select(Commodity._.All, Realtion._.Realtion_Discount,Realtion._.Realtion_CommodityId)
                .Where(where).OrderBy(Realtion._.Realtion_CreateTime.Desc).OrderBy(order).ToTablePage(pageSize, pageIndex);

        }

    }
}