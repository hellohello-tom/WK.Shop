﻿// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：Realtion 数据访问层
//  作    者：cat
//  添加时间：2015-06-17 10:59:25
// ==========================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//引用
using Shop.Model;
using MySoft.Data;
using System.Data;

namespace Shop.DAL  
{
	/// <summary>
	/// Realtion数据访问层
	/// </summary>
	public partial class RealtionDAL : DALBase<Realtion>
	{
        public DataTable GetRelationTable(WhereClip where = null, OrderByClip order = null)
        {
            return DB.From<Realtion>()
                .LeftJoin<Commodity>(Realtion._.Realtion_CommodityId == Commodity._.Id)
                .Where(where).OrderBy(order)
                .Select(Commodity._.Id.As("commodityId"), Commodity._.Commodity_Name,
                Commodity._.Commodity_CostPrice, Realtion._.Realtion_IsTop, Realtion._.Id, Realtion._.Realtion_Discount, Realtion._.Realtion_CreateTime,
                new Field("(cast(Commodity.Commodity_CostPrice*Realtion.Realtion_Discount/10 as numeric(20,2))) as [price]")).ToTable()
                as DataTable;
        }
   		
	}
}