// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysSiteConfig 数据访问层
//  作    者：Tom.Team
//  添加时间：2014-03-10 09:18:23
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
    /// SysSiteConfig数据访问层
    /// </summary>
    public partial class SysSiteConfigDAL : DALBase<SysSiteConfig>
    {

        /// <summary>
        /// 获取站点配置
        /// </summary>
        /// <returns></returns>
        public SysSiteConfig GetSiteConfig()
        {
            var list = GetTopList(1);
            return list == null ? null : list.First();
        }
    }
}