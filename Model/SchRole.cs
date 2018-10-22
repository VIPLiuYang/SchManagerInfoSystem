using System;
namespace SchSystem.Model
{
    /// <summary>
    /// SchRole:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SchRole
    {
        public SchRole()
        { }
        #region Model
        private int _roleid;
        private string _rolename;
        private string _rolestr;
        private string _roleextstr;
        private int _stat;
        private DateTime _rectime = DateTime.Now;
        private string _recuser;
        private DateTime _lastrectime;
        private string _lastrecuser;
        private int _schid;
        private int _systype = 0;
        /// <summary>
        /// 角色表
        /// </summary>
        public int RoleId
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName
        {
            set { _rolename = value; }
            get { return _rolename; }
        }
        /// <summary>
        /// 角色普通权限串
        /// </summary>
        public string RoleStr
        {
            set { _rolestr = value; }
            get { return _rolestr; }
        }
        /// <summary>
        /// 角色特殊权限串
        /// </summary>
        public string RoleExtStr
        {
            set { _roleextstr = value; }
            get { return _roleextstr; }
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
        public DateTime LastRecTime
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
        public int SchId
        {
            set { _schid = value; }
            get { return _schid; }
        }
        /// <summary>
        /// 所属人员分类,0基本用户,1学校超管,2系统管理员
        /// </summary>
        public int SysType
        {
            set { _systype = value; }
            get { return _systype; }
        }
        #endregion Model

    }
}

