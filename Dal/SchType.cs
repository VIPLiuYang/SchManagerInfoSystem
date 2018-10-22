using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
namespace SchSystem.DAL
{
	/// <summary>
	/// 数据访问类:SchType
	/// </summary>
	public partial class SchType
	{
        public SchType()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SchTypeCode", "SchType"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SchTypeCode,int SchTypeId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SchType");
			strSql.Append(" where SchTypeCode=@SchTypeCode and SchTypeId=@SchTypeId ");
			SqlParameter[] parameters = {
					new SqlParameter("@SchTypeCode", SqlDbType.TinyInt,1),
					new SqlParameter("@SchTypeId", SqlDbType.Int,4)			};
			parameters[0].Value = SchTypeCode;
			parameters[1].Value = SchTypeId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SchSystem.Model.SchType model)
		{
            object obj;
            try
            {
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SchType(");
			strSql.Append("SchTypeCode,SchTypeName,Stat,NOTE)");
			strSql.Append(" values (");
			strSql.Append("@SchTypeCode,@SchTypeName,@Stat,@NOTE)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SchTypeCode", SqlDbType.TinyInt,8),
					new SqlParameter("@SchTypeName", SqlDbType.NVarChar,50),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@NOTE", SqlDbType.NVarChar,200)};
            

			parameters[0].Value = model.SchTypeCode;
			parameters[1].Value = model.SchTypeName;
			parameters[2].Value = model.Stat;
			parameters[3].Value = model.NOTE;
            
            
                obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
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
		public bool Update(SchSystem.Model.SchType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SchType set ");
			strSql.Append("SchTypeName=@SchTypeName,");
			strSql.Append("Stat=@Stat,");
			strSql.Append("NOTE=@NOTE");
			strSql.Append(" where SchTypeId=@SchTypeId");
			SqlParameter[] parameters = {
					new SqlParameter("@SchTypeName", SqlDbType.VarChar,20),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@NOTE", SqlDbType.NVarChar,100),
					new SqlParameter("@SchTypeId", SqlDbType.Int,4),
					new SqlParameter("@SchTypeCode", SqlDbType.TinyInt,1)};
			parameters[0].Value = model.SchTypeName;
			parameters[1].Value = model.Stat;
			parameters[2].Value = model.NOTE;
			parameters[3].Value = model.SchTypeId;
			parameters[4].Value = model.SchTypeCode;

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
		public bool Delete(int SchTypeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchType ");
			strSql.Append(" where SchTypeId=@SchTypeId");
			SqlParameter[] parameters = {
					new SqlParameter("@SchTypeId", SqlDbType.Int,4)
			};
			parameters[0].Value = SchTypeId;

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
		public bool Delete(int SchTypeCode,int SchTypeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchType ");
			strSql.Append(" where SchTypeCode=@SchTypeCode and SchTypeId=@SchTypeId ");
			SqlParameter[] parameters = {
					new SqlParameter("@SchTypeCode", SqlDbType.TinyInt,1),
					new SqlParameter("@SchTypeId", SqlDbType.Int,4)			};
			parameters[0].Value = SchTypeCode;
			parameters[1].Value = SchTypeId;

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
		public bool DeleteList(string SchTypeIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchType ");
			strSql.Append(" where SchTypeId in ("+SchTypeIdlist + ")  ");
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
		public SchSystem.Model.SchType GetModel(int SchTypeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SchTypeId,SchTypeCode,SchTypeName,Stat,NOTE from SchType ");
			strSql.Append(" where SchTypeId=@SchTypeId");
			SqlParameter[] parameters = {
					new SqlParameter("@SchTypeId", SqlDbType.Int,4)
			};
			parameters[0].Value = SchTypeId;

			SchSystem.Model.SchType model=new SchSystem.Model.SchType();
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
		public SchSystem.Model.SchType DataRowToModel(DataRow row)
		{
			SchSystem.Model.SchType model=new SchSystem.Model.SchType();
			if (row != null)
			{
				if(row["SchTypeId"]!=null && row["SchTypeId"].ToString()!="")
				{
					model.SchTypeId=int.Parse(row["SchTypeId"].ToString());
				}
				if(row["SchTypeCode"]!=null && row["SchTypeCode"].ToString()!="")
				{
					model.SchTypeCode=int.Parse(row["SchTypeCode"].ToString());
				}
				if(row["SchTypeName"]!=null)
				{
					model.SchTypeName=row["SchTypeName"].ToString();
				}
				if(row["Stat"]!=null && row["Stat"].ToString()!="")
				{
					model.Stat=int.Parse(row["Stat"].ToString());
				}
				if(row["NOTE"]!=null)
				{
					model.NOTE=row["NOTE"].ToString();
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
			strSql.Append("select SchTypeId,SchTypeCode,SchTypeName,Stat,NOTE ");
			strSql.Append(" FROM SchType ");
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
			strSql.Append(" SchTypeId,SchTypeCode,SchTypeName,Stat,NOTE ");
			strSql.Append(" FROM SchType ");
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
			strSql.Append("select count(1) FROM SchType ");
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
				strSql.Append("order by T.SchTypeId desc");
			}
			strSql.Append(")AS Row, T.*  from SchType T ");
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
			parameters[0].Value = "SchType";
			parameters[1].Value = "SchTypeId";
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

