// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：Navigation 业务逻辑层
//  作    者：cat
//  添加时间：2015-06-08 17:34:37
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
	/// Navigation业务逻辑层
	/// </summary>
	public partial class NavigationBLL : BLLBase<Navigation>
	{	     
		private readonly NavigationDAL dal=new NavigationDAL();
	
		
   
	}
}