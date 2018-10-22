using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWeb.SchoolBaxicInfo.GradeClassSet
{
    public partial class GradeClassInfo : System.Web.UI.Page
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
        public string subs = "";//相应学校科目表及个人科目,json
        public string depart = "";
        //需要根据不同情况建立或修改的不同学校用户和不同类型的用户,本学校用户唯一,不需要全系统唯一
        public string areastr = "";
        public string cotycode = "";
        public bool isAdd;
        public bool isUpdate;
        public bool isDelete;
        public bool isGradeAdd;
        public bool isGradeUpdate;
        public bool isGradeDelete;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //下面是年级操作按钮权限
                isGradeAdd = Com.Public.IsOne(Com.Session.userrolestr, 11)?true:false;//增加权限：true代表为有权限，false代表为无权限。班级的增加权限
                isGradeUpdate = Com.Public.IsOne(Com.Session.userrolestr, 8)?true:false;//修改权限：true代表为有权限，false代表为无权限。年级的修改权限
                isGradeDelete = Com.Public.IsOne(Com.Session.userrolestr, 9)?true:false;//删除权限：true代表为有权限，false代表为无权限。年级的删除权限
                //下面是班级操作按钮权限
                isAdd = Com.Public.IsOne(Com.Session.userrolestr, 11) ? true : false;//增加权限：true代表为有权限，false代表为无权限。
                isUpdate = Com.Public.IsOne(Com.Session.userrolestr, 12) ? true : false;//修改权限：true代表为有权限，false代表为无权限。
                isDelete = Com.Public.IsOne(Com.Session.userrolestr, 13) ? true : false;//删除权限：true代表为有权限，false代表为无权限。
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

            }
        }
        [WebMethod]
        public static string page(string txtname, string ustat, string cotycode, string schid, string gradeCode)
        {
            txtname = Com.Public.SqlEncStr(txtname);
            ustat = Com.Public.SqlEncStr(ustat);
            cotycode = Com.Public.SqlEncStr(cotycode);
            schid = Com.Public.SqlEncStr(schid);
            gradeCode = Com.Public.SqlEncStr(gradeCode);
            SchSystem.BLL.SchClassInfo sciBll = new SchSystem.BLL.SchClassInfo();
            if (schid == "")
                schid = "0";
            //IsFinish:毕业状态,0非,1是,2被删除,正常界面不显示删除,超管界面可以考虑
            string strwhere = "IsFinish = 0 and SchId = '" + Com.Public.SqlEncStr(schid) + "'";
            if (!string.IsNullOrEmpty(ustat))
            {
                strwhere += " and IsFinish=" + Com.Public.SqlEncStr(ustat);
            }
            if (!string.IsNullOrEmpty(gradeCode)||gradeCode != "")
            {
                strwhere += " and GradeCode='" + Com.Public.SqlEncStr(gradeCode) + "'";
            }
            int rowc = 0;
            int pc = 0;
            //DataTable dt = userbll.GetListCols("*", strwhere, "SchName", "ASC", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
            DataTable ClassDt = sciBll.GetList(strwhere).Tables[0];//得到班级数据列表
            //pages.PageCount = pc;
            if (ClassDt.Rows.Count > 0)
            {
                ClassDt.Columns.Add("Ustat");
                ClassDt.Columns.Add("Ucity");
                ClassDt.Columns.Add("TeacherClass");//班主任
                //ClassDt.Columns.Add("Teacher");//任课老师
                ClassDt.Columns.Add("TeacherSub");//任课老师科目
                SchSystem.BLL.SchClassUser scuBLL = new SchSystem.BLL.SchClassUser();
                for (int i = 0; i < ClassDt.Rows.Count; i++)
                {
                    ClassDt.Rows[i]["Ustat"] = ClassDt.Rows[i]["IsFinish"].ToString() == "0" ? "正常" : "停用";
                    string ClassId = ClassDt.Rows[i]["ClassId"].ToString();
                    //班级教师（班主任)
                    ClassDt.Rows[i]["TeacherClass"] = scuBLL.GetNames("ClassId='" + ClassId + "' and Stat=1 and IsMs=1");
                    //任课老师
                    ClassDt.Rows[i]["TeacherSub"] = scuBLL.GetNames("ClassId='" + ClassId + "' and Stat=1 and IsMs=0");
                }
                //pages.list = ClassDt;
            }
            //Newtonsoft.Json.JsonConvert();
            //string ddd = Newtonsoft.Json.JsonConvert.SerializeObject(pages);
            //string ddd = Newtonsoft.Json.JsonConvert.SerializeObject(ClassDt);
            return Newtonsoft.Json.JsonConvert.SerializeObject(ClassDt);
        }
        [WebMethod]
        public static string udel(string type,string schid,string gradeid,string classid)
        {
            schid = Com.Public.SqlEncStr(schid);
            gradeid = Com.Public.SqlEncStr(gradeid);
            classid = Com.Public.SqlEncStr(classid);
            string ret = "";
            try
            {
                if (!Com.Public.IsOne(Com.Session.userrolestr, 13))
                {
                  return  ret = "无操作权限";
                }
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
                        SchSystem.Model.SchClassInfo classmodel = new SchSystem.Model.SchClassInfo();
                        classmodel.ClassId = int.Parse(classid);
                        classmodel.IsFinish = 2;
                        classmodel.LastRecTime = DateTime.Now;
                        classmodel.LastRecUser = Com.Session.userid;
                        if (classbll.UpdateStat(classmodel))
                        {
                            ret = "success";
                        }
                        else
                        {
                            ret = "操作失败";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }

            return ret;
        }
        [WebMethod]
        public static string getarea(string typecode, string pcode)
        {
            typecode = Com.Public.SqlEncStr(typecode);
            pcode = Com.Public.SqlEncStr(pcode);
            string ret = "";
            try
            {

                string selp = "";
                if (typecode != "4")
                    ret = Com.Public.GetDrpArea(typecode, pcode, ref selp, false);
                else ret = Com.Public.GetDrp("dpt", pcode, "1", true, "", "");
            }
            catch (Exception ex)
            {
                ret = "";
            }
            return ret;
        }
    }
}