// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：Menu 数据访问层
//  作    者：cat
//  添加时间：2015-06-17 10:59:27
// ==========================================================================
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
//引用
using Shop.Model;
using MySoft.Data;

namespace Shop.DAL  
{
	/// <summary>
	/// Menu数据访问层
	/// </summary>
	public partial class MenuDAL : DALBase<Menu>
	{
	    /// <summary>
	    ///  获取常见疾病的科室和Menu
	    /// </summary>
	    /// <param name="showCount">每个科室下Menu数量</param>
	    /// <returns></returns>
	    public DataTable GetCommonDiseasesTable(int showCount )
        {
            string sql = string.Format(@"select T.Id,T.Menu_Name,T.Menu_Sort,T.Navigation_Id,T.Navigation_Name,T.Navigation_ImagePath,T.Navigation_Sort,T.Mid
                    from(
                    select Menu.Id,Navigation_Name,Navigation_ImagePath,Menu_Name,Navigation_Sort,Menu_Sort,Navigation.Id as Navigation_Id
                    ,ROW_NUMBER() over(partition by Navigation.Navigation_sort order by Navigation.Navigation_sort desc) Mid
                    from Navigation left join Menu on Navigation.Id=Menu.Menu_NavigationId and Menu.Menu_Type='Tag'
                        where Navigation_IsUse =1 and Menu_Name is not null  and Menu.Menu_IsDel=0 and (Menu.Menu_Status=0 or Menu.Menu_Status=2) and Navigation_Name like '%科'
                    ) T
                    Group by T.Navigation_Name,T.Id,T.Menu_Name,T.Navigation_Sort,T.Mid,T.Menu_Sort,T.Navigation_Id,T.Navigation_ImagePath
                    having Mid<={0} order by T.Navigation_Sort Desc;", showCount);
            try
            {
                var dt = DB.FromSql(sql).ToTable() as DataTable;
                return dt;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
   		
	}
}