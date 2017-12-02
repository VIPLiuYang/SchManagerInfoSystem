using System;
namespace SchSystem.Model
{
	/// <summary>
    /// SchType:实体类(学校类型表)
	/// </summary>
	[Serializable]
	public partial class SchType
	{
		public SchType()
		{}
		#region Model
		private int _schtypeid;
		private int _schtypecode;
		private string _schtypename;
		private int _stat=1;
		private string _note;
		/// <summary>
		/// 学校类型表
		/// </summary>
		public int SchTypeId
		{
			set{ _schtypeid=value;}
			get{return _schtypeid;}
		}
		/// <summary>
		/// 学校类型代码
		/// </summary>
		public int SchTypeCode
		{
			set{ _schtypecode=value;}
			get{return _schtypecode;}
		}
		/// <summary>
		/// 类型名称
		/// </summary>
		public string SchTypeName
		{
			set{ _schtypename=value;}
			get{return _schtypename;}
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
		/// 备注
		/// </summary>
		public string NOTE
		{
			set{ _note=value;}
			get{return _note;}
		}
		#endregion Model

	}
}

