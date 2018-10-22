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

namespace SchWebMaster.Web.UserFuncSoure
{
    public partial class StudentEdit : System.Web.UI.Page
    {
        public string dotype = "";//操作类型,修改或者是添加,a添加,e修改
        public string dptdrp = "";
        public string areastr = "";
        public string schname = "";
        public string schid = "0";//学校id
        public string stuid = "0";//学生id
        public string umodelstr = "1";//学校model 
        public static string njld = "";//年级领导
        public static string bjjs = "";//班级老师
        public static string bzr = "";//班主任
        public static string classinfo = "0";//前台需要的班级相关数据
        public static string oldClassName = "";//原班级名称
        public static string gradecodestr = "";
        public static string classidstr = "";
        public string Stubh;
        SchSystem.BLL.SchStuInfo bll_stu = new SchSystem.BLL.SchStuInfo();
        SchManagerInfoSystem.Common.DttoJson dttojson = new SchManagerInfoSystem.Common.DttoJson();
        #region 初始化加载方法
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dotype = Request.Params["dotype"].ToString();
                gradecodestr = Request.Params["gradecode"].ToString();
                classidstr = Request.Params["classid"].ToString();
                #region 编辑绑定查询
                if (dotype == "e")
                {
                    Stubh = Request.Params["Stubh"].ToString();
                    stuid = Request.Params["id"].ToString();
                    string sql = "select * from SchStuInfoV where StuId='" + stuid + "' ";//根据学生ID查询出学校，年级，班级等信息
                    dt = DbHelperSQL.Query(sql).Tables[0];
                    //18
                    //string oldclassname = dt.Rows[0][18].ToString();
                    DataRow[] dr = dt.Select();
                    if (classidstr == "")
                    {
                        classidstr = dr[0]["ClassId"].ToString();
                    }
                    string oldclassname = dr[0]["OldClassId"].ToString();
                    if (!string.IsNullOrEmpty(oldclassname) || oldclassname != "")
                    {
                        oldClassName = oldclassname;
                    }
                    else
                    {
                        oldClassName = "";
                    }
                    /*if (!string.IsNullOrEmpty(oldclassid) || oldclassid != "")
                    {
                        SchSystem.BLL.SchClassInfo sciBll = new SchSystem.BLL.SchClassInfo();
                        oldClassName = sciBll.GetClassNames("ClassId in (" + oldclassid + ")");
                    }
                    else
                    {
                        oldClassName = "";
                    }*/
                    if (dt.Rows.Count > 0)
                    {
                        classinfo = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
                    }
                    else
                    {
                        classinfo = "0";
                    }
                    SchSystem.BLL.SchStuInfo bll_stu = new SchSystem.BLL.SchStuInfo();
                    string strWhere = " a.StuId=" + stuid;
                    DataSet ds = bll_stu.GetList(strWhere);//修改绑定需要的数据
                    ds.Tables[0].Columns.Add("ClassId");
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
                    umodelstr = dttojson.DatSetToJSON2(ds);
                }
                #endregion
                #region 缺省值：年級領導、班主任和任課教師
                SchSystem.BLL.SchGradeUsers sgiBll = new SchSystem.BLL.SchGradeUsers();
                SchSystem.BLL.SchClassUser scuBll = new SchSystem.BLL.SchClassUser();
                DataTable dtgradeuser = sgiBll.GetList("*", "GradeId='" + gradecodestr + "'").Tables[0];
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
                DataTable dtclassuser = scuBll.GetList("*", "ClassId='" + classidstr + "'").Tables[0];
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
                //普通老师登录
                if (Com.SoureSession.Souresystype == "0")
                {
                    string gradeid = "";
                    if (dotype == "e" && dt.Rows[0]["AreaNo"].ToString().Length == 6)
                    {
                        gradeid = dt.Rows[0]["GradeId"].ToString();
                    }
                    else
                    {
                        gradeid = gradecodestr;
                    }
                    sbarea.Append("<br/><label class=\"biaoti\">年级:</label><select id=\"nj\" style=\"width:100px\">");
                    sbarea.Append(Com.Public.GetGradeSelect("1", int.Parse(classidstr), ref gradeid, Com.SoureSession.Soureschid));
                    sbarea.Append("</select>");
                    string classid = "";
                    if (dotype == "e" && dt.Rows[0]["AreaNo"].ToString().Length == 6)
                    {
                        classid = dt.Rows[0]["ClassId"].ToString();
                    }
                    sbarea.Append("<span id=\"njld\" style=\"color:	#808080	\">年级领导：" + njld + "</span><br/><br/>");
                    sbarea.Append("<label class=\"biaoti\">班级:</label><select id=\"bj\" style=\"width:100px\" >");
                    sbarea.Append(Com.Public.GetGradeSelect("2", int.Parse(classidstr), ref classid, gradeid));
                    sbarea.Append("</select>");
                    sbarea.Append("<span id=\"bzr\" style=\"color:	#808080	\">班主任：" + bzr + "</span>&nbsp;&nbsp; ");
                    sbarea.Append("<span id=\"bjjs\" style=\"color:	#808080	\">任课老师：" + bjjs + "</span><br/><br/>");

                    areastr = sbarea.ToString();
                }
                else if (Com.SoureSession.Souresystype == "1")
                {
                    //获取年级
                    sbarea.Append("<br/> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;年级：<select id=\"nj\" style=\"width:100px\">");
                    string schcode = "";
                    if (dotype == "e" && dt.Rows[0]["AreaNo"].ToString().Length == 6)
                    {
                        schcode = dt.Rows[0]["GradeId"].ToString();
                    }
                    sbarea.Append(Com.Public.GetDrpArea("4", Com.SoureSession.Soureschid, ref schcode, false));



                    sbarea.Append("</select>&nbsp;&nbsp;&nbsp;&nbsp;");
                    sbarea.Append("<span id=\"njld\" style=\"color:	#808080	\">年级领导：" + njld + "</span><br/><br/>");
                    //获取班级
                    sbarea.Append(" &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;班级：<select id=\"bj\" style=\"width:100px\" >");
                    string Classcode = "";
                    if (dotype == "e" && dt.Rows[0]["AreaNo"].ToString().Length == 6)
                    {
                        Classcode = dt.Rows[0]["ClassId"].ToString();
                    }
                    sbarea.Append(Com.Public.GetDrpArea("5", schcode, ref Classcode, false));
                    sbarea.Append("</select>&nbsp;&nbsp;&nbsp;&nbsp;");
                    sbarea.Append("<span id=\"bzr\" style=\"color:	#808080	\">班主任：" + bzr + "</span>&nbsp;&nbsp; ");
                    sbarea.Append("<span id=\"bjjs\" style=\"color:	#808080	\">任课老师：" + bjjs + "</span><br/><br/>");
                    string s = getnj("1", schcode, schid, Classcode);
                    areastr = sbarea.ToString();
                }
                else//超管还要加学校下拉,后面需要更改
                {
                    //第一次加载,获取省市区,获取第一个省份下的所有学校
                    //StringBuilder sbarea = new StringBuilder();
                    //获取省份

                    sbarea.Append("省:<select id=\"aprov\">");
                    string sareacode = "";
                    if (dotype == "e" && dt.Rows[0]["AreaNo"].ToString().Length == 6)
                    {
                        sareacode = dt.Rows[0]["AreaNo"].ToString().Substring(0, 2) + "0000";

                    }
                    sbarea.Append(Com.Public.GetDrpArea("0", "", ref sareacode, false));
                    sbarea.Append("</select>");
                    //获取城市
                    sbarea.Append("市:<select id=\"acity\">");
                    string sareacitycode = "";
                    if (dotype == "e" && dt.Rows[0]["AreaNo"].ToString().Length == 6)
                    {
                        sareacitycode = dt.Rows[0]["AreaNo"].ToString().Substring(0, 4) + "00";

                    }
                    sbarea.Append(Com.Public.GetDrpArea("1", sareacode, ref sareacitycode, false));
                    sbarea.Append("</select>");
                    //获取区县
                    sbarea.Append("区:<select id=\"acoty\">");
                    string sareacotycode = "";
                    if (dotype == "e" && dt.Rows[0]["AreaNo"].ToString().Length == 6)
                    {
                        sareacotycode = dt.Rows[0]["AreaNo"].ToString();
                    }
                    sbarea.Append(Com.Public.GetDrpArea("2", sareacitycode, ref sareacotycode, false));
                    sbarea.Append("</select>");
                    //获取学校
                    sbarea.Append("学校:<select id=\"asch\">");
                    string sareaschid = "";
                    if (dotype == "e" && dt.Rows[0]["AreaNo"].ToString().Length == 6)
                    {
                        sareaschid = dt.Rows[0]["SchId"].ToString();
                    }
                    sbarea.Append(Com.Public.GetDrpArea("3", sareacotycode, ref sareaschid, false));
                    sbarea.Append("</select><br/> ");

                    //获取年级
                    sbarea.Append("<br/> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;年级:<select id=\"nj\" style=\"width:100px\">");
                    string schcode = "";
                    if (dotype == "e" && dt.Rows[0]["AreaNo"].ToString().Length == 6)
                    {
                        schcode = dt.Rows[0]["GradeId"].ToString();
                    }
                    sbarea.Append(Com.Public.GetDrpArea("4", sareaschid, ref schcode, false));
                    sbarea.Append("</select>&nbsp;&nbsp;&nbsp;&nbsp;");


                    sbarea.Append("<span id=\"njld\" style=\"color:#808080	\">年级领导：" + njld + "</span><br/><br/>");
                    //获取班级
                    sbarea.Append(" &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;班级:<select id=\"bj\" style=\"width:100px\" >");
                    string Classcode = "";
                    if (dotype == "e" && dt.Rows[0]["AreaNo"].ToString().Length == 6)
                    {
                        Classcode = dt.Rows[0]["ClassId"].ToString();
                    }
                    sbarea.Append(Com.Public.GetDrpArea("5", schcode, ref Classcode, false));
                    sbarea.Append("</select>&nbsp;&nbsp;&nbsp;&nbsp;");
                    sbarea.Append("<span id=\"bzr\" style=\"color:	#808080	\">班主任：" + bzr + "</span>&nbsp;&nbsp; ");
                    sbarea.Append("<span id=\"bjjs\"  style=\"color:#808080	\">任课老师：" + bjjs + "</span><br/><br/>");
                    string s = getnj("1", schcode, sareaschid, Classcode);

                    areastr = sbarea.ToString();
                }


            }
        }
        #endregion
        [WebMethod]
        public static string getnj(string typecode, string pcode, string schid, string classid)
        {
            if (schid == "undefined")
            {
                schid = Com.SoureSession.Soureschid;
            }
            schid = Com.Public.SqlEncStr(schid);
            typecode = Com.Public.SqlEncStr(typecode);
            string ClassId = "";
            SchSystem.BLL.SchGradeUsers sguBLL = new SchSystem.BLL.SchGradeUsers();
            SchSystem.BLL.SchClassUser scuBLL = new SchSystem.BLL.SchClassUser();
            SchWebMaster.Web.Student.StudentList.namepack np = new SchWebMaster.Web.Student.StudentList.namepack();

            if (typecode == "1")//1为获取年级领导
            {
                string GradeCode = Com.Public.SqlEncStr(pcode);
                string sql1 = "";
                string sql2 = "";
                if (Com.SoureSession.Souresystype != "2")//判断是否是超管
                {
                    sql1 = "select GradeId from dbo.SchGradeInfo where GradeId='" + GradeCode + "' and SchId='" + Com.SoureSession.Soureschid + "'";
                    sql2 = "select *  FROM SchClassGradeV  where IsFinish<>2 and SchId='" + Com.SoureSession.Soureschid + "' and IsFinish=0 and GradeCode='" + GradeCode + "' and ClassId='" + classid + "' order by GradeCode,ClassName	";
                }
                else
                {
                    sql1 = "select GradeId from dbo.SchGradeInfo where GradeId='" + GradeCode + "'  and SchId='" + schid + "'";
                    sql2 = "select *  FROM SchClassGradeV  where IsFinish<>2 and SchId='" + schid + "' and IsFinish=0 and GradeCode='" + GradeCode + "' and ClassId='" + classid + "' order by GradeCode,ClassName	";
                }
                DataTable dt1 = DbHelperSQL.Query(sql1).Tables[0];
                string GradeId = "";
                if (dt1.Rows.Count > 0)
                {
                    GradeId = dt1.Rows[0]["GradeId"].ToString();
                }
                DataTable dt2 = DbHelperSQL.Query(sql2).Tables[0];
                if (dt2.Rows.Count > 0)
                {
                    njld = np.gradeboss = sguBLL.GetNames("GradeId='" + GradeId + "'");
                }
                if (dt2.Rows.Count != 0)
                {
                    ClassId = dt2.Rows[0]["ClassId"].ToString();
                    bzr = np.classms = scuBLL.GetNames("ClassId='" + ClassId + "' and IsMs=1");
                    bjjs = np.classtec = scuBLL.GetNames("ClassId=" + ClassId + " and IsMs=0");
                }
            }
            else//侧为获取班主任和任课老师
            {
                np.classms = scuBLL.GetNames("ClassId='" + pcode + "' and IsMs=1 and SchId='" + schid + "'");
                np.classtec = scuBLL.GetNames("ClassId=" + pcode + " and IsMs=0  and SchId='" + schid + "'");
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(np);
        }
        #region 添加保存和修改保存
        [WebMethod]
        public static string schsave(string Genid1, string Genid2, string Unid1, string Unid2, string Stuid, string dotype, string schid, string ClassId, string TestNo, string StuName, string Sex, string CardNo, string StudyType, string TelNo, string LoginName, string Pwd, string Addr, string Stat, string jzGenName1, string jzTelNo1, string jzLoginName1, string jzPwd1, string jzStat1, string jzGenName2, string jzTelNo2, string jzLoginName2, string jzPwd2, string jzStat2, string Relation1, string Relation2, string OldClassName, string OldGradeId, string OldGradeName, string GradeId, string OldClassId, string CurrentTestNo)
        {
            string result = ""; //事物返回结果 
            SchSystem.BLL.SchClassUser bllclassuser = new SchSystem.BLL.SchClassUser();
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(Com.SoureSession.jsid, Com.SoureSession.jstoken);
            if (rsp.code == "ERROR_TOKEN")
            {
                result = "expire";
            }
            else
            {
                List<string> LstError = new List<string>();
                try
                {
                    //if (!Com.Public.isVa(schid, ""))
                    //{
                    //    LstError.Add("无跨界权限！" + Environment.NewLine);
                    //} 
                    SchSystem.Model.SchStuInfo model_stu = new SchSystem.Model.SchStuInfo();
                    SchSystem.BLL.SchStuInfo bll_stu = new SchSystem.BLL.SchStuInfo();
                    #region 收集学生信息
                    if (Com.SoureSession.Souresystype != "2")
                    {
                        model_stu.SchId = Convert.ToInt32(Com.SoureSession.Soureschid);
                    }
                    else
                    {
                        model_stu.SchId = Convert.ToInt32(schid);
                    }

                    StringBuilder sb = new StringBuilder();
                    if (GradeId != OldGradeId)
                    {
                        sb.Append(OldGradeName);
                    }
                    if (ClassId != OldClassId)
                    {
                        sb.Append(OldClassName);
                    }
                    string sbstr = sb.ToString();
                    if (sbstr != "")
                    {
                        model_stu.OldClassId = sbstr;
                    }
                    else
                    {
                        model_stu.OldClassId = "";
                    }
                    model_stu.ClassId = Convert.ToInt32(ClassId);
                    /*
                    if (ClassId != OldClassIdstr)//如果班级ID有变化说明是在调班
                    {
                        if (OldClassIdSavestr == "")//如果是第一次调班
                        {
                            model_stu.OldClassId = OldClassIdstr;
                        }
                        else//曾经调过班
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append(OldClassIdSavestr + "," + OldClassIdstr);//班级ID以英文半角的逗号隔开
                            model_stu.OldClassId = sb.ToString() ;
                        }
                        model_stu.ClassId = Convert.ToInt32(ClassId);
                    }
                    else//否则，没有调班
                    {
                        model_stu.ClassId = Convert.ToInt32(ClassId);
                    }
                    */
                    model_stu.TestNo = Com.Public.SqlEncStr(TestNo);
                    model_stu.StuName = Com.Public.SqlEncStr(StuName);
                    model_stu.Sex = Convert.ToInt32(Sex);
                    model_stu.Dutie = "";
                    model_stu.StudyType = Convert.ToInt32(StudyType);
                    model_stu.TelNo = Com.Public.SqlEncStr(TelNo);
                    model_stu.LoginName = Com.Public.SqlEncStr(LoginName);
                    if (Pwd != "")
                    {
                        model_stu.Pwd = Com.Public.StrToMD5(Com.Public.SqlEncStr(Pwd));
                    }
                    else
                    {
                        model_stu.Pwd = "";
                    }
                    model_stu.Addr = Com.Public.SqlEncStr(Addr);
                    model_stu.Stat = Convert.ToInt32(Stat);
                    model_stu.Birth = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString());
                    model_stu.RecUser = Com.SoureSession.Soureuserid;
                    model_stu.RecTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString());
                    model_stu.LastRecUser = Com.SoureSession.Soureuserid;
                    model_stu.LastRecTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString());
                    model_stu.StuNo = Com.Public.SqlEncStr(TestNo);
                    model_stu.CardNo = "";//(Test)卡地址在前台读取,
                    model_stu.ImgUrl = "00";//(Test)学生默认头像
                    if (dotype == "e")
                        model_stu.StuId = Convert.ToInt32(Stuid);
                    #endregion
                    #region 收集家长信息
                    List<SchSystem.Model.SchGenInfo> list_model_gen = new List<SchSystem.Model.SchGenInfo>();
                    SchSystem.Model.SchGenInfo model_gen = new SchSystem.Model.SchGenInfo();
                    //if (Convert.ToString(jzGenName1) != "" && Convert.ToString(jzTelNo1) != "")
                    //{
                    model_gen.GenName = Com.Public.SqlEncStr(jzGenName1);
                    model_gen.TelNo = Com.Public.SqlEncStr(jzTelNo1);
                    model_gen.LoginName = "";

                    if (Pwd != "")
                    {
                        model_gen.Pwd = Com.Public.StrToMD5(Com.Public.SqlEncStr(jzPwd1));
                    }
                    else
                    {
                        model_gen.Pwd = "";
                    }
                    model_gen.Stat = Convert.ToInt32(jzStat1);
                    model_gen.RecUser = Com.SoureSession.Soureuserid;
                    model_gen.RecTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString());
                    model_gen.LastRecUser = Com.SoureSession.Soureuserid;
                    model_gen.LastRecTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString());
                    model_gen.ImgUrl = "00";//(Test)学生默认头像
                    model_gen.Sex = 1;
                    if (Genid1 != "")
                    {
                        if (dotype == "e")
                            model_gen.GenId = Convert.ToInt32(Genid1);
                    }
                    list_model_gen.Add(model_gen);
                    //}

                    SchSystem.Model.SchGenInfo model_gen2 = new SchSystem.Model.SchGenInfo();
                    //if (Convert.ToString(jzGenName2) != "" && Convert.ToString(jzTelNo2) != "")
                    //{
                    model_gen2.GenName = Com.Public.SqlEncStr(jzGenName2);
                    model_gen2.TelNo = Com.Public.SqlEncStr(jzTelNo2);
                    model_gen2.LoginName = "";
                    if (Pwd != "")
                    {
                        model_gen2.Pwd = Com.Public.StrToMD5(Convert.ToString(jzPwd2));
                    }
                    else
                    {
                        model_gen2.Pwd = "";
                    }
                    model_gen2.Stat = Convert.ToInt32(jzStat2);
                    model_gen2.RecUser = Com.SoureSession.Soureuserid;
                    model_gen2.RecTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString());
                    model_gen2.LastRecUser = Com.SoureSession.Soureuserid;
                    model_gen2.LastRecTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString());
                    model_gen2.ImgUrl = "00";//(Test)学生默认头像
                    model_gen2.Sex = 1;
                    if (dotype == "e")
                    {
                        if (Genid2 == "")//编辑时，如果家长ID为空，则添加
                        {
                            model_gen2.GenId = 0;
                        }
                        else
                        {
                            model_gen2.GenId = Convert.ToInt32(Genid2);
                        }
                    }
                    list_model_gen.Add(model_gen2);
                    //}

                    #endregion
                    #region 收集学生家长关系信息
                    List<SchSystem.Model.SchStuGenUn> list_model_stu_gen = new List<SchSystem.Model.SchStuGenUn>();
                    SchSystem.Model.SchStuGenUn model_stu_gen = new SchSystem.Model.SchStuGenUn();
                    model_stu_gen.Relation = Com.Public.SqlEncStr(Relation1);
                    model_stu_gen.GenName = Com.Public.SqlEncStr(jzGenName1);
                    if (dotype == "e")
                    {
                        if (Unid1 != "") { model_stu_gen.UnId = Convert.ToInt32(Unid1); } else { model_stu_gen.UnId = 0; }
                        model_stu_gen.StuId = model_stu.StuId;
                        model_stu_gen.GenId = model_gen.GenId;
                    }
                    list_model_stu_gen.Add(model_stu_gen);


                    SchSystem.Model.SchStuGenUn model_stu_gen2 = new SchSystem.Model.SchStuGenUn();
                    if (Convert.ToString(Relation2) != "")
                    {
                        model_stu_gen2.Relation = Com.Public.SqlEncStr(Relation2);
                        model_stu_gen2.GenName = Com.Public.SqlEncStr(jzGenName2);
                        if (dotype == "e")
                        {
                            if (model_gen2.GenId != 0)
                            {
                                model_stu_gen2.UnId = Convert.ToInt32(Unid2);
                                model_stu_gen2.StuId = model_stu.StuId;
                                model_stu_gen2.GenId = model_gen2.GenId;

                            }
                            else
                            {
                                model_stu_gen2.UnId = 0;
                            }
                        }
                        list_model_stu_gen.Add(model_stu_gen2);
                    }


                    #endregion
                    if (dotype == "a")//操作类型为添加
                    {

                        if (bll_stu.ExistsStuCode(0, model_stu.TestNo.ToString(), Convert.ToInt32(model_stu.SchId)))
                        {
                            /*
                            LstError.Add("学(考)号重复 ！" + Environment.NewLine);//学(考)号重复 
                            result = "KHCF";*/
                            StringBuilder sbExists = new StringBuilder();
                            string utname = "";
                            SchSystem.BLL.SchStuInfo ssiBll = new SchSystem.BLL.SchStuInfo();
                            if (schid == "0") { schid = model_stu.SchId.ToString(); }
                            DataTable dt = ssiBll.ExistsStuNo(TestNo, int.Parse(schid)).Tables[0];
                            if (dt.Rows.Count > 0)
                            {
                                DataRow[] dr = dt.Select();
                                foreach (DataRow item in dr)
                                {
                                    sbExists.Append(item["StuName"].ToString() + "[" + item["GradeName"].ToString());
                                    sbExists.Append("(" + item["ClassName"].ToString() + ")]");
                                }
                                //ret += "账号重复!";
                                return result = sbExists.ToString();
                            }
                        }
                        if (LoginName != "")
                        {
                            if (bll_stu.ExistsStuUsername(0, model_stu.LoginName.ToString(), Convert.ToInt32(model_stu.SchId)))
                            {
                                LstError.Add("账号重复 ！" + Environment.NewLine);//账号重复 
                                result = "ZHCF";
                            }
                        }
                        if (LstError.Count == 0)
                        {
                            if (Com.SoureSession.Souresystype == "1" || Com.SoureSession.Souresystype == "2")//超管和学校超管
                            {
                                result = bll_stu.Add(model_stu, list_model_gen, list_model_stu_gen);
                            }
                            else
                            {
                                //if (ClassId == classidstr)
                                //{
                                if (bllclassuser.ExistsIsMs(Com.Public.SqlEncStr(ClassId),Com.SoureSession.Soureusertid, Com.SoureSession.Soureschid, 1) == true)//班主任
                                {
                                    result = bll_stu.Add(model_stu, list_model_gen, list_model_stu_gen);
                                }
                                else
                                {
                                    result = "BBBZR";
                                }
                                //}
                                //else if (GradeId == gradecodestr)
                                //{
                                //    if (bll_stu.ExistsGrade(Com.Public.SqlEncStr(GradeId), Com.Session.schid, Com.Session.usertid) == true)//年级主任
                                //    {
                                //        result = bll_stu.Add(model_stu, list_model_gen, list_model_stu_gen);
                                //    }
                                //    else
                                //    {
                                //        result = "BNJZR";
                                //    }
                                //}

                            }
                            //result = bll_stu.Add(model_stu, list_model_gen, list_model_stu_gen);

                        }
                    }
                    else if (dotype == "e")//操作类型为编辑
                    {
                        StringBuilder sbExists = new StringBuilder();
                        string utname = "";
                        SchSystem.BLL.SchStuInfo ssiBll = new SchSystem.BLL.SchStuInfo();
                        if (schid == "0") { schid = model_stu.SchId.ToString(); }
                        DataTable dt = ssiBll.ExistsStuNoUpdate(TestNo, int.Parse(schid), CurrentTestNo).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            DataRow[] dr = dt.Select();
                            foreach (DataRow item in dr)
                            {
                                sbExists.Append(item["StuName"].ToString() + "[" + item["GradeName"].ToString());
                                sbExists.Append("(" + item["ClassName"].ToString() + ")]");
                            }
                            //ret += "账号重复!";
                            return result = sbExists.ToString();
                        }
                        //if (bll_stu.ExistsStuCode(0, model_stu.TestNo.ToString(), Convert.ToInt32(model_stu.SchId)))
                        //{
                        //    LstError.Add("学(考)号重复 ！" + Environment.NewLine);//学(考)号重复 
                        //    result = "KHCF";
                        //}
                        if (LstError.Count == 0)
                        {

                            result = bll_stu.Update(model_stu, list_model_gen, list_model_stu_gen);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return result;
        }
        #endregion
        #region 联动方法
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
                    if (Com.SoureSession.Souresystype == "1" || Com.SoureSession.Souresystype == "2")//超管和学校超管
                    {
                        string selp = "";
                        if (typecode != "6")
                            ret = Com.Public.GetDrpArea(typecode, pcode, ref selp, false);
                        else ret = Com.Public.GetDrp("dpt", pcode, "1", true, "", "");
                    }
                    else
                    {
                        string classid = "";
                        string gradeid = pcode;
                        ret = Com.Public.GetGradeSelect("2", int.Parse(classidstr), ref classid, gradeid);
                    }
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