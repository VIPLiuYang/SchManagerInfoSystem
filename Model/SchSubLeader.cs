using System;
namespace SchSystem.Model
{
	/// <summary>
	/// SchSubLeader:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SchSubLeader
	{
		public SchSubLeader()
		{}
		#region Model
		private int _autoid;
		private int _classid;
		private int _schid;
		private int _subid;
		private string _subcode;
		private string _username;
		private string _usertname;
		private int _stat;
		private DateTime _rectime;
		private string _recuser;
		private DateTime _lastrectime;
		private string _lastrecuser;
		/// <summary>
		/// 科目组长表---自动编号
		/// </summary>
		public int AutoId
		{
			set{ _autoid=value;}
			get{return _autoid;}
		}
		/// <summary>
		/// 班级编号
		/// </summary>
		public int ClassId
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 学校编号
		/// </summary>
		public int SchId
		{
			set{ _schid=value;}
			get{return _schid;}
		}
		/// <summary>
		/// 科目编号
		/// </summary>
		public int SubId
		{
			set{ _subid=value;}
			get{return _subid;}
		}
		/// <summary>
		/// 科目代码
		/// </summary>
		public string SubCode
		{
			set{ _subcode=value;}
			get{return _subcode;}
		}
		/// <summary>
		/// 操作人账号
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 操作人姓名
		/// </summary>
		public string UserTname
		{
			set{ _usertname=value;}
			get{return _usertname;}
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
		/// 添加时间
		/// </summary>
		public DateTime RecTime
		{
			set{ _rectime=value;}
			get{return _rectime;}
		}
		/// <summary>
		/// 添加人
		/// </summary>
		public string RecUser
		{
			set{ _recuser=value;}
			get{return _recuser;}
		}
		/// <summary>
		/// 最后修改时间
		/// </summary>
		public DateTime LastRecTime
		{
			set{ _lastrectime=value;}
			get{return _lastrectime;}
		}
		/// <summary>
		/// 最后修改人
		/// </summary>
		public string LastRecUser
		{
			set{ _lastrecuser=value;}
			get{return _lastrecuser;}
		}
		#endregion Model

	}
}

