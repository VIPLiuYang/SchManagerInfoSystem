using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
namespace SchSystem.DAL
{
    /// <summary>
    /// 数据访问类:SchGradeInfo
    /// </summary>
    public partial class SchGradeInfo
    {
        public SchGradeInfo()
        { }
        #region  BasicMethod
        public int GetGradeId(string CollCode, string MajorCode, string GradeCode, int SchId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 GradeId from SchGradeInfo ");
            strSql.Append(" where GradeId=@GradeId and GradeCode=@GradeCode and SchId=@SchId and CollCode=@CollCode and MajorCode=@MajorCode");
            SqlParameter[] parameters = {
					new SqlParameter("@GradeCode", SqlDbType.VarChar,4),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@CollCode", SqlDbType.VarChar,10),
					new SqlParameter("@MajorCode", SqlDbType.VarChar,10)};
            parameters[0].Value = GradeCode;
            parameters[1].Value = SchId;
            parameters[2].Value = CollCode;
            parameters[3].Value = MajorCode;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return int.Parse(ds.Tables[0].Rows[0]["GradeId"].ToString());
            }
            else
            {
                return 0;
            }
        }
        public bool ExistsUnvGrade(int GradeId, string CollCode, string MajorCode, string GradeCode, int SchId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchGradeInfo");
            strSql.Append(" where GradeId<>@GradeId and GradeCode=@GradeCode and SchId=@SchId and CollCode=@CollCode and MajorCode=@MajorCode");
            SqlParameter[] parameters = {
					new SqlParameter("@GradeCode", SqlDbType.VarChar,4),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@CollCode", SqlDbType.VarChar,10),
					new SqlParameter("@MajorCode", SqlDbType.VarChar,10),
					new SqlParameter("@GradeId", SqlDbType.Int,4)};
            parameters[0].Value = GradeCode;
            parameters[1].Value = SchId;
            parameters[2].Value = CollCode;
            parameters[3].Value = MajorCode;
            parameters[4].Value = GradeId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddUnv(SchSystem.Model.SchGradeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SchGradeInfo(");
            strSql.Append("GradeYear,GradeCode,GradeName,SchId,IsFinish,RecTime,RecUser,LastRecTime,LastRecUser,CollCode,MajorCode)");
            strSql.Append(" values (");
            strSql.Append("@GradeYear,@GradeCode,@GradeName,@SchId,@IsFinish,@RecTime,@RecUser,@LastRecTime,@LastRecUser,@CollCode,@MajorCode)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@GradeYear", SqlDbType.VarChar,4),
					new SqlParameter("@GradeCode", SqlDbType.VarChar,4),
					new SqlParameter("@GradeName", SqlDbType.VarChar,40),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@IsFinish", SqlDbType.TinyInt,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,20),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@CollCode", SqlDbType.VarChar,10),
					new SqlParameter("@MajorCode", SqlDbType.VarChar,10)};
            parameters[0].Value = model.GradeYear;
            parameters[1].Value = model.GradeCode;
            parameters[2].Value = model.GradeName;
            parameters[3].Value = model.SchId;
            parameters[4].Value = model.IsFinish;
            parameters[5].Value = model.RecTime;
            parameters[6].Value = model.RecUser;
            parameters[7].Value = model.LastRecTime;
            parameters[8].Value = model.LastRecUser;
            parameters[9].Value = model.CollCode;
            parameters[10].Value = model.MajorCode;

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
        public bool UpdateUnv(SchSystem.Model.SchGradeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchGradeInfo set ");
            strSql.Append("GradeYear=@GradeYear,");
            strSql.Append("GradeCode=@GradeCode,");
            strSql.Append("GradeName=@GradeName,");
            strSql.Append("SchId=@SchId,");
            strSql.Append("IsFinish=@IsFinish,");
            strSql.Append("LastRecTime=@LastRecTime,");
            strSql.Append("LastRecUser=@LastRecUser,");
            strSql.Append("CollCode=@CollCode,");
            strSql.Append("MajorCode=@MajorCode");
            strSql.Append(" where GradeId=@GradeId");
            SqlParameter[] parameters = {
					new SqlParameter("@GradeYear", SqlDbType.VarChar,4),
					new SqlParameter("@GradeCode", SqlDbType.VarChar,4),
					new SqlParameter("@GradeName", SqlDbType.VarChar,40),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@IsFinish", SqlDbType.TinyInt,1),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@CollCode", SqlDbType.VarChar,10),
					new SqlParameter("@MajorCode", SqlDbType.VarChar,10),
					new SqlParameter("@GradeId", SqlDbType.Int,4)};
            parameters[0].Value = model.GradeYear;
            parameters[1].Value = model.GradeCode;
            parameters[2].Value = model.GradeName;
            parameters[3].Value = model.SchId;
            parameters[4].Value = model.IsFinish;
            parameters[5].Value = model.LastRecTime;
            parameters[6].Value = model.LastRecUser;
            parameters[7].Value = model.CollCode;
            parameters[8].Value = model.MajorCode;
            parameters[9].Value = model.GradeId;

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
        /// 得到一个对象实体
        /// </summary>
        public string GetName(int GradeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 GradeName from SchGradeInfo ");
            strSql.Append(" where GradeId=@GradeId");
            SqlParameter[] parameters = {
					new SqlParameter("@GradeId", SqlDbType.Int,4)
			};
            parameters[0].Value = GradeId;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["GradeName"].ToString();
            }
            else
            {
                return "";
            }
        }
        public DataSet GetListGradeFinish(string cols, int SchId, int GradeYear)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (cols != "")
            {
                strSql.Append(cols);
            }
            strSql.Append(" FROM SchGradeInfo ");
            strSql.Append(" where (isfinish=0 or isfinish=2) and SchId=" + SchId + " and ((left(GradeCode,1)='4' and " + GradeYear + "-GradeYear>2) or (left(GradeCode,1)='3' and " + GradeYear + "-GradeYear>2) or (left(GradeCode,1)='2' and " + GradeYear + "-GradeYear>5) or (left(GradeCode,1)='1' and " + GradeYear + "-GradeYear>4))");
            
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet Graduated(int schid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select GradeCode,GradeName,GradeYear ");
            strSql.Append(" FROM SchGradeInfo ");
            strSql.Append(" where isfinish=1 and SchId='" + schid + "'");

            return DbHelperSQL.Query(strSql.ToString());
        }
        public bool ExistsGradeFinish(int SchId,int GradeYear)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchGradeInfo");
            strSql.Append(" where (isfinish=0 or isfinish=2) and SchId=@SchId and ((left(GradeCode,1)='4' and @GradeYear-GradeYear>2) or (left(GradeCode,1)='3' and @GradeYear-GradeYear>2) or (left(GradeCode,1)='2' and @GradeYear-GradeYear>5) or (left(GradeCode,1)='1' and @GradeYear-GradeYear>4))");
            SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@GradeYear", SqlDbType.Int,4)};
            parameters[0].Value = SchId;
            parameters[1].Value = GradeYear;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool UpdateGrade(string GradeYear, string GradeCode, int SchId, int IsFinish)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchGradeInfo set ");
            strSql.Append("IsFinish=@IsFinish");
            strSql.Append(" where GradeYear=@GradeYear and GradeCode=@GradeCode and SchId=@SchId");
            SqlParameter[] parameters = {
					new SqlParameter("@GradeYear", SqlDbType.VarChar,4),
					new SqlParameter("@GradeCode", SqlDbType.VarChar,4),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@IsFinish", SqlDbType.TinyInt,1)};
            parameters[0].Value = GradeYear;
            parameters[1].Value = GradeCode;
            parameters[2].Value = SchId;
            parameters[3].Value = IsFinish;

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
        public string GetGradedYear(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Declare @GradeYear nvarchar(500)");
            strSql.Append("Select top 1 @GradeYear=ISNULL(@GradeYear+',','')+GradeYear+'级-'+GradeName From SchGradeInfo");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("Select @GradeYear as graduated ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["graduated"].ToString();
            }
            else
            {
                return null;
            }
        }
        public bool UpdateStat(SchSystem.Model.SchGradeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchGradeInfo set ");
            strSql.Append("IsFinish=@IsFinish,");
            strSql.Append("LastRecTime=@LastRecTime,");
            strSql.Append("LastRecUser=@LastRecUser");
            strSql.Append(" where GradeId=@GradeId");
            SqlParameter[] parameters = {
					new SqlParameter("@IsFinish", SqlDbType.TinyInt,1),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@GradeId", SqlDbType.Int,4)};
            parameters[0].Value = model.IsFinish;
            parameters[1].Value = model.LastRecTime;
            parameters[2].Value = model.LastRecUser;
            parameters[3].Value = model.GradeId;

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
        public int DoSchGrades(string RecUser, string SchId, string GradeIds)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchGradeInfo set IsFinish=1,LastRecTime=getdate(),LastRecUser='" + RecUser + "' where SchId=" + SchId + " and GradeCode not in (" + GradeIds + ") and IsFinish=0");
            strSql.Append("update SchGradeInfo set IsFinish=0,LastRecTime=getdate(),LastRecUser='" + RecUser + "' where SchId=" + SchId + " and GradeCode in (" + GradeIds + ") and IsFinish=1");
            strSql.Append("insert into SchGradeInfo(GradeCode,GradeName,SchId,IsFinish,RecTime,RecUser,LastRecTime,LastRecUser)");
            strSql.Append("select GradeCode,GradeName," + SchId + ",0,getdate(),'" + RecUser + "',getdate(),'" + RecUser + "' from SysGrade where GradeCode in (" + GradeIds + ") and GradeCode not in (select GradeCode from SchGradeInfo where schid=" + SchId + " and IsFinish<>2)");
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public int DoSchGradess(string RecUser, string SchId, string GradeIds)
        {
            //GradeCode|GradeYear|GradeName|IsFinish,2002|2017|二年级|1,2003|2017|三年级|1,2004|2017|四年级|1,2005|2017|五年级|0,2006|2017|六年级|1
            string[] gradeIdsarr = GradeIds.Split(',');
            int gradeIdsLen = gradeIdsarr.Length;
            for (int i = 0; i < gradeIdsLen; i++)
            {
                string[] graderowarr = gradeIdsarr[i].Split('|');
                if (ExistsGradeCode(graderowarr[0], int.Parse(SchId)))//修改
                {

                }
                else//添加
                {

                }
            }
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("update SchGradeInfo set IsFinish=1,LastRecTime=getdate(),LastRecUser='" + RecUser + "' where SchId=" + SchId + " and GradeCode not in (" + GradeIds + ") and IsFinish=0");
            //strSql.Append("update SchGradeInfo set IsFinish=0,LastRecTime=getdate(),LastRecUser='" + RecUser + "' where SchId=" + SchId + " and GradeCode in (" + GradeIds + ") and IsFinish=1");
            //strSql.Append("insert into SchGradeInfo(GradeCode,GradeName,SchId,IsFinish,RecTime,RecUser,LastRecTime,LastRecUser)");
            //strSql.Append("select GradeCode,GradeName," + SchId + ",0,getdate(),'" + RecUser + "',getdate(),'" + RecUser + "' from SysGrade where GradeCode in (" + GradeIds + ") and GradeCode not in (select GradeCode from SchGradeInfo where schid=" + SchId + " and IsFinish<>2)");
            return 1;
            //return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 函数功能：判断同一所学校不能出现两个一样的年级
        /// </summary>
        /// <param name="GradeId"></param>
        /// <param name="GradeCode"></param>
        /// <param name="SchId"></param>
        /// <returns></returns>
        public bool ExistsGradeCode(int GradeId, string GradeCode, int SchId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchGradeInfo");
            strSql.Append(" where GradeId<>@GradeId and SchId=@SchId and GradeCode=@GradeCode and IsFinish<>2 ");
            SqlParameter[] parameters = {
					new SqlParameter("@GradeCode", SqlDbType.VarChar,20),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@GradeId", SqlDbType.Int,4)};
            parameters[0].Value = GradeCode;
            parameters[1].Value = SchId;
            parameters[2].Value = GradeId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool ExistsGradeCode(string GradeCode, int SchId,string statType="yes")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchGradeInfo");
            if (statType == "yes")
            {
                strSql.Append(" where SchId=@SchId and GradeCode=@GradeCode and IsFinish<>2 ");
            }
            else if (statType == "no")
            {
                strSql.Append(" where SchId=@SchId and GradeCode=@GradeCode ");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@GradeCode", SqlDbType.VarChar,20),
					new SqlParameter("@SchId", SqlDbType.Int,6)
                                        };
            parameters[0].Value = GradeCode;
            parameters[1].Value = SchId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("GradeId", "SchGradeInfo");
        }
        public int SchGradeUpdate(string id)
        {
            string procname = "SchGradeUp";//存储过程名称
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int)//,
                    //new SqlParameter("@orderType", SqlDbType.Int),
                    //new SqlParameter("@rowcc", SqlDbType.Int)
                    };
            parameters[0].Value = id;
            //parameters[1].Value = ordertype;
            //parameters[2].Direction = ParameterDirection.Output;
            int RecordsAffected = 0;
            try
            {
                DbHelperSQL.ChangeOrderByExecute(procname, parameters);
                RecordsAffected = (int)parameters[2].Value;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            return RecordsAffected;
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int GradeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchGradeInfo");
            strSql.Append(" where GradeId=@GradeId");
            SqlParameter[] parameters = {
					new SqlParameter("@GradeId", SqlDbType.Int,4)
			};
            parameters[0].Value = GradeId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 支撑系统添加年级
        /// </summary>
        /// <param name="schid"></param>
        /// <returns></returns>
        public int SupportSysSchGradeAdd(int schid)
        {
            int ret = 0;
            string procname = "SchGradeUp";
            SqlParameter[] parameters = {
					new SqlParameter("@sch", SqlDbType.Int)
					};
            parameters[0].Value = schid;
            string table1 = "WFListV";
            DataSet myds1 = DbHelperSQL.RunProcedure(procname, parameters, table1);            
            return ret;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SchSystem.Model.SchGradeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SchGradeInfo(");
            strSql.Append("GradeYear,GradeCode,GradeName,SchId,IsFinish,RecTime,RecUser,LastRecTime,LastRecUser)");
            strSql.Append(" values (");
            strSql.Append("@GradeYear,@GradeCode,@GradeName,@SchId,@IsFinish,@RecTime,@RecUser,@LastRecTime,@LastRecUser)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@GradeYear", SqlDbType.VarChar,4),
					new SqlParameter("@GradeCode", SqlDbType.VarChar,4),
					new SqlParameter("@GradeName", SqlDbType.VarChar,40),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@IsFinish", SqlDbType.TinyInt,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,20),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20)};
            parameters[0].Value = model.GradeYear;
            parameters[1].Value = model.GradeCode;
            parameters[2].Value = model.GradeName;
            parameters[3].Value = model.SchId;
            parameters[4].Value = model.IsFinish;
            parameters[5].Value = model.RecTime;
            parameters[6].Value = model.RecUser;
            parameters[7].Value = model.LastRecTime;
            parameters[8].Value = model.LastRecUser;

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
        public int AddLackGrade(int gradecode, int gradeyear, int schid,string gradename)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SchGradeInfo(GradeYear,GradeCode,GradeName,SchId,IsFinish,RecTime,RecUser) ");
            strSql.Append("select @gradeyear,@gradecode,@gradename,@sch,0,getdate(),'admin'");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@gradeyear", SqlDbType.VarChar,4),
					new SqlParameter("@gradecode", SqlDbType.VarChar,4),
					new SqlParameter("@sch", SqlDbType.Int,6),
                    new SqlParameter("@gradename", SqlDbType.VarChar,30)
                                        };
            parameters[0].Value = gradeyear;
            parameters[1].Value = gradecode;
            parameters[2].Value = schid;
            parameters[3].Value = gradename;
            
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
        public bool Update(SchSystem.Model.SchGradeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchGradeInfo set ");
            strSql.Append("GradeYear=@GradeYear,");
            strSql.Append("GradeCode=@GradeCode,");
            strSql.Append("GradeName=@GradeName,");
            //strSql.Append("SchId=@SchId,");
            //strSql.Append("IsFinish=@IsFinish,");
            //strSql.Append("RecTime=@RecTime,");
            //strSql.Append("RecUser=@RecUser,");
            strSql.Append("LastRecTime=@LastRecTime,");
            strSql.Append("LastRecUser=@LastRecUser");
            strSql.Append(" where GradeId=@GradeId");
            SqlParameter[] parameters = {
					new SqlParameter("@GradeYear", SqlDbType.VarChar,4),
					new SqlParameter("@GradeCode", SqlDbType.VarChar,4),
					new SqlParameter("@GradeName", SqlDbType.VarChar,40),
					//new SqlParameter("@SchId", SqlDbType.Int,4),
					//new SqlParameter("@IsFinish", SqlDbType.TinyInt,1),
					//new SqlParameter("@RecTime", SqlDbType.DateTime),
					//new SqlParameter("@RecUser", SqlDbType.VarChar,20),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@GradeId", SqlDbType.Int,4)};
            parameters[0].Value = model.GradeYear;
            parameters[1].Value = model.GradeCode;
            parameters[2].Value = model.GradeName;
            //parameters[3].Value = model.SchId;
            //parameters[4].Value = model.IsFinish;
            //parameters[5].Value = model.RecTime;
            //parameters[6].Value = model.RecUser;
            parameters[3].Value = model.LastRecTime;
            parameters[4].Value = model.LastRecUser;
            parameters[5].Value = model.GradeId;

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
        /// 更新一条数据
        /// </summary>
        public bool UpdateGrade(SchSystem.Model.SchGradeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchGradeInfo set ");
            strSql.Append("GradeName=@GradeName,");
            strSql.Append("LastRecTime=@LastRecTime,");
            strSql.Append("LastRecUser=@LastRecUser");
            strSql.Append(" where GradeId=@GradeId");
            SqlParameter[] parameters = {
					new SqlParameter("@GradeName", SqlDbType.VarChar,40),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@GradeId", SqlDbType.Int,4)};
            parameters[0].Value = model.GradeName;
            parameters[1].Value = model.LastRecTime;
            parameters[2].Value = model.LastRecUser;
            parameters[3].Value = model.GradeId;

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
        /// 更新一条数据:修改字段（GradeCode、GradeName、IsFinish）条件（GradeId、SchId）
        /// </summary>
        public bool UpdateGrades(SchSystem.Model.SchGradeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchGradeInfo set ");
            strSql.Append("GradeCode=@GradeCode,");
            strSql.Append("GradeName=@GradeName,");
            strSql.Append("IsFinish=@IsFinish,");
            strSql.Append("LastRecTime=@LastRecTime,");
            strSql.Append("LastRecUser=@LastRecUser");
            strSql.Append(" where GradeId=@GradeId and SchId=@SchId");
            SqlParameter[] parameters = {
					new SqlParameter("@GradeCode", SqlDbType.VarChar,4),
					new SqlParameter("@GradeName", SqlDbType.VarChar,40),
					new SqlParameter("@IsFinish", SqlDbType.TinyInt,1),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@GradeId", SqlDbType.Int,4),
                    new SqlParameter("@SchId", SqlDbType.Int,6)
                                        };
            parameters[0].Value = model.GradeCode;
            parameters[1].Value = model.GradeName;
            parameters[2].Value = model.IsFinish;
            parameters[3].Value = model.LastRecTime;
            parameters[4].Value = model.LastRecUser;
            parameters[5].Value = model.GradeId;
            parameters[6].Value = model.SchId;

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
        /// 更新一条数据:更新状态
        /// </summary>
        public bool UpdateGradeStat(SchSystem.Model.SchGradeInfo model, string statType = "gradeid")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchGradeInfo set ");
            strSql.Append("IsFinish=@IsFinish,");
            strSql.Append("LastRecTime=@LastRecTime,");
            strSql.Append("LastRecUser=@LastRecUser");
            if (statType == "gradeid")
            {
                strSql.Append(" where GradeId=@GradeId and SchId=@SchId");
            }
            else if (statType == "gradecode")
            {
                strSql.Append(" where GradeCode=@GradeId and SchId=@SchId");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@IsFinish", SqlDbType.TinyInt,1),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@GradeId", SqlDbType.Int,4),
                    new SqlParameter("@SchId", SqlDbType.Int,6)
                                        };
            parameters[0].Value = model.IsFinish;
            parameters[1].Value = model.LastRecTime;
            parameters[2].Value = model.LastRecUser;
            if (statType == "gradeid")
            {
                parameters[3].Value = model.GradeId;
            }
            else if (statType == "gradecode")
            {
                parameters[3].Value = model.GradeCode;
            }
            parameters[4].Value = model.SchId;

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
        public bool Delete(int GradeId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SchGradeInfo ");
            strSql.Append(" where GradeId=@GradeId");
            SqlParameter[] parameters = {
					new SqlParameter("@GradeId", SqlDbType.Int,4)
			};
            parameters[0].Value = GradeId;

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
        /// 软删除一条数据记录
        /// </summary>
        /// <param name="GradeID">年级编号（自动）</param>
        /// <returns></returns>
        public bool DeleteRec(int GradeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchGradeInfo set ");
            strSql.Append("IsFinish=0");
            strSql.Append(" where GradeId=@GradeID");
            SqlParameter[] parameters = {
					new SqlParameter("@GradeID", SqlDbType.Int,4)};
            parameters[0].Value = GradeId;

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
        public bool DeleteList(string GradeIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SchGradeInfo ");
            strSql.Append(" where GradeId in (" + GradeIdlist + ")  ");
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
        public SchSystem.Model.SchGradeInfo GetModel(int GradeId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 GradeId,GradeYear,GradeCode,GradeName,SchId,IsFinish,RecTime,RecUser,LastRecTime,LastRecUser from SchGradeInfo ");
            strSql.Append(" where GradeId=@GradeId");
            SqlParameter[] parameters = {
					new SqlParameter("@GradeId", SqlDbType.Int,4)
			};
            parameters[0].Value = GradeId;

            SchSystem.Model.SchGradeInfo model = new SchSystem.Model.SchGradeInfo();
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
        public SchSystem.Model.SchGradeInfo DataRowToModel(DataRow row)
        {
            SchSystem.Model.SchGradeInfo model = new SchSystem.Model.SchGradeInfo();
            if (row != null)
            {
                if (row["GradeId"] != null && row["GradeId"].ToString() != "")
                {
                    model.GradeId = int.Parse(row["GradeId"].ToString());
                }
                if (row["GradeYear"] != null)
                {
                    model.GradeYear = row["GradeYear"].ToString();
                }
                if (row["GradeCode"] != null)
                {
                    model.GradeCode = row["GradeCode"].ToString();
                }
                if (row["GradeName"] != null)
                {
                    model.GradeName = row["GradeName"].ToString();
                }
                if (row["SchId"] != null && row["SchId"].ToString() != "")
                {
                    model.SchId = int.Parse(row["SchId"].ToString());
                }
                if (row["IsFinish"] != null && row["IsFinish"].ToString() != "")
                {
                    model.IsFinish = int.Parse(row["IsFinish"].ToString());
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
        public DataSet GetList(string cols, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (cols != "")
            {
                strSql.Append(cols);
            }
            strSql.Append(" FROM SchGradeInfo ");
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
            strSql.Append("select GradeId,GradeYear,GradeCode,GradeName,SchId,IsFinish,RecTime,RecUser,LastRecTime,LastRecUser ");
            strSql.Append(" FROM SchGradeInfo ");
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
            strSql.Append(" GradeId,GradeYear,GradeCode,GradeName,SchId,IsFinish,RecTime,RecUser,LastRecTime,LastRecUser ");
            strSql.Append(" FROM SchGradeInfo ");
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
            strSql.Append("select count(1) FROM SchGradeInfo ");
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
                strSql.Append("order by T.GradeId desc");
            }
            strSql.Append(")AS Row, T.*  from SchGradeInfo T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
            strSql.Append(" FROM SchGradeInfo sgi ");
            strSql.Append(" INNER join SchInfo si ON sgi.SchId=si.SchId ");
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
            parameters[0].Value = "SchGradeInfo";
            parameters[1].Value = "GradeId";
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

