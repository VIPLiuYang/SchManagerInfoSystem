using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
namespace SchSystem.DAL
{
	/// <summary>
	/// 数据访问类:SchApp
	/// </summary>
	public partial class SchApp
	{
		public SchApp()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("AutoId", "SchApp"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AutoId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SchApp");
			strSql.Append(" where AutoId=@AutoId");
			SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
			parameters[0].Value = AutoId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(SchSystem.Model.SchApp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SchApp(");
			strSql.Append("AppCode,AppName,Stat,RecTime,RecUser,LastRecTime,LastRecUser)");
			strSql.Append(" values (");
			strSql.Append("@AppCode,@AppName,@Stat,@RecTime,@RecUser,@LastRecTime,@LastRecUser)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@AppCode", SqlDbType.Int,4),
					new SqlParameter("@AppName", SqlDbType.NVarChar,50),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@RecTime", SqlDbType.SmallDateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,50),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20)};
			parameters[0].Value = model.AppCode;
			parameters[1].Value = model.AppName;
			parameters[2].Value = model.Stat;
			parameters[3].Value = model.RecTime;
			parameters[4].Value = model.RecUser;
			parameters[5].Value = model.LastRecTime;
			parameters[6].Value = model.LastRecUser;

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
        public bool Update(SchSystem.Model.SchApp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SchApp set ");
			strSql.Append("AppCode=@AppCode,");
			strSql.Append("AppName=@AppName,");
			strSql.Append("Stat=@Stat,");
			strSql.Append("RecTime=@RecTime,");
			strSql.Append("RecUser=@RecUser,");
			strSql.Append("LastRecTime=@LastRecTime,");
			strSql.Append("LastRecUser=@LastRecUser");
			strSql.Append(" where AutoId=@AutoId");
			SqlParameter[] parameters = {
					new SqlParameter("@AppCode", SqlDbType.Int,4),
					new SqlParameter("@AppName", SqlDbType.NVarChar,50),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@RecTime", SqlDbType.SmallDateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,50),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@AutoId", SqlDbType.Int,4)};
			parameters[0].Value = model.AppCode;
			parameters[1].Value = model.AppName;
			parameters[2].Value = model.Stat;
			parameters[3].Value = model.RecTime;
			parameters[4].Value = model.RecUser;
			parameters[5].Value = model.LastRecTime;
			parameters[6].Value = model.LastRecUser;
			parameters[7].Value = model.AutoId;

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
			strSql.Append("delete from SchApp ");
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
			strSql.Append("delete from SchApp ");
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
		/// 得到一个对象实体
		/// </summary>
        public SchSystem.Model.SchApp GetModel(int AutoId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AutoId,AppCode,AppName,Stat,RecTime,RecUser,LastRecTime,LastRecUser from SchApp ");
			strSql.Append(" where AutoId=@AutoId");
			SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
			parameters[0].Value = AutoId;

            SchSystem.Model.SchApp model = new SchSystem.Model.SchApp();
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
        public SchSystem.Model.SchApp DataRowToModel(DataRow row)
		{
            SchSystem.Model.SchApp model = new SchSystem.Model.SchApp();
			if (row != null)
			{
				if(row["AutoId"]!=null && row["AutoId"].ToString()!="")
				{
					model.AutoId=int.Parse(row["AutoId"].ToString());
				}
				if(row["AppCode"]!=null && row["AppCode"].ToString()!="")
				{
					model.AppCode=int.Parse(row["AppCode"].ToString());
				}
				if(row["AppName"]!=null)
				{
					model.AppName=row["AppName"].ToString();
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

		/// <summary>
        /// 获得数据列表: AutoId,AppCode,AppName,Stat,RecTime,RecUser,LastRecTime,LastRecUser
		/// </summary>
		public DataSet GetList(string cols,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
            if (cols.Trim() != "")
            {
                strSql.Append(cols);
            }
			strSql.Append(" FROM SchApp ");
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
			strSql.Append(" AutoId,AppCode,AppName,Stat,RecTime,RecUser,LastRecTime,LastRecUser ");
			strSql.Append(" FROM SchApp ");
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
			strSql.Append("select count(1) FROM SchApp ");
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
			strSql.Append(")AS Row, T.*  from SchApp T ");
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
			parameters[0].Value = "SchApp";
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

		#endregion  ExtensionMethod
	}
}

