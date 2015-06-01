// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysAdmin Model
//  作    者：Tom.Team
//  添加时间：2014-03-10 11:55:34
// ==========================================================================
using System;
using System.Collections.Generic;

namespace Shop.Model
{

    public partial class SysAdmin
    {
        /// <summary>
        ///  当前登录用户有权限的菜单
        /// </summary>
        public List<SysModule> ModuleList { get; set; }

        /// <summary>
        /// 所属角色
        /// </summary>
        public string RoleNames { get; set; }

        /// <summary>
        /// 当前登录用户的组织机构信息
        /// </summary>
        public SysOrg Org { get; set; }

        /// <summary>
        /// 当前登录者的业务表主键ID，针对（设计，业主）
        /// </summary>
        public int BusinessId { get; set; }
    }
}

