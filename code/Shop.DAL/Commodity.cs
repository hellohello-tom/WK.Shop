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
using System.Linq;
using System.Text;
//引用
using Shop.Model;
using MySoft.Data;

namespace Shop.DAL
{
    /// <summary>
    /// Commodity数据访问层
    /// </summary>
    public partial class CommodityDAL : DALBase<Commodity>
    {

        public bool Update(Commodity model, int[] imageIds)
        {
            var trans = DB.BeginTrans();
            try
            {
                model.Attach();
                if (imageIds.Length > 0)
                {
                    trans.Update<FileAttr>(FileAttr._.FileAttr_BussinessId, model.Id, FileAttr._.Id.In(imageIds));
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

        public int Add(Commodity model, int[] imageIds)
        {
            int id = 0;
            var trans = DB.BeginTrans();
            try
            {
                InsertCreator ic = InsertCreator.NewCreator().SetEntity<Commodity>(model);
                trans.Excute(ic, out id);
                if (imageIds.Length > 0)
                {
                    trans.Update<FileAttr>(FileAttr._.FileAttr_BussinessId, id, FileAttr._.Id.In(imageIds));
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
        /// 获取折扣过后的商品分页数据
        /// 排序字段 price
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IDataPage<IList<Commodity>> GetCommdityList(WhereClip where = null, OrderByClip order = null,int pageIndex=0,int pageSize=20)
        {
            var list = DB.From<Commodity>().Select(Commodity._.All, new Field("(select b.Commodity_Discount*b.Commodity_CostPrice from Commodity b where b.Id=Commodity.Id) as [price]"))
                .Where(where)
                .OrderBy(order)
                .ToListPage(pageSize, pageIndex);
            return list;
        }


        /// <summary>
        /// 根据条件获取药品列表
        /// </summary>
        /// <param name="wc"></param>
        /// <returns></returns>
        public DataTable GetFlashSalesCommodityTableByCondition( WhereClip wc )
        {
            //QueryCreator qc = QueryCreator.NewCreator()
            //    .From<Realtion>()
            //    .Join<Commodity>(Realtion._.Realtion_CommodityId == Commodity._.Id)
            //    .Join<FlashSales>(Realtion._.Realtion_SaleId == FlashSales._.Id)
            //    .AddField(Commodity._.All)
            //    .AddField(FlashSales._.FlashSales_Discount);
            return DB.From<Realtion>()
                .LeftJoin<Commodity>(Realtion._.Realtion_CommodityId == Commodity._.Id)
                .LeftJoin<FlashSales>(Realtion._.Realtion_SaleId == FlashSales._.Id)
                .Select(Commodity._.All, FlashSales._.FlashSales_Discount)
                .Where(wc).OrderBy(FlashSales._.FlashSales_CreateTime.Desc).ToTable() as DataTable;

        }
    }
}