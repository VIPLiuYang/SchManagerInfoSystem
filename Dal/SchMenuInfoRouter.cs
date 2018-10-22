using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;//Please add references
namespace SchSystem.DAL
{
    /// <summary>
    /// 数据访问类:SchMenuInfoRouter
    /// </summary>
    public partial class SchMenuInfoRouter
    {
        public SchMenuInfoRouter()
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
            strSql.Append(" FROM SchMenuInfoRouter ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int MenuId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchMenuInfoRouter");
            strSql.Append(" where MenuId=@MenuId");
            SqlParameter[] parameters = {
					new SqlParameter("@MenuId", SqlDbType.Int,4)
			};
            parameters[0].Value = MenuId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SchSystem.Model.SchMenuInfoRouter model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SchMenuInfoRouter(");
            strSql.Append("NavUrl,TextName,FuncCode,SchId,SysType)");
            strSql.Append(" values (");
            strSql.Append("@NavUrl,@TextName,@FuncCode,@SchId,@SysType)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@NavUrl", SqlDbType.VarChar,200),
					new SqlParameter("@TextName", SqlDbType.VarChar,30),
					new SqlParameter("@FuncCode", SqlDbType.Int,4),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@SysType", SqlDbType.TinyInt,1)};
            parameters[0].Value = model.NavUrl;
            parameters[1].Value = model.TextName;
            parameters[2].Value = model.FuncCode;
            parameters[3].Value = model.SchId;
            parameters[4].Value = model.SysType;

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
        public bool Update(SchSystem.Model.SchMenuInfoRouter model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchMenuInfoRouter set ");
            strSql.Append("NavUrl=@NavUrl,");
            strSql.Append("TextName=@TextName,");
            strSql.Append("FuncCode=@FuncCode,");
            strSql.Append("SchId=@SchId,");
            strSql.Append("SysType=@SysType");
            strSql.Append(" where MenuId=@MenuId");
            SqlParameter[] parameters = {
					new SqlParameter("@NavUrl", SqlDbType.VarChar,200),
					new SqlParameter("@TextName", SqlDbType.VarChar,30),
					new SqlParameter("@FuncCode", SqlDbType.Int,4),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@SysType", SqlDbType.TinyInt,1),
					new SqlParameter("@MenuId", SqlDbType.Int,4)};
            parameters[0].Value = model.NavUrl;
            parameters[1].Value = model.TextName;
            parameters[2].Value = model.FuncCode;
            parameters[3].Value = model.SchId;
            parameters[4].Value = model.SysType;
            parameters[5].Value = model.MenuId;

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
        public bool Delete(int MenuId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SchMenuInfoRouter ");
            strSql.Append(" where MenuId=@MenuId");
            SqlParameter[] parameters = {
					new SqlParameter("@MenuId", SqlDbType.Int,4)
			};
            parameters[0].Value = MenuId;

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
        public bool DeleteList(string MenuIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SchMenuInfoRouter ");
            strSql.Append(" where MenuId in (" + MenuIdlist + ")  ");
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
        public SchSystem.Model.SchMenuInfoRouter GetModel(int MenuId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MenuId,NavUrl,TextName,FuncCode,SchId,SysType from SchMenuInfoRouter ");
            strSql.Append(" where MenuId=@MenuId");
            SqlParameter[] parameters = {
					new SqlParameter("@MenuId", SqlDbType.Int,4)
			};
            parameters[0].Value = MenuId;

            SchSystem.Model.SchMenuInfoRouter model = new SchSystem.Model.SchMenuInfoRouter();
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
        public SchSystem.Model.SchMenuInfoRouter DataRowToModel(DataRow row)
        {
            SchSystem.Model.SchMenuInfoRouter model = new SchSystem.Model.SchMenuInfoRouter();
            if (row != null)
            {
                if (row["MenuId"] != null && row["MenuId"].ToString() != "")
                {
                    model.MenuId = int.Parse(row["MenuId"].ToString());
                }
                if (row["NavUrl"] != null)
                {
                    model.NavUrl = row["NavUrl"].ToString();
                }
                if (row["TextName"] != null)
                {
                    model.TextName = row["TextName"].ToString();
                }
                if (row["FuncCode"] != null && row["FuncCode"].ToString() != "")
                {
                    model.FuncCode = int.Parse(row["FuncCode"].ToString());
                }
                if (row["SchId"] != null && row["SchId"].ToString() != "")
                {
                    model.SchId = int.Parse(row["SchId"].ToString());
                }
                if (row["SysType"] != null && row["SysType"].ToString() != "")
                {
                    model.SysType = int.Parse(row["SysType"].ToString());
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
            strSql.Append("select MenuId,NavUrl,TextName,FuncCode,SchId,SysType ");
            strSql.Append(" FROM SchMenuInfoRouter ");
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
            strSql.Append(" MenuId,NavUrl,TextName,FuncCode,SchId,SysType ");
            strSql.Append(" FROM SchMenuInfoRouter ");
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
            strSql.Append("select count(1) FROM SchMenuInfoRouter ");
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
                strSql.Append("order by T.MenuId desc");
            }
            strSql.Append(")AS Row, T.*  from SchMenuInfoRouter T ");
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
            parameters[0].Value = "SchMenuInfoRouter";
            parameters[1].Value = "MenuId";
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

