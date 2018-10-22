

using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
namespace SchSystem.DAL
{
	/// <summary>
	/// 数据访问类:SchThdInfo
	/// </summary>
	public partial class SchThdInfo
	{
		public SchThdInfo()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(int schid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SchThdInfo");
			strSql.Append(" where SchId=@SchId");
			SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,6)
			};
            parameters[0].Value = schid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        public bool ExistsSysUrl( string SysUrl, int SchId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchThdInfo ");
            strSql.Append("  where  SchId=@SchId and SysUrl=@SysUrl ");
            SqlParameter[] parameters = {
					new SqlParameter("@SysUrl", SqlDbType.VarChar,20),
					new SqlParameter("@SchId", SqlDbType.Int,4)};
            parameters[0].Value = SysUrl;
            parameters[1].Value = SchId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }




        /// <summary>
        /// 数据分页
        /// </summary>
        /// <param name="cols">所查询的列</param>
        /// <param name="strWhere">所查询的条件</param>
        /// <param name="ordercols">排序列</param>
        /// <param name="orderby">降序或升序</param>
        /// <param name="PageIndex">当前页数</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="RowCount">记录总数</param>
        /// <param name="PageCount">总页数</param>
        /// <returns></returns>
        public DataSet GetListCols(string cols, string strWhere, string ordercols, string orderby, int PageIndex, int PageSize, ref int RowCount, ref int PageCount)
        {
            string procname = "XiaoZhengGe";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + cols);
            strSql.Append(" FROM SchThdInfo  "); 
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (ordercols.Trim() != "")
                strSql.Append(" order by " + ordercols + " " + orderby); 
            SqlParameter[] parameters = {
                    new SqlParameter("@sqlstr", SqlDbType.NVarChar, 4000),
                    new SqlParameter("@currentpage", SqlDbType.Int),
                    new SqlParameter("@pagesize", SqlDbType.Int),
                    new SqlParameter("@pagecount", SqlDbType.Int),
                    new SqlParameter("@rowcount", SqlDbType.Int),
                    };
            parameters[0].Value = strSql.ToString();
            parameters[1].Value = PageIndex;
            parameters[2].Value = PageSize;
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;
            string table1 = "WFListV";
            DataSet myds1 = DbHelperSQL.RunProcedure(procname, parameters, table1);
            DataTable dt = new DataTable();
            dt = myds1.Tables["WFListV1"].Copy();
            DataSet myds = new DataSet();
            myds.Tables.Add(dt);

            PageCount = (int)parameters[3].Value;
            RowCount = (int)parameters[4].Value;
            return myds;
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SchSystem.Model.SchThdInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SchThdInfo(");
			strSql.Append("SchId,SysName,SysUrl,SysUserNameTips,SysUserPwTips,SysLoginUrl,RecTime,RecUser,LastRecTime,LastRecUser)");
			strSql.Append(" values (");
			strSql.Append("@SchId,@SysName,@SysUrl,@SysUserNameTips,@SysUserPwTips,@SysLoginUrl,@RecTime,@RecUser,@LastRecTime,@LastRecUser)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@SysName", SqlDbType.NVarChar,50),
					new SqlParameter("@SysUrl", SqlDbType.VarChar,500),
					new SqlParameter("@SysUserNameTips", SqlDbType.VarChar,50),
					new SqlParameter("@SysUserPwTips", SqlDbType.NVarChar,50),
					new SqlParameter("@SysLoginUrl", SqlDbType.VarChar,500),
					new SqlParameter("@RecTime", SqlDbType.SmallDateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,50),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20)};
			parameters[0].Value = model.SchId;
			parameters[1].Value = model.SysName;
			parameters[2].Value = model.SysUrl;
			parameters[3].Value = model.SysUserNameTips;
			parameters[4].Value = model.SysUserPwTips;
			parameters[5].Value = model.SysLoginUrl;
			parameters[6].Value = model.RecTime;
			parameters[7].Value = model.RecUser;
			parameters[8].Value = model.LastRecTime;
			parameters[9].Value = model.LastRecUser;

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
		public bool Update(SchSystem.Model.SchThdInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SchThdInfo set ");
			strSql.Append("SchId=@SchId,");
			strSql.Append("SysName=@SysName,");
			strSql.Append("SysUrl=@SysUrl,");
			strSql.Append("SysUserNameTips=@SysUserNameTips,");
			strSql.Append("SysUserPwTips=@SysUserPwTips,");
			strSql.Append("SysLoginUrl=@SysLoginUrl,");
			strSql.Append("RecTime=@RecTime,");
			strSql.Append("RecUser=@RecUser,");
			strSql.Append("LastRecTime=@LastRecTime,");
			strSql.Append("LastRecUser=@LastRecUser");
			strSql.Append(" where AutoId=@AutoId");
			SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@SysName", SqlDbType.NVarChar,50),
					new SqlParameter("@SysUrl", SqlDbType.VarChar,500),
					new SqlParameter("@SysUserNameTips", SqlDbType.VarChar,50),
					new SqlParameter("@SysUserPwTips", SqlDbType.NVarChar,50),
					new SqlParameter("@SysLoginUrl", SqlDbType.VarChar,500),
					new SqlParameter("@RecTime", SqlDbType.SmallDateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,50),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@AutoId", SqlDbType.Int,4)};
			parameters[0].Value = model.SchId;
			parameters[1].Value = model.SysName;
			parameters[2].Value = model.SysUrl;
			parameters[3].Value = model.SysUserNameTips;
			parameters[4].Value = model.SysUserPwTips;
			parameters[5].Value = model.SysLoginUrl;
			parameters[6].Value = model.RecTime;
			parameters[7].Value = model.RecUser;
			parameters[8].Value = model.LastRecTime;
			parameters[9].Value = model.LastRecUser;
			parameters[10].Value = model.AutoId;

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
			strSql.Append("delete from SchThdInfo ");
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
			strSql.Append("delete from SchThdInfo ");
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
		public SchSystem.Model.SchThdInfo GetModel(int AutoId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AutoId,SchId,SysName,SysUrl,SysUserNameTips,SysUserPwTips,SysLoginUrl,RecTime,RecUser,LastRecTime,LastRecUser from SchThdInfo ");
			strSql.Append(" where AutoId=@AutoId");
			SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
			parameters[0].Value = AutoId;

			SchSystem.Model.SchThdInfo model=new SchSystem.Model.SchThdInfo();
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
		public SchSystem.Model.SchThdInfo DataRowToModel(DataRow row)
		{
			SchSystem.Model.SchThdInfo model=new SchSystem.Model.SchThdInfo();
			if (row != null)
			{
				if(row["AutoId"]!=null && row["AutoId"].ToString()!="")
				{
					model.AutoId=int.Parse(row["AutoId"].ToString());
				}
				if(row["SchId"]!=null && row["SchId"].ToString()!="")
				{
					model.SchId=int.Parse(row["SchId"].ToString());
				}
				if(row["SysName"]!=null)
				{
					model.SysName=row["SysName"].ToString();
				}
				if(row["SysUrl"]!=null)
				{
					model.SysUrl=row["SysUrl"].ToString();
				}
				if(row["SysUserNameTips"]!=null)
				{
					model.SysUserNameTips=row["SysUserNameTips"].ToString();
				}
				if(row["SysUserPwTips"]!=null)
				{
					model.SysUserPwTips=row["SysUserPwTips"].ToString();
				}
				if(row["SysLoginUrl"]!=null)
				{
					model.SysLoginUrl=row["SysLoginUrl"].ToString();
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
			strSql.Append("select AutoId,SchId,SysName,SysUrl,SysUserNameTips,SysUserPwTips,SysLoginUrl,RecTime,RecUser,LastRecTime,LastRecUser ");
			strSql.Append(" FROM SchThdInfo ");
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
			strSql.Append(" AutoId,SchId,SysName,SysUrl,SysUserNameTips,SysUserPwTips,SysLoginUrl,RecTime,RecUser,LastRecTime,LastRecUser ");
			strSql.Append(" FROM SchThdInfo ");
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
			strSql.Append("select count(1) FROM SchThdInfo ");
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
			strSql.Append(")AS Row, T.*  from SchThdInfo T ");
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
			parameters[0].Value = "SchThdInfo";
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

