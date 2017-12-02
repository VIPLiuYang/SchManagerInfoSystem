using System;
namespace SchSystem.Model
{
	/// <summary>
    /// SchStuGenUn:实体类(学生与家长关联表)
	/// </summary>
	[Serializable]
	public partial class SchStuGenUn
	{
		public SchStuGenUn()
		{}
		#region Model
		private int _unid;
		private int _stuid;
		private int _genid;
		private string _relation;
		/// <summary>
		/// 学生与家长关联表
		/// </summary>
		public int UnId
		{
			set{ _unid=value;}
			get{return _unid;}
		}
		/// <summary>
		/// 学生ID
		/// </summary>
		public int StuId
		{
			set{ _stuid=value;}
			get{return _stuid;}
		}
		/// <summary>
		/// 家长ID
		/// </summary>
		public int GenId
		{
			set{ _genid=value;}
			get{return _genid;}
		}
		/// <summary>
		/// 关系
		/// </summary>
		public string Relation
		{
			set{ _relation=value;}
			get{return _relation;}
		}
		#endregion Model

	}
}

