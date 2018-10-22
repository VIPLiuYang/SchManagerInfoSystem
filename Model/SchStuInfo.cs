using System;
namespace SchSystem.Model
{
	/// <summary>
    /// SchStuInfo:实体类(学生表)
	/// </summary>
	[Serializable]
	public partial class SchStuInfo
	{
		public SchStuInfo()
		{}
        #region Model
        private int _stuid;
        private string _loginname;
        private string _pwd = "123456";
        private string _stuname;
        private string _stuno;
        private int? _classid;
        private string _oldclassid;
        private int _schid;
        private string _cardno;
        private string _testno;
        private int _sex = 2;
        private DateTime? _birth;
        private string _telno;
        private string _addr;
        private string _imgurl;
        private int? _studytype = 1;
        private int _stat = 1;
        private DateTime? _logintime = DateTime.Now;
        private DateTime? _rectime = DateTime.Now;
        private string _recuser;
        private DateTime? _lastrectime;
        private string _lastrecuser;
        private string dutie;
        /// <summary>
        /// 职务
        /// </summary>
        public string Dutie
        {
            get { return dutie; }
            set { dutie = value; }
        }
        /// <summary>
        /// 学生表
        /// </summary>
        public int StuId
        {
            set { _stuid = value; }
            get { return _stuid; }
        }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StuName
        {
            set { _stuname = value; }
            get { return _stuname; }
        }
        /// <summary>
        /// 学生证号
        /// </summary>
        public string StuNo
        {
            set { _stuno = value; }
            get { return _stuno; }
        }
        /// <summary>
        /// 班级ID
        /// </summary>
        public int? ClassId
        {
            set { _classid = value; }
            get { return _classid; }
        }
        /// <summary>
        /// 原班级ID
        /// </summary>
        public string OldClassId
        {
            set { _oldclassid = value; }
            get { return _oldclassid; }
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
        /// 卡地址
        /// </summary>
        public string CardNo
        {
            set { _cardno = value; }
            get { return _cardno; }
        }
        /// <summary>
        /// 考号
        /// </summary>
        public string TestNo
        {
            set { _testno = value; }
            get { return _testno; }
        }
        /// <summary>
        /// 0:女，1：男,2,未明
        /// </summary>
        public int Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birth
        {
            set { _birth = value; }
            get { return _birth; }
        }
        /// <summary>
        /// 家庭电话
        /// </summary>
        public string TelNo
        {
            set { _telno = value; }
            get { return _telno; }
        }
        /// <summary>
        /// 家庭住址
        /// </summary>
        public string Addr
        {
            set { _addr = value; }
            get { return _addr; }
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
        /// 走读类型:0住校,1走读
        /// </summary>
        public int? StudyType
        {
            set { _studytype = value; }
            get { return _studytype; }
        }
        /// <summary>
        /// 状态,0废弃,1正常
        /// </summary>
        public int Stat
        {
            set { _stat = value; }
            get { return _stat; }
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

