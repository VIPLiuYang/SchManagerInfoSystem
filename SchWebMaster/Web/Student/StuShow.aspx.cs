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

namespace SchWebMaster.Web.Student
{
    public partial class StuShow : System.Web.UI.Page
    {

        public string stuname;
        public string stugrade;
        public string stugradeboss;
        public string stuclass;
        public string stuclassms;
        public string stuclasstec;

        public string stuid;
        public string stucode;
        public string stusex;
        public string stucard;
        public string stutel;
        public string stuaddr;
        public string stustp;
        public string stuocls;
        public string stug1name;
        public string stug1rl;
        public string stug1rt;
        public string stug2name;
        public string stug2rl;
        public string stug2rt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                stuid = Request.Params["id"].ToString();//

                SchSystem.BLL.SchStuInfoV bll_stu = new SchSystem.BLL.SchStuInfoV();
                DataTable dt = bll_stu.GetList("GradeId,GradeName,ClassId,ClassName,StuId,StuName,CardNo,StuNo,Sex,OldClassId,TestNo,TelNo,StudyType,Addr", "StuId=" + Com.Public.SqlEncStr(stuid)).Tables[0];

                string gradeid = dt.Rows[0]["GradeId"].ToString();
                string classid = dt.Rows[0]["ClassId"].ToString();
                stuname = dt.Rows[0]["StuName"].ToString();
                stugrade = dt.Rows[0]["GradeName"].ToString();
                stuclass = dt.Rows[0]["ClassName"].ToString();
                stucode = dt.Rows[0]["TestNo"].ToString();
                stusex = dt.Rows[0]["Sex"].ToString() == "0" ? "女" : "男";
                stucard = dt.Rows[0]["CardNo"].ToString();
                stutel = dt.Rows[0]["TelNo"].ToString();
                stuaddr = dt.Rows[0]["Addr"].ToString();
                stustp = dt.Rows[0]["StudyType"].ToString() == "0" ? "否" : "是"; ;
                stuocls = dt.Rows[0]["OldClassId"].ToString();
                SchSystem.BLL.SchStuGenUV bll_stugen = new SchSystem.BLL.SchStuGenUV();
                DataTable dtgen = bll_stugen.GetList("Relation,GenName,TelNo", "StuId=" + Com.Public.SqlEncStr(stuid)).Tables[0];
                if (dtgen != null && dtgen.Rows.Count > 0)
                {
                    stug1name = dtgen.Rows[0]["GenName"].ToString();
                    stug1rl = dtgen.Rows[0]["Relation"].ToString();
                    stug1rt = dtgen.Rows[0]["TelNo"].ToString();
                    if (dtgen.Rows.Count > 1)
                    {
                        stug2name = dtgen.Rows[1]["GenName"].ToString();
                        stug2rl = dtgen.Rows[1]["Relation"].ToString();
                        stug2rt = dtgen.Rows[1]["TelNo"].ToString();
                    }
                }
                StudentList.namepack npgrade = (StudentList.namepack)Newtonsoft.Json.JsonConvert.DeserializeObject<StudentList.namepack>(getusers("1", gradeid));
                stugradeboss = npgrade.gradeboss;
                StudentList.namepack np = (StudentList.namepack)Newtonsoft.Json.JsonConvert.DeserializeObject<StudentList.namepack>(getusers("2", classid));
                stuclassms = np.classms;
                stuclasstec = np.classtec;
                stuid = "00000000".Substring(0, 8 - stuid.Length) + stuid;
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