// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：Commodity 数据访问层
//  作    者：cat
//  添加时间：2015-06-08 17:34:32
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
    /// Commodity数据访问层
    /// </summary>
    public partial class CommodityDAL : DALBase<Commodity>
    {

        public bool Update(Commodity model, int[] imageIds)
        {
            var trans = DB.BeginTrans();
            try
            {
                model.Attach();
                if (imageIds.Length > 0)
                {
                    trans.Update<FileAttr>(FileAttr._.FileAttr_BussinessId, model.Id, FileAttr._.Id.In(imageIds));
                }
                trans.Save(model);
                trans.Commit();
                return true;
            }
            catch
            {
                trans.Rollback();
                return false;
            }
            finally
            {
                trans.Dispose();
            }
        }

        public int Add(Commodity model, int[] imageIds)
        {
            int id = 0;
            var trans = DB.BeginTrans();
            try
            {
                InsertCreator ic = InsertCreator.NewCreator().SetEntity<Commodity>(model);
                trans.Excute(ic, out id);
                if (imageIds.Length > 0)
                {
                    trans.Update<FileAttr>(FileAttr._.FileAttr_BussinessId, id, FileAttr._.Id.In(imageIds));
                }
                trans.Commit();
            }
            catch
            {
                trans.Rollback();
            }
            finally
            {
                trans.Dispose();
            }
            return id;
        }
    }
}