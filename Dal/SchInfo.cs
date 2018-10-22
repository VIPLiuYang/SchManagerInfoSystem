using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
namespace SchSystem.DAL
{
    /// <summary>
    /// 数据访问类:SchInfo
    /// </summary>
    public partial class SchInfo
    {
        public SchInfo()
        { }
        #region  BasicMethod
        public bool Exists(int SchId, int Stat)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchInfo");
            strSql.Append(" where SchId=@SchId");
            SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,4)
			};
            parameters[0].Value = SchId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public string GetSchName(int SchId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SchId,SchName from SchInfo ");
            strSql.Append(" where SchId=@SchId");
            SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,4)
			};
            parameters[0].Value = SchId;

            SchSystem.Model.SchInfo model = new SchSystem.Model.SchInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["SchName"].ToString();
            }
            else
            {
                return null;
            }
        }
        public bool UpdateStat(SchSystem.Model.SchInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchInfo set ");
            strSql.Append("Stat=@Stat,");
            strSql.Append("LastRecTime=@LastRecTime,");
            strSql.Append("LastRecUser=@LastRecUser");
            strSql.Append(" where SchId=@SchId");
            SqlParameter[] parameters = {
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@SchId", SqlDbType.Int,4)};
            parameters[0].Value = model.Stat;
            parameters[1].Value = model.LastRecTime;
            parameters[2].Value = model.LastRecUser;
            parameters[3].Value = model.SchId;

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
        public bool UpdateAlone(SchSystem.Model.SchInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchInfo set ");
            strSql.Append("IsAlone=@IsAlone,");
            strSql.Append("AloneTime=@AloneTime,");
            strSql.Append("AloneUser=@AloneUser");
            strSql.Append(" where SchId=@SchId");
            SqlParameter[] parameters = {
					new SqlParameter("@IsAlone", SqlDbType.TinyInt,1),
					new SqlParameter("@AloneTime", SqlDbType.DateTime),
					new SqlParameter("@AloneUser", SqlDbType.VarChar,50),
					new SqlParameter("@SchId", SqlDbType.Int,4)};
            parameters[0].Value = model.IsAlone;
            parameters[1].Value = model.AloneTime;
            parameters[2].Value = model.AloneUser;
            parameters[3].Value = model.SchId;

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
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("SchId", "SchInfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SchId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SchInfo");
            strSql.Append(" where SchId=@SchId ");
            SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,4)			};
            parameters[0].Value = SchId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 支撑添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SchAdd(SchSystem.Model.SchInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SchInfo(");
            strSql.Append("SchNo,SchName,SchType,AreaNo,SchMaster,MasterPostion,SchYear,SchAddr,SchTel,SchLv,IsCity,Artisan,PrincipalName,PrincipalTel,ServiceName,ServiceTel,PlatformName,PlatformIco,PlatformUrl,PlatformIP,SchNote,Stat,RecTime,RecUser,LastRecTime,LastRecUser,SonSysStat,ResourcePlatformName,ResourcePlatformIco,ResourcePlatformUrl,ResourcePlatformIP,SchoolSection,SchCreator,SourceSerStat,HomeschServStat,HomeSchBasicStat,OpenMonth)");
            strSql.Append(" values (");
            strSql.Append("@SchNo,@SchName,@SchType,@AreaNo,@SchMaster,@MasterPostion,@SchYear,@SchAddr,@SchTel,@SchLv,@IsCity,@Artisan,@PrincipalName,@PrincipalTel,@ServiceName,@ServiceTel,@PlatformName,@PlatformIco,@PlatformUrl,@PlatformIP,@SchNote,@Stat,@RecTime,@RecUser,@LastRecTime,@LastRecUser,@SonSysStat,@ResourcePlatformName,@ResourcePlatformIco,@ResourcePlatformUrl,@ResourcePlatformIP,@SchoolSection,@SchCreator,@SourceSerStat,@HomeschServStat,@HomeSchBasicStat,@OpenMonth)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SchNo", SqlDbType.VarChar,10),
					new SqlParameter("@SchName", SqlDbType.VarChar,50),
					new SqlParameter("@SchType", SqlDbType.SmallInt,2),
					new SqlParameter("@AreaNo", SqlDbType.VarChar,8),
					new SqlParameter("@SchMaster", SqlDbType.VarChar,20),
					new SqlParameter("@MasterPostion", SqlDbType.NVarChar,50),
					new SqlParameter("@SchYear", SqlDbType.TinyInt,1),
					new SqlParameter("@SchAddr", SqlDbType.VarChar,200),
					new SqlParameter("@SchTel", SqlDbType.VarChar,20),
					new SqlParameter("@SchLv", SqlDbType.TinyInt,1),
					new SqlParameter("@IsCity", SqlDbType.TinyInt,1),
					new SqlParameter("@Artisan", SqlDbType.VarChar,50),
					new SqlParameter("@PrincipalName", SqlDbType.NVarChar,50),
					new SqlParameter("@PrincipalTel", SqlDbType.VarChar,11),
					new SqlParameter("@ServiceName", SqlDbType.NVarChar,50),
					new SqlParameter("@ServiceTel", SqlDbType.VarChar,11),
					new SqlParameter("@PlatformName", SqlDbType.NVarChar,50),
					new SqlParameter("@PlatformIco", SqlDbType.VarChar,300),
					new SqlParameter("@PlatformUrl", SqlDbType.VarChar,300),
					new SqlParameter("@PlatformIP", SqlDbType.VarChar,15),
					new SqlParameter("@SchNote", SqlDbType.VarChar,2000),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,20),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@SonSysStat", SqlDbType.TinyInt,1),
					new SqlParameter("@ResourcePlatformName", SqlDbType.NVarChar,50),
					new SqlParameter("@ResourcePlatformIco", SqlDbType.NVarChar,50),
					new SqlParameter("@ResourcePlatformUrl", SqlDbType.VarChar,300),
					new SqlParameter("@ResourcePlatformIP", SqlDbType.VarChar,30),
					new SqlParameter("@SchoolSection", SqlDbType.NVarChar,20),
                    new SqlParameter("@SchCreator",SqlDbType.VarChar,30),
                    new SqlParameter("@SourceSerStat",SqlDbType.TinyInt,1),
                    new SqlParameter("@HomeschServStat",SqlDbType.TinyInt,1),
                    new SqlParameter("@HomeSchBasicStat",SqlDbType.TinyInt,1),
                    new SqlParameter("@OpenMonth",SqlDbType.TinyInt,1)
                                        };
            parameters[0].Value = model.SchNo;
            parameters[1].Value = model.SchName;
            parameters[2].Value = model.SchType;
            parameters[3].Value = model.AreaNo;
            parameters[4].Value = model.SchMaster;
            parameters[5].Value = model.MasterPostion;
            parameters[6].Value = model.SchYear;
            parameters[7].Value = model.SchAddr;
            parameters[8].Value = model.SchTel;
            parameters[9].Value = model.SchLv;
            parameters[10].Value = model.IsCity;
            parameters[11].Value = model.Artisan;
            parameters[12].Value = model.PrincipalName;
            parameters[13].Value = model.PrincipalTel;
            parameters[14].Value = model.ServiceName;
            parameters[15].Value = model.ServiceTel;
            parameters[16].Value = model.PlatformName;
            parameters[17].Value = model.PlatformIco;
            parameters[18].Value = model.PlatformUrl;
            parameters[19].Value = model.PlatformIP;
            parameters[20].Value = model.SchNote;
            parameters[21].Value = model.Stat;
            parameters[22].Value = model.RecTime;
            parameters[23].Value = model.RecUser;
            parameters[24].Value = model.LastRecTime;
            parameters[25].Value = model.LastRecUser;
            parameters[26].Value = model.SonSysStat;
            parameters[27].Value = model.ResourcePlatformName;
            parameters[28].Value = model.ResourcePlatformIco;
            parameters[29].Value = model.ResourcePlatformUrl;
            parameters[30].Value = model.ResourcePlatformIP;
            parameters[31].Value = model.SchoolSection;
            parameters[32].Value = model.SchCreator;
            parameters[33].Value = model.SourceSerStat;
            parameters[34].Value = model.HomeschServStat;
            parameters[35].Value = model.HomeSchBasicStat;
            parameters[36].Value = model.OpenMonth;

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

        public bool SchAddXXT(SchSystem.Model.SchInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchInfo set ");
            strSql.Append("HomeSchPlatName=@HomeSchPlatName,");
            strSql.Append("HomeSchPlatIco=@HomeSchPlatIco,");
            strSql.Append("HomeSchPlatUrl=@HomeSchPlatUrl,");
            strSql.Append("HomeSchPlatIP=@HomeSchPlatIP,");
            strSql.Append("HomeschBasicStat=@HomeschBasicStat,");
            strSql.Append("HomeschServStat=@HomeschServStat,");
            strSql.Append("HomeSchCreateTime=@HomeSchCreateTime");
            strSql.Append(" where SchId=@SchId");
            SqlParameter[] parameters = {
                    new SqlParameter("@HomeSchPlatName",SqlDbType.VarChar,50),
                    new SqlParameter("@HomeSchPlatIco",SqlDbType.VarChar,300),
                    new SqlParameter("@HomeSchPlatUrl",SqlDbType.VarChar,300),
                    new SqlParameter("@HomeSchPlatIP",SqlDbType.VarChar,300),
                    new SqlParameter("@HomeschBasicStat",SqlDbType.Int,2),
                    new SqlParameter("@HomeschServStat",SqlDbType.Int,2),
                    new SqlParameter("@HomeSchCreateTime", SqlDbType.DateTime),
					new SqlParameter("@SchId", SqlDbType.Int,6)
                                        };
            parameters[0].Value = model.HomeSchPlatName;
            parameters[1].Value = model.HomeSchPlatIco;
            parameters[2].Value = model.HomeSchPlatUrl;
            parameters[3].Value = model.HomeSchPlatIP;
            parameters[4].Value = model.HomeSchBasicStat;
            parameters[5].Value = model.HomeschServStat;
            parameters[6].Value = DateTime.Now;
            parameters[7].Value = model.SchId;
            string ss = strSql.ToString();
            int ssss = 0;
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
        /// 增加一条数据
        /// </summary>
        public int Add(SchSystem.Model.SchInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SchInfo(");
            strSql.Append("SchNo,SchName,SchType,AreaNo,SchMaster,MasterPostion,SchYear,SchAddr,SchTel,SchLv,IsCity,Artisan,PrincipalName,PrincipalTel,ServiceName,ServiceTel,PlatformName,PlatformIco,PlatformUrl,PlatformIP,SchNote,Stat,RecTime,RecUser,LastRecTime,LastRecUser,SonSysStat,ResourcePlatformName,ResourcePlatformIco,ResourcePlatformUrl,ResourcePlatformIP,SchoolSection,SchCreator)");
            strSql.Append(" values (");
            strSql.Append("@SchNo,@SchName,@SchType,@AreaNo,@SchMaster,@MasterPostion,@SchYear,@SchAddr,@SchTel,@SchLv,@IsCity,@Artisan,@PrincipalName,@PrincipalTel,@ServiceName,@ServiceTel,@PlatformName,@PlatformIco,@PlatformUrl,@PlatformIP,@SchNote,@Stat,@RecTime,@RecUser,@LastRecTime,@LastRecUser,@SonSysStat,@ResourcePlatformName,@ResourcePlatformIco,@ResourcePlatformUrl,@ResourcePlatformIP,@SchoolSection,@SchCreator)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SchNo", SqlDbType.VarChar,10),
					new SqlParameter("@SchName", SqlDbType.VarChar,50),
					new SqlParameter("@SchType", SqlDbType.SmallInt,2),
					new SqlParameter("@AreaNo", SqlDbType.VarChar,8),
					new SqlParameter("@SchMaster", SqlDbType.VarChar,20),
					new SqlParameter("@MasterPostion", SqlDbType.NVarChar,50),
					new SqlParameter("@SchYear", SqlDbType.TinyInt,1),
					new SqlParameter("@SchAddr", SqlDbType.VarChar,200),
					new SqlParameter("@SchTel", SqlDbType.VarChar,20),
					new SqlParameter("@SchLv", SqlDbType.TinyInt,1),
					new SqlParameter("@IsCity", SqlDbType.TinyInt,1),
					new SqlParameter("@Artisan", SqlDbType.VarChar,50),
					new SqlParameter("@PrincipalName", SqlDbType.NVarChar,50),
					new SqlParameter("@PrincipalTel", SqlDbType.VarChar,11),
					new SqlParameter("@ServiceName", SqlDbType.NVarChar,50),
					new SqlParameter("@ServiceTel", SqlDbType.VarChar,11),
					new SqlParameter("@PlatformName", SqlDbType.NVarChar,50),
					new SqlParameter("@PlatformIco", SqlDbType.VarChar,300),
					new SqlParameter("@PlatformUrl", SqlDbType.VarChar,300),
					new SqlParameter("@PlatformIP", SqlDbType.VarChar,15),
					new SqlParameter("@SchNote", SqlDbType.VarChar,2000),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,20),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@SonSysStat", SqlDbType.TinyInt,1),
					new SqlParameter("@ResourcePlatformName", SqlDbType.NVarChar,50),
					new SqlParameter("@ResourcePlatformIco", SqlDbType.VarChar,300),
					new SqlParameter("@ResourcePlatformUrl", SqlDbType.VarChar,300),
					new SqlParameter("@ResourcePlatformIP", SqlDbType.NVarChar,50),
					new SqlParameter("@SchoolSection", SqlDbType.NVarChar,20),
                    new SqlParameter("@SchCreator",SqlDbType.VarChar,30)
                                        };
            parameters[0].Value = model.SchNo;
            parameters[1].Value = model.SchName;
            parameters[2].Value = model.SchType;
            parameters[3].Value = model.AreaNo;
            parameters[4].Value = model.SchMaster;
            parameters[5].Value = model.MasterPostion;
            parameters[6].Value = model.SchYear;
            parameters[7].Value = model.SchAddr;
            parameters[8].Value = model.SchTel;
            parameters[9].Value = model.SchLv;
            parameters[10].Value = model.IsCity;
            parameters[11].Value = model.Artisan;
            parameters[12].Value = model.PrincipalName;
            parameters[13].Value = model.PrincipalTel;
            parameters[14].Value = model.ServiceName;
            parameters[15].Value = model.ServiceTel;
            parameters[16].Value = model.PlatformName;
            parameters[17].Value = model.PlatformIco;
            parameters[18].Value = model.PlatformUrl;
            parameters[19].Value = model.PlatformIP;
            parameters[20].Value = model.SchNote;
            parameters[21].Value = model.Stat;
            parameters[22].Value = model.RecTime;
            parameters[23].Value = model.RecUser;
            parameters[24].Value = model.LastRecTime;
            parameters[25].Value = model.LastRecUser;
            parameters[26].Value = model.SonSysStat;
            parameters[27].Value = model.ResourcePlatformName;
            parameters[28].Value = model.ResourcePlatformIco;
            parameters[29].Value = model.ResourcePlatformUrl;
            parameters[30].Value = model.ResourcePlatformIP;
            parameters[31].Value = model.SchoolSection;
            parameters[32].Value = model.SchCreator;

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
        public bool UpdateSch(SchSystem.Model.SchInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchInfo set ");
            strSql.Append("SchNo=@SchNo,");
            strSql.Append("SchName=@SchName,");
            strSql.Append("SchType=@SchType,");
            strSql.Append("AreaNo=@AreaNo,");
            strSql.Append("SchMaster=@SchMaster,");
            strSql.Append("MasterPostion=@MasterPostion,");
            strSql.Append("SchYear=@SchYear,");
            strSql.Append("SchAddr=@SchAddr,");
            strSql.Append("SchTel=@SchTel,");
            strSql.Append("SchLv=@SchLv,");
            strSql.Append("IsCity=@IsCity,");
            strSql.Append("Artisan=@Artisan,");
            strSql.Append("PrincipalName=@PrincipalName,");
            strSql.Append("PrincipalTel=@PrincipalTel,");
            strSql.Append("ServiceName=@ServiceName,");
            strSql.Append("ServiceTel=@ServiceTel,");
            strSql.Append("PlatformName=@PlatformName,");
            strSql.Append("PlatformIco=@PlatformIco,");
            strSql.Append("PlatformUrl=@PlatformUrl,");
            strSql.Append("PlatformIP=@PlatformIP,");
            strSql.Append("SchNote=@SchNote,");
            strSql.Append("LastRecTime=@LastRecTime,");
            strSql.Append("LastRecUser=@LastRecUser,");
            strSql.Append("ResourcePlatformName=@ResourcePlatformName,");
            strSql.Append("ResourcePlatformIco=@ResourcePlatformIco,");
            strSql.Append("ResourcePlatformUrl=@ResourcePlatformUrl,");
            strSql.Append("ResourcePlatformIP=@ResourcePlatformIP,");
            strSql.Append("SchoolSection=@SchoolSection,");
            strSql.Append("SchCreator=@SchCreator,");
            strSql.Append("SourceSerStat=@SourceSerStat,");
            strSql.Append("OpenMonth=@OpenMonth");
            strSql.Append(" where SchId=@SchId");
            SqlParameter[] parameters = {
					new SqlParameter("@SchNo", SqlDbType.VarChar,10),
					new SqlParameter("@SchName", SqlDbType.VarChar,50),
					new SqlParameter("@SchType", SqlDbType.SmallInt,2),
					new SqlParameter("@AreaNo", SqlDbType.VarChar,8),
					new SqlParameter("@SchMaster", SqlDbType.VarChar,20),
					new SqlParameter("@MasterPostion", SqlDbType.NVarChar,50),
					new SqlParameter("@SchYear", SqlDbType.TinyInt,1),
					new SqlParameter("@SchAddr", SqlDbType.VarChar,200),
					new SqlParameter("@SchTel", SqlDbType.VarChar,20),
					new SqlParameter("@SchLv", SqlDbType.TinyInt,1),
					new SqlParameter("@IsCity", SqlDbType.TinyInt,1),
					new SqlParameter("@Artisan", SqlDbType.VarChar,50),
					new SqlParameter("@PrincipalName", SqlDbType.NVarChar,50),
					new SqlParameter("@PrincipalTel", SqlDbType.VarChar,11),
					new SqlParameter("@ServiceName", SqlDbType.NVarChar,50),
					new SqlParameter("@ServiceTel", SqlDbType.VarChar,11),
					new SqlParameter("@PlatformName", SqlDbType.NVarChar,50),
					new SqlParameter("@PlatformIco", SqlDbType.VarChar,300),
					new SqlParameter("@PlatformUrl", SqlDbType.VarChar,300),
					new SqlParameter("@PlatformIP", SqlDbType.VarChar,15),
					new SqlParameter("@SchNote", SqlDbType.VarChar,2000),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@ResourcePlatformName", SqlDbType.NVarChar,50),
					new SqlParameter("@ResourcePlatformIco", SqlDbType.VarChar,300),
					new SqlParameter("@ResourcePlatformUrl", SqlDbType.VarChar,300),
					new SqlParameter("@ResourcePlatformIP", SqlDbType.NVarChar,50),
					new SqlParameter("@SchoolSection", SqlDbType.NVarChar,20),
                    new SqlParameter("@SchCreator", SqlDbType.NVarChar,20),
                    new SqlParameter("@SourceSerStat",SqlDbType.TinyInt,1),
                    new SqlParameter("@OpenMonth",SqlDbType.TinyInt,1),
					new SqlParameter("@SchId", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.SchNo;
            parameters[1].Value = model.SchName;
            parameters[2].Value = model.SchType;
            parameters[3].Value = model.AreaNo;
            parameters[4].Value = model.SchMaster;
            parameters[5].Value = model.MasterPostion;
            parameters[6].Value = model.SchYear;
            parameters[7].Value = model.SchAddr;
            parameters[8].Value = model.SchTel;
            parameters[9].Value = model.SchLv;
            parameters[10].Value = model.IsCity;
            parameters[11].Value = model.Artisan;
            parameters[12].Value = model.PrincipalName;
            parameters[13].Value = model.PrincipalTel;
            parameters[14].Value = model.ServiceName;
            parameters[15].Value = model.ServiceTel;
            parameters[16].Value = model.PlatformName;
            parameters[17].Value = model.PlatformIco;
            parameters[18].Value = model.PlatformUrl;
            parameters[19].Value = model.PlatformIP;
            parameters[20].Value = model.SchNote;
            parameters[21].Value = model.LastRecTime;
            parameters[22].Value = model.LastRecUser;
            parameters[23].Value = model.ResourcePlatformName;
            parameters[24].Value = model.ResourcePlatformIco;
            parameters[25].Value = model.ResourcePlatformUrl;
            parameters[26].Value = model.ResourcePlatformIP;
            parameters[27].Value = model.SchoolSection;
            parameters[28].Value = model.SchCreator;
            parameters[29].Value = model.SourceSerStat;
            parameters[30].Value = model.OpenMonth;
            parameters[31].Value = model.SchId;


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
        public bool UpdateSchXXT(SchSystem.Model.SchInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchInfo set ");
            strSql.Append("HomeSchPlatName=@HomeSchPlatName,");
            strSql.Append("HomeSchPlatIco=@HomeSchPlatIco,");
            strSql.Append("HomeSchPlatUrl=@HomeSchPlatUrl,");
            strSql.Append("HomeSchPlatIP=@HomeSchPlatIP,");
            strSql.Append("HomeschBasicStat=@HomeschBasicStat");
            strSql.Append(" where SchId=@SchId");
            SqlParameter[] parameters = {
                    new SqlParameter("@HomeSchPlatName",SqlDbType.VarChar,50),
                    new SqlParameter("@HomeSchPlatIco",SqlDbType.VarChar,300),
                    new SqlParameter("@HomeSchPlatUrl",SqlDbType.VarChar,300),
                    new SqlParameter("@HomeSchPlatIP",SqlDbType.VarChar,300),
                    new SqlParameter("@HomeschBasicStat",SqlDbType.Int,2),
					new SqlParameter("@SchId", SqlDbType.Int,6)
                                        };
            parameters[0].Value = model.HomeSchPlatName;
            parameters[1].Value = model.HomeSchPlatIco;
            parameters[2].Value = model.HomeSchPlatUrl;
            parameters[3].Value = model.HomeSchPlatIP;
            parameters[4].Value = model.HomeSchBasicStat;
            parameters[5].Value = model.SchId;


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
        /// 修改管理员账号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertSchAccount(int schid, string managerAccount, string password, string SchMaster)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SchUserInfo(");
            strSql.Append("UserName,PassWord,UserTname,SchId,SysType)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@PassWord,@UserTname,@SchId,1)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,30),
					new SqlParameter("@PassWord", SqlDbType.VarChar,32),
                    new SqlParameter("@UserTname", SqlDbType.VarChar,20),
					new SqlParameter("@SchId", SqlDbType.Int,6)
                                        };
            parameters[0].Value = managerAccount;
            parameters[1].Value = password;
            parameters[2].Value = SchMaster;
            parameters[3].Value = schid;

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
        /// 更新子系统状态及结束时间
        /// </summary>
        /// <param name="schid"></param>
        /// <param name="sonsysendtime"></param>
        /// <param name="sonsysstat"></param>
        /// <returns></returns>
        public bool UpdateSonSysOpen(int schid,DateTime sonsysendtime,string StatNote)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchInfo set ");
            strSql.Append("SchSonSysEndDateTime=@SchSonSysEndDateTime,");
            strSql.Append("SchSonSysEnableTime=getdate(),");
            strSql.Append("SonSysStat=@SonSysStat,");
            strSql.Append("SonSysStatNote=@SonSysStatNote");
            strSql.Append(" where SchId=@SchId");
            SqlParameter[] parameters = {
					new SqlParameter("@SchSonSysEndDateTime", SqlDbType.DateTime,15),
					new SqlParameter("@SonSysStat", SqlDbType.Int,2),
                    new SqlParameter("@SonSysStatNote", SqlDbType.NVarChar,50),
					new SqlParameter("@SchId", SqlDbType.Int,6)
                                        };
            parameters[0].Value = sonsysendtime;
            parameters[1].Value = 1;
            parameters[2].Value = StatNote;
            parameters[3].Value = schid;

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
        public bool UpdateSonSysClose(int schid, string StatNote)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchInfo set ");
            strSql.Append("SchSonSysEndDateTime=getdate(),");
            strSql.Append("SonSysStat=@SonSysStat,");
            strSql.Append("SonSysStatNote=@SonSysStatNote");
            strSql.Append(" where SchId=@SchId");
            SqlParameter[] parameters = {
					new SqlParameter("@SonSysStat", SqlDbType.Int,2),
                    new SqlParameter("@SonSysStatNote", SqlDbType.NVarChar,50),
					new SqlParameter("@SchId", SqlDbType.Int,6)
                                        };
            parameters[0].Value = 0;
            parameters[1].Value = StatNote;
            parameters[2].Value = schid;

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
        /// 更新子系统状态及结束时间
        /// </summary>
        /// <param name="schid"></param>
        /// <param name="sonsysendtime"></param>
        /// <param name="sonsysstat"></param>
        /// <returns></returns>
        public bool UpdateSoureSysOpen(int schid, DateTime sonsysendtime, string StatNote)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchInfo set ");
            strSql.Append("SourceSerEndTime=@SourceSerEndTime,");
            strSql.Append("SoureSerEnableTime=getdate(),");
            strSql.Append("SourceSerStat=@SourceSerStat,");
            strSql.Append("SourceSerStatNote=@SourceSerStatNote");
            strSql.Append(" where SchId=@SchId");
            SqlParameter[] parameters = {
					new SqlParameter("@SourceSerEndTime", SqlDbType.DateTime,15),
					new SqlParameter("@SourceSerStat", SqlDbType.Int,2),
                    new SqlParameter("@SourceSerStatNote", SqlDbType.NVarChar,50),
					new SqlParameter("@SchId", SqlDbType.Int,6)
                                        };
            parameters[0].Value = sonsysendtime;
            parameters[1].Value = 1;
            parameters[2].Value = StatNote;
            parameters[3].Value = schid;

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
        /// 更新家校互通平台状态及结束时间
        /// </summary>
        /// <param name="schid"></param>
        /// <param name="sonsysendtime"></param>
        /// <param name="sonsysstat"></param>
        /// <returns></returns>
        public bool UpdateSchXXTOpen(int schid, DateTime sonsysendtime, string StatNote)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchInfo set ");
            strSql.Append("HomeSchEndTime=@HomeSchEndTime,");
            strSql.Append("HomeSchEnableTime=getdate(),");
            strSql.Append("HomeschServStat=@HomeschServStat");
            strSql.Append(" where SchId=@SchId");
            SqlParameter[] parameters = {
					new SqlParameter("@HomeSchEndTime", SqlDbType.DateTime,15),
					new SqlParameter("@HomeschServStat", SqlDbType.Int,2),
					new SqlParameter("@SchId", SqlDbType.Int,6)
                                        };
            parameters[0].Value = sonsysendtime;
            parameters[1].Value = 1;
            parameters[2].Value = schid;

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
        public bool UpdateSchXXTClose(int schid, string StatNote)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchInfo set ");
            strSql.Append("HomeSchEndTime=getdate(),");
            strSql.Append("HomeschServStat=@HomeschServStat");
            strSql.Append(" where SchId=@SchId");
            SqlParameter[] parameters = {
					new SqlParameter("@HomeschServStat", SqlDbType.Int,2),
					new SqlParameter("@SchId", SqlDbType.Int,6)
                                        };
            parameters[0].Value = 0;
            parameters[1].Value = schid;

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
        public bool UpdateSoureSysClose(int schid, string StatNote)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchInfo set ");
            strSql.Append("SourceSerEndTime=getdate(),");
            strSql.Append("SourceSerStat=@SourceSerStat,");
            strSql.Append("SourceSerStatNote=@SourceSerStatNote");
            strSql.Append(" where SchId=@SchId");
            SqlParameter[] parameters = {
					new SqlParameter("@SourceSerStat", SqlDbType.Int,2),
                    new SqlParameter("@SourceSerStatNote", SqlDbType.NVarChar,50),
					new SqlParameter("@SchId", SqlDbType.Int,6)
                                        };
            parameters[0].Value = 0;
            parameters[1].Value = StatNote;
            parameters[2].Value = schid;

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
        /// 更新家校互通平台基础数据维护人状态
        /// </summary>
        /// <param name="schid"></param>
        /// <param name="sonsysendtime"></param>
        /// <param name="sonsysstat"></param>
        /// <returns></returns>
        public bool UpdateSchXXTServStat(int schid, int ServStat)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchInfo set ");
            strSql.Append("HomeSchBasicStat=@HomeSchBasicStat");
            strSql.Append(" where SchId=@SchId");
            SqlParameter[] parameters = {
					new SqlParameter("@HomeSchBasicStat", SqlDbType.Int,2),
					new SqlParameter("@SchId", SqlDbType.Int,6)
                                        };
            parameters[0].Value = ServStat;
            parameters[1].Value = schid;

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
        public bool Update(SchSystem.Model.SchInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SchInfo set ");
            strSql.Append("SchNo=@SchNo,");
            strSql.Append("SchName=@SchName,");
            strSql.Append("SchType=@SchType,");
            strSql.Append("AreaNo=@AreaNo,");
            strSql.Append("SchMaster=@SchMaster,");
            strSql.Append("MasterPostion=@MasterPostion,");
            strSql.Append("SchYear=@SchYear,");
            strSql.Append("SchAddr=@SchAddr,");
            strSql.Append("SchTel=@SchTel,");
            strSql.Append("SchLv=@SchLv,");
            strSql.Append("IsCity=@IsCity,");
            strSql.Append("Artisan=@Artisan,");
            strSql.Append("PrincipalName=@PrincipalName,");
            strSql.Append("PrincipalTel=@PrincipalTel,");
            strSql.Append("ServiceName=@ServiceName,");
            strSql.Append("ServiceTel=@ServiceTel,");
            strSql.Append("PlatformName=@PlatformName,");
            strSql.Append("PlatformIco=@PlatformIco,");
            strSql.Append("PlatformUrl=@PlatformUrl,");
            strSql.Append("PlatformIP=@PlatformIP,");
            strSql.Append("SchNote=@SchNote,");
            //strSql.Append("Stat=@Stat,");
            //strSql.Append("RecTime=@RecTime,");
            //strSql.Append("RecUser=@RecUser,");
            strSql.Append("LastRecTime=@LastRecTime,");
            strSql.Append("LastRecUser=@LastRecUser,");
            strSql.Append("SonSysStat=@SonSysStat,");
            strSql.Append("ResourcePlatformName=@ResourcePlatformName,");
            strSql.Append("ResourcePlatformIco=@ResourcePlatformIco,");
            strSql.Append("ResourcePlatformUrl=@ResourcePlatformUrl,");
            strSql.Append("ResourcePlatformIP=@ResourcePlatformIP,");
            strSql.Append("SchoolSection=@SchoolSection,");
            strSql.Append("SchCreator=@SchCreator");
            strSql.Append(" where SchId=@SchId");
            SqlParameter[] parameters = {
					new SqlParameter("@SchNo", SqlDbType.VarChar,10),
					new SqlParameter("@SchName", SqlDbType.VarChar,50),
					new SqlParameter("@SchType", SqlDbType.SmallInt,2),
					new SqlParameter("@AreaNo", SqlDbType.VarChar,8),
					new SqlParameter("@SchMaster", SqlDbType.VarChar,20),
					new SqlParameter("@MasterPostion", SqlDbType.NVarChar,50),
					new SqlParameter("@SchYear", SqlDbType.TinyInt,1),
					new SqlParameter("@SchAddr", SqlDbType.VarChar,200),
					new SqlParameter("@SchTel", SqlDbType.VarChar,20),
					new SqlParameter("@SchLv", SqlDbType.TinyInt,1),
					new SqlParameter("@IsCity", SqlDbType.TinyInt,1),
					new SqlParameter("@Artisan", SqlDbType.VarChar,50),
					new SqlParameter("@PrincipalName", SqlDbType.NVarChar,50),
					new SqlParameter("@PrincipalTel", SqlDbType.VarChar,11),
					new SqlParameter("@ServiceName", SqlDbType.NVarChar,50),
					new SqlParameter("@ServiceTel", SqlDbType.VarChar,11),
					new SqlParameter("@PlatformName", SqlDbType.NVarChar,50),
					new SqlParameter("@PlatformIco", SqlDbType.VarChar,300),
					new SqlParameter("@PlatformUrl", SqlDbType.VarChar,300),
					new SqlParameter("@PlatformIP", SqlDbType.VarChar,15),
					new SqlParameter("@SchNote", SqlDbType.VarChar,2000),
					//new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					//new SqlParameter("@RecTime", SqlDbType.DateTime),
					//new SqlParameter("@RecUser", SqlDbType.VarChar,20),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@SonSysStat", SqlDbType.TinyInt,1),
					new SqlParameter("@ResourcePlatformName", SqlDbType.NVarChar,50),
					new SqlParameter("@ResourcePlatformIco", SqlDbType.VarChar,300),
					new SqlParameter("@ResourcePlatformUrl", SqlDbType.VarChar,300),
					new SqlParameter("@ResourcePlatformIP", SqlDbType.NVarChar,50),
					new SqlParameter("@SchoolSection", SqlDbType.NVarChar,20),
                    new SqlParameter("@SchCreator", SqlDbType.NVarChar,20),
					new SqlParameter("@SchId", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.SchNo;
            parameters[1].Value = model.SchName;
            parameters[2].Value = model.SchType;
            parameters[3].Value = model.AreaNo;
            parameters[4].Value = model.SchMaster;
            parameters[5].Value = model.MasterPostion;
            parameters[6].Value = model.SchYear;
            parameters[7].Value = model.SchAddr;
            parameters[8].Value = model.SchTel;
            parameters[9].Value = model.SchLv;
            parameters[10].Value = model.IsCity;
            parameters[11].Value = model.Artisan;
            parameters[12].Value = model.PrincipalName;
            parameters[13].Value = model.PrincipalTel;
            parameters[14].Value = model.ServiceName;
            parameters[15].Value = model.ServiceTel;
            parameters[16].Value = model.PlatformName;
            parameters[17].Value = model.PlatformIco;
            parameters[18].Value = model.PlatformUrl;
            parameters[19].Value = model.PlatformIP;
            parameters[20].Value = model.SchNote;
            //parameters[21].Value = model.Stat;
            //parameters[22].Value = model.RecTime;
            //parameters[23].Value = model.RecUser;
            parameters[21].Value = model.LastRecTime;
            parameters[22].Value = model.LastRecUser;
            parameters[23].Value = model.SonSysStat;
            parameters[24].Value = model.ResourcePlatformName;
            parameters[25].Value = model.ResourcePlatformIco;
            parameters[26].Value = model.ResourcePlatformUrl;
            parameters[27].Value = model.ResourcePlatformIP;
            parameters[28].Value = model.SchoolSection;
            parameters[29].Value = model.SchCreator;
            parameters[30].Value = model.SchId;

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
        public bool Delete(int SchId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SchInfo ");
            strSql.Append(" where SchId=@SchId ");
            SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,4)			};
            parameters[0].Value = SchId;

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
        public bool DeleteList(string SchIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SchInfo ");
            strSql.Append(" where SchId in (" + SchIdlist + ")  ");
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
        /// 支撑系统使用
        /// </summary>
        /// <param name="SchId"></param>
        /// <returns></returns>
        public SchSystem.Model.SchInfo GetSupportModel(int SchId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SchId,SchNo,SchName,SchType,AreaNo,SchMaster,MasterPostion,SchYear,SchAddr,SchTel,SchLv,IsCity,Artisan,PrincipalName,PrincipalTel,ServiceName,ServiceTel,PlatformName,PlatformIco,PlatformUrl,PlatformIP,SchNote,Stat,RecTime,RecUser,LastRecTime,LastRecUser,SonSysStat,ResourcePlatformName,ResourcePlatformIco,ResourcePlatformUrl,ResourcePlatformIP,SchoolSection,SchCreator,SchSonSysEndDateTime,SchSonSysEnableTime,IsSonArrears,SourceSerStat,SourceSerEndTime,HomeschServStat,HomeSchBasicStat,HomeSchPlatName,HomeSchPlatIco,HomeSchPlatUrl,HomeSchPlatIP,HomeSchCreateTime,HomeSchEnableTime,HomeSchEndTime,SourceSerStat,OpenMonth from SchInfo ");
            strSql.Append(" where SchId=@SchId");
            SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,6)
			};
            parameters[0].Value = SchId;

            SchSystem.Model.SchInfo model = new SchSystem.Model.SchInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return SupportDataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public SchSystem.Model.SchInfo GetModel(int SchId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SchId,SchNo,SchName,SchType,AreaNo,SchMaster,MasterPostion,SchYear,SchAddr,SchTel,SchLv,IsCity,SchNote,Stat,RecTime,RecUser,LastRecTime,LastRecUser,SonSysStat,isnull(HomeschServStat,0) HomeschServStat,isnull(HomeSchBasicStat,0) HomeSchBasicStat,HomeSchPlatName,HomeSchPlatIco from SchInfo ");
            strSql.Append(" where SchId=@SchId");
            SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,6)
			};
            parameters[0].Value = SchId;

            SchSystem.Model.SchInfo model = new SchSystem.Model.SchInfo();
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
        /// 支撑系统使用
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public SchSystem.Model.SchInfo SupportDataRowToModel(DataRow row)
        {
            SchSystem.Model.SchInfo model = new SchSystem.Model.SchInfo();
            if (row != null)
            {
                if (row["SchId"] != null && row["SchId"].ToString() != "")
                {
                    model.SchId = int.Parse(row["SchId"].ToString());
                }
                if (row["SchNo"] != null)
                {
                    model.SchNo = row["SchNo"].ToString();
                }
                if (row["SchName"] != null)
                {
                    model.SchName = row["SchName"].ToString();
                }
                if (row["SchType"] != null && row["SchType"].ToString() != "")
                {
                    model.SchType = int.Parse(row["SchType"].ToString());
                }
                if (row["AreaNo"] != null)
                {
                    model.AreaNo = row["AreaNo"].ToString();
                }
                if (row["SchMaster"] != null)
                {
                    model.SchMaster = row["SchMaster"].ToString();
                }
                if (row["MasterPostion"] != null)
                {
                    model.MasterPostion = row["MasterPostion"].ToString();
                }
                if (row["SchYear"] != null && row["SchYear"].ToString() != "")
                {
                    model.SchYear = int.Parse(row["SchYear"].ToString());
                }
                if (row["SchAddr"] != null)
                {
                    model.SchAddr = row["SchAddr"].ToString();
                }
                if (row["SchTel"] != null)
                {
                    model.SchTel = row["SchTel"].ToString();
                }
                if (row["SchLv"] != null && row["SchLv"].ToString() != "")
                {
                    model.SchLv = int.Parse(row["SchLv"].ToString());
                }
                if (row["OpenMonth"] != null && row["OpenMonth"].ToString() != "")
                {
                    model.OpenMonth = int.Parse(row["OpenMonth"].ToString());
                }
                if (row["SchType"] != null && row["SchType"].ToString() != "")
                {
                    model.SchType = int.Parse(row["SchType"].ToString());
                }
                if (row["IsCity"] != null && row["IsCity"].ToString() != "")
                {
                    model.IsCity = int.Parse(row["IsCity"].ToString());
                }
                if (row["Artisan"] != null)
                {
                    model.Artisan = row["Artisan"].ToString();
                }
                if (row["PrincipalName"] != null)
                {
                    model.PrincipalName = row["PrincipalName"].ToString();
                }
                if (row["PrincipalTel"] != null)
                {
                    model.PrincipalTel = row["PrincipalTel"].ToString();
                }
                if (row["ServiceName"] != null)
                {
                    model.ServiceName = row["ServiceName"].ToString();
                }
                if (row["ServiceTel"] != null)
                {
                    model.ServiceTel = row["ServiceTel"].ToString();
                }
                if (row["PlatformName"] != null)
                {
                    model.PlatformName = row["PlatformName"].ToString();
                }
                if (row["PlatformIco"] != null)
                {
                    model.PlatformIco = row["PlatformIco"].ToString();
                }
                if (row["PlatformUrl"] != null)
                {
                    model.PlatformUrl = row["PlatformUrl"].ToString();
                }
                if (row["PlatformIP"] != null)
                {
                    model.PlatformIP = row["PlatformIP"].ToString();
                }
                if (row["SchNote"] != null)
                {
                    model.SchNote = row["SchNote"].ToString();
                }
                if (row["Stat"] != null && row["Stat"].ToString() != "")
                {
                    model.Stat = int.Parse(row["Stat"].ToString());
                }
                if (row["RecTime"] != null && row["RecTime"].ToString() != "")
                {
                    model.RecTime = DateTime.Parse(row["RecTime"].ToString());
                }
                else
                {
                    model.RecTime = DateTime.Now;
                }
                if (row["RecUser"] != null)
                {
                    model.RecUser = row["RecUser"].ToString();
                }
                if (row["LastRecTime"] != null && row["LastRecTime"].ToString() != "")
                {
                    model.LastRecTime = DateTime.Parse(row["LastRecTime"].ToString());
                }
                else
                {
                    model.LastRecTime = DateTime.Now;
                }
                if (row["LastRecUser"] != null)
                {
                    model.LastRecUser = row["LastRecUser"].ToString();
                }
                if (row["SonSysStat"] != null && row["SonSysStat"].ToString() != "")
                {
                    model.SonSysStat = int.Parse(row["SonSysStat"].ToString());
                }
                if (row["ResourcePlatformName"] != null)
                {
                    model.ResourcePlatformName = row["ResourcePlatformName"].ToString();
                }
                if (row["ResourcePlatformIco"] != null)
                {
                    model.ResourcePlatformIco = row["ResourcePlatformIco"].ToString();
                }
                if (row["ResourcePlatformUrl"] != null)
                {
                    model.ResourcePlatformUrl = row["ResourcePlatformUrl"].ToString();
                }
                if (row["ResourcePlatformIP"] != null)
                {
                    model.ResourcePlatformIP = row["ResourcePlatformIP"].ToString();
                }
                if (row["SchoolSection"] != null)
                {
                    model.SchoolSection = row["SchoolSection"].ToString();
                }
                if (row["SchSonSysEndDateTime"] != null && row["SchSonSysEndDateTime"].ToString() != "")
                {
                    model.SchSonSysEndDateTime = DateTime.Parse(row["SchSonSysEndDateTime"].ToString());
                }
                else
                {
                    model.SchSonSysEndDateTime = DateTime.Now;
                }
                if (row["SchSonSysEnableTime"] != null && row["SchSonSysEnableTime"].ToString() != "")
                {
                    model.SchSonSysEnableTime = DateTime.Parse(row["SchSonSysEnableTime"].ToString());
                }
                else
                {
                    model.SchSonSysEnableTime = DateTime.Now;
                }
                if (row["IsSonArrears"] != null)
                {
                    model.IsSonArrears = row["IsSonArrears"].ToString();
                }
                if (row["SchCreator"] != null)
                {
                    model.SchCreator = row["SchCreator"].ToString();
                }
                if (row["SourceSerStat"] != null && row["SourceSerStat"].ToString() != "")
                {
                    model.SourceSerStat = Convert.ToInt32(row["SourceSerStat"]);
                }
                if (row["SourceSerEndTime"] != null && row["SourceSerEndTime"].ToString() != "")
                {
                    model.Sourcesrendtime = DateTime.Parse(row["SourceSerEndTime"].ToString());
                }
                //家校互通平台
                if (row["HomeschServStat"] != null && row["HomeschServStat"].ToString() != "")
                {
                    model.HomeschServStat = int.Parse(row["HomeschServStat"].ToString());
                }
                else
                {
                    model.HomeschServStat = 0;
                }
                if (row["HomeSchBasicStat"] != null && row["HomeSchBasicStat"].ToString() != "")
                {
                    model.HomeSchBasicStat = int.Parse(row["HomeSchBasicStat"].ToString());
                }
                else
                {
                    model.HomeSchBasicStat = 0;
                }
                if (row["HomeSchPlatName"] != null)
                {
                    model.HomeSchPlatName = row["HomeSchPlatName"].ToString();
                }
                if (row["HomeSchPlatIco"] != null)
                {
                    model.HomeSchPlatIco = row["HomeSchPlatIco"].ToString();
                }
                if (row["HomeSchPlatUrl"] != null)
                {
                    model.HomeSchPlatUrl = row["HomeSchPlatUrl"].ToString();
                }
                if (row["HomeSchPlatIP"] != null)
                {
                    model.HomeSchPlatIP = row["HomeSchPlatIP"].ToString();
                }
                if (row["HomeSchCreateTime"] != null && row["HomeSchCreateTime"].ToString() != "")
                {
                    model.HomeSchCreateTime = DateTime.Parse(row["HomeSchCreateTime"].ToString());
                }
                else
                {
                    model.HomeSchCreateTime = DateTime.Parse("2100-1-1");
                }
                if (row["HomeSchEnableTime"] != null && row["HomeSchEnableTime"].ToString() != "")
                {
                    model.HomeSchEnableTime = DateTime.Parse(row["HomeSchEnableTime"].ToString());
                }
                else
                {
                    model.HomeSchEnableTime = DateTime.Parse("2100-1-1");
                }
                if (row["HomeSchEndTime"] != null && row["HomeSchEndTime"].ToString() != "")
                {
                    model.HomeSchEndTime = DateTime.Parse(row["HomeSchEndTime"].ToString());
                }
                else
                {
                    model.HomeSchEndTime = DateTime.Parse("2100-1-1");
                }
            }
            return model;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SchSystem.Model.SchInfo DataRowToModel(DataRow row)
        {
            SchSystem.Model.SchInfo model = new SchSystem.Model.SchInfo();
            if (row != null)
            {
                if (row["SchId"] != null && row["SchId"].ToString() != "")
                {
                    model.SchId = int.Parse(row["SchId"].ToString());
                }
                if (row["SchNo"] != null)
                {
                    model.SchNo = row["SchNo"].ToString();
                }
                if (row["SchName"] != null)
                {
                    model.SchName = row["SchName"].ToString();
                }
                if (row["SchType"] != null && row["SchType"].ToString() != "")
                {
                    model.SchType = int.Parse(row["SchType"].ToString());
                }
                if (row["AreaNo"] != null)
                {
                    model.AreaNo = row["AreaNo"].ToString();
                }
                if (row["SchMaster"] != null)
                {
                    model.SchMaster = row["SchMaster"].ToString();
                }
                if (row["MasterPostion"] != null)
                {
                    model.MasterPostion = row["MasterPostion"].ToString();
                }
                if (row["SchYear"] != null && row["SchYear"].ToString() != "")
                {
                    model.SchYear = int.Parse(row["SchYear"].ToString());
                }
                if (row["SchAddr"] != null)
                {
                    model.SchAddr = row["SchAddr"].ToString();
                }
                if (row["SchTel"] != null)
                {
                    model.SchTel = row["SchTel"].ToString();
                }
                if (row["SchLv"] != null && row["SchLv"].ToString() != "")
                {
                    model.SchLv = int.Parse(row["SchLv"].ToString());
                }
                if (row["IsCity"] != null && row["IsCity"].ToString() != "")
                {
                    model.IsCity = int.Parse(row["IsCity"].ToString());
                }
                if (row["SchNote"] != null)
                {
                    model.SchNote = row["SchNote"].ToString();
                }
                if (row["Stat"] != null && row["Stat"].ToString() != "")
                {
                    model.Stat = int.Parse(row["Stat"].ToString());
                }
                if (row["HomeschServStat"] != null && row["HomeschServStat"].ToString() != "")
                {
                    model.HomeschServStat = int.Parse(row["HomeschServStat"].ToString());
                }
                else
                {
                    model.HomeschServStat = 0;
                }
                if (row["HomeSchBasicStat"] != null && row["HomeSchBasicStat"].ToString() != "")
                {
                    model.HomeSchBasicStat = int.Parse(row["HomeSchBasicStat"].ToString());
                }
                else
                {
                    model.HomeSchBasicStat = 0;
                }
                if (row["RecTime"] != null && row["RecTime"].ToString() != "")
                {
                    model.RecTime = DateTime.Parse(row["RecTime"].ToString());
                }
                if (row["RecUser"] != null)
                {
                    model.RecUser = row["RecUser"].ToString();
                }
                if (row["HomeSchPlatName"] != null)
                {
                    model.HomeSchPlatName = row["HomeSchPlatName"].ToString();
                }
                if (row["HomeSchPlatIco"] != null)
                {
                    model.HomeSchPlatIco = row["HomeSchPlatIco"].ToString();
                }
                if (row["LastRecTime"] != null && row["LastRecTime"].ToString() != "")
                {
                    model.LastRecTime = DateTime.Parse(row["LastRecTime"].ToString());
                }
                if (row["LastRecUser"] != null)
                {
                    model.LastRecUser = row["LastRecUser"].ToString();
                }
                if (row["SonSysStat"] != null && row["SonSysStat"].ToString() != "")
                {
                    model.SonSysStat = int.Parse(row["SonSysStat"].ToString());
                }
            }
            return model;
        }
        public DataSet GetList(string Cols, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + Cols);
            strSql.Append(" FROM SchInfo ");
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
            strSql.Append("select SchId,SchNo,SchName,SchType,AreaNo,MasterPostion,SchMaster,SchYear,SchAddr,SchTel,SchLv,IsCity,RecTime,RecUser,LastRecTime,LastRecUser,Stat,SchNote ");
            strSql.Append(" FROM SchInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得状态
        /// </summary>
        public DataSet GetStat(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SonSysStat ");
            strSql.Append(" FROM SchInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetSchList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM SchInfo ");
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
            strSql.Append(" SchId,SchNo,SchName,SchType,AreaNo,SchMaster,SchYear,SchAddr,SchTel,SchLv,IsCity,RecTime,RecUser,LastRecTime,LastRecUser,Stat,SchNote ");
            strSql.Append(" FROM SchInfo ");
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
            strSql.Append("select count(1) FROM SchInfo ");
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
                strSql.Append("order by T.SchId desc");
            }
            strSql.Append(")AS Row, T.*  from SchInfo T ");
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
            strSql.Append(" FROM SchInfo  ");
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
        public DataSet GetListColsV(string cols, string strWhere, string ordercols, string orderby, int PageIndex, int PageSize, ref int RowCount, ref int PageCount)
        {
            string procname = "XiaoZhengGe";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + cols);
            strSql.Append(" FROM SchInfoGradeV  ");
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
            parameters[0].Value = "SchInfo";
            parameters[1].Value = "SchId";
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

