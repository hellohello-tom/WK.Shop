// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：Menu Model
//  作    者：cat
//  添加时间：2015-06-17 10:59:27
// ==========================================================================
using System;
//引用
using MySoft.Data;
using System.ComponentModel.DataAnnotations;

namespace Shop.Model{
	/// <summary>
	/// 表名：Menu 主键列：Id 	 
///Menu
	/// </summary>
	[SerializableAttribute()]
	public partial class Menu : Entity,IModel
	{
   		#region 私有变量
   		private int _Id;
		private int _Menu_ParentId;
		private string _Menu_Name;
		private int _Menu_Sort;
		private string _Menu_Type;
		private int _Menu_User;
		private DateTime? _Menu_CreateTime;
		private bool _Menu_IsDel;
		   		#endregion  
   		
   		#region 属性
      			
		/// <summary>
		/// Id
        /// </summary>		
        public int Id
        {
            get{ return _Id; }
            set
            { 
                OnPropertyValueChange(_.Id, _Id, value);
                _Id = value; 
            }
        } 
				
		/// <summary>
		/// 父ID
        /// </summary>
		[RegularExpression("-?\\d+", ErrorMessage = "*")]		
        public int Menu_ParentId
        {
            get{ return _Menu_ParentId; }
            set
            { 
                OnPropertyValueChange(_.Menu_ParentId, _Menu_ParentId, value);
                _Menu_ParentId = value; 
            }
        } 
				
		/// <summary>
		/// 菜单名称
        /// </summary>
		[StringLength(10,ErrorMessage="*")]		
        public string Menu_Name
        {
            get{ return _Menu_Name; }
            set
            { 
                OnPropertyValueChange(_.Menu_Name, _Menu_Name, value);
                _Menu_Name = value; 
            }
        } 
				
		/// <summary>
		/// 排序
        /// </summary>
		[RegularExpression("-?\\d+", ErrorMessage = "*")]		
        public int Menu_Sort
        {
            get{ return _Menu_Sort; }
            set
            { 
                OnPropertyValueChange(_.Menu_Sort, _Menu_Sort, value);
                _Menu_Sort = value; 
            }
        } 
				
		/// <summary>
		/// 菜单类型
        /// </summary>
		[StringLength(10,ErrorMessage="*")]		
        public string Menu_Type
        {
            get{ return _Menu_Type; }
            set
            { 
                OnPropertyValueChange(_.Menu_Type, _Menu_Type, value);
                _Menu_Type = value; 
            }
        } 
				
		/// <summary>
		/// 创建人
        /// </summary>
		[RegularExpression("-?\\d+", ErrorMessage = "*")]		
        public int Menu_User
        {
            get{ return _Menu_User; }
            set
            { 
                OnPropertyValueChange(_.Menu_User, _Menu_User, value);
                _Menu_User = value; 
            }
        } 
				
		/// <summary>
		/// 创建时间
        /// </summary>
		[RegularExpression("^\\d{4}(\\-|\\/|\\.)\\d{1,2}\\1\\d{1,2}(\\s\\d{1,2}:\\d{1,2}:\\d{1,2})?$", ErrorMessage = "*")]		
        public DateTime? Menu_CreateTime
        {
            get{ return _Menu_CreateTime; }
            set
            { 
                OnPropertyValueChange(_.Menu_CreateTime, _Menu_CreateTime, value);
                _Menu_CreateTime = value; 
            }
        } 
				
		/// <summary>
		/// 是否删除
        /// </summary>		
        public bool Menu_IsDel
        {
            get{ return _Menu_IsDel; }
            set
            { 
                OnPropertyValueChange(_.Menu_IsDel, _Menu_IsDel, value);
                _Menu_IsDel = value; 
            }
        } 
				#endregion
		
		#region MySoft
		/// <summary>
        /// 获取实体对应的表名
        /// </summary>
        protected override Table GetTable()
        {
            return new Table<Menu>("Menu");
        }

        /// <summary>
        /// 获取实体中的标识列
        /// </summary>
        protected override Field GetIdentityField()
        {
            return _.Id;
        }

        /// <summary>
        /// 获取实体中的主键列
        /// </summary>
        protected override Field[] GetPrimaryKeyFields()
        {
            return new Field[] {		
           						_.Id};
        }

        /// <summary>
        /// 获取列信息
        /// </summary>
        protected override Field[] GetFields()
        {
            return new Field[] {         
            					_.Id,
								_.Menu_ParentId,
								_.Menu_Name,
								_.Menu_Sort,
								_.Menu_Type,
								_.Menu_User,
								_.Menu_CreateTime,
								_.Menu_IsDel};
        }

        /// <summary>
        /// 获取列数据
        /// </summary>
        protected override object[] GetValues()
        {
            return new object[] {
            					_Id,
								_Menu_ParentId,
								_Menu_Name,
								_Menu_Sort,
								_Menu_Type,
								_Menu_User,
								_Menu_CreateTime,
								_Menu_IsDel};
        }

        /// <summary>
        /// 给当前实体赋值
        /// </summary>
        protected override void SetValues(IRowReader reader)
        {           
            			
			if ((false == reader.IsDBNull(_.Id)))
			{
				this._Id=reader.GetInt32(_.Id);
			}
						
			if ((false == reader.IsDBNull(_.Menu_ParentId)))
			{
				this._Menu_ParentId=reader.GetInt32(_.Menu_ParentId);
			}
						
			if ((false == reader.IsDBNull(_.Menu_Name)))
			{
				this._Menu_Name=reader.GetString(_.Menu_Name);
			}
						
			if ((false == reader.IsDBNull(_.Menu_Sort)))
			{
				this._Menu_Sort=reader.GetInt32(_.Menu_Sort);
			}
						
			if ((false == reader.IsDBNull(_.Menu_Type)))
			{
				this._Menu_Type=reader.GetString(_.Menu_Type);
			}
						
			if ((false == reader.IsDBNull(_.Menu_User)))
			{
				this._Menu_User=reader.GetInt32(_.Menu_User);
			}
						
			if ((false == reader.IsDBNull(_.Menu_CreateTime)))
			{
				this._Menu_CreateTime=reader.GetDateTime(_.Menu_CreateTime);
			}
			        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if ((obj == null))
            {
                return false;
            }
            if ((false == typeof(Menu).IsAssignableFrom(obj.GetType())))
            {
                return false;
            }
            if ((((object)(this)) == ((object)(obj))))
            {
                return true;
            }
            return false;
        }

        public class _
        {

            /// <summary>
            /// 表示选择所有列，与*等同
            /// </summary>
            public static AllField All = new AllField<Menu>();
                        
            /// <summary>
            /// 字段名:Id -  数据类型:int
            /// </summary>
            public static Field Id = new Field<Menu>("Id");
			            
            /// <summary>
            /// 父ID -  数据类型:int
            /// </summary>
            public static Field Menu_ParentId = new Field<Menu>("Menu_ParentId");
			            
            /// <summary>
            /// 菜单名称 -  数据类型:string
            /// </summary>
            public static Field Menu_Name = new Field<Menu>("Menu_Name");
			            
            /// <summary>
            /// 排序 -  数据类型:int
            /// </summary>
            public static Field Menu_Sort = new Field<Menu>("Menu_Sort");
			            
            /// <summary>
            /// 菜单类型 -  数据类型:string
            /// </summary>
            public static Field Menu_Type = new Field<Menu>("Menu_Type");
			            
            /// <summary>
            /// 创建人 -  数据类型:int
            /// </summary>
            public static Field Menu_User = new Field<Menu>("Menu_User");
			            
            /// <summary>
            /// 创建时间 -  数据类型:DateTime
            /// </summary>
            public static Field Menu_CreateTime = new Field<Menu>("Menu_CreateTime");
			            
            /// <summary>
            /// 是否删除 -  数据类型:bool
            /// </summary>
            public static Field Menu_IsDel = new Field<Menu>("Menu_IsDel");
						
		}
        #endregion
   
	}
}

