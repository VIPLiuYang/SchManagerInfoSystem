using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebMaster.Web.School
{
    public partial class SchShow : System.Web.UI.Page
    {
        //进入此页需要确认的三个关键参数
        public string dotype = "";//操作类型,修改或者是添加,a添加,e修改
        public string schid = "0";//需要建立的学校ID
        public string btnname = "添加";
        //根据上面两个参数的不同得到不同的参数
        public string areastr = "";
        public string umodelstr = "1";//学校model
        public string grades = "";//系统年级
        public string subs = "";//系统科目
        public string systype = "2";

        public string returl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Com.Session.systype == "2")
            {
                returl = "<div class=\"nav-search\" id=\"nav-search\"><a class=\"btn btn-danger btn-sm pull-right\" href=\"javascript:window.history.go(-1);\"><i class=\"icon-reply icon-only\"></i></a></div>";
            }

            if (!IsPostBack)
            {
                if (Com.Session.systype != "2")
                {
                    systype = Com.Session.systype;
                }
                //先得到操作类型
                SchSystem.BLL.SchInfo schbll = new SchSystem.BLL.SchInfo();
                SchSystem.Model.SchInfo usermodel = new SchSystem.Model.SchInfo();
                dotype = Request.Params["dotype"].ToString();
                if (dotype == "a")//添加
                {
                    
                }
                else if (dotype == "e")//修改,不能修改用户的类型及学校参数
                {
                    
                    btnname = "修改";
                    schid = Request.Params["schid"].ToString();
                    //判断跨界操作的可能性
                    if (!Com.Public.isVa(schid, ""))
                    {
                        Response.Write("出错,用户非法跨界操作!");
                        Response.End();
                    }
                    if (string.IsNullOrEmpty(schid))
                    {
                        Response.Write("无对应修改的记录!");
                        Response.End();
                    }
                    //获取修改的对应用户的
                    usermodel = schbll.GetModel(int.Parse(schid));
                    if (usermodel != null && usermodel.SchId > 0)
                    {
                        umodelstr = Newtonsoft.Json.JsonConvert.SerializeObject(usermodel);
                    }
                    else
                    {
                        Response.Write("无该学校!");
                        Response.End();
                    }
                    if (Com.Session.systype != "2")
                    {
                        btnname = "开始编辑";
                    }
                }
                else//不在添加及修改之内,则返回
                {
                    Response.Write("没有可供确认的操作类型!");
                    Response.End();
                }


                if (!string.IsNullOrEmpty(schid))
                {
                    //系统科目
                    SchSystem.BLL.SysSub syssubbll = new SchSystem.BLL.SysSub();
                    DataTable dtsub = syssubbll.GetList("'0' pId,SubCode id,SubName name,'false' checked", "1=1 Order by SubCode").Tables[0];
                    //获取学校的sub
                    SchSystem.BLL.SchSub schsubbll = new SchSystem.BLL.SchSub();
                    DataTable dtschsub = schsubbll.GetList("'0' pId,SubCode id,SubName name,'false' checked", "Stat=1 and SchId=" + schid + " Order by SubCode").Tables[0];


                    if (dtsub != null && dtschsub != null && dtsub.Rows.Count > 0 && dtschsub.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtsub.Rows.Count; i++)
                        {
                            DataRow[] drs = dtschsub.Select("id='" + dtsub.Rows[i]["id"].ToString() + "'");
                            if (drs.Length > 0)
                            {
                                dtsub.Rows[i]["checked"] = "true";
                            }
                        }
                    }
                    subs = Newtonsoft.Json.JsonConvert.SerializeObject(dtsub);
                    //获取整个系统的年级
                    SchSystem.BLL.SysGrade sysgradebll = new SchSystem.BLL.SysGrade();
                    DataTable dtgrade = sysgradebll.GetList("GradeType pId,GradeCode id,GradeName name,'false' checked,'false' nochecks", " 1=1 Order by GradeType,GradeLv").Tables[0];

                    //获取学校的sub
                    SchSystem.BLL.SchGradeInfo schgradebll = new SchSystem.BLL.SchGradeInfo();
                    DataTable dtschgrade = schgradebll.GetList("GradeCode id", "isfinish=0 and SchId=" + schid).Tables[0];
                    if (dtgrade != null && dtschgrade != null && dtgrade.Rows.Count > 0 && dtschgrade.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtgrade.Rows.Count; i++)
                        {
                            DataRow[] drs = dtschgrade.Select("id='" + dtgrade.Rows[i]["id"].ToString() + "'");
                            if (drs.Length > 0)
                            {
                                dtgrade.Rows[i]["checked"] = "true";
                            }
                        }
                    }
                    dtgrade.Columns["nochecks"].ColumnName = "nocheck";
                    DataRow dry = dtgrade.NewRow();
                    dry["pId"] = "0";
                    dry["id"] = "1";
                    dry["name"] = "幼儿园";
                    dry["nocheck"] = "false";
                    DataRow[] drs1 = dtgrade.Select("pId='1' and checked='false'");
                    if (drs1.Length == 0)
                    {
                        dry["checked"] = "true";
                    }
                    dtgrade.Rows.Add(dry);
                    dry = dtgrade.NewRow();
                    dry["pId"] = "0";
                    dry["id"] = "2";
                    dry["name"] = "小学";
                    dry["nocheck"] = "false";
                    DataRow[] drs2 = dtgrade.Select("pId='2' and checked='false'");
                    if (drs2.Length == 0)
                    {
                        dry["checked"] = "true";
                    }
                    dtgrade.Rows.Add(dry);
                    dry = dtgrade.NewRow();
                    dry["pId"] = "0";
                    dry["id"] = "3";
                    dry["name"] = "初中";
                    dry["nocheck"] = "false";
                    DataRow[] drs3 = dtgrade.Select("pId='3' and checked='false'");
                    if (drs3.Length == 0)
                    {
                        dry["checked"] = "true";
                    }
                    dtgrade.Rows.Add(dry);
                    dry = dtgrade.NewRow();
                    dry["pId"] = "0";
                    dry["id"] = "4";
                    dry["name"] = "高中";
                    dry["nocheck"] = "false";
                    DataRow[] drs4 = dtgrade.Select("pId='4' and checked='false'");
                    if (drs4.Length == 0)
                    {
                        dry["checked"] = "true";
                    }
                    dtgrade.Rows.Add(dry);
                    grades = Newtonsoft.Json.JsonConvert.SerializeObject(dtgrade);
                    //获取下拉列表
                    StringBuilder sbarea = new StringBuilder();
                    //获取省份
                    sbarea.Append("<select id=\"aprov\">");
                    string sareacode = "";
                    if (usermodel != null && usermodel.SchId > 0 && usermodel.AreaNo.Length == 6)
                    {
                        sareacode = usermodel.AreaNo.Substring(0, 2) + "0000";
                    }
                    sbarea.Append(Com.Public.GetDrpArea("0", "", ref sareacode, false));
                    sbarea.Append("</select>");
                    //获取城市
                    sbarea.Append("<select id=\"acity\">");
                    string sareacitycode = "";
                    if (usermodel != null && usermodel.SchId > 0 && usermodel.AreaNo.Length == 6)
                    {
                        sareacitycode = usermodel.AreaNo.Substring(0, 4) + "00";
                    }
                    sbarea.Append(Com.Public.GetDrpArea("1", sareacode, ref sareacitycode, false));
                    sbarea.Append("</select>");
                    //获取区县
                    sbarea.Append("<select id=\"acoty\">");
                    string sareacotycode = "";
                    if (usermodel != null && usermodel.SchId > 0 && usermodel.AreaNo.Length == 6)
                    {
                        sareacotycode = usermodel.AreaNo;
                    }
                    sbarea.Append(Com.Public.GetDrpArea("2", sareacitycode, ref sareacotycode, false));
                    sbarea.Append("</select>");
                    areastr = sbarea.ToString();
                }
            }
        }

        [WebMethod]
        public static string schsave(string dotype, string schid, string schname, string schaddr, string schmaster, string schmasterpst, string schmastertel, string iscity, string schstat, string selgrades, string selsubs, string areano, string schnote)
        {
            string ret = "";
            try
            {
                //学校名不能为空,
                if (string.IsNullOrEmpty(schname))
                {
                    ret += "学校名称不能为空!";
                }
                if (!Com.Public.isVa(schid, ""))
                {
                    ret += "无跨界权限;";
                }
                if (dotype == "e")
                {
                    
                }
                if (dotype == "a")
                {
                    
                }
                if (ret == "")
                {
                    SchSystem.BLL.SchInfo schbll = new SchSystem.BLL.SchInfo();
                    SchSystem.Model.SchInfo schmodel = new SchSystem.Model.SchInfo();
                    schmodel.LastRecTime = DateTime.Now;
                    schmodel.LastRecUser = Com.Session.userid;
                    schmodel.SchAddr = schaddr;
                    schmodel.SchMaster = schmaster;
                    schmodel.MasterPostion = schmasterpst;
                    schmodel.SchName = schname;
                    schmodel.SchTel = schmastertel;
                    schmodel.IsCity = int.Parse(iscity);
                    schmodel.Stat = int.Parse(schstat);
                    schmodel.AreaNo = areano;
                    schmodel.SchNote = schnote;
                    if (dotype == "e")
                    {
                        schmodel.SchId = int.Parse(schid);
                        schbll.UpdateSch(schmodel);
                    }
                    if (dotype == "a")
                    {
                        schmodel.RecTime = DateTime.Now;
                        schmodel.RecUser = Com.Session.userid;
                        schid = schbll.Add(schmodel).ToString();
                    }
                    if (int.Parse(schid) > 0)
                    {
                        //添加年级及科目
                        SchSystem.BLL.SchGradeInfo gradebll = new SchSystem.BLL.SchGradeInfo();
                        gradebll.DoSchGrades(Com.Session.userid, schid, selgrades);
                        //添加科目
                        SchSystem.BLL.SchSub subbll = new SchSystem.BLL.SchSub();
                        subbll.DoSchSubs(Com.Session.userid, schid, selsubs);
                    }
                    ret = "success";
                }

            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }
            return ret;

        }
    }
}