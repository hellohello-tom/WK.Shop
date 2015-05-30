// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysSiteConfig Model
//  作    者：ThinkWang
//  添加时间：2014-04-11 16:21:01
// ==========================================================================
using System;
//引用
using MySoft.Data;
using System.ComponentModel.DataAnnotations;

namespace Shop.Model
{
    /// <summary>
    /// 表名：SysSiteConfig 主键列：Id 	 
    /// </summary>
    [SerializableAttribute()]
    public partial class SysSiteConfig : Entity, IModel
    {
        #region 私有变量
        private int _Id;
        private string _WebName;
        private string _WebCrod;
        private string _WebCopy;
        private string _WebTel;
        private string _WebAddr;
        private string _WebShare;
        private string _AttachPath;
        private string _AttachExtension;
        private int _AttachSize;
        private string _AttachImgExtension;
        private int _AttachImgSize;
        private int _AttachImgWidth;
        private int _AttachImgHeight;
        private int _ThumbnailWidth;
        private int _ThumbnailHeight;
        private string _WatermarkPicPath;
        private string _WebTitle;
        private string _WebKeyword;
        private string _WebDescription;
        private string _WebCountCode;
        private string _SensitiveWord;
        #endregion

        #region 属性

        /// <summary>
        /// ID
        /// </summary>		
        public int Id
        {
            get { return _Id; }
            set
            {
                OnPropertyValueChange(_.Id, _Id, value);
                _Id = value;
            }
        }

        
        /// <summary>
        /// 网站名称
        /// </summary>
        /// 
        [Required(ErrorMessage="必填项")]
        [StringLength(100, ErrorMessage = "长度不能大于100")]
        public string WebName
        {
            get { return _WebName; }
            set
            {
                OnPropertyValueChange(_.WebName, _WebName, value);
                _WebName = value;
            }
        }

        /// <summary>
        /// 网站备案号
        /// </summary>
        [StringLength(100, ErrorMessage = "长度不能大于100")]
        public string WebCrod
        {
            get { return _WebCrod; }
            set
            {
                OnPropertyValueChange(_.WebCrod, _WebCrod, value);
                _WebCrod = value;
            }
        }

        /// <summary>
        /// 网站版权
        /// </summary>
        [StringLength(1000, ErrorMessage = "长度不能大于1000")]
        public string WebCopy
        {
            get { return _WebCopy; }
            set
            {
                OnPropertyValueChange(_.WebCopy, _WebCopy, value);
                _WebCopy = value;
            }
        }

        /// <summary>
        /// 联系电话
        /// </summary>
        [StringLength(100, ErrorMessage = "长度不能大于100")]
        public string WebTel
        {
            get { return _WebTel; }
            set
            {
                OnPropertyValueChange(_.WebTel, _WebTel, value);
                _WebTel = value;
            }
        }

        /// <summary>
        /// 联系地址
        /// </summary>
        [StringLength(100, ErrorMessage = "长度不能大于100")]
        public string WebAddr
        {
            get { return _WebAddr; }
            set
            {
                OnPropertyValueChange(_.WebAddr, _WebAddr, value);
                _WebAddr = value;
            }
        }

        /// <summary>
        /// WebShare
        /// </summary>
        [StringLength(2000, ErrorMessage = "长度不能大于2000")]
        public string WebShare
        {
            get { return _WebShare; }
            set
            {
                OnPropertyValueChange(_.WebShare, _WebShare, value);
                _WebShare = value;
            }
        }

        /// <summary>
        /// 附件目录前后都要带'/'
        /// </summary>
        /// 
        [Required(ErrorMessage="必填项")]
        [StringLength(100, ErrorMessage = "长度不能大于100")]
        public string AttachPath
        {
            get { return _AttachPath; }
            set
            {
                OnPropertyValueChange(_.AttachPath, _AttachPath, value);
                _AttachPath = value;
            }
        }

        /// <summary>
        /// 上传类型,分号隔开
        /// </summary>
        [StringLength(200, ErrorMessage = "长度不能大于200")]
        public string AttachExtension
        {
            get { return _AttachExtension; }
            set
            {
                OnPropertyValueChange(_.AttachExtension, _AttachExtension, value);
                _AttachExtension = value;
            }
        }

        /// <summary>
        /// 文件大小(KB)
        /// </summary>

        [RegularExpression("-?\\d+", ErrorMessage = "格式输入不正确")]
        public int AttachSize
        {
            get { return _AttachSize; }
            set
            {
                OnPropertyValueChange(_.AttachSize, _AttachSize, value);
                _AttachSize = value;
            }
        }

        /// <summary>
        /// 允许上传的图片格式，多个用分号隔开
        /// </summary>
        [StringLength(200, ErrorMessage = "长度不能大于200")]
        public string AttachImgExtension
        {
            get { return _AttachImgExtension; }
            set
            {
                OnPropertyValueChange(_.AttachImgExtension, _AttachImgExtension, value);
                _AttachImgExtension = value;
            }
        }

        /// <summary>
        /// 图片大小(KB)
        /// </summary>
        [RegularExpression("-?\\d+", ErrorMessage = "格式输入不正确")]
        public int AttachImgSize
        {
            get { return _AttachImgSize; }
            set
            {
                OnPropertyValueChange(_.AttachImgSize, _AttachImgSize, value);
                _AttachImgSize = value;
            }
        }

        /// <summary>
        /// 图片宽度
        /// </summary>
        [RegularExpression("-?\\d+", ErrorMessage = "格式输入不正确")]
        public int AttachImgWidth
        {
            get { return _AttachImgWidth; }
            set
            {
                OnPropertyValueChange(_.AttachImgWidth, _AttachImgWidth, value);
                _AttachImgWidth = value;
            }
        }

        /// <summary>
        /// 图片高度
        /// </summary>
        [RegularExpression("-?\\d+", ErrorMessage = "格式输入不正确")]
        public int AttachImgHeight
        {
            get { return _AttachImgHeight; }
            set
            {
                OnPropertyValueChange(_.AttachImgHeight, _AttachImgHeight, value);
                _AttachImgHeight = value;
            }
        }

        /// <summary>
        /// 缩略图宽度
        /// </summary>
        [RegularExpression("-?\\d+", ErrorMessage = "格式输入不正确")]
        public int ThumbnailWidth
        {
            get { return _ThumbnailWidth; }
            set
            {
                OnPropertyValueChange(_.ThumbnailWidth, _ThumbnailWidth, value);
                _ThumbnailWidth = value;
            }
        }

        /// <summary>
        /// 缩略图高度
        /// </summary>
        [RegularExpression("-?\\d+", ErrorMessage = "格式输入不正确")]
        public int ThumbnailHeight
        {
            get { return _ThumbnailHeight; }
            set
            {
                OnPropertyValueChange(_.ThumbnailHeight, _ThumbnailHeight, value);
                _ThumbnailHeight = value;
            }
        }

        /// <summary>
        /// 水印图片路径
        /// </summary>
        [StringLength(200, ErrorMessage = "长度不能大于200")]
        public string WatermarkPicPath
        {
            get { return _WatermarkPicPath; }
            set
            {
                OnPropertyValueChange(_.WatermarkPicPath, _WatermarkPicPath, value);
                _WatermarkPicPath = value;
            }
        }

        /// <summary>
        /// 首页标题SEO
        /// </summary>
        [StringLength(200, ErrorMessage = "长度不能大于200")]
        public string WebTitle
        {
            get { return _WebTitle; }
            set
            {
                OnPropertyValueChange(_.WebTitle, _WebTitle, value);
                _WebTitle = value;
            }
        }

        /// <summary>
        /// 关键字SEO
        /// </summary>
        [StringLength(200, ErrorMessage = "长度不能大于200")]
        public string WebKeyword
        {
            get { return _WebKeyword; }
            set
            {
                OnPropertyValueChange(_.WebKeyword, _WebKeyword, value);
                _WebKeyword = value;
            }
        }

        /// <summary>
        /// 页面描述SEO
        /// </summary>
        [StringLength(500, ErrorMessage = "长度不能大于500")]
        public string WebDescription
        {
            get { return _WebDescription; }
            set
            {
                OnPropertyValueChange(_.WebDescription, _WebDescription, value);
                _WebDescription = value;
            }
        }

        /// <summary>
        /// 网站统计
        /// </summary>
        [StringLength(2000, ErrorMessage = "长度不能大于2000")]
        public string WebCountCode
        {
            get { return _WebCountCode; }
            set
            {
                OnPropertyValueChange(_.WebCountCode, _WebCountCode, value);
                _WebCountCode = value;
            }
        }


        /// <summary>
        /// 敏感字，分号隔开
        /// </summary>
        [StringLength(500, ErrorMessage = "长度不能大于500")]
        public string SensitiveWord
        {
            get { return _SensitiveWord; }
            set
            {
                OnPropertyValueChange(_.SensitiveWord, _SensitiveWord, value);
                _SensitiveWord = value;
            }
        }
        #endregion

        #region MySoft
        /// <summary>
        /// 获取实体对应的表名
        /// </summary>
        protected override Table GetTable()
        {
            return new Table<SysSiteConfig>("SysSiteConfig");
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
								_.WebName,
								_.WebCrod,
								_.WebCopy,
								_.WebTel,
								_.WebAddr,
								_.WebShare,
								_.AttachPath,
								_.AttachExtension,
								_.AttachSize,
								_.AttachImgExtension,
								_.AttachImgSize,
								_.AttachImgWidth,
								_.AttachImgHeight,
								_.ThumbnailWidth,
								_.ThumbnailHeight,
								_.WatermarkPicPath,
								_.WebTitle,
								_.WebKeyword,
								_.WebDescription,
								_.WebCountCode,
								_.SensitiveWord};
        }

        /// <summary>
        /// 获取列数据
        /// </summary>
        protected override object[] GetValues()
        {
            return new object[] {
            					_Id,
								_WebName,
								_WebCrod,
								_WebCopy,
								_WebTel,
								_WebAddr,
								_WebShare,
								_AttachPath,
								_AttachExtension,
								_AttachSize,
								_AttachImgExtension,
								_AttachImgSize,
								_AttachImgWidth,
								_AttachImgHeight,
								_ThumbnailWidth,
								_ThumbnailHeight,
								_WatermarkPicPath,
								_WebTitle,
								_WebKeyword,
								_WebDescription,
								_WebCountCode,
								_SensitiveWord};
        }

        /// <summary>
        /// 给当前实体赋值
        /// </summary>
        protected override void SetValues(IRowReader reader)
        {

            if ((false == reader.IsDBNull(_.Id)))
            {
                this._Id = reader.GetInt32(_.Id);
            }

            if ((false == reader.IsDBNull(_.WebName)))
            {
                this._WebName = reader.GetString(_.WebName);
            }

            if ((false == reader.IsDBNull(_.WebCrod)))
            {
                this._WebCrod = reader.GetString(_.WebCrod);
            }

            if ((false == reader.IsDBNull(_.WebCopy)))
            {
                this._WebCopy = reader.GetString(_.WebCopy);
            }

            if ((false == reader.IsDBNull(_.WebTel)))
            {
                this._WebTel = reader.GetString(_.WebTel);
            }

            if ((false == reader.IsDBNull(_.WebAddr)))
            {
                this._WebAddr = reader.GetString(_.WebAddr);
            }

            if ((false == reader.IsDBNull(_.WebShare)))
            {
                this._WebShare = reader.GetString(_.WebShare);
            }

            if ((false == reader.IsDBNull(_.AttachPath)))
            {
                this._AttachPath = reader.GetString(_.AttachPath);
            }

            if ((false == reader.IsDBNull(_.AttachExtension)))
            {
                this._AttachExtension = reader.GetString(_.AttachExtension);
            }

            if ((false == reader.IsDBNull(_.AttachSize)))
            {
                this._AttachSize = reader.GetInt32(_.AttachSize);
            }

            if ((false == reader.IsDBNull(_.AttachImgExtension)))
            {
                this._AttachImgExtension = reader.GetString(_.AttachImgExtension);
            }

            if ((false == reader.IsDBNull(_.AttachImgSize)))
            {
                this._AttachImgSize = reader.GetInt32(_.AttachImgSize);
            }

            if ((false == reader.IsDBNull(_.AttachImgWidth)))
            {
                this._AttachImgWidth = reader.GetInt32(_.AttachImgWidth);
            }

            if ((false == reader.IsDBNull(_.AttachImgHeight)))
            {
                this._AttachImgHeight = reader.GetInt32(_.AttachImgHeight);
            }

            if ((false == reader.IsDBNull(_.ThumbnailWidth)))
            {
                this._ThumbnailWidth = reader.GetInt32(_.ThumbnailWidth);
            }

            if ((false == reader.IsDBNull(_.ThumbnailHeight)))
            {
                this._ThumbnailHeight = reader.GetInt32(_.ThumbnailHeight);
            }

            if ((false == reader.IsDBNull(_.WatermarkPicPath)))
            {
                this._WatermarkPicPath = reader.GetString(_.WatermarkPicPath);
            }

            if ((false == reader.IsDBNull(_.WebTitle)))
            {
                this._WebTitle = reader.GetString(_.WebTitle);
            }

            if ((false == reader.IsDBNull(_.WebKeyword)))
            {
                this._WebKeyword = reader.GetString(_.WebKeyword);
            }

            if ((false == reader.IsDBNull(_.WebDescription)))
            {
                this._WebDescription = reader.GetString(_.WebDescription);
            }

            if ((false == reader.IsDBNull(_.WebCountCode)))
            {
                this._WebCountCode = reader.GetString(_.WebCountCode);
            }


            if ((false == reader.IsDBNull(_.SensitiveWord)))
            {
                this._SensitiveWord = reader.GetString(_.SensitiveWord);
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
            if ((false == typeof(SysSiteConfig).IsAssignableFrom(obj.GetType())))
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
            public static AllField All = new AllField<SysSiteConfig>();

            /// <summary>
            /// ID -  数据类型:int
            /// </summary>
            public static Field Id = new Field<SysSiteConfig>("Id");

            /// <summary>
            /// 网站名称 -  数据类型:string
            /// </summary>
            public static Field WebName = new Field<SysSiteConfig>("WebName");

            /// <summary>
            /// 网站备案号 -  数据类型:string
            /// </summary>
            public static Field WebCrod = new Field<SysSiteConfig>("WebCrod");

            /// <summary>
            /// 网站版权 -  数据类型:string
            /// </summary>
            public static Field WebCopy = new Field<SysSiteConfig>("WebCopy");

            /// <summary>
            /// 联系电话 -  数据类型:string
            /// </summary>
            public static Field WebTel = new Field<SysSiteConfig>("WebTel");

            /// <summary>
            /// 联系地址 -  数据类型:string
            /// </summary>
            public static Field WebAddr = new Field<SysSiteConfig>("WebAddr");

            /// <summary>
            /// 字段名:WebShare -  数据类型:string
            /// </summary>
            public static Field WebShare = new Field<SysSiteConfig>("WebShare");

            /// <summary>
            /// 附件目录前后都要带'/' -  数据类型:string
            /// </summary>
            public static Field AttachPath = new Field<SysSiteConfig>("AttachPath");

            /// <summary>
            /// 上传类型,分号隔开 -  数据类型:string
            /// </summary>
            public static Field AttachExtension = new Field<SysSiteConfig>("AttachExtension");

            /// <summary>
            /// 文件大小(KB) -  数据类型:int
            /// </summary>
            public static Field AttachSize = new Field<SysSiteConfig>("AttachSize");

            /// <summary>
            /// 允许上传的图片格式，多个用分号隔开 -  数据类型:string
            /// </summary>
            public static Field AttachImgExtension = new Field<SysSiteConfig>("AttachImgExtension");

            /// <summary>
            /// 图片大小(KB) -  数据类型:int
            /// </summary>
            public static Field AttachImgSize = new Field<SysSiteConfig>("AttachImgSize");

            /// <summary>
            /// 图片宽度 -  数据类型:int
            /// </summary>
            public static Field AttachImgWidth = new Field<SysSiteConfig>("AttachImgWidth");

            /// <summary>
            /// 图片高度 -  数据类型:int
            /// </summary>
            public static Field AttachImgHeight = new Field<SysSiteConfig>("AttachImgHeight");

            /// <summary>
            /// 缩略图宽度 -  数据类型:int
            /// </summary>
            public static Field ThumbnailWidth = new Field<SysSiteConfig>("ThumbnailWidth");

            /// <summary>
            /// 缩略图高度 -  数据类型:int
            /// </summary>
            public static Field ThumbnailHeight = new Field<SysSiteConfig>("ThumbnailHeight");

            /// <summary>
            /// 水印图片路径 -  数据类型:string
            /// </summary>
            public static Field WatermarkPicPath = new Field<SysSiteConfig>("WatermarkPicPath");

            /// <summary>
            /// 首页标题SEO -  数据类型:string
            /// </summary>
            public static Field WebTitle = new Field<SysSiteConfig>("WebTitle");

            /// <summary>
            /// 关键字SEO -  数据类型:string
            /// </summary>
            public static Field WebKeyword = new Field<SysSiteConfig>("WebKeyword");

            /// <summary>
            /// 页面描述SEO -  数据类型:string
            /// </summary>
            public static Field WebDescription = new Field<SysSiteConfig>("WebDescription");

            /// <summary>
            /// 网站统计 -  数据类型:string
            /// </summary>
            public static Field WebCountCode = new Field<SysSiteConfig>("WebCountCode");

            /// <summary>
            /// 敏感字，分号隔开 -  数据类型:string
            /// </summary>
            public static Field SensitiveWord = new Field<SysSiteConfig>("SensitiveWord");

        }
        #endregion

    }
}

