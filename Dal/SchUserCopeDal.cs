using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
namespace SchSystem.Dal
{
	/// <summary>
	/// 数据访问类:SchUserCope
	/// </summary>
	public partial class SchUserCopeDal
	{
        public SchUserCopeDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("TabId", "SchUserCope"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TabId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SchUserCope");
			strSql.Append(" where TabId=@TabId");
			SqlParameter[] parameters = {
					new SqlParameter("@TabId", SqlDbType.Int,4)
			};
			parameters[0].Value = TabId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SchSystem.Model.SchUserCope model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SchUserCope(");
			strSql.Append("SchIds,GradeIds,ClassIds,UserId)");
			strSql.Append(" values (");
			strSql.Append("@SchIds,@GradeIds,@ClassIds,@UserId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SchIds", SqlDbType.VarChar,100),
					new SqlParameter("@GradeIds", SqlDbType.VarChar,500),
					new SqlParameter("@ClassIds", SqlDbType.VarChar,2000),
					new SqlParameter("@UserId", SqlDbType.Int,4)};
			parameters[0].Value = model.SchIds;
			parameters[1].Value = model.GradeIds;
			parameters[2].Value = model.ClassIds;
			parameters[3].Value = model.UserId;

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
		public bool Update(SchSystem.Model.SchUserCope model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SchUserCope set ");
			strSql.Append("SchIds=@SchIds,");
			strSql.Append("GradeIds=@GradeIds,");
			strSql.Append("ClassIds=@ClassIds,");
			strSql.Append("UserId=@UserId");
			strSql.Append(" where TabId=@TabId");
			SqlParameter[] parameters = {
					new SqlParameter("@SchIds", SqlDbType.VarChar,100),
					new SqlParameter("@GradeIds", SqlDbType.VarChar,500),
					new SqlParameter("@ClassIds", SqlDbType.VarChar,2000),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@TabId", SqlDbType.Int,4)};
			parameters[0].Value = model.SchIds;
			parameters[1].Value = model.GradeIds;
			parameters[2].Value = model.ClassIds;
			parameters[3].Value = model.UserId;
			parameters[4].Value = model.TabId;

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
		public bool Delete(int TabId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchUserCope ");
			strSql.Append(" where TabId=@TabId");
			SqlParameter[] parameters = {
					new SqlParameter("@TabId", SqlDbType.Int,4)
			};
			parameters[0].Value = TabId;

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
		public bool DeleteList(string TabIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchUserCope ");
			strSql.Append(" where TabId in ("+TabIdlist + ")  ");
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
		public SchSystem.Model.SchUserCope GetModel(int TabId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TabId,SchIds,GradeIds,ClassIds,UserId from SchUserCope ");
			strSql.Append(" where TabId=@TabId");
			SqlParameter[] parameters = {
					new SqlParameter("@TabId", SqlDbType.Int,4)
			};
			parameters[0].Value = TabId;

			SchSystem.Model.SchUserCope model=new SchSystem.Model.SchUserCope();
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
		public SchSystem.Model.SchUserCope DataRowToModel(DataRow row)
		{
			SchSystem.Model.SchUserCope model=new SchSystem.Model.SchUserCope();
			if (row != null)
			{
				if(row["TabId"]!=null && row["TabId"].ToString()!="")
				{
					model.TabId=int.Parse(row["TabId"].ToString());
				}
				if(row["SchIds"]!=null)
				{
					model.SchIds=row["SchIds"].ToString();
				}
				if(row["GradeIds"]!=null)
				{
					model.GradeIds=row["GradeIds"].ToString();
				}
				if(row["ClassIds"]!=null)
				{
					model.ClassIds=row["ClassIds"].ToString();
				}
				if(row["UserId"]!=null && row["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(row["UserId"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select TabId,SchIds,GradeIds,ClassIds,UserId ");
			strSql.Append(" FROM SchUserCope ");
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
			strSql.Append(" TabId,SchIds,GradeIds,ClassIds,UserId ");
			strSql.Append(" FROM SchUserCope ");
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
			strSql.Append("select count(1) FROM SchUserCope ");
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
				strSql.Append("order by T.TabId desc");
			}
			strSql.Append(")AS Row, T.*  from SchUserCope T ");
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
			parameters[0].Value = "SchUserCope";
			parameters[1].Value = "TabId";
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

