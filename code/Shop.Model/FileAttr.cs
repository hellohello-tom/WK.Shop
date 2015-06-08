// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：FileAttr Model
//  作    者：cat
//  添加时间：2015-06-08 17:34:36
// ==========================================================================
using System;
//引用
using MySoft.Data;
using System.ComponentModel.DataAnnotations;

namespace Shop.Model{
	/// <summary>
	/// 表名：FileAttr 主键列：Id 	 
///FileAttr
	/// </summary>
	[SerializableAttribute()]
	public partial class FileAttr : Entity,IModel
	{
   		#region 私有变量
   		private int _Id;
		private string _FileAttr_BussinessCode;
		private int _FileAttr_BussinessId;
		private string _FileAttr_Name;
		private string _FileAttr_Ext;
		private int _FileAttr_Size;
		private string _FileAttr_Path;
		private string _FileAttr_MD5;
		private string _FileAttr_CompressPath;
		private int _FileAttr_Sort;
		private int _FileAttr_User;
		private DateTime? _FileAttr_CreateTime;
		private bool _FileAttr_IsDel;
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
		/// 关联业务标示
        /// </summary>
		[StringLength(10,ErrorMessage="*")]		
        public string FileAttr_BussinessCode
        {
            get{ return _FileAttr_BussinessCode; }
            set
            { 
                OnPropertyValueChange(_.FileAttr_BussinessCode, _FileAttr_BussinessCode, value);
                _FileAttr_BussinessCode = value; 
            }
        } 
				
		/// <summary>
		/// 业务Id
        /// </summary>
		[RegularExpression("-?\\d+", ErrorMessage = "*")]		
        public int FileAttr_BussinessId
        {
            get{ return _FileAttr_BussinessId; }
            set
            { 
                OnPropertyValueChange(_.FileAttr_BussinessId, _FileAttr_BussinessId, value);
                _FileAttr_BussinessId = value; 
            }
        } 
				
		/// <summary>
		/// 文件名称
        /// </summary>
		[StringLength(100,ErrorMessage="*")]		
        public string FileAttr_Name
        {
            get{ return _FileAttr_Name; }
            set
            { 
                OnPropertyValueChange(_.FileAttr_Name, _FileAttr_Name, value);
                _FileAttr_Name = value; 
            }
        } 
				
		/// <summary>
		/// 后缀名
        /// </summary>
		[StringLength(10,ErrorMessage="*")]		
        public string FileAttr_Ext
        {
            get{ return _FileAttr_Ext; }
            set
            { 
                OnPropertyValueChange(_.FileAttr_Ext, _FileAttr_Ext, value);
                _FileAttr_Ext = value; 
            }
        } 
				
		/// <summary>
		/// 文件大小
        /// </summary>
		[RegularExpression("-?\\d+", ErrorMessage = "*")]		
        public int FileAttr_Size
        {
            get{ return _FileAttr_Size; }
            set
            { 
                OnPropertyValueChange(_.FileAttr_Size, _FileAttr_Size, value);
                _FileAttr_Size = value; 
            }
        } 
				
		/// <summary>
		/// 文件路径
        /// </summary>
		[StringLength(500,ErrorMessage="*")]		
        public string FileAttr_Path
        {
            get{ return _FileAttr_Path; }
            set
            { 
                OnPropertyValueChange(_.FileAttr_Path, _FileAttr_Path, value);
                _FileAttr_Path = value; 
            }
        } 
				
		/// <summary>
		/// 文件MD5
        /// </summary>
		[StringLength(50,ErrorMessage="*")]		
        public string FileAttr_MD5
        {
            get{ return _FileAttr_MD5; }
            set
            { 
                OnPropertyValueChange(_.FileAttr_MD5, _FileAttr_MD5, value);
                _FileAttr_MD5 = value; 
            }
        } 
				
		/// <summary>
		/// 压缩路径
        /// </summary>
		[StringLength(500,ErrorMessage="*")]		
        public string FileAttr_CompressPath
        {
            get{ return _FileAttr_CompressPath; }
            set
            { 
                OnPropertyValueChange(_.FileAttr_CompressPath, _FileAttr_CompressPath, value);
                _FileAttr_CompressPath = value; 
            }
        } 
				
		/// <summary>
		/// 排序
        /// </summary>
		[RegularExpression("-?\\d+", ErrorMessage = "*")]		
        public int FileAttr_Sort
        {
            get{ return _FileAttr_Sort; }
            set
            { 
                OnPropertyValueChange(_.FileAttr_Sort, _FileAttr_Sort, value);
                _FileAttr_Sort = value; 
            }
        } 
				
		/// <summary>
		/// 创建人
        /// </summary>
		[RegularExpression("-?\\d+", ErrorMessage = "*")]		
        public int FileAttr_User
        {
            get{ return _FileAttr_User; }
            set
            { 
                OnPropertyValueChange(_.FileAttr_User, _FileAttr_User, value);
                _FileAttr_User = value; 
            }
        } 
				
		/// <summary>
		/// 创建时间
        /// </summary>
		[RegularExpression("^\\d{4}(\\-|\\/|\\.)\\d{1,2}\\1\\d{1,2}(\\s\\d{1,2}:\\d{1,2}:\\d{1,2})?$", ErrorMessage = "*")]		
        public DateTime? FileAttr_CreateTime
        {
            get{ return _FileAttr_CreateTime; }
            set
            { 
                OnPropertyValueChange(_.FileAttr_CreateTime, _FileAttr_CreateTime, value);
                _FileAttr_CreateTime = value; 
            }
        } 
				
		/// <summary>
		/// 是否删除
        /// </summary>		
        public bool FileAttr_IsDel
        {
            get{ return _FileAttr_IsDel; }
            set
            { 
                OnPropertyValueChange(_.FileAttr_IsDel, _FileAttr_IsDel, value);
                _FileAttr_IsDel = value; 
            }
        } 
				#endregion
		
		#region MySoft
		/// <summary>
        /// 获取实体对应的表名
        /// </summary>
        protected override Table GetTable()
        {
            return new Table<FileAttr>("FileAttr");
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
								_.FileAttr_BussinessCode,
								_.FileAttr_BussinessId,
								_.FileAttr_Name,
								_.FileAttr_Ext,
								_.FileAttr_Size,
								_.FileAttr_Path,
								_.FileAttr_MD5,
								_.FileAttr_CompressPath,
								_.FileAttr_Sort,
								_.FileAttr_User,
								_.FileAttr_CreateTime,
								_.FileAttr_IsDel};
        }

        /// <summary>
        /// 获取列数据
        /// </summary>
        protected override object[] GetValues()
        {
            return new object[] {
            					_Id,
								_FileAttr_BussinessCode,
								_FileAttr_BussinessId,
								_FileAttr_Name,
								_FileAttr_Ext,
								_FileAttr_Size,
								_FileAttr_Path,
								_FileAttr_MD5,
								_FileAttr_CompressPath,
								_FileAttr_Sort,
								_FileAttr_User,
								_FileAttr_CreateTime,
								_FileAttr_IsDel};
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
						
			if ((false == reader.IsDBNull(_.FileAttr_BussinessCode)))
			{
				this._FileAttr_BussinessCode=reader.GetString(_.FileAttr_BussinessCode);
			}
						
			if ((false == reader.IsDBNull(_.FileAttr_BussinessId)))
			{
				this._FileAttr_BussinessId=reader.GetInt32(_.FileAttr_BussinessId);
			}
						
			if ((false == reader.IsDBNull(_.FileAttr_Name)))
			{
				this._FileAttr_Name=reader.GetString(_.FileAttr_Name);
			}
						
			if ((false == reader.IsDBNull(_.FileAttr_Ext)))
			{
				this._FileAttr_Ext=reader.GetString(_.FileAttr_Ext);
			}
						
			if ((false == reader.IsDBNull(_.FileAttr_Size)))
			{
				this._FileAttr_Size=reader.GetInt32(_.FileAttr_Size);
			}
						
			if ((false == reader.IsDBNull(_.FileAttr_Path)))
			{
				this._FileAttr_Path=reader.GetString(_.FileAttr_Path);
			}
						
			if ((false == reader.IsDBNull(_.FileAttr_MD5)))
			{
				this._FileAttr_MD5=reader.GetString(_.FileAttr_MD5);
			}
						
			if ((false == reader.IsDBNull(_.FileAttr_CompressPath)))
			{
				this._FileAttr_CompressPath=reader.GetString(_.FileAttr_CompressPath);
			}
						
			if ((false == reader.IsDBNull(_.FileAttr_Sort)))
			{
				this._FileAttr_Sort=reader.GetInt32(_.FileAttr_Sort);
			}
						
			if ((false == reader.IsDBNull(_.FileAttr_User)))
			{
				this._FileAttr_User=reader.GetInt32(_.FileAttr_User);
			}
						
			if ((false == reader.IsDBNull(_.FileAttr_CreateTime)))
			{
				this._FileAttr_CreateTime=reader.GetDateTime(_.FileAttr_CreateTime);
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
            if ((false == typeof(FileAttr).IsAssignableFrom(obj.GetType())))
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
            public static AllField All = new AllField<FileAttr>();
                        
            /// <summary>
            /// 字段名:Id -  数据类型:int
            /// </summary>
            public static Field Id = new Field<FileAttr>("Id");
			            
            /// <summary>
            /// 关联业务标示 -  数据类型:string
            /// </summary>
            public static Field FileAttr_BussinessCode = new Field<FileAttr>("FileAttr_BussinessCode");
			            
            /// <summary>
            /// 业务Id -  数据类型:int
            /// </summary>
            public static Field FileAttr_BussinessId = new Field<FileAttr>("FileAttr_BussinessId");
			            
            /// <summary>
            /// 文件名称 -  数据类型:string
            /// </summary>
            public static Field FileAttr_Name = new Field<FileAttr>("FileAttr_Name");
			            
            /// <summary>
            /// 后缀名 -  数据类型:string
            /// </summary>
            public static Field FileAttr_Ext = new Field<FileAttr>("FileAttr_Ext");
			            
            /// <summary>
            /// 文件大小 -  数据类型:int
            /// </summary>
            public static Field FileAttr_Size = new Field<FileAttr>("FileAttr_Size");
			            
            /// <summary>
            /// 文件路径 -  数据类型:string
            /// </summary>
            public static Field FileAttr_Path = new Field<FileAttr>("FileAttr_Path");
			            
            /// <summary>
            /// 文件MD5 -  数据类型:string
            /// </summary>
            public static Field FileAttr_MD5 = new Field<FileAttr>("FileAttr_MD5");
			            
            /// <summary>
            /// 压缩路径 -  数据类型:string
            /// </summary>
            public static Field FileAttr_CompressPath = new Field<FileAttr>("FileAttr_CompressPath");
			            
            /// <summary>
            /// 排序 -  数据类型:int
            /// </summary>
            public static Field FileAttr_Sort = new Field<FileAttr>("FileAttr_Sort");
			            
            /// <summary>
            /// 创建人 -  数据类型:int
            /// </summary>
            public static Field FileAttr_User = new Field<FileAttr>("FileAttr_User");
			            
            /// <summary>
            /// 创建时间 -  数据类型:DateTime
            /// </summary>
            public static Field FileAttr_CreateTime = new Field<FileAttr>("FileAttr_CreateTime");
			            
            /// <summary>
            /// 是否删除 -  数据类型:bool
            /// </summary>
            public static Field FileAttr_IsDel = new Field<FileAttr>("FileAttr_IsDel");
						
		}
        #endregion
   
	}
}

