/**  版本信息模板在安装目录下，可自行修改。
* SysFasc.cs
*
* 功 能： N/A
* 类 名： SysFasc
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
	/// SysFasc:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SysFasc
	{
		public SysFasc()
		{}
		#region Model
		private int _autoid;
		private string _fascname;
		private string _fasccode;
		private int _stat=1;
		/// <summary>
		/// 分册表
		/// </summary>
		public int AutoId
		{
			set{ _autoid=value;}
			get{return _autoid;}
		}
		/// <summary>
		/// 分册名称
		/// </summary>
		public string FascName
		{
			set{ _fascname=value;}
			get{return _fascname;}
		}
		/// <summary>
		/// 分册代码
		/// </summary>
		public string FascCode
		{
			set{ _fasccode=value;}
			get{return _fasccode;}
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

