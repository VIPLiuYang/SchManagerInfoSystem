using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchSystem.Bll;
using System.Data;
using System.Data.SqlClient;
using SchSystem.Model;
using SchManagerInfoSystem.Common;
using Common;

namespace SchWeb.SchoolBaxicInfo.Department.ashx
{
    /// <summary>
    /// Depart 的摘要说明
    /// </summary>
    public class Depart : IHttpHandler
    {
        SchSystem.Bll.SchDepartInfoBll bll_depart = new SchSystem.Bll.SchDepartInfoBll();
        SchManagerInfoSystem.Common.DttoJson dttojson = new SchManagerInfoSystem.Common.DttoJson();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"]; 
            #region 获取学校
            if (action == "GetSch")
            {
                try
                {
                    string strWhere = "  ";

                    string schid = Convert.ToString(context.Request["schid"]);
                    if (!string.IsNullOrEmpty(schid))
                    {
                        strWhere += " where SchId=" + schid;
                    }
                   
                    string sql = " select SchId,SchName from  SchInfo	   "+ strWhere;
                    DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                    context.Response.Write(dttojson.DataTableToJson(dt));
                }
                catch (Exception)
                {

                    throw;
                }
            }
            #endregion
            #region 获取部门
            else if (action == "Getdep")
            {
                try
                {
                    string strWhere = "  ";

                    string id = Convert.ToString(context.Request["depid"]);
                    if (!string.IsNullOrEmpty(id))
                    {
                        strWhere += " where DepartId=" + id;
                    }
                    string sql = " select DepartId,DepartName  FROM SchDepartInfo   "+strWhere;
                    DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                    context.Response.Write(dttojson.DataTableToJson(dt));
                }
                catch (Exception)
                {

                    throw;
                }
            }
            #endregion
            #region 查询
            else if (action == "Search")
            {
                string strWhere = "";
                string Depname = Convert.ToString(context.Request["Depname"]);
                string Depid = Convert.ToString(context.Request["depid"]);
                if (!string.IsNullOrEmpty(Depname))
                {
                    strWhere += " a.DepartName LIKE '%" + Depname + "%'";
                }
                if (!string.IsNullOrEmpty(Depid))
                {
                    strWhere += " a.DepartId =" + Depid;
                }
                int PageSize = int.Parse(context.Request.Form["PageSize"]);//页数
                int PageIndex = 1;//当前页面
                if (!string.IsNullOrEmpty(context.Request.Form["PageIndex"]))
                {
                    PageIndex = int.Parse(context.Request.Form["PageIndex"]);
                }
                //string userid = Convert.ToString(context.Session["userid"]);
                ////如果Session为空，停止运行
                //if (string.IsNullOrEmpty(userid))
                //{
                //    context.Response.Write(pubCls.ClsRetJsonMs.Ret_DgvError("Error", "页面过期，请刷新页面！"));
                //    return;
                //} 
                int RowCount = 0; int PageCount = 0;
                string sql = " a.DepartId,a.DepartName,a.Pid,c.DepartName as Pname,a.OrderId,a.SchId,b.SchName,a.Stat,a.RecTime,a.RecUser,a.LastRecTime,a.LastRecUser ";
                DataSet ds = bll_depart.GetListCols(sql, strWhere, "", "", PageIndex, PageSize, ref RowCount, ref PageCount);
                // SchManagerInfoSystem.Common.DttoJson dttojson = new SchManagerInfoSystem.Common.DttoJson();
                // string json = dttojson.DataTableToJson(dt);
                // context.Response.Write(json); 
                Paging pa = new Paging(PageSize, RowCount, "DepartList.aspx", PageIndex);
                string pages = pa.GetPageing();
                context.Response.Write(SchManagerInfoSystem.Common.Function.DatasetToJson(ds, -1, pages, PageCount, RowCount, PageIndex));//将返回的DataSet集合转换为JSON对象
            }
            #endregion
            #region 添加
            else if (action == "Add")
            {
                SchDepartInfo Sch = new SchDepartInfo();
                Sch.DepartName = context.Request["DepartName"];
                Sch.OrderId = 1;
                Sch.Stat = Convert.ToInt32(context.Request["Stat"]);
                Sch.RecTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString());
                Sch.RecUser = "刘洋";
                Sch.Pid = Convert.ToInt32(context.Request["Pid"]);
                Sch.LastRecTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString());
                Sch.LastRecUser = "刘洋";
                Sch.SchId = Convert.ToInt32(context.Request["SchId"]);
                int Prirow = bll_depart.Add(Sch);
                if (Prirow == 0)
                {
                    context.Response.Write(0);
                }
            }
            #endregion
            #region 编辑
            else if (action == "Edit")
            {
                SchDepartInfo Sch = new SchDepartInfo();
                Sch.DepartId=Convert.ToInt32( context.Request["DepartId"]);
                Sch.DepartName = context.Request["DepartName"];
                Sch.OrderId = 1;
                Sch.Stat = Convert.ToInt32(context.Request["Stat"]);
                Sch.RecTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString());
                Sch.RecUser = "刘洋";
                Sch.Pid = Convert.ToInt32(context.Request["Pid"]);
                Sch.LastRecTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString());
                Sch.LastRecUser = "刘洋";
                Sch.SchId = Convert.ToInt32(context.Request["SchId"]);
                bool Prirow = bll_depart.Update(Sch);
                if (Prirow == true)
                {
                    context.Response.Write(0);
                }
            }
            #endregion 
            #region 删除
            else if (action == "Delete")
            {
                int DepartId = Convert.ToInt32(context.Request["DepartId"]);
                bool Prirow = bll_depart.Delete(DepartId);
                if (Prirow != true)
                {
                    context.Response.Write("sb");
                }
                context.Response.Write("Success");
            }
            #endregion
        } 
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}