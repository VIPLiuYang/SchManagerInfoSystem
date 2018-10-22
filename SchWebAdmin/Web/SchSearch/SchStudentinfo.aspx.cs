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

namespace SchWebAdmin.Web.SchSearch
{
    public partial class SchStudentinfo : System.Web.UI.Page
    {
        public string schid;
        public string areastr = "";
        public static string njld = "";//年级领导
        public static string bjjs = "";//班级老师
        public static string bzr = "";//班主任
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (Request.Params["schid"] != null && Request.Params["schid"].ToString() != "")
                {
                    schid = Com.Public.SqlEncStr(Request.Params["schid"].ToString());
                }
                njld = ""; bzr = ""; bjjs = "";
                StringBuilder sbarea = new StringBuilder();
                //获取年级
                sbarea.Append("<br/>年级:<select id=\"nj\" style=\"width:100px\">");
                string schcode = "-1";//默认为“全部”时，值为“-1”
                sbarea.Append(Com.Public.GetDrpAreaStu("4", schid, ref schcode, true));
                sbarea.Append("</select>&nbsp;&nbsp;&nbsp;&nbsp;");

                sbarea.Append("<span id=\"njld\" style=\"color:	#808080	\">年级领导：" + njld + "</span><br/><br/>");
                //获取班级
                sbarea.Append("班级:<select id=\"bj\" style=\"width:100px\" >");
                string Classcode = "";
                sbarea.Append(Com.Public.GetDrpAreaStu("5", "", ref Classcode, true));
                sbarea.Append("</select>&nbsp;&nbsp;&nbsp;&nbsp;");
                sbarea.Append("<span id=\"bzr\" style=\"color:	#808080	\">班主任：" + bzr + "</span>&nbsp;&nbsp; ");
                sbarea.Append("<span id=\"bjjs\" style=\"color:	#808080	\">任课老师：" + bjjs + "</span><br/><br/>");
                string s = getnj("1", schcode, schid, Classcode);
                areastr = sbarea.ToString();
            
        }

        public class namepack
        {
            public string gradeboss = "";
            public string classms = "";
            public string classtec = "";
        }
        [WebMethod]
        public static string page(string PageIndex, string PageSize, string ClassId, string SchId, string Stuname, string GradeId)
        {

            Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
            pages.PageIndex = int.Parse(PageIndex);
            pages.PageSize = int.Parse(PageSize);
            SchSystem.BLL.SchClassUser bllclassuser = new SchSystem.BLL.SchClassUser();
            SchSystem.BLL.SchGradeUsers bllgradeuser = new SchSystem.BLL.SchGradeUsers();
            string strWhere = "StuStat=1 and SchId=" + Com.Public.SqlEncStr(SchId);
            if (!string.IsNullOrEmpty(Stuname))
                strWhere += " and stuname LIKE '%" + Com.Public.SqlEncStr(Stuname) + "%'";
            if (GradeId != "-1" && GradeId != "")//获取当前用户的所有年级
            {
                strWhere += " and GradeId=" + Com.Public.SqlEncStr(GradeId);
            }
            if (ClassId != "-1" && ClassId != "")//获取当前用户的所有班级
            {
                strWhere += " and ClassId=" + Com.Public.SqlEncStr(ClassId);
            }
            int RowCount = 0; int PageCount = 0;//left('00000000',8-len(StuId))+convert(varchar(10),StuId)
            string cols = "  GradeId,ClassId,GradeName,ClassName,StuId,TestNo,StuName,CardNo,Sex,StuNo,TelNo,StudyType,LoginName,'' GenNameO,'' GenLoginNameO ,'' GenTelO,'' GenNameT,'' GenLoginNameT ,'' GenTelT,'0' isdel,'0' isedit,'0' islook";
            SchSystem.BLL.SchStuInfoV bllstuv = new SchSystem.BLL.SchStuInfoV();
            DataTable dtstuv = bllstuv.GetListCols(cols, strWhere, "StuName", "ASC", pages.PageIndex, pages.PageSize, ref RowCount, ref PageCount).Tables[0];
            pages.PageCount = PageCount;
            pages.RowCount = RowCount;
            if (dtstuv != null && dtstuv.Rows.Count > 0)
            {
                SchSystem.BLL.SchStuGenUV bllstugenv = new SchSystem.BLL.SchStuGenUV();
                for (int i = 0; i < dtstuv.Rows.Count; i++)//将家长添加上,并且把权限加上
                {
                    //获取家长
                    DataTable dtgenv = bllstugenv.GetList("GenName,LoginName,TelNo,Relation", "Stat=1 and StuId=" + dtstuv.Rows[i]["StuId"].ToString()).Tables[0];
                    if (dtgenv != null && dtgenv.Rows.Count > 0)
                    {
                        dtstuv.Rows[i]["GenNameO"] = dtgenv.Rows[0]["GenName"].ToString();
                        dtstuv.Rows[i]["GenTelO"] = dtgenv.Rows[0]["TelNo"].ToString();
                        dtstuv.Rows[i]["GenLoginNameO"] = dtgenv.Rows[0]["LoginName"].ToString();
                        if (dtgenv.Rows.Count > 1)
                        {
                            dtstuv.Rows[i]["GenNameT"] = dtgenv.Rows[1]["GenName"].ToString();
                            dtstuv.Rows[i]["GenTelT"] = dtgenv.Rows[1]["TelNo"].ToString();
                            dtstuv.Rows[i]["GenLoginNameT"] = dtgenv.Rows[1]["LoginName"].ToString();
                        }
                    }

                    pages.list = dtstuv;

                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(pages);

        }

        [WebMethod]
        public static string getnj(string typecode, string pcode, string schid, string classid)
        {
            string ret = "";
            if (Com.Session.userid == null)
            {
                ret = "expire";
            }
            else
            {
                if (pcode == "null")
                {
                    pcode = "0";
                }
                if (schid == "undefined")
                {
                    schid = Com.Session.schid;
                }
                schid = Com.Public.SqlEncStr(schid);
                typecode = Com.Public.SqlEncStr(typecode);
                string ClassId = "";
                SchSystem.BLL.SchGradeUsers sguBLL = new SchSystem.BLL.SchGradeUsers();
                SchSystem.BLL.SchClassUser scuBLL = new SchSystem.BLL.SchClassUser();
                namepack np = new namepack();

                if (typecode == "1")//1为获取年级领导
                {
                    string GradeCode = Com.Public.SqlEncStr(pcode);
                    string sql1 = "";
                    string sql2 = "";
                    if (Com.Session.systype != "2")//判断是否是超管
                    {
                        sql1 = "select GradeId from dbo.SchGradeInfo where GradeId='" + GradeCode + "' and SchId='" + Com.Session.schid + "'";
                        sql2 = "select *  FROM SchClassGradeV  where IsFinish<>2 and SchId='" + Com.Session.schid + "' and IsFinish=0 and GradeId='" + GradeCode + "' and ClassId='" + classid + "' order by GradeCode,ClassName	";
                    }
                    else
                    {
                        sql1 = "select GradeId from dbo.SchGradeInfo where GradeId='" + GradeCode + "'  and SchId='" + schid + "'";
                        sql2 = "select *  FROM SchClassGradeV  where IsFinish<>2 and SchId='" + schid + "' and IsFinish=0 and GradeId='" + GradeCode + "' and ClassId='" + classid + "' order by GradeCode,ClassName	";
                    }

                    DataTable dt1 = DbHelperSQL.Query(sql1).Tables[0];
                    if (dt1.Rows.Count > 0)
                    {
                        string GradeId = dt1.Rows[0]["GradeId"].ToString();
                        DataTable dt2 = DbHelperSQL.Query(sql2).Tables[0];
                        njld = np.gradeboss = sguBLL.GetNames("GradeId='" + GradeId + "'");
                        if (dt2.Rows.Count != 0)
                        {
                            ClassId = dt2.Rows[0]["ClassId"].ToString();
                            bzr = np.classms = scuBLL.GetNames("ClassId='" + ClassId + "' and IsMs=1");
                            bjjs = np.classtec = scuBLL.GetNames("ClassId='" + ClassId + "' and IsMs=0");
                        }
                    }
                }
                else//侧为获取班主任和任课老师
                {
                    np.classms = scuBLL.GetNames("ClassId='" + Com.Public.SqlEncStr(pcode) + "' and IsMs=1  and SchId='" + schid + "'");
                    np.classtec = scuBLL.GetNames("ClassId='" + Com.Public.SqlEncStr(pcode) + "' and IsMs=0 and SchId='" + schid + "'");
                }

                ret = Newtonsoft.Json.JsonConvert.SerializeObject(np);
            }
            return ret;
        }
       
    }
}