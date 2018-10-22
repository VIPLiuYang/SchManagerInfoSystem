using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;

namespace SchSystem.DAL
{
	/// <summary>
	/// 数据访问类:ServSys
	/// </summary>
	public partial class ServSys
	{
		public ServSys()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("AutoId", "ServSys"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AutoId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ServSys");
			strSql.Append(" where AutoId=@AutoId");
			SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
			parameters[0].Value = AutoId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        public bool Exists(string SysCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ServSys");
            strSql.Append(" where SysCode=@SysCode");
            SqlParameter[] parameters = {
					new SqlParameter("@SysCode", SqlDbType.VarChar,10)
			};
            parameters[0].Value = SysCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(SchSystem.Model.ServSys model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ServSys(");
			strSql.Append("SysName,SysCode,SysUrl)");
			strSql.Append(" values (");
			strSql.Append("@SysName,@SysCode,@SysUrl)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SysName", SqlDbType.NVarChar,50),
					new SqlParameter("@SysCode", SqlDbType.VarChar,10),
					new SqlParameter("@SysUrl", SqlDbType.VarChar,300)};
			parameters[0].Value = model.SysName;
			parameters[1].Value = model.SysCode;
			parameters[2].Value = model.SysUrl;

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
        public bool Update(SchSystem.Model.ServSys model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ServSys set ");
			strSql.Append("SysName=@SysName,");
			strSql.Append("SysCode=@SysCode,");
			strSql.Append("SysUrl=@SysUrl");
			strSql.Append(" where AutoId=@AutoId");
			SqlParameter[] parameters = {
					new SqlParameter("@SysName", SqlDbType.NVarChar,50),
					new SqlParameter("@SysCode", SqlDbType.VarChar,10),
					new SqlParameter("@SysUrl", SqlDbType.VarChar,300),
					new SqlParameter("@AutoId", SqlDbType.Int,4)};
			parameters[0].Value = model.SysName;
			parameters[1].Value = model.SysCode;
			parameters[2].Value = model.SysUrl;
			parameters[3].Value = model.AutoId;

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
			strSql.Append("delete from ServSys ");
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
			strSql.Append("delete from ServSys ");
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
        public SchSystem.Model.ServSys GetModel(int AutoId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AutoId,SysName,SysCode,SysUrl from ServSys ");
			strSql.Append(" where AutoId=@AutoId");
			SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
			parameters[0].Value = AutoId;

            SchSystem.Model.ServSys model = new SchSystem.Model.ServSys();
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
        public SchSystem.Model.ServSys DataRowToModel(DataRow row)
		{
            SchSystem.Model.ServSys model = new SchSystem.Model.ServSys();
			if (row != null)
			{
				if(row["AutoId"]!=null && row["AutoId"].ToString()!="")
				{
					model.AutoId=int.Parse(row["AutoId"].ToString());
				}
				if(row["SysName"]!=null)
				{
					model.SysName=row["SysName"].ToString();
				}
				if(row["SysCode"]!=null)
				{
					model.SysCode=row["SysCode"].ToString();
				}
				if(row["SysUrl"]!=null)
				{
					model.SysUrl=row["SysUrl"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AutoId,SysName,SysCode,SysUrl ");
            strSql.Append(" FROM ServSys ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetList(string cols,string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select "+cols+" ");
            strSql.Append(" FROM ServSys ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
			strSql.Append(" AutoId,SysName,SysCode,SysUrl ");
			strSql.Append(" FROM ServSys ");
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
			strSql.Append("select count(1) FROM ServSys ");
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
			strSql.Append(")AS Row, T.*  from ServSys T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" FROM ServSys  ");
            //strSql.Append(" left join SchInfo as b on a.SchId=b.SchId	 ");
            //strSql.Append(" left join SchDepartInfo as c on c.Pid=a.DepartId	 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (ordercols.Trim() != "")
                strSql.Append(" order by " + ordercols + " " + orderby);
            //  @sqlstr nvarchar(4000), --查询字符串
            //  @currentpage int, --第N页
            //  @pagesize int, --每页行数
            //  @pagecount int output ,
            //  @rowcount int output 
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
			parameters[0].Value = "ServSys";
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

