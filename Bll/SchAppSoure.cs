using System;
using System.Data;
using System.Collections.Generic;
using SchManagerInfoSystem.Common;
using SchSystem.Model;
namespace SchSystem.BLL
{
	/// <summary>
	/// SchAppSoure
	/// </summary>
	public partial class SchAppSoure
	{
        private readonly SchSystem.DAL.SchAppSoure dal = new SchSystem.DAL.SchAppSoure();
		public SchAppSoure()
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
        public int Add(SchSystem.Model.SchAppSoure model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(SchSystem.Model.SchAppSoure model)
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
        //    return dal.DeleteList(SchManagerInfoSystem.Common.PageValidate.SafeLongFilter(AutoIdlist, 0));
        //}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public SchSystem.Model.SchAppSoure GetModel(int AutoId)
		{
			
			return dal.GetModel(AutoId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public SchSystem.Model.SchAppSoure GetModelByCache(int AutoId)
        //{
			
        //    string CacheKey = "SchAppSoureModel-" + AutoId;
        //    object objModel = SchManagerInfoSystem.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(AutoId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = SchManagerInfoSystem.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                SchManagerInfoSystem.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (SchSystem.Model.SchAppSoure)objModel;
        //}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string cols,string strWhere)
		{
			return dal.GetList(cols,strWhere);
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
        public List<SchSystem.Model.SchAppSoure> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList("*",strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<SchSystem.Model.SchAppSoure> DataTableToList(DataTable dt)
		{
            List<SchSystem.Model.SchAppSoure> modelList = new List<SchSystem.Model.SchAppSoure>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                SchSystem.Model.SchAppSoure model;
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
			return GetList("*","");
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

