using System;
namespace SchSystem.Model
{
	/// <summary>
	/// ServBusThd:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ServBusThd
	{
		public ServBusThd()
		{}
		#region Model
		private int _busid;
		private string _thdname;
		private string _serviceid;
		private string _feecode;
		private string _cnname;
		private int _busmonth;
		private string _busnote;
		private string _busarea;
		private int _busutype;
		private int _mbusid;
		private int _bustype;
		private string _busurl;
		private string _note;
        private int _thdmonth;
		/// <summary>
		/// 套餐表
		/// </summary>
		public int BusId
		{
			set{ _busid=value;}
			get{return _busid;}
		}
     
		/// <summary>
		/// 
		/// </summary>
		public string ThdName
		{
			set{ _thdname=value;}
			get{return _thdname;}
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
		/// 
		/// </summary>
		public string BusArea
		{
			set{ _busarea=value;}
			get{return _busarea;}
		}
		/// <summary>
		/// 适用用户类型,1老师,2家长,3学生
		/// </summary>
		public int BusUtype
		{
			set{ _busutype=value;}
			get{return _busutype;}
		}
		/// <summary>
		/// 对应的自定义套餐ID
		/// </summary>
		public int Mbusid
		{
			set{ _mbusid=value;}
			get{return _mbusid;}
		}
		/// <summary>
		/// 套餐类型,1 自定义套餐,2 CP套餐
		/// </summary>
		public int BusType
		{
			set{ _bustype=value;}
			get{return _bustype;}
		}
		/// <summary>
		/// 套餐处理页,不在前台显示,仅做程序后台处理
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
        /// <summary>
        /// 默认订购时长
        /// </summary>
        public int ThdMonth
        {
            set { _thdmonth = value; }
            get { return _thdmonth; }
        }
		#endregion Model

	}
}

