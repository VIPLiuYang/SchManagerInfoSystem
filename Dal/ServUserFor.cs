using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;

namespace SchSystem.DAL
{
	/// <summary>
	/// 数据访问类:ServUserFor
	/// </summary>
	public partial class ServUserFor
	{
		public ServUserFor()
		{}
		#region  BasicMethod
        public bool Exists(string UserName, string ServiceId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ServUserFor");
            strSql.Append(" where UserName=@UserName and ServiceId=@ServiceId ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,20),
					new SqlParameter("@ServiceId", SqlDbType.VarChar,10)			};
            parameters[0].Value = UserName;
            parameters[1].Value = ServiceId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("AutoId", "ServUserFor"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AutoId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ServUserFor");
			strSql.Append(" where AutoId=@AutoId");
			SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
			parameters[0].Value = AutoId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SchSystem.Model.ServUserFor model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ServUserFor(");
			strSql.Append("UserName,FromType,RecUser,ServiceId,ServStat,ServMonth,FeeM,RecTime,EndTime,EditTime,DoNote)");
			strSql.Append(" values (");
			strSql.Append("@UserName,@FromType,@RecUser,@ServiceId,@ServStat,@ServMonth,@FeeM,@RecTime,@EndTime,@EditTime,@DoNote)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,20),
					new SqlParameter("@FromType", SqlDbType.NVarChar,10),
					new SqlParameter("@RecUser", SqlDbType.NVarChar,10),
					new SqlParameter("@ServiceId", SqlDbType.VarChar,10),
					new SqlParameter("@ServStat", SqlDbType.TinyInt,1),
					new SqlParameter("@ServMonth", SqlDbType.Int,4),
					new SqlParameter("@FeeM", SqlDbType.Int,4),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@EditTime", SqlDbType.DateTime),
					new SqlParameter("@DoNote", SqlDbType.NVarChar,2000)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.FromType;
			parameters[2].Value = model.RecUser;
			parameters[3].Value = model.ServiceId;
			parameters[4].Value = model.ServStat;
			parameters[5].Value = model.ServMonth;
			parameters[6].Value = model.FeeM;
			parameters[7].Value = model.RecTime;
			parameters[8].Value = model.EndTime;
			parameters[9].Value = model.EditTime;
			parameters[10].Value = model.DoNote;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
        public int ProcAdd(string UserName, string RecUser, string FromType, string ServiceId, int ServMonth, int FeeM,string donote)
        {
            string procname = "ServForDo";
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName", SqlDbType.VarChar, 20),
                    new SqlParameter("@FromType", SqlDbType.VarChar,10),
                    new SqlParameter("@RecUser", SqlDbType.VarChar,10),
                    new SqlParameter("@ServiceId", SqlDbType.VarChar,10),
                    new SqlParameter("@ServMonth", SqlDbType.Int),
                    new SqlParameter("@FeeM", SqlDbType.Int),
                    new SqlParameter("@DoNote", SqlDbType.VarChar,2000),
                    new SqlParameter("@Rowid", SqlDbType.Int),
                    };
            parameters[0].Value = UserName;
            parameters[1].Value = FromType;
            parameters[2].Value = RecUser;
            parameters[3].Value = ServiceId;
            parameters[4].Value = ServMonth;
            parameters[5].Value = FeeM;
            parameters[6].Value = donote;
            parameters[7].Direction = ParameterDirection.Output;
            int RecordsAffected = 0;
            try
            {
                DbHelperSQL.ChangeOrderByExecute(procname, parameters);
                RecordsAffected = (int)parameters[7].Value;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            return RecordsAffected;
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SchSystem.Model.ServUserFor model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ServUserFor set ");
			 
			strSql.Append("ServStat=@ServStat,");
		 
			strSql.Append("DoNote=@DoNote");
			strSql.Append(" where AutoId=@AutoId");
			SqlParameter[] parameters = {
				 
					new SqlParameter("@ServStat", SqlDbType.TinyInt,1),
				 
					new SqlParameter("@DoNote", SqlDbType.NVarChar,2000),
					new SqlParameter("@AutoId", SqlDbType.Int,4)};
			 ;
			parameters[0].Value = model.ServStat;
		 ;
			parameters[1].Value = model.DoNote;
			parameters[2].Value = model.AutoId;

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
        /// 续费
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateRenewals(SchSystem.Model.ServUserFor model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ServUserFor set ");
            strSql.Append("ServMonth=@ServMonth,");
            strSql.Append("FeeM=@FeeM,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("EditTime=@EditTime,");
            strSql.Append("DoNote=@DoNote");
            strSql.Append(" where AutoId=@AutoId");
            SqlParameter[] parameters = {
					new SqlParameter("@ServMonth", SqlDbType.Int,4),
					new SqlParameter("@FeeM", SqlDbType.Int,4),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@EditTime", SqlDbType.DateTime),
					new SqlParameter("@DoNote", SqlDbType.NVarChar,2000),
					new SqlParameter("@AutoId", SqlDbType.Int,4)};
            parameters[0].Value = model.ServMonth;
            parameters[1].Value = model.FeeM;
            parameters[2].Value = model.EndTime;
            parameters[3].Value = model.EditTime;
            parameters[4].Value = model.DoNote;
            parameters[5].Value = model.AutoId;

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
		public bool Delete(int AutoId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ServUserFor ");
			strSql.Append(" where AutoId=@AutoId");
			SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
			parameters[0].Value = AutoId;

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
		public bool DeleteList(string AutoIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ServUserFor ");
			strSql.Append(" where AutoId in ("+AutoIdlist + ")  ");
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
		/// 得到一个对象实体
		/// </summary>
		public SchSystem.Model.ServUserFor GetModel(int AutoId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AutoId,UserName,FromType,RecUser,ServiceId,ServStat,ServMonth,FeeM,RecTime,EndTime,EditTime,DoNote from ServUserFor ");
			strSql.Append(" where AutoId=@AutoId");
			SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
			parameters[0].Value = AutoId;

			SchSystem.Model.ServUserFor model=new SchSystem.Model.ServUserFor();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}
        /// <summary>
        /// 得到一个对象实体:AutoId,UserName,FromType,RecUser,ServiceId,ServStat,ServMonth,FeeM,RecTime,EndTime,EditTime,DoNote
        /// </summary>
        /// <param name="cols"></param>
        /// <param name="AutoId"></param>
        /// <returns></returns>
        public SchSystem.Model.ServUserForV GetModelV(string cols,int AutoId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 "+cols+" from ServUserForV ");
			strSql.Append(" where AutoId=@AutoId");
			SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
			parameters[0].Value = AutoId;

			SchSystem.Model.ServUserFor model=new SchSystem.Model.ServUserFor();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModelV(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SchSystem.Model.ServUserFor DataRowToModel(DataRow row)
		{
			SchSystem.Model.ServUserFor model=new SchSystem.Model.ServUserFor();
			if (row != null)
			{
				if(row["AutoId"]!=null && row["AutoId"].ToString()!="")
				{
					model.AutoId=int.Parse(row["AutoId"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["FromType"]!=null)
				{
					model.FromType=row["FromType"].ToString();
				}
				if(row["RecUser"]!=null)
				{
					model.RecUser=row["RecUser"].ToString();
				}
				if(row["ServiceId"]!=null)
				{
					model.ServiceId=row["ServiceId"].ToString();
				}
				if(row["ServStat"]!=null && row["ServStat"].ToString()!="")
				{
					model.ServStat=int.Parse(row["ServStat"].ToString());
				}
				if(row["ServMonth"]!=null && row["ServMonth"].ToString()!="")
				{
					model.ServMonth=int.Parse(row["ServMonth"].ToString());
				}
				if(row["FeeM"]!=null && row["FeeM"].ToString()!="")
				{
					model.FeeM=int.Parse(row["FeeM"].ToString());
				}
				if(row["RecTime"]!=null && row["RecTime"].ToString()!="")
				{
					model.RecTime=DateTime.Parse(row["RecTime"].ToString());
				}
				if(row["EndTime"]!=null && row["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(row["EndTime"].ToString());
				}
				if(row["EditTime"]!=null && row["EditTime"].ToString()!="")
				{
					model.EditTime=DateTime.Parse(row["EditTime"].ToString());
				}
				if(row["DoNote"]!=null)
				{
					model.DoNote=row["DoNote"].ToString();
				}
			}
			return model;
		}
        public SchSystem.Model.ServUserForV DataRowToModelV(DataRow row)
        {
            SchSystem.Model.ServUserForV model = new SchSystem.Model.ServUserForV();
            if (row != null)
            {
                if (row["AutoId"] != null && row["AutoId"].ToString() != "")
                {
                    model.AutoId = int.Parse(row["AutoId"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["UTname"] != null)
                {
                    model.UTname = row["UTname"].ToString();
                }
                if (row["FromType"] != null)
                {
                    model.FromType = row["FromType"].ToString();
                }
                if (row["RecUser"] != null)
                {
                    model.RecUser = row["RecUser"].ToString();
                }
                if (row["CnName"] != null)
                {
                    model.CnName = row["CnName"].ToString();
                }
                if (row["ServiceId"] != null)
                {
                    model.ServiceId = row["ServiceId"].ToString();
                }
                if (row["Uareano"] != null)
                {
                    model.Uareano = row["Uareano"].ToString();
                }
                if (row["ServStat"] != null && row["ServStat"].ToString() != "")
                {
                    model.ServStat = int.Parse(row["ServStat"].ToString());
                }
                if (row["ServMonth"] != null && row["ServMonth"].ToString() != "")
                {
                    model.ServMonth = int.Parse(row["ServMonth"].ToString());
                }
                if (row["FeeM"] != null && row["FeeM"].ToString() != "")
                {
                    model.FeeM = int.Parse(row["FeeM"].ToString());
                }
                if (row["RecTime"] != null && row["RecTime"].ToString() != "")
                {
                    model.RecTime = DateTime.Parse(row["RecTime"].ToString());
                }
                if (row["EndTime"] != null && row["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(row["EndTime"].ToString());
                }
                if (row["EditTime"] != null && row["EditTime"].ToString() != "")
                {
                    model.EditTime = DateTime.Parse(row["EditTime"].ToString());
                }
                if (row["DoNote"] != null)
                {
                    model.DoNote = row["DoNote"].ToString();
                }
                if (row["BusMonth"] != null)
                {
                    model.BusMonth = int.Parse(row["BusMonth"].ToString());
                }
                if (row["FeeCode"] != null)
                {
                    model.FeeCode = row["FeeCode"].ToString();
                }
            }
            return model;
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AutoId,UserName,FromType,RecUser,ServiceId,ServStat,ServMonth,FeeM,RecTime,EndTime,EditTime,DoNote ");
			strSql.Append(" FROM ServUserFor ");
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
			strSql.Append(" AutoId,UserName,FromType,RecUser,ServiceId,ServStat,ServMonth,FeeM,RecTime,EndTime,EditTime,DoNote ");
			strSql.Append(" FROM ServUserFor ");
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
			strSql.Append("select count(1) FROM ServUserFor ");
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
				strSql.Append("order by T.AutoId desc");
			}
			strSql.Append(")AS Row, T.*  from ServUserFor T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}
        public int UserRefee(string uid, string servid, int servm, int feem, string dnote, string recutname, string frmtype)
        {
            string procname = "ServForDo";            
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar, 20),
                    new SqlParameter("@FromType", SqlDbType.NVarChar, 10),
                    new SqlParameter("@RecUser", SqlDbType.NVarChar, 10),
                    new SqlParameter("@ServiceId", SqlDbType.VarChar, 10),
					new SqlParameter("@ServMonth", SqlDbType.Int),
					new SqlParameter("@FeeM", SqlDbType.Int),
					new SqlParameter("@DoNote", SqlDbType.NVarChar, 200),
					new SqlParameter("@Rowid", SqlDbType.Int),
					};
            parameters[0].Value = uid;
            parameters[1].Value = frmtype;
            parameters[2].Value = recutname;
            parameters[3].Value = servid;
            parameters[4].Value = servm;
            parameters[5].Value = feem;
            parameters[6].Value = dnote;
            parameters[7].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure(procname, parameters);
            return (int)parameters[7].Value;
        }
		
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListColsV(string cols, string strWhere, string ordercols, string orderby, int PageIndex, int PageSize, ref int RowCount, ref int PageCount)
        {
            string procname = "XiaoZhengGe";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + cols);
            strSql.Append(" FROM ServUserForV  ");
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

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

