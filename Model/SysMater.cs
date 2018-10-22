/**  版本信息模板在安装目录下，可自行修改。
* SysMater.cs
*
* 功 能： N/A
* 类 名： SysMater
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018-4-9 16:32   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace SchSystem.Model
{
	/// <summary>
	/// SysMater:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SysMater
	{
		public SysMater()
		{}
		#region Model
		private int _autoid;
		private string _matername;
		private string _matercode;
		private int _stat=1;
		/// <summary>
		/// 教版表
		/// </summary>
		public int AutoId
		{
			set{ _autoid=value;}
			get{return _autoid;}
		}
		/// <summary>
		/// 教版名称
		/// </summary>
		public string MaterName
		{
			set{ _matername=value;}
			get{return _matername;}
		}
		/// <summary>
		/// 教版代码
		/// </summary>
		public string MaterCode
		{
			set{ _matercode=value;}
			get{return _matercode;}
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

