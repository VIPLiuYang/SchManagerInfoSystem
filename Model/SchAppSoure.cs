using System;
namespace SchSystem.Model
{
	/// <summary>
	/// SchAppSoure:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SchAppSoure
	{
		public SchAppSoure()
		{}
		#region Model
		private int _autoid;
		private int _appcode;
		private string _appname;
		private int _stat;
		private DateTime? _rectime= DateTime.Now;
		private string _recuser;
		private DateTime? _lastrectime;
		private string _lastrecuser;
		/// <summary>
		/// 子应用系统字典表
		/// </summary>
		public int AutoId
		{
			set{ _autoid=value;}
			get{return _autoid;}
		}
		/// <summary>
		/// 应用ID
		/// </summary>
		public int AppCode
		{
			set{ _appcode=value;}
			get{return _appcode;}
		}
		/// <summary>
		/// 子应用名称
		/// </summary>
		public string AppName
		{
			set{ _appname=value;}
			get{return _appname;}
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
		/// 记录时间
		/// </summary>
		public DateTime? RecTime
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
		#endregion Model

	}
}

