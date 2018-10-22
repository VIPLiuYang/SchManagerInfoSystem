using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin.Web.SchSignin
{
    public partial class SchSigninList : System.Web.UI.Page
    {
        public string areastr = "";
        public string schid = "0";
        public string cotycode = "";
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
                    SchSystem.BLL.SchGradeInfo schgradebll = new SchSystem.BLL.SchGradeInfo();
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
                        strwhere += " and SchId = " + int.Parse(Com.Public.SqlEncStr(txtschid));
                    }
                    else
                    {
                        if (schid != "0")
                        {
                            strwhere += " and SchId = '" + Com.Public.SqlEncStr(schid) + "'";
                        }
                    }
                    if (!string.IsNullOrEmpty(ustat))
                    {
                        if (ustat == "1")
                        {
                            strwhere += " and schid in (select schid from SchThdInfo)";
                        }
                        else
                        {
                            strwhere += " and schid not in (select schid from SchThdInfo)";
                        }
                    }
                    //"schid in (select schid from SchThdInfo)"
                    if (!string.IsNullOrEmpty(txtname))
                    {
                        strwhere += " and SchName like '%" + Com.Public.SqlEncStr(txtname) + "%'";
                    }
                    Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
                    pages.PageIndex = int.Parse(PageIndex);
                    pages.PageSize = int.Parse(PageSize);
                    int rowc = 0; int pc = 0;

                    SchSystem.BLL.SchThdInfo thdbll = new SchSystem.BLL.SchThdInfo();
                    string clos = "SchId,SchName,AreaNo";
                    DataTable dt = userbll.GetListCols(clos, strwhere, "SchName", "", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
                    pages.PageCount = pc;
                    pages.RowCount = rowc;
                    if (dt.Rows.Count > 0)
                    {
                        dt.Columns.Add("Ustat");
                        dt.Columns.Add("SHENG");
                        dt.Columns.Add("SHI");
                        dt.Columns.Add("QU");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            bool thdbool = thdbll.Exists(int.Parse(dt.Rows[i]["SchId"].ToString()));
                            if (thdbool)
                            {
                                dt.Rows[i]["Ustat"] = "有";
                            }
                            else
                            {
                                dt.Rows[i]["Ustat"] = "无";
                            }
                            string[] areanames = Com.Public.GetArea(dt.Rows[i]["AreaNo"].ToString()).Split('|');
                            dt.Rows[i]["SHENG"] = areanames[0];
                            dt.Rows[i]["SHI"] = areanames[1];
                            dt.Rows[i]["QU"] = areanames[2];

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