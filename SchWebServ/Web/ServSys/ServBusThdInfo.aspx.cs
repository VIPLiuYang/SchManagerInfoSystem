using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebServ.Web.ServSys
{
    public partial class ServBusThdInfo : System.Web.UI.Page
    {
        public string schid = "0";
        #region 初始化
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
                } 
            }
        }
        #endregion
        #region 查询
        [WebMethod]
        public static string page(string PageIndex, string PageSize)
        {
         
                string ret = "";
                if (Com.Session.userid == null)
                {
                    ret = "expire";
                }
                else
                {
                    SchSystem.BLL.ServBusThd servbusthdbll = new SchSystem.BLL.ServBusThd();
                    string strwhere = "1=1 ";
                    Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
                    pages.PageIndex = int.Parse(PageIndex);
                    pages.PageSize = int.Parse(PageSize);
                    int rowc = 0;
                    int pc = 0;
                    string dbcols = "BusId,ThdName,ServiceId,FeeCode,CnName,BusMonth,BusNote,BusArea,BusUtype,Mbusid,BusType,BusUrl,Note,ThdMonth";
                    DataTable dt = servbusthdbll.GetListCols(dbcols, strwhere, "BusId", "ASC", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
                    pages.PageCount = pc;
                    pages.RowCount = rowc;
                    if (dt.Rows.Count > 0)
                    {
                        dt.Columns.Add("SHENG");
                        dt.Columns.Add("SHI");
                        dt.Columns.Add("TUserType");
                        dt.Columns.Add("TBusMonth");
                        dt.Columns.Add("TThdMonth");
                        dt.Columns.Add("TMbusidName");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dt.Rows[i]["SHENG"] = Com.Public.GetSSQ("0", dt.Rows[i]["BusArea"].ToString());
                            dt.Rows[i]["SHI"] = Com.Public.GetSSQ("1", dt.Rows[i]["BusArea"].ToString());
                            dt.Rows[i]["TUserType"] = dt.Rows[i]["BusUtype"].ToString() == "1" ? " 老师" : dt.Rows[i]["BusUtype"].ToString() == "2" ? " 家长" : "学生";
                            dt.Rows[i]["TBusMonth"] = Com.Public.InttoMonth(Convert.ToInt32(dt.Rows[i]["BusMonth"]));
                            dt.Rows[i]["TThdMonth"] = Com.Public.InttoMonth(Convert.ToInt32(dt.Rows[i]["ThdMonth"]));
                            dt.Rows[i]["TMbusidName"] = servbusthdbll.GetServBusNames(" BusId=" + Convert.ToInt32(dt.Rows[i]["Mbusid"]));
                        }
                        pages.list = dt;
                    }
                    ret = Newtonsoft.Json.JsonConvert.SerializeObject(pages);
                }
                return ret;
           
        }
        #endregion
    }
}