using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
using Common;
using System.Collections.Generic;
namespace SchSystem.DAL
{
    /// <summary>
    /// 数据访问类:SchStuInfo
    /// </summary>
    public partial class SchStuInfo
    {
        public SchStuInfo()
        { }
        #region  BasicMethod
        public bool ExistsCard(int StuId, string CardNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchStuInfo");
            strSql.Append(" where CardNo=@CardNo and StuId<>@StuId ");
            SqlParameter[] parameters = {
					new SqlParameter("@CardNo", SqlDbType.VarChar,50),					
					new SqlParameter("@StuId", SqlDbType.Int,4)			};
            parameters[0].Value = CardNo;
            parameters[1].Value = StuId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateCard(int StuId,string CardNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchStuInfo set ");
            strSql.Append("CardNo=@CardNo");
            strSql.Append(" where StuId=@StuId");
            SqlParameter[] parameters = {
					new SqlParameter("@CardNo", SqlDbType.VarChar,15),					
					new SqlParameter("@StuId", SqlDbType.Int,4)};
            parameters[0].Value = CardNo;            
            parameters[1].Value = StuId;

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
            strSql.Append(" FROM SchStuInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool UpdateStu(SchSystem.Model.SchStuInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SchStuInfo set ");
			strSql.Append("StuName=@StuName,");
			strSql.Append("StuNo=@StuNo,");
			strSql.Append("ClassId=@ClassId,");
			strSql.Append("SchId=@SchId,");
			strSql.Append("TestNo=@TestNo,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("Birth=@Birth,");
			strSql.Append("TelNo=@TelNo,");
			strSql.Append("Addr=@Addr,");
			strSql.Append("StudyType=@StudyType,");
			strSql.Append("LastRecTime=@LastRecTime,");
			strSql.Append("LastRecUser=@LastRecUser,");
			strSql.Append("OldClassId=@OldClassId");
			strSql.Append(" where StuId=@StuId");
			SqlParameter[] parameters = {
					new SqlParameter("@StuName", SqlDbType.VarChar,20),
					new SqlParameter("@StuNo", SqlDbType.VarChar,15),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@TestNo", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.TinyInt,1),
					new SqlParameter("@Birth", SqlDbType.DateTime),
					new SqlParameter("@TelNo", SqlDbType.VarChar,50),
					new SqlParameter("@Addr", SqlDbType.NVarChar,200),
					new SqlParameter("@StudyType", SqlDbType.TinyInt,1),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@OldClassId", SqlDbType.NChar,50),
					new SqlParameter("@StuId", SqlDbType.Int,4)};
			parameters[0].Value = model.StuName;
			parameters[1].Value = model.StuNo;
			parameters[2].Value = model.ClassId;
			parameters[3].Value = model.SchId;
			parameters[4].Value = model.TestNo;
			parameters[5].Value = model.Sex;
			parameters[6].Value = model.Birth;
			parameters[7].Value = model.TelNo;
			parameters[8].Value = model.Addr;
			parameters[9].Value = model.StudyType;
			parameters[10].Value = model.LastRecTime;
			parameters[11].Value = model.LastRecUser;
			parameters[12].Value = model.OldClassId;
			parameters[13].Value = model.StuId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
        /// 增加一条数据
        /// </summary>
        public int AddStu(SchSystem.Model.SchStuInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SchStuInfo(");
            strSql.Append("StuName,StuNo,ClassId,SchId,CardNo,TestNo,Sex,Birth,TelNo,Addr,StudyType,RecTime,RecUser,LastRecTime,LastRecUser,OldClassId)");
            strSql.Append(" values (");
            strSql.Append("@StuName,@StuNo,@ClassId,@SchId,@CardNo,@TestNo,@Sex,@Birth,@TelNo,@Addr,@StudyType,@RecTime,@RecUser,@LastRecTime,@LastRecUser,@OldClassId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StuName", SqlDbType.VarChar,20),
					new SqlParameter("@StuNo", SqlDbType.VarChar,15),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@CardNo", SqlDbType.VarChar,15),
					new SqlParameter("@TestNo", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.TinyInt,1),
					new SqlParameter("@Birth", SqlDbType.DateTime),
					new SqlParameter("@TelNo", SqlDbType.VarChar,50),
					new SqlParameter("@Addr", SqlDbType.NVarChar,200),
					new SqlParameter("@StudyType", SqlDbType.TinyInt,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,50),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@OldClassId", SqlDbType.NChar,50)};
            parameters[0].Value = model.StuName;
            parameters[1].Value = model.StuNo;
            parameters[2].Value = model.ClassId;
            parameters[3].Value = model.SchId;
            parameters[4].Value = model.CardNo;
            parameters[5].Value = model.TestNo;
            parameters[6].Value = model.Sex;
            parameters[7].Value = model.Birth;
            parameters[8].Value = model.TelNo;
            parameters[9].Value = model.Addr;
            parameters[10].Value = model.StudyType;
            parameters[11].Value = model.RecTime;
            parameters[12].Value = model.RecUser;
            parameters[13].Value = model.LastRecTime;
            parameters[14].Value = model.LastRecUser;
            parameters[15].Value = model.OldClassId;

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
        public bool Exists(string LoginName, string Pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchStuInfo");
            strSql.Append(" where LoginName=@LoginName and Pwd=@Pwd and Stat=1");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@Pwd", SqlDbType.VarChar,20)			};
            parameters[0].Value = LoginName;
            parameters[1].Value = Pwd;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool ExistsLgname(string LoginName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchStuInfo");
            strSql.Append(" where LoginName=@LoginName ");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.VarChar,50)			};
            parameters[0].Value = LoginName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool UpdateIco(int StuId, string ImgUrl)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchStuInfo set ");
            strSql.Append("ImgUrl=@ImgUrl");
            strSql.Append(" where StuId=@StuId");
            SqlParameter[] parameters = {
					new SqlParameter("@ImgUrl", SqlDbType.VarChar,200),
					new SqlParameter("@StuId", SqlDbType.Int,4)};
            parameters[0].Value = ImgUrl;
            parameters[1].Value = StuId;

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
        public bool UpdatePwd(int StuId, string Pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchStuInfo set ");
            strSql.Append("Pwd=@Pwd");
            strSql.Append(" where StuId=@StuId");
            SqlParameter[] parameters = {
					new SqlParameter("@Pwd", SqlDbType.VarChar,20),
					new SqlParameter("@StuId", SqlDbType.Int,4)};
            parameters[0].Value = Pwd;
            parameters[1].Value = StuId;

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
        public bool UpdateLoginName(int StuId,string LoginName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchStuInfo set ");
            strSql.Append("LoginName=@LoginName");
            strSql.Append(" where StuId=@StuId");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@StuId", SqlDbType.Int,4)};
            parameters[0].Value = LoginName;
            parameters[1].Value = StuId;

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
        public bool ExistsStuCode(int StuId, string StuNo, int SchId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchStuInfo ");
            strSql.Append("  where StuId<>@StuId and SchId=@SchId and StuNo=@StuNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@StuNo", SqlDbType.VarChar,20),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@StuId", SqlDbType.Int,4)};
            parameters[0].Value = StuNo;
            parameters[1].Value = SchId;
            parameters[2].Value = StuId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool ExistsStuUsername(int StuId, string Username, int SchId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchStuInfo ");
            strSql.Append("  where StuId<>@StuId and SchId=@SchId and LoginName=@Username ");
            SqlParameter[] parameters = {
					new SqlParameter("@Username", SqlDbType.VarChar,20),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@StuId", SqlDbType.Int,4)};
            parameters[0].Value = Username;
            parameters[1].Value = SchId;
            parameters[2].Value = StuId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("StuId", "SchStuInfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int StuId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchStuInfo");
            strSql.Append(" where StuId=@StuId");
            SqlParameter[] parameters = {
					new SqlParameter("@StuId", SqlDbType.Int,4)
			};
            parameters[0].Value = StuId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from	 SchUserInfo");
            strSql.Append("  left join	SchClassUser on SchClassUser.UserName= SchUserInfo.UserName ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Exists(strSql.ToString());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public CommandInfo DeleteStuGenUn(int StuId, int GenId)
        {
            CommandInfo cf = new CommandInfo();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SchStuGenUn ");
            strSql.Append(" where StuId=@StuId and GenId=@GenId ");
            strSql.Append(";select @@IDENTITY");
            cf.CommandText = strSql.ToString();
            SqlParameter[] parameters = {
					new SqlParameter("@StuId", SqlDbType.Int,4),
                    new SqlParameter("@GenId", SqlDbType.Int,4)
			};
            parameters[0].Value = StuId;
            parameters[1].Value = GenId;
            cf.Parameters = parameters;
            return cf;
        }
        #endregion
        #region 添加家长信息表
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public CommandInfo AddGen(SchSystem.Model.SchGenInfo model)
        {
            CommandInfo cf = new CommandInfo();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SchGenInfo(");
            strSql.Append("LoginName,Pwd,GenName,TelNo,Sex,ImgUrl,Stat,LoginTime,RecTime,RecUser,LastRecTime,LastRecUser)");
            strSql.Append(" values (");
            strSql.Append("@LoginName,@Pwd,@GenName,@TelNo,@Sex,@ImgUrl,@Stat,@LoginTime,@RecTime,@RecUser,@LastRecTime,@LastRecUser)");
            strSql.Append(";select @@IDENTITY");
            cf.CommandText = strSql.ToString();
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@Pwd", SqlDbType.VarChar,20),
					new SqlParameter("@GenName", SqlDbType.VarChar,20),
					new SqlParameter("@TelNo", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.TinyInt,1),
					new SqlParameter("@ImgUrl", SqlDbType.VarChar,200),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@LoginTime", SqlDbType.DateTime),
					new SqlParameter("@RecTime", SqlDbType.SmallDateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,50),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20)};
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.Pwd;
            parameters[2].Value = model.GenName;
            parameters[3].Value = model.TelNo;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.ImgUrl;
            parameters[6].Value = model.Stat;
            parameters[7].Value = model.LoginTime;
            parameters[8].Value = model.RecTime;
            parameters[9].Value = model.RecUser;
            parameters[10].Value = model.LastRecTime;
            parameters[11].Value = model.LastRecUser;
            cf.Parameters = parameters;
            return cf;
        }
        #endregion
        #region 添加学生家长关系表
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public CommandInfo AddStuGen(SchSystem.Model.SchStuGenUn model)
        {
            CommandInfo cf = new CommandInfo();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SchStuGenUn(");
            strSql.Append("StuId,GenId,Relation,GenName)");
            strSql.Append(" values (");
            strSql.Append("@StuId,@GenId,@Relation,@GenName)");
            strSql.Append(";select @@IDENTITY");
            cf.CommandText = strSql.ToString();
            SqlParameter[] parameters = {
					new SqlParameter("@StuId", SqlDbType.Int,4),
					new SqlParameter("@GenId", SqlDbType.Int,4),
					new SqlParameter("@Relation", SqlDbType.NVarChar,50),
                                        new SqlParameter("@GenName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.StuId;
            parameters[1].Value = model.GenId;
            parameters[2].Value = model.Relation;
            parameters[3].Value = model.GenName;
            cf.Parameters = parameters;
            return cf;
        }

        #endregion
        
        #region 修改家长信息
        public CommandInfo UpdateGen(SchSystem.Model.SchGenInfo model)
        {
            CommandInfo cf = new CommandInfo();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchGenInfo set ");
            strSql.Append("LoginName=@LoginName,");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("GenName=@GenName,");
            strSql.Append("TelNo=@TelNo,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("ImgUrl=@ImgUrl,");
            strSql.Append("Stat=@Stat,");
            strSql.Append("LoginTime=@LoginTime,");
            strSql.Append("RecTime=@RecTime,");
            strSql.Append("RecUser=@RecUser,");
            strSql.Append("LastRecTime=@LastRecTime,");
            strSql.Append("LastRecUser=@LastRecUser");
            strSql.Append(" where GenId=@GenId");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@Pwd", SqlDbType.VarChar,20),
					new SqlParameter("@GenName", SqlDbType.VarChar,20),
					new SqlParameter("@TelNo", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.TinyInt,1),
					new SqlParameter("@ImgUrl", SqlDbType.VarChar,200),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@LoginTime", SqlDbType.DateTime),
					new SqlParameter("@RecTime", SqlDbType.SmallDateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,50),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@GenId", SqlDbType.Int,4)};
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.Pwd;
            parameters[2].Value = model.GenName;
            parameters[3].Value = model.TelNo;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.ImgUrl;
            parameters[6].Value = model.Stat;
            parameters[7].Value = model.LoginTime;
            parameters[8].Value = model.RecTime;
            parameters[9].Value = model.RecUser;
            parameters[10].Value = model.LastRecTime;
            parameters[11].Value = model.LastRecUser;
            parameters[12].Value = model.GenId;
            cf.CommandText = strSql.ToString();
            cf.Parameters = parameters;
            return cf;
        }
        #endregion
        #region 修改学生家长信息
        public CommandInfo UpdateStuGen(SchSystem.Model.SchStuGenUn model)
        {
            CommandInfo cf = new CommandInfo();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchStuGenUn set ");
            strSql.Append("StuId=@StuId,");
            strSql.Append("GenId=@GenId,");
            strSql.Append("Relation=@Relation,");
            strSql.Append("GenName=@GenName");
            strSql.Append(" where UnId=@UnId");
            SqlParameter[] parameters = {
					new SqlParameter("@StuId", SqlDbType.Int,4),
					new SqlParameter("@GenId", SqlDbType.Int,4),
					new SqlParameter("@Relation", SqlDbType.NVarChar,50),
                    new SqlParameter("@GenName", SqlDbType.NVarChar,50),
					new SqlParameter("@UnId", SqlDbType.Int,4)};
            parameters[0].Value = model.StuId;
            parameters[1].Value = model.GenId;
            parameters[2].Value = model.Relation;
            parameters[3].Value = model.GenName;
            parameters[4].Value = model.UnId;

            cf.CommandText = strSql.ToString();
            cf.Parameters = parameters;
            return cf;
        }
        #endregion
        /// <summary>
        /// 软删除一条数据记录
        /// </summary>
        /// <param name="GradeID">年级编号（自动）</param>
        /// <returns></returns>
        public bool DeleteRec(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchStuInfo set ");
            strSql.Append("Stat=2");
            strSql.Append(" where StuId=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

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
        public SchSystem.Model.SchStuInfo GetModel(string LoginName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StuId,LoginName,Pwd,StuName,StuNo,dutie,ClassId,SchId,CardNo,TestNo,Sex,Birth,TelNo,Addr,ImgUrl,StudyType,Stat,LoginTime,RecTime,RecUser,LastRecTime,LastRecUser,OldClassId from SchStuInfo ");
            strSql.Append(" where LoginName=@LoginName ");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.VarChar,50)			};
            parameters[0].Value = LoginName;

            SchSystem.Model.SchStuInfo model = new SchSystem.Model.SchStuInfo();
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
        public SchSystem.Model.SchStuInfo GetModel(int StuId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StuId,LoginName,Pwd,StuName,StuNo,ClassId,SchId,CardNo,Sex,Birth,ImgUrl,StudyType,Stat,LoginTime,RecTime,RecUser,LastRecTime,LastRecUser from SchStuInfo ");
            strSql.Append(" where StuId=@StuId");
            SqlParameter[] parameters = {
					new SqlParameter("@StuId", SqlDbType.Int,4)
			};
            parameters[0].Value = StuId;

            SchSystem.Model.SchStuInfo model = new SchSystem.Model.SchStuInfo();
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
        public SchSystem.Model.SchStuInfo DataRowToModel(DataRow row)
        {
            SchSystem.Model.SchStuInfo model = new SchSystem.Model.SchStuInfo();
            if (row != null)
            {
                if (row["StuId"] != null && row["StuId"].ToString() != "")
                {
                    model.StuId = int.Parse(row["StuId"].ToString());
                }
                if (row["LoginName"] != null)
                {
                    model.LoginName = row["LoginName"].ToString();
                }
                if (row["Pwd"] != null)
                {
                    model.Pwd = row["Pwd"].ToString();
                }
                if (row["StuName"] != null)
                {
                    model.StuName = row["StuName"].ToString();
                }
                if (row["StuNo"] != null)
                {
                    model.StuNo = row["StuNo"].ToString();
                }
                if (row["ClassId"] != null && row["ClassId"].ToString() != "")
                {
                    model.ClassId = int.Parse(row["ClassId"].ToString());
                }
                if (row["SchId"] != null && row["SchId"].ToString() != "")
                {
                    model.SchId = int.Parse(row["SchId"].ToString());
                }
                if (row["CardNo"] != null)
                {
                    model.CardNo = row["CardNo"].ToString();
                }
                if (row["Sex"] != null && row["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(row["Sex"].ToString());
                }
                if (row["Birth"] != null && row["Birth"].ToString() != "")
                {
                    model.Birth = DateTime.Parse(row["Birth"].ToString());
                }
                if (row["ImgUrl"] != null)
                {
                    model.ImgUrl = row["ImgUrl"].ToString();
                }
                if (row["StudyType"] != null && row["StudyType"].ToString() != "")
                {
                    model.StudyType = int.Parse(row["StudyType"].ToString());
                }
                if (row["Stat"] != null && row["Stat"].ToString() != "")
                {
                    model.Stat = int.Parse(row["Stat"].ToString());
                }
                if (row["LoginTime"] != null && row["LoginTime"].ToString() != "")
                {
                    model.LoginTime = DateTime.Parse(row["LoginTime"].ToString());
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

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.StuId,a.ClassId,a.ClassName,a.TestNo,a.StuName,a.CardNo,a.Sex,a.StudyType,a.Stat,a.GradeId,a.GradeName, a.Sex,a.StuNo,a.TelNo,a.StudyType,a.LoginName,a.Addr,a.OldClassId,b.GenName as jzGenName1,c.LoginName as jzLoginName1 ,c.TelNo as jzTelNo1,c.Pwd as jzPwd1,c.Stat as jzStat1,b.Relation as jzRelation1,c.GenId as jzGenId1,b.UnId as jzUnId1  ");
            strSql.Append("  from SchStuInfoV as a  ");
            strSql.Append("  left join SchStuGenUn as b on a.StuId=b.StuId  ");
            strSql.Append(" left join SchGenInfo as c on c.GenId=b.GenId ");
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
            strSql.Append(" StuId,LoginName,Pwd,StuName,StuNo,ClassId,SchId,CardNo,Sex,Birth,ImgUrl,StudyType,Stat,LoginTime,RecTime,RecUser,LastRecTime,LastRecUser ");
            strSql.Append(" FROM SchStuInfo ");
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
            strSql.Append("select count(1) FROM SchStuInfo ");
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
                strSql.Append("order by T.StuId desc");
            }
            strSql.Append(")AS Row, T.*  from SchStuInfo T ");
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
            strSql.Append(" from SchStuInfo as a ");
            strSql.Append(" left join SchStuGenUn as b on a.StuId=b.StuId ");
            strSql.Append(" left join SchGenInfo as c on c.GenId=b.GenId ");
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
            parameters[0].Value = "SchStuInfo";
            parameters[1].Value = "StuId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #region  ExtensionMethod
        /// <summary>
        /// 判断学号是否重复
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="SchId"></param>
        /// <returns></returns>
        public DataSet ExistsStuNo(string StuNo, int SchId)
        {
            DataSet ds = null;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from SchGradeClassStuV");
                strSql.Append(" where SchId=@SchId and StuNo=@StuNo ");// 删除后的学号也不能使用。and Stat=1
                SqlParameter[] parameters = {
					new SqlParameter("@StuNo", SqlDbType.VarChar,15),
					new SqlParameter("@SchId", SqlDbType.Int,4)
                                        };
                parameters[0].Value = StuNo;
                parameters[1].Value = SchId;
                ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            }
            catch (Exception ex)
            {

            }
            return ds;

        }
        /// <summary>
        /// 判断学号是否重复在修改时判断使用
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="SchId"></param>
        ///  <param name="currentStuNo">正在修改的学号</param>
        /// <returns></returns>
        public DataSet GetStuNoList(string StuNo, int SchId,int StuId)
        {
            DataSet ds = null;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from SchGradeClassStuV");
                strSql.Append(" where SchId=@SchId and StuNo=@StuNo and StuId<>@StuId");
                SqlParameter[] parameters = {
					new SqlParameter("@StuNo", SqlDbType.VarChar,15),
					new SqlParameter("@SchId", SqlDbType.Int,4),
                    new SqlParameter("@StuId",SqlDbType.Int,4)
                                        };
                parameters[0].Value = StuNo;
                parameters[1].Value = SchId;
                parameters[2].Value = StuId;
                ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            }
            catch (Exception ex)
            {

            }
            return ds;

        }
        /// <summary>
        /// 判断学号是否重复在修改时判断使用
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="SchId"></param>
        ///  <param name="currentStuNo">正在修改的学号</param>
        /// <returns></returns>
        public DataSet ExistsStuNoUpdate(string StuNo, int SchId, string currentStuNo)
        {
            DataSet ds = null;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from SchGradeClassStuV");
                strSql.Append(" where SchId=@SchId and StuNo=@StuNo and StuNo<>@currentStuNo");
                SqlParameter[] parameters = {
					new SqlParameter("@StuNo", SqlDbType.VarChar,15),
					new SqlParameter("@SchId", SqlDbType.Int,4),
                    new SqlParameter("@currentStuNo",SqlDbType.VarChar,15)
                                        };
                parameters[0].Value = StuNo;
                parameters[1].Value = SchId;
                parameters[2].Value = currentStuNo;
                ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            }
            catch (Exception ex)
            {

            }
            return ds;

        }
        #endregion  ExtensionMethod
    }
}

