using System;
using System.Data;
using System.Collections.Generic;
using SchManagerInfoSystem.Common;
using SchSystem.Model;
namespace SchSystem.BLL
{
	/// <summary>
	/// SchClassInfo
	/// </summary>
	public partial class SchClassInfo
	{
        private readonly SchSystem.DAL.SchClassInfo dal = new SchSystem.DAL.SchClassInfo();
        public SchClassInfo()
		{}
		#region  BasicMethod
        public int GetClassId(string ClassNo, int GradeId, int SchId)
        {

            return dal.GetClassId(ClassNo, GradeId, SchId);
        }
        public bool UpdateUnv(SchSystem.Model.SchClassInfo model)
        {
            return dal.UpdateUnv(model);
        }
        public bool ExistsClass(int ClassId,string ClassNo, int GradeId, int SchId)
        {
            return dal.ExistsClass(ClassId,ClassNo, GradeId, SchId);
        }
        public string GetName(int ClassId)
        {
            return dal.GetName(ClassId);
        }
        public bool ExistsPerClass(string PerCode, int SchId)
        {
            return dal.ExistsPerClass(PerCode, SchId);
        }
        public bool UpdateStat(SchSystem.Model.SchClassInfo model)
        {
            return dal.UpdateStat(model);
        }
        public string GetIds(string strWhere)
        {
            return dal.GetIds(strWhere);
        }
        public string GetClassNames(string strWhere)
        {
            return dal.GetClassNames(strWhere);
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
		public bool Exists(int ClassId)
		{
			return dal.Exists(ClassId);
		}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public DataSet Exists(string schid, int GradeId, string classname)
        {
            return dal.Exists(schid, GradeId, classname);
        }
        /// <summary>
        /// 班级里面是否存在学生
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public bool ExistsClassStuData(int ClassId)
        {
            return dal.ExistsClassStuData(ClassId);
        }
        /// <summary>
        /// 判断年级下面是否有班级数据
        /// </summary>
        /// <param name="SchId"></param>
        /// <param name="GradeCode"></param>
        /// <returns></returns>
        public bool ExistsClassData(string SchId, string GradeCode)
        {
            return dal.ExistsClassData(SchId, GradeCode);
        }
        /// <summary>
        /// 判断学段下面是否有班级
        /// </summary>
        /// <param name="SchId"></param>
        /// <param name="PerCode"></param>
        /// <returns></returns>
        public bool ExistsClassData(int SchId, int PerCode)
        {
            return dal.ExistsClassData(SchId, PerCode);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(SchSystem.Model.SchClassInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SchSystem.Model.SchClassInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ClassId)
		{
			
			return dal.Delete(ClassId);
		}
        /// <summary>
        /// 软删除记录
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public bool DeleteRec(int ClassId)
        {
            return dal.DeleteRec(ClassId);
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ClassIdlist )
		{
			return dal.DeleteList(ClassIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SchSystem.Model.SchClassInfo GetModel(int ClassId)
		{
			
			return dal.GetModel(ClassId);
		}
        /*
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public SchSystem.Model.SchClassInfo GetModelByCache(int ClassId)
		{
			
			string CacheKey = "SchClassInfoModel-" + ClassId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ClassId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (SchSystem.Model.SchClassInfo)objModel;
		}
        */
        public DataSet GetList(string cols, string strWhere)
        {
            return dal.GetList(cols, strWhere);
        }
        public DataSet GetList(string cols, string strWhere,int n)
        {
            return dal.GetList(cols, strWhere,n);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListV(string strWhere)
        {
            return dal.GetListV(strWhere);
        }
        public DataSet GetListV(string cols, string strWhere)
        {
            return dal.GetListV(cols,strWhere);
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
		public List<SchSystem.Model.SchClassInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SchSystem.Model.SchClassInfo> DataTableToList(DataTable dt)
		{
			List<SchSystem.Model.SchClassInfo> modelList = new List<SchSystem.Model.SchClassInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SchSystem.Model.SchClassInfo model;
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
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

