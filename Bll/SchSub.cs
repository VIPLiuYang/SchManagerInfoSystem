using System;
using System.Data;
using System.Collections.Generic;
using SchSystem.Model;
namespace SchSystem.BLL
{
    /// <summary>
    /// SchSub
    /// </summary>
    public partial class SchSub
    {
        private readonly SchSystem.DAL.SchSub dal = new SchSystem.DAL.SchSub();
        public SchSub()
        { }
        #region  BasicMethod
     
        public int DoSchSubs(string RecUser, string SchId, string SubIds)
        {
            return dal.DoSchSubs(RecUser, SchId, SubIds);
        }
        public DataSet GetList(string Cols, string strWhere)
        {
            return dal.GetList(Cols, strWhere);
        }
        public DataSet GetSubList(string strWhere)
        {
            return dal.GetSubList(strWhere);
        }
        public DataSet GetSubList(string cols,string strWhere)
        {
            return dal.GetSubList(cols,strWhere);
        }
        public string GetSubNames(string strWhere)
        {
            return dal.GetSubNames(strWhere);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SchSystem.Model.SchSub model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SchSystem.Model.SchSub model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int SubId)
        {

            return dal.Delete(SubId);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string SubIdlist)
        {
            return dal.DeleteList(SubIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SchSystem.Model.SchSub GetModel(int SubId)
        {

            return dal.GetModel(SubId);
        }
        public SchSystem.Model.SchSub GetModelSub(string SubId,string schid)
        {

            return dal.GetModelSub(SubId,schid);
        }
        public SchSystem.Model.SchSub GetModelSubs(string SubId, string schid)
        {

            return dal.GetModelSubs(SubId, schid);
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
        public List<SchSystem.Model.SchSub> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SchSystem.Model.SchSub> DataTableToList(DataTable dt)
        {
            List<SchSystem.Model.SchSub> modelList = new List<SchSystem.Model.SchSub>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                SchSystem.Model.SchSub model;
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

