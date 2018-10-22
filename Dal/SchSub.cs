using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;//Please add references
namespace SchSystem.DAL
{
    /// <summary>
    /// 数据访问类:SchSub
    /// </summary>
    public partial class SchSub
    {
        public SchSub()
        { }
        #region  BasicMethod

       

        public int DoSchSubs(string RecUser, string SchId, string SubIds)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SchSub where SchId=" + SchId);
                strSql.Append("insert into SchSub(SubCode,SubName,SchId,Stat,RecTime,RecUser,LastRecTime,LastRecUser)");
                //strSql.Append("select SubCode,SubName," + SchId + ",1,getdate(),'" + RecUser + "',getdate(),'" + RecUser + "' from SysSub where SubCode in (" + SubIds + ") and SubCode not in (select SubCode from SchSub where schid=" + SchId + ")");
                strSql.Append("select SubCode,SubName," + SchId + ",1,getdate(),'" + RecUser + "',getdate(),'" + RecUser + "' from SysSub where SubCode in (" + SubIds + ")");
            
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public string GetSubNames(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Declare @SubNames nvarchar(500) ");
            strSql.Append("Select @SubNames=ISNULL(@SubNames+',','')+SubName From SchSub ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("Select @SubNames as NameCollection ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["NameCollection"].ToString();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SchSystem.Model.SchSub model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SchSub(");
            strSql.Append("SubName,SubCode,Stat,SchId,OrderId)");
            strSql.Append(" values (");
            strSql.Append("@SubName,@SubCode,@Stat,@SchId,@OrderId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SubName", SqlDbType.VarChar,10),
					new SqlParameter("@SubCode", SqlDbType.VarChar,10),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@OrderId", SqlDbType.TinyInt,1)};
            parameters[0].Value = model.SubName;
            parameters[1].Value = model.SubCode;
            parameters[2].Value = model.Stat;
            parameters[3].Value = model.SchId;
            parameters[4].Value = model.OrderId;

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
        public bool Update(SchSystem.Model.SchSub model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchSub set ");
            strSql.Append("SubName=@SubName,");
            strSql.Append("SubCode=@SubCode,");
            strSql.Append("Stat=@Stat,");
            strSql.Append("SchId=@SchId,");
            strSql.Append("OrderId=@OrderId");
            strSql.Append(" where SubId=@SubId");
            SqlParameter[] parameters = {
					new SqlParameter("@SubName", SqlDbType.VarChar,10),
					new SqlParameter("@SubCode", SqlDbType.VarChar,10),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@OrderId", SqlDbType.TinyInt,1),
					new SqlParameter("@SubId", SqlDbType.Int,4)};
            parameters[0].Value = model.SubName;
            parameters[1].Value = model.SubCode;
            parameters[2].Value = model.Stat;
            parameters[3].Value = model.SchId;
            parameters[4].Value = model.OrderId;
            parameters[5].Value = model.SubId;

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
        public bool Delete(int SubId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SchSub ");
            strSql.Append(" where SubId=@SubId");
            SqlParameter[] parameters = {
					new SqlParameter("@SubId", SqlDbType.Int,4)
			};
            parameters[0].Value = SubId;

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
        public bool DeleteList(string SubIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SchSub ");
            strSql.Append(" where SubId in (" + SubIdlist + ")  ");
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
        public SchSystem.Model.SchSub GetModel(int SubId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SubId,SubName,SubCode,Stat,SchId,OrderId from SchSub ");
            strSql.Append(" where SubId=@SubId");
            SqlParameter[] parameters = {
					new SqlParameter("@SubId", SqlDbType.Int,4)
			};
            parameters[0].Value = SubId;

            SchSystem.Model.SchSub model = new SchSystem.Model.SchSub();
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
        public SchSystem.Model.SchSub GetModelSub(string SubId,string schid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SubId,SubName,SubCode,Stat,SchId,OrderId from SchSub ");
            strSql.Append(" where SubCode=@SubId and SchId=@schid and Stat=1");
            SqlParameter[] parameters = {
					new SqlParameter("@SubId", SqlDbType.Int,4),new SqlParameter("@SchId", SqlDbType.Int,6)
			};
            parameters[0].Value = SubId;
            parameters[1].Value = schid;

            SchSystem.Model.SchSub model = new SchSystem.Model.SchSub();
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
        public SchSystem.Model.SchSub GetModelSubs(string SubId, string schid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SubId,sysSub.SubName,SchSub.SubCode,SchSub.Stat,SchId,OrderId from SchSub ");
            strSql.Append("left join SysSub on SchSub.SubCode=SysSub.SubCode");
            strSql.Append(" where SchSub.SubCode=@SubId and SchSub.SchId=@schid and SchSub.Stat=1");
            SqlParameter[] parameters = {
					new SqlParameter("@SubId", SqlDbType.Int,4),new SqlParameter("@SchId", SqlDbType.Int,6)
			};
            parameters[0].Value = SubId;
            parameters[1].Value = schid;

            SchSystem.Model.SchSub model = new SchSystem.Model.SchSub();
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
        public SchSystem.Model.SchSub DataRowToModel(DataRow row)
        {
            SchSystem.Model.SchSub model = new SchSystem.Model.SchSub();
            if (row != null)
            {
                if (row["SubId"] != null && row["SubId"].ToString() != "")
                {
                    model.SubId = int.Parse(row["SubId"].ToString());
                }
                if (row["SubName"] != null)
                {
                    model.SubName = row["SubName"].ToString();
                }
                if (row["SubCode"] != null)
                {
                    model.SubCode = row["SubCode"].ToString();
                }
                if (row["Stat"] != null && row["Stat"].ToString() != "")
                {
                    model.Stat = int.Parse(row["Stat"].ToString());
                }
                if (row["SchId"] != null && row["SchId"].ToString() != "")
                {
                    model.SchId = int.Parse(row["SchId"].ToString());
                }
                if (row["OrderId"] != null && row["OrderId"].ToString() != "")
                {
                    model.OrderId = int.Parse(row["OrderId"].ToString());
                }
            }
            return model;
        }
        public DataSet GetList(string Cols,string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + Cols);
            strSql.Append(" FROM SchSub ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetSubList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SchSub.SubCode,SchSub.Stat,SchSub.SchId,SysSub.SubName from SchSub left join SysSub on SchSub.SubCode=SysSub.SubCode");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetSubList(string cols,string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select "+cols+" from SchSub left join SysSub on SchSub.SubCode=SysSub.SubCode");
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
            strSql.Append("select SubId,SubName,SubCode,Stat,SchId,OrderId ");
            strSql.Append(" FROM SchSub ");
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
            strSql.Append(" SubId,SubName,SubCode,Stat,SchId,OrderId ");
            strSql.Append(" FROM SchSub ");
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
            strSql.Append("select count(1) FROM SchSub ");
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
                strSql.Append("order by T.SubId desc");
            }
            strSql.Append(")AS Row, T.*  from SchSub T ");
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
            parameters[0].Value = "SchSub";
            parameters[1].Value = "SubId";
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

