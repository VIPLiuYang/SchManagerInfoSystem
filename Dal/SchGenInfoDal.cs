using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
namespace SchSystem.Dal
{
	/// <summary>
	/// 数据访问类:SchGenInfo
	/// </summary>
	public partial class SchGenInfoDal
	{
        public SchGenInfoDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("GenId", "SchGenInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int GenId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SchGenInfo");
			strSql.Append(" where GenId=@GenId");
			SqlParameter[] parameters = {
					new SqlParameter("@GenId", SqlDbType.Int,4)
			};
			parameters[0].Value = GenId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SchSystem.Model.SchGenInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SchGenInfo(");
			strSql.Append("LoginName,Pwd,GenName,Mobile,Sex,ImgUrl,Stat,LoginTime,RecTime,RecUser,LastRecTime,LastRecUser)");
			strSql.Append(" values (");
			strSql.Append("@LoginName,@Pwd,@GenName,@Mobile,@Sex,@ImgUrl,@Stat,@LoginTime,@RecTime,@RecUser,@LastRecTime,@LastRecUser)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@Pwd", SqlDbType.VarChar,20),
					new SqlParameter("@GenName", SqlDbType.VarChar,20),
					new SqlParameter("@Mobile", SqlDbType.VarChar,15),
					new SqlParameter("@Sex", SqlDbType.TinyInt,1),
					new SqlParameter("@ImgUrl", SqlDbType.VarChar,200),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@LoginTime", SqlDbType.DateTime),
					new SqlParameter("@RecTime", SqlDbType.SmallDateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,50),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20)};
			parameters[0].Value = model.LoginName;
			parameters[1].Value = model.Pwd;
			parameters[2].Value = model.GenName;
			parameters[3].Value = model.Mobile;
			parameters[4].Value = model.Sex;
			parameters[5].Value = model.ImgUrl;
			parameters[6].Value = model.Stat;
			parameters[7].Value = model.LoginTime;
			parameters[8].Value = model.RecTime;
			parameters[9].Value = model.RecUser;
			parameters[10].Value = model.LastRecTime;
			parameters[11].Value = model.LastRecUser;

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
		public bool Update(SchSystem.Model.SchGenInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SchGenInfo set ");
			strSql.Append("LoginName=@LoginName,");
			strSql.Append("Pwd=@Pwd,");
			strSql.Append("GenName=@GenName,");
			strSql.Append("Mobile=@Mobile,");
			strSql.Append("Sex=@Sex,");
			//strSql.Append("ImgUrl=@ImgUrl,");
			//strSql.Append("Stat=@Stat,");
			//strSql.Append("LoginTime=@LoginTime,");
			//strSql.Append("RecTime=@RecTime,");
			//strSql.Append("RecUser=@RecUser,");
			strSql.Append("LastRecTime=@LastRecTime,");
			strSql.Append("LastRecUser=@LastRecUser");
			strSql.Append(" where GenId=@GenId");
			SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@Pwd", SqlDbType.VarChar,20),
					new SqlParameter("@GenName", SqlDbType.VarChar,20),
					new SqlParameter("@Mobile", SqlDbType.VarChar,15),
					new SqlParameter("@Sex", SqlDbType.TinyInt,1),
					//new SqlParameter("@ImgUrl", SqlDbType.VarChar,200),
					//new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					//new SqlParameter("@LoginTime", SqlDbType.DateTime),
					//new SqlParameter("@RecTime", SqlDbType.SmallDateTime),
					//new SqlParameter("@RecUser", SqlDbType.VarChar,50),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@GenId", SqlDbType.Int,4)};
			parameters[0].Value = model.LoginName;
			parameters[1].Value = model.Pwd;
			parameters[2].Value = model.GenName;
			parameters[3].Value = model.Mobile;
			parameters[4].Value = model.Sex;
			//parameters[5].Value = model.ImgUrl;
			//parameters[6].Value = model.Stat;
			//parameters[7].Value = model.LoginTime;
			//parameters[8].Value = model.RecTime;
			//parameters[9].Value = model.RecUser;
			parameters[5].Value = model.LastRecTime;
			parameters[6].Value = model.LastRecUser;
			parameters[7].Value = model.GenId;

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
		public bool Delete(int GenId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchGenInfo ");
			strSql.Append(" where GenId=@GenId");
			SqlParameter[] parameters = {
					new SqlParameter("@GenId", SqlDbType.Int,4)
			};
			parameters[0].Value = GenId;

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
		public bool DeleteList(string GenIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchGenInfo ");
			strSql.Append(" where GenId in ("+GenIdlist + ")  ");
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
        /// 软删除一条数据记录
        /// </summary>
        /// <param name="GradeID">年级编号（自动）</param>
        /// <returns></returns>
        public bool DeleteRec(int GradeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchGenInfo set ");
            strSql.Append("Stat=0");
            strSql.Append(" where GenId=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = GradeId;

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

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SchSystem.Model.SchGenInfo GetModel(int GenId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 GenId,LoginName,Pwd,GenName,Mobile,Sex,ImgUrl,Stat,LoginTime,RecTime,RecUser,LastRecTime,LastRecUser from SchGenInfo ");
			strSql.Append(" where GenId=@GenId");
			SqlParameter[] parameters = {
					new SqlParameter("@GenId", SqlDbType.Int,4)
			};
			parameters[0].Value = GenId;

			SchSystem.Model.SchGenInfo model=new SchSystem.Model.SchGenInfo();
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
		public SchSystem.Model.SchGenInfo DataRowToModel(DataRow row)
		{
			SchSystem.Model.SchGenInfo model=new SchSystem.Model.SchGenInfo();
			if (row != null)
			{
				if(row["GenId"]!=null && row["GenId"].ToString()!="")
				{
					model.GenId=int.Parse(row["GenId"].ToString());
				}
				if(row["LoginName"]!=null)
				{
					model.LoginName=row["LoginName"].ToString();
				}
				if(row["Pwd"]!=null)
				{
					model.Pwd=row["Pwd"].ToString();
				}
				if(row["GenName"]!=null)
				{
					model.GenName=row["GenName"].ToString();
				}
				if(row["Mobile"]!=null)
				{
					model.Mobile=row["Mobile"].ToString();
				}
				if(row["Sex"]!=null && row["Sex"].ToString()!="")
				{
					model.Sex=int.Parse(row["Sex"].ToString());
				}
				if(row["ImgUrl"]!=null)
				{
					model.ImgUrl=row["ImgUrl"].ToString();
				}
				if(row["Stat"]!=null && row["Stat"].ToString()!="")
				{
					model.Stat=int.Parse(row["Stat"].ToString());
				}
				if(row["LoginTime"]!=null && row["LoginTime"].ToString()!="")
				{
					model.LoginTime=DateTime.Parse(row["LoginTime"].ToString());
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
			strSql.Append("select GenId,LoginName,Pwd,GenName,Mobile,Sex,ImgUrl,Stat,LoginTime,RecTime,RecUser,LastRecTime,LastRecUser ");
			strSql.Append(" FROM SchGenInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 获得一条数据积累
        /// </summary>
        public DataSet GetOnce(string cols,string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (cols != "")
            {
                strSql.Append(cols);
            }
            strSql.Append(" FROM SchGenInfo spi ");
            strSql.Append(" INNER JOIN SchStuGenUn ssgu ON spi.GenId=ssgu.GenId ");
            strSql.Append(" INNER JOIN SchStuInfo ssi ON ssi.StuId=ssgu.StuId ");
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
			strSql.Append(" GenId,LoginName,Pwd,GenName,Mobile,Sex,ImgUrl,Stat,LoginTime,RecTime,RecUser,LastRecTime,LastRecUser ");
			strSql.Append(" FROM SchGenInfo ");
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
			strSql.Append("select count(1) FROM SchGenInfo ");
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
				strSql.Append("order by T.GenId desc");
			}
			strSql.Append(")AS Row, T.*  from SchGenInfo T ");
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
            strSql.Append(" FROM SchGenInfo ");
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
			parameters[0].Value = "SchGenInfo";
			parameters[1].Value = "GenId";
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

