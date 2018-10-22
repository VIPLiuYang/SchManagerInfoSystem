using System;
using System.Data;
using System.Collections.Generic;
using SchManagerInfoSystem.Common;
using SchSystem.Model;
namespace SchSystem.BLL
{
	/// <summary>
	/// SchStuInfo
	/// </summary>
	public partial class SchStuInfo
	{
        private readonly SchSystem.DAL.SchStuInfo dal = new SchSystem.DAL.SchStuInfo();
        public SchStuInfo()
		{}
        #region  BasicMethod
        public bool ExistsCard(int StuId, string CardNo)
        {
            return dal.ExistsCard(StuId, CardNo);
        }
        public bool UpdateCard(int StuId, string CardNo)
        {
            return dal.UpdateCard(StuId, CardNo);
        }
        public DataSet GetList(string cols, string strWhere)
        {
            return dal.GetList(cols, strWhere);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateStu(SchSystem.Model.SchStuInfo model)
        {
            return dal.UpdateStu(model);
        }
        public int AddStu(SchSystem.Model.SchStuInfo model)
        {
            return dal.AddStu(model);
        }
        public SchSystem.Model.SchStuInfo GetModel(string LoginName)
        {
            return dal.GetModel(LoginName);
        }
        public bool Exists(string LoginName, string Pwd)
        {
            return dal.Exists(LoginName, Pwd);
        }
        public bool ExistsLgname(string LoginName)
        {
            return dal.ExistsLgname(LoginName);
        }
        public bool UpdateIco(int StuId, string ImgUrl)
        {
            return dal.UpdateIco(StuId, ImgUrl);
        }
        public bool UpdatePwd(int StuId, string Pwd)
        {
            return dal.UpdatePwd(StuId, Pwd);
        }
        public bool UpdateLoginName(int StuId, string LoginName)
        {
            return dal.UpdateLoginName(StuId, LoginName);
        }

        public bool ExistsStuCode(int StuId, string StuNo, int SchId)
        {
            return dal.ExistsStuCode(StuId, StuNo, SchId);
        }
        public bool ExistsStuUsername(int StuId, string Username, int SchId)
        {
            return dal.ExistsStuUsername(StuId, Username, SchId);
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
		public bool Exists(int StuId)
		{
			return dal.Exists(StuId);
		}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string strWhere)
        {
            return dal.Exists(strWhere);
        }

		

		/// <summary>
		/// 删除一条数据
		/// </summary>
        //public bool Delete(int StuId)
        //{
			
        //    return dal.Delete(StuId);
        //}
		/// <summary>
		/// 删除一条数据
		/// </summary>
        //public bool DeleteList(string StuIdlist )
        //{
        //    return dal.DeleteList(StuIdlist );
        //}
        /// <summary>
        /// 软删除记录
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public bool DeleteRec(int id)
        {
            return dal.DeleteRec(id);
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SchSystem.Model.SchStuInfo GetModel(int StuId)
		{
			
			return dal.GetModel(StuId);
		}
        /*
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public SchSystem.Model.SchStuInfo GetModelByCache(int StuId)
		{
			
			string CacheKey = "SchStuInfoModel-" + StuId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(StuId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (SchSystem.Model.SchStuInfo)objModel;
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
		public List<SchSystem.Model.SchStuInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SchSystem.Model.SchStuInfo> DataTableToList(DataTable dt)
		{
			List<SchSystem.Model.SchStuInfo> modelList = new List<SchSystem.Model.SchStuInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SchSystem.Model.SchStuInfo model;
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
        /// 分页获取数据列表(GetRecordCount)
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
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod
        public DataSet ExistsStuNo(string StuNo, int SchId)
        {
            return dal.ExistsStuNo(StuNo, SchId);
        }
        public DataSet ExistsStuNoUpdate(string StuNo, int SchId, string currentStuNo)
        {
            return dal.ExistsStuNoUpdate(StuNo, SchId, currentStuNo);
        }
        public DataSet GetStuNoList(string StuNo, int SchId, int StuId)
        {
            return dal.GetStuNoList(StuNo, SchId, StuId);

        }
		#endregion  ExtensionMethod
	}
}

