using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
namespace SchSystem.Dal
{
	/// <summary>
	/// 数据访问类:SchInfo
	/// </summary>
	public partial class SchInfoDal
	{
        public SchInfoDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SchId", "SchInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SchId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SchInfo");
			strSql.Append(" where SchId=@SchId ");
			SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,4)			};
			parameters[0].Value = SchId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(SchSystem.Model.SchInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SchInfo(");
			strSql.Append("SchId,SchNo,SchName,SchType,AreaNo,SchMaster,SchYear,SchAddr,SchTel,SchLv,IsCity,RecTime,RecUser,LastRecTime,LastRecUser,Stat)");
			strSql.Append(" values (");
			strSql.Append("@SchId,@SchNo,@SchName,@SchType,@AreaNo,@SchMaster,@SchYear,@SchAddr,@SchTel,@SchLv,@IsCity,@RecTime,@RecUser,@LastRecTime,@LastRecUser,@Stat)");
			SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@SchNo", SqlDbType.VarChar,10),
					new SqlParameter("@SchName", SqlDbType.VarChar,50),
					new SqlParameter("@SchType", SqlDbType.SmallInt,2),
					new SqlParameter("@AreaNo", SqlDbType.VarChar,8),
					new SqlParameter("@SchMaster", SqlDbType.VarChar,20),
					new SqlParameter("@SchYear", SqlDbType.TinyInt,1),
					new SqlParameter("@SchAddr", SqlDbType.VarChar,200),
					new SqlParameter("@SchTel", SqlDbType.VarChar,20),
					new SqlParameter("@SchLv", SqlDbType.TinyInt,1),
					new SqlParameter("@IsCity", SqlDbType.TinyInt,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,20),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1)};
			parameters[0].Value = model.SchId;
			parameters[1].Value = model.SchNo;
			parameters[2].Value = model.SchName;
			parameters[3].Value = model.SchType;
			parameters[4].Value = model.AreaNo;
			parameters[5].Value = model.SchMaster;
			parameters[6].Value = model.SchYear;
			parameters[7].Value = model.SchAddr;
			parameters[8].Value = model.SchTel;
			parameters[9].Value = model.SchLv;
			parameters[10].Value = model.IsCity;
			parameters[11].Value = model.RecTime;
			parameters[12].Value = model.RecUser;
			parameters[13].Value = model.LastRecTime;
			parameters[14].Value = model.LastRecUser;
			parameters[15].Value = model.Stat;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(SchSystem.Model.SchInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SchInfo set ");
			strSql.Append("SchNo=@SchNo,");
			strSql.Append("SchName=@SchName,");
			strSql.Append("SchType=@SchType,");
			strSql.Append("AreaNo=@AreaNo,");
			strSql.Append("SchMaster=@SchMaster,");
			strSql.Append("SchYear=@SchYear,");
			strSql.Append("SchAddr=@SchAddr,");
			strSql.Append("SchTel=@SchTel,");
			strSql.Append("SchLv=@SchLv,");
			strSql.Append("IsCity=@IsCity,");
			strSql.Append("RecTime=@RecTime,");
			strSql.Append("RecUser=@RecUser,");
			strSql.Append("LastRecTime=@LastRecTime,");
			strSql.Append("LastRecUser=@LastRecUser,");
			strSql.Append("Stat=@Stat");
			strSql.Append(" where SchId=@SchId ");
			SqlParameter[] parameters = {
					new SqlParameter("@SchNo", SqlDbType.VarChar,10),
					new SqlParameter("@SchName", SqlDbType.VarChar,50),
					new SqlParameter("@SchType", SqlDbType.SmallInt,2),
					new SqlParameter("@AreaNo", SqlDbType.VarChar,8),
					new SqlParameter("@SchMaster", SqlDbType.VarChar,20),
					new SqlParameter("@SchYear", SqlDbType.TinyInt,1),
					new SqlParameter("@SchAddr", SqlDbType.VarChar,200),
					new SqlParameter("@SchTel", SqlDbType.VarChar,20),
					new SqlParameter("@SchLv", SqlDbType.TinyInt,1),
					new SqlParameter("@IsCity", SqlDbType.TinyInt,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,20),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@SchId", SqlDbType.Int,4)};
			parameters[0].Value = model.SchNo;
			parameters[1].Value = model.SchName;
			parameters[2].Value = model.SchType;
			parameters[3].Value = model.AreaNo;
			parameters[4].Value = model.SchMaster;
			parameters[5].Value = model.SchYear;
			parameters[6].Value = model.SchAddr;
			parameters[7].Value = model.SchTel;
			parameters[8].Value = model.SchLv;
			parameters[9].Value = model.IsCity;
			parameters[10].Value = model.RecTime;
			parameters[11].Value = model.RecUser;
			parameters[12].Value = model.LastRecTime;
			parameters[13].Value = model.LastRecUser;
			parameters[14].Value = model.Stat;
			parameters[15].Value = model.SchId;

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
		public bool Delete(int SchId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchInfo ");
			strSql.Append(" where SchId=@SchId ");
			SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,4)			};
			parameters[0].Value = SchId;

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
		public bool DeleteList(string SchIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchInfo ");
			strSql.Append(" where SchId in ("+SchIdlist + ")  ");
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
		public SchSystem.Model.SchInfo GetModel(int SchId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SchId,SchNo,SchName,SchType,AreaNo,SchMaster,SchYear,SchAddr,SchTel,SchLv,IsCity,RecTime,RecUser,LastRecTime,LastRecUser,Stat from SchInfo ");
			strSql.Append(" where SchId=@SchId ");
			SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,4)			};
			parameters[0].Value = SchId;

			SchSystem.Model.SchInfo model=new SchSystem.Model.SchInfo();
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
		public SchSystem.Model.SchInfo DataRowToModel(DataRow row)
		{
			SchSystem.Model.SchInfo model=new SchSystem.Model.SchInfo();
			if (row != null)
			{
				if(row["SchId"]!=null && row["SchId"].ToString()!="")
				{
					model.SchId=int.Parse(row["SchId"].ToString());
				}
				if(row["SchNo"]!=null)
				{
					model.SchNo=row["SchNo"].ToString();
				}
				if(row["SchName"]!=null)
				{
					model.SchName=row["SchName"].ToString();
				}
				if(row["SchType"]!=null && row["SchType"].ToString()!="")
				{
					model.SchType=int.Parse(row["SchType"].ToString());
				}
				if(row["AreaNo"]!=null)
				{
					model.AreaNo=row["AreaNo"].ToString();
				}
				if(row["SchMaster"]!=null)
				{
					model.SchMaster=row["SchMaster"].ToString();
				}
				if(row["SchYear"]!=null && row["SchYear"].ToString()!="")
				{
					model.SchYear=int.Parse(row["SchYear"].ToString());
				}
				if(row["SchAddr"]!=null)
				{
					model.SchAddr=row["SchAddr"].ToString();
				}
				if(row["SchTel"]!=null)
				{
					model.SchTel=row["SchTel"].ToString();
				}
				if(row["SchLv"]!=null && row["SchLv"].ToString()!="")
				{
					model.SchLv=int.Parse(row["SchLv"].ToString());
				}
				if(row["IsCity"]!=null && row["IsCity"].ToString()!="")
				{
					model.IsCity=int.Parse(row["IsCity"].ToString());
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
				if(row["Stat"]!=null && row["Stat"].ToString()!="")
				{
					model.Stat=int.Parse(row["Stat"].ToString());
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
			strSql.Append("select SchId,SchNo,SchName,SchType,AreaNo,SchMaster,SchYear,SchAddr,SchTel,SchLv,IsCity,RecTime,RecUser,LastRecTime,LastRecUser,Stat ");
			strSql.Append(" FROM SchInfo ");
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
			strSql.Append(" SchId,SchNo,SchName,SchType,AreaNo,SchMaster,SchYear,SchAddr,SchTel,SchLv,IsCity,RecTime,RecUser,LastRecTime,LastRecUser,Stat ");
			strSql.Append(" FROM SchInfo ");
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
			strSql.Append("select count(1) FROM SchInfo ");
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
				strSql.Append("order by T.SchId desc");
			}
			strSql.Append(")AS Row, T.*  from SchInfo T ");
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
			parameters[0].Value = "SchInfo";
			parameters[1].Value = "SchId";
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

