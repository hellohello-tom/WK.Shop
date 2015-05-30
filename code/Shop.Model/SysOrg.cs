// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysOrg Model
//  作    者：ThinkWang
//  添加时间：2014-11-20 10:46:49
// ==========================================================================
using System;
//引用
using MySoft.Data;
using System.ComponentModel.DataAnnotations;

namespace Shop.Model
{
    /// <summary>
    /// 表名：SysOrg 主键列：Id 	 
    ///组织机构(SysOrg)
    /// </summary>
    [SerializableAttribute()]
    public partial class SysOrg : Entity, IModel
    {
        #region 私有变量
        private int _Id;
        private int _ParentId;
        private string _Name;
        private int _IsManager;
        private int _Level;
        private int _OrderNum;
        private string _Remark;
        private int _Enabled;
        private string _Relation;
        #endregion

        #region 属性

        /// <summary>
        /// 自增编号
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
        /// 父id
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
        /// 名称
        /// </summary>
        [StringLength(100, ErrorMessage = "*")]
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
        /// 是否为主管单位，是1，否0
        /// </summary>
        [RegularExpression("-?\\d+", ErrorMessage = "*")]
        public int IsManager
        {
            get { return _IsManager; }
            set
            {
                OnPropertyValueChange(_.IsManager, _IsManager, value);
                _IsManager = value;
            }
        }

        /// <summary>
        /// 层级
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
        /// 是否使用1使用0停用
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
        /// Relation
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
        #endregion

        #region MySoft
        /// <summary>
        /// 获取实体对应的表名
        /// </summary>
        protected override Table GetTable()
        {
            return new Table<SysOrg>("SysOrg");
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
								_.ParentId,
								_.Name,
								_.IsManager,
								_.Level,
								_.OrderNum,
								_.Remark,
								_.Enabled,
								_.Relation};
        }

        /// <summary>
        /// 获取列数据
        /// </summary>
        protected override object[] GetValues()
        {
            return new object[] {
            					_Id,
								_ParentId,
								_Name,
								_IsManager,
								_Level,
								_OrderNum,
								_Remark,
								_Enabled,
								_Relation};
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

            if ((false == reader.IsDBNull(_.ParentId)))
            {
                this._ParentId = reader.GetInt32(_.ParentId);
            }

            if ((false == reader.IsDBNull(_.Name)))
            {
                this._Name = reader.GetString(_.Name);
            }

            if ((false == reader.IsDBNull(_.IsManager)))
            {
                this._IsManager = reader.GetInt32(_.IsManager);
            }

            if ((false == reader.IsDBNull(_.Level)))
            {
                this._Level = reader.GetInt32(_.Level);
            }

            if ((false == reader.IsDBNull(_.OrderNum)))
            {
                this._OrderNum = reader.GetInt32(_.OrderNum);
            }

            if ((false == reader.IsDBNull(_.Remark)))
            {
                this._Remark = reader.GetString(_.Remark);
            }

            if ((false == reader.IsDBNull(_.Enabled)))
            {
                this._Enabled = reader.GetInt32(_.Enabled);
            }

            if ((false == reader.IsDBNull(_.Relation)))
            {
                this._Relation = reader.GetString(_.Relation);
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
            if ((false == typeof(SysOrg).IsAssignableFrom(obj.GetType())))
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
            public static AllField All = new AllField<SysOrg>();

            /// <summary>
            /// 自增编号 -  数据类型:int
            /// </summary>
            public static Field Id = new Field<SysOrg>("Id");

            /// <summary>
            /// 父id -  数据类型:int
            /// </summary>
            public static Field ParentId = new Field<SysOrg>("ParentId");

            /// <summary>
            /// 名称 -  数据类型:string
            /// </summary>
            public static Field Name = new Field<SysOrg>("Name");

            /// <summary>
            /// 是否为主管单位，是1，否0 -  数据类型:int
            /// </summary>
            public static Field IsManager = new Field<SysOrg>("IsManager");

            /// <summary>
            /// 层级 -  数据类型:int
            /// </summary>
            public static Field Level = new Field<SysOrg>("Level");

            /// <summary>
            /// 排序号 -  数据类型:int
            /// </summary>
            public static Field OrderNum = new Field<SysOrg>("OrderNum");

            /// <summary>
            /// 备注 -  数据类型:string
            /// </summary>
            public static Field Remark = new Field<SysOrg>("Remark");

            /// <summary>
            /// 是否使用1使用0停用 -  数据类型:int
            /// </summary>
            public static Field Enabled = new Field<SysOrg>("Enabled");

            /// <summary>
            /// 字段名:Relation -  数据类型:string
            /// </summary>
            public static Field Relation = new Field<SysOrg>("Relation");

        }
        #endregion

    }
}

