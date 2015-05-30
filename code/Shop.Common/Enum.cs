using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Common
{
    public enum Approvel
    {
        /// <summary>
        /// 信用评价审批流程类型
        /// </summary>
        Credit = 1
    }

    /// <summary>
    /// 与附件相关的业务源
    /// </summary>
    public enum AttachSource
    {
        /// <summary>
        /// 设计单位
        /// </summary>
        DesignCompany = 0,

        /// <summary>
        /// 项目信息
        /// </summary>
        ProjectInfo = 1,

        /// <summary>
        /// 动态评审上传附件
        /// </summary>
        Dynamic,
        /// <summary>
        /// 设计单位附件
        /// </summary>
        DescompanyFiles
    }

    public enum ProjectStatus
    {
        /// <summary>
        /// 前期
        /// </summary>
        Prophase = 0,
        /// <summary>
        /// 招标
        /// </summary>
        bid = 1,
        /// <summary>
        /// 在建
        /// </summary>
        building = 2,
        /// <summary>
        /// 完工
        /// </summary>
        completed = 3

    }

    /// <summary>
    /// 信用等级
    /// </summary>
    public enum CreditGrade
    {
        D = 1,
        C,
        B,
        A,
        AA
    }

    /// <summary>
    /// 评定内容形式
    /// </summary>
    public enum BehaviorStandard
    {
        /// <summary>
        /// 投标
        /// </summary>
        TB =1,
        /// <summary>
        /// 履约
        /// </summary>
        LY,
        /// <summary>
        /// 其他
        /// </summary>
        QT
    }

    public enum HistoryType
    {
        /// <summary>
        /// 动态
        /// </summary>
        DynamicState = 1,
        /// <summary>
        /// 指定
        /// </summary>
        Assign
    }
}
