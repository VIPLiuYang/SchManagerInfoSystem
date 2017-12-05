using Common;
using SchSystem.Bll;
using SchSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace SchWeb.SchoolBaxicInfo.Grade.Class.ashx
{
    /// <summary>
    /// Class 的摘要说明
    /// </summary>
    public class Class : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string Action = context.Request["Action"];
            
            if (Action == "List")
            {
                //int PageCount = int.Parse(context.Request.Form["PageCount"]);//总条数
                int PageSize = int.Parse(context.Request.Form["PageSize"]);//页数
                int PageIndex = 1;//当前页面
                if (!string.IsNullOrEmpty(context.Request.Form["PageIndex"]))
                {
                    PageIndex = int.Parse(context.Request.Form["PageIndex"]);
                }
                SchClassInfoBll ssiBll = new SchClassInfoBll();
                int RowCount = 0; int PageCount = 0;
                //数据分页：cols，所查询的列；strWhere，所查询的条件；ordercols，排序列；orderby，降序或升序；PageIndex，当前页数；PageSize，每页条数；RowCount，记录总数；PageCount，总页数
                DataSet ds = ssiBll.GetListCols("sci.*,si.SchName,sgi.GradeName,sgi.GradeName,sgi.GradeYear", "sci.IsFinish=1 and sci.SchId=1", "", "", PageIndex, PageSize, ref RowCount, ref PageCount);
                //数字分页
                Paging pa = new Paging(PageSize, RowCount, "ClassList.aspx", PageIndex);
                string pages = pa.GetPageing();
                context.Response.Write(SchManagerInfoSystem.Common.Function.DatasetToJson(ds, -1, pages, PageCount, RowCount, PageIndex));//将返回的DataSet集合转换为JSON对象
            }
            else if (Action == "null")//当没有参数时，即为添加操作
            {
                //查询学校信息：根据用户所在学校的编号查询所属学校
                SchInfoBll siBll = new SchInfoBll();
                DataSet Schds = siBll.GetList("Stat = 1 and SchId=1");
                string SchInfo = SchManagerInfoSystem.Common.Function.DatSetToJSON2(Schds,"SchInfo");
                //查询年级信息：根据用户所在学校查询本属学校的年级信息
                SchGradeInfoBll sgiBll = new SchGradeInfoBll();
                DataSet sgids = sgiBll.GetList("IsFinish = 1 and SchId=1");
                string SchGradeInfo = SchManagerInfoSystem.Common.Function.DatSetToJSON2(sgids, "SchGradeInfo");
                StringBuilder json = new StringBuilder();
                json.Append("{");
                json.Append(SchInfo + ",");
                json.Append(SchGradeInfo);
                json.Append("}");
                context.Response.Write(json);
            }
            else if (Action == "Add")//保存添加操作时执行此方法
            {
                SchClassInfo si = new SchClassInfo();
                si.ClassNo = context.Request.Form["ClassNo"];
                si.ClassName = context.Request.Form["ClassName"];
                si.GradeId = int.Parse(context.Request.Form["GradeName"]);
                si.SchId = int.Parse(context.Request.Form["SchId"]);
                si.IsFinish = 1;
                si.RecTime = DateTime.Now;
                si.RecUser = "admin";
                si.LastRecTime = DateTime.Now;
                si.LastRecUser = "admin";
                SchClassInfoBll ssiBll = new SchClassInfoBll();
                int resultid = ssiBll.Add(si);
                context.Response.Write(resultid);
            }
            else if (Action == "Edit")//编辑方法
            {
                int ClassId = int.Parse(context.Request.Form["ClassId"]);
                SchClassInfoBll sciBll = new SchClassInfoBll();
                DataSet ds = sciBll.GetList("sci.*,si.SchName,si.SchId,sgi.GradeName,sgi.GradeId", "sci.IsFinish=1 and sci.SchId=1 and sci.GradeId=5 and sci.ClassId="+ClassId);
                context.Response.Write(SchManagerInfoSystem.Common.Function.DatasetToJson(ds));
            }
            else if (Action == "EditSave")
            {
                SchClassInfo si = new SchClassInfo();
                si.ClassId = int.Parse(context.Request.Form["ClassId"]);
                si.ClassNo = context.Request.Form["ClassNo"];
                si.ClassName = context.Request.Form["ClassName"];
                si.GradeId = int.Parse(context.Request.Form["GradeName"]);
                //si.SchId = int.Parse(context.Request.Form["SchId"]);
                si.LastRecTime = DateTime.Now;
                si.LastRecUser = "admin";
                SchClassInfoBll ssiBll = new SchClassInfoBll();
                context.Response.Write(ssiBll.Update(si));
            }
            else if (Action == "Delete")//删除方法
            {
                int ClassId = int.Parse(context.Request.Form["ClassId"]);
                SchClassInfoBll ssiBll = new SchClassInfoBll();
                bool result = ssiBll.DeleteRec(ClassId);
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