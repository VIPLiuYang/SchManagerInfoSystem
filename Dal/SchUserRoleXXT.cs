using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;//Please add references
namespace SchSystem.DAL
{
    /// <summary>
    /// 数据访问类:SchUserRoleXXT
    /// </summary>
    public partial class SchUserRoleXXT
    {
        public SchUserRoleXXT()
        { }
        #region  BasicMethod

        public int DoUserRole(string UserName, string RecUser, string SchId, string RoleIds)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SchUserRoleXXT where UserName='" + UserName + "' and SchId=" + SchId);
            strSql.Append(" insert into SchUserRoleXXT(RoleID,UserName,RecTime,RecUser,LastRecTime,LastRecUser,SchId)");
            strSql.Append(" select RoleID,'" + UserName + "',getdate(),'" + RecUser + "',getdate(),'" + RecUser + "','" + SchId + "' from SchRoleXXT where RoleID in (" + RoleIds + ")");
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 判断角色是否正在使用
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public bool ExistsRoleData(string SchId, string RoleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchUserRoleXXT");
            strSql.Append(" where SchId=@SchId and RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,6),
                    new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
            parameters[0].Value = SchId;
            parameters[1].Value = RoleId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("AutoId", "SchUserRoleXXT");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AutoId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchUserRoleXXT");
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
        public int Add(SchSystem.Model.SchUserRoleXXT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SchUserRoleXXT(");
            strSql.Append("RoleID,UserName,RecTime,RecUser,LastRecTime,LastRecUser,SchId)");
            strSql.Append(" values (");
            strSql.Append("@RoleID,@UserName,@RecTime,@RecUser,@LastRecTime,@LastRecUser,@SchId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,20),
					new SqlParameter("@RecTime", SqlDbType.SmallDateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,50),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@SchId", SqlDbType.Int,4)};
            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.RecTime;
            parameters[3].Value = model.RecUser;
            parameters[4].Value = model.LastRecTime;
            parameters[5].Value = model.LastRecUser;
            parameters[6].Value = model.SchId;

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
        public bool Update(SchSystem.Model.SchUserRoleXXT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchUserRoleXXT set ");
            strSql.Append("RoleID=@RoleID,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("RecTime=@RecTime,");
            strSql.Append("RecUser=@RecUser,");
            strSql.Append("LastRecTime=@LastRecTime,");
            strSql.Append("LastRecUser=@LastRecUser,");
            strSql.Append("SchId=@SchId");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,20),
					new SqlParameter("@RecTime", SqlDbType.SmallDateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,50),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@AutoId", SqlDbType.Int,4)};
            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.RecTime;
            parameters[3].Value = model.RecUser;
            parameters[4].Value = model.LastRecTime;
            parameters[5].Value = model.LastRecUser;
            parameters[6].Value = model.SchId;
            parameters[7].Value = model.AutoId;

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
            strSql.Append("delete from SchUserRoleXXT ");
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
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string AutoIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SchUserRoleXXT ");
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
        public SchSystem.Model.SchUserRoleXXT GetModel(int AutoId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AutoId,RoleID,UserName,RecTime,RecUser,LastRecTime,LastRecUser,SchId from SchUserRoleXXT ");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
            parameters[0].Value = AutoId;

            SchSystem.Model.SchUserRoleXXT model = new SchSystem.Model.SchUserRoleXXT();
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
        public SchSystem.Model.SchUserRoleXXT DataRowToModel(DataRow row)
        {
            SchSystem.Model.SchUserRoleXXT model = new SchSystem.Model.SchUserRoleXXT();
            if (row != null)
            {
                if (row["AutoId"] != null && row["AutoId"].ToString() != "")
                {
                    model.AutoId = int.Parse(row["AutoId"].ToString());
                }
                if (row["RoleID"] != null && row["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(row["RoleID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AutoId,RoleID,UserName,RecTime,RecUser,LastRecTime,LastRecUser,SchId ");
            strSql.Append(" FROM SchUserRoleXXT ");
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
            strSql.Append(" AutoId,RoleID,UserName,RecTime,RecUser,LastRecTime,LastRecUser,SchId ");
            strSql.Append(" FROM SchUserRoleXXT ");
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
            strSql.Append("select count(1) FROM SchUserRoleXXT ");
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
            strSql.Append(")AS Row, T.*  from SchUserRoleXXT T ");
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
            parameters[0].Value = "SchUserRoleXXT";
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

