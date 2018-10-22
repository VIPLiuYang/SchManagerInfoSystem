using System;
namespace SchSystem.Model
{
    /// <summary>
    /// SysColl:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SysColl
    {
        public SysColl()
        { }
        #region Model
        private int _autoid;
        private string _collname;
        private string _collcode;
        private int _stat = 1;
        /// <summary>
        /// 大学院系表
        /// </summary>
        public int AutoId
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 院系名称
        /// </summary>
        public string CollName
        {
            set { _collname = value; }
            get { return _collname; }
        }
        /// <summary>
        /// 院系代码
        /// </summary>
        public string CollCode
        {
            set { _collcode = value; }
            get { return _collcode; }
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

