
using System;
namespace SchSystem.Model
{
	/// <summary>
	/// SysUType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SysUType
	{
		public SysUType()
		{}
		#region Model
		private int _autoid;
		private string _utypename;
		private string _utypecode;
		private int _stat=1;
		/// <summary>
		/// 计费系统功能用户角色表
		/// </summary>
		public int AutoId
		{
			set{ _autoid=value;}
			get{return _autoid;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string UTypeName
		{
			set{ _utypename=value;}
			get{return _utypename;}
		}
		/// <summary>
		/// 代码
		/// </summary>
		public string UTypeCode
		{
			set{ _utypecode=value;}
			get{return _utypecode;}
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

