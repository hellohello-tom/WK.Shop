using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web
{
    /// <summary>
    /// dwz分页
    /// 
    /// tomCat
    /// 2014-3-27
    /// </summary>
    public class DWZPageInfo
    {
        private int _pageNum = 1;
        private int _numPerPage = 20;
        private string _sortName = string.Empty;
        private string _sortOrder = "asc";
        /// <summary>
        /// 当前页面 从1开始
        /// </summary>
        public int PageNum
        {
            get { return _pageNum; }
            set { _pageNum = value; }
        }

        /// <summary>
        /// 每页多少记录
        /// </summary>
        public int NumPerPage
        {
            get { return _numPerPage; }
            set { _numPerPage = value; }
        }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortName
        {
            get { return _sortName; }
            set { _sortName = value; }
        }
        /// <summary>
        /// 排序规则，'asc' or 'desc'
        /// </summary>
        public string SortOrder
        {
            get { return _sortOrder; }
            set { _sortOrder = value; }
        }
    }
}