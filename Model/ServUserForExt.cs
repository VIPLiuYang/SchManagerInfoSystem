using System;
namespace SchSystem.Model
{
    /// <summary>
    /// ServUserForExt:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ServUserForExt
    {
        public ServUserForExt()
        { }
        #region Model
        private int _autoid;
        private int _userforid;
        private string _fcode;
        private string _napecode;
        private string _napecodes;
        /// <summary>
        /// 用户定制扩展信息表
        /// </summary>
        public int AutoId
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 对应的订购ID
        /// </summary>
        public int UserForId
        {
            set { _userforid = value; }
            get { return _userforid; }
        }
        /// <summary>
        /// 功能码
        /// </summary>
        public string Fcode
        {
            set { _fcode = value; }
            get { return _fcode; }
        }
        /// <summary>
        /// 下拉项代码
        /// </summary>
        public string NapeCode
        {
            set { _napecode = value; }
            get { return _napecode; }
        }
        /// <summary>
        /// 下拉项代码对应代码串
        /// </summary>
        public string NapeCodes
        {
            set { _napecodes = value; }
            get { return _napecodes; }
        }
        #endregion Model

    }
}

