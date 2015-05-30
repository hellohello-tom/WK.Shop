// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysAdmin 业务逻辑层
//  作    者：ThinkWang
//  添加时间：2014-03-06 17:23:24
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
	/// SysAdmin业务逻辑层
	/// </summary>
	public partial class SysAdminBLL : BLLBase<SysAdmin>
	{	     
		private readonly SysAdminDAL dal=new SysAdminDAL();

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public  SysAdmin GetModel(string username, string password)
        {
            return dal.GetModel(SysAdmin._.UserName == username && SysAdmin._.PassWord == password);
        }

        /// <summary>
        /// 带roleNames
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public IDataPage<IList<SysAdmin>> GetPageList(int pageSize, int pageIndex, WhereClip where = null)
        {
            
            var pages= dal.GetPageList(pageSize, pageIndex, where);

            //给RoleNams赋值
            List<SysAdmin> list = pages.DataSource as List<SysAdmin>;
            List<SysRole> roleList=new SysRoleBLL().GetList(SysRole._.Enabled==1);
            List<SysRole> tempRoleList;
            foreach (var admin in list)
            {
                tempRoleList = roleList.FindAll(x => admin.RoleIds.Contains("," + x.Id.ToString() + ","));
                tempRoleList.ForEach(x => admin.RoleNames += x.Name + ",");
                if (!string.IsNullOrEmpty(admin.RoleNames))
                    admin.RoleNames = admin.RoleNames.Substring(0, admin.RoleNames.Length - 1);
            }
            pages.DataSource = list;

            return pages;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <returns>返回自增id</returns>
        public int Add(SysAdmin model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>	
        public bool UpdateAdmin(SysAdmin model)
        {
            return dal.UpdateAdmin(model);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// 删除多个数据
        /// </summary>
        public int Delete(int[] ids)
        {
            return dal.Delete(ids);
        }
	}
}