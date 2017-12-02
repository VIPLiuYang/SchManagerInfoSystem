using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
namespace SchSystem.Dal
{
	/// <summary>
	/// 数据访问类:SchUserInfo
	/// </summary>
	public partial class SchUserInfoDal
	{
        public SchUserInfoDal()
		{}
		#region  BasicMethod

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
		/// 增加一条数据
		/// </summary>
		public int Add(SchSystem.Model.SchUserInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SchUserInfo(");
			strSql.Append("UserName,UserTname,PassWord,SchId,OrderId,Stat,DepartIds,UserLv,Mobile,Telno,Postion,ImgUrl,LoginTime,ClassMs,RecTime,RecUser,LastRecTime,LastRecUser,CopeId,RoleId)");
			strSql.Append(" values (");
			strSql.Append("@UserName,@UserTname,@PassWord,@SchId,@OrderId,@Stat,@DepartIds,@UserLv,@Mobile,@Telno,@Postion,@ImgUrl,@LoginTime,@ClassMs,@RecTime,@RecUser,@LastRecTime,@LastRecUser,@CopeId,@RoleId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,30),
					new SqlParameter("@UserTname", SqlDbType.VarChar,20),
					new SqlParameter("@PassWord", SqlDbType.VarChar,20),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@OrderId", SqlDbType.Int,4),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@DepartIds", SqlDbType.VarChar,500),
					new SqlParameter("@UserLv", SqlDbType.TinyInt,1),
					new SqlParameter("@Mobile", SqlDbType.VarChar,15),
					new SqlParameter("@Telno", SqlDbType.VarChar,15),
					new SqlParameter("@Postion", SqlDbType.VarChar,20),
					new SqlParameter("@ImgUrl", SqlDbType.VarChar,300),
					new SqlParameter("@LoginTime", SqlDbType.DateTime),
					new SqlParameter("@ClassMs", SqlDbType.VarChar,500),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,20),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@CopeId", SqlDbType.Int,4),
					new SqlParameter("@RoleId", SqlDbType.Int,4)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.UserTname;
			parameters[2].Value = model.PassWord;
			parameters[3].Value = model.SchId;
			parameters[4].Value = model.OrderId;
			parameters[5].Value = model.Stat;
			parameters[6].Value = model.DepartIds;
			parameters[7].Value = model.UserLv;
			parameters[8].Value = model.Mobile;
			parameters[9].Value = model.Telno;
			parameters[10].Value = model.Postion;
			parameters[11].Value = model.ImgUrl;
			parameters[12].Value = model.LoginTime;
			parameters[13].Value = model.ClassMs;
			parameters[14].Value = model.RecTime;
			parameters[15].Value = model.RecUser;
			parameters[16].Value = model.LastRecTime;
			parameters[17].Value = model.LastRecUser;
			parameters[18].Value = model.CopeId;
			parameters[19].Value = model.RoleId;

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
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SchSystem.Model.SchUserInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SchUserInfo set ");
			strSql.Append("UserName=@UserName,");
			strSql.Append("UserTname=@UserTname,");
			strSql.Append("PassWord=@PassWord,");
			strSql.Append("SchId=@SchId,");
			strSql.Append("OrderId=@OrderId,");
			strSql.Append("Stat=@Stat,");
			strSql.Append("DepartIds=@DepartIds,");
			strSql.Append("UserLv=@UserLv,");
			strSql.Append("Mobile=@Mobile,");
			strSql.Append("Telno=@Telno,");
			strSql.Append("Postion=@Postion,");
			strSql.Append("ImgUrl=@ImgUrl,");
			strSql.Append("LoginTime=@LoginTime,");
			strSql.Append("ClassMs=@ClassMs,");
			strSql.Append("RecTime=@RecTime,");
			strSql.Append("RecUser=@RecUser,");
			strSql.Append("LastRecTime=@LastRecTime,");
			strSql.Append("LastRecUser=@LastRecUser,");
			strSql.Append("CopeId=@CopeId,");
			strSql.Append("RoleId=@RoleId");
			strSql.Append(" where UserId=@UserId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,30),
					new SqlParameter("@UserTname", SqlDbType.VarChar,20),
					new SqlParameter("@PassWord", SqlDbType.VarChar,20),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@OrderId", SqlDbType.Int,4),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@DepartIds", SqlDbType.VarChar,500),
					new SqlParameter("@UserLv", SqlDbType.TinyInt,1),
					new SqlParameter("@Mobile", SqlDbType.VarChar,15),
					new SqlParameter("@Telno", SqlDbType.VarChar,15),
					new SqlParameter("@Postion", SqlDbType.VarChar,20),
					new SqlParameter("@ImgUrl", SqlDbType.VarChar,300),
					new SqlParameter("@LoginTime", SqlDbType.DateTime),
					new SqlParameter("@ClassMs", SqlDbType.VarChar,500),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,20),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@CopeId", SqlDbType.Int,4),
					new SqlParameter("@RoleId", SqlDbType.Int,4),
					new SqlParameter("@UserId", SqlDbType.Int,4)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.UserTname;
			parameters[2].Value = model.PassWord;
			parameters[3].Value = model.SchId;
			parameters[4].Value = model.OrderId;
			parameters[5].Value = model.Stat;
			parameters[6].Value = model.DepartIds;
			parameters[7].Value = model.UserLv;
			parameters[8].Value = model.Mobile;
			parameters[9].Value = model.Telno;
			parameters[10].Value = model.Postion;
			parameters[11].Value = model.ImgUrl;
			parameters[12].Value = model.LoginTime;
			parameters[13].Value = model.ClassMs;
			parameters[14].Value = model.RecTime;
			parameters[15].Value = model.RecUser;
			parameters[16].Value = model.LastRecTime;
			parameters[17].Value = model.LastRecUser;
			parameters[18].Value = model.CopeId;
			parameters[19].Value = model.RoleId;
			parameters[20].Value = model.UserId;

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
		/// 得到一个对象实体
		/// </summary>
		public SchSystem.Model.SchUserInfo GetModel(int UserId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UserId,UserName,UserTname,PassWord,SchId,OrderId,Stat,DepartIds,UserLv,Mobile,Telno,Postion,ImgUrl,LoginTime,ClassMs,RecTime,RecUser,LastRecTime,LastRecUser,CopeId,RoleId from SchUserInfo ");
			strSql.Append(" where UserId=@UserId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)
			};
			parameters[0].Value = UserId;

			SchSystem.Model.SchUserInfo model=new SchSystem.Model.SchUserInfo();
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
		/// 得到一个对象实体
		/// </summary>
		public SchSystem.Model.SchUserInfo DataRowToModel(DataRow row)
		{
			SchSystem.Model.SchUserInfo model=new SchSystem.Model.SchUserInfo();
			if (row != null)
			{
				if(row["UserId"]!=null && row["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(row["UserId"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["UserTname"]!=null)
				{
					model.UserTname=row["UserTname"].ToString();
				}
				if(row["PassWord"]!=null)
				{
					model.PassWord=row["PassWord"].ToString();
				}
				if(row["SchId"]!=null && row["SchId"].ToString()!="")
				{
					model.SchId=int.Parse(row["SchId"].ToString());
				}
				if(row["OrderId"]!=null && row["OrderId"].ToString()!="")
				{
					model.OrderId=int.Parse(row["OrderId"].ToString());
				}
				if(row["Stat"]!=null && row["Stat"].ToString()!="")
				{
					model.Stat=int.Parse(row["Stat"].ToString());
				}
				if(row["DepartIds"]!=null)
				{
					model.DepartIds=row["DepartIds"].ToString();
				}
				if(row["UserLv"]!=null && row["UserLv"].ToString()!="")
				{
					model.UserLv=int.Parse(row["UserLv"].ToString());
				}
				if(row["Mobile"]!=null)
				{
					model.Mobile=row["Mobile"].ToString();
				}
				if(row["Telno"]!=null)
				{
					model.Telno=row["Telno"].ToString();
				}
				if(row["Postion"]!=null)
				{
					model.Postion=row["Postion"].ToString();
				}
				if(row["ImgUrl"]!=null)
				{
					model.ImgUrl=row["ImgUrl"].ToString();
				}
				if(row["LoginTime"]!=null && row["LoginTime"].ToString()!="")
				{
					model.LoginTime=DateTime.Parse(row["LoginTime"].ToString());
				}
				if(row["ClassMs"]!=null)
				{
					model.ClassMs=row["ClassMs"].ToString();
				}
				if(row["RecTime"]!=null && row["RecTime"].ToString()!="")
				{
					model.RecTime=DateTime.Parse(row["RecTime"].ToString());
				}
				if(row["RecUser"]!=null)
				{
					model.RecUser=row["RecUser"].ToString();
				}
				if(row["LastRecTime"]!=null && row["LastRecTime"].ToString()!="")
				{
					model.LastRecTime=DateTime.Parse(row["LastRecTime"].ToString());
				}
				if(row["LastRecUser"]!=null)
				{
					model.LastRecUser=row["LastRecUser"].ToString();
				}
				if(row["CopeId"]!=null && row["CopeId"].ToString()!="")
				{
					model.CopeId=int.Parse(row["CopeId"].ToString());
				}
				if(row["RoleId"]!=null && row["RoleId"].ToString()!="")
				{
					model.RoleId=int.Parse(row["RoleId"].ToString());
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
			strSql.Append(" select a.UserId,a.UserName,a.UserTname,a.PassWord,a.SchId,a.OrderId,a.Stat,a.DepartIds,b.Departname,a.UserLv,a.Mobile,a.Telno,a.Postion, ");
            strSql.Append(" a.ImgUrl,a.LoginTime,a.ClassMs,a.RecTime,a.RecUser,a.LastRecTime,a.LastRecUser,a.CopeId,a.RoleId FROM SchUserInfo as a ");
            strSql.Append(" left join SchDepartInfo as b on a.DepartIds=b.DepartId	 ");
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
			strSql.Append(" UserId,UserName,UserTname,PassWord,SchId,OrderId,Stat,DepartIds,UserLv,Mobile,Telno,Postion,ImgUrl,LoginTime,ClassMs,RecTime,RecUser,LastRecTime,LastRecUser,CopeId,RoleId ");
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

