using System;
namespace SchSystem.Model
{
    /// <summary>
    /// SchUserInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SchUserInfo
    {
        public SchUserInfo()
        { }
        #region Model
        private int _userid;
        private string _username;
        private string _usertname;
        private string _password;
        private string _userno;
        private int _schid;
        private int? _orderid;
        private int _stat = 1;
        private int _userlv = 0;
        private string _mobile;
        private string _telno;
        private string _postion;
        private string _title;
        private string _imgurl;
        private DateTime? _logintime = DateTime.Now;
        private DateTime _rectime = DateTime.Now;
        private string _recuser = "xxtsys";
        private DateTime? _lastrectime;
        private string _lastrecuser;
        private int _systype = 0;
        private int _sex = 0;
        private string _subcode;
        private int _accstat = 1;
        /// <summary>
        /// 用户信息表
        /// </summary>
        public int UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 登录名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string UserTname
        {
            set { _usertname = value; }
            get { return _usertname; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserNo
        {
            set { _userno = value; }
            get { return _userno; }
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
        /// 用户级别,用于OA或其他方面应用
        /// </summary>
        public int UserLv
        {
            set { _userlv = value; }
            get { return _userlv; }
        }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 其他联系方式
        /// </summary>
        public string Telno
        {
            set { _telno = value; }
            get { return _telno; }
        }
        /// <summary>
        /// 职位
        /// </summary>
        public string Postion
        {
            set { _postion = value; }
            get { return _postion; }
        }
        /// <summary>
        /// 职称
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 头像URL
        /// </summary>
        public string ImgUrl
        {
            set { _imgurl = value; }
            get { return _imgurl; }
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
        /// 创建时间
        /// </summary>
        public DateTime RecTime
        {
            set { _rectime = value; }
            get { return _rectime; }
        }
        /// <summary>
        /// 创建人
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
        /// 系统人员分类,0学校,1学校超管,2系统超管
        /// </summary>
        public int SysType
        {
            set { _systype = value; }
            get { return _systype; }
        }
        /// <summary>
        /// 性别,0女1男
        /// </summary>
        public int Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 科目代码
        /// </summary>
        public string SubCode
        {
            set { _subcode = value; }
            get { return _subcode; }
        }
        /// <summary>
        /// 账号状态,0屏蔽,1正常
        /// </summary>
        public int AccStat
        {
            set { _accstat = value; }
            get { return _accstat; }
        }
        #endregion Model

    }
}

