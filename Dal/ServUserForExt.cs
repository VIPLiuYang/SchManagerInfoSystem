using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;//Please add references
namespace SchSystem.DAL
{
    /// <summary>
    /// 数据访问类:ServUserForExt
    /// </summary>
    public partial class ServUserForExt
    {
        public ServUserForExt()
        { }
        #region  BasicMethod
        public DataSet GetList(string cols, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (cols.Trim() != "")
            {
                strSql.Append(cols);
            }
            strSql.Append(" FROM ServUserForExt ");
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AutoId,UserForId,Fcode,NapeCode,NapeCodes ");
            strSql.Append(" FROM ServUserForExt ");
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
            strSql.Append(" AutoId,UserForId,Fcode,NapeCode,NapeCodes ");
            strSql.Append(" FROM ServUserForExt ");
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
            strSql.Append("select count(1) FROM ServUserForExt ");
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
            strSql.Append(")AS Row, T.*  from ServUserForExt T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SchSystem.Model.ServUserForExt model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ServUserForExt(");
            strSql.Append("UserForId,Fcode,NapeCode,NapeCodes)");
            strSql.Append(" values (");
            strSql.Append("@UserForId,@Fcode,@NapeCode,@NapeCodes)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserForId", SqlDbType.Int,4),
					new SqlParameter("@Fcode", SqlDbType.VarChar,20),
					new SqlParameter("@NapeCode", SqlDbType.VarChar,10),
					new SqlParameter("@NapeCodes", SqlDbType.VarChar,200)};
            parameters[0].Value = model.UserForId;
            parameters[1].Value = model.Fcode;
            parameters[2].Value = model.NapeCode;
            parameters[3].Value = model.NapeCodes;

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
        public bool Update(SchSystem.Model.ServUserForExt model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ServUserForExt set ");
            strSql.Append("UserForId=@UserForId,");
            strSql.Append("Fcode=@Fcode,");
            strSql.Append("NapeCode=@NapeCode,");
            strSql.Append("NapeCodes=@NapeCodes");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
					new SqlParameter("@UserForId", SqlDbType.Int,4),
					new SqlParameter("@Fcode", SqlDbType.VarChar,20),
					new SqlParameter("@NapeCode", SqlDbType.VarChar,10),
					new SqlParameter("@NapeCodes", SqlDbType.VarChar,200),
					new SqlParameter("@AutoId", SqlDbType.Int,4)};
            parameters[0].Value = model.UserForId;
            parameters[1].Value = model.Fcode;
            parameters[2].Value = model.NapeCode;
            parameters[3].Value = model.NapeCodes;
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
        public bool Delete(int AutoId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ServUserForExt ");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
            parameters[0].Value = AutoId;

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
        public bool DeleteId(int UserForId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ServUserForExt ");
            strSql.Append(" where UserForId=@UserForId");
            SqlParameter[] parameters = {
					new SqlParameter("@UserForId", SqlDbType.Int,4)
			};
            parameters[0].Value = UserForId;

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
        public bool DeleteList(int ForId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ServUserForExt ");
            strSql.Append(" where UserForId = " + ForId);
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
        public SchSystem.Model.ServUserForExt GetModel(int AutoId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AutoId,UserForId,Fcode,NapeCode,NapeCodes from ServUserForExt ");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
            parameters[0].Value = AutoId;

            SchSystem.Model.ServUserForExt model = new SchSystem.Model.ServUserForExt();
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
        public SchSystem.Model.ServUserForExt DataRowToModel(DataRow row)
        {
            SchSystem.Model.ServUserForExt model = new SchSystem.Model.ServUserForExt();
            if (row != null)
            {
                if (row["AutoId"] != null && row["AutoId"].ToString() != "")
                {
                    model.AutoId = int.Parse(row["AutoId"].ToString());
                }
                if (row["UserForId"] != null && row["UserForId"].ToString() != "")
                {
                    model.UserForId = int.Parse(row["UserForId"].ToString());
                }
                if (row["Fcode"] != null)
                {
                    model.Fcode = row["Fcode"].ToString();
                }
                if (row["NapeCode"] != null)
                {
                    model.NapeCode = row["NapeCode"].ToString();
                }
                if (row["NapeCodes"] != null)
                {
                    model.NapeCodes = row["NapeCodes"].ToString();
                }
            }
            return model;
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
            parameters[0].Value = "ServUserForExt";
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

