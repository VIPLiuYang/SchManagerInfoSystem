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

namespace SchWebMaster.Web.UserFuncSoure
{
    public partial class StudentList : System.Web.UI.Page
    {
        public string dptdrp = "";
        public string areastr = "";
        public string schid = "0";
        public bool isadd;
        public static string njld = "";//年级领导
        public static string bjjs = "";//班级老师
        public static string bzr = "";//班主任
        #region 初始化加载方法
        protected void Page_Load(object sender, EventArgs e)
        {
            SchSystem.BLL.SchStuInfo stuinfo = new SchSystem.BLL.SchStuInfo();
            string jsid = Request.Params["sid"].ToString();
            string jstoken = Request.Params["token"].ToString();
            Com.SoureSession.jsid = jsid;
            Com.SoureSession.jstoken = jstoken;
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(jsid, jstoken);
            if (rsp.code == "ERROR_TOKEN")
            {
                Response.Write("登录已失效!");
                Response.End();
            }
            else if (!IsPostBack)
            {
                //权限组的增删改
                if (Com.SoureSession.Souresystype == "1")//超级管理员和学校管理员
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

                #region 普通人员和学校管理员方法
                if (Com.SoureSession.Souresystype != "2")
                {
                    schid = Com.SoureSession.Soureschid;
                    StringBuilder sbarea = new StringBuilder();
                    //获取年级
                    sbarea.Append("<br/>年级:<select id=\"nj\" style=\"width:100px\">");
                    string schcode = "";
                    sbarea.Append(Com.Public.GetDrpAreaStu("4",  Com.SoureSession.Soureschid, ref schcode, true));

                    sbarea.Append("</select>&nbsp;&nbsp;&nbsp;&nbsp;");
                    sbarea.Append("<span id=\"njld\" style=\"color:	#808080	\">年级领导：" + njld + "</span><br/><br/>");
                    //获取班级
                    sbarea.Append("班级:<select id=\"bj\" style=\"width:100px\" >");
                    string Classcode = "";
                    sbarea.Append(Com.Public.GetDrpAreaStu("5", schcode, ref Classcode, true));
                    sbarea.Append("</select>&nbsp;&nbsp;&nbsp;&nbsp;");
                    sbarea.Append("<span id=\"bzr\" style=\"color:	#808080	\">班主任：" + bzr + "</span>&nbsp;&nbsp; ");
                    sbarea.Append("<span id=\"bjjs\" style=\"color:	#808080	\">任课老师：" + bjjs + "</span><br/><br/>");
                    string s = getnj("1", schcode, schid, Classcode);
                    areastr = sbarea.ToString();
                }
                #endregion
                #region 系统超级管理员方法
                else//超管还要加学校下拉
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
                    sbarea.Append("</select>");
                    //获取学校
                    sbarea.Append("学校:<select id=\"asch\">");
                    string sareaschid = "";
                    sbarea.Append(Com.Public.GetDrpArea("3", sareacotycode, ref sareaschid, false));
                    sbarea.Append("</select> <br/> ");
                    //获取年级
                    sbarea.Append("<br/>年级:<select id=\"nj\" style=\"width:100px\">");
                    string schcode = "";
                    sbarea.Append(Com.Public.GetDrpAreaStu("4", sareaschid, ref schcode, false));
                    sbarea.Append("</select>&nbsp;&nbsp;&nbsp;&nbsp;");

                    sbarea.Append("<span id=\"njld\" style=\"color:	#808080	\">年级领导：" + njld + "</span><br/><br/>");
                    //获取班级
                    sbarea.Append("班级:<select id=\"bj\" style=\"width:100px\" >");
                    string Classcode = "";
                    sbarea.Append(Com.Public.GetDrpAreaStu("5", schcode, ref Classcode, false));
                    sbarea.Append("</select>&nbsp;&nbsp;&nbsp;&nbsp;");
                    sbarea.Append("<span id=\"bzr\" style=\"color:	#808080	\">班主任：" + bzr + "</span>&nbsp;&nbsp; ");
                    sbarea.Append("<span id=\"bjjs\" style=\"color:	#808080	\">任课老师：" + bjjs + "</span><br/><br/>");
                    string s = getnj("1", schcode, sareaschid, Classcode);
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
            bool islist = false;
            Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
            pages.PageIndex = int.Parse(PageIndex);
            pages.PageSize = int.Parse(PageSize);
            SchSystem.BLL.SchClassUser bllclassuser = new SchSystem.BLL.SchClassUser();
            SchSystem.BLL.SchGradeUsers bllgradeuser = new SchSystem.BLL.SchGradeUsers();
            #region 添加按钮和列表显示权限
            pages.isadd = false;
            if (Com.SoureSession.Souresystype == "1")//学校超管
            {
                islist = true;
                if ( GradeId == "-1" || ClassId == "-1" || GradeId == "" || ClassId == "")//系统编辑状态为0,或者年级,班级其中一个选择了全部,则不允许出现添加按钮
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

                if (bllclassuser.ExistsIsMs(Com.Public.SqlEncStr(ClassId), Com.SoureSession.Soureuserid, Com.SoureSession.Soureschid, 1) == true)//班主任
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
                    if (bllgradeuser.ExistsGrade(Com.Public.SqlEncStr(GradeId), Com.SoureSession.Soureschid, Com.SoureSession.Soureuserid) == true)//年级主任
                    {
                        islist = true;
                    }
                    if (bllclassuser.ExistsIsMs(Com.Public.SqlEncStr(ClassId), Com.SoureSession.Soureuserid, Com.SoureSession.Soureschid, 0) == true)//任课老师
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
                string strWhere = "StuStat=1 ";
                if (!string.IsNullOrEmpty(Stuname))
                    strWhere += " and stuname LIKE '%" + Com.Public.SqlEncStr(Stuname) + "%'";
                if (GradeId == "-1" || GradeId == "")//获取当前用户的所有年级
                {
                    strWhere += " and GradeId in (" + Com.Public.GetIdsAllStu("4", Com.SoureSession.Soureschid) + ")";
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
                        //权限
                        if (Com.SoureSession.Souresystype == "1")//学校超管,可看
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

                            if (bllclassuser.ExistsIsMs(dtstuv.Rows[i]["ClassId"].ToString(),Com.SoureSession.Soureuserid,Com.SoureSession.Soureschid, 1) == true)//班主任可查看
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
                                if (bllgradeuser.ExistsGrade(dtstuv.Rows[i]["GradeId"].ToString(), Com.SoureSession.Soureschid, Com.SoureSession.Soureuserid) == true)//年级主任
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

            return Newtonsoft.Json.JsonConvert.SerializeObject(pages);

        }


        [WebMethod]
        public static string getnj(string typecode, string pcode, string schid, string classid)
        {
            string ret = "";
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(Com.SoureSession.jsid, Com.SoureSession.jstoken);
            if (rsp.code == "ERROR_TOKEN")
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
                    schid = Com.SoureSession.Soureschid;
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
                    if (Com.SoureSession.Souresystype != "2")//判断是否是超管
                    {
                        sql1 = "select GradeId from dbo.SchGradeInfo where GradeId='" + GradeCode + "' and SchId='" + Com.SoureSession.Soureschid + "'";
                        sql2 = "select *  FROM SchClassGradeV  where IsFinish<>2 and SchId='" + Com.SoureSession.Soureschid + "' and IsFinish=0 and GradeId='" + GradeCode + "' and ClassId='" + classid + "' order by GradeCode,ClassName	";
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
                            bjjs = np.classtec = scuBLL.GetNames("ClassId=" + ClassId + " and IsMs=0");
                        }
                    }
                }
                else//侧为获取班主任和任课老师
                {
                    np.classms = scuBLL.GetNames("ClassId='" + Com.Public.SqlEncStr(pcode) + "' and IsMs=1 and SchId='" + schid + "'");
                    np.classtec = scuBLL.GetNames("ClassId=" + Com.Public.SqlEncStr(pcode) + " and IsMs=0  and SchId='" + schid + "'");
                }

                ret = Newtonsoft.Json.JsonConvert.SerializeObject(np);
            }
            return ret;
        }
        #endregion
        #region 删除
        [WebMethod]
        public static string studel(int id)
        {
            string ret = "";
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(Com.SoureSession.jsid, Com.SoureSession.jstoken);
            if (rsp.code == "ERROR_TOKEN")
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
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(Com.SoureSession.jsid, Com.SoureSession.jstoken);
            if (rsp.code == "ERROR_TOKEN")
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