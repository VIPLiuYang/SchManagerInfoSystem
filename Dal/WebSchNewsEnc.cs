using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;//Please add references
namespace SchSystem.DAL
{
    /// <summary>
    /// 数据访问类:WebSchNewsEnc
    /// </summary>
    public partial class WebSchNewsEnc
    {
        public WebSchNewsEnc()
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
            strSql.Append(" FROM WebSchNewsEnc ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int EncId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from WebSchNewsEnc");
            strSql.Append(" where EncId=@EncId");
            SqlParameter[] parameters = {
					new SqlParameter("@EncId", SqlDbType.Int,4)
			};
            parameters[0].Value = EncId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SchSystem.Model.WebSchNewsEnc model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WebSchNewsEnc(");
            strSql.Append("NewsId,OldName,NewName,SaveUrl,Clicked,RecTime,RecIP,FileSize,ImgUrl)");
            strSql.Append(" values (");
            strSql.Append("@NewsId,@OldName,@NewName,@SaveUrl,@Clicked,@RecTime,@RecIP,@FileSize,@ImgUrl)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@NewsId", SqlDbType.Int,4),
					new SqlParameter("@OldName", SqlDbType.VarChar,50),
					new SqlParameter("@NewName", SqlDbType.VarChar,50),
					new SqlParameter("@SaveUrl", SqlDbType.VarChar,200),
					new SqlParameter("@Clicked", SqlDbType.Int,4),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecIP", SqlDbType.VarChar,20),
					new SqlParameter("@FileSize", SqlDbType.Int,4),
					new SqlParameter("@ImgUrl", SqlDbType.VarChar,200)};
            parameters[0].Value = model.NewsId;
            parameters[1].Value = model.OldName;
            parameters[2].Value = model.NewName;
            parameters[3].Value = model.SaveUrl;
            parameters[4].Value = model.Clicked;
            parameters[5].Value = model.RecTime;
            parameters[6].Value = model.RecIP;
            parameters[7].Value = model.FileSize;
            parameters[8].Value = model.ImgUrl;

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
        public bool Update(SchSystem.Model.WebSchNewsEnc model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebSchNewsEnc set ");
            strSql.Append("NewsId=@NewsId,");
            strSql.Append("OldName=@OldName,");
            strSql.Append("NewName=@NewName,");
            strSql.Append("SaveUrl=@SaveUrl,");
            strSql.Append("Clicked=@Clicked,");
            strSql.Append("RecTime=@RecTime,");
            strSql.Append("RecIP=@RecIP,");
            strSql.Append("FileSize=@FileSize,");
            strSql.Append("ImgUrl=@ImgUrl");
            strSql.Append(" where EncId=@EncId");
            SqlParameter[] parameters = {
					new SqlParameter("@NewsId", SqlDbType.Int,4),
					new SqlParameter("@OldName", SqlDbType.VarChar,50),
					new SqlParameter("@NewName", SqlDbType.VarChar,50),
					new SqlParameter("@SaveUrl", SqlDbType.VarChar,200),
					new SqlParameter("@Clicked", SqlDbType.Int,4),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecIP", SqlDbType.VarChar,20),
					new SqlParameter("@FileSize", SqlDbType.Int,4),
					new SqlParameter("@ImgUrl", SqlDbType.VarChar,200),
					new SqlParameter("@EncId", SqlDbType.Int,4)};
            parameters[0].Value = model.NewsId;
            parameters[1].Value = model.OldName;
            parameters[2].Value = model.NewName;
            parameters[3].Value = model.SaveUrl;
            parameters[4].Value = model.Clicked;
            parameters[5].Value = model.RecTime;
            parameters[6].Value = model.RecIP;
            parameters[7].Value = model.FileSize;
            parameters[8].Value = model.ImgUrl;
            parameters[9].Value = model.EncId;

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
        public bool Delete(int EncId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WebSchNewsEnc ");
            strSql.Append(" where EncId=@EncId");
            SqlParameter[] parameters = {
					new SqlParameter("@EncId", SqlDbType.Int,4)
			};
            parameters[0].Value = EncId;

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
        public bool DeleteNewsEnc(int NewsId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WebSchNewsEnc ");
            strSql.Append(" where NewsId=@NewsId");
            SqlParameter[] parameters = {
					new SqlParameter("@NewsId", SqlDbType.Int,4)
			};
            parameters[0].Value = NewsId;

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
        public bool DeleteList(string EncIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WebSchNewsEnc ");
            strSql.Append(" where EncId in (" + EncIdlist + ")  ");
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
        public SchSystem.Model.WebSchNewsEnc GetModel(int EncId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 EncId,NewsId,OldName,NewName,SaveUrl,Clicked,RecTime,RecIP,FileSize,ImgUrl from WebSchNewsEnc ");
            strSql.Append(" where EncId=@EncId");
            SqlParameter[] parameters = {
					new SqlParameter("@EncId", SqlDbType.Int,4)
			};
            parameters[0].Value = EncId;

            SchSystem.Model.WebSchNewsEnc model = new SchSystem.Model.WebSchNewsEnc();
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
        public SchSystem.Model.WebSchNewsEnc DataRowToModel(DataRow row)
        {
            SchSystem.Model.WebSchNewsEnc model = new SchSystem.Model.WebSchNewsEnc();
            if (row != null)
            {
                if (row["EncId"] != null && row["EncId"].ToString() != "")
                {
                    model.EncId = int.Parse(row["EncId"].ToString());
                }
                if (row["NewsId"] != null && row["NewsId"].ToString() != "")
                {
                    model.NewsId = int.Parse(row["NewsId"].ToString());
                }
                if (row["OldName"] != null)
                {
                    model.OldName = row["OldName"].ToString();
                }
                if (row["NewName"] != null)
                {
                    model.NewName = row["NewName"].ToString();
                }
                if (row["SaveUrl"] != null)
                {
                    model.SaveUrl = row["SaveUrl"].ToString();
                }
                if (row["Clicked"] != null && row["Clicked"].ToString() != "")
                {
                    model.Clicked = int.Parse(row["Clicked"].ToString());
                }
                if (row["RecTime"] != null && row["RecTime"].ToString() != "")
                {
                    model.RecTime = DateTime.Parse(row["RecTime"].ToString());
                }
                if (row["RecIP"] != null)
                {
                    model.RecIP = row["RecIP"].ToString();
                }
                if (row["FileSize"] != null && row["FileSize"].ToString() != "")
                {
                    model.FileSize = int.Parse(row["FileSize"].ToString());
                }
                if (row["ImgUrl"] != null)
                {
                    model.ImgUrl = row["ImgUrl"].ToString();
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
            strSql.Append("select EncId,NewsId,OldName,NewName,SaveUrl,Clicked,RecTime,RecIP,FileSize,ImgUrl ");
            strSql.Append(" FROM WebSchNewsEnc ");
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
            strSql.Append(" EncId,NewsId,OldName,NewName,SaveUrl,Clicked,RecTime,RecIP,FileSize,ImgUrl ");
            strSql.Append(" FROM WebSchNewsEnc ");
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
            strSql.Append("select count(1) FROM WebSchNewsEnc ");
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
                strSql.Append("order by T.EncId desc");
            }
            strSql.Append(")AS Row, T.*  from WebSchNewsEnc T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="table">需要插入的数据</param>
        /// <param name="TableName">表名称</param>
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
            parameters[0].Value = "WebSchNewsEnc";
            parameters[1].Value = "EncId";
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

