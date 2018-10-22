using System;
namespace SchSystem.Model
{
    /// <summary>
    /// WxMinUnSysUser:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class WxMinUnSysUser
    {
        public WxMinUnSysUser()
        { }
        #region Model
        private int _autoid;
        private string _wxuid;
        private string _sysuname;
        private int _systype;
        private int _schid;
        private string _mobile;
        private DateTime _rectime = DateTime.Now;
        /// <summary>
        /// 微信小程序关联表
        /// </summary>
        public int AutoId
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 微信uID
        /// </summary>
        public string WxUid
        {
            set { _wxuid = value; }
            get { return _wxuid; }
        }
        /// <summary>
        /// 系统用户ID
        /// </summary>
        public string SysUname
        {
            set { _sysuname = value; }
            get { return _sysuname; }
        }
        /// <summary>
        /// 系统用户类型
        /// </summary>
        public int SysType
        {
            set { _systype = value; }
            get { return _systype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SchId
        {
            set { _schid = value; }
            get { return _schid; }
        }
        /// <summary>
        /// 绑定的手机号
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime RecTime
        {
            set { _rectime = value; }
            get { return _rectime; }
        }
        #endregion Model

    }
}