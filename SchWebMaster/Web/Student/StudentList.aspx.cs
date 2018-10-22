using SchManagerInfoSystem.Common;
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

namespace SchWebMaster.Web.Student
{
    public partial class StudentList : System.Web.UI.Page
    {
        public string dptdrp = "";
        public string areastr = "";
        public string schid = "0";
        public bool isadd;
        #region 初始化加载方法
        protected void Page_Load(object sender, EventArgs e)
        {
            SchSystem.BLL.SchStuInfo stuinfo = new SchSystem.BLL.SchStuInfo();
            if (!IsPostBack)
            {
                //权限组的增删改
                if (Com.Session.systype == "1")//超级管理员和学校管理员
                {
                    if (Com.Session.appeditstat == "0")// && Com.Session.systype == "1"
                    {
                        isadd = false;                      
                    }
                    else
                    {
                        isadd = true;
                    }
                }

                #region 学校管理员方法
                if (Com.Session.systype == "1")
                {
                    schid = Com.Session.schid;
                    StringBuilder sbarea = new StringBuilder();
                    //获取年级
                    sbarea.Append("年级:<select id=\"nj\" style=\"width:100px\">");
                    string schcode = "";
                    sbarea.Append(Com.Public.GetDrpAreaStu("4", Com.Session.schid, ref schcode, true));
                   
                    sbarea.Append("</select>&nbsp;&nbsp;&nbsp;&nbsp;");
                    sbarea.Append("<span id=\"njld\" style=\"color:	#808080	\">年级领导：</span><br/>");
                    sbarea.Append("<div class=\"space-4\"></div>");
                    //获取班级
                    sbarea.Append("班级:<select id=\"bj\" style=\"width:100px\" >");
                    string Classcode = "";
                    sbarea.Append(Com.Public.GetDrpAreaStu("5", "", ref Classcode, true));
                    sbarea.Append("</select>&nbsp;&nbsp;&nbsp;&nbsp;");
                    sbarea.Append("<span id=\"bzr\" style=\"color:	#808080	\">班主任：</span>&nbsp;&nbsp; ");
                    sbarea.Append("<span id=\"bjjs\" style=\"color:	#808080	\">任课老师：</span>");
                    
                    areastr = sbarea.ToString();
                }
                #endregion
                
            }
        }
        #endregion
        #region 获取年级领导/班主任/任课老师
        public class namepack
        {
            public string gradeboss = "";
            public string classms = "";
            public string classtec = "";
        }
        [WebMethod]
        public static string page(string PageIndex, string PageSize, string ClassId, string SchId, string Stuname, string GradeId)
        {
            string ret = "";
            if (Com.Session.userid == null)
            {
                ret = "expire";
            }
            else
            {
                bool islist = false;
                Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
                pages.PageIndex = int.Parse(PageIndex);
                pages.PageSize = int.Parse(PageSize);
                SchSystem.BLL.SchClassUser bllclassuser = new SchSystem.BLL.SchClassUser();
                SchSystem.BLL.SchGradeUsers bllgradeuser = new SchSystem.BLL.SchGradeUsers();
                #region 添加按钮和列表显示权限
                pages.isadd = false;
                if (Com.Session.systype == "1")//学校超管
                {
                    islist = true;
                    if (Com.Session.appeditstat == "0" || GradeId == "-1" || ClassId == "-1" || GradeId == "" || ClassId == "")//系统编辑状态为0,或者年级,班级其中一个选择了全部,则不允许出现添加按钮
                    {
                        pages.isadd = false;
                    }
                    else
                    {
                        pages.isadd = true;
                    }

                }
                else//普通老师账号
                {

                    if (bllclassuser.ExistsIsMs(Com.Public.SqlEncStr(ClassId), Com.Session.usertid, Com.Session.schid, 1) == true)//班主任
                    {
                        if (Com.Session.appeditstat == "1")
                        {
                            pages.isadd = true;
                        }
                        islist = true;
                    }
                    else
                    {
                        pages.isadd = false;
                        if (bllgradeuser.ExistsGrade(Com.Public.SqlEncStr(GradeId), Com.Session.schid, Com.Session.usertid) == true)//年级主任
                        {
                            islist = true;
                        }
                        if (bllclassuser.ExistsIsMs(Com.Public.SqlEncStr(ClassId), Com.Session.usertid, Com.Session.schid, 0) == true)//任课老师
                        {
                            islist = true;
                        }
                    }
                    if (Com.Public.IsUserVal(Com.Session.userrolestr, 2))
                    {
                        islist = true;
                    };

                }
                #endregion
                if (islist)
                {
                    string strWhere = " StuStat=1 ";
                    if (!string.IsNullOrEmpty(Stuname))
                        strWhere += " and stuname LIKE '%" + Com.Public.SqlEncStr(Stuname) + "%'";
                    if (GradeId == "-1" || GradeId == "")//获取当前用户的所有年级
                    {
                        strWhere += " and GradeId in (" + Com.Public.GetIdsAllStu("4", Com.Session.schid) + ")";
                    }
                    else
                    {
                        strWhere += " and GradeId=" + Com.Public.SqlEncStr(GradeId);
                    }
                    if (ClassId == "-1" || ClassId == "")//获取当前用户的所有班级
                    {
                        if (GradeId == "") GradeId = "-1";
                        strWhere += " and ClassId in (" + Com.Public.GetIdsAllStu("5", Com.Public.SqlEncStr(GradeId)) + ")";
                    }
                    else
                    {
                        strWhere += " and ClassId=" + Com.Public.SqlEncStr(ClassId);
                    }

                    int RowCount = 0; int PageCount = 0;//left('00000000',8-len(StuId))+convert(varchar(10),StuId)
                    string cols = "  GradeId,ClassId,GradeName,ClassName,StuId,isnull(TestNo,'') TestNo,StuName,CardNo,Sex,StuNo,TelNo,StudyType,LoginName,'' GenNameO,'' GenLoginNameO ,'' GenTelO,'' GenNameT,'' GenLoginNameT ,'' GenTelT,'0' isdel,'0' isedit,'0' islook";
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
                            //权限
                            if (Com.Session.systype == "1")//学校超管,可看
                            {
                                if (Com.Session.appeditstat == "1")//系统未被屏蔽编辑功能,则可编辑和删除
                                {
                                    dtstuv.Rows[i]["isdel"] = "1";
                                    dtstuv.Rows[i]["isedit"] = "1";
                                }
                                dtstuv.Rows[i]["islook"] = "1";
                            }
                            else//普通老师账号
                            {

                                if (bllclassuser.ExistsIsMs(dtstuv.Rows[i]["ClassId"].ToString(), Com.Session.usertid, Com.Session.schid, 1) == true)//班主任可查看
                                {
                                    dtstuv.Rows[i]["islook"] = "1";
                                    if (Com.Session.appeditstat == "1")
                                    {
                                        dtstuv.Rows[i]["isdel"] = "1";
                                        dtstuv.Rows[i]["isedit"] = "1";
                                    }
                                }
                                else
                                {
                                    if (bllgradeuser.ExistsGrade(dtstuv.Rows[i]["GradeId"].ToString(), Com.Session.schid, Com.Session.usertid) == true)//年级主任
                                    {
                                        islist = true;
                                        dtstuv.Rows[i]["islook"] = "1";
                                    }
                                }
                                if (Com.Public.IsUserVal(Com.Session.userrolestr, 2))
                                {
                                    dtstuv.Rows[i]["islook"] = "1";
                                    islist = true;
                                }
                            }
                        }
                        pages.list = dtstuv;

                    }
                }

                ret= Newtonsoft.Json.JsonConvert.SerializeObject(pages);
            }
            return ret;
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
        #endregion
        #region 删除
        [WebMethod]
        public static string studel(int id)
        {
            string ret = "";
            if (Com.Session.userid == null)
            {
                ret = "expire";
            }
            else
            {
                try
                {
                    List<string> LstError = new List<string>();

                    if (LstError.Count == 0)
                    {
                        SchSystem.BLL.SchStuInfo bll_stu = new SchSystem.BLL.SchStuInfo();
                        bool Prirow = bll_stu.DeleteRec(Convert.ToInt32(id));
                        if (Prirow == true)
                        {
                            ret = "Success";
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return ret;
        }
        #endregion
        #region 联动下拉框
        [WebMethod]
        public static string getarea(string typecode, string pcode)
        {
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
                    if (typecode != "6")
                        ret = Com.Public.GetDrpAreaStu(Com.Public.SqlEncStr(typecode), Com.Public.SqlEncStr(pcode), ref selp, true);
                    else ret = Com.Public.GetDrp("dpt", pcode, "1", true, "", "");
                }
                catch (Exception ex)
                {
                    ret = "";
                }
            }
            return ret;
        }
        #endregion
    }
}