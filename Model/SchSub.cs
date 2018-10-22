using System;
namespace SchSystem.Model
{
    /// <summary>
    /// SchSub:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SchSub
    {
        public SchSub()
        { }
        #region Model
        private int _subid;
        private string _subname;
        private string _subcode;
        private int _stat;
        private int _schid;
        private int? _orderid;
        /// <summary>
        /// 学校科目表
        /// </summary>
        public int SubId
        {
            set { _subid = value; }
            get { return _subid; }
        }
        /// <summary>
        /// 科目名称
        /// </summary>
        public string SubName
        {
            set { _subname = value; }
            get { return _subname; }
        }
        /// <summary>
        /// 科目代码
        /// </summary>
        public string SubCode
        {
            set { _subcode = value; }
            get { return _subcode; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int Stat
        {
            set { _stat = value; }
            get { return _stat; }
        }
        /// <summary>
        /// 学校ID
        /// </summary>
        public int SchId
        {
            set { _schid = value; }
            get { return _schid; }
        }
        /// <summary>
        /// 排序ID
        /// </summary>
        public int? OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        #endregion Model

    }
}

