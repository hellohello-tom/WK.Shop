// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：Commodity Model
//  作    者：cat
//  添加时间：2015-06-16 10:33:24
// ==========================================================================
using System;
//引用
using MySoft.Data;
using System.ComponentModel.DataAnnotations;

namespace Shop.Model
{
    /// <summary>
    /// 表名：Commodity 主键列：Id 	 

    ///Commodity
    /// </summary>
    [SerializableAttribute()]
    public partial class Commodity : Entity, IModel
    {
        #region 私有变量
        private int _Id;
        private int _Commodity_TagId;
        private string _Commodity_Name;
        private int _Commodity_Sales;
        private string _Commodity_Remind;
        private decimal _Commodity_CostPrice;
        private decimal _Commodity_Discount;
        private int _Commodity_ResidueCount;
        private string _Commodity_Remark;
        private string _Commodity_ImagePath;
        private string _Commodity_Content;
        private int _Commodity_Status;
        private DateTime? _Commodity_CreateTime;
        private int _Commodity_User;
        private bool _Commodity_IsDel;
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
        /// 标签Id
        /// </summary>

        [RegularExpression("-?\\d+", ErrorMessage = "*")]
        public int Commodity_TagId
        {
            get { return _Commodity_TagId; }
            set
            {
                OnPropertyValueChange(_.Commodity_TagId, _Commodity_TagId, value);
                _Commodity_TagId = value;
            }
        }

        /// <summary>
        /// 商品名称
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(50, ErrorMessage = "字符不能超过50个")]
        public string Commodity_Name
        {
            get { return _Commodity_Name; }
            set
            {
                OnPropertyValueChange(_.Commodity_Name, _Commodity_Name, value);
                _Commodity_Name = value;
            }
        }

        /// <summary>
        /// 商品销量
        /// </summary>

        [RegularExpression("-?\\d+", ErrorMessage = "*")]
        public int Commodity_Sales
        {
            get { return _Commodity_Sales; }
            set
            {
                OnPropertyValueChange(_.Commodity_Sales, _Commodity_Sales, value);
                _Commodity_Sales = value;
            }
        }

        /// <summary>
        /// 提醒
        /// </summary>		
        [StringLength(200, ErrorMessage = "字符不能超过200个")]
        public string Commodity_Remind
        {
            get { return _Commodity_Remind; }
            set
            {
                OnPropertyValueChange(_.Commodity_Remind, _Commodity_Remind, value);
                _Commodity_Remind = value;
            }
        }

        /// <summary>
        /// 原价
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Range(0.02, 100000.00, ErrorMessage = "价格范围0.02元~10万元")]
        [RegularExpression(@"^(([1-9]+[0-9]*)|0)(\.\d{1,2})?$", ErrorMessage = "请输入正确价格，最多保留两位小数")]
        
        public decimal Commodity_CostPrice
        {
            get { return _Commodity_CostPrice; }
            set
            {
                OnPropertyValueChange(_.Commodity_CostPrice, _Commodity_CostPrice, value);
                _Commodity_CostPrice = value;
            }
        }

        /// <summary>
        /// 折扣系数
        /// </summary>
        [RegularExpression(@"^([1-9])(\.\d{1})?$", ErrorMessage = "请输入正确的折扣，最多保留一位小数")]
        public decimal? Commodity_Discount
        {
            get { return _Commodity_Discount; }
            set
            {
                OnPropertyValueChange(_.Commodity_Discount, _Commodity_Discount, value);
                _Commodity_Discount = value.Value;
            }
        }

        /// <summary>
        /// 剩余数量
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Range(0, 100000, ErrorMessage = "0~100000之间")]
        [RegularExpression(@"^\d+$", ErrorMessage = "请输入正整数")]
        public int Commodity_ResidueCount
        {
            get { return _Commodity_ResidueCount; }
            set
            {
                OnPropertyValueChange(_.Commodity_ResidueCount, _Commodity_ResidueCount, value);
                _Commodity_ResidueCount = value;
            }
        }

        /// <summary>
        /// 备注
        /// </summary>		
        [StringLength(500, ErrorMessage = "不能超过500个字符")]
        public string Commodity_Remark
        {
            get { return _Commodity_Remark; }
            set
            {
                OnPropertyValueChange(_.Commodity_Remark, _Commodity_Remark, value);
                _Commodity_Remark = value;
            }
        }

        /// <summary>
        /// 默认展示图片
        /// </summary>

        [StringLength(500, ErrorMessage = "*")]
        public string Commodity_ImagePath
        {
            get { return _Commodity_ImagePath; }
            set
            {
                OnPropertyValueChange(_.Commodity_ImagePath, _Commodity_ImagePath, value);
                _Commodity_ImagePath = value;
            }
        }

        /// <summary>
        /// 图文详情
        /// </summary>		
        public string Commodity_Content
        {
            get { return _Commodity_Content; }
            set
            {
                OnPropertyValueChange(_.Commodity_Content, _Commodity_Content, value);
                _Commodity_Content = value;
            }
        }

        /// <summary>
        /// 商品状态，0，上架，1，下架，2，展示
        /// </summary>
        public int Commodity_Status
        {
            get { return _Commodity_Status; }
            set
            {
                OnPropertyValueChange(_.Commodity_Status, _Commodity_Status, value);
                _Commodity_Status = value;
            }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        [RegularExpression("^\\d{4}(\\-|\\/|\\.)\\d{1,2}\\1\\d{1,2}(\\s\\d{1,2}:\\d{1,2}:\\d{1,2})?$", ErrorMessage = "*")]
        public DateTime? Commodity_CreateTime
        {
            get { return _Commodity_CreateTime; }
            set
            {
                OnPropertyValueChange(_.Commodity_CreateTime, _Commodity_CreateTime, value);
                _Commodity_CreateTime = value;
            }
        }

        /// <summary>
        /// 创建人
        /// </summary>

        [RegularExpression("-?\\d+", ErrorMessage = "*")]
        public int Commodity_User
        {
            get { return _Commodity_User; }
            set
            {
                OnPropertyValueChange(_.Commodity_User, _Commodity_User, value);
                _Commodity_User = value;
            }
        }

        /// <summary>
        /// 是否删除
        /// </summary>

        [Required(ErrorMessage = "*")]
        public bool Commodity_IsDel
        {
            get { return _Commodity_IsDel; }
            set
            {
                OnPropertyValueChange(_.Commodity_IsDel, _Commodity_IsDel, value);
                _Commodity_IsDel = value;
            }
        }
        #endregion

        #region MySoft
        /// <summary>
        /// 获取实体对应的表名
        /// </summary>
        protected override Table GetTable()
        {
            return new Table<Commodity>("Commodity");
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
								_.Commodity_TagId,
								_.Commodity_Name,
								_.Commodity_Sales,
								_.Commodity_Remind,
								_.Commodity_CostPrice,
								_.Commodity_Discount,
								_.Commodity_ResidueCount,
								_.Commodity_Remark,
								_.Commodity_ImagePath,
								_.Commodity_Content,
								_.Commodity_Status,
								_.Commodity_CreateTime,
								_.Commodity_User,
								_.Commodity_IsDel};
        }

        /// <summary>
        /// 获取列数据
        /// </summary>
        protected override object[] GetValues()
        {
            return new object[] {
            					_Id,
								_Commodity_TagId,
								_Commodity_Name,
								_Commodity_Sales,
								_Commodity_Remind,
								_Commodity_CostPrice,
								_Commodity_Discount,
								_Commodity_ResidueCount,
								_Commodity_Remark,
								_Commodity_ImagePath,
								_Commodity_Content,
								_Commodity_Status,
								_Commodity_CreateTime,
								_Commodity_User,
								_Commodity_IsDel};
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

            if ((false == reader.IsDBNull(_.Commodity_TagId)))
            {
                this._Commodity_TagId = reader.GetInt32(_.Commodity_TagId);
            }

            if ((false == reader.IsDBNull(_.Commodity_Name)))
            {
                this._Commodity_Name = reader.GetString(_.Commodity_Name);
            }

            if ((false == reader.IsDBNull(_.Commodity_Sales)))
            {
                this._Commodity_Sales = reader.GetInt32(_.Commodity_Sales);
            }

            if ((false == reader.IsDBNull(_.Commodity_Remind)))
            {
                this._Commodity_Remind = reader.GetString(_.Commodity_Remind);
            }

            if ((false == reader.IsDBNull(_.Commodity_CostPrice)))
            {
                this._Commodity_CostPrice = reader.GetDecimal(_.Commodity_CostPrice);
            }

            if ((false == reader.IsDBNull(_.Commodity_Discount)))
            {
                this._Commodity_Discount = reader.GetDecimal(_.Commodity_Discount);
            }

            if ((false == reader.IsDBNull(_.Commodity_ResidueCount)))
            {
                this._Commodity_ResidueCount = reader.GetInt32(_.Commodity_ResidueCount);
            }

            if ((false == reader.IsDBNull(_.Commodity_Remark)))
            {
                this._Commodity_Remark = reader.GetString(_.Commodity_Remark);
            }

            if ((false == reader.IsDBNull(_.Commodity_ImagePath)))
            {
                this._Commodity_ImagePath = reader.GetString(_.Commodity_ImagePath);
            }

            if ((false == reader.IsDBNull(_.Commodity_Content)))
            {
                this._Commodity_Content = reader.GetString(_.Commodity_Content);
            }

            if ((false == reader.IsDBNull(_.Commodity_Status)))
            {
                this._Commodity_Status = reader.GetInt32(_.Commodity_Status);
            }

            if ((false == reader.IsDBNull(_.Commodity_CreateTime)))
            {
                this._Commodity_CreateTime = reader.GetDateTime(_.Commodity_CreateTime);
            }

            if ((false == reader.IsDBNull(_.Commodity_User)))
            {
                this._Commodity_User = reader.GetInt32(_.Commodity_User);
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
            if ((false == typeof(Commodity).IsAssignableFrom(obj.GetType())))
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
            public static AllField All = new AllField<Commodity>();

            /// <summary>
            /// Id -  数据类型:int
            /// </summary>
            public static Field Id = new Field<Commodity>("Id");

            /// <summary>
            /// 标签Id -  数据类型:int
            /// </summary>
            public static Field Commodity_TagId = new Field<Commodity>("Commodity_TagId");

            /// <summary>
            /// 商品名称 -  数据类型:string
            /// </summary>
            public static Field Commodity_Name = new Field<Commodity>("Commodity_Name");

            /// <summary>
            /// 字段名:Commodity_Sales -  数据类型:int
            /// </summary>
            public static Field Commodity_Sales = new Field<Commodity>("Commodity_Sales");

            /// <summary>
            /// 提醒 -  数据类型:string
            /// </summary>
            public static Field Commodity_Remind = new Field<Commodity>("Commodity_Remind");

            /// <summary>
            /// 原价 -  数据类型:decimal
            /// </summary>
            public static Field Commodity_CostPrice = new Field<Commodity>("Commodity_CostPrice");

            /// <summary>
            /// 折扣系数 -  数据类型:decimal
            /// </summary>
            public static Field Commodity_Discount = new Field<Commodity>("Commodity_Discount");

            /// <summary>
            /// 剩余数量 -  数据类型:int
            /// </summary>
            public static Field Commodity_ResidueCount = new Field<Commodity>("Commodity_ResidueCount");

            /// <summary>
            /// 备注 -  数据类型:string
            /// </summary>
            public static Field Commodity_Remark = new Field<Commodity>("Commodity_Remark");

            /// <summary>
            /// 默认展示图片 -  数据类型:string
            /// </summary>
            public static Field Commodity_ImagePath = new Field<Commodity>("Commodity_ImagePath");

            /// <summary>
            /// 图文详情 -  数据类型:string
            /// </summary>
            public static Field Commodity_Content = new Field<Commodity>("Commodity_Content");

            /// <summary>
            /// 字段名:Commodity_Status -  数据类型:int
            /// </summary>
            public static Field Commodity_Status = new Field<Commodity>("Commodity_Status");

            /// <summary>
            /// 创建时间 -  数据类型:DateTime
            /// </summary>
            public static Field Commodity_CreateTime = new Field<Commodity>("Commodity_CreateTime");

            /// <summary>
            /// 创建人 -  数据类型:int
            /// </summary>
            public static Field Commodity_User = new Field<Commodity>("Commodity_User");

            /// <summary>
            /// 是否删除 -  数据类型:bool
            /// </summary>
            public static Field Commodity_IsDel = new Field<Commodity>("Commodity_IsDel");

        }
        #endregion

    }
}

