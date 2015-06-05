// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysAdmin 数据访问层
//  作    者：Tom.Team
//  添加时间：2014-03-20 10:23:27
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
	/// SysAdmin数据访问层
	/// </summary>
	public partial class SysAdminDAL : DALBase<SysAdmin>
	{
		/// <summary>
		/// 增加一条数据 同时添加关系表
		/// </summary>
		/// <returns>返回自增id</returns>
		public int Add(SysAdmin model)
		{
			int id = 0;
			var trans = DB.BeginTrans();
			try
			{
				//添加用户表
				InsertCreator ic = InsertCreator.NewCreator().SetEntity<SysAdmin>(model);
				trans.Excute(ic, out id);
				//添加组织机构用户关系表
				var orgUserModel = new SysOrgUser();
				orgUserModel.OrgId = model.Org.Id;
				orgUserModel.UserId = id;
				orgUserModel.Detach();
				trans.Save(orgUserModel);
				trans.Commit();
			}
			catch (Exception ex)
			{
				id = 0;
				Log.Logger.Error(ex);
				trans.Rollback();
			}

			return id;
		}

		/// <summary>
		/// 更新一条数据 同时更新关系表
		/// </summary>	
		public bool UpdateAdmin(SysAdmin model)
		{
			var isOk = false;
			var trans = DB.BeginTrans();
			try
			{
				//更新用户表
				model.Attach();
				trans.Save(model);
				//更新 关系表
				trans.Update<SysOrgUser>(SysOrgUser._.OrgId, model.Org.Id, SysOrgUser._.UserId == model.Id);

				trans.Commit();
				isOk = true;
			}
			catch (Exception ex)
			{
				isOk = false;
				Log.Logger.Error(ex);
				trans.Rollback();
			}
			return isOk;
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			var isOk = false;
			var trans = DB.BeginTrans();
			try
			{
				trans.Delete<SysOrgUser>(SysOrgUser._.UserId == id);
				trans.Delete<SysAdmin>(SysAdmin._.Id == id);
				trans.Commit();
				isOk = true;
			}
			catch (Exception ex)
			{
				isOk = false;
				Log.Logger.Error(ex);
				trans.Rollback();
			}
			return isOk;
		}

		/// <summary>
		/// 删除多条数据
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		public int Delete(int[] ids)
		{
			var count = 0;
			var trans = DB.BeginTrans();
			try
			{
				
				trans.Delete<SysOrgUser>(SysOrgUser._.Id.In(ids));
				count = trans.Delete<SysAdmin>(SysAdmin._.Id.In(ids));
				trans.Commit();
			}
			catch (Exception ex)
			{
				count = 0;
				Log.Logger.Error(ex);
				trans.Rollback();
			}
			return count;
		}
	}
}