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
    public partial class SchAdd : System.Web.UI.Page
    {
        public string schid = "0";//需要建立的学校ID
        public string areastr = "";
        public string grades = "";//系统年级
        public string subs = "";//系统科目
        public string sonsys = "";//子系统选择
        public string usertname = "";//系统管理
        public string deptsuser = "";
        public string treeNodekinderstr = "";
        public string souretree = "";
        public string sysmatertree = "";
        public string subsmat = "";
        public string homeschtree = "";//家校互通平台子模块树
        public string percodes="";
        public string percode="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                usertname = Com.Session.uname;

                //先得到操作类型
                SchSystem.BLL.SchInfo schbll = new SchSystem.BLL.SchInfo();
                SchSystem.Model.SchInfo usermodel = new SchSystem.Model.SchInfo();

                SchSystem.BLL.SysSub syssubbll = new SchSystem.BLL.SysSub();
                DataTable dtsub = syssubbll.GetList("'0' pId,SubCode id,SubName name,'false' checked", "Stat=1 Order by SubCode").Tables[0];//Stat=1 
                DataTable dtsubmat = dtsub.Copy();
                //获取学校的sub 
                SchSystem.BLL.SchSub schsubbll = new SchSystem.BLL.SchSub();
                DataTable dtschsub = schsubbll.GetList("'0' pId,SubCode id,SubName name,'false' checked", "Stat=1 and SchId='" + schid + "' Order by SubCode").Tables[0];
                subs = Newtonsoft.Json.JsonConvert.SerializeObject(dtsub);
                subsmat = Newtonsoft.Json.JsonConvert.SerializeObject(dtsubmat);

                treeNodekinderstr = Newtonsoft.Json.JsonConvert.SerializeObject(dtschsub);
                //获取子系统:AutoId,AppCode,AppName,Stat,RecTime,RecUser,LastRecTime,LastRecUser
                SchSystem.BLL.SchApp schappBll = new SchSystem.BLL.SchApp();
                DataTable dtschapp = schappBll.GetList("'0' pId,AppCode id,AppName name,'false' checked,AppCode", "Stat=1 and AppCode not in (1,2)").Tables[0];
                sonsys = Newtonsoft.Json.JsonConvert.SerializeObject(dtschapp);

                //获取整个系统的年级
                SchSystem.BLL.SysGrade sysgradebll = new SchSystem.BLL.SysGrade();
                DataTable dtgrade = sysgradebll.GetList("GradeType pId,GradeCode id,GradeName name,'false' checked,'false' nochecks,'0' IsFinish", " GradeCode<>'3004' and GradeCode<>'4004' Order by GradeType,GradeLv").Tables[0];
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

                //if (dtgrade != null && dtschgrade != null && dtgrade.Rows.Count > 0 && dtschgrade.Rows.Count > 0)//系统年级和学校年级不等于null
                //{
                //    for (int i = 0; i < dtgrade.Rows.Count; i++)//遍历实体年级行数
                //    {
                //        DataRow[] drs = dtschgrade.Select("id='" + dtgrade.Rows[i]["id"].ToString() + "'");//根据系统年级id查询学校年级
                //        if (drs.Length > 0)
                //        {
                //            //string ss = drs[0]["id"].ToString();
                //            //dtgrade.Rows[i]["checked"] = "true";
                //            //DataRow[] drss = dtgrade.Select("id='"+ss+"'");
                //            //int ss = int.Parse(drss["pId"].ToString());
                //        }
                //    }
                //}

                grades = Newtonsoft.Json.JsonConvert.SerializeObject(dtgrade);

                //获取资源平台服务资源:AutoId,AppCode,AppName,Stat,RecTime,RecUser,LastRecTime,LastRecUser
                SchSystem.BLL.SchAppSoure schappsoureBll = new SchSystem.BLL.SchAppSoure();
                DataTable dtschappsoure = schappsoureBll.GetList("'0' pId,AppCode id,AppName name,'false' checked,AppCode", "Stat=1").Tables[0];
                if (dtschappsoure.Rows.Count > 0)
                {
                    for (int i = 0; i < dtschappsoure.Rows.Count; i++)
                    {
                        dtschappsoure.Rows[i]["name"] = dtschappsoure.Rows[i]["name"] + "【不共享】";
                    }
                }
                souretree = Newtonsoft.Json.JsonConvert.SerializeObject(dtschappsoure);

                //获取教版
                SchSystem.BLL.SysMater smaterBll = new SchSystem.BLL.SysMater();
                DataTable dtsmater = smaterBll.GetList("'0' pId,AutoId id,MaterName name,'false' checked,MaterCode", "Stat=1").Tables[0];
                sysmatertree = Newtonsoft.Json.JsonConvert.SerializeObject(dtsmater);

                //获取家校互通服务资源:AutoId,AppCode,AppName,Stat,RecTime,RecUser,LastRecTime,LastRecUser
                SchSystem.BLL.SchAppXXT schappxxtBll = new SchSystem.BLL.SchAppXXT();
                DataTable dtschappxxt = schappxxtBll.GetList("'0' pId,AppCode id,AppName name,'false' checked,AppCode", "Stat=1").Tables[0];
                //if (dtschappsoure.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dtschappsoure.Rows.Count; i++)
                //    {
                //        dtschappsoure.Rows[i]["name"] = dtschappsoure.Rows[i]["name"] + "【不共享】";
                //    }
                //}
                homeschtree = Newtonsoft.Json.JsonConvert.SerializeObject(dtschappxxt);

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

                //根据部门分类查询人员信息
                //当前学校老师
                SchSystem.BLL.SchUserDeptV userbll = new SchSystem.BLL.SchUserDeptV();
                DataTable dtuser = userbll.GetList("DeptId,DepartName,UserId,UserTname", "Stat=1 and Ustat=1 and SchId=" + Com.Public.SqlEncStr(schid)).Tables[0];
                SchSystem.BLL.SchDepartInfo dptbll = new SchSystem.BLL.SchDepartInfo();
                DataTable dt = dptbll.GetList("Pid pId,convert(varchar(20),DepartId) id,DepartName name,'0' isms,'' subcode,'false' checked,'true' nochecks", "SchId=" + schid + " and Stat=1 Order by OrderId,DepartName").Tables[0];
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

                                dr["id"] = item["UserId"].ToString();
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

        [WebMethod]
        public static Com.DataPack.DataRsp<string> schsave(List<string> arr)
        {
            int schid = 0; string selgrades = ""; string selsubs = ""; string sonsys = ""; string schsonsysenabletime = ""; string resourcemodules = ""; string homschmodules = "";
            string kinderstr = ""; string primarystr = ""; string juniorstr = ""; string highstr = "";
            string homkinderstr = ""; string homprimarystr = ""; string homjuniorstr = ""; string homhighstr = "";
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
                    SchSystem.Model.SchInfo schmodel = new SchSystem.Model.SchInfo();
                    SchSystem.BLL.SchInfo schbll = new SchSystem.BLL.SchInfo();
                    #region 收集前台传递过来的数据
                    foreach (string str in arr)
                    {
                        string[] strarr = str.Split('#');
                        if (strarr[0] == "schid") { schmodel.SchId = int.Parse(strarr[1]); }
                        else if (strarr[0] == "schname") { schmodel.SchName = strarr[1]; }
                        else if (strarr[0] == "acoty") { if (((IList)strarr).Contains(strarr[1])) { schmodel.AreaNo = strarr[1]; } else { schmodel.AreaNo = ""; } }
                        else if (strarr[0] == "iscity") { if (((IList)strarr).Contains(strarr[1])) { schmodel.IsCity = int.Parse(strarr[1]); } else { schmodel.IsCity = 0; } }
                        else if (strarr[0] == "schaddr") { if (((IList)strarr).Contains(strarr[1])) { schmodel.SchAddr = strarr[1]; } else { schmodel.SchAddr = ""; } }
                        else if (strarr[0] == "schmaster") { if (((IList)strarr).Contains(strarr[1])) { schmodel.SchMaster = strarr[1]; } else { schmodel.SchMaster = ""; } }
                        else if (strarr[0] == "schmasterpst") { if (((IList)strarr).Contains(strarr[1])) { schmodel.MasterPostion = strarr[1]; } else { schmodel.MasterPostion = ""; } }
                        else if (strarr[0] == "schmastertel") { if (((IList)strarr).Contains(strarr[1])) { schmodel.SchTel = strarr[1]; } else { schmodel.SchTel = ""; } }
                        else if (strarr[0] == "frontlinetechni") { if (((IList)strarr).Contains(strarr[1])) { schmodel.Artisan = strarr[1]; } else { schmodel.Artisan = ""; } }
                        else if (strarr[0] == "principalname") { if (((IList)strarr).Contains(strarr[1])) { schmodel.PrincipalName = strarr[1]; } else { schmodel.PrincipalName = ""; } }
                        else if (strarr[0] == "principaltel") { if (((IList)strarr).Contains(strarr[1])) { schmodel.PrincipalTel = strarr[1]; } else { schmodel.PrincipalTel = ""; } }
                        else if (strarr[0] == "customerservicestaffname") { if (((IList)strarr).Contains(strarr[1])) { schmodel.ServiceName = strarr[1]; } else { schmodel.ServiceName = ""; } }
                        else if (strarr[0] == "customerservicestaffnametel") { if (((IList)strarr).Contains(strarr[1])) { schmodel.ServiceTel = strarr[1]; } else { schmodel.ServiceTel = ""; } }
                        else if (strarr[0] == "platformname") { if (((IList)strarr).Contains(strarr[1])) { schmodel.PlatformName = strarr[1]; } else { schmodel.PlatformName = ""; } }
                        else if (strarr[0] == "platformico") { if (((IList)strarr).Contains(strarr[1])) { schmodel.PlatformIco = strarr[1]; } else { schmodel.PlatformIco = ""; } }
                        else if (strarr[0] == "platformurl") { if (((IList)strarr).Contains(strarr[1])) { schmodel.PlatformUrl = strarr[1]; } else { schmodel.PlatformUrl = ""; } }
                        else if (strarr[0] == "ipaddress") { if (((IList)strarr).Contains(strarr[1])) { schmodel.PlatformIP = strarr[1]; } else { schmodel.PlatformIP = ""; } }
                        else if (strarr[0] == "manageracount") { if (((IList)strarr).Contains(strarr[1])) { schmodel.Manageracount = strarr[1]; } else { schmodel.Manageracount = ""; } }
                        else if (strarr[0] == "selgrades") { if (((IList)strarr).Contains(strarr[1])) { selgrades = strarr[1]; } else { selgrades = ""; } }
                        else if (strarr[0] == "selsubs") { if (((IList)strarr).Contains(strarr[1])) { selsubs = strarr[1]; } else { selsubs = ""; } }
                        else if (strarr[0] == "sonsys") { if (((IList)strarr).Contains(strarr[1])) { sonsys = strarr[1]; } else { sonsys = ""; } }
                        else if (strarr[0] == "resourceplatformname") { if (((IList)strarr).Contains(strarr[1])) { schmodel.ResourcePlatformName = strarr[1]; } else { schmodel.ResourcePlatformName = ""; } }
                        else if (strarr[0] == "resourceplatformico") { if (((IList)strarr).Contains(strarr[1])) { schmodel.ResourcePlatformIco = strarr[1]; } else { schmodel.ResourcePlatformIco = ""; } }
                        else if (strarr[0] == "resourceplatformurl") { if (((IList)strarr).Contains(strarr[1])) { schmodel.ResourcePlatformUrl = strarr[1]; } else { schmodel.ResourcePlatformUrl = ""; } }
                        else if (strarr[0] == "resourceplatformip") { if (((IList)strarr).Contains(strarr[1])) { schmodel.ResourcePlatformIP = strarr[1]; } else { schmodel.ResourcePlatformIP = ""; } }
                        else if (strarr[0] == "schoolsection") { if (((IList)strarr).Contains(strarr[1])) { schmodel.SchoolSection = strarr[1]; } else { schmodel.SchoolSection = ""; } }
                        else if (strarr[0] == "creator") { if (((IList)strarr).Contains(strarr[1])) { schmodel.SchCreator = strarr[1]; } else { schmodel.SchCreator = ""; } }
                        else if (strarr[0] == "resourcemodules") { if (((IList)strarr).Contains(strarr[1])) { resourcemodules = strarr[1]; } else { resourcemodules = ""; } }
                        //else if (strarr[0] == "sourceserverstat") { if (((IList)strarr).Contains(strarr[1])) { schmodel.Sourceserstat = int.Parse(strarr[1]); } else { schmodel.Sourceserstat = 0; } }
                        else if (strarr[0] == "kinderstr") { if (((IList)strarr).Contains(strarr[1])) { kinderstr = strarr[1]; } else { kinderstr = ""; } }
                        else if (strarr[0] == "primarystr") { if (((IList)strarr).Contains(strarr[1])) { primarystr = strarr[1]; } else { primarystr = ""; } }
                        else if (strarr[0] == "juniorstr") { if (((IList)strarr).Contains(strarr[1])) { juniorstr = strarr[1]; } else { juniorstr = ""; } }
                        else if (strarr[0] == "highstr") { if (((IList)strarr).Contains(strarr[1])) { highstr = strarr[1]; } else { highstr = ""; } }

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
                    #endregion
                    schmodel.RecTime = DateTime.Now;
                    schmodel.RecUser = schmodel.SchCreator;
                    schmodel.SonSysStat = 1;//子系统状态，缺省值为1，表示启用
                    schmodel.Stat = 1;//0代表废弃；1代表正常；2代表删除
                    schmodel.SourceSerStat = 0;
                    schmodel.HomeSchCreateTime = DateTime.Now;
                    string msusername = schmodel.Manageracount;
                    string msusertname = schmodel.SchMaster;
                    string errorstr = "";
                    SchSystem.BLL.SchUserInfo suiBll = new SchSystem.BLL.SchUserInfo();
                    if (string.IsNullOrEmpty(msusername) || string.IsNullOrEmpty(msusertname))
                    {
                        errorstr += "管理员账号或管理员姓名为空;";
                    }
                    if (msusername!=""&&suiBll.ExistsUserName(0,msusername))//判断管理账号是否存在
                    {
                        errorstr += "管理员账号已经被使用,请修改;";
                    }                    
                    if (Encoding.Default.GetBytes(schmodel.PlatformIP).Length > 15)//判断管理平台IP地址
                    {
                        errorstr += "管理平台IP地址超出15个字符;";
                    }
                    if (Encoding.Default.GetBytes(schmodel.ResourcePlatformIP).Length > 15)//判断资源平台IP地址
                    {
                        errorstr += "管理平台IP地址超出15个字符;";
                    }
                    if (Encoding.Default.GetBytes(schmodel.HomeSchPlatIP).Length > 15)//判断家校互通平台IP地址
                    {
                        errorstr += "管理平台IP地址超出15个字符;";
                    }
                    if (errorstr == "")
                    {
                        schid = schbll.SchAdd(schmodel);
                        if (schid > 0)
                        {
                            suiBll.AddUser(schid, schmodel.SchMaster, schmodel.Manageracount, Com.Public.StrToMD5("123456"), Com.Session.userid);
                            //添加家校互通平台基础数据
                            schmodel.SchId = schid;
                            schbll.SchAddXXT(schmodel);
                            //添加年级及科目
                            GradeSubAdd(selgrades, schid);
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
                            rsp.code = "success";
                            rsp.msg = "添加成功";
                        }
                        else
                        {
                            rsp.code = "error";
                            rsp.msg = "添加失败";
                        }
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
        #region 添加年级及科目
        public static void GradeSubAdd(string selgrades, int schid)
        {
            if (selgrades != "")
            {
                SchSystem.BLL.SchGradeInfo gradebll = new SchSystem.BLL.SchGradeInfo();
                SchSystem.Model.SchGradeInfo grademodel = new SchSystem.Model.SchGradeInfo();

                string[] gradeIdsarr = selgrades.Split(',');
                int gradeIdsLen = gradeIdsarr.Length;
                for (int i = 0; i < gradeIdsLen; i++)
                {
                    string[] graderowarr = gradeIdsarr[i].Split('|');
                    grademodel.GradeCode = graderowarr[0];
                    grademodel.GradeYear = graderowarr[1];
                    grademodel.GradeName = graderowarr[2];
                    grademodel.IsFinish = int.Parse(graderowarr[3]);
                    grademodel.SchId = schid;
                    grademodel.RecTime = DateTime.Now;
                    grademodel.RecUser = Com.Session.userid;
                    grademodel.LastRecTime = DateTime.Now;

                    gradebll.Add(grademodel);
                }
            }
        }
        #endregion
        #region 添加科目
        /// <summary>
        /// 添加科目
        /// </summary>
        /// <param name="selsubs"></param>
        /// <param name="schid"></param>
        public static void subAdd(string selsubs, int schid)
        {
            if (selsubs != "")
            {
                SchSystem.BLL.SchSub subbll = new SchSystem.BLL.SchSub();
                subbll.DoSchSubs(Com.Session.userid, schid.ToString(), selsubs);//SchWebAdmin.Com.Session.userid
            }
        }
        #endregion
        #region 添加子系统
        /// <summary>
        /// 添加子系统
        /// </summary>
        /// <param name="sonsys"></param>
        /// <param name="schid"></param>
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
        /// <summary>
        /// 资料科目及教版
        /// </summary>
        /// <param name="schid"></param>
        /// <param name="kinderstr"></param>
        /// <param name="primarystr"></param>
        /// <param name="juniorstr"></param>
        /// <param name="highstr"></param>
        public static void dataSubMat(int schid, string kinderstr, string primarystr, string juniorstr, string highstr)
        {
            SchSystem.BLL.SchPerSubMat spsmBll = new SchSystem.BLL.SchPerSubMat();
            SchSystem.Model.SchPerSubMat spsmModel = new SchSystem.Model.SchPerSubMat();
            bool resbool = spsmBll.Exists(schid);//判断原来是否存在
            if (resbool)//存在
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
                    spsmBll.Add(spsmModel);
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
        /// <summary>
        /// 资源模块
        /// </summary>
        /// <param name="resourcemodules"></param>
        /// <param name="schid"></param>
        public static void ResourcesModel(string resourcemodules, int schid)
        {
            if (resourcemodules != "")
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
        }
        #endregion
        #region 家校互通平台学段科目及教版
        /// <summary>
        /// 家校互通平台学段科目及教版
        /// </summary>
        /// <param name="schid"></param>
        /// <param name="homkinderstr"></param>
        /// <param name="homprimarystr"></param>
        /// <param name="homjuniorstr"></param>
        /// <param name="homhighstr"></param>
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
            if (homschmodules != "")
            {
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
        }
        #endregion
        [WebMethod]
        public static Com.DataPack.DataRsp<string> existuser(string usertname, int schid)
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
                if (suiBll.ExistsUserName(0, usertname))
                {                    
                    rsp.code = "error";
                    rsp.msg = "管理员账号已被占用,请修改!";
                }
            }
            return rsp;
        }
    }
}