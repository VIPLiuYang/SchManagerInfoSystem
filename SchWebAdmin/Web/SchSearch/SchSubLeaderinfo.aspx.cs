using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin.Web.SchSearch
{
    public partial class SchSubLeaderinfo : System.Web.UI.Page
    {
        //进入此页需要确认的三个关键参数
        public string dotype = "";//操作类型,修改或者是添加,a添加,e修改
        public string schid = "";//需要建立的学校ID
        public string systype = "";//需要建立的用户类型,0普通用户,1学校超管,2系统超管
        public string btnname = "添加";

        public string schname = "";
        //根据上面两个参数的不同得到不同的参数
        public string umodelstr = "1";//用户model,json
        public string roles = "";//学校role和相应用户的select
        public string funcstr = "";//功能表,json
        public string depts = "";//相应学校部门及个人部门,json
        public static string subs = "";//相应学校科目表及个人科目,json
        public string tecs = "";
        public static string grades = "";
        public string subUser = "";
        //需要根据不同情况建立或修改的不同学校用户和不同类型的用户,本学校用户唯一,不需要全系统唯一
        public string areastr = "";
        public string cotycode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["schid"] != null && Request.Params["schid"].ToString() != "")
            {
                schid = Com.Public.SqlEncStr(Request.Params["schid"].ToString());
                //年级
                SchSystem.BLL.SchGradeInfo sgiBLL = new SchSystem.BLL.SchGradeInfo();
                DataTable dtSchGrade = sgiBLL.GetList(" IsFinish=0 and SchId='" + schid + "' order by GradeCode").Tables[0];//得到年级数据列表,并且是为非毕业的年级
                //年级领导
                SchSystem.BLL.SchGradeUsers sguBLL = new SchSystem.BLL.SchGradeUsers();
                dtSchGrade.Columns.Add("GradeBoss");
                if (dtSchGrade.Rows.Count > 0)
                {
                    for (int i = 0; i < dtSchGrade.Rows.Count; i++)
                    {
                        dtSchGrade.Rows[i]["GradeBoss"] = sguBLL.GetNames("GradeId=" + dtSchGrade.Rows[i]["GradeId"].ToString());
                    }
                }
                grades = Newtonsoft.Json.JsonConvert.SerializeObject(dtSchGrade);
                //当前学校所开设的科目
                SchSystem.BLL.SchSub schsubBll = new SchSystem.BLL.SchSub();
                DataSet dsSchSub = schsubBll.GetList("Stat=1 and SchId='" + schid + "'");
                subs = Newtonsoft.Json.JsonConvert.SerializeObject(dsSchSub);
                //获取科目教师
                SchSystem.BLL.SchSubLeader scuBll = new SchSystem.BLL.SchSubLeader();
                DataSet dssubUser = scuBll.GetListTecSub("*", "schid='" + schid + "' and Stat=1");
                subUser = Newtonsoft.Json.JsonConvert.SerializeObject(dssubUser);
                //subUser
                //当前学校的教师
                SchSystem.BLL.SchUserInfo suiBll = new SchSystem.BLL.SchUserInfo();
                DataSet dsSUI = suiBll.GetList("*", "Stat=1 and SchId='" + schid + "'");
                tecs = Newtonsoft.Json.JsonConvert.SerializeObject(dsSUI);

            }
        }
        [WebMethod]
        public static string page(string txtname, string ustat, string cotycode, string schid, string gradeCode, string classid, string subcode)
        {
            string ret = "";
            if (Com.Session.userid == null)
            {
                ret = "expire";
            }
            else
            {
                SchSystem.BLL.SchClassInfo sciBll = new SchSystem.BLL.SchClassInfo();
                //Stat:0废弃,1正常,2被删除,正常界面不显示删除,超管界面可以考虑
                string strwhere = "ClassStat<>2 and SchId = '" + Com.Public.SqlEncStr(schid) + "'";
                if (!string.IsNullOrEmpty(ustat))
                {
                    strwhere += " and ClassStat=" + Com.Public.SqlEncStr(ustat);
                }
                if (!string.IsNullOrEmpty(gradeCode))
                {
                    strwhere += " and GradeId='" + Com.Public.SqlEncStr(gradeCode) + "'";
                }
                if (!string.IsNullOrEmpty(classid))
                {
                    strwhere += " and ClassId='" + Com.Public.SqlEncStr(classid) + "'";
                }
                if (!string.IsNullOrEmpty(subcode) && !string.IsNullOrEmpty(txtname))
                {
                    strwhere += " and ClassId in (select ClassId from SchClassUser where SubCode='" + Com.Public.SqlEncStr(subcode) + "' and schid='" + Com.Public.SqlEncStr(schid) + "' and UserTname like '%" + Com.Public.SqlEncStr(txtname) + "%')";
                }
                else if (!string.IsNullOrEmpty(txtname) || !string.IsNullOrEmpty(subcode))
                {
                    if (!string.IsNullOrEmpty(txtname))
                    {
                        strwhere += " and ClassId in (select ClassId from SchClassUser where UserTname like '%" + Com.Public.SqlEncStr(txtname) + "%' and schid='" + Com.Public.SqlEncStr(schid) + "')";
                    }
                    else
                    {
                        strwhere += " and ClassId in (select ClassId from SchClassUser where SubCode='" + Com.Public.SqlEncStr(subcode) + "' and schid='" + Com.Public.SqlEncStr(schid) + "')";
                    }
                }
                DataTable ClassDt = sciBll.GetListV(strwhere + " order by GradeCode,ClassName").Tables[0];//得到班级数据列表 
                if (ClassDt.Rows.Count > 0)
                {
                    ClassDt.Columns.Add("Ustat");
                    ClassDt.Columns.Add("Ucity");
                    ClassDt.Columns.Add("TeacherClass");//班主任
                    //ClassDt.Columns.Add("Teacher");//任课老师
                    ClassDt.Columns.Add("TeacherSub");//任课老师科目
                    SchSystem.BLL.SchClassUser scuBLL = new SchSystem.BLL.SchClassUser();
                    string sqlstr = "";
                    string sqlstrn = "";
                    if (!string.IsNullOrEmpty(txtname))
                    {
                        sqlstrn = " UserTname like '%" + Com.Public.SqlEncStr(txtname) + "%'";
                    }
                    string sqlstrs = "";
                    if (!string.IsNullOrEmpty(subcode))
                    {
                        sqlstrs = " SubCode='" + Com.Public.SqlEncStr(subcode) + "'";
                    }
                    if (sqlstrn != "" && sqlstrs != "")
                    {
                        sqlstr = " and ( " + sqlstrn + " or " + sqlstrs + ")";
                    }
                    else if (sqlstrn != "" || sqlstrs != "")
                    {
                        sqlstr = " and " + sqlstrn + sqlstrs;
                    }
                    for (int i = 0; i < ClassDt.Rows.Count; i++)
                    {
                        ClassDt.Rows[i]["Ustat"] = ClassDt.Rows[i]["IsFinish"].ToString() == "0" ? "正常" : "停用";
                        string ClassId = ClassDt.Rows[i]["ClassId"].ToString();
                        //班级教师（班主任)
                        ClassDt.Rows[i]["TeacherClass"] = scuBLL.GetNames("ClassId='" + ClassId + "' and IsMs=1" + sqlstr);
                        //任课老师
                        ClassDt.Rows[i]["TeacherSub"] = scuBLL.GetNames("ClassId='" + ClassId + "' and IsMs=0" + sqlstr);
                    }
                }
                ret = Newtonsoft.Json.JsonConvert.SerializeObject(ClassDt);
            }
            return ret;
        }
        [Serializable]
        private class gradsub
        {
            public string grade;
            public string subs;
            public DataTable schclass;
        }
        [Serializable]
        private class searchgradsub
        {
            public DataTable grade;
            public DataSet subs;
            public DataSet subtec;
        }
        [WebMethod]
        public static string getSearch(string schid, string gradecode, string subcode, string ustat)
        {
            schid = Com.Public.SqlEncStr(schid);
            gradecode = Com.Public.SqlEncStr(gradecode);
            subcode = Com.Public.SqlEncStr(subcode);
            ustat = Com.Public.SqlEncStr(ustat);
            string ret = "";
            if (Com.Session.userid == null)
            {
                ret = "expire";
            }
            else
            {
                try
                {
                    //年级
                    SchSystem.BLL.SchGradeInfo sgiBLL = new SchSystem.BLL.SchGradeInfo();
                    DataTable dtSchGrade = sgiBLL.GetList(" IsFinish=0 and SchId=" + schid + " order by GradeCode").Tables[0];//得到年级数据列表,并且是为非毕业的年级
                    //年级领导
                    SchSystem.BLL.SchGradeUsers sguBLL = new SchSystem.BLL.SchGradeUsers();
                    dtSchGrade.Columns.Add("GradeBoss");
                    if (dtSchGrade.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtSchGrade.Rows.Count; i++)
                        {
                            dtSchGrade.Rows[i]["GradeBoss"] = sguBLL.GetNames("GradeId=" + dtSchGrade.Rows[i]["GradeId"].ToString());
                        }
                    }
                    //grades = Newtonsoft.Json.JsonConvert.SerializeObject(dtSchGrade);
                    //当前学校所开设的科目
                    SchSystem.BLL.SchSub schsubBll = new SchSystem.BLL.SchSub();
                    DataSet dsSchSub = schsubBll.GetList("Stat=1 and SchId=" + schid);
                    //subs = Newtonsoft.Json.JsonConvert.SerializeObject(dsSchSub);
                    //获取科目教师
                    SchSystem.BLL.SchSubLeader scuBll = new SchSystem.BLL.SchSubLeader();
                    DataSet dssubUser = scuBll.GetListTecSub("*", "schid='" + schid + "' and Stat=1");
                    //subUser = Newtonsoft.Json.JsonConvert.SerializeObject(dssubUser);

                    searchgradsub ds = new searchgradsub();
                    ds.grade = dtSchGrade;
                    ds.subs = dsSchSub;
                    ds.subtec = dssubUser;
                    ret = Newtonsoft.Json.JsonConvert.SerializeObject(ds);
                }
                catch (Exception ex)
                {
                    ret = ex.Message;
                }
            }
            return ret;
        }
    }
}