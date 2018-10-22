using System;
using System.Data;
using System.Collections.Generic;
using SchSystem.Model;
namespace SchSystem.BLL
{
    /// <summary>
    /// WebSchChn
    /// </summary>
    public partial class WebSchChn
    {
        private readonly SchSystem.DAL.WebSchChn dal = new SchSystem.DAL.WebSchChn();
        public WebSchChn()
        { }
        #region  BasicMethod
        public bool UpdateStat(SchSystem.Model.WebSchChn model)
        {
            return dal.UpdateStat(model);
        }
        public DataSet GetList(string cols, string strWhere)
        {
            return dal.GetList(cols, strWhere);
        }
        public DataSet GetListCols(string cols, string strWhere, string ordercols, string orderby, int PageIndex, int PageSize, ref int RowCount, ref int PageCount)
        {
            return dal.GetListCols(cols, strWhere, ordercols, orderby, PageIndex, PageSize, ref RowCount, ref PageCount);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ChnId)
        {
            return dal.Exists(ChnId);
        }
        public bool ExistsChnCode(int ChnId, int ChnCode, int SchId)
        {
            return dal.ExistsChnCode(ChnId, ChnCode, SchId);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SchSystem.Model.WebSchChn model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SchSystem.Model.WebSchChn model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool CUpdate(SchSystem.Model.WebSchChn model)
        {
            return dal.CUpdate(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ChnId)
        {

            return dal.Delete(ChnId);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string ChnIdlist)
        {
            return dal.DeleteList(ChnIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SchSystem.Model.WebSchChn GetModel(int ChnId)
        {

            return dal.GetModel(ChnId);
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SchSystem.Model.WebSchChn> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SchSystem.Model.WebSchChn> DataTableToList(DataTable dt)
        {
            List<SchSystem.Model.WebSchChn> modelList = new List<SchSystem.Model.WebSchChn>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                SchSystem.Model.WebSchChn model;
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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

