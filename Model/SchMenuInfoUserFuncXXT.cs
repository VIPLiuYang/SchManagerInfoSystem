using System;
namespace SchSystem.Model
{
    /// <summary>
    /// SchMenuInfoUserFuncXXT:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SchMenuInfoUserFuncXXT
    {
        public SchMenuInfoUserFuncXXT()
        { }
        #region Model
        private int _menuid;
        private int _pid;
        private int _expn;
        private string _navurl;
        private string _selact;
        private string _targets;
        private string _textname;
        private int _funccode;
        private string _funclv;
        private int _appcode = 0;
        private int? _orderid;
        private int _stat = 1;
        private string _ico;
        /// <summary>
        /// 菜单组表,权限组树表
        /// </summary>
        public int MenuId
        {
            set { _menuid = value; }
            get { return _menuid; }
        }
        /// <summary>
        /// 父ID
        /// </summary>
        public int Pid
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 是否展开
        /// </summary>
        public int Expn
        {
            set { _expn = value; }
            get { return _expn; }
        }
        /// <summary>
        /// 连接URL
        /// </summary>
        public string NavUrl
        {
            set { _navurl = value; }
            get { return _navurl; }
        }
        /// <summary>
        /// 是否被选中
        /// </summary>
        public string SelAct
        {
            set { _selact = value; }
            get { return _selact; }
        }
        /// <summary>
        /// 打开窗体
        /// </summary>
        public string Targets
        {
            set { _targets = value; }
            get { return _targets; }
        }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string TextName
        {
            set { _textname = value; }
            get { return _textname; }
        }
        /// <summary>
        /// 功能码
        /// </summary>
        public int FuncCode
        {
            set { _funccode = value; }
            get { return _funccode; }
        }
        /// <summary>
        /// 管辖菜单范围,对应菜单表的FuncCode,多个用,隔开
        /// </summary>
        public string FuncLv
        {
            set { _funclv = value; }
            get { return _funclv; }
        }
        /// <summary>
        /// 所属子应用ID
        /// </summary>
        public int AppCode
        {
            set { _appcode = value; }
            get { return _appcode; }
        }
        /// <summary>
        /// 排序ID
        /// </summary>
        public int? OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
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
        /// 
        /// </summary>
        public string Ico
        {
            set { _ico = value; }
            get { return _ico; }
        }
        #endregion Model

    }
}

