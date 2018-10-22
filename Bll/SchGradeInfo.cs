﻿using System;
using System.Data;
using System.Collections.Generic;
using SchManagerInfoSystem.Common;
using SchSystem.Model;
namespace SchSystem.BLL
{
	/// <summary>
	/// SchGradeInfo
	/// </summary>
	public partial class SchGradeInfo
	{
        private readonly SchSystem.DAL.SchGradeInfo dal = new SchSystem.DAL.SchGradeInfo();
        public SchGradeInfo()
		{}
		#region  BasicMethod
        public int GetGradeId(string CollCode, string MajorCode, string GradeCode, int SchId)
        {
            return dal.GetGradeId(CollCode, MajorCode, GradeCode, SchId);
        }
        public bool ExistsUnvGrade(int GradeId, string CollCode, string MajorCode, string GradeCode, int SchId)
        {
            return dal.ExistsUnvGrade(GradeId, CollCode, MajorCode, GradeCode, SchId);
        }
        public int AddUnv(SchSystem.Model.SchGradeInfo model)
        {
            return dal.AddUnv(model);
        }
        public bool UpdateUnv(SchSystem.Model.SchGradeInfo model)
        {
            return dal.UpdateUnv(model);
        }
        public string GetName(int GradeId)
        {
            return dal.GetName(GradeId);
        }
        public DataSet GetListGradeFinish(string cols, int SchId, int GradeYear)
        {
            return dal.GetListGradeFinish(cols, SchId, GradeYear);
        }
        public bool ExistsGradeFinish(int SchId, int GradeYear)
        {
            return dal.ExistsGradeFinish(SchId, GradeYear);
        }
        public DataSet Graduated(int schid)
        {
            return dal.Graduated(schid);
        }
        public bool UpdateGrade(string GradeYear, string GradeCode, int SchId, int IsFinish)
        {
            return dal.UpdateGrade(GradeYear, GradeCode, SchId, IsFinish);
        }
        public bool UpdateStat(SchSystem.Model.SchGradeInfo model)
        {
            return dal.UpdateStat(model);
        }
        public int DoSchGrades(string RecUser, string SchId, string GradeIds)
        {
            return dal.DoSchGrades(RecUser, SchId, GradeIds);
        }
        public int DoSchGradess(string RecUser, string SchId, string GradeIds)
        {
            return dal.DoSchGradess(RecUser, SchId, GradeIds);
        }
        /// <summary>
        /// 函数功能：同一所学校，不能出现两个完全一样的年级
        /// </summary>
        /// <param name="GradeId"></param>
        /// <param name="GradeCode"></param>
        /// <param name="SchId"></param>
        /// <returns></returns>
        public bool ExistsGradeCode(int GradeId, string GradeCode, int SchId)
        {
            return dal.ExistsGradeCode(GradeId, GradeCode, SchId);
        }
        public bool ExistsGradeCode(string GradeCode, int SchId,string statType="yes")
        {
            return dal.ExistsGradeCode(GradeCode, SchId,statType);
        }
		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}
        public string GetGradedYear(string strWhere)
        {
            return dal.GetGradedYear(strWhere);
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int GradeId)
		{
			return dal.Exists(GradeId);
		}
        /// <summary>
        /// 支持系统添加年级
        /// </summary>
        /// <param name="schid"></param>
        /// <returns></returns>
        public int SupportSysSchGradeAdd(int schid)
        {
            return dal.SupportSysSchGradeAdd(schid);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(SchSystem.Model.SchGradeInfo model)
		{
			return dal.Add(model);
		}
        public int AddLackGrade(int gradecode, int gradeyear, int schid,string gradename)
        {
            return dal.AddLackGrade(gradecode,gradeyear,schid,gradename);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SchSystem.Model.SchGradeInfo model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateGrade(SchSystem.Model.SchGradeInfo model)
        {
            return dal.UpdateGrade(model);
        }
        /// <summary>
        /// 更新一条数据:修改字段（GradeCode、GradeName、IsFinish）条件（GradeId、SchId）
        /// </summary>
        public bool UpdateGrades(SchSystem.Model.SchGradeInfo model)
        {
            return dal.UpdateGrades(model);
        }
        public int SchGradeUpdate(string id)
        {
            return dal.SchGradeUpdate(id);
        }
        /// <summary>
        /// 更新一条数据:更新状态
        /// </summary>
        public bool UpdateGradeStat(SchSystem.Model.SchGradeInfo model, string statType = "gradeid")
        {
            return dal.UpdateGradeStat(model, statType);
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int GradeId)
		{
			
			return dal.Delete(GradeId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string GradeIdlist )
		{
			return dal.DeleteList(GradeIdlist );
		}
        /// <summary>
        /// 软删除记录
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public bool DeleteRec(int GradeId)
        {
            return dal.DeleteRec(GradeId);
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SchSystem.Model.SchGradeInfo GetModel(int GradeId)
		{
			
			return dal.GetModel(GradeId);
		}
        /*
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public SchSystem.Model.SchGradeInfo GetModelByCache(int GradeId)
		{
			
			string CacheKey = "SchGradeInfoModel-" + GradeId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(GradeId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (SchSystem.Model.SchGradeInfo)objModel;
		}
        */
        public DataSet GetList(string cols, string strWhere)
        {
            return dal.GetList(cols, strWhere);
        }
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
		public List<SchSystem.Model.SchGradeInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SchSystem.Model.SchGradeInfo> DataTableToList(DataTable dt)
		{
			List<SchSystem.Model.SchGradeInfo> modelList = new List<SchSystem.Model.SchGradeInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SchSystem.Model.SchGradeInfo model;
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

