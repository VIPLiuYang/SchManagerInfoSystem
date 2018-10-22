using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin.Web.SchInfo
{
    public partial class SchEdit : System.Web.UI.Page
    {
        public string dotype = "";//操作类型,修改或者是添加,a添加,e修改
        public string schid = "0";//需要建立的学校ID
        public string areastr = "";
        public string grades = "";//系统年级
        public string subs = "";//系统科目
        public string schsubs = "";//系统科目
        
        public string sonsys = "";//子系统选择
        public string umodelstr = "1";//学校model
        public string usermanagerstr = "1";
        public string userinfostr = "";
        public string deptsuser = "";
        //public string usertname = "";//系统管理
        public string treeNodekinderstr = "";
        public string souretree = "";
        public string sysmatertree = "";
        public string subsmat = "";
        public string showmatertree = "";
        public string updateGrade = "";//畢業年級以及畢業年級的入學年份
        public string homeschtree = "";//家校互通平台子模块树
        public string showmaterxxttree = "";
        public string sarxxttree = "";
        public string percodes = "";
        public string percode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Com.Session.userid == null)
                {
                    Response.Redirect("../../Login.aspx");
                    Response.End();
                }
                else
                {
                    //先得到操作类型
                    SchSystem.BLL.SchInfo schbll = new SchSystem.BLL.SchInfo();
                    SchSystem.Model.SchInfo usermodel = new SchSystem.Model.SchInfo();
                    dotype = Request.Params["dotype"].ToString();
                    schid = Request.Params["schid"].ToString();
                    if (dotype == "e")//修改,不能修改用户的类型及学校参数
                    {
                        schid = Request.Params["schid"].ToString();
                        if (string.IsNullOrEmpty(schid))
                        {
                            Response.Write("无对应修改的记录!");
                            Response.End();
                        }
                        //获取修改的对应用户的
                        usermodel = schbll.GetSupportModel(int.Parse(schid));
                        if (usermodel != null && usermodel.SchId > 0)
                        {
                            umodelstr = Newtonsoft.Json.JsonConvert.SerializeObject(usermodel);
                        }
                        else
                        {
                            Response.Write("无该学校!");
                            Response.End();
                        }
                    }
                    else//不在添加及修改之内,则返回
                    {
                        Response.Write("没有可供确认的操作类型!");
                        Response.End();
                    }
                    if (!string.IsNullOrEmpty(schid))
                    {
                        //获取管理员账号密码信息
                        SchSystem.BLL.SchUserInfo suiBll = new SchSystem.BLL.SchUserInfo();
                        SchSystem.Model.SchUserInfo modeluserinfo = suiBll.GetSupportModel(int.Parse(schid), 1);
                        if (modeluserinfo != null)
                        {
                            if (modeluserinfo.PassWord == Com.Public.StrToMD5("123456"))
                            {
                                modeluserinfo.PassWord = "1";
                            }
                            
                        }
                        percode = usermodel.SchType.ToString();
                        //获取学校类型
                        SchSystem.BLL.SysPer sysperbll = new SchSystem.BLL.SysPer();
                        DataTable dtper = sysperbll.GetList("PerName Name,PerCode ID", " Stat=1 Order by convert(int,PerCode)").Tables[0];
                        if (dtper.Rows.Count > 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            for (int i = 0; i < dtper.Rows.Count; i++)
                            {
                                if (dtper.Rows[i]["ID"].ToString() == percode)
                                {
                                    sb.Append("<option value=\"" + dtper.Rows[i]["ID"].ToString() + "\" selected=\"selected\">" + dtper.Rows[i]["Name"].ToString() + "</option>");

                                }
                                else
                                {
                                    sb.Append("<option value=\"" + dtper.Rows[i]["ID"].ToString() + "\">" + dtper.Rows[i]["Name"].ToString() + "</option>");
                                }
                                //}
                            }
                            percodes = sb.ToString();
                        }
                        usermanagerstr = Newtonsoft.Json.JsonConvert.SerializeObject(modeluserinfo);
                        DataTable dtuserinfo = suiBll.GetList("UserId,UserName,UserTname", "SchId='" + int.Parse(schid) + "'").Tables[0];
                        userinfostr = Newtonsoft.Json.JsonConvert.SerializeObject(dtuserinfo);
                        //系统科目
                        SchSystem.BLL.SysSub syssubbll = new SchSystem.BLL.SysSub();
                        DataTable dtsub = syssubbll.GetList("'0' pId,SubCode id,SubName name,'false' checked", "Stat=1 Order by SubCode").Tables[0];//Stat=1 Order by id
                        DataTable dtsubmat = dtsub.Copy();
                        //获取学校的sub 
                        SchSystem.BLL.SchSub schsubbll = new SchSystem.BLL.SchSub();
                        DataTable dtschsub = schsubbll.GetList("'0' pId,SubCode id,SubName name,'false' checked", "Stat=1 and SchId='" + schid + "' Order by SubCode").Tables[0];
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
                        schsubs = Newtonsoft.Json.JsonConvert.SerializeObject(dtschsub);
                        subs = Newtonsoft.Json.JsonConvert.SerializeObject(dtsub);
                        subsmat = Newtonsoft.Json.JsonConvert.SerializeObject(dtsubmat);

                        //获取子系统:AutoId,AppCode,AppName,Stat,RecTime,RecUser,LastRecTime,LastRecUser
                        #region 获取子系统
                        SchSystem.BLL.SchApp schappBll = new SchSystem.BLL.SchApp();
                        DataTable dtschapp = schappBll.GetList("'0' pId,AppCode id,AppName name,'false' checked,AppCode", "AppCode not in (1,2) and Stat=1").Tables[0];
                        SchSystem.BLL.SchAppRole schapproleBll = new SchSystem.BLL.SchAppRole();
                        DataTable dtschapprole = schapproleBll.GetList("SchId='" + schid + "'").Tables[0];
                        if (dtschapp.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtschapp.Rows.Count; i++)
                            {
                                DataRow[] drstr = dtschapprole.Select();
                                if (drstr.Length > 0)
                                {
                                    string approlestr = drstr[0]["AppStr"].ToString();
                                    string[] approlearr = approlestr.Split(',');
                                    int approlearrlen = approlearr.Length;
                                    for (int j = 0; j < approlearrlen; j++)
                                    {
                                        if (dtschapp.Rows[i]["AppCode"].ToString() == approlearr[j])
                                        {
                                            dtschapp.Rows[i]["checked"] = "true";
                                        }
                                    }
                                }
                            }
                        }
                        sonsys = Newtonsoft.Json.JsonConvert.SerializeObject(dtschapp);
                        #endregion

                        //获取整个系统的年级
                        SchSystem.BLL.SysGrade sysgradebll = new SchSystem.BLL.SysGrade();
                        DataTable dtgrade = sysgradebll.GetList("GradeType pId,GradeCode id,GradeName name,'false' checked,'false' nochecks,'0' IsFinish,'' GradeYear,'' GradeId", " GradeCode<>'3004' and GradeCode<>'4004' Order by GradeType,GradeLv").Tables[0];

                        //获取学校的年级
                        #region 获取学校的年级
                        SchSystem.BLL.SchGradeInfo schgradebll = new SchSystem.BLL.SchGradeInfo();
                        DataTable dtschgrade = schgradebll.GetList("GradeCode id,GradeYear,GradeId", "isfinish='0' and SchId='" + schid + "'").Tables[0];

                        dtgrade.Columns["nochecks"].ColumnName = "nocheck";
                        DataRow dry = dtgrade.NewRow();
                        dry["pId"] = "0";
                        dry["id"] = "1";
                        dry["name"] = "幼儿园";
                        dry["nocheck"] = "false";
                        dry["IsFinish"] = "0";
                        dtgrade.Rows.Add(dry);
                        dry = dtgrade.NewRow();
                        dry["pId"] = "0";
                        dry["id"] = "2";
                        dry["name"] = "小学";
                        dry["nocheck"] = "false";
                        dry["IsFinish"] = "0";
                        dtgrade.Rows.Add(dry);
                        dry = dtgrade.NewRow();
                        dry["pId"] = "0";
                        dry["id"] = "3";
                        dry["name"] = "初中";
                        dry["nocheck"] = "false";
                        dry["IsFinish"] = "0";
                        dtgrade.Rows.Add(dry);
                        dry = dtgrade.NewRow();
                        dry["pId"] = "0";
                        dry["id"] = "4";
                        dry["name"] = "高中";
                        dry["nocheck"] = "false";
                        dry["IsFinish"] = "0";
                        dtgrade.Rows.Add(dry);

                        if (dtgrade != null && dtschgrade != null && dtgrade.Rows.Count > 0 && dtschgrade.Rows.Count > 0)//系统年级和学校年级不等于null
                        {
                            for (int i = 0; i < dtgrade.Rows.Count; i++)//遍历实体年级行数
                            {
                                DataRow[] drs = dtschgrade.Select("id='" + dtgrade.Rows[i]["id"].ToString() + "'");//根据系统年级id查询学校年级
                                if (drs.Length > 0)
                                {
                                    dtgrade.Rows[i]["checked"] = "true";
                                    dtgrade.Rows[i]["GradeYear"] = drs[0]["GradeYear"];
                                    dtgrade.Rows[i]["GradeId"] = drs[0]["GradeId"];
                                }
                            }
                        }

                        grades = Newtonsoft.Json.JsonConvert.SerializeObject(dtgrade);
                        #endregion

                        //获取服务资源:AutoId,AppCode,AppName,Stat,RecTime,RecUser,LastRecTime,LastRecUser
                        #region 获取服务资源
                        SchSystem.BLL.SchAppSoure schappsoureBll = new SchSystem.BLL.SchAppSoure();
                        DataTable dtschappsoure = schappsoureBll.GetList("'0' pId,AppCode id,AppName name,'false' checked,'false' isShar", "Stat=1").Tables[0];
                        SchSystem.BLL.SchAppRoleSoure sarsBll = new SchSystem.BLL.SchAppRoleSoure();
                        DataTable dtsars = sarsBll.GetList("SchId='" + schid + "'").Tables[0];
                        DataRow[] drsarsstr = dtsars.Select();
                        string[] approlesourearr = { };
                        if (drsarsstr.Length > 0)
                        {
                            approlesourearr = drsarsstr[0]["AppCode"].ToString().Split('|');
                        }
                        if (dtschappsoure.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtschappsoure.Rows.Count; i++)
                            {
                                //dtschappsoure.Rows[i]["name"] = dtschappsoure.Rows[i]["name"] + "【不共享】";
                                
                                for (int j = 0; j < approlesourearr.Length; j++)
                                {
                                    if (approlesourearr[j].Split(',').Length>1)
                                    {
                                        string appsourestr = approlesourearr[j].Split(',')[0];
                                        string appsourestat = approlesourearr[j].Split(',')[1];
                                        if (dtschappsoure.Rows[i]["id"].ToString() == appsourestr)
                                        {
                                            if (appsourestat == "1")
                                            {
                                                dtschappsoure.Rows[i]["name"] = dtschappsoure.Rows[i]["name"] + "【共享】";
                                                //dtschappsoure.Rows[i]["isShar"] = "true";
                                            }
                                            else if (appsourestat == "0")
                                            {
                                                dtschappsoure.Rows[i]["name"] = dtschappsoure.Rows[i]["name"] + "【不共享】";
                                                //dtschappsoure.Rows[i]["isShar"] = "false";
                                            }
                                            dtschappsoure.Rows[i]["checked"] = "true";
                                        }
                                    }
                                }
                                if (dtschappsoure.Rows[i]["checked"].ToString() == "false")
                                {
                                    dtschappsoure.Rows[i]["name"] = dtschappsoure.Rows[i]["name"] + "【不共享】";
                                    //dtschappsoure.Rows[i]["isShar"] = "false";
                                }
                            }
                        }
                        souretree = Newtonsoft.Json.JsonConvert.SerializeObject(dtschappsoure);
                        #endregion
                        #region 家校互通平台子模块
                        SchSystem.BLL.SchAppXXT saxxtBll = new SchSystem.BLL.SchAppXXT();
                        DataTable dtsaxxt = saxxtBll.GetList("'0' pId,AppCode id,AppName name,'false' checked,'false' isShar", "Stat=1").Tables[0];
                        SchSystem.BLL.SchAppRoleXXT sarxxtBll = new SchSystem.BLL.SchAppRoleXXT();
                        DataTable dtsarxxt = sarxxtBll.GetList("SchId='" + schid + "'").Tables[0];
                        DataRow[] drsarxxt = dtsarxxt.Select();
                        string[] approlexxtarr = { };
                        if (drsarxxt.Length > 0)
                        {
                            approlexxtarr = drsarxxt[0]["AppStr"].ToString().Split(',');
                            if (dtsaxxt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtsaxxt.Rows.Count; i++)
                                {
                                    for (int j = 0; j < approlexxtarr.Length; j++)
                                    {
                                        if (dtsaxxt.Rows[i]["id"].ToString() == approlexxtarr[j].ToString())
                                        {
                                            dtsaxxt.Rows[i]["checked"] = "true";
                                        }
                                    }
                                }
                            }

                        }
                        sarxxttree = Newtonsoft.Json.JsonConvert.SerializeObject(dtsaxxt);
                        #endregion
                        //获取教版
                        SchSystem.BLL.SysMater smaterBll = new SchSystem.BLL.SysMater();
                        DataTable dtsmater = smaterBll.GetList("'0' pId,MaterCode id,MaterName name,'false' checked,'' subcodechk,MaterCode,'' PerCode,'' SubCode,'' SubName", "").Tables[0];//Stat=1
                        SchSystem.BLL.SchPerSubMat spsmBll = new SchSystem.BLL.SchPerSubMat();
                        DataTable dtspsm = spsmBll.SchPerSubMatVMatSub("SchId='" + schid + "' Order by convert(int,PerCode) asc").Tables[0];
                        sysmatertree = Newtonsoft.Json.JsonConvert.SerializeObject(dtsmater);
                        showmatertree = Newtonsoft.Json.JsonConvert.SerializeObject(dtspsm);
                        //家校互通平台学段、科目教版
                        SchSystem.BLL.SchPerSubMatXXT spsmxxtBll = new SchSystem.BLL.SchPerSubMatXXT();
                        DataTable dtspsmxxt = spsmxxtBll.SchPerSubMatXXTV("SchId='" + schid + "' Order by convert(int,PerCode) asc").Tables[0];
                        showmaterxxttree = Newtonsoft.Json.JsonConvert.SerializeObject(dtspsmxxt);
                        #region 获取家校互通服务资源:AutoId,AppCode,AppName,Stat,RecTime,RecUser,LastRecTime,LastRecUser
                        SchSystem.BLL.SchAppXXT schappxxtBll = new SchSystem.BLL.SchAppXXT();
                        DataTable dtschappxxt = schappxxtBll.GetList("'0' pId,AppCode id,AppName name,'false' checked,AppCode", "").Tables[0];//Stat=1
                        homeschtree = Newtonsoft.Json.JsonConvert.SerializeObject(dtschappxxt);
                        #endregion
                        //获取下拉列表
                        StringBuilder sbarea = new StringBuilder();
                        //获取省份
                        sbarea.Append("<select id=\"aprov\">");
                        string sareacode = "";
                        if (usermodel != null && usermodel.SchId > 0 && usermodel.AreaNo.Length == 6)
                        {
                            sareacode = usermodel.AreaNo.Substring(0, 2) + "0000";
                        }
                        sbarea.Append(SchWebAdmin.Com.Public.GetDrpArea("0", "", ref sareacode, false));
                        sbarea.Append("</select>");
                        //获取城市
                        sbarea.Append("<select id=\"acity\">");
                        string sareacitycode = "";
                        if (usermodel != null && usermodel.SchId > 0 && usermodel.AreaNo.Length == 6)
                        {
                            sareacitycode = usermodel.AreaNo.Substring(0, 4) + "00";
                        }
                        sbarea.Append(SchWebAdmin.Com.Public.GetDrpArea("1", sareacode, ref sareacitycode, false));
                        sbarea.Append("</select>");
                        //获取区县
                        sbarea.Append("<select id=\"acoty\">");
                        string sareacotycode = "";
                        if (usermodel != null && usermodel.SchId > 0 && usermodel.AreaNo.Length == 6)
                        {
                            sareacotycode = usermodel.AreaNo;
                        }
                        sbarea.Append(SchWebAdmin.Com.Public.GetDrpArea("2", sareacitycode, ref sareacotycode, false));
                        sbarea.Append("</select>");
                        areastr = sbarea.ToString();
                        //獲取當前年份
                        string CurrentYear = "";
                        if (DateTime.Now.Month < 8)//当当前日期在8月份之前
                        {
                            CurrentYear = (DateTime.Now.Year - 1).ToString();//系统当前年份-1
                        }
                        else
                        {
                            CurrentYear = DateTime.Now.Year.ToString();//系统当前年份
                        }
                        //獲取畢業年級的年級名稱和入學年份
                        //DataTable dtres = schgradebll.GetListGradeFinish("GradeCode,GradeName,GradeYear", int.Parse(schid), int.Parse(CurrentYear)).Tables[0];
                        DataTable dtres = schgradebll.Graduated(int.Parse(schid)).Tables[0];
                        updateGrade = Newtonsoft.Json.JsonConvert.SerializeObject(dtres);

                        //根据部门分类查询人员信息
                        //当前学校老师
                        SchSystem.BLL.SchUserDeptV userbll = new SchSystem.BLL.SchUserDeptV();
                        DataTable dtuser = userbll.GetList("DeptId,DepartName,UserId,UserTname", "Stat=1 and Ustat=1 and SchId=" + Com.Public.SqlEncStr(Com.Public.getKey("adminschid"))).Tables[0];
                        SchSystem.BLL.SchDepartInfo dptbll = new SchSystem.BLL.SchDepartInfo();
                        DataTable dt = dptbll.GetList("Pid pId,convert(varchar(20),DepartId) id,DepartName name,'0' isms,'' subcode,'false' checked,'true' nochecks", "SchId=" + Com.Public.getKey("adminschid") + " and Stat=1 Order by OrderId,DepartName").Tables[0];
                        DataTable dtdptuser = dt.Clone();
                        dtdptuser.Columns["nochecks"].ColumnName = "nocheck";
                        if (dt.Rows.Count > 0)
                        {
                            //合并人员到部门表
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dtdptuser.Rows.Add(dt.Rows[i].ItemArray);
                                //获取该部门下的人员
                                DataRow[] drss = dtuser.Select("DeptId='" + dt.Rows[i]["id"].ToString() + "'");
                                if (drss.Length > 0)
                                {
                                    foreach (DataRow item in drss)
                                    {
                                        DataRow dr = dtdptuser.NewRow();

                                        dr["id"] = item["DeptId"].ToString() + "_" + item["UserId"].ToString();
                                        dr["name"] = item["UserTname"].ToString();
                                        dr["pId"] = item["DeptId"].ToString();
                                        if (dr["name"].ToString() == usermodel.Artisan.ToString())
                                        {
                                            dr["checked"] = true;
                                        }
                                        dtdptuser.Rows.Add(dr);
                                    }
                                }
                            }
                        }
                        deptsuser = Newtonsoft.Json.JsonConvert.SerializeObject(dtdptuser);
                    }
                }
            }
        }

        [WebMethod]
        public static Com.DataPack.DataRsp<string> schsave(List<string> arr)
        {
            string ret = ""; int schid = 0; string kindergarten = ""; string primarySchool = ""; string juniorHighSchool = "";
            string highSchool = ""; string selsubs = ""; string sonsys = ""; string schsonsysenabletime = ""; string useridhidden = ""; string resourcemodules = ""; string homschmodules = "";
            string kinderstr = ""; string primarystr = ""; string juniorstr = ""; string highstr = ""; string manageracount = "";
            string homkinderstr = ""; string homprimarystr = ""; string homjuniorstr = ""; string homhighstr = "";
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            try
            {
                    SchSystem.Model.SchInfo schmodel = new SchSystem.Model.SchInfo();
                    SchSystem.BLL.SchInfo schbll = new SchSystem.BLL.SchInfo();
                    foreach (string str in arr)
                    {
                        string[] strarr = str.Split('#');
                        if (strarr[0] == "schid") { schmodel.SchId = int.Parse(strarr[1]); }
                        else if (strarr[0] == "schname") { schmodel.SchName = strarr[1]; }
                        else if (strarr[0] == "acoty") { schmodel.AreaNo = strarr[1]; }
                        else if (strarr[0] == "iscity") { schmodel.IsCity = int.Parse(strarr[1]); }
                        else if (strarr[0] == "schaddr") { schmodel.SchAddr = strarr[1]; }
                        else if (strarr[0] == "schmaster") { schmodel.SchMaster = strarr[1]; }
                        else if (strarr[0] == "schmasterpst") { schmodel.MasterPostion = strarr[1]; }
                        else if (strarr[0] == "schmastertel") { schmodel.SchTel = strarr[1]; }
                        else if (strarr[0] == "frontlinetechni") { schmodel.Artisan = strarr[1]; }
                        else if (strarr[0] == "principalname") { schmodel.PrincipalName = strarr[1]; }
                        else if (strarr[0] == "principaltel") { schmodel.PrincipalTel = strarr[1]; }
                        else if (strarr[0] == "customerservicestaffname") { schmodel.ServiceName = strarr[1]; }
                        else if (strarr[0] == "customerservicestaffnametel") { schmodel.ServiceTel = strarr[1]; }
                        else if (strarr[0] == "platformname") { schmodel.PlatformName = strarr[1]; }
                        else if (strarr[0] == "platformico") { schmodel.PlatformIco = strarr[1]; }
                        else if (strarr[0] == "platformurl") { schmodel.PlatformUrl = strarr[1]; }
                        else if (strarr[0] == "ipaddress") { schmodel.PlatformIP = strarr[1]; }
                        else if (strarr[0] == "schoolsection") { schmodel.SchoolSection = strarr[1]; }
                        else if (strarr[0] == "kindergarten") { kindergarten = strarr[1]; }
                        else if (strarr[0] == "primarySchool") { primarySchool = strarr[1]; }
                        else if (strarr[0] == "juniorHighSchool") { juniorHighSchool = strarr[1]; }
                        else if (strarr[0] == "highSchool") { highSchool = strarr[1]; }
                        else if (strarr[0] == "initialpwd") { schmodel.Initialpwd = strarr[1]; }
                        else if (strarr[0] == "selsubs") { selsubs = strarr[1]; }
                        else if (strarr[0] == "sonsys") { sonsys = strarr[1]; }
                        else if (strarr[0] == "resourceplatformname") { schmodel.ResourcePlatformName = strarr[1]; }
                        else if (strarr[0] == "resourceplatformico") { schmodel.ResourcePlatformIco = strarr[1]; }
                        else if (strarr[0] == "resourceplatformurl") { schmodel.ResourcePlatformUrl = strarr[1]; }
                        else if (strarr[0] == "resourceplatformip") { schmodel.ResourcePlatformIP = strarr[1]; }
                        else if (strarr[0] == "gradechklvalstr") { schmodel.SchoolSection = strarr[1]; }
                        else if (strarr[0] == "creator") { schmodel.SchCreator = strarr[1]; }
                        else if (strarr[0] == "useridhidden") { useridhidden = strarr[1]; }
                        else if (strarr[0] == "resourcemodules") { if (((IList)strarr).Contains(strarr[1])) { resourcemodules = strarr[1]; } else { resourcemodules = ""; } }
                        else if (strarr[0] == "sourceserverstat") { if (((IList)strarr).Contains(strarr[1])) { schmodel.SourceSerStat = int.Parse(strarr[1]); } else { schmodel.SourceSerStat = 0; } }
                        else if (strarr[0] == "kinderstr") { if (((IList)strarr).Contains(strarr[1])) { kinderstr = strarr[1]; } else { kinderstr = ""; } }
                        else if (strarr[0] == "primarystr") { if (((IList)strarr).Contains(strarr[1])) { primarystr = strarr[1]; } else { primarystr = ""; } }
                        else if (strarr[0] == "juniorstr") { if (((IList)strarr).Contains(strarr[1])) { juniorstr = strarr[1]; } else { juniorstr = ""; } }
                        else if (strarr[0] == "highstr") { if (((IList)strarr).Contains(strarr[1])) { highstr = strarr[1]; } else { highstr = ""; } }
                        //else if (strarr[0] == "manageracount") { manageracount = strarr[1]; }
                        else if (strarr[0] == "manageracount") { if (((IList)strarr).Contains(strarr[1])) { schmodel.Manageracount = strarr[1]; } else { schmodel.Manageracount = ""; } }

                        else if (strarr[0] == "per") { if (((IList)strarr).Contains(strarr[1])) { schmodel.SchType = int.Parse(strarr[1]); } else { schmodel.SchType = 0; } }
                        else if (strarr[0] == "drpm") { if (((IList)strarr).Contains(strarr[1])) { schmodel.OpenMonth = int.Parse(strarr[1]); } else { schmodel.OpenMonth = 0; } }

                        //家校互通平台基础数据
                        else if (strarr[0] == "homeschoolingname") { if (((IList)strarr).Contains(strarr[1])) { schmodel.HomeSchPlatName = strarr[1]; } else { schmodel.HomeSchPlatName = ""; } }
                        else if (strarr[0] == "homeschoolingico") { if (((IList)strarr).Contains(strarr[1])) { schmodel.HomeSchPlatIco = strarr[1]; } else { schmodel.HomeSchPlatIco = ""; } }
                        else if (strarr[0] == "homeschoolingurl") { if (((IList)strarr).Contains(strarr[1])) { schmodel.HomeSchPlatUrl = strarr[1]; } else { schmodel.HomeSchPlatUrl = ""; } }
                        else if (strarr[0] == "homeschoolingip") { if (((IList)strarr).Contains(strarr[1])) { schmodel.HomeSchPlatIP = strarr[1]; } else { schmodel.HomeSchPlatIP = ""; } }
                        else if (strarr[0] == "homeschoolbaxicstat") { if (((IList)strarr).Contains(strarr[1])) { schmodel.HomeSchBasicStat = int.Parse(strarr[1]); } else { schmodel.HomeSchBasicStat = 0; } }
                        else if (strarr[0] == "homeschoolservstat") { if (((IList)strarr).Contains(strarr[1])) { schmodel.HomeschServStat = int.Parse(strarr[1]); } else { schmodel.HomeschServStat = 0; } }
                        //家校互通平台学段、科目及教版
                        else if (strarr[0] == "homschkinderstr") { if (((IList)strarr).Contains(strarr[1])) { homkinderstr = strarr[1]; } else { homkinderstr = ""; } }
                        else if (strarr[0] == "homschprimarystr") { if (((IList)strarr).Contains(strarr[1])) { homprimarystr = strarr[1]; } else { homprimarystr = ""; } }
                        else if (strarr[0] == "homschjuniorstr") { if (((IList)strarr).Contains(strarr[1])) { homjuniorstr = strarr[1]; } else { homjuniorstr = ""; } }
                        else if (strarr[0] == "homschhighstr") { if (((IList)strarr).Contains(strarr[1])) { homhighstr = strarr[1]; } else { homhighstr = ""; } }
                        //家校互通平台子模块
                        else if (strarr[0] == "homschmodules") { if (((IList)strarr).Contains(strarr[1])) { homschmodules = strarr[1]; } else { homschmodules = ""; } }
                    }
                    string Manageracount = schmodel.Manageracount;
                    string SchMaster = schmodel.SchMaster;
                    if (string.IsNullOrEmpty(Manageracount) || string.IsNullOrEmpty(SchMaster))
                    {
                        rsp.code = "IsNullEmpty";
                        rsp.msg = "管理员账号或管理员姓名为空";
                    }
                    else if (schmodel.PlatformIP.Length > 39)//判断管理平台IP地址:IPv4最长12位，IPv6最长32位
                    {
                        rsp.code = "Platformip";
                        rsp.msg = "管理平台IP地址超出字符个数";
                    }
                    else if (schmodel.ResourcePlatformIP.Length > 39)//判断资源平台IP地址:IPv4最长12位，IPv6最长32位
                    {
                        rsp.code = "ResourcePlatip";
                        rsp.msg = "管理平台IP地址超出字符个数";
                    }
                    else if (schmodel.HomeSchPlatIP.Length > 39)//判断家校互通平台IP地址:IPv4最长12位，IPv6最长32位
                    {
                        rsp.code = "SchxxtPlatip";
                        rsp.msg = "管理平台IP地址超出字符个数";
                    }
                    else
                    {
                        StringBuilder sbstr = new StringBuilder();
                        string[] kindergartenarr = kindergarten.Split(',');
                        var kindergartenarrs = kindergartenarr[1].Split('|');
                        string[] primarySchoolarr = primarySchool.Split(',');
                        var primarySchoolarrs = primarySchoolarr[1].Split('|');
                        string[] juniorHighSchoolarr = juniorHighSchool.Split(',');
                        var juniorHighSchoolarrs = juniorHighSchoolarr[1].Split('|');
                        string[] highSchoolarr = highSchool.Split(',');
                        var highSchoolarrs = highSchoolarr[1].Split('|');

                        if (schmodel.SchoolSection == "")
                        {
                            schmodel.SchoolSection = "0";
                        }

                        schmodel.LastRecTime = DateTime.Now;
                        schmodel.LastRecUser = Com.Session.userid;
                        schmodel.HomeSchCreateTime = DateTime.Now;

                        schmodel.Stat = 1;//0代表废弃；1代表正常；2代表删除

                        if (schmodel.Initialpwd == "123456" && useridhidden != "")
                        {
                            ResetPwd(useridhidden);
                        }

                        SchSystem.BLL.SchGradeInfo gradebll = new SchSystem.BLL.SchGradeInfo();
                        bool resbool = schbll.UpdateSch(schmodel);//更新学校基础信息
                        schbll.UpdateSchXXT(schmodel);//更新学校家校互通平台基础数据
                        schid = schmodel.SchId;
                        gradebll.SupportSysSchGradeAdd(schid);
                        if (resbool)
                        {
                            //DataTable dtisgrade = gradebll.GetList("SchId='" + schid + "' and IsFinish=0").Tables[0];
                            //更新年級
                            UpdateGrade(schid, kindergarten, primarySchool, juniorHighSchool, highSchool, gradebll);
                            //添加科目
                            subAdd(selsubs, schid);
                            //添加子系统
                            SonSysAdd(sonsys, schid);
                            //资料科目及教版
                            dataSubMat(schid, kinderstr, primarystr, juniorstr, highstr);
                            //资源模块
                            ResourcesModel(resourcemodules, schid);
                            //家校互通平台学段科目及教版
                            schxxtPerSubMat(schid, homkinderstr, homprimarystr, homjuniorstr, homhighstr);
                            //家校互通平台子模块
                            schxxtSonModel(homschmodules, schid);
                            rsp.code = "Success";
                            rsp.msg = "修改成功";
                        }
                        else
                        {
                            rsp.code = "Error";
                            rsp.msg = "修改失败";
                        }
                    }
                
            }
            catch (Exception ex)
            {
                rsp.code = "ExcepError";
                rsp.msg = ex.Message;
            }
            return rsp;
        }
        #region 更新年級信息
        public static void UpdateGrade(int schid, string kindergarten, string primarySchool, string juniorHighSchool, string highSchool, SchSystem.BLL.SchGradeInfo gradebll)
        {
            //幼儿园
            if (kindergarten != "")
            {
                string[] gradeIdsarr = kindergarten.Split(',');
                int gradeIdsLen = gradeIdsarr.Length;
                for (int i = 0; i < gradeIdsLen; i++)
                {
                    var gradeitemarr = gradeIdsarr[i].Split('|');
                    gradebll.UpdateGrade(gradeitemarr[1], gradeitemarr[0], schid, int.Parse(gradeitemarr[4]));
                }
            }
            //小学
            if (primarySchool != "")
            {
                string[] gradeIdsarr = primarySchool.Split(',');
                int gradeIdsLen = gradeIdsarr.Length;
                for (int i = 0; i < gradeIdsLen; i++)
                {
                    var gradeitemarr = gradeIdsarr[i].Split('|');
                    gradebll.UpdateGrade(gradeitemarr[1], gradeitemarr[0], schid, int.Parse(gradeitemarr[4]));
                }
            }
            //初中
            if (juniorHighSchool != "")
            {
                string[] gradeIdsarr = juniorHighSchool.Split(',');
                int gradeIdsLen = gradeIdsarr.Length;
                for (int i = 0; i < gradeIdsLen; i++)
                {
                    var gradeitemarr = gradeIdsarr[i].Split('|');
                    gradebll.UpdateGrade(gradeitemarr[1], gradeitemarr[0], schid, int.Parse(gradeitemarr[4]));
                }
            }
            //高中
            if (highSchool != "")
            {
                string[] gradeIdsarr = highSchool.Split(',');
                int gradeIdsLen = gradeIdsarr.Length;
                for (int i = 0; i < gradeIdsLen; i++)
                {
                    var gradeitemarr = gradeIdsarr[i].Split('|');
                    gradebll.UpdateGrade(gradeitemarr[1], gradeitemarr[0], schid, int.Parse(gradeitemarr[4]));
                }
            }
        }
        #endregion
        #region 添加科目
        public static void subAdd(string selsubs, int schid)
        {
            SchSystem.BLL.SchSub subbll = new SchSystem.BLL.SchSub();
            
            if (selsubs != "")
            {
                
                subbll.DoSchSubs(Com.Session.userid, schid.ToString(), selsubs);//admin:  SchWebAdmin.Com.Session.userid
            }
        }
        #endregion
        #region 添加子系统
        public static void SonSysAdd(string sonsys, int schid)
        {
            if (sonsys != "")
            {

                SchSystem.BLL.SchAppRole sarBll = new SchSystem.BLL.SchAppRole();
                SchSystem.Model.SchAppRole sarModel = new SchSystem.Model.SchAppRole();
                sarModel.SchId = schid;
                sarModel.AppStr = sonsys;
                if (sarBll.SchAppExists(schid))
                {
                    sarModel.LastRecTime = DateTime.Now;
                    sarModel.LastRecUser = Com.Session.userid;
                    sarBll.Update(sarModel);

                }
                else
                {
                    sarModel.RecTime = DateTime.Now;
                    sarModel.RecUser = Com.Session.userid;
                    sarBll.Add(sarModel);
                }
            }
        }
        #endregion
        #region 资料科目及教版
        public static void dataSubMat(int schid, string kinderstr, string primarystr, string juniorstr, string highstr)
        {
            SchSystem.BLL.SchPerSubMat spsmBll = new SchSystem.BLL.SchPerSubMat();
            SchSystem.Model.SchPerSubMat spsmModel = new SchSystem.Model.SchPerSubMat();
            bool resbools = spsmBll.Exists(schid);//判断原来是否存在
            if (resbools)//存在
            {
                spsmBll.Delete(schid);//删除
            }
            if (kinderstr != "")
            {
                string[] kinderstrarr = kinderstr.Split('|');
                for (int i = 0; i < kinderstrarr.Length; i++)
                {
                    string[] kinderarr = kinderstrarr[i].Split(',');
                    spsmModel.SchId = schid;
                    spsmModel.PerCode = kinderarr[0];
                    spsmModel.SubCode = kinderarr[1];
                    spsmModel.MaterCode = kinderarr[2];
                    int s = spsmBll.Add(spsmModel);
                }
            }
            if (primarystr != "")
            {
                string[] primarystrarr = primarystr.Split('|');
                for (int i = 0; i < primarystrarr.Length; i++)
                {
                    string[] primaryarr = primarystrarr[i].Split(',');
                    spsmModel.SchId = schid;
                    spsmModel.PerCode = primaryarr[0];
                    spsmModel.SubCode = primaryarr[1];
                    spsmModel.MaterCode = primaryarr[2];
                    spsmBll.Add(spsmModel);
                }
            }
            if (juniorstr != "")
            {
                string[] juniorstrarr = juniorstr.Split('|');
                for (int i = 0; i < juniorstrarr.Length; i++)
                {
                    string[] juniorarr = juniorstrarr[i].Split(',');
                    spsmModel.SchId = schid;
                    spsmModel.PerCode = juniorarr[0];
                    spsmModel.SubCode = juniorarr[1];
                    spsmModel.MaterCode = juniorarr[2];
                    spsmBll.Add(spsmModel);
                }
            }
            if (highstr != "")
            {
                string[] highstrarr = highstr.Split('|');
                for (int i = 0; i < highstrarr.Length; i++)
                {
                    string[] higharr = highstrarr[i].Split(',');
                    spsmModel.SchId = schid;
                    spsmModel.PerCode = higharr[0];
                    spsmModel.SubCode = higharr[1];
                    spsmModel.MaterCode = higharr[2];
                    spsmBll.Add(spsmModel);
                }
            }
        }
        #endregion
        #region 资源模块
        public static void ResourcesModel(string resourcemodules, int schid)
        {
            SchSystem.BLL.SchAppRoleSoure srsBll = new SchSystem.BLL.SchAppRoleSoure();
            SchSystem.Model.SchAppRoleSoure srsModel = new SchSystem.Model.SchAppRoleSoure();
            srsModel.SchId = schid;
            srsModel.AppCode = resourcemodules;
            if (srsBll.SchAppExists(schid))
            {
                srsModel.LastRecTime = DateTime.Now;
                srsModel.LastRecUser = Com.Session.userid;
                srsBll.Update(srsModel);
            }
            else
            {
                srsModel.RecTime = DateTime.Now;
                srsModel.RecUser = Com.Session.userid;
                srsBll.Add(srsModel);
            }
        }
        #endregion
        #region 家校互通平台学段科目及教版
        public static void schxxtPerSubMat(int schid, string homkinderstr, string homprimarystr, string homjuniorstr, string homhighstr)
        {
            SchSystem.BLL.SchPerSubMatXXT spsmxxtBll = new SchSystem.BLL.SchPerSubMatXXT();
            SchSystem.Model.SchPerSubMatXXT spsmxxtModel = new SchSystem.Model.SchPerSubMatXXT();
            bool resxxtbool = spsmxxtBll.Exists(schid);//判断原来是否存在
            if (resxxtbool)//存在
            {
                spsmxxtBll.Delete(schid);//删除
            }
            if (homkinderstr != "")
            {
                string[] kinderstrarr = homkinderstr.Split('|');
                for (int i = 0; i < kinderstrarr.Length; i++)
                {
                    string[] kinderarr = kinderstrarr[i].Split(',');
                    spsmxxtModel.SchId = schid;
                    spsmxxtModel.PerCode = kinderarr[0];
                    spsmxxtModel.SubCode = kinderarr[1];
                    spsmxxtModel.MaterCode = kinderarr[2];
                    spsmxxtBll.Add(spsmxxtModel);
                }
            }
            if (homprimarystr != "")
            {
                string[] primarystrarr = homprimarystr.Split('|');
                for (int i = 0; i < primarystrarr.Length; i++)
                {
                    string[] primaryarr = primarystrarr[i].Split(',');
                    spsmxxtModel.SchId = schid;
                    spsmxxtModel.PerCode = primaryarr[0];
                    spsmxxtModel.SubCode = primaryarr[1];
                    spsmxxtModel.MaterCode = primaryarr[2];
                    spsmxxtBll.Add(spsmxxtModel);
                }
            }
            if (homjuniorstr != "")
            {
                string[] juniorstrarr = homjuniorstr.Split('|');
                for (int i = 0; i < juniorstrarr.Length; i++)
                {
                    string[] juniorarr = juniorstrarr[i].Split(',');
                    spsmxxtModel.SchId = schid;
                    spsmxxtModel.PerCode = juniorarr[0];
                    spsmxxtModel.SubCode = juniorarr[1];
                    spsmxxtModel.MaterCode = juniorarr[2];
                    spsmxxtBll.Add(spsmxxtModel);
                }
            }
            if (homhighstr != "")
            {
                string[] highstrarr = homhighstr.Split('|');
                for (int i = 0; i < highstrarr.Length; i++)
                {
                    string[] higharr = highstrarr[i].Split(',');
                    spsmxxtModel.SchId = schid;
                    spsmxxtModel.PerCode = higharr[0];
                    spsmxxtModel.SubCode = higharr[1];
                    spsmxxtModel.MaterCode = higharr[2];
                    spsmxxtBll.Add(spsmxxtModel);
                }
            }
        }
        #endregion
        #region 家校互通平台子模块
        /// <summary>
        /// 家校互通平台子模块
        /// </summary>
        /// <param name="homschmodules"></param>
        /// <param name="schid"></param>
        public static void schxxtSonModel(string homschmodules, int schid)
        {
            if (homschmodules == null)
                homschmodules = "";
            SchSystem.BLL.SchAppRoleXXT sarxxtBll = new SchSystem.BLL.SchAppRoleXXT();
            SchSystem.Model.SchAppRoleXXT sarxxtModel = new SchSystem.Model.SchAppRoleXXT();
            sarxxtModel.SchId = schid;
            sarxxtModel.AppStr = homschmodules;
            if (sarxxtBll.SchAppExists(schid))
            {
                sarxxtModel.LastRecTime = DateTime.Now;
                sarxxtModel.LastRecUser = Com.Session.userid;
                sarxxtBll.Update(sarxxtModel);
            }
            else
            {
                sarxxtModel.RecTime = DateTime.Now;
                sarxxtModel.RecUser = Com.Session.userid;
                sarxxtBll.Add(sarxxtModel);
            }
        }
        #endregion
        #region
        [WebMethod]
        public static Com.DataPack.DataRsp<string> ExistsClassData(int schid, int percode)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            SchSystem.BLL.SchClassInfo sciBll = new SchSystem.BLL.SchClassInfo();
            bool resultBool = sciBll.ExistsPerClass(percode.ToString(), schid);
            if (resultBool)
            {
                rsp.code = "01";
                rsp.msg = "请先删除班级";
            }
            else
            {
                rsp.code = "Error";
                rsp.msg = "年级无班级";
            }
            return rsp;
        }
        #endregion
        #region
        [WebMethod]
        public static string ExistsClassSubUser(string schid, string subcode)
        {
            string ret = "";
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            SchSystem.BLL.SchSubLeader sslBll = new SchSystem.BLL.SchSubLeader();
            bool sslbool = sslBll.ExistsClassSubUser(schid, subcode);
            if (sslbool)
            {
                rsp.code = "success01";
                rsp.msg = "班級组长已存在";
            }
            else
            {
                SchSystem.BLL.SchClassUser scuBll = new SchSystem.BLL.SchClassUser();
                bool scuBool = scuBll.ExistsClassSubUser(schid, subcode);
                if (scuBool)
                {
                    rsp.code = "success02";
                    rsp.msg = "任课教师已存在";
                }
                else
                {
                    rsp.code = "";
                    rsp.msg = "0";
                }
            }
            return ret = Newtonsoft.Json.JsonConvert.SerializeObject(rsp);
        }
        #endregion
        #region 
        [WebMethod]
        public static Com.DataPack.DataRsp<string> isSchSub(string schid, string subcode)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            if (Com.Session.userid == null)
            {
                rsp.code = "expire";
                rsp.msg = "页面已经过期，请重新登录";
            }
            else
            {
                try
                {
                    SchSystem.BLL.SchClassUser scuBll = new SchSystem.BLL.SchClassUser();
                    bool resbool = scuBll.ExistsClassSubUser(schid, subcode);
                    if (resbool)
                    {
                        rsp.code = "ClassTeacher";
                        rsp.msg = "班级科目中已有关联";
                    }
                    else
                    {
                        SchSystem.BLL.SchSubLeader sslBll = new SchSystem.BLL.SchSubLeader();
                        bool resultbool = sslBll.ExistsClassSubUser(schid, subcode);
                        if (resultbool)
                        {
                            rsp.code = "SubLeader";
                            rsp.msg = "科目组长已关联";
                        }
                    }
                }
                catch (Exception ex)
                {
                    rsp.code = "ExcepError";
                    rsp.msg = ex.Message;
                }
            }
            return rsp;
        }
        #endregion
        #region 修改学校管理员密码
        /// <summary>
        /// 修改学校管理员密码
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        [WebMethod]
        public static string ResetPwd(string userid)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            if (Com.Session.userid == null)
            {
                rsp.code = "expire";
                rsp.msg = "页面已经过期，请重新登录";
            }
            else
            {
                SchSystem.BLL.SchUserInfo suiBll = new SchSystem.BLL.SchUserInfo();
                bool resbool = suiBll.UpdatePw(int.Parse(userid), Com.Public.StrToMD5("123456"));
                if (resbool)
                {
                    rsp.code = "Success";
                    rsp.msg = "修改成功";
                }
                else
                {
                    rsp.code = "Error";
                    rsp.msg = "修改失败";
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rsp);
        }
        #endregion
    }
}