using System;
namespace SchSystem.Model
{
    /// <summary>
    /// ServType:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ServType
    {
        public ServType()
        { }
        #region Model
        private int _autoid;
        private string _typename;
        private string _typecode;
        /// <summary>
        /// 业务类型表
        /// </summary>
        public int AutoId
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 业务类型名称
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 业务类型代码
        /// </summary>
        public string TypeCode
        {
            set { _typecode = value; }
            get { return _typecode; }
        }
        #endregion Model

    }
}

