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

namespace Shop.Model{
	/// <summary>
	/// 表名：FlashSales 主键列：Id 	 
///FlashSales
	/// </summary>
	[SerializableAttribute()]
	public partial class FlashSales : Entity,IModel
	{
   		#region 私有变量
   		private int _Id;
		private int _FlashSales_MenuId;
		private string _FlashSales_Name;
		private DateTime? _FlashSales_EndTime;
		private string _FlashSales_KeyWord;
		private decimal _FlashSales_Discount;
		private int _FlashSales_CreateUser;
		private DateTime? _FlashSales_CreateTime;
		private bool _FlashSales_IsDel;
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
		/// 菜单ID
        /// </summary>
		[RegularExpression("-?\\d+", ErrorMessage = "*")]		
        public int FlashSales_MenuId
        {
            get{ return _FlashSales_MenuId; }
            set
            { 
                OnPropertyValueChange(_.FlashSales_MenuId, _FlashSales_MenuId, value);
                _FlashSales_MenuId = value; 
            }
        } 
				
		/// <summary>
		/// 名称
        /// </summary>
		[StringLength(10,ErrorMessage="*")]		
        public string FlashSales_Name
        {
            get{ return _FlashSales_Name; }
            set
            { 
                OnPropertyValueChange(_.FlashSales_Name, _FlashSales_Name, value);
                _FlashSales_Name = value; 
            }
        } 
				
		/// <summary>
		/// 截止时间
        /// </summary>
		[RegularExpression("^\\d{4}(\\-|\\/|\\.)\\d{1,2}\\1\\d{1,2}(\\s\\d{1,2}:\\d{1,2}:\\d{1,2})?$", ErrorMessage = "*")]		
        public DateTime? FlashSales_EndTime
        {
            get{ return _FlashSales_EndTime; }
            set
            { 
                OnPropertyValueChange(_.FlashSales_EndTime, _FlashSales_EndTime, value);
                _FlashSales_EndTime = value; 
            }
        } 
				
		/// <summary>
		/// 关键字
        /// </summary>
		[StringLength(50,ErrorMessage="*")]		
        public string FlashSales_KeyWord
        {
            get{ return _FlashSales_KeyWord; }
            set
            { 
                OnPropertyValueChange(_.FlashSales_KeyWord, _FlashSales_KeyWord, value);
                _FlashSales_KeyWord = value; 
            }
        } 
				
		/// <summary>
		/// 折扣
        /// </summary>
		[RegularExpression("-?\\d{1,9}(.\\d{1,0})?", ErrorMessage = "*")]		
        public decimal FlashSales_Discount
        {
            get{ return _FlashSales_Discount; }
            set
            { 
                OnPropertyValueChange(_.FlashSales_Discount, _FlashSales_Discount, value);
                _FlashSales_Discount = value; 
            }
        } 
				
		/// <summary>
		/// 创建人
        /// </summary>
		[RegularExpression("-?\\d+", ErrorMessage = "*")]		
        public int FlashSales_CreateUser
        {
            get{ return _FlashSales_CreateUser; }
            set
            { 
                OnPropertyValueChange(_.FlashSales_CreateUser, _FlashSales_CreateUser, value);
                _FlashSales_CreateUser = value; 
            }
        } 
				
		/// <summary>
		/// 创建时间
        /// </summary>
		[RegularExpression("^\\d{4}(\\-|\\/|\\.)\\d{1,2}\\1\\d{1,2}(\\s\\d{1,2}:\\d{1,2}:\\d{1,2})?$", ErrorMessage = "*")]		
        public DateTime? FlashSales_CreateTime
        {
            get{ return _FlashSales_CreateTime; }
            set
            { 
                OnPropertyValueChange(_.FlashSales_CreateTime, _FlashSales_CreateTime, value);
                _FlashSales_CreateTime = value; 
            }
        } 
				
		/// <summary>
		/// 是否删除
        /// </summary>		
        public bool FlashSales_IsDel
        {
            get{ return _FlashSales_IsDel; }
            set
            { 
                OnPropertyValueChange(_.FlashSales_IsDel, _FlashSales_IsDel, value);
                _FlashSales_IsDel = value; 
            }
        } 
				#endregion
		
		#region MySoft
		/// <summary>
        /// 获取实体对应的表名
        /// </summary>
        protected override Table GetTable()
        {
            return new Table<FlashSales>("FlashSales");
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
								_.FlashSales_MenuId,
								_.FlashSales_Name,
								_.FlashSales_EndTime,
								_.FlashSales_KeyWord,
								_.FlashSales_Discount,
								_.FlashSales_CreateUser,
								_.FlashSales_CreateTime,
								_.FlashSales_IsDel};
        }

        /// <summary>
        /// 获取列数据
        /// </summary>
        protected override object[] GetValues()
        {
            return new object[] {
            					_Id,
								_FlashSales_MenuId,
								_FlashSales_Name,
								_FlashSales_EndTime,
								_FlashSales_KeyWord,
								_FlashSales_Discount,
								_FlashSales_CreateUser,
								_FlashSales_CreateTime,
								_FlashSales_IsDel};
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
						
			if ((false == reader.IsDBNull(_.FlashSales_MenuId)))
			{
				this._FlashSales_MenuId=reader.GetInt32(_.FlashSales_MenuId);
			}
						
			if ((false == reader.IsDBNull(_.FlashSales_Name)))
			{
				this._FlashSales_Name=reader.GetString(_.FlashSales_Name);
			}
						
			if ((false == reader.IsDBNull(_.FlashSales_EndTime)))
			{
				this._FlashSales_EndTime=reader.GetDateTime(_.FlashSales_EndTime);
			}
						
			if ((false == reader.IsDBNull(_.FlashSales_KeyWord)))
			{
				this._FlashSales_KeyWord=reader.GetString(_.FlashSales_KeyWord);
			}
						
			if ((false == reader.IsDBNull(_.FlashSales_Discount)))
			{
				this._FlashSales_Discount=reader.GetDecimal(_.FlashSales_Discount);
			}
						
			if ((false == reader.IsDBNull(_.FlashSales_CreateUser)))
			{
				this._FlashSales_CreateUser=reader.GetInt32(_.FlashSales_CreateUser);
			}
						
			if ((false == reader.IsDBNull(_.FlashSales_CreateTime)))
			{
				this._FlashSales_CreateTime=reader.GetDateTime(_.FlashSales_CreateTime);
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
            if ((false == typeof(FlashSales).IsAssignableFrom(obj.GetType())))
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
            public static AllField All = new AllField<FlashSales>();
                        
            /// <summary>
            /// Id -  数据类型:int
            /// </summary>
            public static Field Id = new Field<FlashSales>("Id");
			            
            /// <summary>
            /// 菜单ID -  数据类型:int
            /// </summary>
            public static Field FlashSales_MenuId = new Field<FlashSales>("FlashSales_MenuId");
			            
            /// <summary>
            /// 名称 -  数据类型:string
            /// </summary>
            public static Field FlashSales_Name = new Field<FlashSales>("FlashSales_Name");
			            
            /// <summary>
            /// 截止时间 -  数据类型:DateTime
            /// </summary>
            public static Field FlashSales_EndTime = new Field<FlashSales>("FlashSales_EndTime");
			            
            /// <summary>
            /// 关键字 -  数据类型:string
            /// </summary>
            public static Field FlashSales_KeyWord = new Field<FlashSales>("FlashSales_KeyWord");
			            
            /// <summary>
            /// 折扣 -  数据类型:decimal
            /// </summary>
            public static Field FlashSales_Discount = new Field<FlashSales>("FlashSales_Discount");
			            
            /// <summary>
            /// 创建人 -  数据类型:int
            /// </summary>
            public static Field FlashSales_CreateUser = new Field<FlashSales>("FlashSales_CreateUser");
			            
            /// <summary>
            /// 创建时间 -  数据类型:DateTime
            /// </summary>
            public static Field FlashSales_CreateTime = new Field<FlashSales>("FlashSales_CreateTime");
			            
            /// <summary>
            /// 是否删除 -  数据类型:bool
            /// </summary>
            public static Field FlashSales_IsDel = new Field<FlashSales>("FlashSales_IsDel");
						
		}
        #endregion
   
	}
}

