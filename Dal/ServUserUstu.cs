﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;//Please add references
namespace SchSystem.DAL
{
    /// <summary>
    /// 数据访问类:ServUserUstu
    /// </summary>
    public partial class ServUserUstu
    {
        public ServUserUstu()
        { }
        #region  BasicMethod
        public bool Update(int ForId, int StuId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ServUserUstu set ");
            strSql.Append("StuId=@StuId,");
            strSql.Append("ForId=@ForId");
            strSql.Append(" where ForId=@ForId ");
            SqlParameter[] parameters = {
					new SqlParameter("@StuId", SqlDbType.Int,4),
					new SqlParameter("@ForId", SqlDbType.Int,4)};
            parameters[0].Value = StuId;
            parameters[1].Value = ForId;

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
        public bool ExistsFor(int ForId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ServUserUstu");
            strSql.Append(" where ForId=@ForId ");
            SqlParameter[] parameters = {
					new SqlParameter("@ForId", SqlDbType.Int,4)			};
            parameters[0].Value = ForId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool Exists(int StuId, int ForId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ServUserUstu");
            strSql.Append(" where StuId=@StuId and ForId=@ForId ");
            SqlParameter[] parameters = {
					new SqlParameter("@StuId", SqlDbType.Int,4),
					new SqlParameter("@ForId", SqlDbType.Int,4)			};
            parameters[0].Value = StuId;
            parameters[1].Value = ForId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool Exists(int AutoId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ServUserUstu");
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
        public int Add(SchSystem.Model.ServUserUstu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ServUserUstu(");
            strSql.Append("StuId,ForId,ServUserId)");
            strSql.Append(" values (");
            strSql.Append("@StuId,@ForId,@ServUserId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StuId", SqlDbType.Int,4),
					new SqlParameter("@ForId", SqlDbType.Int,4),
					new SqlParameter("@ServUserId", SqlDbType.Int,4)};
            parameters[0].Value = model.StuId;
            parameters[1].Value = model.ForId;
            parameters[2].Value = model.ServUserId;

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
        public bool Update(SchSystem.Model.ServUserUstu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ServUserUstu set ");
            strSql.Append("StuId=@StuId,");
            strSql.Append("ForId=@ForId,");
            strSql.Append("ServUserId=@ServUserId");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
					new SqlParameter("@StuId", SqlDbType.Int,4),
					new SqlParameter("@ForId", SqlDbType.Int,4),
					new SqlParameter("@ServUserId", SqlDbType.Int,4),
					new SqlParameter("@AutoId", SqlDbType.Int,4)};
            parameters[0].Value = model.StuId;
            parameters[1].Value = model.ForId;
            parameters[2].Value = model.ServUserId;
            parameters[3].Value = model.AutoId;

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
            strSql.Append("delete from ServUserUstu ");
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
            strSql.Append("delete from ServUserUstu ");
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
        public SchSystem.Model.ServUserUstu GetModel(int AutoId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AutoId,StuId,ForId,ServUserId from ServUserUstu ");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
            parameters[0].Value = AutoId;

            SchSystem.Model.ServUserUstu model = new SchSystem.Model.ServUserUstu();
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
        public SchSystem.Model.ServUserUstu DataRowToModel(DataRow row)
        {
            SchSystem.Model.ServUserUstu model = new SchSystem.Model.ServUserUstu();
            if (row != null)
            {
                if (row["AutoId"] != null && row["AutoId"].ToString() != "")
                {
                    model.AutoId = int.Parse(row["AutoId"].ToString());
                }
                if (row["StuId"] != null && row["StuId"].ToString() != "")
                {
                    model.StuId = int.Parse(row["StuId"].ToString());
                }
                if (row["ForId"] != null && row["ForId"].ToString() != "")
                {
                    model.ForId = int.Parse(row["ForId"].ToString());
                }
                if (row["ServUserId"] != null && row["ServUserId"].ToString() != "")
                {
                    model.ServUserId = int.Parse(row["ServUserId"].ToString());
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
            strSql.Append("select AutoId,StuId,ForId,ServUserId ");
            strSql.Append(" FROM ServUserUstu ");
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
            strSql.Append(" AutoId,StuId,ForId,ServUserId ");
            strSql.Append(" FROM ServUserUstu ");
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
            strSql.Append("select count(1) FROM ServUserUstu ");
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
            strSql.Append(")AS Row, T.*  from ServUserUstu T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

