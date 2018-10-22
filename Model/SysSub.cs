using System;
namespace SchSystem.Model
{
    /// <summary>
    /// SysSub:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SysSub
    {
        public SysSub()
        { }
        #region Model
        private int _autoid;
        private string _subcode;
        private string _subname;
        private int _stat = 1;
        /// <summary>
        /// 系统科目表
        /// </summary>
        public int AutoId
        {
            set { _autoid = value; }
            get { return _autoid; }
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
        /// 科目名称
        /// </summary>
        public string SubName
        {
            set { _subname = value; }
            get { return _subname; }
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

