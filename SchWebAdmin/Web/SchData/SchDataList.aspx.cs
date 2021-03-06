﻿using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin.Web.SchData
{
    public partial class SchDataList : System.Web.UI.Page
    {
        public string areastr = "";
        public string schid = "0";
        public string cotycode = "";
        public bool isadd;
        public bool isedit;
        public bool isdel;
        public bool islook;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

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
        public static Com.DataPack.DataRsp<string> page(string PageIndex, string PageSize, string txtname, string ustat, string cotycode, string schid, string aprovserch, string acityserch, string txtschid, string gradelv, string isfinish)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            if (Com.Session.userid == null)
            {
                rsp.code = "expire";
                rsp.msg = "页面已经过期，请重新登录";
            }
            else
            {
                if (schid == "")
                    schid = "0";
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
                if (!string.IsNullOrEmpty(txtschid))
                {
                    strwhere += " and SchId = " + int.Parse(Com.Public.SqlEncStr(txtschid));
                }
                else
                {
                    if (schid != "0")
                    {
                        strwhere += " and SchId = '" + Com.Public.SqlEncStr(schid) + "'";
                    }
                }
                if (!string.IsNullOrEmpty(txtname))
                {
                    strwhere += " and SchName like '%" + Com.Public.SqlEncStr(txtname) + "%'";
                }
                if (!string.IsNullOrEmpty(ustat))
                {
                    strwhere += " and SonSysStat=" + Com.Public.SqlEncStr(ustat);
                }
                string currentYear = "";
                if (DateTime.Now.Month < 8)
                {
                    currentYear = (DateTime.Now.Year - 1).ToString();
                }
                else
                {
                    currentYear = DateTime.Now.Year.ToString();
                }
                if (!string.IsNullOrEmpty(gradelv))//选择了学段
                {
                    if (!string.IsNullOrEmpty(isfinish))//并且选择了是否有毕业班需要升级
                    {
                        string yearlv = "0";
                        if (gradelv == "1")
                        {
                            yearlv = "4";
                        }
                        else if (gradelv == "2")
                        {
                            yearlv = "5";
                        }
                        else if (gradelv == "3")
                        {
                            yearlv = "3";
                        }
                        else if (gradelv == "4")
                        {
                            yearlv = "3";
                        }
                        if (isfinish == "0")//无毕业班,需要剔除有该学段毕业班学校
                        {
                            strwhere += " and schid not in (select schid from SchGradeInfo where isfinish=0 and left(GradeCode,1)='" + Com.Public.SqlEncStr(gradelv) + "' and " + currentYear + "-GradeYear>" + yearlv + ")";
                        }
                        else//有毕业班,含有该学段且有毕业班的学校
                        {
                            strwhere += " and schid in (select schid from SchGradeInfo where isfinish=0 and left(GradeCode,1)='" + Com.Public.SqlEncStr(gradelv) + "' and " + currentYear + "-GradeYear>" + yearlv + ")";
                        }
                    }
                    else//仅选择了学段,则选择有该学段的学校
                    {
                        strwhere += " and schid in (select schid from SchGradeInfo where isfinish=0 and left(GradeCode,1)='" + Com.Public.SqlEncStr(gradelv) + "')";
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(isfinish))
                    {
                        if (isfinish == "0")//无毕业班,需要剔除含有毕业班学校
                        {
                            strwhere += " and schid not in (select schid from SchGradeInfo where (isfinish=0 or isfinish=2) and ((left(GradeCode,1)='4' and " + currentYear + "-GradeYear>3) or (left(GradeCode,1)='3' and " + currentYear + "-GradeYear>3) or (left(GradeCode,1)='2' and " + currentYear + "-GradeYear>5) or (left(GradeCode,1)='1' and " + currentYear + "-GradeYear>4)))";
                        }
                        else//有毕业班,含有毕业班的学校
                        {
                            strwhere += " and schid in (select schid from SchGradeInfo where (isfinish=0 or isfinish=2) and ((left(GradeCode,1)='4' and " + currentYear + "-GradeYear>3) or (left(GradeCode,1)='3' and " + currentYear + "-GradeYear>3) or (left(GradeCode,1)='2' and " + currentYear + "-GradeYear>5) or (left(GradeCode,1)='1' and " + currentYear + "-GradeYear>4)))";
                        }
                    }
                }
                //isfinish=0 and SchId=@SchId and ((left(GradeCode,1)='4' and @GradeYear-GradeYear>3) or (left(GradeCode,1)='3' and @GradeYear-GradeYear>3) or (left(GradeCode,1)='2' and @GradeYear-GradeYear>5) or (left(GradeCode,1)='1' and @GradeYear-GradeYear>4))
                Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
                pages.PageIndex = int.Parse(PageIndex);
                pages.PageSize = int.Parse(PageSize);
                int rowc = 0;
                int pc = 0;

                try
                {
                    SchSystem.BLL.SchInfo userbll = new SchSystem.BLL.SchInfo();
                    //查询最近毕业年级
                    SchSystem.BLL.SchGradeInfo sgibll = new SchSystem.BLL.SchGradeInfo();
                    SchSystem.BLL.SchApp saBll = new SchSystem.BLL.SchApp();
                    string dbcols = "SchId,SchName,PlatformIP,SchoolSection,SonSysStat,RecTime,SchSonSysEnableTime,SchSonSysEndDateTime,AreaNo,Stat,PlatformUrl";//,PlatformIco,SchMaster,ServiceName,Artisan,SchCreator,iscity
                    DataTable dt = userbll.GetListCols(dbcols, strwhere, "SchName", "Asc", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
                    pages.PageCount = pc;
                    pages.RowCount = rowc;
                    if (dt.Rows.Count > 0)
                    {
                        dt.Columns.Add("IsUpgrade");
                        dt.Columns.Add("SHENG");
                        dt.Columns.Add("SHI");
                        dt.Columns.Add("QU");
                        dt.Columns.Add("SchoolSections");
                        dt.Columns.Add("graduated");
                        dt.Columns.Add("AppSonSys");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string[] areanames = Com.Public.GetArea(dt.Rows[i]["AreaNo"].ToString()).Split('|');
                            dt.Rows[i]["SHENG"] = areanames[0];
                            dt.Rows[i]["SHI"] = areanames[1];
                            dt.Rows[i]["QU"] = areanames[2];
                            StringBuilder sbstr = new StringBuilder();
                            string ss = dt.Rows[i]["SchoolSection"].ToString();
                            if (!string.IsNullOrEmpty(dt.Rows[i]["SchoolSection"].ToString()))
                            {
                                string[] str = dt.Rows[i]["SchoolSection"].ToString().Split(',');
                                for (int j = 0; j < str.Length; j++)
                                {
                                    if (str[j] == "1") { sbstr.Append("幼儿园,"); }
                                    else if (str[j] == "2") { sbstr.Append("小学,"); }
                                    else if (str[j] == "3") { sbstr.Append("初中,"); }
                                    else if (str[j] == "4") { sbstr.Append("高中,"); }
                                }
                                if (sbstr.ToString() != "")
                                {
                                    dt.Rows[i]["SchoolSections"] = sbstr.ToString().Substring(0, sbstr.ToString().Length - 1);
                                }
                                else
                                {
                                    dt.Rows[i]["SchoolSections"] = "";
                                }
                            }
                            bool resBool = false;
                            if (!string.IsNullOrEmpty(dt.Rows[i]["SchId"].ToString()))
                            {

                                resBool = sgibll.ExistsGradeFinish(int.Parse(dt.Rows[i]["SchId"].ToString()), int.Parse(currentYear));
                            }
                            if (resBool)
                            {
                                dt.Rows[i]["IsUpgrade"] = "1";
                            }
                            else
                            {
                                dt.Rows[i]["IsUpgrade"] = "0";
                            }
                            string gradecurrent = " and isfinish=1 and ((left(GradeCode,1)='4' and " + currentYear + "-GradeYear=3) or (left(GradeCode,1)='3' and " + currentYear + "-GradeYear=3) or (left(GradeCode,1)='2' and " + currentYear + "-GradeYear=6) or (left(GradeCode,1)='1' and " + currentYear + "-GradeYear=5))";
                            dt.Rows[i]["graduated"] = sgibll.GetGradedYear("SchId=" + dt.Rows[i]["SchId"].ToString() + gradecurrent);
                            //查询应用子系统
                            SchSystem.BLL.SchAppRole sarBll = new SchSystem.BLL.SchAppRole();
                            DataTable dtsars = sarBll.GetList("SchId='" + dt.Rows[i]["SchId"].ToString() + "'").Tables[0];
                            StringBuilder sbsars = new StringBuilder();
                            if (dtsars.Rows.Count > 0)
                            {
                                string sarsarr = dtsars.Rows[0]["AppStr"].ToString();

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

                        }
                        pages.list = dt;
                    }
                    rsp.data = Newtonsoft.Json.JsonConvert.SerializeObject(pages);
                }
                catch (Exception ex)
                {
                    rsp.code = "ExcepError";
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
                        rsp.code = "NoCross";
                        rsp.msg = "无跨界权限，页面不能访问";
                    }
                    else if (id == Com.Public.getKey("adminschid"))
                    {
                        rsp.code = "SysSch";
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
                            rsp.code = "Success";
                            rsp.msg = "删除成功";
                        }
                        else
                        {
                            rsp.code = "Error";
                            rsp.msg = "删除失败";
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

    }
}