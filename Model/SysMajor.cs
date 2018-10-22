using System;
namespace SchSystem.Model
{
    /// <summary>
    /// SysMajor:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SysMajor
    {
        public SysMajor()
        { }
        #region Model
        private int _autoid;
        private string _majorname;
        private string _majorcode;
        private int _stat = 1;
        /// <summary>
        /// 大学专业表
        /// </summary>
        public int AutoId
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 专业名称
        /// </summary>
        public string MajorName
        {
            set { _majorname = value; }
            get { return _majorname; }
        }
        /// <summary>
        /// 专业代码
        /// </summary>
        public string MajorCode
        {
            set { _majorcode = value; }
            get { return _majorcode; }
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

