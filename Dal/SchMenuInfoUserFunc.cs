using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;//Please add references
namespace SchSystem.DAL
{
    /// <summary>
    /// 数据访问类:SchMenuInfoUserFunc
    /// </summary>
    public partial class SchMenuInfoUserFunc
    {
        public SchMenuInfoUserFunc()
        { }
        #region  BasicMethod
        public DataSet GetList(string Cols, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + Cols);
            strSql.Append(" FROM SchMenuInfoUserFunc ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public string GetMenug(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Declare @FuncLvs nvarchar(500)");
            strSql.Append("Select @FuncLvs=ISNULL(@FuncLvs+',','')+FuncLv From SchMenuInfoUserFunc");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("Select @FuncLvs as NameCollection ");
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
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int MenuId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchMenuInfoUserFunc");
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
        public int Add(SchSystem.Model.SchMenuInfoUserFunc model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SchMenuInfoUserFunc(");
            strSql.Append("Pid,Expn,NavUrl,SelAct,Targets,TextName,FuncCode,FuncLv,OrderId,Stat,Ico)");
            strSql.Append(" values (");
            strSql.Append("@Pid,@Expn,@NavUrl,@SelAct,@Targets,@TextName,@FuncCode,@FuncLv,@OrderId,@Stat,@Ico)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Pid", SqlDbType.Int,4),
					new SqlParameter("@Expn", SqlDbType.TinyInt,1),
					new SqlParameter("@NavUrl", SqlDbType.VarChar,200),
					new SqlParameter("@SelAct", SqlDbType.VarChar,50),
					new SqlParameter("@Targets", SqlDbType.VarChar,20),
					new SqlParameter("@TextName", SqlDbType.VarChar,30),
					new SqlParameter("@FuncCode", SqlDbType.Int,4),
					new SqlParameter("@FuncLv", SqlDbType.VarChar,100),
					new SqlParameter("@OrderId", SqlDbType.Int,4),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@Ico", SqlDbType.VarChar,200)};
            parameters[0].Value = model.Pid;
            parameters[1].Value = model.Expn;
            parameters[2].Value = model.NavUrl;
            parameters[3].Value = model.SelAct;
            parameters[4].Value = model.Targets;
            parameters[5].Value = model.TextName;
            parameters[6].Value = model.FuncCode;
            parameters[7].Value = model.FuncLv;
            parameters[8].Value = model.OrderId;
            parameters[9].Value = model.Stat;
            parameters[10].Value = model.Ico;

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
        public bool Update(SchSystem.Model.SchMenuInfoUserFunc model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchMenuInfoUserFunc set ");
            strSql.Append("Pid=@Pid,");
            strSql.Append("Expn=@Expn,");
            strSql.Append("NavUrl=@NavUrl,");
            strSql.Append("SelAct=@SelAct,");
            strSql.Append("Targets=@Targets,");
            strSql.Append("TextName=@TextName,");
            strSql.Append("FuncCode=@FuncCode,");
            strSql.Append("FuncLv=@FuncLv,");
            strSql.Append("OrderId=@OrderId,");
            strSql.Append("Stat=@Stat,");
            strSql.Append("Ico=@Ico");
            strSql.Append(" where MenuId=@MenuId");
            SqlParameter[] parameters = {
					new SqlParameter("@Pid", SqlDbType.Int,4),
					new SqlParameter("@Expn", SqlDbType.TinyInt,1),
					new SqlParameter("@NavUrl", SqlDbType.VarChar,200),
					new SqlParameter("@SelAct", SqlDbType.VarChar,50),
					new SqlParameter("@Targets", SqlDbType.VarChar,20),
					new SqlParameter("@TextName", SqlDbType.VarChar,30),
					new SqlParameter("@FuncCode", SqlDbType.Int,4),
					new SqlParameter("@FuncLv", SqlDbType.VarChar,100),
					new SqlParameter("@OrderId", SqlDbType.Int,4),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@Ico", SqlDbType.VarChar,200),
					new SqlParameter("@MenuId", SqlDbType.Int,4)};
            parameters[0].Value = model.Pid;
            parameters[1].Value = model.Expn;
            parameters[2].Value = model.NavUrl;
            parameters[3].Value = model.SelAct;
            parameters[4].Value = model.Targets;
            parameters[5].Value = model.TextName;
            parameters[6].Value = model.FuncCode;
            parameters[7].Value = model.FuncLv;
            parameters[8].Value = model.OrderId;
            parameters[9].Value = model.Stat;
            parameters[10].Value = model.Ico;
            parameters[11].Value = model.MenuId;

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
            strSql.Append("delete from SchMenuInfoUserFunc ");
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
            strSql.Append("delete from SchMenuInfoUserFunc ");
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
        public SchSystem.Model.SchMenuInfoUserFunc GetModel(int MenuId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MenuId,Pid,Expn,NavUrl,SelAct,Targets,TextName,FuncCode,FuncLv,OrderId,Stat,Ico from SchMenuInfoUserFunc ");
            strSql.Append(" where MenuId=@MenuId");
            SqlParameter[] parameters = {
					new SqlParameter("@MenuId", SqlDbType.Int,4)
			};
            parameters[0].Value = MenuId;

            SchSystem.Model.SchMenuInfoUserFunc model = new SchSystem.Model.SchMenuInfoUserFunc();
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
        public SchSystem.Model.SchMenuInfoUserFunc DataRowToModel(DataRow row)
        {
            SchSystem.Model.SchMenuInfoUserFunc model = new SchSystem.Model.SchMenuInfoUserFunc();
            if (row != null)
            {
                if (row["MenuId"] != null && row["MenuId"].ToString() != "")
                {
                    model.MenuId = int.Parse(row["MenuId"].ToString());
                }
                if (row["Pid"] != null && row["Pid"].ToString() != "")
                {
                    model.Pid = int.Parse(row["Pid"].ToString());
                }
                if (row["Expn"] != null && row["Expn"].ToString() != "")
                {
                    model.Expn = int.Parse(row["Expn"].ToString());
                }
                if (row["NavUrl"] != null)
                {
                    model.NavUrl = row["NavUrl"].ToString();
                }
                if (row["SelAct"] != null)
                {
                    model.SelAct = row["SelAct"].ToString();
                }
                if (row["Targets"] != null)
                {
                    model.Targets = row["Targets"].ToString();
                }
                if (row["TextName"] != null)
                {
                    model.TextName = row["TextName"].ToString();
                }
                if (row["FuncCode"] != null && row["FuncCode"].ToString() != "")
                {
                    model.FuncCode = int.Parse(row["FuncCode"].ToString());
                }
                if (row["FuncLv"] != null)
                {
                    model.FuncLv = row["FuncLv"].ToString();
                }
                if (row["OrderId"] != null && row["OrderId"].ToString() != "")
                {
                    model.OrderId = int.Parse(row["OrderId"].ToString());
                }
                if (row["Stat"] != null && row["Stat"].ToString() != "")
                {
                    model.Stat = int.Parse(row["Stat"].ToString());
                }
                if (row["Ico"] != null)
                {
                    model.Ico = row["Ico"].ToString();
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
            strSql.Append("select MenuId,Pid,Expn,NavUrl,SelAct,Targets,TextName,FuncCode,FuncLv,OrderId,Stat,Ico ");
            strSql.Append(" FROM SchMenuInfoUserFunc ");
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
            strSql.Append(" MenuId,Pid,Expn,NavUrl,SelAct,Targets,TextName,FuncCode,FuncLv,OrderId,Stat,Ico ");
            strSql.Append(" FROM SchMenuInfoUserFunc ");
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
            strSql.Append("select count(1) FROM SchMenuInfoUserFunc ");
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
            strSql.Append(")AS Row, T.*  from SchMenuInfoUserFunc T ");
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
            parameters[0].Value = "SchMenuInfoUserFunc";
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

