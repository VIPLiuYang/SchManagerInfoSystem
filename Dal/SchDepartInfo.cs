using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
namespace SchSystem.Dal
{
	/// <summary>
	/// 数据访问类:SchDepartInfo
	/// </summary>
	public partial class SchDepartInfoDal
	{
        public SchDepartInfoDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("DepartId", "SchDepartInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DepartId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SchDepartInfo");
			strSql.Append(" where DepartId=@DepartId");
			SqlParameter[] parameters = {
					new SqlParameter("@DepartId", SqlDbType.Int,4)
			};
			parameters[0].Value = DepartId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SchSystem.Model.SchDepartInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SchDepartInfo(");
			strSql.Append("DepartName,Pid,OrderId,SchId,Stat,RecTime,RecUser,LastRecTime,LastRecUser)");
			strSql.Append(" values (");
			strSql.Append("@DepartName,@Pid,@OrderId,@SchId,@Stat,@RecTime,@RecUser,@LastRecTime,@LastRecUser)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DepartName", SqlDbType.VarChar,20),
					new SqlParameter("@Pid", SqlDbType.Int,4),
					new SqlParameter("@OrderId", SqlDbType.Int,4),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@RecTime", SqlDbType.SmallDateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,50),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20)};
			parameters[0].Value = model.DepartName;
			parameters[1].Value = model.Pid;
			parameters[2].Value = model.OrderId;
			parameters[3].Value = model.SchId;
			parameters[4].Value = model.Stat;
			parameters[5].Value = model.RecTime;
			parameters[6].Value = model.RecUser;
			parameters[7].Value = model.LastRecTime;
			parameters[8].Value = model.LastRecUser;

            int obj = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
		public bool Update(SchSystem.Model.SchDepartInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SchDepartInfo set ");
			strSql.Append("DepartName=@DepartName,");
			strSql.Append("Pid=@Pid,");
			strSql.Append("OrderId=@OrderId,");
			strSql.Append("SchId=@SchId,");
			strSql.Append("Stat=@Stat,");
			strSql.Append("RecTime=@RecTime,");
			strSql.Append("RecUser=@RecUser,");
			strSql.Append("LastRecTime=@LastRecTime,");
			strSql.Append("LastRecUser=@LastRecUser");
			strSql.Append(" where DepartId=@DepartId");
			SqlParameter[] parameters = {
					new SqlParameter("@DepartName", SqlDbType.VarChar,20),
					new SqlParameter("@Pid", SqlDbType.Int,4),
					new SqlParameter("@OrderId", SqlDbType.Int,4),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@RecTime", SqlDbType.SmallDateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,50),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@DepartId", SqlDbType.Int,4)};
			parameters[0].Value = model.DepartName;
			parameters[1].Value = model.Pid;
			parameters[2].Value = model.OrderId;
			parameters[3].Value = model.SchId;
			parameters[4].Value = model.Stat;
			parameters[5].Value = model.RecTime;
			parameters[6].Value = model.RecUser;
			parameters[7].Value = model.LastRecTime;
			parameters[8].Value = model.LastRecUser;
			parameters[9].Value = model.DepartId;

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
		public bool Delete(int DepartId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchDepartInfo ");
			strSql.Append(" where DepartId=@DepartId");
			SqlParameter[] parameters = {
					new SqlParameter("@DepartId", SqlDbType.Int,4)
			};
			parameters[0].Value = DepartId;

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
		public bool DeleteList(string DepartIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchDepartInfo ");
			strSql.Append(" where DepartId in ("+DepartIdlist + ")  ");
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
		public SchSystem.Model.SchDepartInfo GetModel(int DepartId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DepartId,DepartName,Pid,OrderId,SchId,Stat,RecTime,RecUser,LastRecTime,LastRecUser from SchDepartInfo ");
			strSql.Append(" where DepartId=@DepartId");
			SqlParameter[] parameters = {
					new SqlParameter("@DepartId", SqlDbType.Int,4)
			};
			parameters[0].Value = DepartId;

			SchSystem.Model.SchDepartInfo model=new SchSystem.Model.SchDepartInfo();
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
		public SchSystem.Model.SchDepartInfo DataRowToModel(DataRow row)
		{
			SchSystem.Model.SchDepartInfo model=new SchSystem.Model.SchDepartInfo();
			if (row != null)
			{
				if(row["DepartId"]!=null && row["DepartId"].ToString()!="")
				{
					model.DepartId=int.Parse(row["DepartId"].ToString());
				}
				if(row["DepartName"]!=null)
				{
					model.DepartName=row["DepartName"].ToString();
				}
				if(row["Pid"]!=null && row["Pid"].ToString()!="")
				{
					model.Pid=int.Parse(row["Pid"].ToString());
				}
				if(row["OrderId"]!=null && row["OrderId"].ToString()!="")
				{
					model.OrderId=int.Parse(row["OrderId"].ToString());
				}
				if(row["SchId"]!=null && row["SchId"].ToString()!="")
				{
					model.SchId=int.Parse(row["SchId"].ToString());
				}
				if(row["Stat"]!=null && row["Stat"].ToString()!="")
				{
					model.Stat=int.Parse(row["Stat"].ToString());
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select a.DepartId,a.DepartName,a.Pid,c.DepartName as Pname,a.OrderId,a.SchId,b.SchName,a.Stat,a.RecTime,a.RecUser,a.LastRecTime,a.LastRecUser ");
			strSql.Append(" FROM SchDepartInfo as a	 left join SchInfo as b on a.SchId=b.SchId	left join SchDepartInfo as c on c.Pid=a.DepartId	  ");
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
			strSql.Append(" DepartId,DepartName,Pid,OrderId,SchId,Stat,RecTime,RecUser,LastRecTime,LastRecUser ");
			strSql.Append(" FROM SchDepartInfo ");
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
			strSql.Append("select count(1) FROM SchDepartInfo ");
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
				strSql.Append("order by T.DepartId desc");
			}
			strSql.Append(")AS Row, T.*  from SchDepartInfo T ");
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
			parameters[0].Value = "SchDepartInfo";
			parameters[1].Value = "DepartId";
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

