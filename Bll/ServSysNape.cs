﻿
using System;
using System.Data;
using System.Collections.Generic;
using System.Collections.Generic;
using SchSystem.Model;
namespace SchSystem.BLL
{
	/// <summary>
	/// ServSysNape
	/// </summary>
	public partial class ServSysNape
	{
		private readonly SchSystem.DAL.ServSysNape dal=new SchSystem.DAL.ServSysNape();
		public ServSysNape()
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
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AutoId)
		{
			return dal.Exists(AutoId);
		}
        public DataSet GetList(string cols, string strWhere)
        {
            return dal.GetList(cols, strWhere);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(SchSystem.Model.ServSysNape model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SchSystem.Model.ServSysNape model)
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
		public bool DeleteList(string AutoIdlist )
		{
			return dal.DeleteList(AutoIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SchSystem.Model.ServSysNape GetModel(int AutoId)
		{
			
			return dal.GetModel(AutoId);
		}

        ///// <summary>
        ///// 得到一个对象实体，从缓存中
        ///// </summary>
        //public SchSystem.Model.ServSysNape GetModelByCache(int AutoId)
        //{
			
        //    string CacheKey = "ServSysNapeModel-" + AutoId;
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
        //    return (SchSystem.Model.ServSysNape)objModel;
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
		public List<SchSystem.Model.ServSysNape> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SchSystem.Model.ServSysNape> DataTableToList(DataTable dt)
		{
			List<SchSystem.Model.ServSysNape> modelList = new List<SchSystem.Model.ServSysNape>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SchSystem.Model.ServSysNape model;
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

