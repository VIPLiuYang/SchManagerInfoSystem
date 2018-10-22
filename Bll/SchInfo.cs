using System;
using System.Data;
using System.Collections.Generic;
using SchManagerInfoSystem.Common;
using SchSystem.Model;
namespace SchSystem.BLL
{
	/// <summary>
	/// SchInfo：学校信息BLL
	/// </summary>
	public partial class SchInfo
	{
        private readonly SchSystem.DAL.SchInfo dal = new SchSystem.DAL.SchInfo();
        public SchInfo()
		{}
		#region  BasicMethod
        public bool Exists(int SchId, int Stat)
        {
            return dal.Exists(SchId, Stat);
        }
        public string GetSchName(int SchId)
        {
            return dal.GetSchName(SchId);
        }
        public bool UpdateStat(SchSystem.Model.SchInfo model)
        {
            return dal.UpdateStat(model);
        }
        public bool UpdateAlone(SchSystem.Model.SchInfo model)
        {
            return dal.UpdateAlone(model);
        }
		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SchId)
		{
			return dal.Exists(SchId);
		}
        /// <summary>
        /// 支撑系统添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SchAdd(SchSystem.Model.SchInfo model)
        {
            return dal.SchAdd(model);
        }
        public bool SchAddXXT(SchSystem.Model.SchInfo model)
        {
            return dal.SchAddXXT(model);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SchSystem.Model.SchInfo model)
		{
			return dal.Add(model);
		}
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int InsertSchAccount(int schid, string managerAccount, string password,string SchMaster)
        {
            return dal.InsertSchAccount(schid, managerAccount, password, SchMaster);
        }
        /// <summary>
        /// 修改管理员账号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateSch(SchSystem.Model.SchInfo model)
        {
            return dal.UpdateSch(model);
        }
        public bool UpdateSchXXT(SchSystem.Model.SchInfo model)
        {
            return dal.UpdateSchXXT(model);
        }
        public bool UpdateSonSysOpen(int schid, DateTime sonsysendtime, string StatNote)
        {
            return dal.UpdateSonSysOpen(schid, sonsysendtime, StatNote);
        }
        public bool UpdateSonSysClose(int schid, string StatNote)
        {
            return dal.UpdateSonSysClose(schid, StatNote);
        }
        public bool UpdateSoureSysOpen(int schid, DateTime sonsysendtime, string StatNote)
        {
            return dal.UpdateSoureSysOpen(schid, sonsysendtime, StatNote);
        }
        public bool UpdateSoureSysClose(int schid, string StatNote)
        {
            return dal.UpdateSoureSysClose(schid, StatNote);
        }
        //更新家校互通平台状态
        public bool UpdateSchXXTOpen(int schid, DateTime sonsysendtime, string StatNote)
        {
            return dal.UpdateSchXXTOpen(schid, sonsysendtime, StatNote);
        }
        public bool UpdateSchXXTClose(int schid, string StatNote)
        {
            return dal.UpdateSchXXTClose(schid, StatNote);
        }
        //家校互通基础数据维护人
        public bool UpdateSchXXTServStat(int schid, int ServStat)
        {
            return dal.UpdateSchXXTServStat(schid, ServStat);
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SchSystem.Model.SchInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int SchId)
		{
			
			return dal.Delete(SchId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string SchIdlist )
		{
			return dal.DeleteList(SchIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SchSystem.Model.SchInfo GetModel(int SchId)
		{
			
			return dal.GetModel(SchId);
		}
        /*
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public SchSystem.Model.SchInfo GetModelByCache(int SchId)
		{
			
			string CacheKey = "SchInfoModel-" + SchId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SchId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (SchSystem.Model.SchInfo)objModel;
		}
        */
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        public DataSet GetList(string Cols, string strWhere)
        {
            return dal.GetList(Cols, strWhere);
        }
        public DataSet GetSchList(string strWhere)
        {
            return dal.GetSchList(strWhere);
        
        }
        public DataSet GetStat(string strWhere)
        {
            return dal.GetStat(strWhere);
        }
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SchSystem.Model.SchInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
        /// <summary>
        /// 支撑系统使用
        /// </summary>
        /// <param name="SchId"></param>
        /// <returns></returns>
        public SchSystem.Model.SchInfo GetSupportModel(int SchId)
        {
            return dal.GetSupportModel(SchId);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SchSystem.Model.SchInfo> DataTableToList(DataTable dt)
		{
			List<SchSystem.Model.SchInfo> modelList = new List<SchSystem.Model.SchInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SchSystem.Model.SchInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
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
            return dal.GetListCols(cols, strWhere, ordercols, orderby, PageIndex, PageSize, ref RowCount, ref PageCount);
        }
        public DataSet GetListColsV(string cols, string strWhere, string ordercols, string orderby, int PageIndex, int PageSize, ref int RowCount, ref int PageCount)
        {
            return dal.GetListColsV(cols, strWhere, ordercols, orderby, PageIndex, PageSize, ref RowCount, ref PageCount);
        }
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

