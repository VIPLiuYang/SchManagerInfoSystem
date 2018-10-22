using System;
namespace SchSystem.Model
{
    /// <summary>
    /// SysTerm:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SysTerm
    {
        public SysTerm()
        { }
        #region Model
        private int _autoid;
        private string _termname;
        private string _termcode;
        /// <summary>
        /// 
        /// </summary>
        public int AutoId
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TermName
        {
            set { _termname = value; }
            get { return _termname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TermCode
        {
            set { _termcode = value; }
            get { return _termcode; }
        }
        #endregion Model

    }
}

