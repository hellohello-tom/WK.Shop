// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysLog 业务逻辑层
//  作    者：ThinkWang
//  添加时间：2014-03-20 10:23:35
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
	/// SysLog业务逻辑层
	/// </summary>
	public partial class SysLogBLL : BLLBase<SysLog>
	{	     
		private readonly SysLogDAL dal=new SysLogDAL();
	
		
   
	}
}