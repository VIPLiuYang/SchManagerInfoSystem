using Common;
using SchSystem.Bll;
using SchSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace SchWeb.SchoolBaxicInfo.Parents.ashx
{
    /// <summary>
    /// Parents 的摘要说明
    /// </summary>
    public class Parents : IHttpHandler
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
                SchGenInfoBll ssiBll = new SchGenInfoBll();
                int RowCount = 0; int PageCount = 0;
                //数据分页：cols，所查询的列；strWhere，所查询的条件；ordercols，排序列；orderby，降序或升序；PageIndex，当前页数；PageSize，每页条数；RowCount，记录总数；PageCount，总页数
                DataSet ds = ssiBll.GetListCols("*", "Stat=1", "", "", PageIndex, PageSize, ref RowCount, ref PageCount);
                //数字分页
                Paging pa = new Paging(PageSize, RowCount, "ParentsList.aspx", PageIndex);
                string pages = pa.GetPageing();
                context.Response.Write(SchManagerInfoSystem.Common.Function.DatasetToJson(ds, -1, pages, PageCount, RowCount, PageIndex));//将返回的DataSet集合转换为JSON对象
            }
            else if (Action == "Add")//保存添加操作时执行此方法
            {
                SchGenInfo sgi = new SchGenInfo();
                sgi.LoginName = context.Request.Form["LoginName"];
                sgi.Pwd = context.Request.Form["Pwd"];
                sgi.GenName = context.Request.Form["GenName"];
                sgi.Mobile = context.Request.Form["Mobile"];
                sgi.Sex = int.Parse(context.Request.Form["Sex"]);
                sgi.Stat = 1;
                sgi.RecTime = DateTime.Now;
                sgi.RecUser = "admin";
                sgi.LastRecTime = DateTime.Now;
                sgi.LastRecUser = "admin";
                SchGenInfoBll ssiBll = new SchGenInfoBll();
                int resultid = ssiBll.Add(sgi);
                context.Response.Write(resultid);
            }
            else if (Action == "Edit")//编辑方法
            {
                int GenId = int.Parse(context.Request.Form["GenId"]);
                SchGenInfoBll sciBll = new SchGenInfoBll();
                DataSet ds = sciBll.GetList("Stat=1 and GenId="+GenId);
                context.Response.Write(SchManagerInfoSystem.Common.Function.DatasetToJson(ds));
            }
            else if (Action == "EditSave")
            {
                SchGenInfo si = new SchGenInfo();
                si.GenId = int.Parse(context.Request.Form["sId"]);
                si.LoginName = context.Request.Form["LoginName"];
                si.Pwd = context.Request.Form["Pwd"];
                si.GenName = context.Request.Form["GenName"];
                si.Mobile = context.Request.Form["Mobile"];
                si.Sex = int.Parse(context.Request.Form["Sex"]);
                si.LastRecTime = DateTime.Now;
                si.LastRecUser = "admin";
                SchGenInfoBll ssiBll = new SchGenInfoBll();
                context.Response.Write(ssiBll.Update(si));
            }
            else if (Action == "Delete")
            {
                int ParentsId = int.Parse(context.Request.Form["ParentsId"]);
                SchGenInfoBll sgiBll = new SchGenInfoBll();
                bool result = sgiBll.DeleteRec(ParentsId);
                context.Response.Write(result);
            }
            else
            {
                context.Response.Write("参数有误，请检查");
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