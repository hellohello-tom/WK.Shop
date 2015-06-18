// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：FlashSales 数据访问层
//  作    者：cat
//  添加时间：2015-06-17 10:59:29
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
    /// FlashSales数据访问层
    /// </summary>
    public partial class FlashSalesDAL : DALBase<FlashSales>
    {
        public int Add(Model.FlashSales model, int[] commdityIds)
        {
            int id = 0;
            var trans = DB.BeginTrans();
            try
            {
                InsertCreator ic = InsertCreator.NewCreator().SetEntity<FlashSales>(model);
                trans.Excute(ic, out id);
                if (commdityIds.Length > 0)
                {
                    foreach (var item in commdityIds)
                    {
                        var detail = new Realtion
                        {
                            Realtion_SaleId = id,
                            Realtion_CommodityId = item,
                            Realtion_CreateTime = DateTime.Now,
                            Realtion_IsDel = false,
                            Realtion_IsTop = false
                        };
                        detail.Detach();
                        trans.Save(detail);
                    }
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

        public bool Update(Model.FlashSales model, int[] commdityIds)
        {
            var trans = DB.BeginTrans();
            try
            {
                model.Attach();
                if (commdityIds.Length > 0)
                {
                    trans.Delete<Realtion>(Realtion._.Realtion_SaleId == model.Id);
                    foreach (var item in commdityIds)
                    {
                        var detail = new Realtion
                        {
                            Realtion_SaleId = model.Id,
                            Realtion_CommodityId = item,
                            Realtion_CreateTime = DateTime.Now,
                            Realtion_IsDel = false,
                            Realtion_IsTop = false
                        };
                        detail.Detach();
                        trans.Save(detail);
                    }
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
        /// <summary>
        /// 根据条件获取闪购列表
        /// </summary>
        /// <param name="wc"></param>
        /// <returns></returns>
        public DataTable GetFlashSalesListByCondition(WhereClip wc)
        {
            return DB.From<FlashSales>()
                 .LeftJoin<FileAttr>(FlashSales._.Id == FileAttr._.FileAttr_BussinessId)
                 .Select(FlashSales._.All,FileAttr._.FileAttr_Path,FileAttr._.FileAttr_Name)
                 .Where(wc).OrderBy(FlashSales._.FlashSales_CreateTime.Desc).ToTable() as DataTable;

        }

        /// <summary>
        /// 获取闪购页面数据
        /// </summary>
        /// <param name="topSize"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataTable GetFlashSales(int topSize, WhereClip where = null, OrderByClip order = null)
        {
            return DB.From<FlashSales>()
                .LeftJoin<Realtion>(Realtion._.Realtion_SaleId == FlashSales._.Id)
                .LeftJoin<Commodity>(Commodity._.Id == Realtion._.Realtion_CommodityId)
                .Select(Realtion._.Realtion_Discount, Commodity._.Id.As("commdityId"), Commodity._.Commodity_Name
                , Commodity._.Commodity_ImagePath, new Field("(Realtion.Realtion_Discount*Commodity.Commodity_CostPrice) [price]"))
                .Where(where)
                .OrderBy(order)
                .ToTable() as DataTable;
        }

        /// <summary>
        /// 网站首页获取闪购药品项
        /// </summary>
        /// <param name="wc"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public DataTable GetFlashSalesCommodityList( WhereClip wc,OrderByClip orderBy )
        {
            return
                DB.From<FlashSales>().LeftJoin<Realtion>(FlashSales._.Id==Realtion._.Realtion_SaleId)
                    .LeftJoin<Commodity>(Commodity._.Id == Realtion._.Realtion_CommodityId)
                    .Select(Commodity._.All, Realtion._.Realtion_Discount, Realtion._.Realtion_SaleId, Realtion._.Realtion_IsTop).Where(wc).OrderBy(orderBy).ToTable() as DataTable;
        }

        /// <summary>
        ///闪购药品详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public DataRow GetFlashSalesCommodity( int id )
        {
            var dt=DB.From<Commodity>()
                    .RightJoin<Realtion>(Commodity._.Id == Realtion._.Realtion_CommodityId)
                    .Where(Realtion._.Realtion_CommodityId == id)
                    .Select(Commodity._.All, Realtion._.Realtion_Discount,Realtion._.Realtion_SaleId).ToTable() as DataTable;
            if (dt != null) return dt.Rows[0];
            return null;
        }
    }
}