using System;
using System.Data;
using System.Collections.Generic;
using SchSystem.Model;
namespace SchSystem.BLL
{
    /// <summary>
    /// SchGradeUserV
    /// </summary>
    public partial class SchGradeUserV
    {
        private readonly SchSystem.DAL.SchGradeUserV dal = new SchSystem.DAL.SchGradeUserV();
        public SchGradeUserV()
        { }
        #region  BasicMethod
        public bool ExistsGrade(string SchId, string usertid)
        {
            return dal.ExistsGrade(SchId, usertid);
        }
        public bool Exists(string UserName)
        {
            return dal.Exists(UserName);
        }
        public DataSet GetList(string cols = "*", string strWhere = "Stat=1")
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
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

