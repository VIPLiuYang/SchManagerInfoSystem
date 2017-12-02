using System;
namespace SchSystem.Model
{
	/// <summary>
    /// SchMenuInfo:实体类(菜单表)
	/// </summary>
	[Serializable]
	public partial class SchMenuInfo
	{
		public SchMenuInfo()
		{}
		#region Model
		private int _menuid;
		private int _pid;
		private int _expn;
		private string _navurl;
		private string _selact;
		private string _targets;
		private string _textname;
		private int _funccode;
		private int _orderid;
		private int _stat=1;
		/// <summary>
		/// 菜单表
		/// </summary>
		public int MenuId
		{
			set{ _menuid=value;}
			get{return _menuid;}
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
		/// 是否展开
		/// </summary>
		public int Expn
		{
			set{ _expn=value;}
			get{return _expn;}
		}
		/// <summary>
		/// 连接URL
		/// </summary>
		public string NavUrl
		{
			set{ _navurl=value;}
			get{return _navurl;}
		}
		/// <summary>
		/// 是否被选中
		/// </summary>
		public string SelAct
		{
			set{ _selact=value;}
			get{return _selact;}
		}
		/// <summary>
		/// 打开窗体
		/// </summary>
		public string Targets
		{
			set{ _targets=value;}
			get{return _targets;}
		}
		/// <summary>
		/// 节点名称
		/// </summary>
		public string TextName
		{
			set{ _textname=value;}
			get{return _textname;}
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
		/// 排序ID
		/// </summary>
		public int OrderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
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

