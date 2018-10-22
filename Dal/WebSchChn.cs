using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;//Please add references
namespace SchSystem.DAL
{
    /// <summary>
    /// 数据访问类:WebSchChn
    /// </summary>
    public partial class WebSchChn
    {
        public WebSchChn()
        { }
        #region  BasicMethod
        public bool UpdateStat(SchSystem.Model.WebSchChn model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebSchChn set ");
            strSql.Append("Stat=@Stat");
            strSql.Append(" where ChnId=@ChnId");
            SqlParameter[] parameters = {
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@ChnId", SqlDbType.Int,4)};
            parameters[0].Value = model.Stat;;
            parameters[1].Value = model.ChnId;

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
        public DataSet GetList(string cols, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (cols != "")
            {
                strSql.Append(cols);
            }
            strSql.Append(" FROM WebSchChn ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
            strSql.Append(" FROM WebSchChn  ");
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
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ChnId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from WebSchChn");
            strSql.Append(" where Pid=@ChnId");
            SqlParameter[] parameters = {
					new SqlParameter("@ChnId", SqlDbType.Int,4)
			};
            parameters[0].Value = ChnId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool ExistsChnCode(int ChnId, int ChnCode, int SchId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from WebSchChn");
            strSql.Append(" where ChnId<>@ChnId and SchId=@SchId and Stat<2  and ChnCode=@ChnCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@ChnCode",  SqlDbType.Int,4),
					new SqlParameter("@SchId", SqlDbType.Int,6),
					new SqlParameter("@ChnId", SqlDbType.Int,4)};
            parameters[0].Value = ChnCode;
            parameters[1].Value = SchId;
            parameters[2].Value = ChnId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SchSystem.Model.WebSchChn model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WebSchChn(");
            strSql.Append("Pid,SchId,ChnName,ChnCode,OrderId,Stat,IsTop,Note,IsWrite,IsPlc,RecUser,RecName,RecTime,RecIp,IsLink,LinkUrl)");
            strSql.Append(" values (");
            strSql.Append("@Pid,@SchId,@ChnName,@ChnCode,@OrderId,@Stat,@IsTop,@Note,@IsWrite,@IsPlc,@RecUser,@RecName,@RecTime,@RecIp,@IsLink,@LinkUrl)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Pid", SqlDbType.Int,4),
					new SqlParameter("@SchId", SqlDbType.VarChar,50),
					new SqlParameter("@ChnName", SqlDbType.VarChar,50),
					new SqlParameter("@ChnCode", SqlDbType.Int,4),
					new SqlParameter("@OrderId", SqlDbType.Int,4),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@IsTop", SqlDbType.TinyInt,1),
					new SqlParameter("@Note", SqlDbType.VarChar,300),
					new SqlParameter("@IsWrite", SqlDbType.TinyInt,1),
					new SqlParameter("@IsPlc", SqlDbType.TinyInt,1),
					new SqlParameter("@RecUser", SqlDbType.VarChar,30),
					new SqlParameter("@RecName", SqlDbType.VarChar,30),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecIp", SqlDbType.VarChar,20),
					new SqlParameter("@IsLink", SqlDbType.TinyInt,1),
					new SqlParameter("@LinkUrl", SqlDbType.VarChar,300)};
            parameters[0].Value = model.Pid;
            parameters[1].Value = model.SchId;
            parameters[2].Value = model.ChnName;
            parameters[3].Value = model.ChnCode;
            parameters[4].Value = model.OrderId;
            parameters[5].Value = model.Stat;
            parameters[6].Value = model.IsTop;
            parameters[7].Value = model.Note;
            parameters[8].Value = model.IsWrite;
            parameters[9].Value = model.IsPlc;
            parameters[10].Value = model.RecUser;
            parameters[11].Value = model.RecName;
            parameters[12].Value = model.RecTime;
            parameters[13].Value = model.RecIp;
            parameters[14].Value = model.IsLink;
            parameters[15].Value = model.LinkUrl;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(SchSystem.Model.WebSchChn model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebSchChn set ");
            strSql.Append("Pid=@Pid,");
            strSql.Append("SchId=@SchId,");
            strSql.Append("ChnName=@ChnName,");
            strSql.Append("ChnCode=@ChnCode,");
            strSql.Append("OrderId=@OrderId,");
            strSql.Append("Stat=@Stat,");
            strSql.Append("IsTop=@IsTop,");
            strSql.Append("Note=@Note,");
            strSql.Append("IsWrite=@IsWrite,");
            strSql.Append("IsPlc=@IsPlc,");
            strSql.Append("RecUser=@RecUser,");
            strSql.Append("RecName=@RecName,");
            strSql.Append("RecTime=@RecTime,");
            strSql.Append("RecIp=@RecIp,");
            strSql.Append("IsLink=@IsLink,");
            strSql.Append("LinkUrl=@LinkUrl");
            strSql.Append(" where ChnId=@ChnId");
            SqlParameter[] parameters = {
					new SqlParameter("@Pid", SqlDbType.Int,4),
					new SqlParameter("@SchId", SqlDbType.VarChar,50),
					new SqlParameter("@ChnName", SqlDbType.VarChar,50),
					new SqlParameter("@ChnCode", SqlDbType.Int,4),
					new SqlParameter("@OrderId", SqlDbType.Int,4),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@IsTop", SqlDbType.TinyInt,1),
					new SqlParameter("@Note", SqlDbType.VarChar,300),
					new SqlParameter("@IsWrite", SqlDbType.TinyInt,1),
					new SqlParameter("@IsPlc", SqlDbType.TinyInt,1),
					new SqlParameter("@RecUser", SqlDbType.VarChar,30),
					new SqlParameter("@RecName", SqlDbType.VarChar,30),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecIp", SqlDbType.VarChar,20),
					new SqlParameter("@IsLink", SqlDbType.TinyInt,1),
					new SqlParameter("@LinkUrl", SqlDbType.VarChar,300),
					new SqlParameter("@ChnId", SqlDbType.Int,4)};
            parameters[0].Value = model.Pid;
            parameters[1].Value = model.SchId;
            parameters[2].Value = model.ChnName;
            parameters[3].Value = model.ChnCode;
            parameters[4].Value = model.OrderId;
            parameters[5].Value = model.Stat;
            parameters[6].Value = model.IsTop;
            parameters[7].Value = model.Note;
            parameters[8].Value = model.IsWrite;
            parameters[9].Value = model.IsPlc;
            parameters[10].Value = model.RecUser;
            parameters[11].Value = model.RecName;
            parameters[12].Value = model.RecTime;
            parameters[13].Value = model.RecIp;
            parameters[14].Value = model.IsLink;
            parameters[15].Value = model.LinkUrl;
            parameters[16].Value = model.ChnId;

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
        /// 更新一条数据
        /// </summary>
        public bool CUpdate(SchSystem.Model.WebSchChn model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebSchChn set ");
            strSql.Append("Pid=@Pid,");
            strSql.Append("SchId=@SchId,");
            strSql.Append("ChnName=@ChnName,");
            strSql.Append("ChnCode=@ChnCode,");
            strSql.Append("Stat=@Stat,");
            strSql.Append("Note=@Note"); 
            strSql.Append(" where ChnId=@ChnId");
            SqlParameter[] parameters = {
					new SqlParameter("@Pid", SqlDbType.Int,4),
					new SqlParameter("@SchId", SqlDbType.VarChar,50),
					new SqlParameter("@ChnName", SqlDbType.VarChar,50),
					new SqlParameter("@ChnCode", SqlDbType.Int,4), 
					new SqlParameter("@Stat", SqlDbType.TinyInt,1), 
					new SqlParameter("@Note", SqlDbType.VarChar,300), 
					new SqlParameter("@ChnId", SqlDbType.Int,4)};
            parameters[0].Value = model.Pid;
            parameters[1].Value = model.SchId;
            parameters[2].Value = model.ChnName;
            parameters[3].Value = model.ChnCode; 
            parameters[4].Value = model.Stat; 
            parameters[5].Value = model.Note; 
            parameters[6].Value = model.ChnId;

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
        public bool Delete(int ChnId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WebSchChn ");
            strSql.Append(" where ChnId=@ChnId");
            SqlParameter[] parameters = {
					new SqlParameter("@ChnId", SqlDbType.Int,4)
			};
            parameters[0].Value = ChnId;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string ChnIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WebSchChn ");
            strSql.Append(" where ChnId in (" + ChnIdlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public SchSystem.Model.WebSchChn GetModel(int ChnId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ChnId,Pid,SchId,ChnName,ChnCode,OrderId,Stat,IsTop,Note,IsWrite,IsPlc,RecUser,RecName,RecTime,RecIp,IsLink,LinkUrl from WebSchChn ");
            strSql.Append(" where ChnId=@ChnId");
            SqlParameter[] parameters = {
					new SqlParameter("@ChnId", SqlDbType.Int,4)
			};
            parameters[0].Value = ChnId;

            SchSystem.Model.WebSchChn model = new SchSystem.Model.WebSchChn();
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
        public SchSystem.Model.WebSchChn DataRowToModel(DataRow row)
        {
            SchSystem.Model.WebSchChn model = new SchSystem.Model.WebSchChn();
            if (row != null)
            {
                if (row["ChnId"] != null && row["ChnId"].ToString() != "")
                {
                    model.ChnId = int.Parse(row["ChnId"].ToString());
                }
                if (row["Pid"] != null && row["Pid"].ToString() != "")
                {
                    model.Pid = int.Parse(row["Pid"].ToString());
                }
                if (row["SchId"] != null && row["SchId"].ToString() != "")
                {
                    model.SchId = int.Parse(row["SchId"].ToString());
                }
                if (row["ChnName"] != null)
                {
                    model.ChnName = row["ChnName"].ToString();
                }
                if (row["ChnCode"] != null && row["ChnCode"].ToString() != "")
                {
                    model.ChnCode = int.Parse(row["ChnCode"].ToString());
                }
                if (row["OrderId"] != null && row["OrderId"].ToString() != "")
                {
                    model.OrderId = int.Parse(row["OrderId"].ToString());
                }
                if (row["Stat"] != null && row["Stat"].ToString() != "")
                {
                    model.Stat = int.Parse(row["Stat"].ToString());
                }
                if (row["IsTop"] != null && row["IsTop"].ToString() != "")
                {
                    model.IsTop = int.Parse(row["IsTop"].ToString());
                }
                if (row["Note"] != null)
                {
                    model.Note = row["Note"].ToString();
                }
                if (row["IsWrite"] != null && row["IsWrite"].ToString() != "")
                {
                    model.IsWrite = int.Parse(row["IsWrite"].ToString());
                }
                if (row["IsPlc"] != null && row["IsPlc"].ToString() != "")
                {
                    model.IsPlc = int.Parse(row["IsPlc"].ToString());
                }
                if (row["RecUser"] != null)
                {
                    model.RecUser = row["RecUser"].ToString();
                }
                if (row["RecName"] != null)
                {
                    model.RecName = row["RecName"].ToString();
                }
                if (row["RecTime"] != null && row["RecTime"].ToString() != "")
                {
                    model.RecTime = DateTime.Parse(row["RecTime"].ToString());
                }
                if (row["RecIp"] != null)
                {
                    model.RecIp = row["RecIp"].ToString();
                }
                if (row["IsLink"] != null && row["IsLink"].ToString() != "")
                {
                    model.IsLink = int.Parse(row["IsLink"].ToString());
                }
                if (row["LinkUrl"] != null)
                {
                    model.LinkUrl = row["LinkUrl"].ToString();
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
            strSql.Append("select ChnId,Pid,SchId,ChnName,ChnCode,OrderId,Stat,IsTop,Note,IsWrite,IsPlc,RecUser,RecName,RecTime,RecIp,IsLink,LinkUrl ");
            strSql.Append(" FROM WebSchChn ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ChnId,Pid,SchId,ChnName,ChnCode,OrderId,Stat,IsTop,Note,IsWrite,IsPlc,RecUser,RecName,RecTime,RecIp,IsLink,LinkUrl ");
            strSql.Append(" FROM WebSchChn ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM WebSchChn ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ChnId desc");
            }
            strSql.Append(")AS Row, T.*  from WebSchChn T ");
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
            parameters[0].Value = "WebSchChn";
            parameters[1].Value = "ChnId";
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

