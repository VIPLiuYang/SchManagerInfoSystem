using System;
namespace SchSystem.Model
{
    /// <summary>
    /// SchClassUser:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SchClassUser
    {
        public SchClassUser()
        { }
        #region Model
        private int _autoid;
        private int _classid;
        private string _subcode;
        private string _username;
        private string _usertname;
        private int _isms;
        private DateTime _rectime = DateTime.Now;
        private string _recuser;
        private DateTime? _lastrectime;
        private string _lastrecuser;
        private int? _schid;
        /// <summary>
        /// 班级老师表
        /// </summary>
        public int AutoId
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 班级ID
        /// </summary>
        public int ClassId
        {
            set { _classid = value; }
            get { return _classid; }
        }
        /// <summary>
        /// 科目ID
        /// </summary>
        public string SubCode
        {
            set { _subcode = value; }
            get { return _subcode; }
        }
        /// <summary>
        /// 老师账号
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 老师姓名
        /// </summary>
        public string UserTname
        {
            set { _usertname = value; }
            get { return _usertname; }
        }
        /// <summary>
        /// 是否班主任,1是0否
        /// </summary>
        public int IsMs
        {
            set { _isms = value; }
            get { return _isms; }
        }
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime RecTime
        {
            set { _rectime = value; }
            get { return _rectime; }
        }
        /// <summary>
        /// 记录日
        /// </summary>
        public string RecUser
        {
            set { _recuser = value; }
            get { return _recuser; }
        }
        /// <summary>
        /// 最后编辑时间
        /// </summary>
        public DateTime? LastRecTime
        {
            set { _lastrectime = value; }
            get { return _lastrectime; }
        }
        /// <summary>
        /// 最后编辑人
        /// </summary>
        public string LastRecUser
        {
            set { _lastrecuser = value; }
            get { return _lastrecuser; }
        }
        /// <summary>
        /// 学校ID
        /// </summary>
        public int? SchId
        {
            set { _schid = value; }
            get { return _schid; }
        }
        #endregion Model

    }
}

