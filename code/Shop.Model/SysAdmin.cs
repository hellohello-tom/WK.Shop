// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysAdmin Model
//  作    者：ThinkWang
//  添加时间：2014-10-20 10:46:11
// ==========================================================================
using System;
//引用
using MySoft.Data;
using System.ComponentModel.DataAnnotations;

namespace Shop.Model{
	/// <summary>
	/// 表名：SysAdmin 主键列：Id 	 
///管理员表
	/// </summary>
	[SerializableAttribute()]
	public partial class SysAdmin : Entity,IModel
	{
   		#region 私有变量
   		private int _Id;
		private string _UserName;
		private string _PassWord;
		private string _RoleIds;
		private string _RealName;
		private string _LastLoginIP;
		private DateTime? _LastLoginTime;
		private int _LoginTimes;
		private int _Enabled;
		private DateTime? _AddTime;
		private string _AddUser;
		private DateTime? _UpdateTime;
		private string _UpdateUser;
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
		/// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空！")]
        [StringLength(20, ErrorMessage = "用户名长度不能超过20个字符！")]
        public string UserName
        {
            get{ return _UserName; }
            set
            { 
                OnPropertyValueChange(_.UserName, _UserName, value);
                _UserName = value; 
            }
        } 
				
		/// <summary>
		/// 用户密码
        /// </summary>
        [DataType(DataType.Password)]
        [StringLength(14, MinimumLength = 6, ErrorMessage = "密码长度为6至14位")]
        public string PassWord
        {
            get{ return _PassWord; }
            set
            { 
                OnPropertyValueChange(_.PassWord, _PassWord, value);
                _PassWord = value; 
            }
        } 
				
		/// <summary>
		/// 所属角色ID,逗号隔开
        /// </summary>
		[StringLength(50,ErrorMessage="*")]		
        public string RoleIds
        {
            get{ return _RoleIds; }
            set
            { 
                OnPropertyValueChange(_.RoleIds, _RoleIds, value);
                _RoleIds = value; 
            }
        } 
		/// <summary>
		/// 姓名
        /// </summary>
		[StringLength(50,ErrorMessage="*")]		
        public string RealName
        {
            get{ return _RealName; }
            set
            { 
                OnPropertyValueChange(_.RealName, _RealName, value);
                _RealName = value; 
            }
        } 
				
		/// <summary>
		/// 最后一次登录IP
        /// </summary>
		[StringLength(50,ErrorMessage="*")]		
        public string LastLoginIP
        {
            get{ return _LastLoginIP; }
            set
            { 
                OnPropertyValueChange(_.LastLoginIP, _LastLoginIP, value);
                _LastLoginIP = value; 
            }
        } 
				
		/// <summary>
		/// 最后一次登录时间
        /// </summary>
		[RegularExpression("^\\d{4}(\\-|\\/|\\.)\\d{1,2}\\1\\d{1,2}(\\s\\d{1,2}:\\d{1,2}:\\d{1,2})?$", ErrorMessage = "*")]		
        public DateTime? LastLoginTime
        {
            get{ return _LastLoginTime; }
            set
            { 
                OnPropertyValueChange(_.LastLoginTime, _LastLoginTime, value);
                _LastLoginTime = value; 
            }
        } 
				
		/// <summary>
		/// 登录次数
        /// </summary>
		[Required(ErrorMessage = "*")]
		[RegularExpression("-?\\d+", ErrorMessage = "*")]		
        public int LoginTimes
        {
            get{ return _LoginTimes; }
            set
            { 
                OnPropertyValueChange(_.LoginTimes, _LoginTimes, value);
                _LoginTimes = value; 
            }
        } 
				
		/// <summary>
		/// 是否启用
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
				
		/// <summary>
		/// 添加时间
        /// </summary>
		[Required(ErrorMessage = "*")]
		[RegularExpression("^\\d{4}(\\-|\\/|\\.)\\d{1,2}\\1\\d{1,2}(\\s\\d{1,2}:\\d{1,2}:\\d{1,2})?$", ErrorMessage = "*")]		
        public DateTime? AddTime
        {
            get{ return _AddTime; }
            set
            { 
                OnPropertyValueChange(_.AddTime, _AddTime, value);
                _AddTime = value; 
            }
        } 
				
		/// <summary>
		/// 添加人
        /// </summary>
		[StringLength(50,ErrorMessage="*")]		
        public string AddUser
        {
            get{ return _AddUser; }
            set
            { 
                OnPropertyValueChange(_.AddUser, _AddUser, value);
                _AddUser = value; 
            }
        } 
				
		/// <summary>
		/// 修改时间
        /// </summary>
		[RegularExpression("^\\d{4}(\\-|\\/|\\.)\\d{1,2}\\1\\d{1,2}(\\s\\d{1,2}:\\d{1,2}:\\d{1,2})?$", ErrorMessage = "*")]		
        public DateTime? UpdateTime
        {
            get{ return _UpdateTime; }
            set
            { 
                OnPropertyValueChange(_.UpdateTime, _UpdateTime, value);
                _UpdateTime = value; 
            }
        } 
				
		/// <summary>
		/// 修改人
        /// </summary>
		[StringLength(50,ErrorMessage="*")]		
        public string UpdateUser
        {
            get{ return _UpdateUser; }
            set
            { 
                OnPropertyValueChange(_.UpdateUser, _UpdateUser, value);
                _UpdateUser = value; 
            }
        } 
				#endregion
		
		#region MySoft
		/// <summary>
        /// 获取实体对应的表名
        /// </summary>
        protected override Table GetTable()
        {
            return new Table<SysAdmin>("SysAdmin");
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
								_.UserName,
								_.PassWord,
								_.RoleIds,
								_.RealName,
								_.LastLoginIP,
								_.LastLoginTime,
								_.LoginTimes,
								_.Enabled,
								_.AddTime,
								_.AddUser,
								_.UpdateTime,
								_.UpdateUser};
        }

        /// <summary>
        /// 获取列数据
        /// </summary>
        protected override object[] GetValues()
        {
            return new object[] {
            					_Id,
								_UserName,
								_PassWord,
								_RoleIds,
								_RealName,
								_LastLoginIP,
								_LastLoginTime,
								_LoginTimes,
								_Enabled,
								_AddTime,
								_AddUser,
								_UpdateTime,
								_UpdateUser};
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
						
			if ((false == reader.IsDBNull(_.UserName)))
			{
				this._UserName=reader.GetString(_.UserName);
			}
						
			if ((false == reader.IsDBNull(_.PassWord)))
			{
				this._PassWord=reader.GetString(_.PassWord);
			}
						
			if ((false == reader.IsDBNull(_.RoleIds)))
			{
				this._RoleIds=reader.GetString(_.RoleIds);
			}
						
			if ((false == reader.IsDBNull(_.RealName)))
			{
				this._RealName=reader.GetString(_.RealName);
			}
						
			if ((false == reader.IsDBNull(_.LastLoginIP)))
			{
				this._LastLoginIP=reader.GetString(_.LastLoginIP);
			}
						
			if ((false == reader.IsDBNull(_.LastLoginTime)))
			{
				this._LastLoginTime=reader.GetDateTime(_.LastLoginTime);
			}
						
			if ((false == reader.IsDBNull(_.LoginTimes)))
			{
				this._LoginTimes=reader.GetInt32(_.LoginTimes);
			}
						
			if ((false == reader.IsDBNull(_.Enabled)))
			{
				this._Enabled=reader.GetInt32(_.Enabled);
			}
						
			if ((false == reader.IsDBNull(_.AddTime)))
			{
				this._AddTime=reader.GetDateTime(_.AddTime);
			}
						
			if ((false == reader.IsDBNull(_.AddUser)))
			{
				this._AddUser=reader.GetString(_.AddUser);
			}
						
			if ((false == reader.IsDBNull(_.UpdateTime)))
			{
				this._UpdateTime=reader.GetDateTime(_.UpdateTime);
			}
						
			if ((false == reader.IsDBNull(_.UpdateUser)))
			{
				this._UpdateUser=reader.GetString(_.UpdateUser);
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
            if ((false == typeof(SysAdmin).IsAssignableFrom(obj.GetType())))
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
            public static AllField All = new AllField<SysAdmin>();
                        
            /// <summary>
            /// 自增编号 -  数据类型:int
            /// </summary>
            public static Field Id = new Field<SysAdmin>("Id");
			            
            /// <summary>
            /// 用户名 -  数据类型:string
            /// </summary>
            public static Field UserName = new Field<SysAdmin>("UserName");
			            
            /// <summary>
            /// 用户密码 -  数据类型:string
            /// </summary>
            public static Field PassWord = new Field<SysAdmin>("PassWord");
			            
            /// <summary>
            /// 所属角色ID,逗号隔开 -  数据类型:string
            /// </summary>
            public static Field RoleIds = new Field<SysAdmin>("RoleIds");
			            
            /// <summary>
            /// 姓名 -  数据类型:string
            /// </summary>
            public static Field RealName = new Field<SysAdmin>("RealName");
			            
            /// <summary>
            /// 最后一次登录IP -  数据类型:string
            /// </summary>
            public static Field LastLoginIP = new Field<SysAdmin>("LastLoginIP");
			            
            /// <summary>
            /// 最后一次登录时间 -  数据类型:DateTime
            /// </summary>
            public static Field LastLoginTime = new Field<SysAdmin>("LastLoginTime");
			            
            /// <summary>
            /// 登录次数 -  数据类型:int
            /// </summary>
            public static Field LoginTimes = new Field<SysAdmin>("LoginTimes");
			            
            /// <summary>
            /// 是否启用 -  数据类型:int
            /// </summary>
            public static Field Enabled = new Field<SysAdmin>("Enabled");
			            
            /// <summary>
            /// 添加时间 -  数据类型:DateTime
            /// </summary>
            public static Field AddTime = new Field<SysAdmin>("AddTime");
			            
            /// <summary>
            /// 添加人 -  数据类型:string
            /// </summary>
            public static Field AddUser = new Field<SysAdmin>("AddUser");
			            
            /// <summary>
            /// 修改时间 -  数据类型:DateTime
            /// </summary>
            public static Field UpdateTime = new Field<SysAdmin>("UpdateTime");
			            
            /// <summary>
            /// 修改人 -  数据类型:string
            /// </summary>
            public static Field UpdateUser = new Field<SysAdmin>("UpdateUser");
						
		}
        #endregion
   
	}
}

