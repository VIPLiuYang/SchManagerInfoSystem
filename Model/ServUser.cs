using System;
namespace SchSystem.Model
{
    /// <summary>
    /// ServUser:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ServUser
    {
        public ServUser()
        { }
        #region Model
        private int _autoid;
        private string _username;
        private string _pwd;
        private int _usex;
        private string _utname;
        private string _uareano;
        private DateTime _rectime = DateTime.Now;
        private DateTime? _logintime;
        private string _uico;
        private int _stat = 1;
        /// <summary>
        /// 普通用户注册信息表
        /// </summary>
        public int AutoId
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 密码,MD5
        /// </summary>
        public string Pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }
        /// <summary>
        /// 性别,0女,1男
        /// </summary>
        public int Usex
        {
            set { _usex = value; }
            get { return _usex; }
        }
        /// <summary>
        /// 用户昵称或姓名
        /// </summary>
        public string UTname
        {
            set { _utname = value; }
            get { return _utname; }
        }
        /// <summary>
        /// 所属区域
        /// </summary>
        public string Uareano
        {
            set { _uareano = value; }
            get { return _uareano; }
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
        /// 最近登录时间
        /// </summary>
        public DateTime? LoginTime
        {
            set { _logintime = value; }
            get { return _logintime; }
        }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string Uico
        {
            set { _uico = value; }
            get { return _uico; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int Stat
        {
            set { _stat = value; }
            get { return _stat; }
        }
        #endregion Model

    }
}

