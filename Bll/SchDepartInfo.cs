using System;
using System.Data;
using System.Collections.Generic;
using SchManagerInfoSystem.Common;
using SchSystem.Model;
namespace SchSystem.BLL
{
	/// <summary>
	/// SchDepartInfo
	/// </summary>
	public partial class SchDepartInfo
	{
        private readonly SchSystem.DAL.SchDepartInfo dal = new SchSystem.DAL.SchDepartInfo();
        public SchDepartInfo()
		{}
		#region  BasicMethod
        public bool ExistsPid(int Pid)
        {
            return dal.ExistsPid(Pid);
        }
        public bool ExistsUser(int DeptId)
        {
            return dal.ExistsUser(DeptId);
        }

        public bool UpdateStat(SchSystem.Model.SchDepartInfo model)
        {
            return dal.UpdateStat(model);
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
		public bool Exists(int DepartId)
		{
			return dal.Exists(DepartId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(SchSystem.Model.SchDepartInfo model)
		{
			return dal.Add(model);
		}
        public bool ChangeOrderBy(SchSystem.Model.SchDepartInfo model)
        {
            return dal.ChangeOrderBy(model);
        }
        public int ChangeOrderBy(string id, string ordertype)
        {
            return dal.ChangeOrderBy(id,ordertype);
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SchSystem.Model.SchDepartInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int DepartId)
		{
			
			return dal.Delete(DepartId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string DepartIdlist )
		{
			return dal.DeleteList(DepartIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SchSystem.Model.SchDepartInfo GetModel(int DepartId)
		{
			
			return dal.GetModel(DepartId);
		}
        /*
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public SchSystem.Model.SchDepartInfo GetModelByCache(int DepartId)
		{
			
			string CacheKey = "SchDepartInfoModel-" + DepartId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(DepartId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (SchSystem.Model.SchDepartInfo)objModel;
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
		public List<SchSystem.Model.SchDepartInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SchSystem.Model.SchDepartInfo> DataTableToList(DataTable dt)
		{
			List<SchSystem.Model.SchDepartInfo> modelList = new List<SchSystem.Model.SchDepartInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SchSystem.Model.SchDepartInfo model;
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
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            return dal.GetList(PageSize, PageIndex, strWhere);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

