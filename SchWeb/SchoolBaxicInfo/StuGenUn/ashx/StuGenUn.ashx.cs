using Common;
using SchSystem.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SchWeb.SchoolBaxicInfo.StuGenUn.ashx
{
    /// <summary>
    /// StuGenUn 的摘要说明
    /// </summary>
    public class StuGenUn : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string Action = context.Request.Form["Action"];


            if (Action == "List")
            {
                int PageSize = int.Parse(context.Request.Form["PageSize"]);//页数
                int PageIndex = 1;//当前页面
                if (!string.IsNullOrEmpty(context.Request.Form["PageIndex"]))
                {
                    PageIndex = int.Parse(context.Request.Form["PageIndex"]);
                }
                SchStuGenUnBll ssiBll = new SchStuGenUnBll();
                int RowCount = 0; int PageCount = 0;
                //数据分页：cols，所查询的列；strWhere，所查询的条件；ordercols，排序列；orderby，降序或升序；PageIndex，当前页数；PageSize，每页条数；RowCount，记录总数；PageCount，总页数
                DataSet ds = ssiBll.GetListCols("ssgu.*,ssi.StuName,spi.GenName", "", "", "", PageIndex, PageSize, ref RowCount, ref PageCount);
                //数字分页
                Paging pa = new Paging(PageSize, RowCount, "StuGenUnList.aspx", PageIndex);
                string pages = pa.GetPageing();
                context.Response.Write(SchManagerInfoSystem.Common.Function.DatasetToJson(ds, -1, pages, PageCount, RowCount, PageIndex));//将返回的DataSet集合转换为JSON对象
            }
            else if (Action == "Delete")
            {
                int StudentId = int.Parse(context.Request.Form["StudentId"]);
                SchStuGenUnBll ssguBll = new SchStuGenUnBll();
                bool result = ssguBll.Delete(StudentId);
                context.Response.Write(result);
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