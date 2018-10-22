using System;
using System.Data;
using System.Collections.Generic;
using SchSystem.Model;
namespace SchSystem.BLL
{
	/// <summary>
	/// 1
	/// </summary>
	public partial class WebSchNews
	{
		private readonly SchSystem.DAL.WebSchNews dal=new SchSystem.DAL.WebSchNews();
		public WebSchNews()
		{}
		#region  BasicMethod
        public bool UpdateIsTop(int NewsId, int IsTop)
        {
            return dal.UpdateIsTop(NewsId, IsTop);
        }
        public bool Update(int NewsId, int Stat)
        {
            return dal.Update(NewsId, Stat);
        }
        public bool ExistsChn(int ChnId)
        {
            return dal.ExistsChn(ChnId);
        }
        public DataSet GetList(string cols, string strWhere)
        {
            return dal.GetList(cols, strWhere);
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
		public bool Exists(int NewsId)
		{
			return dal.Exists(NewsId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(SchSystem.Model.WebSchNews model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SchSystem.Model.WebSchNews model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int NewsId)
		{
			
			return dal.Delete(NewsId);
		}
        public bool DeleteFalse(int NewsId)
        {

            return dal.DeleteFalse(NewsId);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SchSystem.Model.WebSchNews GetModel(int NewsId)
		{
			
			return dal.GetModel(NewsId);
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
		public List<SchSystem.Model.WebSchNews> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SchSystem.Model.WebSchNews> DataTableToList(DataTable dt)
		{
			List<SchSystem.Model.WebSchNews> modelList = new List<SchSystem.Model.WebSchNews>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SchSystem.Model.WebSchNews model;
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
        public DataSet GetListCols(string cols, string strWhere, string ordercols, string orderby, int PageIndex, int PageSize, ref int RowCount, ref int PageCount)
        {
            return dal.GetListCols(cols, strWhere, ordercols, orderby, PageIndex, PageSize, ref RowCount, ref PageCount);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

