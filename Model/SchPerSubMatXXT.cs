using System;
namespace SchSystem.Model
{
	/// <summary>
	/// SchPerSubMatXXT:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SchPerSubMatXXT
	{
		public SchPerSubMatXXT()
		{}
		#region Model
		private int _autoid;
		private string _percode;
		private string _subcode;
		private string _matercode;
		private int _schid;
		/// <summary>
		/// 资源平台学校学段科目对应表
		/// </summary>
		public int AutoId
		{
			set{ _autoid=value;}
			get{return _autoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PerCode
		{
			set{ _percode=value;}
			get{return _percode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SubCode
		{
			set{ _subcode=value;}
			get{return _subcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MaterCode
		{
			set{ _matercode=value;}
			get{return _matercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SchId
		{
			set{ _schid=value;}
			get{return _schid;}
		}
		#endregion Model

	}
}

