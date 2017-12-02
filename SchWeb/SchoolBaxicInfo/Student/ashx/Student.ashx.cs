using SchManagerInfoSystem;
using SchSystem.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SchWeb.SchoolBaxicInfo.Student.ashx
{
    /// <summary>
    /// Student 的摘要说明
    /// </summary>
    public class Student : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string Action = context.Request.Form["Action"];
            int PageCount = int.Parse(context.Request.Form["PageCount"]);//总条数
            int PageSize = int.Parse(context.Request.Form["PageSize"]);//页数
            int PageIndex = 1;//当前页面
            if (!string.IsNullOrEmpty(context.Request.Form["PageIndex"]))
            {
                PageIndex = int.Parse(context.Request.Form["PageIndex"]);
            }
            if (Action == "List")
            {
                SchStuInfoBll ssiBll = new SchStuInfoBll();
                int RowCount = ssiBll.GetRecordCount("Stat=1");//查询总条数
                //数据分页：cols，所查询的列；strWhere，所查询的条件；ordercols，排序列；orderby，降序或升序；PageIndex，当前页数；PageSize，每页条数；RowCount，记录总数；PageCount，总页数
                DataSet ds = ssiBll.GetListCols("*", "Stat=1", "", "", PageIndex, PageSize, ref RowCount, ref PageCount);
                //数字分页
                Paging pa = new Paging(PageSize, RowCount, "StudentList.aspx", PageIndex);
                string pages = pa.GetPageing();
                context.Response.Write(SchManagerInfoSystem.Common.Function.DatasetToJson(ds, -1, pages, PageCount, RowCount, PageIndex));//将返回的DataSet集合转换为JSON对象
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