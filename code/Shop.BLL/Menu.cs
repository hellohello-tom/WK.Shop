// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：Menu 业务逻辑层
//  作    者：cat
//  添加时间：2015-06-17 10:59:26
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
	/// Menu业务逻辑层
	/// </summary>
	public partial class MenuBLL : BLLBase<Menu>
	{	     
		private readonly MenuDAL dal=new MenuDAL();

	    /// <summary>
	    ///  获取常见疾病的科室和Menu
	    /// </summary>
	    /// <param name="showCount">每个科室下Menu数量</param>
	    /// <returns></returns>
	    public DataTable GetCommonDiseasesTable(int showCount)
	    {
	       return dal.GetCommonDiseasesTable(showCount);
	    }
   
	}
}