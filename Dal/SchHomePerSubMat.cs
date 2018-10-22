using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
namespace SchWebAdmin.DAL
{
	/// <summary>
	/// 数据访问类:SchHomePerSubMat
	/// </summary>
	public partial class SchHomePerSubMat
	{
		public SchHomePerSubMat()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("AutoId", "SchHomePerSubMat"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AutoId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SchHomePerSubMat");
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
		public int Add(SchWebAdmin.Model.SchHomePerSubMat model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SchHomePerSubMat(");
			strSql.Append("PerCode,SubCode,MaterCode,SchId)");
			strSql.Append(" values (");
			strSql.Append("@PerCode,@SubCode,@MaterCode,@SchId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PerCode", SqlDbType.VarChar,10),
					new SqlParameter("@SubCode", SqlDbType.VarChar,10),
					new SqlParameter("@MaterCode", SqlDbType.VarChar,100),
					new SqlParameter("@SchId", SqlDbType.Int,4)};
			parameters[0].Value = model.PerCode;
			parameters[1].Value = model.SubCode;
			parameters[2].Value = model.MaterCode;
			parameters[3].Value = model.SchId;

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
		public bool Update(SchWebAdmin.Model.SchHomePerSubMat model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SchHomePerSubMat set ");
			strSql.Append("PerCode=@PerCode,");
			strSql.Append("SubCode=@SubCode,");
			strSql.Append("MaterCode=@MaterCode,");
			strSql.Append("SchId=@SchId");
			strSql.Append(" where AutoId=@AutoId");
			SqlParameter[] parameters = {
					new SqlParameter("@PerCode", SqlDbType.VarChar,10),
					new SqlParameter("@SubCode", SqlDbType.VarChar,10),
					new SqlParameter("@MaterCode", SqlDbType.VarChar,100),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@AutoId", SqlDbType.Int,4)};
			parameters[0].Value = model.PerCode;
			parameters[1].Value = model.SubCode;
			parameters[2].Value = model.MaterCode;
			parameters[3].Value = model.SchId;
			parameters[4].Value = model.AutoId;

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
		public bool Delete(int AutoId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchHomePerSubMat ");
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
			strSql.Append("delete from SchHomePerSubMat ");
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
		public SchWebAdmin.Model.SchHomePerSubMat GetModel(int AutoId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AutoId,PerCode,SubCode,MaterCode,SchId from SchHomePerSubMat ");
			strSql.Append(" where AutoId=@AutoId");
			SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
			parameters[0].Value = AutoId;

			SchWebAdmin.Model.SchHomePerSubMat model=new SchWebAdmin.Model.SchHomePerSubMat();
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
		public SchWebAdmin.Model.SchHomePerSubMat DataRowToModel(DataRow row)
		{
			SchWebAdmin.Model.SchHomePerSubMat model=new SchWebAdmin.Model.SchHomePerSubMat();
			if (row != null)
			{
				if(row["AutoId"]!=null && row["AutoId"].ToString()!="")
				{
					model.AutoId=int.Parse(row["AutoId"].ToString());
				}
				if(row["PerCode"]!=null)
				{
					model.PerCode=row["PerCode"].ToString();
				}
				if(row["SubCode"]!=null)
				{
					model.SubCode=row["SubCode"].ToString();
				}
				if(row["MaterCode"]!=null)
				{
					model.MaterCode=row["MaterCode"].ToString();
				}
				if(row["SchId"]!=null && row["SchId"].ToString()!="")
				{
					model.SchId=int.Parse(row["SchId"].ToString());
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
			strSql.Append("select AutoId,PerCode,SubCode,MaterCode,SchId ");
			strSql.Append(" FROM SchHomePerSubMat ");
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
			strSql.Append(" AutoId,PerCode,SubCode,MaterCode,SchId ");
			strSql.Append(" FROM SchHomePerSubMat ");
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
			strSql.Append("select count(1) FROM SchHomePerSubMat ");
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
			strSql.Append(")AS Row, T.*  from SchHomePerSubMat T ");
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
			parameters[0].Value = "SchHomePerSubMat";
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

		#endregion  ExtensionMethod
	}
}

