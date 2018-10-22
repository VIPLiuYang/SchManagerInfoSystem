using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;//Please add references
namespace SchSystem.DAL
{
    /// <summary>
    /// 数据访问类:WxMinUnSysUser
    /// </summary>
    public partial class WxMinUnSysUser
    {
        public WxMinUnSysUser()
        { }
        #region  BasicMethod
        public bool UpdateUn(SchSystem.Model.WxMinUnSysUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WxMinUnSysUser set ");
            strSql.Append("WxUid=@WxUid,");
            strSql.Append("SysUname=@SysUname,");
            strSql.Append("SysType=@SysType,");
            strSql.Append("SchId=@SchId,");
            strSql.Append("Mobile=@Mobile");
            strSql.Append(" where WxUid=@WxUid ");
            SqlParameter[] parameters = {
					new SqlParameter("@WxUid", SqlDbType.VarChar,50),
					new SqlParameter("@SysUname", SqlDbType.VarChar,50),
					new SqlParameter("@SysType", SqlDbType.TinyInt,1),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50)};
            parameters[0].Value = model.WxUid;
            parameters[1].Value = model.SysUname;
            parameters[2].Value = model.SysType;
            parameters[3].Value = model.SchId;
            parameters[4].Value = model.Mobile;

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
            if (cols.Trim() != "")
            {
                strSql.Append(cols);
            }
            strSql.Append(" FROM WxMinUnSysUser ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public bool ExistsUid(string WxUid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from WxMinUnSysUser");
            strSql.Append(" where WxUid=@WxUid ");
            SqlParameter[] parameters = {
					new SqlParameter("@WxUid", SqlDbType.VarChar,50)			};
            parameters[0].Value = WxUid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SchSystem.Model.WxMinUnSysUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WxMinUnSysUser(");
            strSql.Append("WxUid,SysUname,SysType,SchId,Mobile,RecTime)");
            strSql.Append(" values (");
            strSql.Append("@WxUid,@SysUname,@SysType,@SchId,@Mobile,@RecTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@WxUid", SqlDbType.VarChar,50),
					new SqlParameter("@SysUname", SqlDbType.VarChar,50),
					new SqlParameter("@SysType", SqlDbType.TinyInt,1),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@RecTime", SqlDbType.DateTime)};
            parameters[0].Value = model.WxUid;
            parameters[1].Value = model.SysUname;
            parameters[2].Value = model.SysType;
            parameters[3].Value = model.SchId;
            parameters[4].Value = model.Mobile;
            parameters[5].Value = model.RecTime;

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
        public bool Update(SchSystem.Model.WxMinUnSysUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WxMinUnSysUser set ");
            strSql.Append("WxUid=@WxUid,");
            strSql.Append("SysUname=@SysUname,");
            strSql.Append("SysType=@SysType,");
            strSql.Append("SchId=@SchId,");
            strSql.Append("Mobile=@Mobile,");
            strSql.Append("RecTime=@RecTime");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
					new SqlParameter("@WxUid", SqlDbType.VarChar,50),
					new SqlParameter("@SysUname", SqlDbType.VarChar,50),
					new SqlParameter("@SysType", SqlDbType.TinyInt,1),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@AutoId", SqlDbType.Int,4)};
            parameters[0].Value = model.WxUid;
            parameters[1].Value = model.SysUname;
            parameters[2].Value = model.SysType;
            parameters[3].Value = model.SchId;
            parameters[4].Value = model.Mobile;
            parameters[5].Value = model.RecTime;
            parameters[6].Value = model.AutoId;

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
            strSql.Append("delete from WxMinUnSysUser ");
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
            strSql.Append("delete from WxMinUnSysUser ");
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
        public SchSystem.Model.WxMinUnSysUser GetModel(int AutoId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AutoId,WxUid,SysUname,SysType,SchId,Mobile,RecTime from WxMinUnSysUser ");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
            parameters[0].Value = AutoId;

            SchSystem.Model.WxMinUnSysUser model = new SchSystem.Model.WxMinUnSysUser();
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
        public SchSystem.Model.WxMinUnSysUser DataRowToModel(DataRow row)
        {
            SchSystem.Model.WxMinUnSysUser model = new SchSystem.Model.WxMinUnSysUser();
            if (row != null)
            {
                if (row["AutoId"] != null && row["AutoId"].ToString() != "")
                {
                    model.AutoId = int.Parse(row["AutoId"].ToString());
                }
                if (row["WxUid"] != null)
                {
                    model.WxUid = row["WxUid"].ToString();
                }
                if (row["SysUname"] != null)
                {
                    model.SysUname = row["SysUname"].ToString();
                }
                if (row["SysType"] != null && row["SysType"].ToString() != "")
                {
                    model.SysType = int.Parse(row["SysType"].ToString());
                }
                if (row["SchId"] != null && row["SchId"].ToString() != "")
                {
                    model.SchId = int.Parse(row["SchId"].ToString());
                }
                if (row["Mobile"] != null)
                {
                    model.Mobile = row["Mobile"].ToString();
                }
                if (row["RecTime"] != null && row["RecTime"].ToString() != "")
                {
                    model.RecTime = DateTime.Parse(row["RecTime"].ToString());
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
            strSql.Append("select AutoId,WxUid,SysUname,SysType,SchId,Mobile,RecTime ");
            strSql.Append(" FROM WxMinUnSysUser ");
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
            strSql.Append(" AutoId,WxUid,SysUname,SysType,SchId,Mobile,RecTime ");
            strSql.Append(" FROM WxMinUnSysUser ");
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
            strSql.Append("select count(1) FROM WxMinUnSysUser ");
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
            strSql.Append(")AS Row, T.*  from WxMinUnSysUser T ");
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
            parameters[0].Value = "WxMinUnSysUser";
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

