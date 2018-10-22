using System;
using System.Data;
using System.Collections.Generic;
using SchSystem.Model;
namespace SchSystem.BLL
{
    /// <summary>
    /// WebSchNewsEnc
    /// </summary>
    public partial class WebSchNewsEnc
    {
        private readonly SchSystem.DAL.WebSchNewsEnc dal = new SchSystem.DAL.WebSchNewsEnc();
        public WebSchNewsEnc()
        { }
        #region  BasicMethod
        public DataSet GetList(string cols, string strWhere)
        {
            return dal.GetList(cols, strWhere);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int EncId)
        {
            return dal.Exists(EncId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SchSystem.Model.WebSchNewsEnc model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SchSystem.Model.WebSchNewsEnc model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int EncId)
        {

            return dal.Delete(EncId);
        }
        public bool DeleteNewsEnc(int NewsId)
        {

            return dal.DeleteNewsEnc(NewsId);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string EncIdlist)
        {
            return dal.DeleteList(EncIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SchSystem.Model.WebSchNewsEnc GetModel(int EncId)
        {

            return dal.GetModel(EncId);
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
        public List<SchSystem.Model.WebSchNewsEnc> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SchSystem.Model.WebSchNewsEnc> DataTableToList(DataTable dt)
        {
            List<SchSystem.Model.WebSchNewsEnc> modelList = new List<SchSystem.Model.WebSchNewsEnc>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                SchSystem.Model.WebSchNewsEnc model;
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
        /// 批量插入数据
        /// </summary>
        /// <param name="table">需要插入的数据</param>
        /// <param name="TableName">表名称</param>
        public string ExecuteSqlBulkCopy(DataTable table, string TableName)
        {
            string result = dal.ExecuteSqlBulkCopy(table, TableName);
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

