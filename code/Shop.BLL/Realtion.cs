// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：Realtion 业务逻辑层
//  作    者：cat
//  添加时间：2015-06-17 10:59:24
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
using System.Data;

namespace Shop.BLL {
	/// <summary>
	/// Realtion业务逻辑层
	/// </summary>
	public partial class RealtionBLL : BLLBase<Realtion>
	{	     
		private readonly RealtionDAL dal=new RealtionDAL();

        public DataTable GetRelationTable(WhereClip where = null, OrderByClip order = null)
        {
            return dal.GetRelationTable(where, order);
        }
   
	}
}