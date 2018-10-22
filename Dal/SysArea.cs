using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
namespace SchSystem.DAL
{
	/// <summary>
	/// 数据访问类:SysArea
	/// </summary>
	public partial class SysArea
	{
        public SysArea()
		{}
		#region  BasicMethod
        public DataTable GetAreas(string type, string pareacode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AreaCode acode, AreaName aname, TypeCode atype  from SysArea");
            if (type != "")
            {
                strSql.Append(" where stat=1 and TypeCode='" + type + "' and left(AreaCode," + pareacode.Length + ")=@AreaCode order by AreaCode");
            }
            else
            {
                strSql.Append(" where stat=1 order by AreaCode");
            }
            SqlParameter[] parameters = {
			            new SqlParameter("@AreaCode", SqlDbType.Char,12)            
              
            };
            parameters[0].Value = pareacode;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        public DataSet GetList(string Cols, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + Cols);
            strSql.Append(" FROM SysArea ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Tabid", "SysArea"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Tabid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SysArea");
			strSql.Append(" where Tabid=@Tabid");
			SqlParameter[] parameters = {
					new SqlParameter("@Tabid", SqlDbType.Int,4)
			};
			parameters[0].Value = Tabid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SchSystem.Model.SysArea model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SysArea(");
			strSql.Append("AreaCode,AreaName,TypeCode,Stat)");
			strSql.Append(" values (");
			strSql.Append("@AreaCode,@AreaName,@TypeCode,@Stat)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@AreaCode", SqlDbType.VarChar,10),
					new SqlParameter("@AreaName", SqlDbType.VarChar,30),
					new SqlParameter("@TypeCode", SqlDbType.TinyInt,1),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1)};
			parameters[0].Value = model.AreaCode;
			parameters[1].Value = model.AreaName;
			parameters[2].Value = model.TypeCode;
			parameters[3].Value = model.Stat;

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
		public bool Update(SchSystem.Model.SysArea model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SysArea set ");
			strSql.Append("AreaCode=@AreaCode,");
			strSql.Append("AreaName=@AreaName,");
			strSql.Append("TypeCode=@TypeCode,");
			strSql.Append("Stat=@Stat");
			strSql.Append(" where Tabid=@Tabid");
			SqlParameter[] parameters = {
					new SqlParameter("@AreaCode", SqlDbType.VarChar,10),
					new SqlParameter("@AreaName", SqlDbType.VarChar,30),
					new SqlParameter("@TypeCode", SqlDbType.TinyInt,1),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@Tabid", SqlDbType.Int,4)};
			parameters[0].Value = model.AreaCode;
			parameters[1].Value = model.AreaName;
			parameters[2].Value = model.TypeCode;
			parameters[3].Value = model.Stat;
			parameters[4].Value = model.Tabid;

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
		public bool Delete(int Tabid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SysArea ");
			strSql.Append(" where Tabid=@Tabid");
			SqlParameter[] parameters = {
					new SqlParameter("@Tabid", SqlDbType.Int,4)
			};
			parameters[0].Value = Tabid;

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
		public bool DeleteList(string Tabidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SysArea ");
			strSql.Append(" where Tabid in ("+Tabidlist + ")  ");
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
		public SchSystem.Model.SysArea GetModel(int Tabid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Tabid,AreaCode,AreaName,TypeCode,Stat from SysArea ");
			strSql.Append(" where Tabid=@Tabid");
			SqlParameter[] parameters = {
					new SqlParameter("@Tabid", SqlDbType.Int,4)
			};
			parameters[0].Value = Tabid;

			SchSystem.Model.SysArea model=new SchSystem.Model.SysArea();
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
		public SchSystem.Model.SysArea DataRowToModel(DataRow row)
		{
			SchSystem.Model.SysArea model=new SchSystem.Model.SysArea();
			if (row != null)
			{
				if(row["Tabid"]!=null && row["Tabid"].ToString()!="")
				{
					model.Tabid=int.Parse(row["Tabid"].ToString());
				}
				if(row["AreaCode"]!=null)
				{
					model.AreaCode=row["AreaCode"].ToString();
				}
				if(row["AreaName"]!=null)
				{
					model.AreaName=row["AreaName"].ToString();
				}
				if(row["TypeCode"]!=null && row["TypeCode"].ToString()!="")
				{
					model.TypeCode=int.Parse(row["TypeCode"].ToString());
				}
				if(row["Stat"]!=null && row["Stat"].ToString()!="")
				{
					model.Stat=int.Parse(row["Stat"].ToString());
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
			strSql.Append("select Tabid,AreaCode,AreaName,TypeCode,Stat ");
			strSql.Append(" FROM SysArea ");
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
			strSql.Append(" Tabid,AreaCode,AreaName,TypeCode,Stat ");
			strSql.Append(" FROM SysArea ");
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
			strSql.Append("select count(1) FROM SysArea ");
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
				strSql.Append("order by T.Tabid desc");
			}
			strSql.Append(")AS Row, T.*  from SysArea T ");
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
			parameters[0].Value = "SysArea";
			parameters[1].Value = "Tabid";
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

