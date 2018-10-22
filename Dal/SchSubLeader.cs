using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
namespace SchSystem.DAL
{
	/// <summary>
	/// 数据访问类:SchSubLeader
	/// </summary>
	public partial class SchSubLeader
	{
		public SchSubLeader()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("AutoId", "SchSubLeader"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AutoId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SchSubLeader");
			strSql.Append(" where AutoId=@AutoId");
			SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
			parameters[0].Value = AutoId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="GradeId">科目ID</param>
        /// <param name="RecUser"></param>
        /// <param name="SchId"></param>
        /// <param name="UserIds">组长ID</param>
        /// <returns></returns>
        public int DoUserSubLeader(string GradeId, string RecUser, string SchId, string UserIds)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SchSubLeader where SubCode='" + GradeId+"' and SchId='"+SchId+"'");
            if (UserIds != "")
            {
                strSql.Append(" insert into SchSubLeader(SchId,SubCode,UserName,UserTname,LastRecTime,LastRecUser,Stat)");
                //strSql.Append(" select '" + SchId + "','" + GradeId + "',AutoId,UserTname,getdate(),'" + RecUser + "','1' from SchClassUserSubV where SchId=" + SchId + " and AutoId in (" + UserIds + ")");
                strSql.Append("select '" + SchId + "','" + GradeId + "',UserId,UserTname,getdate(),'" + RecUser + "','1' from SchUserInfo where SchId=" + SchId + " and UserId in (" + UserIds + ")");
            }
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SchSystem.Model.SchSubLeader model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SchSubLeader(");
			strSql.Append("ClassId,SchId,SubId,SubCode,UserName,UserTname,Stat,RecTime,RecUser,LastRecTime,LastRecUser)");
			strSql.Append(" values (");
			strSql.Append("@ClassId,@SchId,@SubId,@SubCode,@UserName,@UserTname,@Stat,@RecTime,@RecUser,@LastRecTime,@LastRecUser)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@SubId", SqlDbType.Int,4),
					new SqlParameter("@SubCode", SqlDbType.VarChar,10),
					new SqlParameter("@UserName", SqlDbType.VarChar,30),
					new SqlParameter("@UserTname", SqlDbType.VarChar,20),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,20),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20)};
			parameters[0].Value = model.ClassId;
			parameters[1].Value = model.SchId;
			parameters[2].Value = model.SubId;
			parameters[3].Value = model.SubCode;
			parameters[4].Value = model.UserName;
			parameters[5].Value = model.UserTname;
			parameters[6].Value = model.Stat;
			parameters[7].Value = model.RecTime;
			parameters[8].Value = model.RecUser;
			parameters[9].Value = model.LastRecTime;
			parameters[10].Value = model.LastRecUser;

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
		public bool Update(SchSystem.Model.SchSubLeader model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SchSubLeader set ");
			strSql.Append("ClassId=@ClassId,");
			strSql.Append("SchId=@SchId,");
			strSql.Append("SubId=@SubId,");
			strSql.Append("SubCode=@SubCode,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("UserTname=@UserTname,");
			strSql.Append("Stat=@Stat,");
			strSql.Append("RecTime=@RecTime,");
			strSql.Append("RecUser=@RecUser,");
			strSql.Append("LastRecTime=@LastRecTime,");
			strSql.Append("LastRecUser=@LastRecUser");
			strSql.Append(" where AutoId=@AutoId");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@SubId", SqlDbType.Int,4),
					new SqlParameter("@SubCode", SqlDbType.VarChar,10),
					new SqlParameter("@UserName", SqlDbType.VarChar,30),
					new SqlParameter("@UserTname", SqlDbType.VarChar,20),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,20),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@AutoId", SqlDbType.Int,4)};
			parameters[0].Value = model.ClassId;
			parameters[1].Value = model.SchId;
			parameters[2].Value = model.SubId;
			parameters[3].Value = model.SubCode;
			parameters[4].Value = model.UserName;
			parameters[5].Value = model.UserTname;
			parameters[6].Value = model.Stat;
			parameters[7].Value = model.RecTime;
			parameters[8].Value = model.RecUser;
			parameters[9].Value = model.LastRecTime;
			parameters[10].Value = model.LastRecUser;
			parameters[11].Value = model.AutoId;

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
		public bool Delete(int AutoId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchSubLeader ");
			strSql.Append(" where AutoId=@AutoId");
			SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
			parameters[0].Value = AutoId;

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
		public bool DeleteList(string AutoIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchSubLeader ");
			strSql.Append(" where AutoId in ("+AutoIdlist + ")  ");
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
        /// 获取教师以及科目列表
        /// </summary>
        public DataSet GetListTecSub(string cols, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (cols != "")
            {
                strSql.Append(cols);
            }
            strSql.Append(" from SchSubLeader where SubCode in(select SubCode from SchSub ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(") ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SchSystem.Model.SchSubLeader GetModel(int AutoId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AutoId,ClassId,SchId,SubId,SubCode,UserName,UserTname,Stat,RecTime,RecUser,LastRecTime,LastRecUser from SchSubLeader ");
			strSql.Append(" where AutoId=@AutoId");
			SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
			parameters[0].Value = AutoId;

			SchSystem.Model.SchSubLeader model=new SchSystem.Model.SchSubLeader();
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
		public SchSystem.Model.SchSubLeader DataRowToModel(DataRow row)
		{
			SchSystem.Model.SchSubLeader model=new SchSystem.Model.SchSubLeader();
			if (row != null)
			{
				if(row["AutoId"]!=null && row["AutoId"].ToString()!="")
				{
					model.AutoId=int.Parse(row["AutoId"].ToString());
				}
				if(row["ClassId"]!=null && row["ClassId"].ToString()!="")
				{
					model.ClassId=int.Parse(row["ClassId"].ToString());
				}
				if(row["SchId"]!=null && row["SchId"].ToString()!="")
				{
					model.SchId=int.Parse(row["SchId"].ToString());
				}
				if(row["SubId"]!=null && row["SubId"].ToString()!="")
				{
					model.SubId=int.Parse(row["SubId"].ToString());
				}
				if(row["SubCode"]!=null)
				{
					model.SubCode=row["SubCode"].ToString();
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["UserTname"]!=null)
				{
					model.UserTname=row["UserTname"].ToString();
				}
				if(row["Stat"]!=null && row["Stat"].ToString()!="")
				{
					model.Stat=int.Parse(row["Stat"].ToString());
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
        public DataSet GetListV(string cols, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (cols != "")
            {
                strSql.Append(cols);
            }
            strSql.Append(" FROM SchClassUserSub");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
		/// <summary>
        /// 获得数据列表AutoId,ClassId,SchId,SubId,SubCode,UserName,UserTname,Stat,RecTime,RecUser,LastRecTime,LastRecUser
		/// </summary>
		public DataSet GetList(string cols ,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
            if (cols.Trim() != "")
            {
                strSql.Append(cols);
            }
			strSql.Append(" FROM SchSubLeader ");
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
			strSql.Append(" AutoId,ClassId,SchId,SubId,SubCode,UserName,UserTname,Stat,RecTime,RecUser,LastRecTime,LastRecUser ");
			strSql.Append(" FROM SchSubLeader ");
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
			strSql.Append("select count(1) FROM SchSubLeader ");
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
				strSql.Append("order by T.AutoId desc");
			}
			strSql.Append(")AS Row, T.*  from SchSubLeader T ");
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
			parameters[0].Value = "SchSubLeader";
			parameters[1].Value = "AutoId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        public bool ExistsClassSubUser(string SchId, string SubCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchSubLeader");
            strSql.Append(" where SchId=@SchId and SubCode=@SubCode");
            SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,4),
                    new SqlParameter("@SubCode", SqlDbType.VarChar,10)
			};
            parameters[0].Value = SchId;
            parameters[1].Value = SubCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool ExistsClassSubLeader(string SchId, string UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchSubLeader");
            strSql.Append(" where SchId=@SchId and UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.VarChar,30)
			};
            parameters[0].Value = SchId;
            parameters[1].Value = UserId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
		#endregion  ExtensionMethod
	}
}

