using System;
using System.Data;
using System.Collections.Generic;
using SchSystem.Model;
namespace SchSystem.BLL
{
    /// <summary>
    /// SchGradeUsers
    /// </summary>
    public partial class SchGradeUsers
    {
        private readonly SchSystem.DAL.SchGradeUsers dal = new SchSystem.DAL.SchGradeUsers();
        public SchGradeUsers()
        { }
        #region  BasicMethod
        //年级主任
        public bool ExistsGrade(string GradeId, string SchId, string usertid)
        {
            return dal.ExistsGrade(GradeId, SchId, usertid);
        }
        public bool ExistsGrade(string SchId, string usertid)
        {
            return dal.ExistsGrade(SchId, usertid);
        }
        public int DoUserGrade(string GradeId, string RecUser, string SchId, string UserIds)
        {
            return dal.DoUserGrade(GradeId, RecUser, SchId, UserIds);
        }
        public string GetNames(string strWhere)
        {
            return dal.GetNames(strWhere);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SchSystem.Model.SchGradeUsers model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SchSystem.Model.SchGradeUsers model)
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
        public SchSystem.Model.SchGradeUsers GetModel(int AutoId)
        {

            return dal.GetModel(AutoId);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string cols, string Where)
        {
            return dal.GetList(cols, Where);
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
        public List<SchSystem.Model.SchGradeUsers> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList("*",strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SchSystem.Model.SchGradeUsers> DataTableToList(DataTable dt)
        {
            List<SchSystem.Model.SchGradeUsers> modelList = new List<SchSystem.Model.SchGradeUsers>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                SchSystem.Model.SchGradeUsers model;
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
        /// <summary>
        /// 判断老师是否在年级领导中设置
        /// </summary>
        /// <param name="SchId"></param>
        /// <param name="GradeCode"></param>
        /// <returns></returns>
        public bool ExistsGradeUser(string SchId,string UserId)
        {
            return dal.ExistsGradeUser(SchId,UserId);
        }
        #endregion  ExtensionMethod
    }
}

