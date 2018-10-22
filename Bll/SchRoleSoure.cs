﻿using System;
using System.Data;
using System.Collections.Generic;
using SchManagerInfoSystem.Common;
using SchSystem.Model;
namespace SchSystem.BLL
{
    /// <summary>
    /// SchRoleSoure
    /// </summary>
    public partial class SchRoleSoure
    {
        private readonly SchSystem.DAL.SchRoleSoure dal = new SchSystem.DAL.SchRoleSoure();
        public SchRoleSoure()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }
        public bool UpdateStat(SchSystem.Model.SchRoleSoure model)
        {
            return dal.UpdateStat(model);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RoleId)
        {
            return dal.Exists(RoleId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SchSystem.Model.SchRoleSoure model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SchSystem.Model.SchRoleSoure model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int RoleId)
        {

            return dal.Delete(RoleId);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string RoleIdlist)
        {
            return dal.DeleteList(RoleIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SchSystem.Model.SchRoleSoure GetModel(int RoleId)
        {

            return dal.GetModel(RoleId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public SchSystem.Model.SchRoleSoure GetModelByCache(int RoleId)
        //{

        //    string CacheKey = "SchRoleSoureModel-" + RoleId;
        //    object objModel = SchManagerInfoSystem.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(RoleId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = SchManagerInfoSystem.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                SchManagerInfoSystem.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (SchSystem.Model.SchRoleSoure)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        public DataSet GetList(string Cols, string strWhere)
        {
            return dal.GetList(Cols, strWhere);
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
        public List<SchSystem.Model.SchRoleSoure> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SchSystem.Model.SchRoleSoure> DataTableToList(DataTable dt)
        {
            List<SchSystem.Model.SchRoleSoure> modelList = new List<SchSystem.Model.SchRoleSoure>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                SchSystem.Model.SchRoleSoure model;
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

