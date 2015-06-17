// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：FlashSales Model
//  作    者：cat
//  添加时间：2015-06-17 10:59:29
// ==========================================================================
using System;
//引用
using MySoft.Data;
using System.ComponentModel.DataAnnotations;

namespace Shop.Model
{
    /// <summary>
    /// 表名：FlashSales 主键列：Id 	 

    ///FlashSales
    /// </summary>
    public partial class FlashSales
    {
        private string FileAttr_Path { get; set; }

        private string FileAttr_Name { get; set; }
    }
}

