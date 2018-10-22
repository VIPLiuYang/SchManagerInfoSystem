using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;//Please add references
namespace SchSystem.DAL
{
    /// <summary>
    /// 数据访问类:SchClassUser
    /// </summary>
    public partial class SchClassUser
    {
        public SchClassUser()
        { }
        #region  BasicMethod
        public bool ExistsV(int IsFinish, int Stat, string UserName, int IsMs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchClassUserSubV");
            strSql.Append(" where UserName=@UserName and IsMs=@IsMs and IsFinish=@IsFinish");//GradeFinish=@IsFinish and IsFinish=@IsFinish and 
            SqlParameter[] parameters = {
					new SqlParameter("@IsFinish", SqlDbType.TinyInt,1),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@IsMs", SqlDbType.TinyInt,1)			};
            parameters[0].Value = IsFinish;
            parameters[1].Value = Stat;
            parameters[2].Value = UserName;
            parameters[3].Value = IsMs;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteUserSub(string strwhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SchClassUser ");
            strSql.Append(" where " + strwhere);
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
        public string GetNames(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Declare @UsersNames nvarchar(500)");
            strSql.Append("Select @UsersNames=ISNULL(@UsersNames+',','')+UserTname+'<'+SubName+'>' From SchClassUserSubV");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("Select @UsersNames as NameCollection ");
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
        public int Add(SchSystem.Model.SchClassUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SchClassUser(");
            strSql.Append("ClassId,SubCode,UserName,UserTname,IsMs,RecTime,RecUser,LastRecTime,LastRecUser,SchId)");
            strSql.Append(" values (");
            strSql.Append("@ClassId,@SubCode,@UserName,@UserTname,@IsMs,@RecTime,@RecUser,@LastRecTime,@LastRecUser,@SchId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@SubCode", SqlDbType.VarChar,10),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@UserTname", SqlDbType.NVarChar,50),
					new SqlParameter("@IsMs", SqlDbType.TinyInt,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,50),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@SchId", SqlDbType.Int,4)};
            parameters[0].Value = model.ClassId;
            parameters[1].Value = model.SubCode;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.UserTname;
            parameters[4].Value = model.IsMs;
            parameters[5].Value = model.RecTime;
            parameters[6].Value = model.RecUser;
            parameters[7].Value = model.LastRecTime;
            parameters[8].Value = model.LastRecUser;
            parameters[9].Value = model.SchId;

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
        public bool Update(SchSystem.Model.SchClassUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchClassUser set ");
            strSql.Append("ClassId=@ClassId,");
            strSql.Append("SubCode=@SubCode,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("UserTname=@UserTname,");
            strSql.Append("IsMs=@IsMs,");
            strSql.Append("RecTime=@RecTime,");
            strSql.Append("RecUser=@RecUser,");
            strSql.Append("LastRecTime=@LastRecTime,");
            strSql.Append("LastRecUser=@LastRecUser");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@SubCode", SqlDbType.VarChar,10),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@UserTname", SqlDbType.NVarChar,50),
					new SqlParameter("@IsMs", SqlDbType.TinyInt,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,50),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@AutoId", SqlDbType.Int,4)};
            parameters[0].Value = model.ClassId;
            parameters[1].Value = model.SubCode;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.UserTname;
            parameters[4].Value = model.IsMs;
            parameters[5].Value = model.RecTime;
            parameters[6].Value = model.RecUser;
            parameters[7].Value = model.LastRecTime;
            parameters[8].Value = model.LastRecUser;
            parameters[9].Value = model.AutoId;

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
        /// 删除班级对应的任课老师信息
        /// </summary>
        public bool Delete(string ClassId, string SchId)
        {
            
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SchClassUser ");
            strSql.Append(" where ClassId=@ClassId and SchId=@SchId");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4),
                    new SqlParameter("@SchId", SqlDbType.Int,6)
			};
            parameters[0].Value = ClassId;
            parameters[1].Value = SchId;

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
            strSql.Append("delete from SchClassUser ");
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
        public SchSystem.Model.SchClassUser GetModel(int AutoId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AutoId,ClassId,SubCode,UserName,UserTname,IsMs,RecTime,RecUser,LastRecTime,LastRecUser from SchClassUser ");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
            parameters[0].Value = AutoId;

            SchSystem.Model.SchClassUser model = new SchSystem.Model.SchClassUser();
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
        public SchSystem.Model.SchClassUser DataRowToModel(DataRow row)
        {
            SchSystem.Model.SchClassUser model = new SchSystem.Model.SchClassUser();
            if (row != null)
            {
                if (row["AutoId"] != null && row["AutoId"].ToString() != "")
                {
                    model.AutoId = int.Parse(row["AutoId"].ToString());
                }
                if (row["ClassId"] != null && row["ClassId"].ToString() != "")
                {
                    model.ClassId = int.Parse(row["ClassId"].ToString());
                }
                if (row["SubCode"] != null)
                {
                    model.SubCode = row["SubCode"].ToString();
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["UserTname"] != null)
                {
                    model.UserTname = row["UserTname"].ToString();
                }
                if (row["IsMs"] != null && row["IsMs"].ToString() != "")
                {
                    model.IsMs = int.Parse(row["IsMs"].ToString());
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
            }
            return model;
        }
        public DataSet getGradeClassName(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select GradeName,ClassName from SchGradeInfo left join SchClassInfo on SchGradeInfo.GradeId=SchClassInfo.GradeId ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表:AutoId,ClassId,SubCode,UserName,UserTname,IsMs,RecTime,RecUser,LastRecTime,LastRecUser
        /// </summary>
        public DataSet GetList(string cols,string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (cols != "")
            {
                strSql.Append(cols);
            }
            strSql.Append(" FROM SchClassUser ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取教师以及科目列表
        /// </summary>
        public DataSet GetListV(string cols, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (cols != "")
            {
                strSql.Append(cols);
            }
            strSql.Append(" FROM SchClassUserSubV");
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
            strSql.Append(" AutoId,ClassId,SubCode,UserName,UserTname,IsMs,RecTime,RecUser,LastRecTime,LastRecUser ");
            strSql.Append(" FROM SchClassUser ");
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
            strSql.Append("select count(1) FROM SchClassUser ");
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
            strSql.Append(")AS Row, T.*  from SchClassUser T ");
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
            parameters[0].Value = "SchClassUser";
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

        public bool ExistsIsMs(string ClassId, string usertid, string SchId, int IsMs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(1) from	 SchClassUser  ");
            strSql.Append(" where  ClassId=@ClassId and UserName=@usertid and SchId=@SchId and IsMs=@IsMs");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.VarChar,20),
                    new SqlParameter("@usertid", SqlDbType.VarChar,20),
                    new SqlParameter("@SchId", SqlDbType.VarChar,20),
                    new SqlParameter("@IsMs", SqlDbType.Int,4)};
            parameters[0].Value = ClassId;
            parameters[1].Value = usertid;
            parameters[2].Value = SchId;
            parameters[3].Value = IsMs;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool ExistsIsMs(string usertid, string SchId, int IsMs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(1) from	 SchClassUser  ");
            strSql.Append(" where  UserName=@usertid and SchId=@SchId and IsMs=@IsMs");
            SqlParameter[] parameters = {
                    new SqlParameter("@usertid", SqlDbType.VarChar,20),
                    new SqlParameter("@SchId", SqlDbType.VarChar,20),
                    new SqlParameter("@IsMs", SqlDbType.Int,1)
                                        };
            parameters[0].Value = usertid;
            parameters[1].Value = SchId;
            parameters[2].Value = IsMs;
            bool objbool=false;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                objbool = false;
            }
            else
            {
                if (Convert.ToInt32(obj) > 0)
                {
                    objbool = true;
                }
                else
                {
                    objbool = false;
                }
            }
            return objbool;
        }
        public bool ExistsClassSubUser(string SchId, string SubCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchClassUser");
            strSql.Append(" where SchId=@SchId and SubCode=@SubCode");
            SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,4),
                    new SqlParameter("@SubCode", SqlDbType.VarChar,10)
			};
            parameters[0].Value = SchId;
            parameters[1].Value = SubCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool ExistsClassUser(string SchId, string UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchClassUser");
            strSql.Append(" where SchId=@SchId and UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,6),
                    new SqlParameter("@UserName", SqlDbType.VarChar,50)
			};
            parameters[0].Value = SchId;
            parameters[1].Value = UserId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool ExistsClassUser(string SchId, int classid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchClassUser");
            strSql.Append(" where SchId=@SchId and ClassId=@classid");
            SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,6),
                    new SqlParameter("@classid", SqlDbType.Int,6)
			};
            parameters[0].Value = SchId;
            parameters[1].Value = classid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool ExistsClassUser(int SchId, int ClassId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchClassUser");
            strSql.Append(" where SchId=@SchId and ClassId=@ClassId");
            SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,4),
                    new SqlParameter("@ClassId", SqlDbType.Int,4)
			};
            parameters[0].Value = SchId;
            parameters[1].Value = ClassId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion  ExtensionMethod
    }
}

