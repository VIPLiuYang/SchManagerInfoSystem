using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;//Please add references
namespace SchSystem.DAL
{
    /// <summary>
    /// 数据访问类:SchRoleXXT
    /// </summary>
    public partial class SchRoleXXT
    {
        public SchRoleXXT()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("RoleId", "SchRoleXXT");
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateStat(SchSystem.Model.SchRoleXXT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchRoleXXT set ");
            strSql.Append("Stat=@Stat,");
            strSql.Append("LastRecTime=@LastRecTime,");
            strSql.Append("LastRecUser=@LastRecUser");
            strSql.Append(" where RoleId=@RoleId");
            SqlParameter[] parameters = {
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@RoleId", SqlDbType.Int,4)};
            parameters[0].Value = model.Stat;
            parameters[1].Value = model.LastRecTime;
            parameters[2].Value = model.LastRecUser;
            parameters[3].Value = model.RoleId;

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
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RoleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchRoleXXT");
            strSql.Append(" where RoleId=@RoleId");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleId", SqlDbType.Int,4)
			};
            parameters[0].Value = RoleId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SchSystem.Model.SchRoleXXT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SchRoleXXT(");
            strSql.Append("RoleName,RoleStr,RoleStrExt,Stat,RecTime,RecUser,LastRecTime,LastRecUser,SchId,SysType)");
            strSql.Append(" values (");
            strSql.Append("@RoleName,@RoleStr,@RoleStrExt,@Stat,@RecTime,@RecUser,@LastRecTime,@LastRecUser,@SchId,@SysType)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.VarChar,50),
					new SqlParameter("@RoleStr", SqlDbType.VarChar,4000),
					new SqlParameter("@RoleStrExt", SqlDbType.VarChar,50),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@RecTime", SqlDbType.SmallDateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,50),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@SysType", SqlDbType.TinyInt,1)};
            parameters[0].Value = model.RoleName;
            parameters[1].Value = model.RoleStr;
            parameters[2].Value = model.RoleStrExt;
            parameters[3].Value = model.Stat;
            parameters[4].Value = model.RecTime;
            parameters[5].Value = model.RecUser;
            parameters[6].Value = model.LastRecTime;
            parameters[7].Value = model.LastRecUser;
            parameters[8].Value = model.SchId;
            parameters[9].Value = model.SysType;

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
        public bool Update(SchSystem.Model.SchRoleXXT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchRoleXXT set ");
            strSql.Append("RoleName=@RoleName,");
            strSql.Append("RoleStr=@RoleStr,");
            strSql.Append("RoleStrExt=@RoleStrExt,");
            strSql.Append("Stat=@Stat,");
            strSql.Append("RecTime=@RecTime,");
            strSql.Append("RecUser=@RecUser,");
            strSql.Append("LastRecTime=@LastRecTime,");
            strSql.Append("LastRecUser=@LastRecUser,");
            strSql.Append("SchId=@SchId,");
            strSql.Append("SysType=@SysType");
            strSql.Append(" where RoleId=@RoleId");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.VarChar,50),
					new SqlParameter("@RoleStr", SqlDbType.VarChar,4000),
					new SqlParameter("@RoleStrExt", SqlDbType.VarChar,50),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@RecTime", SqlDbType.SmallDateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,50),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@SysType", SqlDbType.TinyInt,1),
					new SqlParameter("@RoleId", SqlDbType.Int,4)};
            parameters[0].Value = model.RoleName;
            parameters[1].Value = model.RoleStr;
            parameters[2].Value = model.RoleStrExt;
            parameters[3].Value = model.Stat;
            parameters[4].Value = model.RecTime;
            parameters[5].Value = model.RecUser;
            parameters[6].Value = model.LastRecTime;
            parameters[7].Value = model.LastRecUser;
            parameters[8].Value = model.SchId;
            parameters[9].Value = model.SysType;
            parameters[10].Value = model.RoleId;

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
        public bool Delete(int RoleId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SchRoleXXT ");
            strSql.Append(" where RoleId=@RoleId");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleId", SqlDbType.Int,4)
			};
            parameters[0].Value = RoleId;

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
        public bool DeleteList(string RoleIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SchRoleXXT ");
            strSql.Append(" where RoleId in (" + RoleIdlist + ")  ");
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
        public SchSystem.Model.SchRoleXXT GetModel(int RoleId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 RoleId,RoleName,RoleStr,RoleStrExt,Stat,RecTime,RecUser,LastRecTime,LastRecUser,SchId,SysType from SchRoleXXT ");
            strSql.Append(" where RoleId=@RoleId");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleId", SqlDbType.Int,4)
			};
            parameters[0].Value = RoleId;

            SchSystem.Model.SchRoleXXT model = new SchSystem.Model.SchRoleXXT();
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
        public SchSystem.Model.SchRoleXXT DataRowToModel(DataRow row)
        {
            SchSystem.Model.SchRoleXXT model = new SchSystem.Model.SchRoleXXT();
            if (row != null)
            {
                if (row["RoleId"] != null && row["RoleId"].ToString() != "")
                {
                    model.RoleId = int.Parse(row["RoleId"].ToString());
                }
                if (row["RoleName"] != null)
                {
                    model.RoleName = row["RoleName"].ToString();
                }
                if (row["RoleStr"] != null)
                {
                    model.RoleStr = row["RoleStr"].ToString();
                }
                if (row["RoleStrExt"] != null)
                {
                    model.RoleStrExt = row["RoleStrExt"].ToString();
                }
                if (row["Stat"] != null && row["Stat"].ToString() != "")
                {
                    model.Stat = int.Parse(row["Stat"].ToString());
                }
                if (row["RecTime"] != null && row["RecTime"].ToString() != "")
                {
                    model.RecTime = DateTime.Parse(row["RecTime"].ToString());
                }
                if (row["RecUser"] != null)
                {
                    model.RecUser = row["RecUser"].ToString();
                }
                if (row["LastRecTime"] != null && row["LastRecTime"].ToString() != "")
                {
                    model.LastRecTime = DateTime.Parse(row["LastRecTime"].ToString());
                }
                if (row["LastRecUser"] != null)
                {
                    model.LastRecUser = row["LastRecUser"].ToString();
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
            strSql.Append("select RoleId,RoleName,RoleStr,RoleStrExt,Stat,RecTime,RecUser,LastRecTime,LastRecUser,SchId,SysType ");
            strSql.Append(" FROM SchRoleXXT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetList(string Cols, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + Cols);
            strSql.Append(" FROM SchRoleXXT ");
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
            strSql.Append(" RoleId,RoleName,RoleStr,RoleStrExt,Stat,RecTime,RecUser,LastRecTime,LastRecUser,SchId,SysType ");
            strSql.Append(" FROM SchRoleXXT ");
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
            strSql.Append("select count(1) FROM SchRoleXXT ");
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
                strSql.Append("order by T.RoleId desc");
            }
            strSql.Append(")AS Row, T.*  from SchRoleXXT T ");
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
            parameters[0].Value = "SchRoleXXT";
            parameters[1].Value = "RoleId";
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

