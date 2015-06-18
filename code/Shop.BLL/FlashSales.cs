// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：FlashSales 业务逻辑层
//  作    者：cat
//  添加时间：2015-06-17 10:59:28
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
	/// FlashSales业务逻辑层
	/// </summary>
	public partial class FlashSalesBLL : BLLBase<FlashSales>
	{	     
		private readonly FlashSalesDAL dal=new FlashSalesDAL();

        public int Add(Model.FlashSales model, int[] commdityIds)
        {
            return dal.Add(model, commdityIds);
        }

        public bool Update(Model.FlashSales model, int[] commdityIds)
        {
            return dal.Update(model, commdityIds);
        }

        /// <summary>
        /// 根据条件获取数据 left SysDicType
        /// </summary>
        /// <param name="wc"></param>
        /// <returns>数据列表</returns>
        public DataTable GetlistByCondition( WhereClip wc )
        {
            return dal.GetFlashSalesListByCondition(wc);
        }

       // GetFlashSalesCommodities

        public DataRow GetFlashSalesCommodity( int id )
        {
            return dal.GetFlashSalesCommodity(id);
        }
	}
}