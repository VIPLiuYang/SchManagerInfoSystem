using SchManagerInfoSystem.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWeb.SchoolBaxicInfo.Student
{
    public partial class StuShow : System.Web.UI.Page
    {
        public string umodelstr = "1";//学校model
        public static string oldClassName = "";//原班级名称
        public string Stubh;
        public string areastr = "";
        public string schid = "0";//学校id
        public static string njld = "";//年级领导
        public static string bjjs = "";//班级老师
        public static string bzr = "";//班主任
        public static string gradecodestr = "";
        public static string classidstr = "";
        SchManagerInfoSystem.Common.DttoJson dttojson = new SchManagerInfoSystem.Common.DttoJson();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                string dotype = Request.Params["dotype"].ToString();
                var gradeid = Request.Params["gradecode"].ToString();
                var classid = Request.Params["classid"].ToString();
                if (dotype == "c")
                {
                    Stubh = Request.Params["Stubh"].ToString();
                    string stuid = Request.Params["id"].ToString();
                    string sql = "select * from SchStuInfoV where StuId='" + stuid + "' ";//根据学生ID查询出学校，年级，班级等信息
                    dt = DbHelperSQL.Query(sql).Tables[0];
                    if (gradeid == "")
                    {
                        gradeid = dt.Rows[0]["GradeId"].ToString();
                    }
                    if (classid == "")
                    {
                        classid = dt.Rows[0]["ClassId"].ToString();
                    }
                    DataRow[] drr = dt.Select();
                    string oldclassname = drr[0]["OldClassId"].ToString();
                    if (!string.IsNullOrEmpty(oldclassname) || oldclassname != "")
                    {
                        oldClassName = oldclassname;
                    }
                    else
                    {
                        oldClassName = "";
                    }
                    SchSystem.BLL.SchStuInfo bll_stu = new SchSystem.BLL.SchStuInfo();
                    string strWhere = " a.StuId=" + stuid;
                    DataSet ds = bll_stu.GetList(strWhere);//修改绑定需要的数据
                    ds.Tables[0].Columns.Add("jzGenName2");
                    ds.Tables[0].Columns.Add("jzLoginName2");
                    ds.Tables[0].Columns.Add("jzTelNo2");
                    ds.Tables[0].Columns.Add("jzPwd2");
                    ds.Tables[0].Columns.Add("jzStat2");
                    ds.Tables[0].Columns.Add("jzRelation2");
                    ds.Tables[0].Columns.Add("jzGenId2");
                    ds.Tables[0].Columns.Add("jzUnId2");
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            for (int j = i + 1; j < ds.Tables[0].Rows.Count; j++)
                            {
                                if (ds.Tables[0].Rows[i]["StuId"].ToString() == ds.Tables[0].Rows[j]["StuId"].ToString())
                                {
                                    ds.Tables[0].Rows[i]["jzGenName2"] = ds.Tables[0].Rows[j]["jzGenName1"].ToString();
                                    ds.Tables[0].Rows[i]["jzLoginName2"] = ds.Tables[0].Rows[j]["jzLoginName1"].ToString();
                                    ds.Tables[0].Rows[i]["jzTelNo2"] = ds.Tables[0].Rows[j]["jzTelNo1"].ToString();
                                    ds.Tables[0].Rows[i]["jzPwd2"] = ds.Tables[0].Rows[j]["jzPwd1"].ToString();
                                    ds.Tables[0].Rows[i]["jzStat2"] = ds.Tables[0].Rows[j]["jzStat1"].ToString();
                                    ds.Tables[0].Rows[i]["jzRelation2"] = ds.Tables[0].Rows[j]["jzRelation1"].ToString();
                                    ds.Tables[0].Rows[i]["jzGenId2"] = ds.Tables[0].Rows[j]["jzGenId1"].ToString();
                                    ds.Tables[0].Rows[i]["jzUnId2"] = ds.Tables[0].Rows[j]["jzUnId1"].ToString();
                                    ds.Tables[0].Rows.RemoveAt(j);
                                }
                            }
                        }
                    }
                    #region 缺省值：年級領導、班主任和任課教師
                    SchSystem.BLL.SchGradeUsers sgiBll = new SchSystem.BLL.SchGradeUsers();
                    SchSystem.BLL.SchClassUser scuBll = new SchSystem.BLL.SchClassUser();
                    DataTable dtgradeuser = sgiBll.GetList("*", "GradeId='" + gradeid + "'").Tables[0];
                    if (dtgradeuser.Rows.Count > 0)
                    {
                        StringBuilder sbgradeuser = new StringBuilder();
                        foreach (DataRow dr in dtgradeuser.Rows)
                        {
                            sbgradeuser.Append(dr["UserTname"].ToString() + ",");
                        }
                        if (sbgradeuser.ToString().Length > 0)
                        {
                            njld = sbgradeuser.ToString().Substring(0, sbgradeuser.ToString().Length - 1);//年級領導
                        }
                    }
                    DataTable dtclassuser = scuBll.GetList("*", "ClassId='" + classid + "'").Tables[0];
                    if (dtclassuser.Rows.Count > 0)
                    {
                        StringBuilder sbgradeuser01 = new StringBuilder();
                        StringBuilder sbgradeuser02 = new StringBuilder();
                        foreach (DataRow dr in dtclassuser.Rows)
                        {
                            if (dr["IsMs"].ToString() == "1")
                            {
                                sbgradeuser01.Append(dr["UserTname"].ToString() + ",");
                            }
                            else
                            {
                                sbgradeuser02.Append(dr["UserTname"].ToString() + ",");
                            }
                        }
                        if (sbgradeuser01.ToString().Length > 0)
                        {
                            bzr = sbgradeuser01.ToString().Substring(0, sbgradeuser01.ToString().Length - 1);//班主任
                        }
                        if (sbgradeuser02.ToString().Length > 0)
                        {
                            bjjs = sbgradeuser02.ToString().Substring(0, sbgradeuser02.ToString().Length - 1);//任課教師
                        }
                    }
                    #endregion
                    StringBuilder sbarea = new StringBuilder();

                    //获取年级
                    sbarea.Append("<br/> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;年级：<select id=\"nj\" style=\"width:100px\" disabled=\"disabled\">");

                    sbarea.Append(Com.Public.GetDrpAreaShow("4", Com.Session.schid, ref gradeid, false));
                    sbarea.Append("</select>&nbsp;&nbsp;&nbsp;&nbsp;");
                    //获取年级主任
                    StudentList.namepack npgrade = (StudentList.namepack)Newtonsoft.Json.JsonConvert.DeserializeObject<StudentList.namepack>(getusers("1", gradeid));
                    sbarea.Append("<span id=\"njld\" style=\"color:	#808080	\">年级领导：" + npgrade.gradeboss + "</span><br/><br/>");
                    //获取班级
                    sbarea.Append(" &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;班级：<select id=\"bj\" style=\"width:100px\" disabled=\"disabled\" >");

                    sbarea.Append(Com.Public.GetDrpAreaShow("5", gradeid, ref classid, false));
                    sbarea.Append("</select>&nbsp;&nbsp;&nbsp;&nbsp;");
                    //获取班主任及任课老师
                    StudentList.namepack np = (StudentList.namepack)Newtonsoft.Json.JsonConvert.DeserializeObject<StudentList.namepack>(getusers("2", classid));
                    sbarea.Append("<span id=\"bzr\" style=\"color:	#808080	\">班主任：" + np.classms + "</span>&nbsp;&nbsp; ");
                    sbarea.Append("<span id=\"bjjs\" style=\"color:	#808080	\">任课老师：" + np.classtec + "</span><br/><br/>");
                  
                    areastr = sbarea.ToString();

                    umodelstr = dttojson.DatSetToJSON2(ds); ;
                }
            }
        }
        [WebMethod]
        public static string getusers(string tp, string id)
        {
            StudentList.namepack np = new StudentList.namepack();
            if (Com.Public.IsNum(id))
            {
                if (tp == "1")//获取年级主任
                {
                    SchSystem.BLL.SchGradeUsers sguBLL = new SchSystem.BLL.SchGradeUsers();
                    np.gradeboss = sguBLL.GetNames("GradeId=" + Com.Public.SqlEncStr(id));
                }
                else
                {
                    SchSystem.BLL.SchClassUser scuBLL = new SchSystem.BLL.SchClassUser();
                    np.classms = scuBLL.GetNames("ClassId=" + Com.Public.SqlEncStr(id) + " and IsMs=1");
                    np.classtec = scuBLL.GetNames("ClassId=" + Com.Public.SqlEncStr(id) + " and IsMs=0");
                }
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(np);
        }        
    }
}