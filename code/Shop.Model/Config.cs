// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：Config Model
//  作    者：cat
//  添加时间：2015-06-08 17:34:34
// ==========================================================================
using System;
namespace Shop.Model{
	/// <summary>
	/// 表名：Config 主键列：Id 	 
///Config
	/// </summary>
	[SerializableAttribute()]
	public  class Config
	{
        /// <summary>
        /// 站点名称
        /// </summary>
        public string ConfigName { get; set; }

        /// <summary>
        /// 手机端采用的样式
        /// </summary>
        public string PhoneStyle { get; set; }

        /// <summary>
        /// 页脚信息
        /// </summary>
        public string Footer { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 服务微信
        /// </summary>
        public string WeiXin { get; set; }
	}
}

