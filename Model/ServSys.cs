using System;
namespace SchSystem.Model
{
	/// <summary>
	/// ServSys:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ServSys
	{
		public ServSys()
		{}
		#region Model
		private int _autoid;
		private string _sysname;
		private string _syscode;
		private string _sysurl;
		/// <summary>
		/// 平台列表
		/// </summary>
		public int AutoId
		{
			set{ _autoid=value;}
			get{return _autoid;}
		}
		/// <summary>
		/// 平台名称
		/// </summary>
		public string SysName
		{
			set{ _sysname=value;}
			get{return _sysname;}
		}
		/// <summary>
		/// 平台代码
		/// </summary>
		public string SysCode
		{
			set{ _syscode=value;}
			get{return _syscode;}
		}
		/// <summary>
		/// 平台URL
		/// </summary>
		public string SysUrl
		{
			set{ _sysurl=value;}
			get{return _sysurl;}
		}
		#endregion Model

	}
}

