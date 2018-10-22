using System;
using System.Data;
using System.Collections.Generic;
using SchWebAdmin.Model;
namespace SchWebAdmin.BLL
{
	/// <summary>
	/// SchHomePerSubMat
	/// </summary>
	public partial class SchHomePerSubMat
	{
		private readonly SchWebAdmin.DAL.SchHomePerSubMat dal=new SchWebAdmin.DAL.SchHomePerSubMat();
		public SchHomePerSubMat()
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
		public bool Exists(int AutoId)
		{
			return dal.Exists(AutoId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(SchWebAdmin.Model.SchHomePerSubMat model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SchWebAdmin.Model.SchHomePerSubMat model)
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
        //public bool DeleteList(string AutoIdlist )
        //{
        //    return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(AutoIdlist,0) );
        //}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SchWebAdmin.Model.SchHomePerSubMat GetModel(int AutoId)
		{
			
			return dal.GetModel(AutoId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public SchWebAdmin.Model.SchHomePerSubMat GetModelByCache(int AutoId)
        //{
			
        //    string CacheKey = "SchHomePerSubMatModel-" + AutoId;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(AutoId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (SchWebAdmin.Model.SchHomePerSubMat)objModel;
        //}

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
		public List<SchWebAdmin.Model.SchHomePerSubMat> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SchWebAdmin.Model.SchHomePerSubMat> DataTableToList(DataTable dt)
		{
			List<SchWebAdmin.Model.SchHomePerSubMat> modelList = new List<SchWebAdmin.Model.SchHomePerSubMat>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SchWebAdmin.Model.SchHomePerSubMat model;
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

