// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：Config Model
//  作    者：cat
//  添加时间：2015-06-08 17:34:34
// ==========================================================================
using System;
//引用
using MySoft.Data;
using System.ComponentModel.DataAnnotations;

namespace Shop.Model{
	/// <summary>
	/// 表名：Config 主键列：Id 	 
///Config
	/// </summary>
	[SerializableAttribute()]
	public partial class Config : Entity,IModel
	{
   		#region 私有变量
   		private int _Id;
		private string _Config_Name;
		private string _Config_Syle;
		private string _Config_Footer;
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
		/// 名称
        /// </summary>
		[StringLength(10,ErrorMessage="*")]		
        public string Config_Name
        {
            get{ return _Config_Name; }
            set
            { 
                OnPropertyValueChange(_.Config_Name, _Config_Name, value);
                _Config_Name = value; 
            }
        } 
				
		/// <summary>
		/// 样式
        /// </summary>
		[StringLength(10,ErrorMessage="*")]		
        public string Config_Syle
        {
            get{ return _Config_Syle; }
            set
            { 
                OnPropertyValueChange(_.Config_Syle, _Config_Syle, value);
                _Config_Syle = value; 
            }
        } 
				
		/// <summary>
		/// 底部样式
        /// </summary>		
        public string Config_Footer
        {
            get{ return _Config_Footer; }
            set
            { 
                OnPropertyValueChange(_.Config_Footer, _Config_Footer, value);
                _Config_Footer = value; 
            }
        } 
				#endregion
		
		#region MySoft
		/// <summary>
        /// 获取实体对应的表名
        /// </summary>
        protected override Table GetTable()
        {
            return new Table<Config>("Config");
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
								_.Config_Name,
								_.Config_Syle,
								_.Config_Footer};
        }

        /// <summary>
        /// 获取列数据
        /// </summary>
        protected override object[] GetValues()
        {
            return new object[] {
            					_Id,
								_Config_Name,
								_Config_Syle,
								_Config_Footer};
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
						
			if ((false == reader.IsDBNull(_.Config_Name)))
			{
				this._Config_Name=reader.GetString(_.Config_Name);
			}
						
			if ((false == reader.IsDBNull(_.Config_Syle)))
			{
				this._Config_Syle=reader.GetString(_.Config_Syle);
			}
						
			if ((false == reader.IsDBNull(_.Config_Footer)))
			{
				this._Config_Footer=reader.GetString(_.Config_Footer);
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
            if ((false == typeof(Config).IsAssignableFrom(obj.GetType())))
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
            public static AllField All = new AllField<Config>();
                        
            /// <summary>
            /// Id -  数据类型:int
            /// </summary>
            public static Field Id = new Field<Config>("Id");
			            
            /// <summary>
            /// 名称 -  数据类型:string
            /// </summary>
            public static Field Config_Name = new Field<Config>("Config_Name");
			            
            /// <summary>
            /// 样式 -  数据类型:string
            /// </summary>
            public static Field Config_Syle = new Field<Config>("Config_Syle");
			            
            /// <summary>
            /// 底部样式 -  数据类型:string
            /// </summary>
            public static Field Config_Footer = new Field<Config>("Config_Footer");
						
		}
        #endregion
   
	}
}

