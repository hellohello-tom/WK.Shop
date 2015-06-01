// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysRole 业务逻辑层
//  作    者：Tom.Team
//  添加时间：2014-03-25 16:54:21
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
	/// SysRole业务逻辑层
	/// </summary>
	public partial class SysRoleBLL : BLLBase<SysRole>
	{	     
		private readonly SysRoleDAL dal=new SysRoleDAL();

        /// <summary>
        /// 根据角色编码获取角色实体
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public SysRole GetModelByCode(string code)
        {
            return dal.GetModel(SysRole._.Code == code);
        }
   
	}
}