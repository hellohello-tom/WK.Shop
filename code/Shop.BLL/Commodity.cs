// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：Commodity 业务逻辑层
//  作    者：cat
//  添加时间：2015-06-08 17:34:31
// ==========================================================================
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
//引用
using Shop.DAL;
using Shop.Model;
using Shop.Common;
using MySoft.Data;

namespace Shop.BLL {
	/// <summary>
	/// Commodity业务逻辑层
	/// </summary>
	public partial class CommodityBLL : BLLBase<Commodity>
	{	     
		private readonly CommodityDAL dal=new CommodityDAL();
        
        /// <summary>
        /// 将上传的图片列表批量更新到数据库中
        /// </summary>
        /// <param name="model"></param>
        /// <param name="imageIds"></param>
        /// <returns></returns>
        public bool Update(Commodity model, int[] imageIds)
        {
            return dal.Update(model, imageIds);
        }

        /// <summary>
        /// 将上传的图片列表批量更新到数据库中
        /// </summary>
        /// <param name="model"></param>
        /// <param name="imageIds"></param>
        /// <returns></returns>
        public int Add(Commodity model, int[] imageIds)
        {
            return dal.Add(model, imageIds);
        }

	    /// <summary>
	    ///根据Tag 获取折扣过后的商品分页数据
	    /// 排序字段 price
	    /// </summary>
	    /// <param name="where"></param>
	    /// <param name="order"></param>
	    /// <param name="pageIndex"></param>
	    /// <param name="pageSize"></param>
	    /// <returns></returns>
	    public IList<Commodity> GetCommdityListByTag(int tagId ,string order,int pageIndex=0,int pageSize=20)
        {
            return dal.GetCommdityListByTag(tagId, order, pageIndex, pageSize);
        }

	    ///  <summary>
	    /// 根据nav 获取折扣过后的商品分页数据
	    ///  排序字段 price
	    ///  </summary>
	    /// <param name="navId"></param>
	    /// <param name="menuId"></param>
	    /// <param name="order"></param>
	    ///  <param name="pageIndex"></param>
	    ///  <param name="pageSize"></param>
	    ///  <returns></returns>
	    public IList<Commodity> GetCommdityListByNav( int navId = 0, int menuId = 0, string order = "asc", int pageIndex = 0, int pageSize = 20 )
        {
            return dal.GetCommdityListByNav(navId,menuId, order, pageIndex, pageSize);
        }


        /// <summary>
        /// 根据nav 获取折扣过后的商品分页数据 非price字段
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public IList<Commodity> GetCommdityListByNav( int pageSize, int pageIndex, WhereClip where = null, OrderByClip order = null )
        {
            return dal.GetCommdityListByNav(pageSize, pageIndex, where, order);
        }
        /// <summary>
        /// 获取折扣过后的闪购商品分页数据
        /// 排序字段 price
        /// </summary>
        /// <param name="tagId"></param>
        /// <param name="order"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public DataTable GetFlashSalesCommdityPageTable( int tagId, string order, int pageIndex = 0, int pageSize = 20 )
        {
            return dal.GetFlashSalesCommdityPageTable(tagId, order, pageIndex, pageSize);
        }
        /// <summary>
        /// 根据条件获取闪购药品列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public IDataPage<DataTable> GetFlashSalesCommodityListByCondition( int pageSize, int pageIndex, WhereClip where = null, OrderByClip order = null )
	    {
            return dal.GetFlashSalesCommodityListByCondition(pageSize, pageIndex, where, order);
	    }
	}
}