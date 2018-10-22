using System;
using System.Data;
using System.Collections.Generic;
using SchSystem.Model;
namespace SchSystem.BLL
{
	/// <summary>
	/// SchAppRole
	/// </summary>
	public partial class SchAppRole
	{
		private readonly SchSystem.DAL.SchAppRole dal=new SchSystem.DAL.SchAppRole();
		public SchAppRole()
		{}
		#region  BasicMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public string GetAppStr(int schid)
        {
            return dal.GetAppStr(schid);
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
		public bool Exists(int AutoId)
		{
			return dal.Exists(AutoId);
		}
        public bool SchAppExists(int SchId)
        {
            return dal.SchAppExists(SchId);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(SchSystem.Model.SchAppRole model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SchSystem.Model.SchAppRole model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int AutoId)
		{
			
			return dal.Delete(AutoId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
        /*
		public bool DeleteList(string AutoIdlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(AutoIdlist,0) );
		}
        */
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SchSystem.Model.SchAppRole GetModel(int AutoId)
		{
			
			return dal.GetModel(AutoId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
        public SchSystem.Model.SchAppRole GetModelByCache(int AutoId)
		{
			
			string CacheKey = "SchAppRoleModel-" + AutoId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(AutoId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (SchSystem.Model.SchAppRole)objModel;
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
		public List<SchSystem.Model.SchAppRole> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SchSystem.Model.SchAppRole> DataTableToList(DataTable dt)
		{
			List<SchSystem.Model.SchAppRole> modelList = new List<SchSystem.Model.SchAppRole>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SchSystem.Model.SchAppRole model;
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

