using System;
using System.Data;
using System.Collections.Generic;
using SchSystem.Model;

namespace SchSystem.BLL
{
	/// <summary>
	/// ServUserFor
	/// </summary>
	public partial class ServUserFor
	{
		private readonly SchSystem.DAL.ServUserFor dal=new SchSystem.DAL.ServUserFor();
		public ServUserFor()
		{}
		#region  BasicMethod
        public bool Exists(string UserName, string ServiceId)
        {
            return dal.Exists(UserName, ServiceId);
        }
        public int UserRefee(string uid, string servid, int servm, int feem, string dnote, string recutname, string frmtype)
        {
            return dal.UserRefee(uid, servid, servm, feem, dnote, recutname, frmtype);
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

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(SchSystem.Model.ServUserFor model)
		{
			return dal.Add(model);
		}
        public int ProcAdd(string UserName, string RecUser, string FromType, string ServiceId, int ServMonth, int FeeM,string donote)
        {
            return dal.ProcAdd(UserName, RecUser, FromType, ServiceId, ServMonth, FeeM, donote);
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SchSystem.Model.ServUserFor model)
		{
			return dal.Update(model);
		}
        /// <summary>
        /// 续费
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateRenewals(SchSystem.Model.ServUserFor model)
        {
            return dal.UpdateRenewals(model);
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
		public SchSystem.Model.ServUserFor GetModel(int AutoId)
		{
			
			return dal.GetModel(AutoId);
		}
        public SchSystem.Model.ServUserForV GetModelV(string cols,int AutoId)
        {

            return dal.GetModelV(cols,AutoId);
        }
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public SchSystem.Model.ServUserFor GetModelByCache(int AutoId)
        //{
			
        //    string CacheKey = "ServUserForModel-" + AutoId;
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
        //    return (SchSystem.Model.ServUserFor)objModel;
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
		public List<SchSystem.Model.ServUserFor> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SchSystem.Model.ServUserFor> DataTableToList(DataTable dt)
		{
			List<SchSystem.Model.ServUserFor> modelList = new List<SchSystem.Model.ServUserFor>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SchSystem.Model.ServUserFor model;
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
        public DataSet GetListColsV(string cols, string strWhere, string ordercols, string orderby, int PageIndex, int PageSize, ref int RowCount, ref int PageCount)
        {
            return dal.GetListColsV(cols, strWhere, ordercols, orderby, PageIndex, PageSize, ref RowCount, ref PageCount);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

