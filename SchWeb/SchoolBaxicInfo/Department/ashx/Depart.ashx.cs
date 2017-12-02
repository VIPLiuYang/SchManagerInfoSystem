using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchSystem.Bll;
using System.Data;
using System.Data.SqlClient;
using SchSystem.Model;


namespace SchWeb.SchoolBaxicInfo.Department.ashx
{
    /// <summary>
    /// Depart 的摘要说明
    /// </summary>
    public class Depart : IHttpHandler
    {
        SchSystem.Bll.SchDepartInfoBll bll_depart = new SchSystem.Bll.SchDepartInfoBll();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];

            if (action == "Search")
            {
                string strWhere = "";
                //string userid = Convert.ToString(context.Session["userid"]);
                ////如果Session为空，停止运行
                //if (string.IsNullOrEmpty(userid))
                //{
                //    context.Response.Write(pubCls.ClsRetJsonMs.Ret_DgvError("Error", "页面过期，请刷新页面！"));
                //    return;
                //}
                ////每页条数ie
                //int rows = Convert.ToInt32(HttpContext.Current.Request["rows"]);
                ////当前页码
                //int page = Convert.ToInt32(HttpContext.Current.Request["page"]);
                DataTable dt = bll_depart.GetList(strWhere).Tables[0];
                SchManagerInfoSystem.Common.DttoJson dttojson = new SchManagerInfoSystem.Common.DttoJson();
                string json = dttojson.DataTableToJson(dt);
                context.Response.Write(json);
            }
            else if (action == "Add")
            {
                SchDepartInfo Sch = new SchDepartInfo();
                Sch.DepartName = context.Request["DepartName"];
                Sch.OrderId = 1;
                Sch.Stat = 1;
                Sch.RecTime = Convert.ToDateTime("2010-09-12");
                Sch.RecUser = " sw";
                Sch.Pid = Convert.ToInt32(context.Request["Pid"]);
                Sch.LastRecTime = Convert.ToDateTime("2011-02-11");
                Sch.LastRecUser = "liuyang";
                Sch.SchId = Convert.ToInt32(context.Request["SchId"]);
                int Prirow = bll_depart.Add(Sch);
                if (Prirow == 0)
                {
                    context.Response.Write(0);
                }
            }
            else if (action == "edit")
            {

            }
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