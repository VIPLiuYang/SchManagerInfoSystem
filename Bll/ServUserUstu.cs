using System;
using System.Data;
using System.Collections.Generic;
using SchSystem.Model;
namespace SchSystem.BLL
{
    /// <summary>
    /// ServUserUstu
    /// </summary>
    public partial class ServUserUstu
    {
        private readonly SchSystem.DAL.ServUserUstu dal = new SchSystem.DAL.ServUserUstu();
        public ServUserUstu()
        { }
        #region  BasicMethod
        public bool Update(int ForId, int StuId)
        {
            return dal.Update(ForId, StuId);
        }
        public bool ExistsFor(int ForId)
        {
            return dal.ExistsFor(ForId);
        }
        public bool Exists(int StuId, int ForId)
        {
            return dal.Exists(StuId, ForId);
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
        public int Add(SchSystem.Model.ServUserUstu model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SchSystem.Model.ServUserUstu model)
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
        public bool DeleteList(string AutoIdlist)
        {
            return dal.DeleteList(AutoIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SchSystem.Model.ServUserUstu GetModel(int AutoId)
        {

            return dal.GetModel(AutoId);
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
        public List<SchSystem.Model.ServUserUstu> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SchSystem.Model.ServUserUstu> DataTableToList(DataTable dt)
        {
            List<SchSystem.Model.ServUserUstu> modelList = new List<SchSystem.Model.ServUserUstu>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                SchSystem.Model.ServUserUstu model;
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

