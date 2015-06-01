// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysModule 数据访问层
//  作    者：Tom.Team
//  添加时间：2014-03-20 10:23:36
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
	/// SysModule数据访问层
	/// </summary>
	public partial class SysModuleDAL : DALBase<SysModule>
	{

        public int Add(SysModule model)
        {
            int id = 0;

            var trans = DB.BeginTrans();
            try
            {
                var pModel = DB.From<SysModule>().Where(SysModule._.Id == model.ParentId).ToSingle()?? new SysModule();
                model.Level = pModel.Level + 1;
                InsertCreator ic = InsertCreator.NewCreator().SetEntity<SysModule>(model);
                trans.Excute(ic, out id);

                if (string.IsNullOrEmpty(pModel.Relation)) pModel.Relation = ",";//如果父级不存在
                trans.Update<SysModule>(SysModule._.Relation, pModel.Relation + id + ",", SysModule._.Id == id);
                trans.Commit();
            }
            catch (Exception)
            {
                id = 0;
                trans.Rollback();
            }
            finally {
                trans.Dispose();
            }
          
            return id;
        }


       
	}
}