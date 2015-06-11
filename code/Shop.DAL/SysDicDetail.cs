// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysDicDetail 数据访问层
//  作    者：Tom.Team
//  添加时间：2014-03-20 10:23:29
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
	/// SysDicDetail数据访问层
	/// </summary>
	public partial class SysDicDetailDAL : DALBase<SysDicDetail>
	{

		/// <summary>
        /// 根据条件获取数据 left SysDicType
		/// </summary>
		/// <param name="wc"
		/// <returns>数据列表</returns>
		public List<SysDicDetail> GetlistByCondition(WhereClip wc)
		{
			return DB.From<SysDicDetail>()
				 .LeftJoin<SysDicType>(SysDicType._.Id == SysDicDetail._.DicTypeId)
				 .Select(SysDicDetail._.All)
				 .Where(wc).OrderBy(SysDicDetail._.OrderNum.Asc)
				 .ToList() as List<SysDicDetail>;

		}
        /// <summary>
        /// 增加一条数据（子项目增加时用的）
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回自增的ID</returns>
        public int SysDicDetailAdd(SysDicDetail model)
        {
            int id = 0;

            var trans = DB.BeginTrans();
            try
            {
                var pModel = DB.From<SysDicDetail>().Where(SysDicDetail._.Id == model.ParentId).ToSingle() ?? new SysDicDetail();
                model.Level = pModel.Level + 1;
                InsertCreator ic = InsertCreator.NewCreator().SetEntity<SysDicDetail>(model);
                trans.Excute(ic, out id);

                if (string.IsNullOrEmpty(pModel.Relation)) pModel.Relation = ",";//如果父级不存在
                trans.Update<SysDicDetail>(SysDicDetail._.Relation, pModel.Relation + id + ",", SysDicDetail._.Id == id);
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
        /// 通过城市名称获得ID
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public SysDicDetail GetSysModel(string cityName)
        {
            return DB.From<SysDicDetail>().Where(SysDicDetail._.Name==cityName).ToSingle();
        }

        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool AddList(List<SysDicDetail> list)
        {
            var trans = DB.BeginTrans();
            try
            {
                foreach (var item in list)
                {
                    if (!trans.Exists<SysDicDetail>(SysDicDetail._.Name == item.Name))
                    {
                        item.Detach();
                        trans.Save(item);
                    }
                }
                trans.Commit();
                return true;
            }
            catch (Exception)
            {
                trans.Rollback();
                return false;
            }
            finally
            {
                trans.Dispose();
            }
        }

	}
}