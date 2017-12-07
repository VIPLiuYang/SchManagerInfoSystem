using SchManagerInfoSystem.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SchWeb.PublicPage.Department
{
    /// <summary>
    /// Department_h 的摘要说明
    /// </summary>
    public class Department_h : IHttpHandler
    {
        SchManagerInfoSystem.Common.DttoJson dttojson = new SchManagerInfoSystem.Common.DttoJson();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];


            if (action == "Search")
            {
                try
                {
                    string sql = " select DepartId as id,DepartName as text,Pid  FROM SchDepartInfo  ";
                    DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                    context.Response.Write(dttojson.DataTableToJson(dt));
                }
                catch (Exception)
                {

                    throw;
                }
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