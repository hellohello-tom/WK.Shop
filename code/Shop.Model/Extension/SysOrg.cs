using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Model
{
    /// <summary>
    ///组织机构(SysOrg)
    /// </summary>
    public partial class SysOrg
    {
        /// <summary>
        /// 所有子级点id
        /// </summary>
        public int[] ChildIds { get; set; }
    }
}
