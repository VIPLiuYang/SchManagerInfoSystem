using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWeb.SchoolBaxicInfo.GradeClassSet
{
    public partial class SchClassShow : System.Web.UI.Page
    {
        //进入此页需要确认的三个关键参数
        public string dotype = "";//操作类型,修改或者是添加,a添加,e修改
        public string schid = "0";//需要建立的学校ID
        public string gradecode = "0";//需要建立的用户类型,0普通用户,1学校超管,2系统超管
        public string classid = "0";
        public string btnname = "添加";
        public string subs = "";
        public string schname = "";
        //根据上面两个参数的不同得到不同的参数
        public string umodelstr = "1";//用户model,json
        public string gradeboss = "";
        public string gradesdrp = "";
        public string depts = "";//相应学校部门,json
        public string subsdrp = "";//相应学校科目表,json
        public string deptss = "";
        public string deptusers = "";
        //需要根据不同情况建立或修改的不同学校用户和不同类型的用户,本学校用户唯一,不需要全系统唯一
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (true)//如果没对应权限,及判断用户类型是否跨界,主要防止非法篡改数据出现
            //{
            //    Response.Write("无对应权限");
            //    Response.End();
            //}
            if (!IsPostBack)
            {
                //先得到操作类型
                dotype = Com.Public.SqlEncStr(Request.Params["dotype"].ToString());
                schid = Com.Public.SqlEncStr(Request.Params["schid"].ToString());
                gradecode = Com.Public.SqlEncStr(Request.Params["gradecode"].ToString());
                if (string.IsNullOrEmpty(schid) || string.IsNullOrEmpty(gradecode))//如果没有对应参数中任意一个
                {
                    Response.Write("参数错误!");
                    Response.End();
                }
                if (dotype == "a")
                { }
                else if (dotype == "e")//修改,不能修改用户的类型及学校参数
                {
                    btnname = "保存";
                    classid = Com.Public.SqlEncStr(Request.Params["classid"].ToString());
                    if (string.IsNullOrEmpty(classid))
                    {
                        Response.Write("无对应修改的记录!");
                        Response.End();
                    }
                    //获取修改的对应用户的
                    SchSystem.BLL.SchClassInfo sgibll = new SchSystem.BLL.SchClassInfo();
                    SchSystem.Model.SchClassInfo sgimodel = sgibll.GetModel(int.Parse(classid));
                    if (sgimodel != null && sgimodel.ClassId > 0)
                    {
                        umodelstr = Newtonsoft.Json.JsonConvert.SerializeObject(sgimodel);
                    }
                    else
                    {
                        Response.Write("无该记录!");
                        Response.End();
                    }
                }
                else//不在添加及修改之内,则返回
                {
                    Response.Write("没有可供确认的操作类型!");
                    Response.End();
                }
                /*//判断跨界操作的可能性
                if (!Com.Public.isVa(schid, systype))
                {
                    Response.Write("出错,用户非法跨界操作!");
                    Response.End();
                }*/
                SchSystem.BLL.SchInfo schbll = new SchSystem.BLL.SchInfo();
                schname = schbll.GetSchName(int.Parse(schid));
                #region 获取当前学校的老师
                //当前班级任课老师及班主任
                SchSystem.BLL.SchClassUser userclassbll = new SchSystem.BLL.SchClassUser();
                DataTable dtclassuser = userclassbll.GetList("UserName id,SubCode subcode,UserTname name,IsMs isms", "ClassId=" + Com.Public.SqlEncStr(classid)).Tables[0];

                //当前学校老师
                SchSystem.BLL.SchUserDeptV userbll = new SchSystem.BLL.SchUserDeptV();
                DataTable dtuser = userbll.GetList("DeptId,DepartName,UserName,UserTname", "Stat=1 and Ustat=1 and SchId=" + Com.Public.SqlEncStr(schid)).Tables[0];
                //DataRow[] dtRow = dtuser.Select();
                StringBuilder sb = new StringBuilder();
                //DataView dv = dtuser.DefaultView;
                //DataTable datadpt = dv.ToTable(true, "Pid,DeptId,DepartName");
                SchSystem.BLL.SchDepartInfo dptbll = new SchSystem.BLL.SchDepartInfo();
                DataTable dt = dptbll.GetList("Pid pId,convert(varchar(20),DepartId) id,DepartName name,'0' isms,'' subcode,'false' checked,'true' nochecks", "SchId=" + schid + " and Stat=1 Order by OrderId,DepartName").Tables[0];
                DataTable dtdptuser = dt.Clone();
                dtdptuser.Columns["nochecks"].ColumnName = "nocheck";
                if (dt.Rows.Count > 0)
                {
                    //合并人员到部门表
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        dtdptuser.Rows.Add(dt.Rows[i].ItemArray);
                        //获取该部门下的人员
                        DataRow[] drss = dtuser.Select("DeptId='" + dt.Rows[i]["id"].ToString() + "'");
                        if (drss.Length > 0)
                        {
                            foreach (DataRow item in drss)
                            {
                                DataRow dr = dtdptuser.NewRow();

                                dr["id"] = item["UserName"].ToString();
                                dr["name"] = item["UserTname"].ToString();
                                dr["pId"] = item["DeptId"].ToString();
                                dtdptuser.Rows.Add(dr);

                            }
                        }
                    }
                    deptusers = Newtonsoft.Json.JsonConvert.SerializeObject(dtdptuser);
                    DataRow[] drs = dt.Select("Pid=0");
                    foreach (DataRow dr in drs)
                    {
                        string nodeID = dr["ID"].ToString();
                        string nodeText = dr["Name"].ToString();


                        nodeText = "├" + nodeText;
                        string blank = "&nbsp;&nbsp;&nbsp;&nbsp;";
                        sb.Append("<option value=\"p_" + nodeID + "\">" + nodeText + "</option>");
                        DataRow[] drusers = dtuser.Select("DeptId='" + nodeID + "'");
                        if (drusers != null && drusers.Length > 0)
                        {
                            foreach (DataRow druser in drusers)
                            {
                                sb.Append("<option style=\"color:blue\" value=\"u_" + druser["UserName"].ToString() + "\">" + blank + "&nbsp;&nbsp;&nbsp;&nbsp;" + druser["UserTname"].ToString() + "</option>");
                            }
                        }
                        BindSon(sb, nodeID, dt, blank, dtuser);
                    }
                }
                depts = sb.ToString();
                deptss = Newtonsoft.Json.JsonConvert.SerializeObject(dtclassuser);
                subsdrp = Com.Public.GetDrp("sub", schid, "1", false, "", "");
                #endregion

                #region 获取年级领导
                SchSystem.BLL.SchGradeUsers usergradebll = new SchSystem.BLL.SchGradeUsers();
                gradeboss = usergradebll.GetNames("GradeId in ( select GradeId from SchGradeInfo where GradeCode=" + Com.Public.SqlEncStr(gradecode) + " and schid=" + schid + ")");
                gradesdrp = Com.Public.GetDrp("grade", schid, "0", false, "", "");
                #endregion

            }
        }
        public static void BindSon(StringBuilder sb, string pid, DataTable dt, string blank, DataTable dtuser)
        {
            DataRow[] drs = dt.Select("Pid=" + pid);
            foreach (DataRow dr in drs)
            {
                string nodeID = dr["ID"].ToString();
                string nodeText = dr["Name"].ToString();
                nodeText = blank + "|--" + nodeText;
                sb.Append("<option value=\"p_" + nodeID + "\">" + nodeText + "</option>");
                string blank2 = blank + "&nbsp;&nbsp;&nbsp;&nbsp;";
                DataRow[] drusers = dtuser.Select("DeptId='" + nodeID + "'");
                if (drusers != null && drusers.Length > 0)
                {
                    foreach (DataRow druser in drusers)
                    {
                        sb.Append("<option style=\"color:blue\"  value=\"u_" + druser["UserName"].ToString() + "\">" + blank2 + "&nbsp;&nbsp;&nbsp;&nbsp;" + druser["UserTname"].ToString() + "</option>");
                    }
                }

                BindSon(sb, nodeID, dt, blank2, dtuser);
            }
        }
        [WebMethod]
        public static string getgradeboss(string schid, string gradecode)
        {
            schid = Com.Public.SqlEncStr(schid);
            gradecode = Com.Public.SqlEncStr(gradecode);
            string rets = "";
            //年级领导
            SchSystem.BLL.SchGradeUsers sguBLL = new SchSystem.BLL.SchGradeUsers();
            rets = sguBLL.GetNames("GradeId in ( select GradeId from SchGradeInfo where GradeCode=" + Com.Public.SqlEncStr(gradecode) + " and schid=" + schid + ")");
            return rets;
        }
        [WebMethod]
        public static string classsave(string dotype, string schid, string gradecode, string classid, string classname, string tagsusers)
        {
            dotype = Com.Public.SqlEncStr(dotype);
            schid = Com.Public.SqlEncStr(schid);
            gradecode = Com.Public.SqlEncStr(gradecode);
            classid = Com.Public.SqlEncStr(classid);
            classname = Com.Public.SqlEncStr(classname);
            tagsusers = Com.Public.SqlEncStr(tagsusers);
            string ret = "";
            //字符串匹配验证
            string PatternStr = @"^[\u4e00-\u9fa5]+$";
            bool resultStr = Regex.IsMatch(classname, PatternStr);
            if (resultStr != true)
            {
                return ret = "只能输入中文名称";
            }
            try
            {
                if (!Com.Public.IsOne(Com.Session.userrolestr, 12))
                {
                    return ret = "无操作权限";
                }
                if (!Com.Public.isVa(schid, ""))
                {
                    return ret = "无跨界权限";
                }
                if (schid == Com.Public.getKey("adminschid"))
                {
                    ret = "此为系统学校,不允许操作";
                }
                else if (string.IsNullOrEmpty(schid) || schid == "0")
                    ret += "非法的学校!";
                SchSystem.BLL.SchClassInfo classbll = new SchSystem.BLL.SchClassInfo();
                SchSystem.Model.SchClassInfo classmodel = new SchSystem.Model.SchClassInfo();
                classmodel.LastRecTime = DateTime.Now;
                classmodel.LastRecUser = Com.Session.userid;
                classmodel.GradeCode = gradecode;
                classmodel.ClassName = classname;
                //判断编号及账号是否有重复,生成密码加密
                if (dotype == "e")
                {
                    /*if (userbll.ExistsUserCode(int.Parse(userid), usercode, int.Parse(schid)))
                    {
                        ret += "用户编号重复!";
                    }*/
                }
                if (dotype == "a")
                {
                    /*if (userbll.ExistsUserCode(0, usercode, int.Parse(schid)))
                    {
                        ret += "用户编号重复!";
                    }
                    if (userbll.ExistsUserCode(0, username, int.Parse(schid)))
                    {
                        ret += "账号重复!";
                    }*/

                }
                if (ret == "")
                {
                    if (dotype == "e")
                    {
                        classmodel.ClassId = int.Parse(classid);
                        classbll.Update(classmodel);
                    }
                    if (dotype == "a")
                    {
                        //usermodel.PassWord = SchManagerInfoSystem.Common.DESEncrypt.Encrypt(userpw);
                        classmodel.RecTime = DateTime.Now;
                        classmodel.RecUser = Com.Session.userid;
                        classmodel.IsFinish = 0;
                        classmodel.SchId = int.Parse(schid);
                        classid = classbll.Add(classmodel).ToString();
                    }
                    //清除关联的老师,再添加或更新关联老师
                    SchSystem.BLL.SchClassUser classuserbll = new SchSystem.BLL.SchClassUser();
                    SchSystem.Model.SchClassUser classusermodel;
                    classuserbll.DeleteUserSub("ClassId=" + Com.Public.SqlEncStr(classid));
                    tagsusers = tagsusers.Replace("u_", "");//UID,UTNAME,SUB,ISMS
                    string[] uss = tagsusers.Split('|');
                    if (uss.Length > 0)
                    {
                        foreach (string item in uss)
                        {
                            string[] its = item.Split(',');
                            if (its.Length == 4)
                            {
                                classusermodel = new SchSystem.Model.SchClassUser();
                                classusermodel.ClassId = int.Parse(classid);
                                classusermodel.LastRecTime = DateTime.Now;
                                classusermodel.LastRecUser = Com.Session.userid;
                                classusermodel.RecTime = DateTime.Now;
                                classusermodel.RecUser = Com.Session.userid;
                                classusermodel.UserName = its[0];
                                classusermodel.SubCode = its[1];
                                classusermodel.UserTname = its[2];
                                classusermodel.IsMs = int.Parse(its[3]);
                                classusermodel.SchId = int.Parse(schid);
                                classuserbll.Add(classusermodel);
                            }
                        }
                    }
                    ret = "success";
                }

            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }
            return ret;

        }
    }
}