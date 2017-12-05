using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
namespace SchSystem.Dal
{
	/// <summary>
	/// 数据访问类:SchClassInfo
	/// </summary>
	public partial class SchClassInfoDal
	{
        public SchClassInfoDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ClassId", "SchClassInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ClassId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SchClassInfo");
			strSql.Append(" where ClassId=@ClassId");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4)
			};
			parameters[0].Value = ClassId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SchSystem.Model.SchClassInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SchClassInfo(");
			strSql.Append("ClassNo,ClassName,GradeId,SchId,IsFinish,RecTime,RecUser,LastRecTime,LastRecUser)");
			strSql.Append(" values (");
			strSql.Append("@ClassNo,@ClassName,@GradeId,@SchId,@IsFinish,@RecTime,@RecUser,@LastRecTime,@LastRecUser)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassNo", SqlDbType.VarChar,10),
					new SqlParameter("@ClassName", SqlDbType.VarChar,40),
					new SqlParameter("@GradeId", SqlDbType.Int,4),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@IsFinish", SqlDbType.TinyInt,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,20),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20)};
			parameters[0].Value = model.ClassNo;
			parameters[1].Value = model.ClassName;
			parameters[2].Value = model.GradeId;
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
		public bool Update(SchSystem.Model.SchClassInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SchClassInfo set ");
			strSql.Append("ClassNo=@ClassNo,");
			strSql.Append("ClassName=@ClassName,");
			strSql.Append("GradeId=@GradeId,");
			//strSql.Append("SchId=@SchId,");
			//strSql.Append("IsFinish=@IsFinish,");
			//strSql.Append("RecTime=@RecTime,");
			//strSql.Append("RecUser=@RecUser,");
			strSql.Append("LastRecTime=@LastRecTime,");
			strSql.Append("LastRecUser=@LastRecUser");
			strSql.Append(" where ClassId=@ClassId");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassNo", SqlDbType.VarChar,10),
					new SqlParameter("@ClassName", SqlDbType.VarChar,40),
					new SqlParameter("@GradeId", SqlDbType.Int,4),
					//new SqlParameter("@SchId", SqlDbType.Int,4),
					//new SqlParameter("@IsFinish", SqlDbType.TinyInt,1),
					//new SqlParameter("@RecTime", SqlDbType.DateTime),
					//new SqlParameter("@RecUser", SqlDbType.VarChar,20),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@ClassId", SqlDbType.Int,4)};
			parameters[0].Value = model.ClassNo;
			parameters[1].Value = model.ClassName;
			parameters[2].Value = model.GradeId;
			//parameters[3].Value = model.SchId;
			//parameters[4].Value = model.IsFinish;
			//parameters[5].Value = model.RecTime;
			//parameters[6].Value = model.RecUser;
			parameters[3].Value = model.LastRecTime;
			parameters[4].Value = model.LastRecUser;
			parameters[5].Value = model.ClassId;
            string sql = strSql.ToString();
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
        /// 软删除一条数据记录
        /// </summary>
        /// <param name="ClassId">班级编号（自动）</param>
        /// <returns></returns>
        public bool DeleteRec(int ClassId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchClassInfo set ");
            strSql.Append("IsFinish=0");
            strSql.Append(" where ClassId=@ClassId");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4)};
            parameters[0].Value = ClassId;

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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ClassId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchClassInfo ");
			strSql.Append(" where ClassId=@ClassId");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4)
			};
			parameters[0].Value = ClassId;

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
		public bool DeleteList(string ClassIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchClassInfo ");
			strSql.Append(" where ClassId in ("+ClassIdlist + ")  ");
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
		public SchSystem.Model.SchClassInfo GetModel(int ClassId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ClassId,ClassNo,ClassName,GradeId,SchId,IsFinish,RecTime,RecUser,LastRecTime,LastRecUser from SchClassInfo ");
			strSql.Append(" where ClassId=@ClassId");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4)
			};
			parameters[0].Value = ClassId;

			SchSystem.Model.SchClassInfo model=new SchSystem.Model.SchClassInfo();
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
		public SchSystem.Model.SchClassInfo DataRowToModel(DataRow row)
		{
			SchSystem.Model.SchClassInfo model=new SchSystem.Model.SchClassInfo();
			if (row != null)
			{
				if(row["ClassId"]!=null && row["ClassId"].ToString()!="")
				{
					model.ClassId=int.Parse(row["ClassId"].ToString());
				}
				if(row["ClassNo"]!=null)
				{
					model.ClassNo=row["ClassNo"].ToString();
				}
				if(row["ClassName"]!=null)
				{
					model.ClassName=row["ClassName"].ToString();
				}
				if(row["GradeId"]!=null && row["GradeId"].ToString()!="")
				{
					model.GradeId=int.Parse(row["GradeId"].ToString());
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
        public DataSet GetList(string cols, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            if (cols.Trim() != "")
            {
                strSql.Append(cols);
            }
            strSql.Append(" FROM SchClassInfo sci ");
            strSql.Append(" RIGHT JOIN SchGradeInfo sgi ON sci.GradeId = sgi.GradeId ");
            strSql.Append(" RIGHT JOIN SchInfo si ON sgi.SchId = si.SchId ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetList(string cols,string strWhere,int n)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(cols);
            strSql.Append(" FROM SchClassInfo sci ");
            strSql.Append(" INNER JOIN SchGradeInfo sgi ON sci.GradeId = sgi.GradeId ");
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
			strSql.Append("select ClassId,ClassNo,ClassName,GradeId,SchId,IsFinish,RecTime,RecUser,LastRecTime,LastRecUser ");
			strSql.Append(" FROM SchClassInfo ");
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
			strSql.Append(" ClassId,ClassNo,ClassName,GradeId,SchId,IsFinish,RecTime,RecUser,LastRecTime,LastRecUser ");
			strSql.Append(" FROM SchClassInfo ");
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
			strSql.Append("select count(1) FROM SchClassInfo ");
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
				strSql.Append("order by T.ClassId desc");
			}
			strSql.Append(")AS Row, T.*  from SchClassInfo T ");
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
            strSql.Append(" FROM SchClassInfo sci ");
            strSql.Append(" RIGHT JOIN SchGradeInfo sgi ON sci.GradeId = sgi.GradeId ");
            strSql.Append(" RIGHT JOIN SchInfo si ON sgi.SchId = si.SchId ");
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
			parameters[0].Value = "SchClassInfo";
			parameters[1].Value = "ClassId";
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

