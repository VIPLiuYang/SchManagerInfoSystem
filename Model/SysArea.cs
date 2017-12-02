using System;
namespace SchSystem.Model
{
	/// <summary>
    /// SysArea:实体类中国行政区三级联动
	/// </summary>
	[Serializable]
	public partial class SysArea
	{
		public SysArea()
		{}
		#region Model
		private int _tabid;
		private string _areacode;
		private string _areaname;
		private int _typecode;
		private int _stat;
		/// <summary>
		/// 区域表
		/// </summary>
		public int Tabid
		{
			set{ _tabid=value;}
			get{return _tabid;}
		}
		/// <summary>
		/// 区域代码
		/// </summary>
		public string AreaCode
		{
			set{ _areacode=value;}
			get{return _areacode;}
		}
		/// <summary>
		/// 区域名称
		/// </summary>
		public string AreaName
		{
			set{ _areaname=value;}
			get{return _areaname;}
		}
		/// <summary>
		/// 区域类型(省0市1区县2)
		/// </summary>
		public int TypeCode
		{
			set{ _typecode=value;}
			get{return _typecode;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int Stat
		{
			set{ _stat=value;}
			get{return _stat;}
		}
		#endregion Model

	}
}

