using SchManagerInfoSystem.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchSystem.DAL
{
    public partial class WebSchChnNewsV
    {
        public WebSchChnNewsV()
        {

        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SchSystem.Model.WebSchChnNewsV GetModel(int NewsId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ChnName,ChnId,Topic,RecTime,Stat,SchId,NewsId,Lv,ClassId,GradeId,IsReply,IsQuo,QuoUrl,Content,IsTop from WebSchChnNewsV ");
            strSql.Append(" where NewsId=@NewsId ");
            SqlParameter[] parameters = {
					new SqlParameter("@NewsId", SqlDbType.Int,4)			};
            parameters[0].Value = NewsId;

            SchSystem.Model.WebSchChnNewsV model = new SchSystem.Model.WebSchChnNewsV();
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
        public SchSystem.Model.WebSchChnNewsV DataRowToModel(DataRow row)
        {
            SchSystem.Model.WebSchChnNewsV model = new SchSystem.Model.WebSchChnNewsV();
            if (row != null)
            {
                if (row["ChnName"] != null)
                {
                    model.ChnName = row["ChnName"].ToString();
                }
                if (row["ChnId"] != null && row["ChnId"].ToString() != "")
                {
                    model.ChnId = int.Parse(row["ChnId"].ToString());
                }
                if (row["Topic"] != null)
                {
                    model.Topic = row["Topic"].ToString();
                }
                if (row["RecTime"] != null && row["RecTime"].ToString() != "")
                {
                    model.RecTime = DateTime.Parse(row["RecTime"].ToString());
                }
                if (row["Stat"] != null && row["Stat"].ToString() != "")
                {
                    model.Stat = int.Parse(row["Stat"].ToString());
                }
                if (row["SchId"] != null && row["SchId"].ToString() != "")
                {
                    model.SchId = int.Parse(row["SchId"].ToString());
                }
                if (row["NewsId"] != null && row["NewsId"].ToString() != "")
                {
                    model.NewsId = int.Parse(row["NewsId"].ToString());
                }
                if (row["Lv"] != null && row["Lv"].ToString() != "")
                {
                    model.Lv = int.Parse(row["Lv"].ToString());
                }
                if (row["ClassId"] != null && row["ClassId"].ToString() != "")
                {
                    model.ClassId = int.Parse(row["ClassId"].ToString());
                }
                if (row["GradeId"] != null && row["GradeId"].ToString() != "")
                {
                    model.GradeId = int.Parse(row["GradeId"].ToString());
                }
                if (row["IsReply"] != null && row["IsReply"].ToString() != "")
                {
                    model.IsReply = int.Parse(row["IsReply"].ToString());
                }
                if (row["IsQuo"] != null && row["IsQuo"].ToString() != "")
                {
                    model.IsQuo = int.Parse(row["IsQuo"].ToString());
                }
                if (row["QuoUrl"] != null)
                {
                    model.QuoUrl = row["QuoUrl"].ToString();
                }
                if (row["Content"] != null)
                {
                    model.Content = row["Content"].ToString();
                }
                if (row["IsTop"] != null && row["IsTop"].ToString() != "")
                {
                    model.IsTop = int.Parse(row["IsTop"].ToString());
                }
            }
            return model;
        }
        public DataSet GetList(string cols, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (cols.Trim() != "")
            {
                strSql.Append(cols);
            }
            strSql.Append(" FROM WebSchChnNewsV ");
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
            strSql.Append(" FROM WebSchChnNewsV  ");

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
    }
}
