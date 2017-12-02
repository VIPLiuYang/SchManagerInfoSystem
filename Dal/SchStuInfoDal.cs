﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
using SchManagerInfoSystem;
namespace SchSystem.Dal
{
	/// <summary>
	/// 数据访问类:SchStuInfo
	/// </summary>
	public partial class SchStuInfoDal
	{
        public SchStuInfoDal()
		{}
		#region  BasicMethod

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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SchStuInfo");
			strSql.Append(" where StuId=@StuId");
			SqlParameter[] parameters = {
					new SqlParameter("@StuId", SqlDbType.Int,4)
			};
			parameters[0].Value = StuId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SchSystem.Model.SchStuInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SchStuInfo(");
			strSql.Append("LoginName,Pwd,StuName,StuNo,ClassId,SchId,CardNo,Sex,Birth,ImgUrl,StudyType,Stat,LoginTime,RecTime,RecUser,LastRecTime,LastRecUser)");
			strSql.Append(" values (");
			strSql.Append("@LoginName,@Pwd,@StuName,@StuNo,@ClassId,@SchId,@CardNo,@Sex,@Birth,@ImgUrl,@StudyType,@Stat,@LoginTime,@RecTime,@RecUser,@LastRecTime,@LastRecUser)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@Pwd", SqlDbType.VarChar,20),
					new SqlParameter("@StuName", SqlDbType.VarChar,20),
					new SqlParameter("@StuNo", SqlDbType.VarChar,15),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@CardNo", SqlDbType.VarChar,15),
					new SqlParameter("@Sex", SqlDbType.TinyInt,1),
					new SqlParameter("@Birth", SqlDbType.DateTime),
					new SqlParameter("@ImgUrl", SqlDbType.VarChar,200),
					new SqlParameter("@StudyType", SqlDbType.TinyInt,1),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@LoginTime", SqlDbType.DateTime),
					new SqlParameter("@RecTime", SqlDbType.SmallDateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,50),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20)};
			parameters[0].Value = model.LoginName;
			parameters[1].Value = model.Pwd;
			parameters[2].Value = model.StuName;
			parameters[3].Value = model.StuNo;
			parameters[4].Value = model.ClassId;
			parameters[5].Value = model.SchId;
			parameters[6].Value = model.CardNo;
			parameters[7].Value = model.Sex;
			parameters[8].Value = model.Birth;
			parameters[9].Value = model.ImgUrl;
			parameters[10].Value = model.StudyType;
			parameters[11].Value = model.Stat;
			parameters[12].Value = model.LoginTime;
			parameters[13].Value = model.RecTime;
			parameters[14].Value = model.RecUser;
			parameters[15].Value = model.LastRecTime;
			parameters[16].Value = model.LastRecUser;

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
		public bool Update(SchSystem.Model.SchStuInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SchStuInfo set ");
			strSql.Append("LoginName=@LoginName,");
			strSql.Append("Pwd=@Pwd,");
			strSql.Append("StuName=@StuName,");
			strSql.Append("StuNo=@StuNo,");
			strSql.Append("ClassId=@ClassId,");
			strSql.Append("SchId=@SchId,");
			strSql.Append("CardNo=@CardNo,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("Birth=@Birth,");
			strSql.Append("ImgUrl=@ImgUrl,");
			strSql.Append("StudyType=@StudyType,");
			strSql.Append("Stat=@Stat,");
			strSql.Append("LoginTime=@LoginTime,");
			strSql.Append("RecTime=@RecTime,");
			strSql.Append("RecUser=@RecUser,");
			strSql.Append("LastRecTime=@LastRecTime,");
			strSql.Append("LastRecUser=@LastRecUser");
			strSql.Append(" where StuId=@StuId");
			SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@Pwd", SqlDbType.VarChar,20),
					new SqlParameter("@StuName", SqlDbType.VarChar,20),
					new SqlParameter("@StuNo", SqlDbType.VarChar,15),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@SchId", SqlDbType.Int,4),
					new SqlParameter("@CardNo", SqlDbType.VarChar,15),
					new SqlParameter("@Sex", SqlDbType.TinyInt,1),
					new SqlParameter("@Birth", SqlDbType.DateTime),
					new SqlParameter("@ImgUrl", SqlDbType.VarChar,200),
					new SqlParameter("@StudyType", SqlDbType.TinyInt,1),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@LoginTime", SqlDbType.DateTime),
					new SqlParameter("@RecTime", SqlDbType.SmallDateTime),
					new SqlParameter("@RecUser", SqlDbType.VarChar,50),
					new SqlParameter("@LastRecTime", SqlDbType.DateTime),
					new SqlParameter("@LastRecUser", SqlDbType.VarChar,20),
					new SqlParameter("@StuId", SqlDbType.Int,4)};
			parameters[0].Value = model.LoginName;
			parameters[1].Value = model.Pwd;
			parameters[2].Value = model.StuName;
			parameters[3].Value = model.StuNo;
			parameters[4].Value = model.ClassId;
			parameters[5].Value = model.SchId;
			parameters[6].Value = model.CardNo;
			parameters[7].Value = model.Sex;
			parameters[8].Value = model.Birth;
			parameters[9].Value = model.ImgUrl;
			parameters[10].Value = model.StudyType;
			parameters[11].Value = model.Stat;
			parameters[12].Value = model.LoginTime;
			parameters[13].Value = model.RecTime;
			parameters[14].Value = model.RecUser;
			parameters[15].Value = model.LastRecTime;
			parameters[16].Value = model.LastRecUser;
			parameters[17].Value = model.StuId;

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
		public bool Delete(int StuId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchStuInfo ");
			strSql.Append(" where StuId=@StuId");
			SqlParameter[] parameters = {
					new SqlParameter("@StuId", SqlDbType.Int,4)
			};
			parameters[0].Value = StuId;

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
		public bool DeleteList(string StuIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchStuInfo ");
			strSql.Append(" where StuId in ("+StuIdlist + ")  ");
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
		public SchSystem.Model.SchStuInfo GetModel(int StuId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 StuId,LoginName,Pwd,StuName,StuNo,ClassId,SchId,CardNo,Sex,Birth,ImgUrl,StudyType,Stat,LoginTime,RecTime,RecUser,LastRecTime,LastRecUser from SchStuInfo ");
			strSql.Append(" where StuId=@StuId");
			SqlParameter[] parameters = {
					new SqlParameter("@StuId", SqlDbType.Int,4)
			};
			parameters[0].Value = StuId;

			SchSystem.Model.SchStuInfo model=new SchSystem.Model.SchStuInfo();
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
		public SchSystem.Model.SchStuInfo DataRowToModel(DataRow row)
		{
			SchSystem.Model.SchStuInfo model=new SchSystem.Model.SchStuInfo();
			if (row != null)
			{
				if(row["StuId"]!=null && row["StuId"].ToString()!="")
				{
					model.StuId=int.Parse(row["StuId"].ToString());
				}
				if(row["LoginName"]!=null)
				{
					model.LoginName=row["LoginName"].ToString();
				}
				if(row["Pwd"]!=null)
				{
					model.Pwd=row["Pwd"].ToString();
				}
				if(row["StuName"]!=null)
				{
					model.StuName=row["StuName"].ToString();
				}
				if(row["StuNo"]!=null)
				{
					model.StuNo=row["StuNo"].ToString();
				}
				if(row["ClassId"]!=null && row["ClassId"].ToString()!="")
				{
					model.ClassId=int.Parse(row["ClassId"].ToString());
				}
				if(row["SchId"]!=null && row["SchId"].ToString()!="")
				{
					model.SchId=int.Parse(row["SchId"].ToString());
				}
				if(row["CardNo"]!=null)
				{
					model.CardNo=row["CardNo"].ToString();
				}
				if(row["Sex"]!=null && row["Sex"].ToString()!="")
				{
					model.Sex=int.Parse(row["Sex"].ToString());
				}
				if(row["Birth"]!=null && row["Birth"].ToString()!="")
				{
					model.Birth=DateTime.Parse(row["Birth"].ToString());
				}
				if(row["ImgUrl"]!=null)
				{
					model.ImgUrl=row["ImgUrl"].ToString();
				}
				if(row["StudyType"]!=null && row["StudyType"].ToString()!="")
				{
					model.StudyType=int.Parse(row["StudyType"].ToString());
				}
				if(row["Stat"]!=null && row["Stat"].ToString()!="")
				{
					model.Stat=int.Parse(row["Stat"].ToString());
				}
				if(row["LoginTime"]!=null && row["LoginTime"].ToString()!="")
				{
					model.LoginTime=DateTime.Parse(row["LoginTime"].ToString());
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
			strSql.Append("select StuId,LoginName,Pwd,StuName,StuNo,ClassId,SchId,CardNo,Sex,Birth,ImgUrl,StudyType,Stat,LoginTime,RecTime,RecUser,LastRecTime,LastRecUser ");
			strSql.Append(" FROM SchStuInfo ");
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
			strSql.Append(" StuId,LoginName,Pwd,StuName,StuNo,ClassId,SchId,CardNo,Sex,Birth,ImgUrl,StudyType,Stat,LoginTime,RecTime,RecUser,LastRecTime,LastRecUser ");
			strSql.Append(" FROM SchStuInfo ");
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
			strSql.Append("select count(1) FROM SchStuInfo ");
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
            strSql.Append(" FROM SchStuInfo ");
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

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

