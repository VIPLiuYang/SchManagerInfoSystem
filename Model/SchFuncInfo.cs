using System;
namespace SchSystem.Model
{
	/// <summary>
    /// SchFuncInfo:实体类(功能码)
	/// </summary>
	[Serializable]
	public partial class SchFuncInfo
	{
		public SchFuncInfo()
		{}
		#region Model
		private int _funcid;
		private int _pid;
		private string _funcname;
		private int _funccode;
		private string _functype;
		private string _funclv;
		private int _isdaily;
		private int _orderid;
		private string _note;
		private int _stat=1;
		/// <summary>
		/// 功能码
		/// </summary>
		public int FuncId
		{
			set{ _funcid=value;}
			get{return _funcid;}
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
		/// 功能名称
		/// </summary>
		public string FuncName
		{
			set{ _funcname=value;}
			get{return _funcname;}
		}
		/// <summary>
		/// 功能码
		/// </summary>
		public int FuncCode
		{
			set{ _funccode=value;}
			get{return _funccode;}
		}
		/// <summary>
		/// 功能类型
		/// </summary>
		public string FuncType
		{
			set{ _functype=value;}
			get{return _functype;}
		}
		/// <summary>
		/// 功能分类
		/// </summary>
		public string FuncLv
		{
			set{ _funclv=value;}
			get{return _funclv;}
		}
		/// <summary>
		/// 是否进行日志
		/// </summary>
		public int IsDaily
		{
			set{ _isdaily=value;}
			get{return _isdaily;}
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
		/// 备注
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
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

