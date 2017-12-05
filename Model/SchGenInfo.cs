using System;
namespace SchSystem.Model
{
	/// <summary>
    /// SchGenInfo:实体类(家长信息表)
	/// </summary>
	[Serializable]
	public partial class SchGenInfo
	{
		public SchGenInfo()
		{}
		#region Model
		private int _genid;
		private string _loginname;
		private string _pwd= "123456";
		private string _genname;
		private string _mobile;
		private int _sex=2;
		private string _imgurl;
		private int _stat=1;
		private DateTime _logintime= DateTime.Now;
		private DateTime _rectime= DateTime.Now;
		private string _recuser;
		private DateTime _lastrectime;
		private string _lastrecuser;
		/// <summary>
		/// 家长信息表
		/// </summary>
		public int GenId
		{
			set{ _genid=value;}
			get{return _genid;}
		}
		/// <summary>
		/// 登录名
		/// </summary>
		public string LoginName
		{
			set{ _loginname=value;}
			get{return _loginname;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string Pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		/// <summary>
		/// 家长姓名
		/// </summary>
		public string GenName
		{
			set{ _genname=value;}
			get{return _genname;}
		}
		/// <summary>
		/// 卡地址
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 0:女，1：男,2,未明
		/// </summary>
		public int Sex
		{
			set{ _sex=value;}
			get{return _sex;}
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
		/// 状态,0废弃,1正常
		/// </summary>
		public int Stat
		{
			set{ _stat=value;}
			get{return _stat;}
		}
		/// <summary>
		/// 最近登录时间
		/// </summary>
		public DateTime LoginTime
		{
			set{ _logintime=value;}
			get{return _logintime;}
		}
		/// <summary>
		/// 记录时间
		/// </summary>
		public DateTime RecTime
		{
			set{ _rectime=value;}
			get{return _rectime;}
		}
		/// <summary>
		/// 记录日
		/// </summary>
		public string RecUser
		{
			set{ _recuser=value;}
			get{return _recuser;}
		}
		/// <summary>
		/// 最后编辑时间
		/// </summary>
		public DateTime LastRecTime
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
		#endregion Model

	}
}

