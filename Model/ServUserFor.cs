using System;
namespace SchSystem.Model
{
	/// <summary>
	/// ServUserFor:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ServUserFor
	{
		public ServUserFor()
		{}
		#region Model
		private int _autoid;
		private string _username;
		private string _fromtype;
		private string _recuser;
		private string _serviceid;
		private int _servstat;
		private int _servmonth;
		private int _feem;
		private DateTime _rectime;
		private DateTime _endtime;
		private DateTime? _edittime;
		private string _donote;
		/// <summary>
		/// 用户订购信息表
		/// </summary>
		public int AutoId
		{
			set{ _autoid=value;}
			get{return _autoid;}
		}
		/// <summary>
		/// 账号
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 来源
		/// </summary>
		public string FromType
		{
			set{ _fromtype=value;}
			get{return _fromtype;}
		}
		/// <summary>
		/// 登记者
		/// </summary>
		public string RecUser
		{
			set{ _recuser=value;}
			get{return _recuser;}
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
		/// 状态
		/// </summary>
		public int ServStat
		{
			set{ _servstat=value;}
			get{return _servstat;}
		}
		/// <summary>
		/// 订购月数
		/// </summary>
		public int ServMonth
		{
			set{ _servmonth=value;}
			get{return _servmonth;}
		}
		/// <summary>
		/// 金额
		/// </summary>
		public int FeeM
		{
			set{ _feem=value;}
			get{return _feem;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime RecTime
		{
			set{ _rectime=value;}
			get{return _rectime;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 状态更改时间
		/// </summary>
		public DateTime? EditTime
		{
			set{ _edittime=value;}
			get{return _edittime;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string DoNote
		{
			set{ _donote=value;}
			get{return _donote;}
		}
		#endregion Model

	}
}

