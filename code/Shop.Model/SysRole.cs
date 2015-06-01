// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysRole Model
//  作    者：Tom.Team
//  添加时间：2014-03-25 16:54:28
// ==========================================================================
using System;
//引用
using MySoft.Data;
using System.ComponentModel.DataAnnotations;

namespace Shop.Model{
	/// <summary>
	/// 表名：SysRole 主键列：Id 	 
///SysRole
	/// </summary>
	[SerializableAttribute()]
	public partial class SysRole : Entity,IModel
	{
   		#region 私有变量
   		private int _Id;
		private string _Code;
		private string _Name;
		private string _ModuleIds;
		private string _Remark;
		private int _Enabled=-1;
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
		/// Code
        /// </summary>
        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "*")]
        public string Code
        {
            get{ return _Code; }
            set
            { 
                OnPropertyValueChange(_.Code, _Code, value);
                _Code = value; 
            }
        } 
				
		/// <summary>
		/// 角色名称
        /// </summary>	
        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "*")]
        public string Name
        {
            get{ return _Name; }
            set
            { 
                OnPropertyValueChange(_.Name, _Name, value);
                _Name = value; 
            }
        } 
				
		/// <summary>
		/// 菜单权限,用逗号隔开
        /// </summary>
        [StringLength(100,ErrorMessage="*")]
        public string ModuleIds
        {
            get{ return _ModuleIds; }
            set
            { 
                OnPropertyValueChange(_.ModuleIds, _ModuleIds, value);
                _ModuleIds = value; 
            }
        } 
				
		/// <summary>
		/// 备注
        /// </summary>	
        [StringLength(500, ErrorMessage = "*")]
        public string Remark
        {
            get{ return _Remark; }
            set
            { 
                OnPropertyValueChange(_.Remark, _Remark, value);
                _Remark = value; 
            }
        } 
				
		/// <summary>
		/// 是否使用1启用0停用
        /// </summary>
		[Required(ErrorMessage = "*")]
		[RegularExpression("-?\\d+", ErrorMessage = "*")]		
        public int Enabled
        {
            get{ return _Enabled; }
            set
            { 
                OnPropertyValueChange(_.Enabled, _Enabled, value);
                _Enabled = value; 
            }
        } 
				#endregion
		
		#region MySoft
		/// <summary>
        /// 获取实体对应的表名
        /// </summary>
        protected override Table GetTable()
        {
            return new Table<SysRole>("SysRole");
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
								_.Code,
								_.Name,
								_.ModuleIds,
								_.Remark,
								_.Enabled};
        }

        /// <summary>
        /// 获取列数据
        /// </summary>
        protected override object[] GetValues()
        {
            return new object[] {
            					_Id,
								_Code,
								_Name,
								_ModuleIds,
								_Remark,
								_Enabled};
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
						
			if ((false == reader.IsDBNull(_.Code)))
			{
				this._Code=reader.GetString(_.Code);
			}
						
			if ((false == reader.IsDBNull(_.Name)))
			{
				this._Name=reader.GetString(_.Name);
			}
						
			if ((false == reader.IsDBNull(_.ModuleIds)))
			{
				this._ModuleIds=reader.GetString(_.ModuleIds);
			}
						
			if ((false == reader.IsDBNull(_.Remark)))
			{
				this._Remark=reader.GetString(_.Remark);
			}
						
			if ((false == reader.IsDBNull(_.Enabled)))
			{
				this._Enabled=reader.GetInt32(_.Enabled);
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
            if ((false == typeof(SysRole).IsAssignableFrom(obj.GetType())))
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
            public static AllField All = new AllField<SysRole>();
                        
            /// <summary>
            /// Id -  数据类型:int
            /// </summary>
            public static Field Id = new Field<SysRole>("Id");
			            
            /// <summary>
            /// 字段名:Code -  数据类型:string
            /// </summary>
            public static Field Code = new Field<SysRole>("Code");
			            
            /// <summary>
            /// 角色名称 -  数据类型:string
            /// </summary>
            public static Field Name = new Field<SysRole>("Name");
			            
            /// <summary>
            /// 菜单权限,用逗号隔开 -  数据类型:string
            /// </summary>
            public static Field ModuleIds = new Field<SysRole>("ModuleIds");
			            
            /// <summary>
            /// 备注 -  数据类型:string
            /// </summary>
            public static Field Remark = new Field<SysRole>("Remark");
			            
            /// <summary>
            /// 是否使用1启用0停用 -  数据类型:int
            /// </summary>
            public static Field Enabled = new Field<SysRole>("Enabled");
						
		}
        #endregion
   
	}
}

