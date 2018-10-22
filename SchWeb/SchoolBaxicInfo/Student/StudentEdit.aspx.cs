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
    public partial class StudentEdit : System.Web.UI.Page
    {
        public string dotype = "";//操作类型,修改或者是添加,a添加,e修改
        public string areastr = "";
        public string schid = "0";//学校id
        public string stuid = "0";//学生id
        public string umodelstr = "1";//学校model
        public string Stubh;
        #region 初始化加载方法
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dotype = Request.Params["dotype"].ToString();
                string gradeid = Request.Params["gradecode"].ToString();
                string classid = Request.Params["classid"].ToString();
                schid = Com.Session.schid;
                #region 编辑绑定查询
                if (dotype == "e")
                {
                    Stubh = Request.Params["Stubh"].ToString();
                    stuid = Com.Public.SqlEncStr(Request.Params["id"].ToString());
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
                    if (ds.Tables[0].Rows.Count > 0)
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
                        gradeid = ds.Tables[0].Rows[0]["GradeId"].ToString();
                        classid = ds.Tables[0].Rows[0]["ClassId"].ToString();
                    }
                    umodelstr = Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[0]);
                }
                #endregion
                StringBuilder sbarea = new StringBuilder();
                //普通老师登录
                if (Com.Session.systype == "0")
                {
                    //获取年级
                    sbarea.Append("<br/>年级：<select id=\"nj\" style=\"width:100px\">");

                    sbarea.Append(Com.Public.GetDrpAreaClassMaster("4", Com.Session.schid, ref gradeid, false));
                    sbarea.Append("</select>&nbsp;&nbsp;&nbsp;&nbsp;");
                    //获取年级主任
                    StudentList.namepack npgrade = (StudentList.namepack)Newtonsoft.Json.JsonConvert.DeserializeObject<StudentList.namepack>(getusers("1", gradeid));
                    sbarea.Append("<span id=\"njld\" style=\"color:	#808080	\">年级领导：" + npgrade.gradeboss + "</span><br/><br/>");
                    //获取班级
                    sbarea.Append("班级：<select id=\"bj\" style=\"width:100px\" >");

                    sbarea.Append(Com.Public.GetDrpAreaClassMaster("5", gradeid, ref classid, false));
                    sbarea.Append("</select>&nbsp;&nbsp;&nbsp;&nbsp;");
                    //获取班主任及任课老师
                    StudentList.namepack np = (StudentList.namepack)Newtonsoft.Json.JsonConvert.DeserializeObject<StudentList.namepack>(getusers("2", classid));
                    sbarea.Append("<span id=\"bzr\" style=\"color:	#808080	\">班主任：" + np.classms + "</span>&nbsp;&nbsp; ");
                    sbarea.Append("<span id=\"bjjs\" style=\"color:	#808080	\">任课老师：" + np.classtec + "</span><br/><br/>");

                    areastr = sbarea.ToString();
                }
            }
        }
        #endregion
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
        #region 添加保存和修改保存
        [WebMethod]
        public static Com.DataPack.DataRsp<string> schsave(string Genid1, string Genid2, string Unid1, string Unid2, string Stuid, string dotype, string schid, string ClassId, string TestNo, string StuName, string Sex, string CardNo, string StudyType, string TelNo, string LoginName, string Pwd, string Addr, string Stat, string jzGenName1, string jzTelNo1, string jzLoginName1, string jzPwd1, string jzStat1, string jzGenName2, string jzTelNo2, string jzLoginName2, string jzPwd2, string jzStat2, string Relation1, string Relation2, string OldClassName, string OldGradeId, string OldGradeName, string GradeId, string OldClassId, string CurrentTestNo)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            SchSystem.BLL.SchClassUser bllclassuser = new SchSystem.BLL.SchClassUser();
            if (Com.Session.userid == null)
            {
                rsp.code = "expire";
                rsp.msg = "页面已经过期，请重新登录";
            }
            else
            {
                try
                {
                    SchSystem.Model.SchStuInfo model_stu = new SchSystem.Model.SchStuInfo();
                    SchSystem.BLL.SchStuInfo bll_stu = new SchSystem.BLL.SchStuInfo();
                    if (Com.Session.systype != "2")
                    {
                        model_stu.SchId = Convert.ToInt32(Com.Session.schid);
                    }
                    else
                    {
                        model_stu.SchId = Convert.ToInt32(schid);
                    }

                    StringBuilder sb = new StringBuilder();
                    if (ClassId != OldClassId)
                    {
                        sb.Append(OldGradeName + "(" + OldClassName + ")");
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
                    model_stu.TestNo = Com.Public.SqlEncStr(TestNo);
                    model_stu.StuName = Com.Public.SqlEncStr(StuName);
                    model_stu.Sex = Convert.ToInt32(Sex);
                    model_stu.StudyType = Convert.ToInt32(StudyType);
                    model_stu.TelNo = Com.Public.SqlEncStr(TelNo);
                    model_stu.Addr = Com.Public.SqlEncStr(Addr);
                    model_stu.RecUser = Com.Session.userid;
                    model_stu.RecTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString());
                    model_stu.LastRecUser = Com.Session.userid;
                    model_stu.LastRecTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString());
                    model_stu.StuNo = Com.Public.SqlEncStr(TestNo);
                    model_stu.CardNo = "";//(Test)卡地址在前台读取,
                    string errorstr = "";
                    //获取有考号的学生列表,进行添加或者修改判断
                    int stuids = 0;
                    if (dotype == "e")//根据是否有判断
                    {
                        model_stu.StuId = Convert.ToInt32(Stuid);
                        stuids = model_stu.StuId;
                    }
                    //判断是否有该学号的学生
                    StringBuilder sbExists = new StringBuilder();
                    SchSystem.BLL.SchStuInfo ssiBll = new SchSystem.BLL.SchStuInfo();
                    //看是否考号被占用
                    DataTable dt = ssiBll.GetStuNoList(TestNo, model_stu.SchId, stuids).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        DataRow[] dr = dt.Select();
                        foreach (DataRow item in dr)
                        {
                            sbExists.Append("[" + item["GradeName"].ToString() + item["ClassName"].ToString() + "]" + item["StuName"].ToString() + ";");

                        }
                        errorstr += "考号被:" + sbExists.ToString() + "占用;";
                    }
                    if (Com.Session.systype == "0" && !bllclassuser.ExistsIsMs(Com.Public.SqlEncStr(ClassId), Com.Session.usertid, Com.Session.schid, 1) == true)//班主任
                    {
                        errorstr += "非班主任不能添加学生!";
                    }
                    if (errorstr == "")
                    {

                        if (dotype == "e")
                        {
                            //更新学生
                            bll_stu.UpdateStu(model_stu);
                        }
                        else
                        {
                            stuids = bll_stu.AddStu(model_stu);
                        }
                        if (stuids > 0)
                        {
                            //添加家长
                            //先删除关联表数据
                            SchSystem.BLL.SchStuGenUn genunBll = new SchSystem.BLL.SchStuGenUn();
                            genunBll.DeleteStuUn(stuids);
                            SchSystem.BLL.SchGenInfo genBll = new SchSystem.BLL.SchGenInfo();
                            //对第一个家长资料进行处理
                            if (Convert.ToString(jzGenName1) != "" && Convert.ToString(jzTelNo1) != "")
                            {
                                int genid = genBll.GetMbId(jzTelNo1);
                                if (genid == 0)//无号码存在,则插数据
                                {
                                    SchSystem.Model.SchGenInfo genmodel = new SchSystem.Model.SchGenInfo();
                                    genmodel.TelNo = jzTelNo1;
                                    genmodel.RecUser = Com.Session.userid;
                                    genmodel.RecTime = DateTime.Now;
                                    genmodel.LastRecUser = Com.Session.userid;
                                    genmodel.LastRecTime = DateTime.Now;
                                    genid = genBll.Add(genmodel);
                                }
                                if (genid > 0)//插成功或者获取成功,则往关联表插数据
                                {
                                    SchSystem.Model.SchStuGenUn genunmodel = new SchSystem.Model.SchStuGenUn();
                                    genunmodel.StuId = stuids;
                                    genunmodel.GenId = genid;
                                    genunmodel.GenName = jzGenName1;
                                    genunmodel.Relation = Relation1 == "" ? "其他" : Relation1;
                                    genunBll.Add(genunmodel);
                                }
                            }
                            //对第二个家长进行处理
                            if (Convert.ToString(jzGenName2) != "" && Convert.ToString(jzTelNo2) != "")
                            {
                                int genid = genBll.GetMbId(jzTelNo2);
                                if (genid == 0)//无号码存在,则插数据
                                {
                                    SchSystem.Model.SchGenInfo genmodel = new SchSystem.Model.SchGenInfo();
                                    genmodel.TelNo = jzTelNo2;
                                    genmodel.RecUser = Com.Session.userid;
                                    genmodel.RecTime = DateTime.Now;
                                    genmodel.LastRecUser = Com.Session.userid;
                                    genmodel.LastRecTime = DateTime.Now;
                                    genid = genBll.Add(genmodel);
                                }
                                if (genid > 0)//插成功或者获取成功,则往关联表插数据
                                {
                                    SchSystem.Model.SchStuGenUn genunmodel = new SchSystem.Model.SchStuGenUn();
                                    genunmodel.StuId = stuids;
                                    genunmodel.GenId = genid;
                                    genunmodel.GenName = jzGenName2;
                                    genunmodel.Relation = Relation2 == "" ? "其他" : Relation2;
                                    genunBll.Add(genunmodel);
                                }
                            }
                        }
                        rsp.code = "success";
                        rsp.msg = "保存成功";
                    }
                    else
                    {
                        rsp.code = "error";
                        rsp.msg = errorstr;
                    }
                }
                catch (Exception ex)
                {
                    rsp.code = "error";
                    rsp.msg = ex.Message;
                }
            }

            return rsp;
        }
        #endregion
        #region 联动方法
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
                        ret = Com.Public.GetDrpAreaClassMaster(Com.Public.SqlEncStr(typecode), Com.Public.SqlEncStr(pcode), ref selp, false);
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