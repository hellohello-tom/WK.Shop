// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysModule Model
//  作    者：ThinkWang
//  添加时间：2014-10-20 11:33:52
// ==========================================================================
using System;
//引用
using MySoft.Data;
using System.ComponentModel.DataAnnotations;

namespace Shop.Model
{
    /// <summary>
    /// 表名：SysModule 主键列：Id 	 
    ///菜单模块表
    /// </summary>
    [SerializableAttribute()]
    public partial class SysModule : Entity, IModel
    {
        #region 私有变量
        private int _Id;
        private string _Code;
        private string _Name;
        private string _Url;
        private string _Remark;
        private int _Enabled;
        private int _OrderNum;
        private int _ParentId;
        private string _Relation;
        private int _Level;
        private int _IsShow;
        #endregion

        #region 属性

        /// <summary>
        /// Id
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
        /// 编码
        /// </summary>
        [StringLength(50, ErrorMessage = "*")]
        public string Code
        {
            get { return _Code; }
            set
            {
                OnPropertyValueChange(_.Code, _Code, value);
                _Code = value;
            }
        }

        /// <summary>
        /// 名称
        /// </summary>
        [StringLength(50, ErrorMessage = "*")]
        public string Name
        {
            get { return _Name; }
            set
            {
                OnPropertyValueChange(_.Name, _Name, value);
                _Name = value;
            }
        }

        /// <summary>
        /// URL
        /// </summary>
        [StringLength(100, ErrorMessage = "*")]
        public string Url
        {
            get { return _Url; }
            set
            {
                OnPropertyValueChange(_.Url, _Url, value);
                _Url = value;
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(500, ErrorMessage = "*")]
        public string Remark
        {
            get { return _Remark; }
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
            get { return _Enabled; }
            set
            {
                OnPropertyValueChange(_.Enabled, _Enabled, value);
                _Enabled = value;
            }
        }

        /// <summary>
        /// 排序号
        /// </summary>
        [Required(ErrorMessage = "*")]
        [RegularExpression("-?\\d+", ErrorMessage = "*")]
        public int OrderNum
        {
            get { return _OrderNum; }
            set
            {
                OnPropertyValueChange(_.OrderNum, _OrderNum, value);
                _OrderNum = value;
            }
        }

        /// <summary>
        /// 父ID
        /// </summary>
        [Required(ErrorMessage = "*")]
        [RegularExpression("-?\\d+", ErrorMessage = "*")]
        public int ParentId
        {
            get { return _ParentId; }
            set
            {
                OnPropertyValueChange(_.ParentId, _ParentId, value);
                _ParentId = value;
            }
        }

        /// <summary>
        /// 关系路径
        /// </summary>
        [StringLength(100, ErrorMessage = "*")]
        public string Relation
        {
            get { return _Relation; }
            set
            {
                OnPropertyValueChange(_.Relation, _Relation, value);
                _Relation = value;
            }
        }

        /// <summary>
        /// 层级索引
        /// </summary>
        [Required(ErrorMessage = "*")]
        [RegularExpression("-?\\d+", ErrorMessage = "*")]
        public int Level
        {
            get { return _Level; }
            set
            {
                OnPropertyValueChange(_.Level, _Level, value);
                _Level = value;
            }
        }

        /// <summary>
        /// 是否在显示到菜单1是0否
        /// </summary>
        [Required(ErrorMessage = "*")]
        [RegularExpression("-?\\d+", ErrorMessage = "*")]
        public int IsShow
        {
            get { return _IsShow; }
            set
            {
                OnPropertyValueChange(_.IsShow, _IsShow, value);
                _IsShow = value;
            }
        }
        #endregion

        #region MySoft
        /// <summary>
        /// 获取实体对应的表名
        /// </summary>
        protected override Table GetTable()
        {
            return new Table<SysModule>("SysModule");
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
								_.Url,
								_.Remark,
								_.Enabled,
								_.OrderNum,
								_.ParentId,
								_.Relation,
								_.Level,
								_.IsShow};
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
								_Url,
								_Remark,
								_Enabled,
								_OrderNum,
								_ParentId,
								_Relation,
								_Level,
								_IsShow};
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

            if ((false == reader.IsDBNull(_.Code)))
            {
                this._Code = reader.GetString(_.Code);
            }

            if ((false == reader.IsDBNull(_.Name)))
            {
                this._Name = reader.GetString(_.Name);
            }

            if ((false == reader.IsDBNull(_.Url)))
            {
                this._Url = reader.GetString(_.Url);
            }

            if ((false == reader.IsDBNull(_.Remark)))
            {
                this._Remark = reader.GetString(_.Remark);
            }

            if ((false == reader.IsDBNull(_.Enabled)))
            {
                this._Enabled = reader.GetInt32(_.Enabled);
            }

            if ((false == reader.IsDBNull(_.OrderNum)))
            {
                this._OrderNum = reader.GetInt32(_.OrderNum);
            }

            if ((false == reader.IsDBNull(_.ParentId)))
            {
                this._ParentId = reader.GetInt32(_.ParentId);
            }

            if ((false == reader.IsDBNull(_.Relation)))
            {
                this._Relation = reader.GetString(_.Relation);
            }

            if ((false == reader.IsDBNull(_.Level)))
            {
                this._Level = reader.GetInt32(_.Level);
            }

            if ((false == reader.IsDBNull(_.IsShow)))
            {
                this._IsShow = reader.GetInt32(_.IsShow);
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
            if ((false == typeof(SysModule).IsAssignableFrom(obj.GetType())))
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
            public static AllField All = new AllField<SysModule>();

            /// <summary>
            /// Id -  数据类型:int
            /// </summary>
            public static Field Id = new Field<SysModule>("Id");

            /// <summary>
            /// 编码 -  数据类型:string
            /// </summary>
            public static Field Code = new Field<SysModule>("Code");

            /// <summary>
            /// 名称 -  数据类型:string
            /// </summary>
            public static Field Name = new Field<SysModule>("Name");

            /// <summary>
            /// URL -  数据类型:string
            /// </summary>
            public static Field Url = new Field<SysModule>("Url");

            /// <summary>
            /// 备注 -  数据类型:string
            /// </summary>
            public static Field Remark = new Field<SysModule>("Remark");

            /// <summary>
            /// 是否使用1启用0停用 -  数据类型:int
            /// </summary>
            public static Field Enabled = new Field<SysModule>("Enabled");

            /// <summary>
            /// 排序号 -  数据类型:int
            /// </summary>
            public static Field OrderNum = new Field<SysModule>("OrderNum");

            /// <summary>
            /// 父ID -  数据类型:int
            /// </summary>
            public static Field ParentId = new Field<SysModule>("ParentId");

            /// <summary>
            /// 关系路径 -  数据类型:string
            /// </summary>
            public static Field Relation = new Field<SysModule>("Relation");

            /// <summary>
            /// 层级索引 -  数据类型:int
            /// </summary>
            public static Field Level = new Field<SysModule>("Level");

            /// <summary>
            /// 是否在显示到菜单1是0否 -  数据类型:int
            /// </summary>
            public static Field IsShow = new Field<SysModule>("IsShow");

        }
        #endregion

    }
}

