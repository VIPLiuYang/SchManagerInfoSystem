using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
namespace SchSystem.Dal
{
	/// <summary>
	/// 数据访问类:SchGradeInfo
	/// </summary>
	public partial class SchGradeInfoDal
	{
        public SchGradeInfoDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("GradeId", "SchGradeInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int GradeId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SchGradeInfo");
			strSql.Append(" where GradeId=@GradeId");
			SqlParameter[] parameters = {
					new SqlParameter("@GradeId", SqlDbType.Int,4)
			};
			parameters[0].Value = GradeId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SchSystem.Model.SchGradeInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SchGradeInfo(");
			strSql.Append("GradeYear,GradeCode,GradeName,SchId,IsFinish,RecTime,RecUser,LastRecTime,LastRecUser)");
			strSql.Append(" values (");
			strSql.Append("@GradeYear,@GradeCode,@GradeName,@SchId,@IsFinish,@RecTime,@RecUser,@LastRecTime,@LastRecUser)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@GradeYear", SqlDbType.VarChar,4),
					new SqlParameter("@GradeCode", SqlDbType.VarChar,2),
					new SqlParameter("@GradeName", SqlDbType.VarChar,40),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@IsFinish", SqlDbType.TinyInt,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,20),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20)};
			parameters[0].Value = model.GradeYear;
			parameters[1].Value = model.GradeCode;
			parameters[2].Value = model.GradeName;
			parameters[3].Value = model.SchId;
			parameters[4].Value = model.IsFinish;
			parameters[5].Value = model.RecTime;
			parameters[6].Value = model.RecUser;
			parameters[7].Value = model.LastRecTime;
			parameters[8].Value = model.LastRecUser;

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
		public bool Update(SchSystem.Model.SchGradeInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SchGradeInfo set ");
			strSql.Append("GradeYear=@GradeYear,");
			strSql.Append("GradeCode=@GradeCode,");
			strSql.Append("GradeName=@GradeName,");
			strSql.Append("SchId=@SchId,");
			strSql.Append("IsFinish=@IsFinish,");
			strSql.Append("RecTime=@RecTime,");
			strSql.Append("RecUser=@RecUser,");
			strSql.Append("LastRecTime=@LastRecTime,");
			strSql.Append("LastRecUser=@LastRecUser");
			strSql.Append(" where GradeId=@GradeId");
			SqlParameter[] parameters = {
					new SqlParameter("@GradeYear", SqlDbType.VarChar,4),
					new SqlParameter("@GradeCode", SqlDbType.VarChar,2),
					new SqlParameter("@GradeName", SqlDbType.VarChar,40),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@IsFinish", SqlDbType.TinyInt,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,20),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@GradeId", SqlDbType.Int,4)};
			parameters[0].Value = model.GradeYear;
			parameters[1].Value = model.GradeCode;
			parameters[2].Value = model.GradeName;
			parameters[3].Value = model.SchId;
			parameters[4].Value = model.IsFinish;
			parameters[5].Value = model.RecTime;
			parameters[6].Value = model.RecUser;
			parameters[7].Value = model.LastRecTime;
			parameters[8].Value = model.LastRecUser;
			parameters[9].Value = model.GradeId;

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
		public bool Delete(int GradeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchGradeInfo ");
			strSql.Append(" where GradeId=@GradeId");
			SqlParameter[] parameters = {
					new SqlParameter("@GradeId", SqlDbType.Int,4)
			};
			parameters[0].Value = GradeId;

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
		public bool DeleteList(string GradeIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchGradeInfo ");
			strSql.Append(" where GradeId in ("+GradeIdlist + ")  ");
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
		public SchSystem.Model.SchGradeInfo GetModel(int GradeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 GradeId,GradeYear,GradeCode,GradeName,SchId,IsFinish,RecTime,RecUser,LastRecTime,LastRecUser from SchGradeInfo ");
			strSql.Append(" where GradeId=@GradeId");
			SqlParameter[] parameters = {
					new SqlParameter("@GradeId", SqlDbType.Int,4)
			};
			parameters[0].Value = GradeId;

			SchSystem.Model.SchGradeInfo model=new SchSystem.Model.SchGradeInfo();
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
		public SchSystem.Model.SchGradeInfo DataRowToModel(DataRow row)
		{
			SchSystem.Model.SchGradeInfo model=new SchSystem.Model.SchGradeInfo();
			if (row != null)
			{
				if(row["GradeId"]!=null && row["GradeId"].ToString()!="")
				{
					model.GradeId=int.Parse(row["GradeId"].ToString());
				}
				if(row["GradeYear"]!=null)
				{
					model.GradeYear=row["GradeYear"].ToString();
				}
				if(row["GradeCode"]!=null)
				{
					model.GradeCode=row["GradeCode"].ToString();
				}
				if(row["GradeName"]!=null)
				{
					model.GradeName=row["GradeName"].ToString();
				}
				if(row["SchId"]!=null && row["SchId"].ToString()!="")
				{
					model.SchId=int.Parse(row["SchId"].ToString());
				}
				if(row["IsFinish"]!=null && row["IsFinish"].ToString()!="")
				{
					model.IsFinish=int.Parse(row["IsFinish"].ToString());
				}
				if(row["RecTime"]!=null && row["RecTime"].ToString()!="")
				{
					model.RecTime=DateTime.Parse(row["RecTime"].ToString());
				}
				if(row["RecUser"]!=null)
				{
					model.RecUser=row["RecUser"].ToString();
				}
				if(row["LastRecTime"]!=null && row["LastRecTime"].ToString()!="")
				{
					model.LastRecTime=DateTime.Parse(row["LastRecTime"].ToString());
				}
				if(row["LastRecUser"]!=null)
				{
					model.LastRecUser=row["LastRecUser"].ToString();
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
			strSql.Append("select GradeId,GradeYear,GradeCode,GradeName,SchId,IsFinish,RecTime,RecUser,LastRecTime,LastRecUser ");
			strSql.Append(" FROM SchGradeInfo ");
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
			strSql.Append(" GradeId,GradeYear,GradeCode,GradeName,SchId,IsFinish,RecTime,RecUser,LastRecTime,LastRecUser ");
			strSql.Append(" FROM SchGradeInfo ");
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
			strSql.Append("select count(1) FROM SchGradeInfo ");
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
				strSql.Append("order by T.GradeId desc");
			}
			strSql.Append(")AS Row, T.*  from SchGradeInfo T ");
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
			parameters[0].Value = "SchGradeInfo";
			parameters[1].Value = "GradeId";
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

