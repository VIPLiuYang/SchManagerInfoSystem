using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
namespace SchSystem.DAL
{
	/// <summary>
	/// 数据访问类:SchUserInfo
	/// </summary>
	public partial class SchUserInfo
	{
        public SchUserInfo()
		{}
		#region  BasicMethod
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdatePw(int UserId, string PassWord)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchUserInfo set ");
            strSql.Append("PassWord=@PassWord,");
            strSql.Append("LastRecTime=@LastRecTime");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@PassWord", SqlDbType.VarChar,32),
                    new SqlParameter("@LastRecTime",SqlDbType.DateTime),
					new SqlParameter("@UserId", SqlDbType.Int,4)};
            parameters[0].Value = PassWord;
            parameters[1].Value = DateTime.Now;
            parameters[2].Value = UserId;
            

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
        /// 上传头像
        /// </summary>
        public bool UploadPicture(int UserId,string ImgUrl)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchUserInfo set ");
            strSql.Append("ImgUrl=@ImgUrl");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@ImgUrl", SqlDbType.VarChar,300),
                    new SqlParameter("@UserId", SqlDbType.Int,4)};
            parameters[0].Value = ImgUrl;
            parameters[1].Value = UserId;

            int rows = 0;
            try
            {
                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {

            }
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ExistsSchUser(string UserName, string PassWord, int SchId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchUserInfo");
            strSql.Append(" where UserName=@UserName and PassWord=@PassWord and Stat=1 and AccStat=1 and SchId=@SchId");//and SchId=@SchId 
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,20),
					new SqlParameter("@PassWord", SqlDbType.VarChar,32),
					new SqlParameter("@SchId", SqlDbType.Int,4)	};
            parameters[0].Value = UserName;
            parameters[1].Value = PassWord;
            parameters[2].Value = SchId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool Exists(string UserName, string PassWord)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchUserInfo");
            strSql.Append(" where UserName=@UserName and PassWord=@PassWord and Stat=1 and AccStat=1 ");//and SchId=@SchId 
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,20),
					new SqlParameter("@PassWord", SqlDbType.VarChar,32)	};
            parameters[0].Value = UserName;
            parameters[1].Value = PassWord;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool ExistsUser(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchUserInfo");
            strSql.Append(" where UserName=@UserName and Stat=1 ");//SchId=@SchId and 
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,20)	};
            parameters[0].Value = UserName;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool UpdateUserName(string UserName, int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchUserInfo set ");
            strSql.Append("UserName=@UserName");
            //strSql.Append(" where UserId=@UserId and len(UserName)=0 ");
            strSql.Append(" where UserId=@UserId ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,20),
					new SqlParameter("@UserId", SqlDbType.Int,4)};
            parameters[0].Value = UserName;
            parameters[1].Value = UserId;

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
        public bool UpdateStat(SchSystem.Model.SchUserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchUserInfo set ");
            strSql.Append("Stat=@Stat,");
            strSql.Append("LastRecTime=@LastRecTime,");
            strSql.Append("LastRecUser=@LastRecUser");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@UserId", SqlDbType.Int,4)};
            parameters[0].Value = model.Stat;
            parameters[1].Value = model.LastRecTime;
            parameters[2].Value = model.LastRecUser;
            parameters[3].Value = model.UserId;

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
        public bool ExistsUserCode(int UserId, string UserNo, int SchId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchUserInfo");
            strSql.Append(" where UserId<>@UserId and SchId=@SchId and UserNo=@UserNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserNo", SqlDbType.VarChar,20),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@UserId", SqlDbType.Int,4)};
            parameters[0].Value = UserNo;
            parameters[1].Value = SchId;
            parameters[2].Value = UserId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool ExistsUserName(int UserId, string UserName)//and SchId=@SchId 2018-4-10去掉学校用户唯一属性,改成全平台唯一
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchUserInfo");
            strSql.Append(" where UserId<>@UserId and UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,20),
					new SqlParameter("@UserId", SqlDbType.Int,4)};
            parameters[0].Value = UserName;
            parameters[1].Value = UserId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool UpdateUser(SchSystem.Model.SchUserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchUserInfo set ");
            strSql.Append("UserTname=@UserTname,");
            strSql.Append("UserNo=@UserNo,");
            strSql.Append("AccStat=@AccStat,");
            strSql.Append("Mobile=@Mobile,");
            strSql.Append("Telno=@Telno,");
            strSql.Append("Postion=@Postion,");
            strSql.Append("Title=@Title,");
            strSql.Append("LastRecTime=@LastRecTime,");
            strSql.Append("LastRecUser=@LastRecUser,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("SubCode=@SubCode");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@UserTname", SqlDbType.VarChar,20),
					new SqlParameter("@UserNo", SqlDbType.VarChar,20),
					new SqlParameter("@AccStat", SqlDbType.TinyInt,1),
					new SqlParameter("@Mobile", SqlDbType.VarChar,15),
					new SqlParameter("@Telno", SqlDbType.VarChar,15),
					new SqlParameter("@Postion", SqlDbType.NVarChar,50),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@Sex", SqlDbType.TinyInt,1),
					new SqlParameter("@SubCode", SqlDbType.VarChar,10),
					new SqlParameter("@UserId", SqlDbType.Int,4)};
            parameters[0].Value = model.UserTname;
            parameters[1].Value = model.UserNo;
            parameters[2].Value = model.AccStat;
            parameters[3].Value = model.Mobile;
            parameters[4].Value = model.Telno;
            parameters[5].Value = model.Postion;
            parameters[6].Value = model.Title;
            parameters[7].Value = model.LastRecTime;
            parameters[8].Value = model.LastRecUser;
            parameters[9].Value = model.Sex;
            parameters[10].Value = model.SubCode;
            parameters[11].Value = model.UserId;

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
        public SchSystem.Model.SchUserInfo GetModelByUname(string UserName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserId,UserName,UserTname,PassWord,UserNo,SchId,OrderId,Stat,UserLv,Mobile,Telno,Postion,Title,ImgUrl,LoginTime,RecTime,RecUser,LastRecTime,LastRecUser,SysType,Sex,SubCode,AccStat from SchUserInfo ");
            strSql.Append(" where UserName=@UserName");// and SchId=@SchId 
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,20)};//,					new SqlParameter("@SchId", SqlDbType.Int,4)			
            parameters[0].Value = UserName;
            //parameters[1].Value = SchId;

            SchSystem.Model.SchUserInfo model = new SchSystem.Model.SchUserInfo();
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
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("UserId", "SchUserInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UserId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SchUserInfo");
			strSql.Append(" where UserId=@UserId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)
			};
			parameters[0].Value = UserId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchUserInfo");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where "+strWhere);
            }
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SchSystem.Model.SchUserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SchUserInfo(");
            strSql.Append("UserName,UserTname,PassWord,UserNo,SchId,OrderId,Stat,UserLv,Mobile,Telno,Postion,Title,ImgUrl,LoginTime,RecTime,RecUser,LastRecTime,LastRecUser,SysType,Sex,SubCode,AccStat)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@UserTname,@PassWord,@UserNo,@SchId,@OrderId,@Stat,@UserLv,@Mobile,@Telno,@Postion,@Title,@ImgUrl,@LoginTime,@RecTime,@RecUser,@LastRecTime,@LastRecUser,@SysType,@Sex,@SubCode,@AccStat)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,20),
					new SqlParameter("@UserTname", SqlDbType.VarChar,20),
					new SqlParameter("@PassWord", SqlDbType.VarChar,32),
					new SqlParameter("@UserNo", SqlDbType.VarChar,10),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@OrderId", SqlDbType.Int,4),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@UserLv", SqlDbType.TinyInt,1),
					new SqlParameter("@Mobile", SqlDbType.VarChar,15),
					new SqlParameter("@Telno", SqlDbType.VarChar,15),
					new SqlParameter("@Postion", SqlDbType.NVarChar,50),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@ImgUrl", SqlDbType.VarChar,300),
					new SqlParameter("@LoginTime", SqlDbType.DateTime),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,20),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@SysType", SqlDbType.TinyInt,1),
					new SqlParameter("@Sex", SqlDbType.TinyInt,1),
					new SqlParameter("@SubCode", SqlDbType.VarChar,10),
					new SqlParameter("@AccStat", SqlDbType.TinyInt,1)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.UserTname;
            parameters[2].Value = model.PassWord;
            parameters[3].Value = model.UserNo;
            parameters[4].Value = model.SchId;
            parameters[5].Value = model.OrderId;
            parameters[6].Value = model.Stat;
            parameters[7].Value = model.UserLv;
            parameters[8].Value = model.Mobile;
            parameters[9].Value = model.Telno;
            parameters[10].Value = model.Postion;
            parameters[11].Value = model.Title;
            parameters[12].Value = model.ImgUrl;
            parameters[13].Value = model.LoginTime;
            parameters[14].Value = model.RecTime;
            parameters[15].Value = model.RecUser;
            parameters[16].Value = model.LastRecTime;
            parameters[17].Value = model.LastRecUser;
            parameters[18].Value = model.SysType;
            parameters[19].Value = model.Sex;
            parameters[20].Value = model.SubCode;
            parameters[21].Value = model.AccStat;

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
        public int AddUser(int schid,string usertname,string username,string password,string createauthor="")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SchUserInfo(");
            strSql.Append("UserName,UserTname,PassWord,SchId,Stat,RecTime,RecUser,SysType,AccStat)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@UserTname,@PassWord,@SchId,@Stat,@RecTime,@RecUser,@SysType,@AccStat)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,20),
					new SqlParameter("@UserTname", SqlDbType.VarChar,20),
					new SqlParameter("@PassWord", SqlDbType.VarChar,32),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,20),
                    new SqlParameter("@SysType", SqlDbType.Int,4),
                    new SqlParameter("@AccStat", SqlDbType.Int,1)
					};
            parameters[0].Value = username;
            parameters[1].Value = usertname;
            parameters[2].Value = password;
            parameters[3].Value = schid;
            parameters[4].Value = 1;
            parameters[5].Value = DateTime.Now;
            parameters[6].Value = createauthor;
            parameters[7].Value = 1;
            parameters[8].Value = 1;

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
        public bool Update(SchSystem.Model.SchUserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchUserInfo set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("UserTname=@UserTname,");
            strSql.Append("PassWord=@PassWord,");
            strSql.Append("UserNo=@UserNo,");
            strSql.Append("SchId=@SchId,");
            strSql.Append("OrderId=@OrderId,");
            strSql.Append("Stat=@Stat,");
            strSql.Append("UserLv=@UserLv,");
            strSql.Append("Mobile=@Mobile,");
            strSql.Append("Telno=@Telno,");
            strSql.Append("Postion=@Postion,");
            strSql.Append("Title=@Title,");
            strSql.Append("ImgUrl=@ImgUrl,");
            strSql.Append("LoginTime=@LoginTime,");
            strSql.Append("RecTime=@RecTime,");
            strSql.Append("RecUser=@RecUser,");
            strSql.Append("LastRecTime=@LastRecTime,");
            strSql.Append("LastRecUser=@LastRecUser,");
            strSql.Append("SysType=@SysType,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("SubCode=@SubCode");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,20),
					new SqlParameter("@UserTname", SqlDbType.VarChar,20),
					new SqlParameter("@PassWord", SqlDbType.VarChar,32),
					new SqlParameter("@UserNo", SqlDbType.VarChar,20),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@OrderId", SqlDbType.Int,4),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@UserLv", SqlDbType.TinyInt,1),
					new SqlParameter("@Mobile", SqlDbType.VarChar,15),
					new SqlParameter("@Telno", SqlDbType.VarChar,15),
					new SqlParameter("@Postion", SqlDbType.NVarChar,50),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@ImgUrl", SqlDbType.VarChar,300),
					new SqlParameter("@LoginTime", SqlDbType.DateTime),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,20),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@SysType", SqlDbType.TinyInt,1),
					new SqlParameter("@Sex", SqlDbType.TinyInt,1),
					new SqlParameter("@SubCode", SqlDbType.VarChar,10),
					new SqlParameter("@UserId", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.UserTname;
            parameters[2].Value = model.PassWord;
            parameters[3].Value = model.UserNo;
            parameters[4].Value = model.SchId;
            parameters[5].Value = model.OrderId;
            parameters[6].Value = model.Stat;
            parameters[7].Value = model.UserLv;
            parameters[8].Value = model.Mobile;
            parameters[9].Value = model.Telno;
            parameters[10].Value = model.Postion;
            parameters[11].Value = model.Title;
            parameters[12].Value = model.ImgUrl;
            parameters[13].Value = model.LoginTime;
            parameters[14].Value = model.RecTime;
            parameters[15].Value = model.RecUser;
            parameters[16].Value = model.LastRecTime;
            parameters[17].Value = model.LastRecUser;
            parameters[18].Value = model.SysType;
            parameters[19].Value = model.Sex;
            parameters[20].Value = model.SubCode;
            parameters[21].Value = model.UserId;

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
        public SchSystem.Model.SchUserInfo GetModel(int UserId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserId,UserName,UserTname,PassWord,UserNo,SchId,OrderId,Stat,UserLv,Mobile,Telno,Postion,Title,ImgUrl,LoginTime,RecTime,RecUser,LastRecTime,LastRecUser,SysType,Sex,SubCode,AccStat from SchUserInfo ");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)
			};
            parameters[0].Value = UserId;

            SchSystem.Model.SchUserInfo model = new SchSystem.Model.SchUserInfo();
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
        public SchSystem.Model.SchUserInfo GetSupportModel(int SchId, int SysType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserId,UserName,UserTname,PassWord,UserNo,SchId,OrderId,Stat,UserLv,Mobile,Telno,Postion,Title,ImgUrl,LoginTime,RecTime,RecUser,LastRecTime,LastRecUser,SysType,Sex,SubCode,AccStat from SchUserInfo ");
            strSql.Append(" where SchId=@SchId and SysType=@SysType");
            SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,6),
                    new SqlParameter("@SysType", SqlDbType.Int,4)
			};
            parameters[0].Value = SchId;
            parameters[1].Value = SysType;

            SchSystem.Model.SchUserInfo model = new SchSystem.Model.SchUserInfo();
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
        public SchSystem.Model.SchUserInfo DataRowToModel(DataRow row)
        {
            SchSystem.Model.SchUserInfo model = new SchSystem.Model.SchUserInfo();
            if (row != null)
            {
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["UserTname"] != null)
                {
                    model.UserTname = row["UserTname"].ToString();
                }
                if (row["PassWord"] != null)
                {
                    model.PassWord = row["PassWord"].ToString();
                }
                if (row["UserNo"] != null)
                {
                    model.UserNo = row["UserNo"].ToString();
                }
                if (row["SchId"] != null && row["SchId"].ToString() != "")
                {
                    model.SchId = int.Parse(row["SchId"].ToString());
                }
                if (row["OrderId"] != null && row["OrderId"].ToString() != "")
                {
                    model.OrderId = int.Parse(row["OrderId"].ToString());
                }
                if (row["Stat"] != null && row["Stat"].ToString() != "")
                {
                    model.Stat = int.Parse(row["Stat"].ToString());
                }
                if (row["UserLv"] != null && row["UserLv"].ToString() != "")
                {
                    model.UserLv = int.Parse(row["UserLv"].ToString());
                }
                if (row["Mobile"] != null)
                {
                    model.Mobile = row["Mobile"].ToString();
                }
                if (row["Telno"] != null)
                {
                    model.Telno = row["Telno"].ToString();
                }
                if (row["Postion"] != null)
                {
                    model.Postion = row["Postion"].ToString();
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["ImgUrl"] != null)
                {
                    model.ImgUrl = row["ImgUrl"].ToString();
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
                if (row["SysType"] != null && row["SysType"].ToString() != "")
                {
                    model.SysType = int.Parse(row["SysType"].ToString());
                }
                if (row["Sex"] != null && row["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(row["Sex"].ToString());
                }
                if (row["SubCode"] != null)
                {
                    model.SubCode = row["SubCode"].ToString();
                }
                if (row["AccStat"] != null && row["AccStat"].ToString() != "")
                {
                    model.AccStat = int.Parse(row["AccStat"].ToString());
                }
            }
            return model;
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int UserId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchUserInfo ");
			strSql.Append(" where UserId=@UserId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)
			};
			parameters[0].Value = UserId;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string UserIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchUserInfo ");
			strSql.Append(" where UserId in ("+UserIdlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
        /// 获得数据列表--字段列表:UserId,UserName,UserTname,PassWord,SchId,OrderId,Stat,DepartIds,UserLv,Mobile,Telno,Postion,ImgUrl,LoginTime,ClassMs,RecTime,RecUser,LastRecTime,LastRecUser,CopeId,RoleId
		/// </summary>
		public DataSet GetList(string cols = "*",string strWhere = "Stat=1")
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
            strSql.Append(cols);
			strSql.Append(" FROM SchUserInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" UserId,UserName,UserTname,PassWord,UserNo,SchId,OrderId,Stat,UserLv,Mobile,Telno,Postion,Title,ImgUrl,LoginTime,RecTime,RecUser,LastRecTime,LastRecUser,SysType,Sex,SubCode,AccStat ");
			strSql.Append(" FROM SchUserInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM SchUserInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.UserId desc");
			}
			strSql.Append(")AS Row, T.*  from SchUserInfo T ");
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
            strSql.Append(" FROM SchUserInfo  ");
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
			parameters[0].Value = "SchUserInfo";
			parameters[1].Value = "UserId";
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

