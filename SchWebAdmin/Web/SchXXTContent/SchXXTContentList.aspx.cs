using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin.Web.SchXXTContent
{
    public partial class SchXXTContentList : System.Web.UI.Page
    {
        public string areastr = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            //获取下拉列表
            StringBuilder sbarea = new StringBuilder();
            //获取省份
            sbarea.Append("省：<select id=\"aprov\">");
            string sareacode = "";
            sbarea.Append(Com.Public.GetDrpArea("0", "", ref sareacode, true));
            sbarea.Append("</select> &nbsp; &nbsp;");
            //获取城市
            sbarea.Append("市：<select id=\"acity\">");
            string sareacitycode = "";
            sbarea.Append(Com.Public.GetDrpArea("1", sareacode, ref sareacitycode, true));
            sbarea.Append("</select> &nbsp; &nbsp;");
            //获取区县
            sbarea.Append("区县：<select id=\"acoty\">");
            string sareacotycode = "";
            sbarea.Append(Com.Public.GetDrpArea("2", sareacitycode, ref sareacotycode, true));
            sbarea.Append("</select> &nbsp; &nbsp;");
            areastr = sbarea.ToString();
        }

        [WebMethod]
        public static Com.DataPack.DataRsp<string> page(string PageIndex, string PageSize, string txtname, string ustat, string cotycode, string aprovserch, string acityserch, string schname)
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
                        strwhere += " and left(AreaNo,2) = '" + Com.Public.SqlEncStr(aprovserch.Substring(0, 2)) + "'";
                    }
                    if (!string.IsNullOrEmpty(acityserch))
                    {
                        strwhere += " and left(AreaNo,4) = '" + Com.Public.SqlEncStr(acityserch.Substring(0, 4)) + "'";
                    }
                    if (!string.IsNullOrEmpty(schname))
                    {
                        strwhere += " and SchName like '%" + Com.Public.SqlEncStr(schname) + "%'";
                    }
                    if (!string.IsNullOrEmpty(txtname))
                    {
                        strwhere += " and SchId  = '" + Com.Public.SqlEncStr(txtname) + "'";
                    }
                    if (!string.IsNullOrEmpty(ustat))
                    {
                        strwhere += " and HomeschServStat=" + Com.Public.SqlEncStr(ustat);
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
                    Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
                    pages.PageIndex = int.Parse(PageIndex);
                    pages.PageSize = int.Parse(PageSize);
                    int rowc = 0;
                    int pc = 0;
                    string dbcols = "SchId,SchName,HomeSchPlatName,HomeSchPlatUrl,HomeSchPlatIco,HomeSchPlatIP,SchMaster,SchoolSection,ServiceName,Artisan,SchCreator,RecTime,HomeschServStat,AreaNo";
                    DataTable dt = userbll.GetListCols(dbcols, strwhere, "SchName", "ASC", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
                    pages.PageCount = pc;
                    pages.RowCount = rowc;
                    if (dt.Rows.Count > 0)
                    {
                        dt.Columns.Add("SHENG");
                        dt.Columns.Add("SHI");
                        dt.Columns.Add("QU");
                        dt.Columns.Add("graduated");
                        dt.Columns.Add("SoureName");
                        dt.Columns.Add("SchSubNames");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string[] areanames = Com.Public.GetArea(dt.Rows[i]["AreaNo"].ToString()).Split('|');
                            dt.Rows[i]["SHENG"] = areanames[0];
                            dt.Rows[i]["SHI"] = areanames[1];
                            dt.Rows[i]["QU"] = areanames[2];
                            //查询最近毕业年级
                            SchSystem.BLL.SchGradeInfo sgibll = new SchSystem.BLL.SchGradeInfo();
                            //dt.Rows[i]["graduated"] = sgibll.GetGradedYear("SchId=" + dt.Rows[i]["SchId"].ToString() + " and IsFinish=1");
                            string gradecurrent = " and isfinish=1 and ((left(GradeCode,1)='4' and " + currentYear + "-GradeYear=3) or (left(GradeCode,1)='3' and " + currentYear + "-GradeYear=3) or (left(GradeCode,1)='2' and " + currentYear + "-GradeYear=6) or (left(GradeCode,1)='1' and " + currentYear + "-GradeYear=5))";
                            dt.Rows[i]["graduated"] = sgibll.GetGradedYear("SchId=" + dt.Rows[i]["SchId"].ToString() + gradecurrent);
                            //查询子模块
                            SchSystem.BLL.SchAppRoleXXT sarxxtBll = new SchSystem.BLL.SchAppRoleXXT();
                            DataTable dtsarxxt = sarxxtBll.GetList("SchId='" + dt.Rows[i]["SchId"].ToString() + "'").Tables[0];
                            if (dtsarxxt.Rows.Count > 0)
                            {
                                string[] sarsAppCodearr = dtsarxxt.Rows[0]["AppStr"].ToString().Split(',');
                                StringBuilder sarsAppCodesb = new StringBuilder();
                                StringBuilder sasSoureName = new StringBuilder();
                                for (int j = 0; j < sarsAppCodearr.Length; j++)
                                {
                                    sarsAppCodesb.Append(sarsAppCodearr[j] + ",");
                                }
                                SchSystem.BLL.SchAppXXT saxxtBll = new SchSystem.BLL.SchAppXXT();
                                if (sarsAppCodesb.ToString() != "")
                                {
                                    try
                                    {
                                        DataTable dtsas = saxxtBll.GetList("AppName", "AppCode in (" + sarsAppCodesb.ToString().Substring(0, sarsAppCodesb.ToString().Length - 1) + ")").Tables[0];

                                        if (dtsas.Rows.Count > 0)
                                        {
                                            foreach (DataRow dr in dtsas.Rows)
                                            {
                                                sasSoureName.Append(dr["AppName"] + ",");
                                            }
                                            dt.Rows[i]["SoureName"] = sasSoureName.ToString().Substring(0, sasSoureName.Length - 1);
                                        }
                                    }
                                    catch (Exception e) { }
                                }
                                else
                                {
                                    dt.Rows[i]["SoureName"] = "";
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
    }
}