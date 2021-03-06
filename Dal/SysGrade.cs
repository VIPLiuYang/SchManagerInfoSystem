﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;//Please add references
namespace SchSystem.DAL
{
    /// <summary>
    /// 数据访问类:SysGrade
    /// </summary>
    public partial class SysGrade
    {
        public SysGrade()
        { }
        #region  BasicMethod
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateCode(SchSystem.Model.SysGrade model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SysGrade set ");
            strSql.Append("GradeType=@GradeType,");
            strSql.Append("GradeName=@GradeName,");
            strSql.Append("GradeCode=@GradeCode");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
					new SqlParameter("@GradeType", SqlDbType.TinyInt,1),
					new SqlParameter("@GradeName", SqlDbType.NVarChar,10),
					new SqlParameter("@GradeCode", SqlDbType.VarChar,10),
					new SqlParameter("@AutoId", SqlDbType.Int,4)};
            parameters[0].Value = model.GradeType;
            parameters[1].Value = model.GradeName;
            parameters[2].Value = model.GradeCode;
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
            strSql.Append(" FROM SysGrade  ");
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
        public DataSet GetList(string Cols, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + Cols);
            strSql.Append(" FROM SysGrade ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SchSystem.Model.SysGrade model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SysGrade(");
            strSql.Append("GradeType,GradeName,GradeCode)");
            strSql.Append(" values (");
            strSql.Append("@GradeType,@GradeName,@GradeCode)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@GradeType", SqlDbType.TinyInt,1),
					new SqlParameter("@GradeName", SqlDbType.NVarChar,10),
					new SqlParameter("@GradeCode", SqlDbType.VarChar,10)};
            parameters[0].Value = model.GradeType;
            parameters[1].Value = model.GradeName;
            parameters[2].Value = model.GradeCode;

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
        public bool Update(SchSystem.Model.SysGrade model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SysGrade set ");
            strSql.Append("GradeType=@GradeType,");
            strSql.Append("GradeName=@GradeName");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
					new SqlParameter("@GradeType", SqlDbType.TinyInt,1),
					new SqlParameter("@GradeName", SqlDbType.NVarChar,10),
					new SqlParameter("@AutoId", SqlDbType.Int,4)};
            parameters[0].Value = model.GradeType;
            parameters[1].Value = model.GradeName;
            parameters[2].Value = model.AutoId;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            DbHelperSQL.ExecuteSql("update SchGradeInfo set GradeName=b.GradeName from SchGradeInfo a,SysGrade b where a.GradeCode=b.GradeCode and a.GradeName<>b.GradeName");
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
            strSql.Append("delete from SysGrade ");
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
        public bool DeleteList(string PerCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SysGrade ");
            strSql.Append(" where GradeType = '" + PerCode + "' ");
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
        public SchSystem.Model.SysGrade GetModel(int AutoId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AutoId,GradeType,GradeTypeName,GradeName,GradeLv,GradeLvName,GradeCode from SysGrade ");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
            parameters[0].Value = AutoId;

            SchSystem.Model.SysGrade model = new SchSystem.Model.SysGrade();
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
        public SchSystem.Model.SysGrade DataRowToModel(DataRow row)
        {
            SchSystem.Model.SysGrade model = new SchSystem.Model.SysGrade();
            if (row != null)
            {
                if (row["AutoId"] != null && row["AutoId"].ToString() != "")
                {
                    model.AutoId = int.Parse(row["AutoId"].ToString());
                }
                if (row["GradeType"] != null && row["GradeType"].ToString() != "")
                {
                    model.GradeType = int.Parse(row["GradeType"].ToString());
                }
                if (row["GradeTypeName"] != null)
                {
                    model.GradeTypeName = row["GradeTypeName"].ToString();
                }
                if (row["GradeName"] != null)
                {
                    model.GradeName = row["GradeName"].ToString();
                }
                if (row["GradeLv"] != null && row["GradeLv"].ToString() != "")
                {
                    model.GradeLv = int.Parse(row["GradeLv"].ToString());
                }
                if (row["GradeLvName"] != null)
                {
                    model.GradeLvName = row["GradeLvName"].ToString();
                }
                if (row["GradeCode"] != null)
                {
                    model.GradeCode = row["GradeCode"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表:AutoId,GradeType,GradeTypeName,GradeName,GradeLv,GradeLvName,GradeCode
        /// </summary>
        public DataSet GetList(string cols,string strWhere,string groupby="")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (cols != "")
            {
                strSql.Append(cols);
            }
            strSql.Append(" FROM SysGrade ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if(groupby.Trim() !=""){
                strSql.Append(" Group By "+groupby);
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
            strSql.Append(" AutoId,GradeType,GradeTypeName,GradeName,GradeLv,GradeLvName,GradeCode ");
            strSql.Append(" FROM SysGrade ");
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
            strSql.Append("select count(1) FROM SysGrade ");
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
            strSql.Append(")AS Row, T.*  from SysGrade T ");
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
            parameters[0].Value = "SysGrade";
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

