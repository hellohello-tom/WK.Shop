// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：FlashSales 数据访问层
//  作    者：cat
//  添加时间：2015-06-17 10:59:29
// ==========================================================================
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// 根据条件获取闪购列表
        /// </summary>
        /// <param name="wc"></param>
        /// <returns></returns>
        public List<FlashSales> GetFlashSalesListByCondition( WhereClip wc )
        {
            return DB.From<FlashSales>()
                 .LeftJoin<FileAttr>(FlashSales._.Id == FileAttr._.FileAttr_BussinessId)
                 .Select(FlashSales._.All)
                 .Where(wc).OrderBy(FlashSales._.FlashSales_CreateTime.Desc)
                 .ToList() as List<FlashSales>;

        }
	}
}