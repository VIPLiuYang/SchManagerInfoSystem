using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;

namespace SchSystem.DAL
{
    /// <summary>
    /// 数据访问类:ServBusThd
    /// </summary>
    public partial class ServBusThd
    {
        public ServBusThd()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("BusId", "ServBusThd");
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
            strSql.Append(" FROM ServBusThd  ");
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
        public bool Exists(int BusId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ServBusThd");
            strSql.Append(" where BusId=@BusId");
            SqlParameter[] parameters = {
					new SqlParameter("@BusId", SqlDbType.Int,4)
			};
            parameters[0].Value = BusId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool ExistsCnName(int BusId, string CnName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ServBusThd ");
            strSql.Append("  where BusId<>@BusId  and CnName=@CnName ");
            SqlParameter[] parameters = {
					new SqlParameter("@CnName", SqlDbType.VarChar,20),
					new SqlParameter("@BusId", SqlDbType.Int,4) };
            parameters[0].Value = CnName;
            parameters[1].Value = BusId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool ExistsServiceId(int BusId, string ServiceId)
        {
            if (BusId==0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from ServBusThd ");
                strSql.Append("  where BusId<>@BusId  and ServiceId=@ServiceId ");
                SqlParameter[] parameters = {
					new SqlParameter("@ServiceId", SqlDbType.VarChar,20),
					new SqlParameter("@BusId", SqlDbType.Int,4) };
                parameters[0].Value = ServiceId;
                parameters[1].Value = BusId;

                return DbHelperSQL.Exists(strSql.ToString(), parameters);
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from ServBusThd ");
                strSql.Append("  where BusId<>@BusId  and ServiceId=@ServiceId ");
                SqlParameter[] parameters = {
					new SqlParameter("@ServiceId", SqlDbType.VarChar,20),
					new SqlParameter("@BusId", SqlDbType.Int,4) };
                parameters[0].Value = ServiceId;
                parameters[1].Value = BusId;

                return DbHelperSQL.Exists(strSql.ToString(), parameters);
            }
           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CnName"></param>
        /// <param name="BusId"></param>
        ///  <param name="currentCnName">正在修改的名称</param>
        /// <returns></returns>
        public DataSet ExistsCnNameUpdate(string CnName, int BusId, string currentCnName)
        {
            DataSet ds = null;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from ServBusThd");
                strSql.Append(" where   CnName=@CnName and CnName<>@currentCnName");
                SqlParameter[] parameters = { 
					 
					new SqlParameter("@CnName", SqlDbType.VarChar,15),
                    new SqlParameter("@currentCnName",SqlDbType.VarChar,15)
                                        };
                parameters[0].Value = CnName; 
                parameters[1].Value = currentCnName;
                ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            }
            catch (Exception ex)
            {

            }
            return ds;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CnName"></param>
        /// <param name="BusId"></param>
        ///  <param name="currentCnName">正在修改的名称</param>
        /// <returns></returns>
        public DataSet ExistsCodeUpdate(string Code, int BusId, string currentCode)
        {
            DataSet ds = null;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from ServBusThd");
                strSql.Append(" where   ServiceId=@Code and ServiceId<>@currentCode");
                SqlParameter[] parameters = { 
					 
					new SqlParameter("@Code", SqlDbType.VarChar,15),
                    new SqlParameter("@currentCode",SqlDbType.VarChar,15)
                                        };
                parameters[0].Value = Code;
                parameters[1].Value = currentCode;
                ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            }
            catch (Exception ex)
            {

            }
            return ds;

        }
        public string GetServBusNames(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("Select CnName From ServBus ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            } 
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["CnName"].ToString();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SchSystem.Model.ServBusThd model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ServBusThd(");
            strSql.Append("ThdName,ServiceId,FeeCode,CnName,BusMonth,BusNote,BusArea,BusUtype,Mbusid,BusType,BusUrl,Note,ThdMonth)");
            strSql.Append(" values (");
            strSql.Append("@ThdName,@ServiceId,@FeeCode,@CnName,@BusMonth,@BusNote,@BusArea,@BusUtype,@Mbusid,@BusType,@BusUrl,@Note,@ThdMonth)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ThdName", SqlDbType.NVarChar,50),
					new SqlParameter("@ServiceId", SqlDbType.VarChar,20),
					new SqlParameter("@FeeCode", SqlDbType.VarChar,10),
					new SqlParameter("@CnName", SqlDbType.VarChar,30),
					new SqlParameter("@BusMonth", SqlDbType.Int,4),
					new SqlParameter("@BusNote", SqlDbType.NVarChar,300),
					new SqlParameter("@BusArea", SqlDbType.VarChar,10),
					new SqlParameter("@BusUtype", SqlDbType.TinyInt,1),
					new SqlParameter("@Mbusid", SqlDbType.Int,4),
					new SqlParameter("@BusType", SqlDbType.TinyInt,1),
					new SqlParameter("@BusUrl", SqlDbType.VarChar,300),
					new SqlParameter("@Note", SqlDbType.VarChar,100),
                                        new SqlParameter("@ThdMonth", SqlDbType.Int,4)};
            parameters[0].Value = model.ThdName;
            parameters[1].Value = model.ServiceId;
            parameters[2].Value = model.FeeCode;
            parameters[3].Value = model.CnName;
            parameters[4].Value = model.BusMonth;
            parameters[5].Value = model.BusNote;
            parameters[6].Value = model.BusArea;
            parameters[7].Value = model.BusUtype;
            parameters[8].Value = model.Mbusid;
            parameters[9].Value = model.BusType;
            parameters[10].Value = model.BusUrl;
            parameters[11].Value = model.Note;
            parameters[12].Value = model.ThdMonth;

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
        public bool Update(SchSystem.Model.ServBusThd model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ServBusThd set ");
            strSql.Append("ThdName=@ThdName,");
            strSql.Append("ServiceId=@ServiceId,");
            strSql.Append("FeeCode=@FeeCode,");
            strSql.Append("CnName=@CnName,");
            strSql.Append("BusMonth=@BusMonth,");
            strSql.Append("BusNote=@BusNote,");
            strSql.Append("BusArea=@BusArea,");
            strSql.Append("BusUtype=@BusUtype,");
            strSql.Append("Mbusid=@Mbusid,");
            strSql.Append("BusType=@BusType,");
            strSql.Append("BusUrl=@BusUrl,");
            strSql.Append("Note=@Note,");
            strSql.Append("ThdMonth=@ThdMonth");
            strSql.Append(" where BusId=@BusId");
            SqlParameter[] parameters = {
					new SqlParameter("@ThdName", SqlDbType.NVarChar,50),
					new SqlParameter("@ServiceId", SqlDbType.VarChar,20),
					new SqlParameter("@FeeCode", SqlDbType.VarChar,10),
					new SqlParameter("@CnName", SqlDbType.VarChar,30),
					new SqlParameter("@BusMonth", SqlDbType.Int,4),
					new SqlParameter("@BusNote", SqlDbType.NVarChar,300),
					new SqlParameter("@BusArea", SqlDbType.VarChar,10),
					new SqlParameter("@BusUtype", SqlDbType.TinyInt,1),
					new SqlParameter("@Mbusid", SqlDbType.Int,4),
					new SqlParameter("@BusType", SqlDbType.TinyInt,1),
					new SqlParameter("@BusUrl", SqlDbType.VarChar,300),
					new SqlParameter("@Note", SqlDbType.VarChar,100),
                    new SqlParameter("@ThdMonth", SqlDbType.Int,4),
					new SqlParameter("@BusId", SqlDbType.Int,4)};
            parameters[0].Value = model.ThdName;
            parameters[1].Value = model.ServiceId;
            parameters[2].Value = model.FeeCode;
            parameters[3].Value = model.CnName;
            parameters[4].Value = model.BusMonth;
            parameters[5].Value = model.BusNote;
            parameters[6].Value = model.BusArea;
            parameters[7].Value = model.BusUtype;
            parameters[8].Value = model.Mbusid;
            parameters[9].Value = model.BusType;
            parameters[10].Value = model.BusUrl;
            parameters[11].Value = model.Note;
            parameters[12].Value = model.ThdMonth;
            parameters[13].Value = model.BusId;

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
        public bool Delete(int BusId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ServBusThd ");
            strSql.Append(" where BusId=@BusId");
            SqlParameter[] parameters = {
					new SqlParameter("@BusId", SqlDbType.Int,4)
			};
            parameters[0].Value = BusId;

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
        public bool DeleteList(string BusIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ServBusThd ");
            strSql.Append(" where BusId in (" + BusIdlist + ")  ");
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
        public SchSystem.Model.ServBusThd GetModel(int BusId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BusId,ThdName,ServiceId,FeeCode,CnName,BusMonth,BusNote,BusArea,BusUtype,Mbusid,BusType,BusUrl,Note,ThdMonth from ServBusThd ");
            strSql.Append(" where BusId=@BusId");
            SqlParameter[] parameters = {
					new SqlParameter("@BusId", SqlDbType.Int,4)
			};
            parameters[0].Value = BusId;

            SchSystem.Model.ServBusThd model = new SchSystem.Model.ServBusThd();
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
        public SchSystem.Model.ServBusThd DataRowToModel(DataRow row)
        {
            SchSystem.Model.ServBusThd model = new SchSystem.Model.ServBusThd();
            if (row != null)
            {
                if (row["BusId"] != null && row["BusId"].ToString() != "")
                {
                    model.BusId = int.Parse(row["BusId"].ToString());
                }
                if (row["ThdName"] != null)
                {
                    model.ThdName = row["ThdName"].ToString();
                }
                if (row["ServiceId"] != null)
                {
                    model.ServiceId = row["ServiceId"].ToString();
                }
                if (row["FeeCode"] != null)
                {
                    model.FeeCode = row["FeeCode"].ToString();
                }
                if (row["CnName"] != null)
                {
                    model.CnName = row["CnName"].ToString();
                }
                if (row["BusMonth"] != null && row["BusMonth"].ToString() != "")
                {
                    model.BusMonth = int.Parse(row["BusMonth"].ToString());
                }
                if (row["BusNote"] != null)
                {
                    model.BusNote = row["BusNote"].ToString();
                }
                if (row["BusArea"] != null)
                {
                    model.BusArea = row["BusArea"].ToString();
                }
                if (row["BusUtype"] != null && row["BusUtype"].ToString() != "")
                {
                    model.BusUtype = int.Parse(row["BusUtype"].ToString());
                }
                if (row["Mbusid"] != null && row["Mbusid"].ToString() != "")
                {
                    model.Mbusid = int.Parse(row["Mbusid"].ToString());
                }
                if (row["BusType"] != null && row["BusType"].ToString() != "")
                {
                    model.BusType = int.Parse(row["BusType"].ToString());
                }
                if (row["BusUrl"] != null)
                {
                    model.BusUrl = row["BusUrl"].ToString();
                }
                if (row["Note"] != null)
                {
                    model.Note = row["Note"].ToString();
                }
                if (row["ThdMonth"] != null && row["ThdMonth"].ToString() != "")
                {
                    model.ThdMonth = int.Parse(row["ThdMonth"].ToString());
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
            strSql.Append("select BusId,ThdName,ServiceId,FeeCode,CnName,BusMonth,BusNote,BusArea,BusUtype,Mbusid,BusType,BusUrl,Note ");
            strSql.Append(" FROM ServBusThd ");
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
            strSql.Append(" BusId,ThdName,ServiceId,FeeCode,CnName,BusMonth,BusNote,BusArea,BusUtype,Mbusid,BusType,BusUrl,Note ");
            strSql.Append(" FROM ServBusThd ");
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
            strSql.Append("select count(1) FROM ServBusThd ");
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
                strSql.Append("order by T.BusId desc");
            }
            strSql.Append(")AS Row, T.*  from ServBusThd T ");
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
            parameters[0].Value = "ServBusThd";
            parameters[1].Value = "BusId";
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

