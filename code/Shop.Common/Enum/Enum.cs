using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Common
{
    public enum Theme
    {
        /// <summary>
        /// 药材
        /// </summary>
        Materials = 0,

        /// <summary>
        /// 日用百货
        /// </summary>
        Store = 1
    }

    /// <summary>
    /// 业务标示（附件表用）
    /// </summary>
    public enum BizCode
    {
        /// <summary>
        /// 商品
        /// </summary>
        Commodity = 0,
        /// <summary>
        /// 闪购图
        /// </summary>
        FlashSales
    }

    /// <summary>
    /// 状态
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// 显示
        /// </summary>
        Show = 0,

        /// <summary>
        /// 隐藏
        /// </summary>
        Hide = 1,

        /// <summary>
        /// 展示
        /// </summary>
        View = 2
    }

    public enum MenuType
    {
        /// <summary>
        /// 闪购
        /// </summary>
        FlashSalues = 0,

        /// <summary>
        /// 日用百货
        /// </summary>
        Store = 1,

        /// <summary>
        /// 药品标签
        /// </summary>
        Tag =2
    }
}
