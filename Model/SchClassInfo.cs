using System;
namespace SchSystem.Model
{
	/// <summary>
	/// SchClassInfo:实体类(班级信息表)
	/// </summary>
	[Serializable]
	public partial class SchClassInfo
	{
		public SchClassInfo()
		{}
		#region Model
		private int _classid;
		private string _classno;
		private string _classname;
		private int _gradeid;
		private int _schid;
		private int _isfinish=0;
		private DateTime _rectime;
		private string _recuser;
		private DateTime _lastrectime;
		private string _lastrecuser;
		/// <summary>
		/// 班级编号（自动）
		/// </summary>
		public int ClassId
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 班级编号
		/// </summary>
		public string ClassNo
		{
			set{ _classno=value;}
			get{return _classno;}
		}
		/// <summary>
		/// 班级名称
		/// </summary>
		public string ClassName
		{
			set{ _classname=value;}
			get{return _classname;}
		}
		/// <summary>
		/// 年级编号
		/// </summary>
		public int GradeId
		{
			set{ _gradeid=value;}
			get{return _gradeid;}
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
		/// 是否完成
		/// </summary>
		public int IsFinish
		{
			set{ _isfinish=value;}
			get{return _isfinish;}
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
		/// 记录者
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

