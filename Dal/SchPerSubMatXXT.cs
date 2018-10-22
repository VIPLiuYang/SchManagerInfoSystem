using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
namespace SchSystem.DAL
{
	/// <summary>
	/// 数据访问类:SchPerSubMatXXT
	/// </summary>
	public partial class SchPerSubMatXXT
	{
		public SchPerSubMatXXT()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("AutoId", "SchPerSubMatXXT"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(int SchId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SchPerSubMatXXT");
            strSql.Append(" where SchId=@SchId");
			SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,4)
			};
            parameters[0].Value = SchId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SchSystem.Model.SchPerSubMatXXT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SchPerSubMatXXT(");
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
		public bool Update(SchSystem.Model.SchPerSubMatXXT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SchPerSubMatXXT set ");
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
		public bool Delete(int schid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchPerSubMatXXT ");
            strSql.Append(" where SchId=@SchId");
			SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.Int,8)
			};
            parameters[0].Value = schid;

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
			strSql.Append("delete from SchPerSubMatXXT ");
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
		public SchSystem.Model.SchPerSubMatXXT GetModel(int AutoId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AutoId,PerCode,SubCode,MaterCode,SchId from SchPerSubMatXXT ");
			strSql.Append(" where AutoId=@AutoId");
			SqlParameter[] parameters = {
					new SqlParameter("@AutoId", SqlDbType.Int,4)
			};
			parameters[0].Value = AutoId;

			SchSystem.Model.SchPerSubMatXXT model=new SchSystem.Model.SchPerSubMatXXT();
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
		public SchSystem.Model.SchPerSubMatXXT DataRowToModel(DataRow row)
		{
			SchSystem.Model.SchPerSubMatXXT model=new SchSystem.Model.SchPerSubMatXXT();
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
			strSql.Append(" FROM SchPerSubMatXXT ");
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
			strSql.Append(" FROM SchPerSubMatXXT ");
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
			strSql.Append("select count(1) FROM SchPerSubMatXXT ");
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
			strSql.Append(")AS Row, T.*  from SchPerSubMatXXT T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		
		/// <summary>
		/// 学段、科目及教版
		/// </summary>
        public DataSet SchPerSubMatXXTV(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SubName,MaterName,PerCode,SubCode,MaterCode,SchId,SysSubStat,SysMaterStat ");
            strSql.Append(" FROM SchPerSubMatXXTV ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

