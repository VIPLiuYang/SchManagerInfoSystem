﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWeb.SchoolBaxicInfo.SubLeader
{
    public partial class SubLeaderInfo : System.Web.UI.Page
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
        public bool isadd;
        public bool isedit;
        public bool isdel;
        public bool islook;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Com.Session.systype == "1" || Com.Session.systype == "2")//超级管理员和学校管理员
                {
                    islook = true;
                    if (Com.Session.appeditstat == "0" && Com.Session.systype == "1")
                    {
                        isadd = false;
                        isedit = false;
                        isdel = false;
                    }
                    else
                    {
                        isadd = true;
                        isedit = true;
                        isdel = true;
                    }
                }
                else//普通老师
                {
                        isadd = false;
                        isedit = false;
                        isdel = false;
                    islook =true;//学科/年级/班级任课权限
                }
                //isGradeClassAuth = Com.Public.IsUserVal(Com.Session.userrolestr, 2) ? true : false;//学科/年级/班级任课权限

                //不是超管获取本学校的
                if (Com.Session.systype != "2")
                {
                    schid = Com.Session.schid;
                }
                else//超管还要加省市区学校下拉,后面需要更改
                {
                    //第一次加载,获取省市区,获取第一个省份下的所有学校
                    StringBuilder sbarea = new StringBuilder();
                    //获取省份
                    sbarea.Append("省:<select id=\"aprov\">");
                    string sareacode = "";
                    sbarea.Append(Com.Public.GetDrpArea("0", "", ref sareacode, false));
                    sbarea.Append("</select>");
                    //获取城市
                    sbarea.Append("市:<select id=\"acity\">");
                    string sareacitycode = "";
                    sbarea.Append(Com.Public.GetDrpArea("1", sareacode, ref sareacitycode, false));
                    sbarea.Append("</select>");
                    //获取区县
                    sbarea.Append("区:<select id=\"acoty\">");
                    string sareacotycode = "";
                    sbarea.Append(Com.Public.GetDrpArea("2", sareacitycode, ref sareacotycode, false));
                    cotycode = sareacotycode;
                    sbarea.Append("</select>");
                    sbarea.Append("学校:<select id=\"asch\">");
                    string sareaschid = "";
                    sbarea.Append(Com.Public.GetDrpArea("3", sareacotycode, ref sareaschid, false));
                    if (sareaschid != "")
                    {
                        schid = sareaschid;
                    }
                    sbarea.Append("</select>");
                    areastr = sbarea.ToString();
                    systype = Com.Session.systype;

                }
                //当前学校年级:IsFinish状态，1代表已毕业；0代表未毕业
               // SchSystem.BLL.SchGradeInfo sgiBll = new SchSystem.BLL.SchGradeInfo();
                //DataSet dsSchGrade = sgiBll.GetList("IsFinish=0 and SchId=" + schid);
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
                DataSet dsSchSub = schsubBll.GetList("Stat=1 and SchId='" + schid+"'");
                subs = Newtonsoft.Json.JsonConvert.SerializeObject(dsSchSub);
                //获取科目教师
                SchSystem.BLL.SchSubLeader scuBll = new SchSystem.BLL.SchSubLeader();
                DataSet dssubUser = scuBll.GetListTecSub("*", "schid='"+schid+"' and Stat=1");
                subUser = Newtonsoft.Json.JsonConvert.SerializeObject(dssubUser);
                //subUser
                //当前学校的教师
                SchSystem.BLL.SchUserInfo suiBll = new SchSystem.BLL.SchUserInfo();
                DataSet dsSUI = suiBll.GetList("*","Stat=1 and SchId='" + schid+"'");
                tecs = Newtonsoft.Json.JsonConvert.SerializeObject(dsSUI);

            }
        }
        [Serializable]
        private class pages
        {
            public DataTable pagelist;
            public bool isadd;
            public bool isdel;
            public bool isedit;
            public bool islook;
        }
        [WebMethod]
        public static string page(string txtname, string ustat, string cotycode, string schid, string gradeCode,string classid,string subcode)
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
                string strwhere = "ClassStat=0 and SchId = '" + Com.Public.SqlEncStr(schid) + "'";
                if (!string.IsNullOrEmpty(ustat))
                {
                    strwhere += " and IsFinish=" + Com.Public.SqlEncStr(ustat);
                }
                else
                {
                    strwhere += " and IsFinish=0";
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
                int rowc = 0;
                int pc = 0;
                //DataTable dt = userbll.GetListCols("*", strwhere, "SchName", "ASC", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
                DataTable ClassDt = sciBll.GetListV(strwhere + " order by GradeCode,ClassName").Tables[0];//得到班级数据列表
                //pages.PageCount = pc;
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
                        ClassDt.Rows[i]["Ustat"] = ClassDt.Rows[i]["IsFinish"].ToString() == "0" ? "正常" : "毕业";
                        string ClassId = ClassDt.Rows[i]["ClassId"].ToString();
                        string sss = scuBLL.GetNames("ClassId='" + ClassId + "'and IsMs=1");
                        //班级教师（班主任)
                        ClassDt.Rows[i]["TeacherClass"] = scuBLL.GetNames("ClassId='" + ClassId + "' and IsMs=1 " + sqlstr);
                        //任课老师
                        ClassDt.Rows[i]["TeacherSub"] = scuBLL.GetNames("ClassId='" + ClassId + "' and IsMs=0 " + sqlstr);
                    }
                    //pages.list = ClassDt;
                }
                ret = Newtonsoft.Json.JsonConvert.SerializeObject(ClassDt);
            }
            return ret;
        }
        [WebMethod]
        public static string udel(string type, string schid, string gradeid, string classid)
        {            
            schid = Com.Public.SqlEncStr(schid);
            gradeid = Com.Public.SqlEncStr(gradeid);
            classid = Com.Public.SqlEncStr(classid);
            string ret = "";
            if (Com.Session.userid == null)
            {
                ret = "expire";
            }
            else
            {
                try
                {
                    if (!Com.Public.isVa(schid, ""))
                    {
                        return ret = "无跨界权限";
                    }
                    if (schid == Com.Public.getKey("adminschid"))
                    {
                        ret = "此为系统学校,不允许操作";
                    }
                    else
                    {
                        if (type == "1")//删除年级
                        {
                            SchSystem.BLL.SchGradeInfo bll = new SchSystem.BLL.SchGradeInfo();
                            SchSystem.Model.SchGradeInfo model = new SchSystem.Model.SchGradeInfo();
                            model.GradeId = int.Parse(gradeid);
                            model.IsFinish = 2;
                            model.LastRecTime = DateTime.Now;
                            model.LastRecUser = Com.Session.userid;
                            if (bll.UpdateStat(model))
                            {
                                ret = "success";
                            }
                            else
                            {
                                ret = "操作失败";
                            }
                        }
                        else if (type == "0")//删除班级
                        {
                            SchSystem.BLL.SchClassInfo classbll = new SchSystem.BLL.SchClassInfo();
                            bool resultBool = classbll.ExistsClassStuData(int.Parse(classid));
                            SchSystem.BLL.SchClassUser classuserbll = new SchSystem.BLL.SchClassUser();
                            bool resultBoolUser = classuserbll.ExistsClassUser(schid,classid);
                            if (resultBool || resultBoolUser)//如果为true说明是班级内有属性数据
                            {
                                ret = "success01";
                            }
                            else//否则即可删除班级记录
                            {
                                SchSystem.Model.SchClassInfo classmodel = new SchSystem.Model.SchClassInfo();
                                classmodel.ClassId = int.Parse(classid);
                                classmodel.IsFinish = 2;
                                classmodel.LastRecTime = DateTime.Now;
                                classmodel.LastRecUser = Com.Session.userid;
                                if (classbll.UpdateStat(classmodel))
                                {
                                    SchSystem.BLL.SchClassUser scuBll = new SchSystem.BLL.SchClassUser();
                                    // bool ecu = scuBll.ExistsClassUser(int.Parse(schid), int.Parse(classid));
                                    bool scubool = scuBll.Delete(classid, schid);
                                    //if (scubool)
                                    // {
                                    ret = "success";
                                    //}
                                }
                                else
                                {
                                    ret = "操作失败";
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ret = ex.Message;
                }
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
        [WebMethod]
        public static string getarea(string typecode, string pcode, string ustat, string gradecode)
        {
            typecode = Com.Public.SqlEncStr(typecode);
            pcode = Com.Public.SqlEncStr(pcode);
            ustat = Com.Public.SqlEncStr(ustat);
            gradecode = Com.Public.SqlEncStr(gradecode);
            string ret = "";
            if (Com.Session.userid == null)
            {
                ret = "expire";
            }
            else
            {
                try
                {

                    string selp = "";
                    if (typecode != "4")
                    {
                        ret = Com.Public.GetDrpArea(typecode, pcode, ref selp, false);
                    }
                    else
                    {
                        SchSystem.BLL.SchClassInfo sciBll = new SchSystem.BLL.SchClassInfo();
                        string strWhere = " IsFinish=0 ";
                        if (pcode != "")
                        {
                            strWhere += " and Schid=" + pcode;
                        }
                        if (gradecode != "" || gradecode != "0")
                        {
                            strWhere += " and GradeId='" + gradecode+"'";
                        }
                        //获取科目组长
                        SchSystem.BLL.SchSubLeader scuBll = new SchSystem.BLL.SchSubLeader();
                        DataTable dssubUser = scuBll.GetListTecSub("*", "schid='" + pcode + "' and Stat=1").Tables[0];

                        DataTable scids = sciBll.GetList("ClassId,ClassName", strWhere).Tables[0];
                        //scids.Select();
                        gradsub ds = new gradsub();
                        ds.grade = Com.Public.GetDrp("grade", pcode, ustat, true, "", "");//是否已毕业,1毕业,0未毕业
                        ds.subs = Com.Public.GetDrp("sub", pcode, "1", true, "", "");
                        ds.schclass = scids;
                        ret = Newtonsoft.Json.JsonConvert.SerializeObject(ds);
                        //ret = Com.Public.GetDrp("sub", Com.Public.SqlEncStr(pcode), "1", true, "", "");
                    }
                }
                catch (Exception ex)
                {
                    ret = "";
                }
            }
            return ret;
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