using System;
namespace SchSystem.Model
{
	/// <summary>
    /// SchDepartInfo:实体类(学校部门表)
	/// </summary>
	[Serializable]
	public partial class SchDepartInfo
	{
		public SchDepartInfo()
		{}
		#region Model
		private int _departid;
		private string _departname;
		private int _pid;
		private int _orderid;
		private int _schid;
		private int _stat=1;
		private DateTime _rectime= DateTime.Now;
		private string _recuser;
		private DateTime _lastrectime;
		private string _lastrecuser;
		/// <summary>
		/// 学校部门表
		/// </summary>
		public int DepartId
		{
			set{ _departid=value;}
			get{return _departid;}
		}
		/// <summary>
		/// 部门名称
		/// </summary>
		public string DepartName
		{
			set{ _departname=value;}
			get{return _departname;}
		}
		/// <summary>
		/// 父ID
		/// </summary>
		public int Pid
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 排序ID
		/// </summary>
		public int OrderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
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

