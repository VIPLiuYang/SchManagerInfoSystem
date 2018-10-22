using System;
namespace SchSystem.Model
{
    /// <summary>
    /// SysPer:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SysPer
    {
        public SysPer()
        { }
        #region Model
        private int _autoid;
        private string _pername;
        private string _percode;
        private int _peryear = 3;
        private int _stat = 1;
        /// <summary>
        /// 学段表
        /// </summary>
        public int AutoId
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 学段名称
        /// </summary>
        public string PerName
        {
            set { _pername = value; }
            get { return _pername; }
        }
        /// <summary>
        /// 学段代码
        /// </summary>
        public string PerCode
        {
            set { _percode = value; }
            get { return _percode; }
        }
        /// <summary>
        /// 学年制
        /// </summary>
        public int PerYear
        {
            set { _peryear = value; }
            get { return _peryear; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int Stat
        {
            set { _stat = value; }
            get { return _stat; }
        }
        #endregion Model

    }
}

