using System;
using System.Data;
using System.Collections.Generic;
using SchSystem.Model;
namespace SchSystem.BLL
{
    /// <summary>
    /// ServFuncExt
    /// </summary>
    public partial class ServFuncExt
    {
        private readonly SchSystem.DAL.ServFuncExt dal = new SchSystem.DAL.ServFuncExt();
        public ServFuncExt()
        { }
        #region  BasicMethod
        public DataSet GetListItemV(string cols, string strWhere)
        {
            return dal.GetListItemV(cols, strWhere);
        }
        public DataSet GetList(string cols, string strWhere)
        {
            return dal.GetList(cols, strWhere);
        }
        public DataSet GetListV(string cols, string strWhere)
        {
            return dal.GetListV(cols, strWhere);
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
        public int Add(SchSystem.Model.ServFuncExt model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SchSystem.Model.ServFuncExt model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int FuncId)
        {

            return dal.Delete(FuncId);
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
        public SchSystem.Model.ServFuncExt GetModel(int AutoId)
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
        public List<SchSystem.Model.ServFuncExt> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SchSystem.Model.ServFuncExt> DataTableToList(DataTable dt)
        {
            List<SchSystem.Model.ServFuncExt> modelList = new List<SchSystem.Model.ServFuncExt>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                SchSystem.Model.ServFuncExt model;
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
        public string ExecuteSqlBulkCopy(DataTable table, string TableName)
        {
            string result =  dal.ExecuteSqlBulkCopy(table, TableName);
            if (result == "0")
            {
                result = "操作失败";
            }
            else if (result == "1")
            {
                result = "操作成功";
            }
            return result;
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

