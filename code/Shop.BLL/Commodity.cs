// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：Commodity 业务逻辑层
//  作    者：cat
//  添加时间：2015-06-08 17:34:31
// ==========================================================================
using System;
using System.Collections.Generic;
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
        /// 获取折扣过后的商品分页数据
        /// 排序字段 price
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public IDataPage<IList<Commodity>> GetCommdityList(WhereClip where=null ,OrderByClip order=null)
        {
            return dal.GetCommdityList();
        }
        
	}
}