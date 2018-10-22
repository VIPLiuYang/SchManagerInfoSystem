
using System;
namespace SchSystem.Model
{
	/// <summary>
	/// ServSysNape:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ServSysNape
	{
		public ServSysNape()
		{}
		#region Model
		private int _autoid;
		private string _napename;
		private string _napecode;
		private int _stat=1;
		/// <summary>
		/// 功能附加信息下拉列表
		/// </summary>
		public int AutoId
		{
			set{ _autoid=value;}
			get{return _autoid;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string NapeName
		{
			set{ _napename=value;}
			get{return _napename;}
		}
		/// <summary>
		/// 代码
		/// </summary>
		public string NapeCode
		{
			set{ _napecode=value;}
			get{return _napecode;}
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

