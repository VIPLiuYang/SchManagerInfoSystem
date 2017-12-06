using Common;
using SchSystem.Bll;
using SchSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace SchWeb.SchoolBaxicInfo.Role.ashx
{
    /// <summary>
    /// Role 的摘要说明
    /// </summary>
    public class Role : IHttpHandler
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
                SchUserRoleBll ssiBll = new SchUserRoleBll();
                int RowCount = 0; int PageCount = 0;
                //数据分页：cols，所查询的列；strWhere，所查询的条件；ordercols，排序列；orderby，降序或升序；PageIndex，当前页数；PageSize，每页条数；RowCount，记录总数；PageCount，总页数
                DataSet ds = ssiBll.GetListCols("*", "", "", "", PageIndex, PageSize, ref RowCount, ref PageCount);
                //数字分页
                Paging pa = new Paging(PageSize, RowCount, "RoleList.aspx", PageIndex);
                string pages = pa.GetPageing();
                context.Response.Write(SchManagerInfoSystem.Common.Function.DatasetToJson(ds, -1, pages, PageCount, RowCount, PageIndex));//将返回的DataSet集合转换为JSON对象
            }
            else if (Action == "null")//当没有参数时，即为添加操作
            {
                //查询功能列表
                SchFuncInfoBll siBll = new SchFuncInfoBll();
                DataSet FuncList = siBll.GetList("Stat = 1");
                string SchFuncList = SchManagerInfoSystem.Common.Function.DatSetToJSON2(FuncList, "FuncList");
                StringBuilder json = new StringBuilder();
                json.Append("{");
                json.Append(SchFuncList);
                json.Append("}");
                context.Response.Write(json);
            }
            else if (Action == "Add")//保存添加操作时执行此方法
            {
                SchUserRole sgi = new SchUserRole();
                sgi.RoleName = context.Request.Form["RoleName"];
                sgi.Stat = int.Parse(context.Request.Form["Stat"]);
                //sgi.RoleStr = context.Request.Form["RoleStr"];
                sgi.RecTime = DateTime.Now;
                sgi.RecUser = "admin";
                sgi.LastRecTime = DateTime.Now;
                sgi.LastRecUser = "admin";
                SchUserRoleBll ssiBll = new SchUserRoleBll();
                int resultid = ssiBll.Add(sgi);
                context.Response.Write(resultid);
            }
            else if (Action == "Edit")//编辑方法
            {
                int Id = int.Parse(context.Request.Form["Id"]);
                SchUserRoleBll sciBll = new SchUserRoleBll();
                DataSet ds = sciBll.GetList("RoleId=" + Id);
                context.Response.Write(SchManagerInfoSystem.Common.Function.DatasetToJson(ds));
            }
            else if (Action == "EditSave")
            {
                SchUserRole sgi = new SchUserRole();
                sgi.RoleId = int.Parse(context.Request.Form["sId"]);
                sgi.RoleName = context.Request.Form["RoleName"];
                sgi.Stat = int.Parse(context.Request.Form["Stat"]);
                sgi.LastRecTime = DateTime.Now;
                sgi.LastRecUser = "admin";
                SchUserRoleBll ssiBll = new SchUserRoleBll();
                context.Response.Write(ssiBll.Update(sgi));
            }
            else if (Action == "EditSavePurview")
            {
                SchUserRole sgi = new SchUserRole();
                sgi.RoleId = int.Parse(context.Request.Form["sId"]);
                sgi.RoleStr = context.Request.Form["RoleStr"];
                sgi.LastRecTime = DateTime.Now;
                sgi.LastRecUser = "admin";
                SchUserRoleBll ssiBll = new SchUserRoleBll();
                context.Response.Write(ssiBll.UpdatePurview(sgi));
            }
            else if (Action == "Delete")
            {
                int Id = int.Parse(context.Request.Form["Id"]);
                SchUserRoleBll sgiBll = new SchUserRoleBll();
                bool result = sgiBll.Delete(Id);
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