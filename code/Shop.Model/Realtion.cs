// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：Realtion Model
//  作    者：cat
//  添加时间：2015-06-17 10:59:25
// ==========================================================================
using System;
//引用
using MySoft.Data;
using System.ComponentModel.DataAnnotations;

namespace Shop.Model{
	/// <summary>
	/// 表名：Realtion 主键列：Id 	 
///Realtion
	/// </summary>
	[SerializableAttribute()]
	public partial class Realtion : Entity,IModel
	{
   		#region 私有变量
   		private int _Id;
		private int _Realtion_CommodityId;
		private int _Realtion_SaleId;
		private bool _Realtion_IsTop;
		private DateTime? _Realtion_CreateTime;
		private int _Realtion_CreateUser;
		private bool _Realtion_IsDel;
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
		/// 商品ID
        /// </summary>
		[RegularExpression("-?\\d+", ErrorMessage = "*")]		
        public int Realtion_CommodityId
        {
            get{ return _Realtion_CommodityId; }
            set
            { 
                OnPropertyValueChange(_.Realtion_CommodityId, _Realtion_CommodityId, value);
                _Realtion_CommodityId = value; 
            }
        } 
				
		/// <summary>
		/// 闪购ID
        /// </summary>
		[RegularExpression("-?\\d+", ErrorMessage = "*")]		
        public int Realtion_SaleId
        {
            get{ return _Realtion_SaleId; }
            set
            { 
                OnPropertyValueChange(_.Realtion_SaleId, _Realtion_SaleId, value);
                _Realtion_SaleId = value; 
            }
        } 
				
		/// <summary>
		/// 是否置顶
        /// </summary>		
        public bool Realtion_IsTop
        {
            get{ return _Realtion_IsTop; }
            set
            { 
                OnPropertyValueChange(_.Realtion_IsTop, _Realtion_IsTop, value);
                _Realtion_IsTop = value; 
            }
        } 
				
		/// <summary>
		/// 创建时间
        /// </summary>
		[RegularExpression("^\\d{4}(\\-|\\/|\\.)\\d{1,2}\\1\\d{1,2}(\\s\\d{1,2}:\\d{1,2}:\\d{1,2})?$", ErrorMessage = "*")]		
        public DateTime? Realtion_CreateTime
        {
            get{ return _Realtion_CreateTime; }
            set
            { 
                OnPropertyValueChange(_.Realtion_CreateTime, _Realtion_CreateTime, value);
                _Realtion_CreateTime = value; 
            }
        } 
				
		/// <summary>
		/// 创建人
        /// </summary>
		[RegularExpression("-?\\d+", ErrorMessage = "*")]		
        public int Realtion_CreateUser
        {
            get{ return _Realtion_CreateUser; }
            set
            { 
                OnPropertyValueChange(_.Realtion_CreateUser, _Realtion_CreateUser, value);
                _Realtion_CreateUser = value; 
            }
        } 
				
		/// <summary>
		/// 是否删除
        /// </summary>		
        public bool Realtion_IsDel
        {
            get{ return _Realtion_IsDel; }
            set
            { 
                OnPropertyValueChange(_.Realtion_IsDel, _Realtion_IsDel, value);
                _Realtion_IsDel = value; 
            }
        } 
				#endregion
		
		#region MySoft
		/// <summary>
        /// 获取实体对应的表名
        /// </summary>
        protected override Table GetTable()
        {
            return new Table<Realtion>("Realtion");
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
								_.Realtion_CommodityId,
								_.Realtion_SaleId,
								_.Realtion_IsTop,
								_.Realtion_CreateTime,
								_.Realtion_CreateUser,
								_.Realtion_IsDel};
        }

        /// <summary>
        /// 获取列数据
        /// </summary>
        protected override object[] GetValues()
        {
            return new object[] {
            					_Id,
								_Realtion_CommodityId,
								_Realtion_SaleId,
								_Realtion_IsTop,
								_Realtion_CreateTime,
								_Realtion_CreateUser,
								_Realtion_IsDel};
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
						
			if ((false == reader.IsDBNull(_.Realtion_CommodityId)))
			{
				this._Realtion_CommodityId=reader.GetInt32(_.Realtion_CommodityId);
			}
						
			if ((false == reader.IsDBNull(_.Realtion_SaleId)))
			{
				this._Realtion_SaleId=reader.GetInt32(_.Realtion_SaleId);
			}
						
			if ((false == reader.IsDBNull(_.Realtion_CreateTime)))
			{
				this._Realtion_CreateTime=reader.GetDateTime(_.Realtion_CreateTime);
			}
						
			if ((false == reader.IsDBNull(_.Realtion_CreateUser)))
			{
				this._Realtion_CreateUser=reader.GetInt32(_.Realtion_CreateUser);
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
            if ((false == typeof(Realtion).IsAssignableFrom(obj.GetType())))
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
            public static AllField All = new AllField<Realtion>();
                        
            /// <summary>
            /// Id -  数据类型:int
            /// </summary>
            public static Field Id = new Field<Realtion>("Id");
			            
            /// <summary>
            /// 商品ID -  数据类型:int
            /// </summary>
            public static Field Realtion_CommodityId = new Field<Realtion>("Realtion_CommodityId");
			            
            /// <summary>
            /// 闪购ID -  数据类型:int
            /// </summary>
            public static Field Realtion_SaleId = new Field<Realtion>("Realtion_SaleId");
			            
            /// <summary>
            /// 是否置顶 -  数据类型:bool
            /// </summary>
            public static Field Realtion_IsTop = new Field<Realtion>("Realtion_IsTop");
			            
            /// <summary>
            /// 创建时间 -  数据类型:DateTime
            /// </summary>
            public static Field Realtion_CreateTime = new Field<Realtion>("Realtion_CreateTime");
			            
            /// <summary>
            /// 创建人 -  数据类型:int
            /// </summary>
            public static Field Realtion_CreateUser = new Field<Realtion>("Realtion_CreateUser");
			            
            /// <summary>
            /// 是否删除 -  数据类型:bool
            /// </summary>
            public static Field Realtion_IsDel = new Field<Realtion>("Realtion_IsDel");
						
		}
        #endregion
   
	}
}

