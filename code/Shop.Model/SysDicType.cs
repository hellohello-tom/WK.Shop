// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysDicType Model
//  作    者：Tom.Team
//  添加时间：2014-03-20 10:23:32
// ==========================================================================
using System;
//引用
using MySoft.Data;
using System.ComponentModel.DataAnnotations;

namespace Shop.Model
{
    /// <summary>
    /// 表名：SysDicType 主键列：Id 	 
    ///SysDicType
    /// </summary>
    [SerializableAttribute()]
    public partial class SysDicType : Entity, IModel
    {
        #region 私有变量
        private int _Id;
        private string _Name;
        private string _Code;
        private int _IsEnabled;
        private int _OrderNum;
        private string _Remark;
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
        /// 类型名称
        /// 
        /// 
        /// </summary>		

        [Required(ErrorMessage = "必填项")]
        [StringLength(50,ErrorMessage="长度不能大于50")]
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
        /// 类型标识
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        [StringLength(50, ErrorMessage = "长度不能大于50")]
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
        /// 是否使用1使用0停用
        /// </summary>
        [Required(ErrorMessage = "必选项")]
        [RegularExpression("-?\\d+", ErrorMessage = "请选择")]
        public int IsEnabled
        {
            get { return _IsEnabled; }
            set
            {
                OnPropertyValueChange(_.IsEnabled, _IsEnabled, value);
                _IsEnabled = value;
            }
        }

        /// <summary>
        /// 排序号
        /// </summary>
        /// 
        [Required(ErrorMessage = "必填项")]
        [RegularExpression("-?\\d+", ErrorMessage = "格式输入不正确")]
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
        /// 
        [StringLength(500, ErrorMessage = "长度不能大于500")]
        public string Remark
        {
            get { return _Remark; }
            set
            {
                OnPropertyValueChange(_.Remark, _Remark, value);
                _Remark = value;
            }
        }
        #endregion

        #region MySoft
        /// <summary>
        /// 获取实体对应的表名
        /// </summary>
        protected override Table GetTable()
        {
            return new Table<SysDicType>("SysDicType");
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
								_.Name,
								_.Code,
								_.IsEnabled,
								_.OrderNum,
								_.Remark};
        }

        /// <summary>
        /// 获取列数据
        /// </summary>
        protected override object[] GetValues()
        {
            return new object[] {
            					_Id,
								_Name,
								_Code,
								_IsEnabled,
								_OrderNum,
								_Remark};
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

            if ((false == reader.IsDBNull(_.Name)))
            {
                this._Name = reader.GetString(_.Name);
            }

            if ((false == reader.IsDBNull(_.Code)))
            {
                this._Code = reader.GetString(_.Code);
            }

            if ((false == reader.IsDBNull(_.IsEnabled)))
            {
                this._IsEnabled = reader.GetInt32(_.IsEnabled);
            }

            if ((false == reader.IsDBNull(_.OrderNum)))
            {
                this._OrderNum = reader.GetInt32(_.OrderNum);
            }

            if ((false == reader.IsDBNull(_.Remark)))
            {
                this._Remark = reader.GetString(_.Remark);
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
            if ((false == typeof(SysDicType).IsAssignableFrom(obj.GetType())))
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
            public static AllField All = new AllField<SysDicType>();

            /// <summary>
            /// 自增编号 -  数据类型:int
            /// </summary>
            public static Field Id = new Field<SysDicType>("Id");

            /// <summary>
            /// 类型名称 -  数据类型:string
            /// </summary>
            public static Field Name = new Field<SysDicType>("Name");

            /// <summary>
            /// 类型标识 -  数据类型:string
            /// </summary>
            public static Field Code = new Field<SysDicType>("Code");

            /// <summary>
            /// 是否使用1使用0停用 -  数据类型:int
            /// </summary>
            public static Field IsEnabled = new Field<SysDicType>("IsEnabled");

            /// <summary>
            /// 排序号 -  数据类型:int
            /// </summary>
            public static Field OrderNum = new Field<SysDicType>("OrderNum");

            /// <summary>
            /// 备注 -  数据类型:string
            /// </summary>
            public static Field Remark = new Field<SysDicType>("Remark");

        }
        #endregion



    }
}

