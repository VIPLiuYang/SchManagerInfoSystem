using Common;
using SchManagerInfoSystem.Common;
using SchSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace SchWeb.SchoolBaxicInfo.Users.ashx
{
    /// <summary>
    /// Users 的摘要说明
    /// </summary>
    public class Users : IHttpHandler
    {
        SchSystem.Bll.SchUserInfoBll bll_userinfo = new SchSystem.Bll.SchUserInfoBll();
        SchSystem.Bll.SchDepartInfoBll bll_depart = new SchSystem.Bll.SchDepartInfoBll();
        SchManagerInfoSystem.Common.DttoJson dttojson = new SchManagerInfoSystem.Common.DttoJson();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];

            #region 获取班级
            if (action == "Getgrade")
            {
                try
                {
                    string sql = " select gradeid,gradename from  dbo.SchGradeInfo  ";
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
                    string sql = " select DepartId,DepartName  FROM SchDepartInfo  ";
                    DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                    context.Response.Write(dttojson.DataTableToJson(dt));
                }
                catch (Exception)
                {

                    throw;
                }
            }
            #endregion
            #region 上传图片
            else if (action == "upload")
            {
                HttpPostedFile file = context.Request.Files["Filedata"];
                string uploadPath = HttpContext.Current.Server.MapPath(@context.Request["folder"]) + "\\";
                if (file != null)
                {
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }
                    file.SaveAs(uploadPath + file.FileName);
                    //下面这句代码缺少的话，上传成功后上传队列的显示不会自动消失
                    context.Response.Write("1");
                }
                else
                {
                    context.Response.Write("0");
                }
            }
            #endregion
            #region 查询
            else if (action == "Search")
            {
                string strWhere = " Postion='人员' ";
                string UserTname = Convert.ToString(context.Request["UserTname"]);
                if (!string.IsNullOrEmpty(UserTname))
                {
                    strWhere += " and UserTname LIKE '%" + UserTname + "%'";
                }
                string PriUserId = Convert.ToString(context.Request["PriUserId"]);
                if (!string.IsNullOrEmpty(PriUserId))
                {
                    strWhere += " and UserId=" + PriUserId;
                }
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
                int PageSize = int.Parse(context.Request.Form["PageSize"]);//页数
                int PageIndex = 1;//当前页面
                if (!string.IsNullOrEmpty(context.Request.Form["PageIndex"]))
                {
                    PageIndex = int.Parse(context.Request.Form["PageIndex"]);
                }
                int RowCount = 0; int PageCount = 0;
                string sql = " * ";
                DataSet ds = bll_userinfo.GetListCols(sql, strWhere, "", "", PageIndex, PageSize, ref RowCount, ref PageCount);
                // SchManagerInfoSystem.Common.DttoJson dttojson = new SchManagerInfoSystem.Common.DttoJson();
                // string json = dttojson.DataTableToJson(dt);
                // context.Response.Write(json); 
                Paging pa = new Paging(PageSize, RowCount, "TeacherList.aspx", PageIndex);
                string pages = pa.GetPageing();
                context.Response.Write(SchManagerInfoSystem.Common.Function.DatasetToJson(ds, -1, pages, PageCount, RowCount, PageIndex));//将返回的DataSet集合转换为JSON对象


            }
            #endregion
            #region 添加
            else if (action == "Add")
            {
                SchUserInfo Sch = new SchUserInfo();
                Sch.UserName = context.Request["UserName"];
                Sch.PassWord = context.Request["PassWord"]; ;
                Sch.UserTname = context.Request["UserTname"];
                Sch.Mobile = context.Request["Mobile"];
                Sch.SchId = 1;
                Sch.OrderId = 1;
                Sch.Stat = Convert.ToInt32(context.Request["Stat"]);
                Sch.UserLv = 1;
                Sch.Telno = "123";
                Sch.Postion = "人员";
                Sch.ImgUrl = context.Request["imgurl"];
                Sch.LoginTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString());
                Sch.RecTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString());
                Sch.ClassMs = "";
                Sch.RecUser = " sw";
                Sch.DepartIds = Convert.ToString(context.Request["DepartIds"]);
                Sch.LastRecTime = Convert.ToDateTime("2011-02-11");
                Sch.LastRecUser = "liuyang";
                Sch.CopeId = 1;
                Sch.RoleId = 1;
                Sch.SchId = Convert.ToInt32(1);
                int Prirow = bll_userinfo.Add(Sch);
                if (Prirow == 0)
                {
                    context.Response.Write(0);
                }
            }
            #endregion
            #region 编辑
            else if (action == "Edit")
            {
                SchUserInfo Sch = new SchUserInfo();
                Sch.UserId = Convert.ToInt32(context.Request["PriUserId"]);
                Sch.UserName = context.Request["UserName"];
                Sch.PassWord = context.Request["PassWord"]; ;
                Sch.UserTname = context.Request["UserTname"];
                Sch.Mobile = context.Request["Mobile"];
                Sch.SchId = 1;
                Sch.OrderId = 1;
                Sch.Stat = Convert.ToInt32(context.Request["Stat"]);
                Sch.UserLv = 1;
                Sch.Telno = "123";
                Sch.Postion = "人员";
                Sch.ImgUrl = context.Request["imgurl"];
                Sch.LoginTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString());
                Sch.RecTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString());
                Sch.ClassMs = "1";// Convert.ToString(context.Request["ClassMs"]);
                Sch.RecUser = " sw";
                Sch.DepartIds = "1"; //Convert.ToString(context.Request["DepartIds"]);
                Sch.LastRecTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString());
                Sch.LastRecUser = "liuyang";
                Sch.CopeId = 1;
                Sch.RoleId = 1;
                Sch.SchId = Convert.ToInt32(1);
                bool Prirow = bll_userinfo.Update(Sch);
                if (Prirow == true)
                {
                    context.Response.Write(0);
                }

            }
            #endregion
            #region 删除
            else if (action == "Delete")
            {
                int UserId = Convert.ToInt32(context.Request["UserId"]);
                bool Prirow = bll_userinfo.Delete(UserId);
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