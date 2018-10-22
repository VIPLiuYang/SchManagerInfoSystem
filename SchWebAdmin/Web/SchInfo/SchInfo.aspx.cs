using Common;
using System;
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
    public partial class SchInfo : System.Web.UI.Page
    {
        public string areastr = "";
        public string schid = "";
        public string cotycode = "";
        public bool isadd;
        public bool isedit;
        public bool isdel;
        public bool islook;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                //第一次加载,获取省市区,获取第一个省份下的所有学校
                StringBuilder sbarea = new StringBuilder();
                //获取省份
                sbarea.Append("省:<select id=\"aprov\">");
                string sareacode = "";
                sbarea.Append(Com.Public.GetDrpArea("0", "", ref sareacode, true));
                sbarea.Append("</select>");
                //获取城市
                sbarea.Append("市:<select id=\"acity\">");
                string sareacitycode = "";
                sbarea.Append(Com.Public.GetDrpArea("1", sareacode, ref sareacitycode, true));
                sbarea.Append("</select>");
                //获取区县
                sbarea.Append("区:<select id=\"acoty\">");
                string sareacotycode = "";
                sbarea.Append(Com.Public.GetDrpArea("2", sareacitycode, ref sareacotycode, true));
                cotycode = sareacotycode;
                sbarea.Append("</select>");
                areastr = sbarea.ToString();

            }
        }

        [WebMethod]
        public static Com.DataPack.DataRsp<string> page(string PageIndex, string PageSize, string txtname, string ustat, string cotycode, string schid, string aprovserch, string acityserch)
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
                    SchSystem.BLL.SchInfo userbll = new SchSystem.BLL.SchInfo();
                    //Stat:0废弃,1正常,2被删除,正常界面不显示删除,超管界面可以考虑
                    string strwhere = "Stat<2 ";
                    if (!string.IsNullOrEmpty(cotycode))
                    {
                        strwhere += " and AreaNo = '" + Com.Public.SqlEncStr(cotycode) + "'";
                    }
                    if (!string.IsNullOrEmpty(aprovserch))
                    {
                        strwhere += " and  left(AreaNo,2)= '" + Com.Public.SqlEncStr(aprovserch.Substring(0, 2)) + "'";
                    }
                    if (!string.IsNullOrEmpty(acityserch))
                    {
                        strwhere += " and left(AreaNo,4)= '" + Com.Public.SqlEncStr(acityserch.Substring(0, 4)) + "'";
                    }
                    if (schid != "")
                    {
                        strwhere += " and SchId = '" + Com.Public.SqlEncStr(schid) + "'";
                    }
                    if (!string.IsNullOrEmpty(txtname))
                    {
                        strwhere += " and SchName like '%" + Com.Public.SqlEncStr(txtname) + "%'";
                    }
                    if (!string.IsNullOrEmpty(ustat))
                    {
                        strwhere += " and SonSysStat=" + Com.Public.SqlEncStr(ustat);
                    }
                    Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
                    pages.PageIndex = int.Parse(PageIndex);
                    pages.PageSize = int.Parse(PageSize);
                    int rowc = 0;
                    int pc = 0;
                    string dbcols = "SchId,SchName,PlatformName,PlatformUrl,PlatformIco,PlatformIP,SchMaster,SchoolSection,ServiceName,Artisan,SchCreator,RecTime,Stat,iscity,SonSysStat,AreaNo,SchType";
                    DataTable dt = userbll.GetListCols(dbcols, strwhere, "SchName", "ASC", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
                    pages.PageCount = pc;
                    pages.RowCount = rowc;
                    if (dt.Rows.Count > 0)
                    {
                        dt.Columns.Add("SHENG");
                        dt.Columns.Add("SHI");
                        dt.Columns.Add("QU");
                        dt.Columns.Add("ManagerAcount");
                        dt.Columns.Add("InitialPwd");
                        dt.Columns.Add("graduated");
                        dt.Columns.Add("AppSonSys");
                        dt.Columns.Add("SchSubNames");
                        dt.Columns.Add("SchTypeName");
                        SchSystem.BLL.SysPer bllper = new SchSystem.BLL.SysPer();
                        DataTable dtper = bllper.GetList("PerName,PerCode", " Stat=1 ").Tables[0];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string[] areanames = Com.Public.GetArea(dt.Rows[i]["AreaNo"].ToString()).Split('|');
                            dt.Rows[i]["SHENG"] = areanames[0];
                            dt.Rows[i]["SHI"] = areanames[1];
                            dt.Rows[i]["QU"] = areanames[2];
                            DataRow[] dtr = dtper.Select("PerCode='" + dt.Rows[i]["SchType"].ToString() + "'");
                            if (dtr.Length > 0)
                            {
                                dt.Rows[i]["SchTypeName"] = dtr[0]["PerName"].ToString();
                            }
                            else
                            {
                                dt.Rows[i]["SchTypeName"] = "";
                            }
                            //获取管理员账号密码信息
                            SchSystem.BLL.SchUserInfo suiBll = new SchSystem.BLL.SchUserInfo();
                            SchSystem.Model.SchUserInfo modeluserinfo = suiBll.GetSupportModel(int.Parse(dt.Rows[i]["SchId"].ToString()), 1);
                            if (modeluserinfo != null)
                            {
                                if (modeluserinfo.UserName != "" && modeluserinfo.UserName != null)
                                {
                                    dt.Rows[i]["ManagerAcount"] = modeluserinfo.UserName;
                                }
                                if (modeluserinfo.PassWord != "" && modeluserinfo.PassWord != null)
                                {
                                    dt.Rows[i]["InitialPwd"] = 1;
                                }
                            }
                            else
                            {
                                dt.Rows[i]["ManagerAcount"] = "";
                                dt.Rows[i]["InitialPwd"] = "";
                            }
                            //查询最近毕业年级
                            string currentYear = "";
                            if (DateTime.Now.Month < 8)
                            {
                                currentYear = (DateTime.Now.Year - 1).ToString();
                            }
                            else
                            {
                                currentYear = DateTime.Now.Year.ToString();
                            }
                            SchSystem.BLL.SchGradeInfo sgibll = new SchSystem.BLL.SchGradeInfo();
                            //dt.Rows[i]["graduated"] = sgibll.GetGradedYear("SchId=" + dt.Rows[i]["SchId"].ToString() + " and IsFinish=1");
                            string gradecurrent = " and isfinish=1 and ((left(GradeCode,1)='4' and " + currentYear + "-GradeYear=3) or (left(GradeCode,1)='3' and " + currentYear + "-GradeYear=3) or (left(GradeCode,1)='2' and " + currentYear + "-GradeYear=6) or (left(GradeCode,1)='1' and " + currentYear + "-GradeYear=5))";
                            dt.Rows[i]["graduated"] = sgibll.GetGradedYear("SchId=" + dt.Rows[i]["SchId"].ToString() + gradecurrent);
                            //
                            //查询应用子系统
                            SchSystem.BLL.SchAppRole sarBll = new SchSystem.BLL.SchAppRole();
                            DataTable dtsars = sarBll.GetList("SchId='" + dt.Rows[i]["SchId"].ToString() + "'").Tables[0];
                            StringBuilder sbsars = new StringBuilder();
                            if (dtsars.Rows.Count > 0)
                            {
                                string sarsarr = dtsars.Rows[0]["AppStr"].ToString();
                                SchSystem.BLL.SchApp saBll = new SchSystem.BLL.SchApp();
                                StringBuilder sbsas = new StringBuilder();
                                DataTable dtsas = saBll.GetList("AppName", "AppCode in (" + sarsarr + ")").Tables[0];
                                if (dtsas.Rows.Count > 0)
                                {
                                    foreach (DataRow drsas in dtsas.Rows)
                                    {
                                        sbsas.Append(drsas["AppName"] + ",");
                                    }
                                    dt.Rows[i]["AppSonSys"] = sbsas.ToString().Substring(0, sbsas.ToString().Length - 1);
                                }
                            }
                            //查询科目
                            SchSystem.BLL.SchSub ssBll = new SchSystem.BLL.SchSub();
                            dt.Rows[i]["SchSubNames"] = ssBll.GetSubNames("Stat=1 and SchId='" + dt.Rows[i]["SchId"].ToString() + "'");
                        }
                        pages.list = dt;
                    }
                    rsp.data = Newtonsoft.Json.JsonConvert.SerializeObject(pages);
                }
                catch (Exception ex)
                {
                    rsp.code = "error";
                    rsp.msg = ex.Message;
                }
                
            }
            return rsp;
        }
        [WebMethod]
        public static Com.DataPack.DataRsp<string> udel(string id)
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
                    if (!Com.Public.isVa(id, ""))
                    {
                        rsp.code = "error";
                        rsp.msg = "无跨界权限，页面不能访问";
                    }
                    else if (id == Com.Public.getKey("adminschid"))
                    {
                        rsp.code = "error";
                        rsp.msg = "此为系统学校,不允许操作";
                    }
                    else
                    {
                        SchSystem.BLL.SchInfo bll = new SchSystem.BLL.SchInfo();
                        SchSystem.Model.SchInfo model = new SchSystem.Model.SchInfo();
                        model.SchId = int.Parse(id);
                        model.Stat = 2;
                        model.LastRecTime = DateTime.Now;
                        model.LastRecUser = Com.Session.userid;
                        if (bll.UpdateStat(model))
                        {
                            rsp.code = "success";
                            rsp.msg = "删除成功";
                        }
                        else
                        {
                            rsp.code = "error";
                            rsp.msg = "删除失败";
                        }
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
    }
}