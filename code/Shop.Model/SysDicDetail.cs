﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.5472
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shop.Model
{
    using System;
    using MySoft.Data;
    using System.ComponentModel.DataAnnotations;


    /// <summary>
    /// 表名：SysDicDetail 主键列：Id
    /// </summary>
    [SerializableAttribute()]
    public partial class SysDicDetail : Entity, IModel
    {

        protected Int32 _Id;

        protected Int32? _ParentId;

        protected Int32? _DicTypeId;

        protected String _Name;

        protected String _Relation;

        protected Int32 _Level;

        protected Int32 _OrderNum;

        protected String _Remark;

        protected Int32 _Enabled;

        //自增ID
        public Int32 Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this.OnPropertyValueChange(_.Id, _Id, value);
                this._Id = value;
            }
        }
        //父ID
        public Int32? ParentId
        {
            get
            {
                return this._ParentId;
            }
            set
            {
                this.OnPropertyValueChange(_.ParentId, _ParentId, value);
                this._ParentId = value;
            }
        }
        //字典类型ID
        public Int32? DicTypeId
        {
            get
            {
                return this._DicTypeId;
            }
            set
            {
                this.OnPropertyValueChange(_.DicTypeId, _DicTypeId, value);
                this._DicTypeId = value;
            }
        }
        //名称
        [Required(ErrorMessage = "必填项")]
        [StringLength(50, ErrorMessage = "长度不能大于50")]
        public String Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this.OnPropertyValueChange(_.Name, _Name, value);
                this._Name = value;
            }
        }
        //上下级关系
        public String Relation
        {
            get
            {
                return this._Relation;
            }
            set
            {
                this.OnPropertyValueChange(_.Relation, _Relation, value);
                this._Relation = value;
            }
        }
        //级别
        [Required(ErrorMessage = "必填项")]
        [RegularExpression("-?\\d+", ErrorMessage = "*")]
        public Int32 Level
        {
            get
            {
                return this._Level;
            }
            set
            {
                this.OnPropertyValueChange(_.Level, _Level, value);
                this._Level = value;
            }
        }
        /// <summary>
        /// 排序号
        /// </summary>
        /// 
        [Required(ErrorMessage = "必填项")]
        [RegularExpression("-?\\d+", ErrorMessage = "格式输入不正确")]
        public Int32 OrderNum
        {
            get
            {
                return this._OrderNum;
            }
            set
            {
                this.OnPropertyValueChange(_.OrderNum, _OrderNum, value);
                this._OrderNum = value;
            }
        }
        //备注
         [StringLength(500, ErrorMessage = "长度不能大于500")]
        public String Remark
        {
            get
            {
                return this._Remark;
            }
            set
            {
                this.OnPropertyValueChange(_.Remark, _Remark, value);
                this._Remark = value;
            }
        }
        /// <summary>
        /// 1代表启用2代表停用
        /// </summary>
        [Required(ErrorMessage = "必选项")]
        [RegularExpression("-?\\d+", ErrorMessage = "请选择")]
        public Int32 Enabled
        {
            get
            {
                return this._Enabled;
            }
            set
            {
                this.OnPropertyValueChange(_.Enabled, _Enabled, value);
                this._Enabled = value;
            }
        }

        /// <summary>
        /// 获取实体对应的表名
        /// </summary>
        protected override Table GetTable()
        {
            return new Table<SysDicDetail>("SysDicDetail");
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
                        _.DicTypeId,
                        _.Name,
                        _.Relation,
                        _.Level,
                        _.OrderNum,
                        _.Remark,
                        _.Enabled};
        }

        /// <summary>
        /// 获取列数据
        /// </summary>
        protected override object[] GetValues()
        {
            return new object[] {
                        this._Id,
                        this._ParentId,
                        this._DicTypeId,
                        this._Name,
                        this._Relation,
                        this._Level,
                        this._OrderNum,
                        this._Remark,
                        this._Enabled};
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
            if ((false == reader.IsDBNull(_.DicTypeId)))
            {
                this._DicTypeId = reader.GetInt32(_.DicTypeId);
            }
            if ((false == reader.IsDBNull(_.Name)))
            {
                this._Name = reader.GetString(_.Name);
            }
            if ((false == reader.IsDBNull(_.Relation)))
            {
                this._Relation = reader.GetString(_.Relation);
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
            if ((false == typeof(SysDicDetail).IsAssignableFrom(obj.GetType())))
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
            public static AllField All = new AllField<SysDicDetail>();

            /// <summary>
            /// 字段名：Id - 数据类型：Int32
            /// </summary>
            public static Field Id = new Field<SysDicDetail>("Id");

            /// <summary>
            /// 字段名：ParentId - 数据类型：Nullable`1
            /// </summary>
            public static Field ParentId = new Field<SysDicDetail>("ParentId");

            /// <summary>
            /// 字段名：DicTypeId - 数据类型：Nullable`1
            /// </summary>
            public static Field DicTypeId = new Field<SysDicDetail>("DicTypeId");

            /// <summary>
            /// 字段名：Name - 数据类型：String
            /// </summary>
            public static Field Name = new Field<SysDicDetail>("Name");

            /// <summary>
            /// 字段名：Relation - 数据类型：String
            /// </summary>
            public static Field Relation = new Field<SysDicDetail>("Relation");

            /// <summary>
            /// 字段名：Level - 数据类型：Int32
            /// </summary>
            public static Field Level = new Field<SysDicDetail>("Level");

            /// <summary>
            /// 字段名：OrderNum - 数据类型：Int32
            /// </summary>
            public static Field OrderNum = new Field<SysDicDetail>("OrderNum");

            /// <summary>
            /// 字段名：Remark - 数据类型：String
            /// </summary>
            public static Field Remark = new Field<SysDicDetail>("Remark");

            /// <summary>
            /// 字段名：Enabled - 数据类型：Int32
            /// </summary>
            public static Field Enabled = new Field<SysDicDetail>("Enabled");
        }
    }
}