// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：Tag Model
//  作    者：cat
//  添加时间：2015-06-08 17:34:40
// ==========================================================================
using System;
//引用
using MySoft.Data;
using System.ComponentModel.DataAnnotations;

namespace Shop.Model{
	/// <summary>
	/// 表名：Tag 主键列：Id 	 
///Tag
	/// </summary>
	[SerializableAttribute()]
	public partial class Tag : Entity,IModel
	{
   		#region 私有变量
   		private int _Id;
		private int _Tag_NavigationId;
		private string _Tag_Name;
		private string _Tag_ImagePath;
		private int _Tag_Sort;
		private DateTime? _Tag_CreateTime;
		private int _Tag_User;
		private bool _Tag_IsDel;
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
		/// 导航ID
        /// </summary>
        [Required(ErrorMessage="请选择导航")]		[RegularExpression("-?\\d+", ErrorMessage = "*")]		
        public int Tag_NavigationId
        {
            get{ return _Tag_NavigationId; }
            set
            { 
                OnPropertyValueChange(_.Tag_NavigationId, _Tag_NavigationId, value);
                _Tag_NavigationId = value; 
            }
        } 
				
		/// <summary>
		/// 标签名称
        /// </summary>
        [Required(ErrorMessage = "必填")]		[StringLength(10,ErrorMessage="长度不可超过10个字符")]		
        public string Tag_Name
        {
            get{ return _Tag_Name; }
            set
            { 
                OnPropertyValueChange(_.Tag_Name, _Tag_Name, value);
                _Tag_Name = value; 
            }
        } 
				
		/// <summary>
		/// 标签图片
        /// </summary>		[StringLength(500,ErrorMessage="*")]		
        public string Tag_ImagePath
        {
            get{ return _Tag_ImagePath; }
            set
            { 
                OnPropertyValueChange(_.Tag_ImagePath, _Tag_ImagePath, value);
                _Tag_ImagePath = value; 
            }
        } 
				
		/// <summary>
		/// 排序
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Range(1, 999, ErrorMessage = "1~999之间")]
        [RegularExpression(@"^\d+$", ErrorMessage = "请输入正整数")]
        public int Tag_Sort
        {
            get{ return _Tag_Sort; }
            set
            { 
                OnPropertyValueChange(_.Tag_Sort, _Tag_Sort, value);
                _Tag_Sort = value; 
            }
        } 
				
		/// <summary>
		/// 创建时间
        /// </summary>
		[RegularExpression("^\\d{4}(\\-|\\/|\\.)\\d{1,2}\\1\\d{1,2}(\\s\\d{1,2}:\\d{1,2}:\\d{1,2})?$", ErrorMessage = "*")]		
        public DateTime? Tag_CreateTime
        {
            get{ return _Tag_CreateTime; }
            set
            { 
                OnPropertyValueChange(_.Tag_CreateTime, _Tag_CreateTime, value);
                _Tag_CreateTime = value; 
            }
        } 
				
		/// <summary>
		/// 创建人
        /// </summary>
		[RegularExpression("-?\\d+", ErrorMessage = "*")]		
        public int Tag_User
        {
            get{ return _Tag_User; }
            set
            { 
                OnPropertyValueChange(_.Tag_User, _Tag_User, value);
                _Tag_User = value; 
            }
        } 
				
		/// <summary>
		/// 是否删除
        /// </summary>		
        public bool Tag_IsDel
        {
            get{ return _Tag_IsDel; }
            set
            { 
                OnPropertyValueChange(_.Tag_IsDel, _Tag_IsDel, value);
                _Tag_IsDel = value; 
            }
        } 
				#endregion
		
		#region MySoft
		/// <summary>
        /// 获取实体对应的表名
        /// </summary>
        protected override Table GetTable()
        {
            return new Table<Tag>("Tag");
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
								_.Tag_NavigationId,
								_.Tag_Name,
								_.Tag_ImagePath,
								_.Tag_Sort,
								_.Tag_CreateTime,
								_.Tag_User,
								_.Tag_IsDel};
        }

        /// <summary>
        /// 获取列数据
        /// </summary>
        protected override object[] GetValues()
        {
            return new object[] {
            					_Id,
								_Tag_NavigationId,
								_Tag_Name,
								_Tag_ImagePath,
								_Tag_Sort,
								_Tag_CreateTime,
								_Tag_User,
								_Tag_IsDel};
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
						
			if ((false == reader.IsDBNull(_.Tag_NavigationId)))
			{
				this._Tag_NavigationId=reader.GetInt32(_.Tag_NavigationId);
			}
						
			if ((false == reader.IsDBNull(_.Tag_Name)))
			{
				this._Tag_Name=reader.GetString(_.Tag_Name);
			}
						
			if ((false == reader.IsDBNull(_.Tag_ImagePath)))
			{
				this._Tag_ImagePath=reader.GetString(_.Tag_ImagePath);
			}
						
			if ((false == reader.IsDBNull(_.Tag_Sort)))
			{
				this._Tag_Sort=reader.GetInt32(_.Tag_Sort);
			}
						
			if ((false == reader.IsDBNull(_.Tag_CreateTime)))
			{
				this._Tag_CreateTime=reader.GetDateTime(_.Tag_CreateTime);
			}
						
			if ((false == reader.IsDBNull(_.Tag_User)))
			{
				this._Tag_User=reader.GetInt32(_.Tag_User);
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
            if ((false == typeof(Tag).IsAssignableFrom(obj.GetType())))
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
            public static AllField All = new AllField<Tag>();
                        
            /// <summary>
            /// Id -  数据类型:int
            /// </summary>
            public static Field Id = new Field<Tag>("Id");
			            
            /// <summary>
            /// 导航ID -  数据类型:int
            /// </summary>
            public static Field Tag_NavigationId = new Field<Tag>("Tag_NavigationId");
			            
            /// <summary>
            /// 标签名称 -  数据类型:string
            /// </summary>
            public static Field Tag_Name = new Field<Tag>("Tag_Name");
			            
            /// <summary>
            /// 标签图片 -  数据类型:string
            /// </summary>
            public static Field Tag_ImagePath = new Field<Tag>("Tag_ImagePath");
			            
            /// <summary>
            /// 排序 -  数据类型:int
            /// </summary>
            public static Field Tag_Sort = new Field<Tag>("Tag_Sort");
			            
            /// <summary>
            /// 创建时间 -  数据类型:DateTime
            /// </summary>
            public static Field Tag_CreateTime = new Field<Tag>("Tag_CreateTime");
			            
            /// <summary>
            /// 创建人 -  数据类型:int
            /// </summary>
            public static Field Tag_User = new Field<Tag>("Tag_User");
			            
            /// <summary>
            /// 是否删除 -  数据类型:bool
            /// </summary>
            public static Field Tag_IsDel = new Field<Tag>("Tag_IsDel");
						
		}
        #endregion
   
	}
}

