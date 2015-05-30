// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysDicDetail 业务逻辑层
//  作    者：ThinkWang
//  添加时间：2014-03-20 10:23:31
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
	/// SysDicDetail业务逻辑层
	/// </summary>
	public partial class SysDicDetailBLL : BLLBase<SysDicDetail>
	{	     
		private readonly SysDicDetailDAL dal=new SysDicDetailDAL();
	
		
		/// <summary>
        /// 根据条件获取数据 left SysDicType
		/// </summary>
		/// <param name="wc"></param>
		/// <returns>数据列表</returns>
		public List<SysDicDetail> GetlistByCondition(WhereClip wc)
		{
			return dal.GetlistByCondition(wc);
		}
        /// <summary>
        /// 增加一条数据（子项目增加时用的）
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回自增的ID</returns>
        public int SysDicDetailAdd(SysDicDetail model)
        {
            return dal.SysDicDetailAdd(model);
        }
        /// <summary>
        /// 通过城市名称获得ID
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public SysDicDetail GetSysModel(string cityName)
        {
            return dal.GetSysModel(cityName);
        }
   
	}
}