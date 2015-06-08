// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：Navigation Model
//  作    者：cat
//  添加时间：2015-06-08 17:34:38
// ==========================================================================
using System;
//引用
using MySoft.Data;
using System.ComponentModel.DataAnnotations;

namespace Shop.Model{
	/// <summary>
	/// 表名：Navigation 主键列：Id 	 
///Navigation
	/// </summary>
	[SerializableAttribute()]
	public partial class Navigation : Entity,IModel
	{
   		#region 私有变量
   		private int _Id;
		private string _Navigation_Name;
		private int _Navigation_Sort;
		private int _Navigation_Type;
		private DateTime? _Navigation_CreateTime;
		private int _Navigation_User;
		private bool _Navigation_IsDel;
		   		#endregion  
   		
   		#region 属性
      			
		/// <summary>
		/// ID
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
		/// 导航名称
        /// </summary>
		[StringLength(10,ErrorMessage="*")]		
        public string Navigation_Name
        {
            get{ return _Navigation_Name; }
            set
            { 
                OnPropertyValueChange(_.Navigation_Name, _Navigation_Name, value);
                _Navigation_Name = value; 
            }
        } 
				
		/// <summary>
		/// 排序
        /// </summary>
		[RegularExpression("-?\\d+", ErrorMessage = "*")]		
        public int Navigation_Sort
        {
            get{ return _Navigation_Sort; }
            set
            { 
                OnPropertyValueChange(_.Navigation_Sort, _Navigation_Sort, value);
                _Navigation_Sort = value; 
            }
        } 
				
		/// <summary>
		/// 0,药材专场，1日用百货专场
        /// </summary>
		[RegularExpression("-?\\d+", ErrorMessage = "*")]		
        public int Navigation_Type
        {
            get{ return _Navigation_Type; }
            set
            { 
                OnPropertyValueChange(_.Navigation_Type, _Navigation_Type, value);
                _Navigation_Type = value; 
            }
        } 
				
		/// <summary>
		/// Navigation_CreateTime
        /// </summary>
		[RegularExpression("^\\d{4}(\\-|\\/|\\.)\\d{1,2}\\1\\d{1,2}(\\s\\d{1,2}:\\d{1,2}:\\d{1,2})?$", ErrorMessage = "*")]		
        public DateTime? Navigation_CreateTime
        {
            get{ return _Navigation_CreateTime; }
            set
            { 
                OnPropertyValueChange(_.Navigation_CreateTime, _Navigation_CreateTime, value);
                _Navigation_CreateTime = value; 
            }
        } 
				
		/// <summary>
		/// Navigation_User
        /// </summary>
		[RegularExpression("-?\\d+", ErrorMessage = "*")]		
        public int Navigation_User
        {
            get{ return _Navigation_User; }
            set
            { 
                OnPropertyValueChange(_.Navigation_User, _Navigation_User, value);
                _Navigation_User = value; 
            }
        } 
				
		/// <summary>
		/// Navigation_IsDel
        /// </summary>		
        public bool Navigation_IsDel
        {
            get{ return _Navigation_IsDel; }
            set
            { 
                OnPropertyValueChange(_.Navigation_IsDel, _Navigation_IsDel, value);
                _Navigation_IsDel = value; 
            }
        } 
				#endregion
		
		#region MySoft
		/// <summary>
        /// 获取实体对应的表名
        /// </summary>
        protected override Table GetTable()
        {
            return new Table<Navigation>("Navigation");
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
								_.Navigation_Name,
								_.Navigation_Sort,
								_.Navigation_Type,
								_.Navigation_CreateTime,
								_.Navigation_User,
								_.Navigation_IsDel};
        }

        /// <summary>
        /// 获取列数据
        /// </summary>
        protected override object[] GetValues()
        {
            return new object[] {
            					_Id,
								_Navigation_Name,
								_Navigation_Sort,
								_Navigation_Type,
								_Navigation_CreateTime,
								_Navigation_User,
								_Navigation_IsDel};
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
						
			if ((false == reader.IsDBNull(_.Navigation_Name)))
			{
				this._Navigation_Name=reader.GetString(_.Navigation_Name);
			}
						
			if ((false == reader.IsDBNull(_.Navigation_Sort)))
			{
				this._Navigation_Sort=reader.GetInt32(_.Navigation_Sort);
			}
						
			if ((false == reader.IsDBNull(_.Navigation_Type)))
			{
				this._Navigation_Type=reader.GetInt32(_.Navigation_Type);
			}
						
			if ((false == reader.IsDBNull(_.Navigation_CreateTime)))
			{
				this._Navigation_CreateTime=reader.GetDateTime(_.Navigation_CreateTime);
			}
						
			if ((false == reader.IsDBNull(_.Navigation_User)))
			{
				this._Navigation_User=reader.GetInt32(_.Navigation_User);
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
            if ((false == typeof(Navigation).IsAssignableFrom(obj.GetType())))
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
            public static AllField All = new AllField<Navigation>();
                        
            /// <summary>
            /// ID -  数据类型:int
            /// </summary>
            public static Field Id = new Field<Navigation>("Id");
			            
            /// <summary>
            /// 导航名称 -  数据类型:string
            /// </summary>
            public static Field Navigation_Name = new Field<Navigation>("Navigation_Name");
			            
            /// <summary>
            /// 排序 -  数据类型:int
            /// </summary>
            public static Field Navigation_Sort = new Field<Navigation>("Navigation_Sort");
			            
            /// <summary>
            /// 0,药材专场，1日用百货专场 -  数据类型:int
            /// </summary>
            public static Field Navigation_Type = new Field<Navigation>("Navigation_Type");
			            
            /// <summary>
            /// 字段名:Navigation_CreateTime -  数据类型:DateTime
            /// </summary>
            public static Field Navigation_CreateTime = new Field<Navigation>("Navigation_CreateTime");
			            
            /// <summary>
            /// 字段名:Navigation_User -  数据类型:int
            /// </summary>
            public static Field Navigation_User = new Field<Navigation>("Navigation_User");
			            
            /// <summary>
            /// 字段名:Navigation_IsDel -  数据类型:bool
            /// </summary>
            public static Field Navigation_IsDel = new Field<Navigation>("Navigation_IsDel");
						
		}
        #endregion
   
	}
}

