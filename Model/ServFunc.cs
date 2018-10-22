using System;
namespace SchSystem.Model
{
	/// <summary>
	/// ServFunc:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ServFunc
	{
		public ServFunc()
		{}
		#region Model
		private int _autoid;
		private string _funcname;
		private string _funccode;
		private string _typecode;
		private string _funcrange;
		private string _funcset;
		private string _funcnote;
		private string _funcsyss;
		private string _funcdes;
		/// <summary>
		/// 业务功能表
		/// </summary>
		public int AutoId
		{
			set{ _autoid=value;}
			get{return _autoid;}
		}
		/// <summary>
		/// 功能名称
		/// </summary>
		public string FuncName
		{
			set{ _funcname=value;}
			get{return _funcname;}
		}
		/// <summary>
		/// 功能代码
		/// </summary>
		public string FuncCode
		{
			set{ _funccode=value;}
			get{return _funccode;}
		}
		/// <summary>
		/// 所属业务类型
		/// </summary>
		public string TypeCode
		{
			set{ _typecode=value;}
			get{return _typecode;}
		}
		/// <summary>
		/// 范围说明
		/// </summary>
		public string FuncRange
		{
			set{ _funcrange=value;}
			get{return _funcrange;}
		}
		/// <summary>
		/// 设置说明
		/// </summary>
		public string FuncSet
		{
			set{ _funcset=value;}
			get{return _funcset;}
		}
		/// <summary>
		/// 功能备注
		/// </summary>
		public string FuncNote
		{
			set{ _funcnote=value;}
			get{return _funcnote;}
		}
		/// <summary>
		/// 关联平台,多个代码之间用,号隔开
		/// </summary>
		public string FuncSyss
		{
			set{ _funcsyss=value;}
			get{return _funcsyss;}
		}
		/// <summary>
		/// 功能描述
		/// </summary>
		public string FuncDes
		{
			set{ _funcdes=value;}
			get{return _funcdes;}
		}
		#endregion Model

	}
}

