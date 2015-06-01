// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysOrg 数据访问层
//  作    者：Tom.Team
//  添加时间：2014-10-25 11:45:13
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
	/// 组织机构(SysOrg)数据访问层
	/// </summary>
	public partial class SysOrgDAL : DALBase<SysOrg>
	{
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <returns>返回自增id</returns>
        public int Add(SysOrg model)
        {
            int id = 0;

            var trans = DB.BeginTrans();
            try
            {
                var pModel = DB.From<SysOrg>().Where(SysOrg._.Id == model.ParentId).ToSingle() ?? new SysOrg();
                model.Level = pModel.Level + 1;
                InsertCreator ic = InsertCreator.NewCreator().SetEntity<SysOrg>(model);
                trans.Excute(ic, out id);

                if (string.IsNullOrEmpty(pModel.Relation)) pModel.Relation = ",";//如果父级不存在
                trans.Update<SysOrg>(SysOrg._.Relation, pModel.Relation + id + ",", SysOrg._.Id == id);
                trans.Commit();
            }
            catch (Exception)
            {
                id = 0;
                trans.Rollback();
            }
            finally
            {
                trans.Dispose();
            }

            return id;

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>	
        public bool Update(SysOrg model)
        {
            model.Attach();
            return DB.Save(model) > 0;
        }


        /// <summary>
        /// 根据用户id获取组织机构实体
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public SysOrg GetModelByUserId(int userId)
        {

            return DB.From<SysOrg>().LeftJoin<SysOrgUser>(SysOrgUser._.OrgId == SysOrg._.Id).Where(SysOrgUser._.UserId == userId).ToSingle();
        }
    }
}