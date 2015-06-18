// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：Commodity Model
//  作    者：cat
//  添加时间：2015-06-16 10:33:24
// ==========================================================================
using System;
//引用
using MySoft.Data;
using System.ComponentModel.DataAnnotations;

namespace Shop.Model
{
    /// <summary>
    /// 表名：Commodity 主键列：Id 	 

    ///Commodity
    /// </summary>
    public partial class Commodity
    {
        /// <summary>
        /// 闪购Id
        /// </summary>
        public int Realtion_SaleId { get; set; }
        /// <summary>
        /// 闪购折扣
        /// </summary>
        public decimal Realtion_Discount { get; set; }

        /// <summary>
        /// 此商品闪购截止时间
        /// </summary>
        private DateTime? FlashSales_EndTime;
    }
}

