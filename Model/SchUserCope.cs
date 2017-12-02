using System;
namespace SchSystem.Model
{
	/// <summary>
	/// SchUserCope:实体类(用户范围表)
	/// </summary>
	[Serializable]
	public partial class SchUserCope
	{
		public SchUserCope()
		{}
		#region Model
		private int _tabid;
		private string _schids;
		private string _gradeids;
		private string _classids;
		private int _userid;
		/// <summary>
		/// 用户范围表
		/// </summary>
		public int TabId
		{
			set{ _tabid=value;}
			get{return _tabid;}
		}
		/// <summary>
		/// 学校ID串
		/// </summary>
		public string SchIds
		{
			set{ _schids=value;}
			get{return _schids;}
		}
		/// <summary>
		/// 年级信息串
		/// </summary>
		public string GradeIds
		{
			set{ _gradeids=value;}
			get{return _gradeids;}
		}
		/// <summary>
		/// 班级信息串
		/// </summary>
		public string ClassIds
		{
			set{ _classids=value;}
			get{return _classids;}
		}
		/// <summary>
		/// 用户ID
		/// </summary>
		public int UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		#endregion Model

	}
}

