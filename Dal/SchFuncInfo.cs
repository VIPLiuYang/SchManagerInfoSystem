using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
namespace SchSystem.DAL
{
	/// <summary>
	/// 数据访问类:SchFuncInfo
	/// </summary>
	public partial class SchFuncInfo
	{
        public SchFuncInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("FuncId", "SchFuncInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FuncId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SchFuncInfo");
			strSql.Append(" where FuncId=@FuncId");
			SqlParameter[] parameters = {
					new SqlParameter("@FuncId", SqlDbType.Int,4)
			};
			parameters[0].Value = FuncId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SchSystem.Model.SchFuncInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SchFuncInfo(");
			strSql.Append("Pid,FuncName,FuncCode,FuncType,FuncLv,IsDaily,OrderId,Note,Stat)");
			strSql.Append(" values (");
			strSql.Append("@Pid,@FuncName,@FuncCode,@FuncType,@FuncLv,@IsDaily,@OrderId,@Note,@Stat)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Pid", SqlDbType.Int,4),
					new SqlParameter("@FuncName", SqlDbType.VarChar,30),
					new SqlParameter("@FuncCode", SqlDbType.Int,4),
					new SqlParameter("@FuncType", SqlDbType.VarChar,30),
					new SqlParameter("@FuncLv", SqlDbType.VarChar,10),
					new SqlParameter("@IsDaily", SqlDbType.TinyInt,1),
					new SqlParameter("@OrderId", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.VarChar,100),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1)};
			parameters[0].Value = model.Pid;
			parameters[1].Value = model.FuncName;
			parameters[2].Value = model.FuncCode;
			parameters[3].Value = model.FuncType;
			parameters[4].Value = model.FuncLv;
			parameters[5].Value = model.IsDaily;
			parameters[6].Value = model.OrderId;
			parameters[7].Value = model.Note;
			parameters[8].Value = model.Stat;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SchSystem.Model.SchFuncInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SchFuncInfo set ");
			strSql.Append("Pid=@Pid,");
			strSql.Append("FuncName=@FuncName,");
			strSql.Append("FuncCode=@FuncCode,");
			strSql.Append("FuncType=@FuncType,");
			strSql.Append("FuncLv=@FuncLv,");
			strSql.Append("IsDaily=@IsDaily,");
			strSql.Append("OrderId=@OrderId,");
			strSql.Append("Note=@Note,");
			strSql.Append("Stat=@Stat");
			strSql.Append(" where FuncId=@FuncId");
			SqlParameter[] parameters = {
					new SqlParameter("@Pid", SqlDbType.Int,4),
					new SqlParameter("@FuncName", SqlDbType.VarChar,30),
					new SqlParameter("@FuncCode", SqlDbType.Int,4),
					new SqlParameter("@FuncType", SqlDbType.VarChar,30),
					new SqlParameter("@FuncLv", SqlDbType.VarChar,10),
					new SqlParameter("@IsDaily", SqlDbType.TinyInt,1),
					new SqlParameter("@OrderId", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.VarChar,100),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@FuncId", SqlDbType.Int,4)};
			parameters[0].Value = model.Pid;
			parameters[1].Value = model.FuncName;
			parameters[2].Value = model.FuncCode;
			parameters[3].Value = model.FuncType;
			parameters[4].Value = model.FuncLv;
			parameters[5].Value = model.IsDaily;
			parameters[6].Value = model.OrderId;
			parameters[7].Value = model.Note;
			parameters[8].Value = model.Stat;
			parameters[9].Value = model.FuncId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int FuncId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchFuncInfo ");
			strSql.Append(" where FuncId=@FuncId");
			SqlParameter[] parameters = {
					new SqlParameter("@FuncId", SqlDbType.Int,4)
			};
			parameters[0].Value = FuncId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string FuncIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchFuncInfo ");
			strSql.Append(" where FuncId in ("+FuncIdlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SchSystem.Model.SchFuncInfo GetModel(int FuncId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FuncId,Pid,FuncName,FuncCode,FuncType,FuncLv,IsDaily,OrderId,Note,Stat from SchFuncInfo ");
			strSql.Append(" where FuncId=@FuncId");
			SqlParameter[] parameters = {
					new SqlParameter("@FuncId", SqlDbType.Int,4)
			};
			parameters[0].Value = FuncId;

			SchSystem.Model.SchFuncInfo model=new SchSystem.Model.SchFuncInfo();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SchSystem.Model.SchFuncInfo DataRowToModel(DataRow row)
		{
			SchSystem.Model.SchFuncInfo model=new SchSystem.Model.SchFuncInfo();
			if (row != null)
			{
				if(row["FuncId"]!=null && row["FuncId"].ToString()!="")
				{
					model.FuncId=int.Parse(row["FuncId"].ToString());
				}
				if(row["Pid"]!=null && row["Pid"].ToString()!="")
				{
					model.Pid=int.Parse(row["Pid"].ToString());
				}
				if(row["FuncName"]!=null)
				{
					model.FuncName=row["FuncName"].ToString();
				}
				if(row["FuncCode"]!=null && row["FuncCode"].ToString()!="")
				{
					model.FuncCode=int.Parse(row["FuncCode"].ToString());
				}
				if(row["FuncType"]!=null)
				{
					model.FuncType=row["FuncType"].ToString();
				}
				if(row["FuncLv"]!=null)
				{
					model.FuncLv=row["FuncLv"].ToString();
				}
				if(row["IsDaily"]!=null && row["IsDaily"].ToString()!="")
				{
					model.IsDaily=int.Parse(row["IsDaily"].ToString());
				}
				if(row["OrderId"]!=null && row["OrderId"].ToString()!="")
				{
					model.OrderId=int.Parse(row["OrderId"].ToString());
				}
				if(row["Note"]!=null)
				{
					model.Note=row["Note"].ToString();
				}
				if(row["Stat"]!=null && row["Stat"].ToString()!="")
				{
					model.Stat=int.Parse(row["Stat"].ToString());
				}
			}
			return model;
		}
        public DataSet GetList(string Cols, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + Cols);
            strSql.Append(" FROM SchFuncInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select FuncId,Pid,FuncName,FuncCode,FuncType,FuncLv,IsDaily,OrderId,Note,Stat ");
			strSql.Append(" FROM SchFuncInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" FuncId,Pid,FuncName,FuncCode,FuncType,FuncLv,IsDaily,OrderId,Note,Stat ");
			strSql.Append(" FROM SchFuncInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM SchFuncInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.FuncId desc");
			}
			strSql.Append(")AS Row, T.*  from SchFuncInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "SchFuncInfo";
			parameters[1].Value = "FuncId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

