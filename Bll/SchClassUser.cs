using System;
using System.Data;
using System.Collections.Generic;
using SchSystem.Model;
namespace SchSystem.BLL
{
    /// <summary>
    /// SchClassUser
    /// </summary>
    public partial class SchClassUser
    {
        private readonly SchSystem.DAL.SchClassUser dal = new SchSystem.DAL.SchClassUser();
        public SchClassUser()
        { }
        #region  BasicMethod
        //班主任和任课老师
        public bool ExistsIsMs(string ClassId, string usertid, string SchId, int IsMs)
        {
            return dal.ExistsIsMs(ClassId, usertid, SchId, IsMs);
        }
        public bool ExistsIsMs(string usertid, string SchId, int IsMs)
        {
            return dal.ExistsIsMs(usertid, SchId,IsMs);
        }
        public bool ExistsV(int IsFinish, int Stat, string UserName, int IsMs)
        {
            return dal.ExistsV(IsFinish, Stat, UserName, IsMs);
        }
        public bool DeleteUserSub(string strwhere)
        {
            return dal.DeleteUserSub(strwhere);
        }
        public string GetNames(string strWhere)
        {
            return dal.GetNames(strWhere);
        }
        public DataSet getGradeClassName(string wherestr)
        {
            return dal.getGradeClassName(wherestr);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SchSystem.Model.SchClassUser model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SchSystem.Model.SchClassUser model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除班级对应的任课老师信息
        /// </summary>
        public bool Delete(string ClassId,string SchId)
        {

            return dal.Delete(ClassId,SchId);
        }
        public bool ExistsClassUser(int ClassId, int SchId)
        {

            return dal.ExistsClassUser(ClassId, SchId);
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
        public SchSystem.Model.SchClassUser GetModel(int AutoId)
        {

            return dal.GetModel(AutoId);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string cols, string strWhere)
        {
            return dal.GetList(cols, strWhere);
        }
        /// <summary>
        /// 获取教师以及科目列表
        /// </summary>
        public DataSet GetListV(string cols, string strWhere)
        {
            return dal.GetListV(cols, strWhere);
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
        public List<SchSystem.Model.SchClassUser> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList("*",strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SchSystem.Model.SchClassUser> DataTableToList(DataTable dt)
        {
            List<SchSystem.Model.SchClassUser> modelList = new List<SchSystem.Model.SchClassUser>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                SchSystem.Model.SchClassUser model;
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
        public bool ExistsClassSubUser(string SchId, string SubCode)
        {
            return dal.ExistsClassSubUser(SchId, SubCode);
        }
        public bool ExistsClassUser(string SchId, string UserId)
        {
            return dal.ExistsClassUser(SchId, UserId);
        }
        public bool ExistsClassUser(string SchId, int classid)
        {
            return dal.ExistsClassUser(SchId, classid);
        }
        #endregion  ExtensionMethod
    }
}

