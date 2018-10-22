using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;//Please add references
namespace SchSystem.DAL
{
    /// <summary>
    /// 数据访问类:ServFuncExt
    /// </summary>
    public partial class ServFuncExt
    {
        public ServFuncExt()
        { }
        #region  BasicMethod
        public DataSet GetListItemV(string cols, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (cols.Trim() != "")
            {
                strSql.Append(cols);
            }
            strSql.Append(" FROM ServFuncExtItemV ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        
        public DataSet GetList(string cols, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (cols.Trim() != "")
            {
                strSql.Append(cols);
            }
            strSql.Append(" FROM ServFuncExt ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetListV(string cols, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (cols.Trim() != "")
            {
                strSql.Append(cols);
            }
            strSql.Append(" FROM ServFuncExtV ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AutoId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ServFuncExt");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
            parameters[0].Value = AutoId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SchSystem.Model.ServFuncExt model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ServFuncExt(");
            strSql.Append("FuncId,NapeCode,NapeCodes,NapeC)");
            strSql.Append(" values (");
            strSql.Append("@FuncId,@NapeCode,@NapeCodes,@NapeC)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@FuncId", SqlDbType.Int,4),
					new SqlParameter("@NapeCode", SqlDbType.VarChar,10),
					new SqlParameter("@NapeCodes", SqlDbType.VarChar,200),
					new SqlParameter("@NapeC", SqlDbType.TinyInt,1)};
            parameters[0].Value = model.FuncId;
            parameters[1].Value = model.NapeCode;
            parameters[2].Value = model.NapeCodes;
            parameters[3].Value = model.NapeC;

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
        public bool Update(SchSystem.Model.ServFuncExt model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ServFuncExt set ");
            strSql.Append("FuncId=@FuncId,");
            strSql.Append("NapeCode=@NapeCode,");
            strSql.Append("NapeCodes=@NapeCodes,");
            strSql.Append("NapeC=@NapeC");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
					new SqlParameter("@FuncId", SqlDbType.Int,4),
					new SqlParameter("@NapeCode", SqlDbType.VarChar,10),
					new SqlParameter("@NapeCodes", SqlDbType.VarChar,200),
					new SqlParameter("@NapeC", SqlDbType.TinyInt,1),
					new SqlParameter("@AutoId", SqlDbType.Int,4)};
            parameters[0].Value = model.FuncId;
            parameters[1].Value = model.NapeCode;
            parameters[2].Value = model.NapeCodes;
            parameters[3].Value = model.NapeC;
            parameters[4].Value = model.AutoId;

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
        public bool Delete(int FuncId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ServFuncExt ");
            strSql.Append(" where FuncId=@FuncId");
            SqlParameter[] parameters = {
					new SqlParameter("@FuncId", SqlDbType.Int,4)
			};
            parameters[0].Value = FuncId;

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
        public bool DeleteList(string AutoIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ServFuncExt ");
            strSql.Append(" where AutoId in (" + AutoIdlist + ")  ");
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
        public SchSystem.Model.ServFuncExt GetModel(int AutoId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AutoId,FuncId,NapeCode,NapeCodes,NapeC from ServFuncExt ");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
            parameters[0].Value = AutoId;

            SchSystem.Model.ServFuncExt model = new SchSystem.Model.ServFuncExt();
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
        public SchSystem.Model.ServFuncExt DataRowToModel(DataRow row)
        {
            SchSystem.Model.ServFuncExt model = new SchSystem.Model.ServFuncExt();
            if (row != null)
            {
                if (row["AutoId"] != null && row["AutoId"].ToString() != "")
                {
                    model.AutoId = int.Parse(row["AutoId"].ToString());
                }
                if (row["FuncId"] != null && row["FuncId"].ToString() != "")
                {
                    model.FuncId = int.Parse(row["FuncId"].ToString());
                }
                if (row["NapeCode"] != null)
                {
                    model.NapeCode = row["NapeCode"].ToString();
                }
                if (row["NapeCodes"] != null)
                {
                    model.NapeCodes = row["NapeCodes"].ToString();
                }
                if (row["NapeC"] != null && row["NapeC"].ToString() != "")
                {
                    model.NapeC = int.Parse(row["NapeC"].ToString());
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
            strSql.Append("select AutoId,FuncId,NapeCode,NapeCodes,NapeC ");
            strSql.Append(" FROM ServFuncExt ");
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
            strSql.Append(" AutoId,FuncId,NapeCode,NapeCodes,NapeC ");
            strSql.Append(" FROM ServFuncExt ");
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
            strSql.Append("select count(1) FROM ServFuncExt ");
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
                strSql.Append("order by T.AutoId desc");
            }
            strSql.Append(")AS Row, T.*  from ServFuncExt T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        public string ExecuteSqlBulkCopy(DataTable table, string TableName)
        {
            return DbHelperSQL.ExecuteSqlBulkCopy(table, TableName);
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
            parameters[0].Value = "ServFuncExt";
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

