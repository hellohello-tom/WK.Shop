// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysLog Model
//  作    者：Tom.Team
//  添加时间：2014-07-21 14:59:43
// ==========================================================================
using System;
//引用
using MySoft.Data;
using System.ComponentModel.DataAnnotations;

namespace Shop.Model
{
	/// <summary>
	/// 表名：SysLog 主键列：Id 	 
///SysLog
	/// </summary>
	[SerializableAttribute()]
	public partial class SysLog : Entity,IModel
	{
   		#region 私有变量
   		private int _Id;
		private string _Title;
        private string _Level;
		private string _IP;
		private string _Referrer;
		private string _Content;
		private string _AddUser;
		private DateTime? _AddTime;
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
		/// 日志标题
        /// </summary>
		[StringLength(200,ErrorMessage="*")]		
        public string Title
        {
            get{ return _Title; }
            set
            { 
                OnPropertyValueChange(_.Title, _Title, value);
                _Title = value; 
            }
        } 
				
		/// <summary>
		/// Level
        /// </summary>
		[Required(ErrorMessage = "*")]		
        public string Level
        {
            get{ return _Level; }
            set
            { 
                OnPropertyValueChange(_.Level, _Level, value);
                _Level = value; 
            }
        } 
				
		/// <summary>
		/// 访问者IP
        /// </summary>
		[StringLength(30,ErrorMessage="*")]		
        public string IP
        {
            get{ return _IP; }
            set
            { 
                OnPropertyValueChange(_.IP, _IP, value);
                _IP = value; 
            }
        } 
				
		/// <summary>
		/// 请求页面
        /// </summary>
		[StringLength(200,ErrorMessage="*")]		
        public string Referrer
        {
            get{ return _Referrer; }
            set
            { 
                OnPropertyValueChange(_.Referrer, _Referrer, value);
                _Referrer = value; 
            }
        } 
				
		/// <summary>
		/// 日志内容
        /// </summary>		
        public string Content
        {
            get{ return _Content; }
            set
            { 
                OnPropertyValueChange(_.Content, _Content, value);
                _Content = value; 
            }
        } 
				
		/// <summary>
		/// 记录人
        /// </summary>
		[StringLength(20,ErrorMessage="*")]		
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
		/// 记录时间
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
				#endregion
		
		#region MySoft
		/// <summary>
        /// 获取实体对应的表名
        /// </summary>
        protected override Table GetTable()
        {
            return new Table<SysLog>("SysLog");
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
								_.Title,
								_.Level,
								_.IP,
								_.Referrer,
								_.Content,
								_.AddUser,
								_.AddTime};
        }

        /// <summary>
        /// 获取列数据
        /// </summary>
        protected override object[] GetValues()
        {
            return new object[] {
            					_Id,
								_Title,
								_Level,
								_IP,
								_Referrer,
								_Content,
								_AddUser,
								_AddTime};
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
						
			if ((false == reader.IsDBNull(_.Title)))
			{
				this._Title=reader.GetString(_.Title);
			}

            if ((false == reader.IsDBNull(_.Level)))
            {
                this._Level = reader.GetString(_.Level);
            }
						
			if ((false == reader.IsDBNull(_.IP)))
			{
				this._IP=reader.GetString(_.IP);
			}
						
			if ((false == reader.IsDBNull(_.Referrer)))
			{
				this._Referrer=reader.GetString(_.Referrer);
			}
						
			if ((false == reader.IsDBNull(_.Content)))
			{
                this._Content = reader.GetString(_.Content);
			}
						
			if ((false == reader.IsDBNull(_.AddUser)))
			{
				this._AddUser=reader.GetString(_.AddUser);
			}
						
			if ((false == reader.IsDBNull(_.AddTime)))
			{
				this._AddTime=reader.GetDateTime(_.AddTime);
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
            if ((false == typeof(SysLog).IsAssignableFrom(obj.GetType())))
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
            public static AllField All = new AllField<SysLog>();
                        
            /// <summary>
            /// Id -  数据类型:int
            /// </summary>
            public static Field Id = new Field<SysLog>("Id");
			            
            /// <summary>
            /// 日志标题 -  数据类型:string
            /// </summary>
            public static Field Title = new Field<SysLog>("Title");
			            
            /// <summary>
            /// 字段名:Level -  数据类型:string
            /// </summary>
            public static Field Level = new Field<SysLog>("Level");
			            
            /// <summary>
            /// 访问者IP -  数据类型:string
            /// </summary>
            public static Field IP = new Field<SysLog>("IP");
			            
            /// <summary>
            /// 请求页面 -  数据类型:string
            /// </summary>
            public static Field Referrer = new Field<SysLog>("Referrer");
			            
            /// <summary>
            /// 日志内容 -  数据类型:string
            /// </summary>
            public static Field Content = new Field<SysLog>("Content");
			            
            /// <summary>
            /// 记录人 -  数据类型:string
            /// </summary>
            public static Field AddUser = new Field<SysLog>("AddUser");
			            
            /// <summary>
            /// 记录时间 -  数据类型:DateTime
            /// </summary>
            public static Field AddTime = new Field<SysLog>("AddTime");
						
		}
        #endregion
   
	}
}

