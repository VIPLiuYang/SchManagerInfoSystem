using System;
namespace SchSystem.Model
{
    /// <summary>
    /// SchGradeUsers:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SchGradeUsers
    {
        public SchGradeUsers()
        { }
        #region Model
        private int _autoid;
        private int? _gradeid;
        private string _username;
        private string _usertname;
        private DateTime? _rectime = DateTime.Now;
        private string _recuser;
        private DateTime? _lastrectime;
        private string _lastrecuser;
        /// <summary>
        /// 年级领导表
        /// </summary>
        public int AutoId
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 年级ID
        /// </summary>
        public int? GradeId
        {
            set { _gradeid = value; }
            get { return _gradeid; }
        }
        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserTname
        {
            set { _usertname = value; }
            get { return _usertname; }
        }
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime? RecTime
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
        #endregion Model

    }
}

