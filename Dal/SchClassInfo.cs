using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
namespace SchSystem.DAL
{
	/// <summary>
	/// 数据访问类:SchClassInfo
	/// </summary>
	public partial class SchClassInfo
	{
        public SchClassInfo()
		{}
		#region  BasicMethod
        public int GetClassId(string ClassNo, int GradeId, int SchId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ClassId from SchClassInfo ");
            strSql.Append(" where ClassNo=@ClassNo and GradeId=@GradeId and SchId=@SchId  and IsFinish<>2");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassNo", SqlDbType.VarChar,10),
					new SqlParameter("@GradeId", SqlDbType.Int,4),
					new SqlParameter("@SchId", SqlDbType.Int,4)			};
            parameters[0].Value = ClassNo;
            parameters[1].Value = GradeId;
            parameters[2].Value = SchId;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return int.Parse(ds.Tables[0].Rows[0]["ClassId"].ToString());
            }
            else
            {
                return 0;
            }
        }
        public bool UpdateUnv(SchSystem.Model.SchClassInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchClassInfo set ");
            strSql.Append("ClassNo=@ClassNo,");
            strSql.Append("ClassName=@ClassName,");
            strSql.Append("GradeCode=@GradeCode,");
            strSql.Append("GradeId=@GradeId,");
            strSql.Append("SchId=@SchId,");
            strSql.Append("IsFinish=@IsFinish,");
            strSql.Append("LastRecTime=@LastRecTime,");
            strSql.Append("LastRecUser=@LastRecUser");
            strSql.Append(" where ClassId=@ClassId");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassNo", SqlDbType.VarChar,10),
					new SqlParameter("@ClassName", SqlDbType.VarChar,40),
					new SqlParameter("@GradeCode", SqlDbType.VarChar,10),
					new SqlParameter("@GradeId", SqlDbType.Int,4),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@IsFinish", SqlDbType.TinyInt,1),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@ClassId", SqlDbType.Int,4)};
            parameters[0].Value = model.ClassNo;
            parameters[1].Value = model.ClassName;
            parameters[2].Value = model.GradeCode;
            parameters[3].Value = model.GradeId;
            parameters[4].Value = model.SchId;
            parameters[5].Value = model.IsFinish;
            parameters[6].Value = model.LastRecTime;
            parameters[7].Value = model.LastRecUser;
            parameters[8].Value = model.ClassId;

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
        public bool ExistsClass(int ClassId, string ClassNo, int GradeId, int SchId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchClassInfo");
            strSql.Append(" where ClassId<>@ClassId and ClassNo=@ClassNo and GradeId=@GradeId and SchId=@SchId  and IsFinish<>2");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassNo", SqlDbType.VarChar,10),
					new SqlParameter("@GradeId", SqlDbType.Int,4),
					new SqlParameter("@SchId", SqlDbType.Int,4),	
					new SqlParameter("@ClassId", SqlDbType.Int,4)};
            parameters[0].Value = ClassNo;
            parameters[1].Value = GradeId;
            parameters[2].Value = SchId;
            parameters[3].Value = ClassId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public string GetName(int ClassId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ClassName from SchClassInfo ");
            strSql.Append(" where ClassId=@ClassId");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4)
			};
            parameters[0].Value = ClassId;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["ClassName"].ToString();
            }
            else
            {
                return "";
            }
        }
        public bool ExistsPerClass(string PerCode, int SchId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchClassGradeV");
            strSql.Append(" where left(GradeCode,1)=@PerCode and IsFinish=0 and ClassStat=0 and SchId=@SchId ");
            SqlParameter[] parameters = {
					new SqlParameter("@PerCode", SqlDbType.VarChar,4),
					new SqlParameter("@SchId", SqlDbType.Int,4)			};
            parameters[0].Value = PerCode;
            parameters[1].Value = SchId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool UpdateStat(SchSystem.Model.SchClassInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchClassInfo set ");
            strSql.Append("IsFinish=@IsFinish,");
            strSql.Append("LastRecTime=@LastRecTime,");
            strSql.Append("LastRecUser=@LastRecUser");
            strSql.Append(" where ClassId=@ClassId");
            SqlParameter[] parameters = {
					new SqlParameter("@IsFinish", SqlDbType.TinyInt,1),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@ClassId", SqlDbType.Int,4)};
            parameters[0].Value = model.IsFinish;
            parameters[1].Value = model.LastRecTime;
            parameters[2].Value = model.LastRecUser;
            parameters[3].Value = model.ClassId;

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
        public string GetIds(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Declare @UserTname nvarchar(50)");
            strSql.Append("Select @UserTname=ISNULL(@UserTname+',','')+CONVERT(VARCHAR(50),UserTname) From SchClassUserSub");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("Select @UserTname as TeacherList ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["TeacherList"].ToString();
            }
            else
            {
                return null;
            }
        }
        public string GetClassNames(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Declare @ClassName nvarchar(50)");
            strSql.Append("Select @ClassName=ISNULL(@ClassName+'->','')+CONVERT(VARCHAR(50),ClassName) From SchClassInfo");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("Select @ClassName as ClassNameList ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["ClassNameList"].ToString();
            }
            else
            {
                return null;
            }
        }
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
        /// 是否存在该记录
        /// </summary>
        public DataSet Exists(string schid, int GradeId, string ClassNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ClassId from SchClassInfo");
            strSql.Append(" where SchId=@schid and GradeId=@GradeId and ClassNo=@ClassNo and IsFinish<>2");
            SqlParameter[] parameters = {
					new SqlParameter("@schid", SqlDbType.Int,6),
                    new SqlParameter("@GradeId", SqlDbType.Int,4),
                    new SqlParameter("@ClassNo", SqlDbType.VarChar,40)
			};
            parameters[0].Value = schid;
            parameters[1].Value = GradeId;
            parameters[2].Value = ClassNo;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SchSystem.Model.SchClassInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SchClassInfo(");
            strSql.Append("ClassNo,ClassName,GradeId,GradeCode,SchId,IsFinish,RecTime,RecUser)");
            //strSql.Append("ClassNo,ClassName,GradeId,SchId,IsFinish,RecTime,RecUser,LastRecTime,LastRecUser)");
			strSql.Append(" values (");
            strSql.Append("@ClassNo,@ClassName,@GradeId,@GradeCode,@SchId,@IsFinish,@RecTime,@RecUser)");
            //strSql.Append("@ClassNo,@ClassName,@GradeId,@SchId,@IsFinish,@RecTime,@RecUser,@LastRecTime,@LastRecUser)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassNo", SqlDbType.VarChar,10),
					new SqlParameter("@ClassName", SqlDbType.VarChar,40),
					new SqlParameter("@GradeId", SqlDbType.Int,4),
                    new SqlParameter("@GradeCode", SqlDbType.VarChar,10),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@IsFinish", SqlDbType.TinyInt,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,20)//,
					//new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					//new SqlParameter("@LastRecUser", SqlDbType.VarChar,20)
                                        };
			parameters[0].Value = model.ClassNo;
			parameters[1].Value = model.ClassName;
            parameters[2].Value = model.GradeId;
            parameters[3].Value = model.GradeCode;
			parameters[4].Value = model.SchId;
			parameters[5].Value = model.IsFinish;
			parameters[6].Value = model.RecTime;
			parameters[7].Value = model.RecUser;
			//parameters[7].Value = model.LastRecTime;
			//parameters[8].Value = model.LastRecUser;
            object obj = new object();
            try
            {
                obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {

            }
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
			strSql.Append("IsFinish=@IsFinish,");
			strSql.Append("LastRecTime=@LastRecTime,");
			strSql.Append("LastRecUser=@LastRecUser");
			strSql.Append(" where ClassId=@ClassId");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassNo", SqlDbType.VarChar,10),
					new SqlParameter("@ClassName", SqlDbType.VarChar,40),
					new SqlParameter("@GradeId", SqlDbType.Int,4),
					new SqlParameter("@IsFinish", SqlDbType.TinyInt,1),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@ClassId", SqlDbType.Int,4)};
			parameters[0].Value = model.ClassNo;
			parameters[1].Value = model.ClassName;
            parameters[2].Value = model.GradeId;
			parameters[3].Value = model.IsFinish;
			parameters[4].Value = model.LastRecTime;
			parameters[5].Value = model.LastRecUser;
			parameters[6].Value = model.ClassId;
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
            strSql.Append("select  top 1 ClassId,ClassNo,GradeId,ClassName,SchId,IsFinish,RecTime,RecUser,LastRecTime,LastRecUser from SchClassInfo ");
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
                if (row["GradeId"] != null && row["GradeId"].ToString() != "")
				{
                    model.GradeId = int.Parse(row["GradeId"].ToString());
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
            strSql.Append(" FROM SchClassInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetListV(string cols, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            if (cols.Trim() != "")
            {
                strSql.Append(cols);
            }
            strSql.Append(" FROM SchClassGradeV ");
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
        /// 获得数据列表：普通数据表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select ClassId,ClassNo,ClassName,SchId,GradeId,IsFinish,RecTime,RecUser,LastRecTime,LastRecUser ");
			strSql.Append(" FROM SchClassInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 获得数据列表：年级班级连表视图（SchClassGradeV）
        /// </summary>
        public DataSet GetListV(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM SchClassGradeV ");
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
        /// <summary>
        /// 判断班级下面是否有学生数据
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public bool ExistsClassStuData(int ClassId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchStuInfo");
            strSql.Append(" where ClassId=@ClassId and Stat=1");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4)
			};
            parameters[0].Value = ClassId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 判断年级下面是否有班级数据
        /// </summary>
        /// <param name="SchId"></param>
        /// <param name="GradeCode"></param>
        /// <returns></returns>
        public bool ExistsClassData(string SchId, string GradeCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchClassInfo");
            //strSql.Append(" where SchId=@SchId and GradeId=@GradeCode");
            strSql.Append(" where GradeId in (select GradeId from SchGradeInfo where GradeCode=@GradeCode and SchId=@SchId) and Isfinish=0");
            SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,4),
                    new SqlParameter("@GradeCode", SqlDbType.VarChar,10)
			};
            parameters[0].Value = SchId;
            parameters[1].Value = GradeCode;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 判断学段下面是否有班级数据
        /// </summary>
        /// <param name="SchId"></param>
        /// <param name="PerCode"></param>
        /// <returns></returns>
        public bool ExistsClassData(int SchId, int PerCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CHARINDEX('"+PerCode+"',GradeCode) as peres from SchClassInfo where SchId='"+SchId+"'");
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            DataRow[] dr = dt.Select("peres=1");
            if (dr.Length > 0)
                return true;
            else
                return false;
        }
		#endregion  ExtensionMethod
	}
}

