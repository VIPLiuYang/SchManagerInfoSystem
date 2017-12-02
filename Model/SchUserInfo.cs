using System;
namespace SchSystem.Model
{
	/// <summary>
	/// SchUserInfo:实体类(用户信息表)
	/// </summary>
	[Serializable]
	public partial class SchUserInfo
	{
		public SchUserInfo()
		{}
		#region Model
		private int _userid;
		private string _username;
		private string _usertname;
		private string _password;
		private int? _schid;
		private int? _orderid;
		private int _stat=1;
		private string _departids;
		private int _userlv=0;
		private string _mobile;
		private string _telno;
		private string _postion;
		private string _imgurl;
		private DateTime? _logintime= DateTime.Now;
		private string _classms;
		private DateTime _rectime= DateTime.Now;
		private string _recuser="xxtsys";
		private DateTime? _lastrectime;
		private string _lastrecuser;
		private int? _copeid;
		private int? _roleid;
		/// <summary>
		/// 用户信息表
		/// </summary>
		public int UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 登录名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 真实姓名
		/// </summary>
		public string UserTname
		{
			set{ _usertname=value;}
			get{return _usertname;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string PassWord
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SchId
		{
			set{ _schid=value;}
			get{return _schid;}
		}
		/// <summary>
		/// 排序ID
		/// </summary>
		public int? OrderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int Stat
		{
			set{ _stat=value;}
			get{return _stat;}
		}
		/// <summary>
		/// 部门ID,用逗号隔开,所在的部门
		/// </summary>
		public string DepartIds
		{
			set{ _departids=value;}
			get{return _departids;}
		}
		/// <summary>
		/// 用户级别,用于OA或其他方面应用
		/// </summary>
		public int UserLv
		{
			set{ _userlv=value;}
			get{return _userlv;}
		}
		/// <summary>
		/// 手机号
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 其他联系方式
		/// </summary>
		public string Telno
		{
			set{ _telno=value;}
			get{return _telno;}
		}
		/// <summary>
		/// 职位
		/// </summary>
		public string Postion
		{
			set{ _postion=value;}
			get{return _postion;}
		}
		/// <summary>
		/// 头像URL
		/// </summary>
		public string ImgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		/// <summary>
		/// 最近登录时间
		/// </summary>
		public DateTime? LoginTime
		{
			set{ _logintime=value;}
			get{return _logintime;}
		}
		/// <summary>
		/// 作为班主任的班级
		/// </summary>
		public string ClassMs
		{
			set{ _classms=value;}
			get{return _classms;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime RecTime
		{
			set{ _rectime=value;}
			get{return _rectime;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public string RecUser
		{
			set{ _recuser=value;}
			get{return _recuser;}
		}
		/// <summary>
		/// 最后编辑时间
		/// </summary>
		public DateTime? LastRecTime
		{
			set{ _lastrectime=value;}
			get{return _lastrectime;}
		}
		/// <summary>
		/// 最后编辑人
		/// </summary>
		public string LastRecUser
		{
			set{ _lastrecuser=value;}
			get{return _lastrecuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CopeId
		{
			set{ _copeid=value;}
			get{return _copeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RoleId
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		#endregion Model

	}
}

