using System;
namespace SchSystem.Model
{
	/// <summary>
    /// SchInfo:实体类(学校信息表)
	/// </summary>
	[Serializable]
	public partial class SchInfo
	{
		public SchInfo()
		{}
		#region Model
		private int _schid;
		private string _schno;
		private string _schname;
		private int _schtype;
		private string _areano;
		private string _schmaster;
		private int _schyear;
		private string _schaddr;
		private string _schtel;
		private int _schlv;
		private int _iscity=1;
		private DateTime _rectime;
		private string _recuser;
		private DateTime _lastrectime;
		private string _lastrecuser;
		private int _stat;
		/// <summary>
		/// 学校信息表,区域代码+4位顺序码
		/// </summary>
		public int SchId
		{
			set{ _schid=value;}
			get{return _schid;}
		}
		/// <summary>
		/// 学校代码
		/// </summary>
		public string SchNo
		{
			set{ _schno=value;}
			get{return _schno;}
		}
		/// <summary>
		/// 学校名称
		/// </summary>
		public string SchName
		{
			set{ _schname=value;}
			get{return _schname;}
		}
		/// <summary>
		/// 学校类型:学校类型表代码
		/// </summary>
		public int SchType
		{
			set{ _schtype=value;}
			get{return _schtype;}
		}
		/// <summary>
		/// 区域编码,此决定学校所在区域等级,省级市级或者区县级
		/// </summary>
		public string AreaNo
		{
			set{ _areano=value;}
			get{return _areano;}
		}
		/// <summary>
		/// 学校联系人
		/// </summary>
		public string SchMaster
		{
			set{ _schmaster=value;}
			get{return _schmaster;}
		}
		/// <summary>
		/// 学年制
		/// </summary>
		public int SchYear
		{
			set{ _schyear=value;}
			get{return _schyear;}
		}
		/// <summary>
		/// 学校地址
		/// </summary>
		public string SchAddr
		{
			set{ _schaddr=value;}
			get{return _schaddr;}
		}
		/// <summary>
		/// 学校联系电话
		/// </summary>
		public string SchTel
		{
			set{ _schtel=value;}
			get{return _schtel;}
		}
		/// <summary>
		/// 学校类型:0普通学校,1教育局
		/// </summary>
		public int SchLv
		{
			set{ _schlv=value;}
			get{return _schlv;}
		}
		/// <summary>
		/// 是否为城区学校,1是,0否,2未知
		/// </summary>
		public int IsCity
		{
			set{ _iscity=value;}
			get{return _iscity;}
		}
		/// <summary>
		/// 记录时间
		/// </summary>
		public DateTime RecTime
		{
			set{ _rectime=value;}
			get{return _rectime;}
		}
		/// <summary>
		/// 记录者
		/// </summary>
		public string RecUser
		{
			set{ _recuser=value;}
			get{return _recuser;}
		}
		/// <summary>
		/// 最后编辑时间
		/// </summary>
		public DateTime LastRecTime
		{
			set{ _lastrectime=value;}
			get{return _lastrectime;}
		}
		/// <summary>
		/// 最后编辑人
		/// </summary>
		public string LastRecUser
		{
			set{ _lastrecuser=value;}
			get{return _lastrecuser;}
		}
		/// <summary>
		/// 状态,0废弃,1正常
		/// </summary>
		public int Stat
		{
			set{ _stat=value;}
			get{return _stat;}
		}
		#endregion Model

	}
}

