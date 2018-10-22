using System;
namespace SchSystem.Model
{
    /// <summary>
    /// SchUserRoleXXT:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SchUserRoleXXT
    {
        public SchUserRoleXXT()
        { }
        #region Model
        private int _autoid;
        private int _roleid;
        private string _username;
        private DateTime? _rectime = DateTime.Now;
        private string _recuser;
        private DateTime? _lastrectime;
        private string _lastrecuser;
        private int _schid;
        /// <summary>
        /// 用户资源角色关联表
        /// </summary>
        public int AutoId
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 角色名称
        /// </summary>
        public int RoleID
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        /// <summary>
        /// 角色权限串
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
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
        /// <summary>
        /// 
        /// </summary>
        public int SchId
        {
            set { _schid = value; }
            get { return _schid; }
        }
        #endregion Model

    }
}

