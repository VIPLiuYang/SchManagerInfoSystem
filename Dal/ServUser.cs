using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;

namespace SchSystem.DAL
{
	/// <summary>
	/// 数据访问类:ServUser
	/// </summary>
	public partial class ServUser
	{
		public ServUser()
		{}
		#region  BasicMethod
        public DataSet GetList(string cols, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (cols.Trim() != "")
            {
                strSql.Append(cols);
            }
            strSql.Append(" FROM ServUser ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public bool UpdateIco(int AutoId, string Uico)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ServUser set ");
            strSql.Append("Uico=@Uico");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
					new SqlParameter("@Uico", SqlDbType.VarChar,200),
					new SqlParameter("@AutoId", SqlDbType.Int,4)};
            parameters[0].Value = Uico;
            parameters[1].Value = AutoId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdatePwd(int AutoId, string Pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ServUser set ");
            strSql.Append("Pwd=@Pwd");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
					new SqlParameter("@Pwd", SqlDbType.VarChar,50),
					new SqlParameter("@AutoId", SqlDbType.Int,4)};
            parameters[0].Value = Pwd;
            parameters[1].Value = AutoId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public SchSystem.Model.ServUser GetModel(string UserName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AutoId,UserName,Usex,UTname,Uareano,RecTime,LoginTime,Uico,Stat from ServUser ");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,20)			};
            parameters[0].Value = UserName;

            SchSystem.Model.ServUser model = new SchSystem.Model.ServUser();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        public bool Exists(string UserName, string Pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ServUser");
            strSql.Append(" where Stat=1 and UserName=@UserName and Pwd=@Pwd ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,20),
					new SqlParameter("@Pwd", SqlDbType.VarChar,50)			};
            parameters[0].Value = UserName;
            parameters[1].Value = Pwd;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("AutoId", "ServUser"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string username)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ServUser");
            strSql.Append(" where UserName=@UserName");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,20)
			};
            parameters[0].Value = username;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
                

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SchSystem.Model.ServUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ServUser(");
			strSql.Append("UserName,Pwd,Usex,UTname,Uareano,RecTime)");
			strSql.Append(" values (");
			strSql.Append("@UserName,@Pwd,@Usex,@UTname,@Uareano,@RecTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,20),
					new SqlParameter("@Pwd", SqlDbType.VarChar,50),
					new SqlParameter("@Usex", SqlDbType.TinyInt,1),
					new SqlParameter("@UTname", SqlDbType.NVarChar,20),
					new SqlParameter("@Uareano", SqlDbType.VarChar,10),
					new SqlParameter("@RecTime", SqlDbType.DateTime)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.Pwd;
			parameters[2].Value = model.Usex;
			parameters[3].Value = model.UTname;
			parameters[4].Value = model.Uareano;
			parameters[5].Value = model.RecTime;

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
		public bool Update(SchSystem.Model.ServUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ServUser set ");
			strSql.Append("UserName=@UserName,");
			strSql.Append("Pwd=@Pwd,");
			strSql.Append("Usex=@Usex,");
			strSql.Append("UTname=@UTname,");
			strSql.Append("Uareano=@Uareano,");
			strSql.Append("RecTime=@RecTime");
			strSql.Append(" where AutoId=@AutoId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,20),
					new SqlParameter("@Pwd", SqlDbType.VarChar,50),
					new SqlParameter("@Usex", SqlDbType.TinyInt,1),
					new SqlParameter("@UTname", SqlDbType.NVarChar,20),
					new SqlParameter("@Uareano", SqlDbType.VarChar,10),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@AutoId", SqlDbType.Int,4)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.Pwd;
			parameters[2].Value = model.Usex;
			parameters[3].Value = model.UTname;
			parameters[4].Value = model.Uareano;
			parameters[5].Value = model.RecTime;
			parameters[6].Value = model.AutoId;

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
			strSql.Append("delete from ServUser ");
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
			strSql.Append("delete from ServUser ");
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
        public SchSystem.Model.ServUser GetModel(int AutoId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AutoId,UserName,Pwd,Usex,UTname,Uareano,RecTime,LoginTime,Uico,Stat from ServUser ");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
            parameters[0].Value = AutoId;

            SchSystem.Model.ServUser model = new SchSystem.Model.ServUser();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public SchSystem.Model.ServUser DataRowToModel(DataRow row)
        {
            SchSystem.Model.ServUser model = new SchSystem.Model.ServUser();
            if (row != null)
            {
                if (row["AutoId"] != null && row["AutoId"].ToString() != "")
                {
                    model.AutoId = int.Parse(row["AutoId"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["Usex"] != null && row["Usex"].ToString() != "")
                {
                    model.Usex = int.Parse(row["Usex"].ToString());
                }
                if (row["UTname"] != null)
                {
                    model.UTname = row["UTname"].ToString();
                }
                if (row["Uareano"] != null)
                {
                    model.Uareano = row["Uareano"].ToString();
                }
                if (row["RecTime"] != null && row["RecTime"].ToString() != "")
                {
                    model.RecTime = DateTime.Parse(row["RecTime"].ToString());
                }
                if (row["LoginTime"] != null && row["LoginTime"].ToString() != "")
                {
                    model.LoginTime = DateTime.Parse(row["LoginTime"].ToString());
                }
                if (row["Uico"] != null)
                {
                    model.Uico = row["Uico"].ToString();
                }
                if (row["Stat"] != null && row["Stat"].ToString() != "")
                {
                    model.Stat = int.Parse(row["Stat"].ToString());
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
			strSql.Append("select AutoId,UserName,Pwd,Usex,UTname,Uareano,RecTime ");
			strSql.Append(" FROM ServUser ");
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
			strSql.Append(" AutoId,UserName,Pwd,Usex,UTname,Uareano,RecTime ");
			strSql.Append(" FROM ServUser ");
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
			strSql.Append("select count(1) FROM ServUser ");
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
			strSql.Append(")AS Row, T.*  from ServUser T ");
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
            strSql.Append(" FROM ServUser  ");
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
			parameters[0].Value = "ServUser";
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

