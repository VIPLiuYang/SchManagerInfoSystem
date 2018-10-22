using System;
namespace SchSystem.Model
{
	/// <summary>
	/// ServBus:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ServBus
	{
		public ServBus()
		{}
		#region Model
		private int _busid;
		private string _serviceid;
		private string _feecode;
		private string _cnname;
		private string _funcstr;
		private int _busmonth;
		private string _busnote;
		private int _bustype;
		private string _busurl;
		private string _note;

        public string BusArea { get; set; }
        public string CapName { get; set; }
        public int FrmType { get; set; }

		/// <summary>
		/// 套餐表
		/// </summary>
		public int BusId
		{
			set{ _busid=value;}
			get{return _busid;}
		}
		/// <summary>
		/// 套餐代码
		/// </summary>
		public string ServiceId
		{
			set{ _serviceid=value;}
			get{return _serviceid;}
		}
		/// <summary>
		/// 费率
		/// </summary>
		public string FeeCode
		{
			set{ _feecode=value;}
			get{return _feecode;}
		}
		/// <summary>
		/// 中文名称
		/// </summary>
		public string CnName
		{
			set{ _cnname=value;}
			get{return _cnname;}
		}
		/// <summary>
		/// 功能串
		/// </summary>
		public string FuncStr
		{
			set{ _funcstr=value;}
			get{return _funcstr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int BusMonth
		{
			set{ _busmonth=value;}
			get{return _busmonth;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BusNote
		{
			set{ _busnote=value;}
			get{return _busnote;}
		}
		/// <summary>
		/// 套餐类型,1自定义套餐,2CP套餐
		/// </summary>
		public int BusType
		{
			set{ _bustype=value;}
			get{return _bustype;}
		}
		/// <summary>
		/// 套餐处理页
		/// </summary>
		public string BusUrl
		{
			set{ _busurl=value;}
			get{return _busurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		#endregion Model

	}
}

