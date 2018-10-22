using System;
namespace SchSystem.Model
{
    /// <summary>
    /// SchMenuInfoRouter:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SchMenuInfoRouter
    {
        public SchMenuInfoRouter()
        { }
        #region Model
        private int _menuid;
        private string _navurl;
        private string _textname;
        private int _funccode;
        private int _schid;
        private int _systype;
        /// <summary>
        /// 外链菜单学校路由表,此表中不添加则采用原系统url
        /// </summary>
        public int MenuId
        {
            set { _menuid = value; }
            get { return _menuid; }
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
        /// 学校代码
        /// </summary>
        public int SchId
        {
            set { _schid = value; }
            get { return _schid; }
        }
        /// <summary>
        /// 系统代码0,前台,1后台,2支撑,3计费
        /// </summary>
        public int SysType
        {
            set { _systype = value; }
            get { return _systype; }
        }
        #endregion Model

    }
}

