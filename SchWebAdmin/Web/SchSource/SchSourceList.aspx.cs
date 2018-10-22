using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin.Web.SchSource
{
    public partial class SchSourceList : System.Web.UI.Page
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
        public static Com.DataPack.DataRsp<string> page(string PageIndex, string PageSize, string txtname, string ustat, string cotycode, string schid, string aprovserch, string acityserch, string txtschid)
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
                        strwhere += " and left(AreaNo,2) = '" + Com.Public.SqlEncStr(aprovserch.Substring(0, 2)) + "'";
                    }
                    if (!string.IsNullOrEmpty(acityserch))
                    {
                        strwhere += " and left(AreaNo,4) = '" + Com.Public.SqlEncStr(acityserch.Substring(0, 4)) + "'";
                    }

                    if (!string.IsNullOrEmpty(txtschid))
                    {
                        strwhere += " and SchId = '" + int.Parse(Com.Public.SqlEncStr(txtschid)) + "'";
                    }
                    else
                    {
                        if (schid != "0")
                        {
                            strwhere += " and SchId = '" + int.Parse(Com.Public.SqlEncStr(schid)) + "'";
                        }
                    }
                    if (!string.IsNullOrEmpty(txtname))
                    {
                        strwhere += " and SchName like '%" + Com.Public.SqlEncStr(txtname) + "%'";
                    }
                    if (!string.IsNullOrEmpty(ustat))
                    {
                        strwhere += " and Stat='1' and SourceSerStat='" + Com.Public.SqlEncStr(ustat) + "'";
                    }
                    Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
                    pages.PageIndex = int.Parse(PageIndex);
                    pages.PageSize = int.Parse(PageSize);
                    int rowc = 0;
                    int pc = 0;
                    string dbcols = "SchId,SchName,ResourcePlatformName,ResourcePlatformUrl,ResourcePlatformIco,ResourcePlatformIP,SchMaster,SchoolSection,ServiceName,Artisan,SchCreator,RecTime,Stat,iscity,SoureSerEnableTime,SourceSerEndTime,SourceSerStatNote,SourceSerStat,AreaNo,SourceCreateTime";
                    DataTable dt = userbll.GetListCols(dbcols, strwhere, "SchName", "ASC", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
                    pages.PageCount = pc;
                    pages.RowCount = rowc;
                    if (dt.Rows.Count > 0)
                    {
                        dt.Columns.Add("Ustat");
                        dt.Columns.Add("SoureName");
                        dt.Columns.Add("SHENG");
                        dt.Columns.Add("SHI");
                        dt.Columns.Add("QU");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dt.Rows[i]["Ustat"] = dt.Rows[i]["Stat"].ToString() == "1" ? "正常" : "停用";
                            //dt.Rows[i]["Ucity"] = dt.Rows[i]["iscity"].ToString() == "1" ? "城区" : "非城区";
                            SchSystem.BLL.SchAppRoleSoure sarsBll = new SchSystem.BLL.SchAppRoleSoure();
                            DataTable dtsars = sarsBll.GetList("SchId='" + dt.Rows[i]["SchId"].ToString() + "'").Tables[0];
                            if (dtsars.Rows.Count > 0)
                            {
                                string[] sarsAppCodearr = dtsars.Rows[0]["AppCode"].ToString().Split('|');
                                StringBuilder sarsAppCodesb = new StringBuilder();
                                StringBuilder sasSoureName = new StringBuilder();
                                for (int j = 0; j < sarsAppCodearr.Length; j++)
                                {
                                    //if (sarsAppCodearr[j].Split(',')[1] == "1")
                                    //{
                                    sarsAppCodesb.Append(sarsAppCodearr[j].Split(',')[0] + ",");
                                    //}
                                }
                                SchSystem.BLL.SchAppSoure sasBll = new SchSystem.BLL.SchAppSoure();
                                if (sarsAppCodesb.ToString() != "")
                                {
                                    try
                                    {
                                        DataTable dtsas = sasBll.GetList("AppName", "AppCode in (" + sarsAppCodesb.ToString().Substring(0, sarsAppCodesb.ToString().Length - 1) + ")").Tables[0];

                                        if (dtsas.Rows.Count > 0)
                                        {
                                            foreach (DataRow dr in dtsas.Rows)
                                            {
                                                sasSoureName.Append(dr["AppName"] + ",");
                                            }
                                            dt.Rows[i]["SoureName"] = sasSoureName.ToString().Substring(0, sasSoureName.ToString().Length - 1);
                                        }
                                    }
                                    catch (Exception e) { }
                                }
                                else
                                {
                                    dt.Rows[i]["SoureName"] = "";
                                }
                            }

                            string[] areanames = Com.Public.GetArea(dt.Rows[i]["AreaNo"].ToString()).Split('|');
                            dt.Rows[i]["SHENG"] = areanames[0];
                            dt.Rows[i]["SHI"] = areanames[1];
                            dt.Rows[i]["QU"] = areanames[2];
                        }
                        pages.list = dt;
                    }
                    rsp.data = Newtonsoft.Json.JsonConvert.SerializeObject(pages).Replace("\n\r", "");
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
                        rsp.msg = "无跨界权限";
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
                            rsp.msg = "操作成功";
                        }
                        else
                        {
                            rsp.code = "error";
                            rsp.msg = "操作失败";
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