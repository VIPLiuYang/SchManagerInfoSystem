using System;
using System.Data;
using System.Collections.Generic;
using SchSystem.Model;
namespace SchSystem.BLL
{
	/// <summary>
	/// SchSubLeader
	/// </summary>
	public partial class SchSubLeader
	{
		private readonly SchSystem.DAL.SchSubLeader dal=new SchSystem.DAL.SchSubLeader();
		public SchSubLeader()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}
        public int DoUserSubLeader(string GradeId, string RecUser, string SchId, string UserIds)
        {
            return dal.DoUserSubLeader(GradeId, RecUser, SchId, UserIds);
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AutoId)
		{
			return dal.Exists(AutoId);
		}
        public bool ExistsClassSubUser(string SchId, string SubCode)
        {
            return dal.ExistsClassSubUser(SchId, SubCode);
        }
        public bool ExistsClassSubLeader(string SchId, string UserId)
        {
            return dal.ExistsClassSubLeader(SchId, UserId);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(SchSystem.Model.SchSubLeader model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SchSystem.Model.SchSubLeader model)
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

        public DataSet GetListTecSub(string cols, string strWhere)
        {
            return dal.GetListTecSub(cols, strWhere);
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SchSystem.Model.SchSubLeader GetModel(int AutoId)
		{
			
			return dal.GetModel(AutoId);
		}


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
		public List<SchSystem.Model.SchSubLeader> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList("*",strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SchSystem.Model.SchSubLeader> DataTableToList(DataTable dt)
		{
			List<SchSystem.Model.SchSubLeader> modelList = new List<SchSystem.Model.SchSubLeader>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SchSystem.Model.SchSubLeader model;
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
        public DataSet GetListV(string cols, string strWhere)
        {
            return dal.GetListV(cols, strWhere);
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

