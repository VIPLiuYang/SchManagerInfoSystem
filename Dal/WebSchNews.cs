using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SchManagerInfoSystem.Common;
namespace SchSystem.DAL
{
	/// <summary>
	/// 数据访问类:WebSchNews
	/// </summary>
	public partial class WebSchNews
	{
		public WebSchNews()
		{}
		#region  BasicMethod
        public bool UpdateIsTop(int NewsId, int IsTop)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebSchNews set ");
            strSql.Append("IsTop=@IsTop");
            strSql.Append(" where NewsId=@NewsId");
            SqlParameter[] parameters = {
					new SqlParameter("@IsTop", SqlDbType.TinyInt,1),
					new SqlParameter("@NewsId", SqlDbType.Int,4)};
            parameters[0].Value = IsTop;
            parameters[1].Value = NewsId;

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
        public bool Update(int NewsId, int Stat)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebSchNews set ");
            strSql.Append("Stat=@Stat");
            strSql.Append(" where NewsId=@NewsId");
            SqlParameter[] parameters = {
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@NewsId", SqlDbType.Int,4)};
            parameters[0].Value = Stat;
            parameters[1].Value = NewsId;

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
        public bool ExistsChn(int ChnId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from WebSchNews");
            strSql.Append(" where ChnId=@ChnId and Stat<>2");
            SqlParameter[] parameters = {
					new SqlParameter("@ChnId", SqlDbType.Int,4)
			};
            parameters[0].Value = ChnId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public DataSet GetList(string cols, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (cols.Trim() != "")
            {
                strSql.Append(cols);
            }
            strSql.Append(" FROM WebSchNews ");
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
		return DbHelperSQL.GetMaxID("NewsId", "WebSchNews"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int NewsId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WebSchNews");
			strSql.Append(" where NewsId=@NewsId");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsId", SqlDbType.Int,4)
			};
			parameters[0].Value = NewsId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SchSystem.Model.WebSchNews model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WebSchNews(");
            strSql.Append("SchId,ChnId,Topic,SubTopic,Summas,Content,RecUser,RecTname,RecTime,RecIP,Stat,Clicked,IsQuo,QuoUrl,KeyWord,IsReply,ChkUser,ChkTime,ChkIP,ChkTname,IsTop,IsEnc,Imgurl,GradeId,ClassId,Lv)");
			strSql.Append(" values (");
            strSql.Append("@SchId,@ChnId,@Topic,@SubTopic,@Summas,@Content,@RecUser,@RecTname,@RecTime,@RecIP,@Stat,@Clicked,@IsQuo,@QuoUrl,@KeyWord,@IsReply,@ChkUser,@ChkTime,@ChkIP,@ChkTname,@IsTop,@IsEnc,@Imgurl,@GradeId,@ClassId,@Lv)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.VarChar,50),
					new SqlParameter("@ChnId", SqlDbType.Int,4),
					new SqlParameter("@Topic", SqlDbType.VarChar,50),
					new SqlParameter("@SubTopic", SqlDbType.VarChar,50),
					new SqlParameter("@Summas", SqlDbType.VarChar,500),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@RecUser", SqlDbType.VarChar,30),
					new SqlParameter("@RecTname", SqlDbType.VarChar,30),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecIP", SqlDbType.VarChar,20),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@Clicked", SqlDbType.Int,4),
					new SqlParameter("@IsQuo", SqlDbType.TinyInt,1),
					new SqlParameter("@QuoUrl", SqlDbType.VarChar,200),
					new SqlParameter("@KeyWord", SqlDbType.VarChar,200),
					new SqlParameter("@IsReply", SqlDbType.TinyInt,1),
					new SqlParameter("@ChkUser", SqlDbType.VarChar,30),
					new SqlParameter("@ChkTime", SqlDbType.DateTime),
					new SqlParameter("@ChkIP", SqlDbType.VarChar,20),
					new SqlParameter("@ChkTname", SqlDbType.VarChar,30),
					new SqlParameter("@IsTop", SqlDbType.Int,4),
					new SqlParameter("@IsEnc", SqlDbType.TinyInt,1),
					new SqlParameter("@Imgurl", SqlDbType.VarChar,300),
					new SqlParameter("@GradeId", SqlDbType.Int,4),
                    new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@Lv", SqlDbType.TinyInt,1)};
			parameters[0].Value = model.SchId;
			parameters[1].Value = model.ChnId;
			parameters[2].Value = model.Topic;
			parameters[3].Value = model.SubTopic;
			parameters[4].Value = model.Summas;
			parameters[5].Value = model.Content;
			parameters[6].Value = model.RecUser;
			parameters[7].Value = model.RecTname;
			parameters[8].Value = model.RecTime;
			parameters[9].Value = model.RecIP;
			parameters[10].Value = model.Stat;
			parameters[11].Value = model.Clicked;
			parameters[12].Value = model.IsQuo;
			parameters[13].Value = model.QuoUrl;
			parameters[14].Value = model.KeyWord;
			parameters[15].Value = model.IsReply;
			parameters[16].Value = model.ChkUser;
			parameters[17].Value = model.ChkTime;
			parameters[18].Value = model.ChkIP;
			parameters[19].Value = model.ChkTname;
			parameters[20].Value = model.IsTop;
			parameters[21].Value = model.IsEnc;
			parameters[22].Value = model.Imgurl;
            parameters[23].Value = model.GradeId;
            parameters[24].Value = model.ClassId;
			parameters[25].Value = model.Lv;

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
		public bool Update(SchSystem.Model.WebSchNews model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WebSchNews set ");
			strSql.Append("SchId=@SchId,");
			strSql.Append("ChnId=@ChnId,");
			strSql.Append("Topic=@Topic,");
			strSql.Append("SubTopic=@SubTopic,");
			strSql.Append("Summas=@Summas,");
			strSql.Append("Content=@Content,");
			strSql.Append("RecUser=@RecUser,");
			strSql.Append("RecTname=@RecTname,");
			strSql.Append("RecTime=@RecTime,");
			strSql.Append("RecIP=@RecIP,");
			strSql.Append("Stat=@Stat,");
			strSql.Append("Clicked=@Clicked,");
			strSql.Append("IsQuo=@IsQuo,");
			strSql.Append("QuoUrl=@QuoUrl,");
			strSql.Append("KeyWord=@KeyWord,");
			strSql.Append("IsReply=@IsReply,");
			strSql.Append("ChkUser=@ChkUser,");
			strSql.Append("ChkTime=@ChkTime,");
			strSql.Append("ChkIP=@ChkIP,");
			strSql.Append("ChkTname=@ChkTname,");
			strSql.Append("IsTop=@IsTop,");
			strSql.Append("IsEnc=@IsEnc,");
			strSql.Append("Imgurl=@Imgurl,");
            strSql.Append("GradeId=@GradeId,");
            strSql.Append("ClassId=@ClassId,");
			strSql.Append("Lv=@Lv");
			strSql.Append(" where NewsId=@NewsId");
			SqlParameter[] parameters = {
					new SqlParameter("@SchId", SqlDbType.VarChar,50),
					new SqlParameter("@ChnId", SqlDbType.Int,4),
					new SqlParameter("@Topic", SqlDbType.VarChar,50),
					new SqlParameter("@SubTopic", SqlDbType.VarChar,50),
					new SqlParameter("@Summas", SqlDbType.VarChar,500),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@RecUser", SqlDbType.VarChar,30),
					new SqlParameter("@RecTname", SqlDbType.VarChar,30),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecIP", SqlDbType.VarChar,20),
					new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@Clicked", SqlDbType.Int,4),
					new SqlParameter("@IsQuo", SqlDbType.TinyInt,1),
					new SqlParameter("@QuoUrl", SqlDbType.VarChar,200),
					new SqlParameter("@KeyWord", SqlDbType.VarChar,200),
					new SqlParameter("@IsReply", SqlDbType.TinyInt,1),
					new SqlParameter("@ChkUser", SqlDbType.VarChar,30),
					new SqlParameter("@ChkTime", SqlDbType.DateTime),
					new SqlParameter("@ChkIP", SqlDbType.VarChar,20),
					new SqlParameter("@ChkTname", SqlDbType.VarChar,30),
					new SqlParameter("@IsTop", SqlDbType.Int,4),
					new SqlParameter("@IsEnc", SqlDbType.TinyInt,1),
					new SqlParameter("@Imgurl", SqlDbType.VarChar,300),
					new SqlParameter("@GradeId", SqlDbType.Int,4),
                    new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@Lv", SqlDbType.TinyInt,1),
					new SqlParameter("@NewsId", SqlDbType.Int,4)};
			parameters[0].Value = model.SchId;
			parameters[1].Value = model.ChnId;
			parameters[2].Value = model.Topic;
			parameters[3].Value = model.SubTopic;
			parameters[4].Value = model.Summas;
			parameters[5].Value = model.Content;
			parameters[6].Value = model.RecUser;
			parameters[7].Value = model.RecTname;
			parameters[8].Value = model.RecTime;
			parameters[9].Value = model.RecIP;
			parameters[10].Value = model.Stat;
			parameters[11].Value = model.Clicked;
			parameters[12].Value = model.IsQuo;
			parameters[13].Value = model.QuoUrl;
			parameters[14].Value = model.KeyWord;
			parameters[15].Value = model.IsReply;
			parameters[16].Value = model.ChkUser;
			parameters[17].Value = model.ChkTime;
			parameters[18].Value = model.ChkIP;
			parameters[19].Value = model.ChkTname;
			parameters[20].Value = model.IsTop;
			parameters[21].Value = model.IsEnc;
			parameters[22].Value = model.Imgurl;
			parameters[23].Value = model.GradeId;
            parameters[24].Value = model.ClassId;
			parameters[25].Value = model.Lv;
			parameters[26].Value = model.NewsId;

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
		public bool Delete(int NewsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WebSchNews ");
			strSql.Append(" where NewsId=@NewsId");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsId", SqlDbType.Int,4)
			};
			parameters[0].Value = NewsId;

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
        public bool DeleteFalse(int NewsId)
		{

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebSchNews set ");
            strSql.Append("Stat=@Stat");
			strSql.Append(" where NewsId=@NewsId");
			SqlParameter[] parameters = {
                    new SqlParameter("@Stat", SqlDbType.TinyInt,1),
					new SqlParameter("@NewsId", SqlDbType.Int,4)
			};
            parameters[0].Value = 2;
			parameters[1].Value = NewsId;

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
		public bool DeleteList(string NewsIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WebSchNews ");
			strSql.Append(" where NewsId in ("+NewsIdlist + ")  ");
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


        public SchSystem.Model.WebSchNews GetModel(int NewsId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 NewsId,SchId,ChnId,Topic,SubTopic,Summas,Content,RecUser,RecTname,RecTime,RecIP,Stat,Clicked,IsQuo,QuoUrl,KeyWord,IsReply,ChkUser,ChkTime,ChkIP,ChkTname,IsTop,IsEnc,Imgurl,GradeId,ClassId,Lv from WebSchNews ");
            strSql.Append(" where NewsId=@NewsId");
            SqlParameter[] parameters = {
					new SqlParameter("@NewsId", SqlDbType.Int,4)
			};
            parameters[0].Value = NewsId;

            SchSystem.Model.WebSchNews model = new SchSystem.Model.WebSchNews();
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
        /// 得到一个对象实体
        /// </summary>
        public SchSystem.Model.WebSchNews DataRowToModel(DataRow row)
        {
            SchSystem.Model.WebSchNews model = new SchSystem.Model.WebSchNews();
            if (row != null)
            {
                if (row["NewsId"] != null && row["NewsId"].ToString() != "")
                {
                    model.NewsId = int.Parse(row["NewsId"].ToString());
                }
                if (row["SchId"] != null && row["SchId"].ToString() != "")
                {
                    model.SchId = int.Parse(row["SchId"].ToString());
                }
                if (row["ChnId"] != null && row["ChnId"].ToString() != "")
                {
                    model.ChnId = int.Parse(row["ChnId"].ToString());
                }
                if (row["Topic"] != null)
                {
                    model.Topic = row["Topic"].ToString();
                }
                if (row["SubTopic"] != null)
                {
                    model.SubTopic = row["SubTopic"].ToString();
                }
                if (row["Summas"] != null)
                {
                    model.Summas = row["Summas"].ToString();
                }
                if (row["Content"] != null)
                {
                    model.Content = row["Content"].ToString();
                }
                if (row["RecUser"] != null)
                {
                    model.RecUser = row["RecUser"].ToString();
                }
                if (row["RecTname"] != null)
                {
                    model.RecTname = row["RecTname"].ToString();
                }
                if (row["RecTime"] != null && row["RecTime"].ToString() != "")
                {
                    model.RecTime = DateTime.Parse(row["RecTime"].ToString());
                }
                if (row["RecIP"] != null)
                {
                    model.RecIP = row["RecIP"].ToString();
                }
                if (row["Stat"] != null && row["Stat"].ToString() != "")
                {
                    model.Stat = int.Parse(row["Stat"].ToString());
                }
                if (row["Clicked"] != null && row["Clicked"].ToString() != "")
                {
                    model.Clicked = int.Parse(row["Clicked"].ToString());
                }
                if (row["IsQuo"] != null && row["IsQuo"].ToString() != "")
                {
                    model.IsQuo = int.Parse(row["IsQuo"].ToString());
                }
                if (row["QuoUrl"] != null)
                {
                    model.QuoUrl = row["QuoUrl"].ToString();
                }
                if (row["KeyWord"] != null)
                {
                    model.KeyWord = row["KeyWord"].ToString();
                }
                if (row["IsReply"] != null && row["IsReply"].ToString() != "")
                {
                    model.IsReply = int.Parse(row["IsReply"].ToString());
                }
                if (row["ChkUser"] != null)
                {
                    model.ChkUser = row["ChkUser"].ToString();
                }
                if (row["ChkTime"] != null && row["ChkTime"].ToString() != "")
                {
                    model.ChkTime = DateTime.Parse(row["ChkTime"].ToString());
                }
                if (row["ChkIP"] != null)
                {
                    model.ChkIP = row["ChkIP"].ToString();
                }
                if (row["ChkTname"] != null)
                {
                    model.ChkTname = row["ChkTname"].ToString();
                }
                if (row["IsTop"] != null && row["IsTop"].ToString() != "")
                {
                    model.IsTop = int.Parse(row["IsTop"].ToString());
                }
                if (row["IsEnc"] != null && row["IsEnc"].ToString() != "")
                {
                    model.IsEnc = int.Parse(row["IsEnc"].ToString());
                }
                if (row["Imgurl"] != null)
                {
                    model.Imgurl = row["Imgurl"].ToString();
                }
                if (row["GradeId"] != null && row["GradeId"].ToString() != "")
                {
                    model.GradeId = int.Parse(row["GradeId"].ToString());
                }
                if (row["ClassId"] != null && row["ClassId"].ToString() != "")
                {
                    model.ClassId = int.Parse(row["ClassId"].ToString());
                }
                if (row["Lv"] != null && row["Lv"].ToString() != "")
                {
                    model.Lv = int.Parse(row["Lv"].ToString());
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
			strSql.Append("select NewsId,SchId,ChnId,Topic,SubTopic,Summas,Content,RecUser,RecTname,RecTime,RecIP,Stat,Clicked,IsQuo,QuoUrl,KeyWord,IsReply,ChkUser,ChkTime,ChkIP,ChkTname,IsTop,IsEnc,Imgurl,LvId,Lv ");
			strSql.Append(" FROM WebSchNews ");
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
			strSql.Append(" NewsId,SchId,ChnId,Topic,SubTopic,Summas,Content,RecUser,RecTname,RecTime,RecIP,Stat,Clicked,IsQuo,QuoUrl,KeyWord,IsReply,ChkUser,ChkTime,ChkIP,ChkTname,IsTop,IsEnc,Imgurl,LvId,Lv ");
			strSql.Append(" FROM WebSchNews ");
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
			strSql.Append("select count(1) FROM WebSchNews ");
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
				strSql.Append("order by T.NewsId desc");
			}
			strSql.Append(")AS Row, T.*  from WebSchNews T ");
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
            strSql.Append(" FROM WebSchNews  ");
            
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

