// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysModule 业务逻辑层
//  作    者：Tom.Team
//  添加时间：2014-03-20 10:23:36
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
	/// SysModule业务逻辑层
	/// </summary>
	public partial class SysModuleBLL : BLLBase<SysModule>
	{	     
		private readonly SysModuleDAL dal=new SysModuleDAL();

        /// <summary>
        /// 获取 模块实体和父级名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysModule GetModelAndParentName(int id)
        {
            var model = GetModel(id);
            if (model.ParentId > 0)
            {
                var pModel = GetModel(model.ParentId);
                model.ParentName = pModel.Name;
            }
            else
            {
                model.ParentName = "无父级";
            }
            return model;
        }

        public int Add(SysModule model)
        {
            return dal.Add(model);
        }
	}
}