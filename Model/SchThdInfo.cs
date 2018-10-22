using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace SchSystem.Model
{
	/// <summary>
	/// SchThdInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SchThdInfo
	{
		public SchThdInfo()
		{}
		#region Model
		private int _autoid;
		private int _schid;
		private string _sysname;
		private string _sysurl;
		private string _sysusernametips;
		private string _sysuserpwtips;
		private string _sysloginurl;
		private DateTime? _rectime= DateTime.Now;
		private string _recuser;
		private DateTime? _lastrectime;
		private string _lastrecuser;
		/// <summary>
		/// 学校第三方系统
		/// </summary>
		public int AutoId
		{
			set{ _autoid=value;}
			get{return _autoid;}
		}
		/// <summary>
		/// 学校ID
		/// </summary>
		public int SchId
		{
			set{ _schid=value;}
			get{return _schid;}
		}
		/// <summary>
		/// 系统名称
		/// </summary>
		public string SysName
		{
			set{ _sysname=value;}
			get{return _sysname;}
		}
		/// <summary>
		/// 系统域名或IP
		/// </summary>
		public string SysUrl
		{
			set{ _sysurl=value;}
			get{return _sysurl;}
		}
		/// <summary>
		/// 登录框用户标识
		/// </summary>
		public string SysUserNameTips
		{
			set{ _sysusernametips=value;}
			get{return _sysusernametips;}
		}
		/// <summary>
		/// 登录框密码标识
		/// </summary>
		public string SysUserPwTips
		{
			set{ _sysuserpwtips=value;}
			get{return _sysuserpwtips;}
		}
		/// <summary>
		/// 登录框地址
		/// </summary>
		public string SysLoginUrl
		{
			set{ _sysloginurl=value;}
			get{return _sysloginurl;}
		}
		/// <summary>
		/// 记录时间
		/// </summary>
		public DateTime? RecTime
		{
			set{ _rectime=value;}
			get{return _rectime;}
		}
		/// <summary>
		/// 记录日
		/// </summary>
		public string RecUser
		{
			set{ _recuser=value;}
			get{return _recuser;}
		}
		/// <summary>
		/// 最后编辑时间
		/// </summary>
		public DateTime? LastRecTime
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
		#endregion Model

	}
}

