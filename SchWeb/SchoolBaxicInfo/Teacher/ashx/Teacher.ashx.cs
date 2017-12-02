﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using SchSystem.Model;
using SchManagerInfoSystem.Common;

namespace SchWeb.SchoolBaxicInfo.Teacher.ashx
{
    /// <summary>
    /// Teacher 的摘要说明
    /// </summary>
    public class Teacher : IHttpHandler
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
            else if (action=="Getdep")
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
            #region 查询
            else if (action == "Search")
            {
                string strWhere = "";
                string UserTname = Convert.ToString(context.Request["UserTname"]);
                if (!string.IsNullOrEmpty(UserTname))
                {
                    strWhere += "a.UserTname LIKE '%" + UserTname + "%'";
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
                DataTable dt = bll_userinfo.GetList(strWhere).Tables[0];
                
                string json = dttojson.DataTableToJson(dt);
                if (json=="")
                {
                    context.Response.Write("22");
                }
                context.Response.Write(json);
            }
            #endregion
            #region 添加
            else if (action == "Add")
            {
                SchUserInfo Sch = new SchUserInfo();
                Sch.UserName = "默认值";
                Sch.PassWord = "默认值";
                Sch.UserTname = context.Request["UserTname"];
                Sch.Mobile = context.Request["Mobile"];
                Sch.SchId = 1;
                Sch.OrderId = 1;
                Sch.Stat = 1;
                Sch.UserLv = 1;
                Sch.Telno = "123";
                Sch.Postion = "教师";
                Sch.ImgUrl = "www";
                Sch.LoginTime = Convert.ToDateTime("2010-09-12");
                Sch.RecTime = Convert.ToDateTime("2010-09-12");
                Sch.ClassMs= Convert.ToString(context.Request["ClassMs"]);
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
            else if (action=="Edit")
            {
                SchUserInfo Sch = new SchUserInfo();
                Sch.UserId = Convert.ToInt32(context.Request["UserId"]);
                Sch.UserName = "默认值";
                Sch.PassWord = "默认值";
                Sch.UserTname = context.Request["UserTname"];
                Sch.Mobile = context.Request["Mobile"];
                Sch.SchId = 1;
                Sch.OrderId = 1;
                Sch.Stat = 1;
                Sch.UserLv = 1;
                Sch.Telno = "123";
                Sch.Postion = "教师";
                Sch.ImgUrl = "www";
                Sch.LoginTime = Convert.ToDateTime("2010-09-12");
                Sch.RecTime = Convert.ToDateTime("2010-09-12");
                Sch.ClassMs = Convert.ToString(context.Request["ClassMs"]);
                Sch.RecUser = " sw";
                Sch.DepartIds = Convert.ToString(context.Request["DepartIds"]);
                Sch.LastRecTime = Convert.ToDateTime("2011-02-11");
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
            else if (action== "Delete")
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