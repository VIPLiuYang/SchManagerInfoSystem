using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin.Web.SchIsAlone
{
    public partial class SchIsAlone : System.Web.UI.Page
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
                        strwhere += " and Stat='1' and SonSysStat='" + Com.Public.SqlEncStr(ustat) + "'";
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
                    string dbcols = "SchId,SchName,PlatformIP,AloneUser,AreaNo,AloneTime,PlatformUrl,IsAlone";
                    DataTable dt = userbll.GetListCols(dbcols, strwhere, "SchName", "ASC", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
                    pages.PageCount = pc;
                    pages.RowCount = rowc;
                    if (dt.Rows.Count > 0)
                    {
                        dt.Columns.Add("SHENG");
                        dt.Columns.Add("SHI");
                        dt.Columns.Add("QU");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
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
        public static Com.DataPack.DataRsp<string> isalone(string id, string isalone)
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
                        if (isalone == "&times;")//如果传值为×时，则需要修改为单独部署
                        {
                            model.IsAlone = 1;
                        }
                        else//如果传值为√时，则需要取消单独部署
                        {
                            model.IsAlone = 0;
                        }
                        model.AloneTime = DateTime.Now;
                        model.AloneUser = Com.Session.userid;
                        if (bll.UpdateAlone(model))
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