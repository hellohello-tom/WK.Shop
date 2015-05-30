// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysOrgUser Model
//  作    者：ThinkWang
//  添加时间：2014-10-25 11:45:16
// ==========================================================================
using System;
//引用
using MySoft.Data;
using System.ComponentModel.DataAnnotations;

namespace Shop.Model{
	/// <summary>
	/// 表名：SysOrgUser 主键列：Id 	 
///组织机构用户关系表(SysOrgUser)
	/// </summary>
	[SerializableAttribute()]
	public partial class SysOrgUser : Entity,IModel
	{
   		#region 私有变量
   		private int _Id;
		private int _OrgId;
		private int _UserId;
		   		#endregion  
   		
   		#region 属性
      			
		/// <summary>
		/// 自增编号
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
		/// 组织机构Id
        /// </summary>
		[Required(ErrorMessage = "*")]
		[RegularExpression("-?\\d+", ErrorMessage = "*")]		
        public int OrgId
        {
            get{ return _OrgId; }
            set
            { 
                OnPropertyValueChange(_.OrgId, _OrgId, value);
                _OrgId = value; 
            }
        } 
				
		/// <summary>
		/// 用户Id
        /// </summary>
		[Required(ErrorMessage = "*")]
		[RegularExpression("-?\\d+", ErrorMessage = "*")]		
        public int UserId
        {
            get{ return _UserId; }
            set
            { 
                OnPropertyValueChange(_.UserId, _UserId, value);
                _UserId = value; 
            }
        } 
				#endregion
		
		#region MySoft
		/// <summary>
        /// 获取实体对应的表名
        /// </summary>
        protected override Table GetTable()
        {
            return new Table<SysOrgUser>("SysOrgUser");
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
								_.OrgId,
								_.UserId};
        }

        /// <summary>
        /// 获取列数据
        /// </summary>
        protected override object[] GetValues()
        {
            return new object[] {
            					_Id,
								_OrgId,
								_UserId};
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
						
			if ((false == reader.IsDBNull(_.OrgId)))
			{
				this._OrgId=reader.GetInt32(_.OrgId);
			}
						
			if ((false == reader.IsDBNull(_.UserId)))
			{
				this._UserId=reader.GetInt32(_.UserId);
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
            if ((false == typeof(SysOrgUser).IsAssignableFrom(obj.GetType())))
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
            public static AllField All = new AllField<SysOrgUser>();
                        
            /// <summary>
            /// 自增编号 -  数据类型:int
            /// </summary>
            public static Field Id = new Field<SysOrgUser>("Id");
			            
            /// <summary>
            /// 组织机构Id -  数据类型:int
            /// </summary>
            public static Field OrgId = new Field<SysOrgUser>("OrgId");
			            
            /// <summary>
            /// 用户Id -  数据类型:int
            /// </summary>
            public static Field UserId = new Field<SysOrgUser>("UserId");
						
		}
        #endregion
   
	}
}

