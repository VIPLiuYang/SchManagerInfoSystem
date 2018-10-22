using System;
namespace SchSystem.Model
{
    /// <summary>
    /// ServFuncExt:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ServFuncExt
    {
        public ServFuncExt()
        { }
        #region Model
        private int _autoid;
        private int _funcid;
        private string _napecode;
        private string _napecodes;
        private int _napec = 0;
        /// <summary>
        /// 业务功能扩展配置信息
        /// </summary>
        public int AutoId
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 对应的功能ID
        /// </summary>
        public int FuncId
        {
            set { _funcid = value; }
            get { return _funcid; }
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
        /// <summary>
        /// 允许选择个数
        /// </summary>
        public int NapeC
        {
            set { _napec = value; }
            get { return _napec; }
        }
        #endregion Model

    }
}

