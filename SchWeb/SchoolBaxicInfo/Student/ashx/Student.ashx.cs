using Common;
using SchSystem.Bll;
using SchSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
            
            
            if (Action == "List")
            {
                int PageSize = int.Parse(context.Request.Form["PageSize"]);//页数
                int PageIndex = 1;//当前页面
                if (!string.IsNullOrEmpty(context.Request.Form["PageIndex"]))
                {
                    PageIndex = int.Parse(context.Request.Form["PageIndex"]);
                }
                SchStuInfoBll ssiBll = new SchStuInfoBll();
                int RowCount = 0; int PageCount = 0;
                //数据分页：cols，所查询的列；strWhere，所查询的条件；ordercols，排序列；orderby，降序或升序；PageIndex，当前页数；PageSize，每页条数；RowCount，记录总数；PageCount，总页数
                DataSet ds = ssiBll.GetListCols("*", "Stat=1", "", "", PageIndex, PageSize, ref RowCount, ref PageCount);
                //数字分页
                Paging pa = new Paging(PageSize, RowCount, "StudentList.aspx", PageIndex);
                string pages = pa.GetPageing();
                context.Response.Write(SchManagerInfoSystem.Common.Function.DatasetToJson(ds, -1, pages, PageCount, RowCount, PageIndex));//将返回的DataSet集合转换为JSON对象
            }
            else if (Action == "null")//当没有参数时，即为添加操作
            {
                //查询学校信息：根据用户所在学校的编号查询所属学校
                SchInfoBll siBll = new SchInfoBll();
                DataSet Schds = siBll.GetList("Stat = 1 and SchId=1");
                string SchInfo = SchManagerInfoSystem.Common.Function.DatSetToJSON2(Schds, "SchInfo");
                //查询年级信息：根据用户所在学校查询本属学校的年级信息
                SchClassInfoBll sgiBll = new SchClassInfoBll();
                DataSet sgids = sgiBll.GetList("sci.ClassId,sci.ClassName,sgi.GradeName","sci.SchId=1 and sci.IsFinish=1",2);
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
                SchStuInfo sgi = new SchStuInfo();
                sgi.LoginName = context.Request.Form["LoginName"];
                sgi.Pwd = context.Request.Form["Pwd"];
                sgi.StuName = context.Request.Form["StuName"];
                sgi.StuNo = context.Request.Form["StuNo"];
                sgi.Sex = int.Parse(context.Request.Form["Sex"]);
                sgi.ClassId = int.Parse(context.Request.Form["ClassId"]);
                sgi.SchId = int.Parse(context.Request.Form["SchId"]);
                sgi.CardNo = context.Request.Form["CardNo"];
                sgi.ImgUrl = context.Request.Form["ImgUrl"];
                sgi.Birth = Convert.ToDateTime(context.Request.Form["Birth"]);
                sgi.StudyType = int.Parse(context.Request.Form["StudyType"]);
                sgi.Stat = 1;
                sgi.RecTime = DateTime.Now;
                sgi.RecUser = "admin";
                sgi.LastRecTime = DateTime.Now;
                sgi.LastRecUser = "admin";
                SchStuInfoBll ssiBll = new SchStuInfoBll();
                int resultid = ssiBll.Add(sgi);
                context.Response.Write(resultid);
            }
            else if (Action == "Edit")//编辑方法
            {
                int StuId = int.Parse(context.Request.Form["StuId"]);
                SchStuInfoBll sciBll = new SchStuInfoBll();
                DataSet ds = sciBll.GetList("Stat=1 and StuId=" + StuId);
                context.Response.Write(SchManagerInfoSystem.Common.Function.DatasetToJson(ds));
            }
            else if (Action == "EditSave")
            {
                SchStuInfo sgi = new SchStuInfo();
                sgi.StuId = int.Parse(context.Request.Form["StuId"]); 
                sgi.LoginName = context.Request.Form["LoginName"];
                sgi.Pwd = context.Request.Form["Pwd"];
                sgi.StuName = context.Request.Form["StuName"];
                sgi.StuNo = context.Request.Form["StuNo"];
                sgi.Sex = int.Parse(context.Request.Form["Sex"]);
                sgi.ClassId = int.Parse(context.Request.Form["ClassId"]);
                sgi.SchId = int.Parse(context.Request.Form["SchId"]);
                sgi.CardNo = context.Request.Form["CardNo"];
                sgi.ImgUrl = context.Request.Form["ImgUrl"];
                sgi.Birth = Convert.ToDateTime(context.Request.Form["Birth"]);
                sgi.StudyType = int.Parse(context.Request.Form["StudyType"]);
                sgi.LastRecTime = DateTime.Now;
                sgi.LastRecUser = "admin";
                SchStuInfoBll ssiBll = new SchStuInfoBll();
                context.Response.Write(ssiBll.Update(sgi));
            }
            else if (Action == "Delete")
            {
                int StudentId = int.Parse(context.Request.Form["StudentId"]);
                SchStuInfoBll sgiBll = new SchStuInfoBll();
                bool result = sgiBll.DeleteRec(StudentId);
                context.Response.Write(result);
            }
            else if (Action == "FlieUpload")
            {
                SchManagerInfoSystem.Common.UploadFile uf = new SchManagerInfoSystem.Common.UploadFile();

                //HttpPostedFile File = FileUpload1.PostedFile;
                // AllSheng.UploadObj.PhotoSave("/", FileUpload1);
                HttpFileCollection files = HttpContext.Current.Request.Files;
                uf.Path = "/UploadFileDir";
                String ReStr = uf.SaveAs(files).ToString();
                uf = null;
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