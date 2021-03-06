﻿using System;
using System.Data;
using System.Collections.Generic;
using SchSystem.Model;
namespace SchSystem.BLL
{
    /// <summary>
    /// SchUserRole
    /// </summary>
    public partial class SchUserRole
    {
        private readonly SchSystem.DAL.SchUserRole dal = new SchSystem.DAL.SchUserRole();
        public SchUserRole()
        { }
        #region  BasicMethod
        public int DoUserRole(string UserName, string RecUser, string SchId, string RoleIds)
        {
            return dal.DoUserRole(UserName, RecUser, SchId, RoleIds);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SchSystem.Model.SchUserRole model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SchSystem.Model.SchUserRole model)
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
        public SchSystem.Model.SchUserRole GetModel(int AutoId)
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
        public List<SchSystem.Model.SchUserRole> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SchSystem.Model.SchUserRole> DataTableToList(DataTable dt)
        {
            List<SchSystem.Model.SchUserRole> modelList = new List<SchSystem.Model.SchUserRole>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                SchSystem.Model.SchUserRole model;
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
        /// <summary>
        /// 判断角色是否正在使用
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public bool ExistsRoleData(string SchId,string RoleId)
        {
            return dal.ExistsRoleData(SchId, RoleId);
        }
        #endregion  ExtensionMethod
    }
}

