using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
namespace SchSystem.DAL
{
	/// <summary>
	/// 数据访问类:ServBus
	/// </summary>
	public partial class ServBus
	{
		public ServBus()
		{}
		#region  BasicMethod
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
            strSql.Append(" FROM ServBus  ");
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
		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("BusId", "ServBus"); 
		}
        public string GetFuncNames(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Declare @FuncName nvarchar(500) ");
            strSql.Append("Select @FuncName=ISNULL(@FuncName+',','')+FuncName From ServFunc ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("Select @FuncName as NameCollection ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["NameCollection"].ToString();
            }
            else
            {
                return null;
            }
        }
        public bool ExistsCapNameRepeat(string CapName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ServBus ");
            strSql.Append("  where CapName=@CapName ");
            SqlParameter[] parameters = {
            new SqlParameter("@CapName", SqlDbType.VarChar,30)
                                        };
            parameters[0].Value = CapName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool ExistsCapNameRepeat(int BusId,string CapName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ServBus ");
            strSql.Append("  where BusId<>@BusId  and CapName=@CapName ");
            SqlParameter[] parameters = {
            new SqlParameter("@CapName", SqlDbType.VarChar,30),
            new SqlParameter("@BusId", SqlDbType.Int,4)
                                        };
            parameters[0].Value = CapName;
            parameters[1].Value = BusId; 

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool ExistsCnName(int BusId, string CnName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ServBus ");
            strSql.Append("  where BusId<>@BusId  and CnName=@CnName ");
            SqlParameter[] parameters = {
					new SqlParameter("@CnName", SqlDbType.VarChar,20),
					new SqlParameter("@BusId", SqlDbType.Int,4) };
            parameters[0].Value = CnName;
            parameters[1].Value = BusId; 

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool ExistsServiceId(int BusId, string ServiceId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ServBus ");
            strSql.Append("  where BusId<>@BusId  and ServiceId=@ServiceId ");
            SqlParameter[] parameters = {
					new SqlParameter("@ServiceId", SqlDbType.VarChar,20),
					new SqlParameter("@BusId", SqlDbType.Int,4) };
            parameters[0].Value = ServiceId;
            parameters[1].Value = BusId; 

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int BusId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ServBus");
			strSql.Append(" where BusId=@BusId");
			SqlParameter[] parameters = {
					new SqlParameter("@BusId", SqlDbType.Int,4)
			};
			parameters[0].Value = BusId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CnName"></param>
        /// <param name="BusId"></param>
        ///  <param name="currentCnName">正在修改的名称</param>
        /// <returns></returns>
        public DataSet ExistsCnNameUpdate(string CnName, int BusId, string currentCnName)
        {
            DataSet ds = null;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from ServBus");
                strSql.Append(" where   CnName=@CnName and CnName<>@currentCnName");
                SqlParameter[] parameters = { 
					 
					new SqlParameter("@CnName", SqlDbType.VarChar,15),
                    new SqlParameter("@currentCnName",SqlDbType.VarChar,15)
                                        };
                parameters[0].Value = CnName;
                parameters[1].Value = currentCnName;
                ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            }
            catch (Exception ex)
            {

            }
            return ds;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CnName"></param>
        /// <param name="BusId"></param>
        ///  <param name="currentCnName">正在修改的名称</param>
        /// <returns></returns>
        public DataSet ExistsCodeUpdate(string Code, int BusId, string currentCode)
        {
            DataSet ds = null;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from ServBus");
                strSql.Append(" where   ServiceId=@Code and ServiceId<>@currentCode");
                SqlParameter[] parameters = { 
					 
					new SqlParameter("@Code", SqlDbType.VarChar,15),
                    new SqlParameter("@currentCode",SqlDbType.VarChar,15)
                                        };
                parameters[0].Value = Code;
                parameters[1].Value = currentCode;
                ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            }
            catch (Exception ex)
            {

            }
            return ds;

        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SchSystem.Model.ServBus model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ServBus(");
            strSql.Append("ServiceId,FeeCode,CnName,FuncStr,BusMonth,BusNote,BusType,BusUrl,Note,BusArea,CapName,FrmType)");
			strSql.Append(" values (");
            strSql.Append("@ServiceId,@FeeCode,@CnName,@FuncStr,@BusMonth,@BusNote,@BusType,@BusUrl,@Note,@BusArea,@CapName,@FrmType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ServiceId", SqlDbType.VarChar,20),
					new SqlParameter("@FeeCode", SqlDbType.VarChar,10),
					new SqlParameter("@CnName", SqlDbType.VarChar,30),
					new SqlParameter("@FuncStr", SqlDbType.VarChar,200),
					new SqlParameter("@BusMonth", SqlDbType.Int,4),
					new SqlParameter("@BusNote", SqlDbType.NVarChar,300),
					new SqlParameter("@BusType", SqlDbType.TinyInt,1),
					new SqlParameter("@BusUrl", SqlDbType.VarChar,300),
					new SqlParameter("@Note", SqlDbType.VarChar,100),
                    new SqlParameter("@BusArea", SqlDbType.VarChar,10),
					new SqlParameter("@CapName", SqlDbType.VarChar,30),
                    new SqlParameter("@FrmType", SqlDbType.TinyInt,1)
                                        };
			parameters[0].Value = model.ServiceId;
			parameters[1].Value = model.FeeCode;
			parameters[2].Value = model.CnName;
			parameters[3].Value = model.FuncStr;
			parameters[4].Value = model.BusMonth;
			parameters[5].Value = model.BusNote;
            parameters[6].Value = model.BusType;
            parameters[7].Value = model.BusUrl;
            parameters[8].Value = model.Note;
            parameters[9].Value = model.BusArea;
            parameters[10].Value = model.CapName;
            parameters[11].Value = model.FrmType;

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
		public bool Update(SchSystem.Model.ServBus model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ServBus set ");
			strSql.Append("ServiceId=@ServiceId,");
			strSql.Append("FeeCode=@FeeCode,");
			strSql.Append("CnName=@CnName,");
			strSql.Append("FuncStr=@FuncStr,");
			strSql.Append("BusMonth=@BusMonth,");
			strSql.Append("BusNote=@BusNote,");
			strSql.Append("BusType=@BusType,");
			strSql.Append("BusUrl=@BusUrl,");
			strSql.Append("Note=@Note,");
            strSql.Append("BusArea=@BusArea,");
            strSql.Append("CapName=@CapName,");
            strSql.Append("FrmType=@FrmType");
			strSql.Append(" where BusId=@BusId");
			SqlParameter[] parameters = {
					new SqlParameter("@ServiceId", SqlDbType.VarChar,20),
					new SqlParameter("@FeeCode", SqlDbType.VarChar,10),
					new SqlParameter("@CnName", SqlDbType.VarChar,30),
					new SqlParameter("@FuncStr", SqlDbType.VarChar,200),
					new SqlParameter("@BusMonth", SqlDbType.Int,4),
					new SqlParameter("@BusNote", SqlDbType.NVarChar,300),
					new SqlParameter("@BusType", SqlDbType.TinyInt,1),
					new SqlParameter("@BusUrl", SqlDbType.VarChar,300),
					new SqlParameter("@Note", SqlDbType.VarChar,100),
                    new SqlParameter("@BusArea", SqlDbType.VarChar,10),
					new SqlParameter("@CapName", SqlDbType.VarChar,30),
                    new SqlParameter("@FrmType", SqlDbType.TinyInt,1),
					new SqlParameter("@BusId", SqlDbType.Int,4)};
			parameters[0].Value = model.ServiceId;
			parameters[1].Value = model.FeeCode;
			parameters[2].Value = model.CnName;
			parameters[3].Value = model.FuncStr;
			parameters[4].Value = model.BusMonth;
			parameters[5].Value = model.BusNote;
			parameters[6].Value = model.BusType;
			parameters[7].Value = model.BusUrl;
			parameters[8].Value = model.Note;
            parameters[9].Value = model.BusArea;
            parameters[10].Value = model.CapName;
            parameters[11].Value = model.FrmType;
			parameters[12].Value = model.BusId;

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
		public bool Delete(int BusId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ServBus ");
			strSql.Append(" where BusId=@BusId");
			SqlParameter[] parameters = {
					new SqlParameter("@BusId", SqlDbType.Int,4)
			};
			parameters[0].Value = BusId;

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
		public bool DeleteList(string BusIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ServBus ");
			strSql.Append(" where BusId in ("+BusIdlist + ")  ");
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
		public SchSystem.Model.ServBus GetModel(int BusId)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 BusId,ServiceId,FeeCode,CnName,FuncStr,BusMonth,BusNote,BusType,BusUrl,Note,BusArea,CapName,FrmType from ServBus ");
			strSql.Append(" where BusId=@BusId");
			SqlParameter[] parameters = {
					new SqlParameter("@BusId", SqlDbType.Int,4)
			};
			parameters[0].Value = BusId;

			SchSystem.Model.ServBus model=new SchSystem.Model.ServBus();
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
		public SchSystem.Model.ServBus DataRowToModel(DataRow row)
		{
			SchSystem.Model.ServBus model=new SchSystem.Model.ServBus();
			if (row != null)
			{
				if(row["BusId"]!=null && row["BusId"].ToString()!="")
				{
					model.BusId=int.Parse(row["BusId"].ToString());
				}
				if(row["ServiceId"]!=null)
				{
					model.ServiceId=row["ServiceId"].ToString();
				}
				if(row["FeeCode"]!=null)
				{
					model.FeeCode=row["FeeCode"].ToString();
				}
				if(row["CnName"]!=null)
				{
					model.CnName=row["CnName"].ToString();
				}
				if(row["FuncStr"]!=null)
				{
					model.FuncStr=row["FuncStr"].ToString();
				}
				if(row["BusMonth"]!=null && row["BusMonth"].ToString()!="")
				{
					model.BusMonth=int.Parse(row["BusMonth"].ToString());
				}
				if(row["BusNote"]!=null)
				{
					model.BusNote=row["BusNote"].ToString();
				}
				if(row["BusType"]!=null && row["BusType"].ToString()!="")
				{
					model.BusType=int.Parse(row["BusType"].ToString());
				}
				if(row["BusUrl"]!=null)
				{
					model.BusUrl=row["BusUrl"].ToString();
				}
				if(row["Note"]!=null)
				{
					model.Note=row["Note"].ToString();
				}
                if (row["BusArea"] != null && row["BusArea"].ToString() != "")
                {
                    model.BusArea = row["BusArea"].ToString();
                }
                if (row["CapName"] != null && row["CapName"].ToString() != "")
                {
                    model.CapName = row["CapName"].ToString();
                }
                if (row["FrmType"] != null)
                {
                    model.FrmType = int.Parse(row["FrmType"].ToString());
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
			strSql.Append("select BusId,ServiceId,FeeCode,CnName,FuncStr,BusMonth,BusNote,BusType,BusUrl,Note ");
			strSql.Append(" FROM ServBus ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        public DataSet GetList(string cols, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + cols + " ");
            strSql.Append(" FROM ServBus ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
			strSql.Append(" BusId,ServiceId,FeeCode,CnName,FuncStr,BusMonth,BusNote,BusType,BusUrl,Note ");
			strSql.Append(" FROM ServBus ");
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
			strSql.Append("select count(1) FROM ServBus ");
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
				strSql.Append("order by T.BusId desc");
			}
			strSql.Append(")AS Row, T.*  from ServBus T ");
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
			parameters[0].Value = "ServBus";
			parameters[1].Value = "BusId";
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

