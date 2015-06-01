// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysOrg 业务逻辑层
//  作    者：Tom.Team
//  添加时间：2014-10-25 11:45:12
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
	/// 组织机构(SysOrg)业务逻辑层
	/// </summary>
	public partial class SysOrgBLL : BLLBase<SysOrg>
	{	     
		private readonly SysOrgDAL dal=new SysOrgDAL();

         /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <returns>返回自增id</returns>
        public int Add(SysOrg model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>	
        public bool Update(SysOrg model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 根据用户id获取组织机构实体
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public SysOrg GetModelByUserId(int userId)
        {
            return dal.GetModelByUserId(userId);
        }
	}
}