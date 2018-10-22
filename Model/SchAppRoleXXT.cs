using System;
namespace SchSystem.Model
{
	/// <summary>
	/// SchAppRoleXXT:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SchAppRoleXXT
	{
		public SchAppRoleXXT()
		{}
		#region Model
		private int _autoid;
		private int _schid;
		private string _appstr;
		private DateTime? _rectime= DateTime.Now;
		private string _recuser;
		private DateTime? _lastrectime;
		private string _lastrecuser;
		/// <summary>
		/// 学校应用系统
		/// </summary>
		public int AutoId
		{
			set{ _autoid=value;}
			get{return _autoid;}
		}
		/// <summary>
		/// 学校ID
		/// </summary>
		public int SchId
		{
			set{ _schid=value;}
			get{return _schid;}
		}
		/// <summary>
		/// 菜单串
		/// </summary>
		public string AppStr
		{
			set{ _appstr=value;}
			get{return _appstr;}
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

