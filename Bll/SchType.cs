using System;
using System.Data;
using System.Collections.Generic;
using SchManagerInfoSystem.Common;
using SchSystem.Model;
namespace SchSystem.BLL
{
	/// <summary>
	/// SchType
	/// </summary>
	public partial class SchType
	{
        private readonly SchSystem.DAL.SchType dal = new SchSystem.DAL.SchType();
        public SchType()
		{}
		#region  BasicMethod

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
		public bool Exists(int SchTypeCode,int SchTypeId)
		{
			return dal.Exists(SchTypeCode,SchTypeId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(SchSystem.Model.SchType model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SchSystem.Model.SchType model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int SchTypeId)
		{
			
			return dal.Delete(SchTypeId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int SchTypeCode,int SchTypeId)
		{
			
			return dal.Delete(SchTypeCode,SchTypeId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string SchTypeIdlist )
		{
			return dal.DeleteList(SchTypeIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SchSystem.Model.SchType GetModel(int SchTypeId)
		{
			
			return dal.GetModel(SchTypeId);
		}
        /*
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public SchSystem.Model.SchType GetModelByCache(int SchTypeId)
		{
			
			string CacheKey = "SchTypeModel-" + SchTypeId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SchTypeId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (SchSystem.Model.SchType)objModel;
		}
        */
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
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
		public List<SchSystem.Model.SchType> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SchSystem.Model.SchType> DataTableToList(DataTable dt)
		{
			List<SchSystem.Model.SchType> modelList = new List<SchSystem.Model.SchType>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SchSystem.Model.SchType model;
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

