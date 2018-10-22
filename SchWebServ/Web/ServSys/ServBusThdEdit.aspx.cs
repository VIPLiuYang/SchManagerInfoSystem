using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebServ.Web.ServSys
{
    public partial class ServBusThdEdit : System.Web.UI.Page
    {
        public string umodelstr = "1";//model
        public string BusId = "";//套餐id 
        public string areastr = "";
        public string servbus = "";
        #region 初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Com.Session.userid == null)
            {
                Response.Redirect("../../Login.aspx");
                Response.End();
            }
            else
            {
                SchSystem.BLL.ServBusThd servbusbll = new SchSystem.BLL.ServBusThd();
                SchSystem.Model.ServBusThd servbusmodel = new SchSystem.Model.ServBusThd();
                BusId = Request.Params["BusId"].ToString();
                servbusmodel = servbusbll.GetModel(int.Parse(BusId));
                string FuncStr = "";
                if (servbusmodel != null && servbusmodel.BusId > 0)
                { 
                    umodelstr = Newtonsoft.Json.JsonConvert.SerializeObject(servbusmodel);
                }
                else
                {
                    Response.Write("无该套餐!");
                    Response.End();
                } 
                //获取下拉列表
                StringBuilder sbarea = new StringBuilder();
                //获取省份
                sbarea.Append(" <div class=\"row\">");
                sbarea.Append("<div class=\"col-xs-3 text-right\">默认归属地(省):</div>");
                sbarea.Append("<div class=\"col-xs-2 text-left\">");
                sbarea.Append("<select id=\"aprov\">");
                string sareacode = "";
                if (servbusmodel != null && servbusmodel.BusId > 0 && servbusmodel.BusArea.Length == 6)
                {
                    sareacode = servbusmodel.BusArea.Substring(0, 2) + "0000";
                }
                sbarea.Append(Com.Public.GetDrpArea("0", "", ref sareacode, false, "0"));
                sbarea.Append("</select> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;");
                sbarea.Append(" </div>");
                //获取城市
                sbarea.Append("<div class=\"col-xs-3 text-right\">默认归属地(市):</div>");
                sbarea.Append("<div class=\"col-xs-3 text-left\">");
                sbarea.Append("<select id=\"acity\">");
                string sareacitycode = "";
                if (servbusmodel != null && servbusmodel.BusId > 0 && servbusmodel.BusArea.Length == 6)
                {
                    sareacitycode = servbusmodel.BusArea.Substring(0, 4) + "00";
                }
                sbarea.Append(Com.Public.GetDrpArea("1", sareacode, ref sareacitycode, false, "0"));
                sbarea.Append("</select> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;");
                sbarea.Append(" </div>");
                sbarea.Append(" </div>");
                areastr = sbarea.ToString();
                //对应套餐
                SchSystem.BLL.ServBus stBll = new SchSystem.BLL.ServBus();
                DataTable stdt = stBll.GetList("BusId,CnName", "").Tables[0];
                servbus = Newtonsoft.Json.JsonConvert.SerializeObject(stdt); 
            }
        }
        #endregion
        #region 编辑保存
        [WebMethod]
        public static string ServBusEditSave(List<string> arr)
        {
            
                string ret = "";
                if (Com.Session.userid == null)
                {
                    ret = "expire";
                }
                else
                {
                    SchSystem.BLL.ServBusThd servbusbll = new SchSystem.BLL.ServBusThd();
                    SchSystem.Model.ServBusThd servbusmodel = new SchSystem.Model.ServBusThd();
                    foreach (string str in arr)
                    {
                        string[] strarr = str.Split('#');
                        if (strarr[0] == "BusId") { servbusmodel.BusId = Convert.ToInt32(strarr[1]); }
                        if (strarr[0] == "ThdName") { servbusmodel.ThdName = strarr[1]; }
                        if (strarr[0] == "ServiceId") { servbusmodel.ServiceId = strarr[1]; }
                        if (strarr[0] == "CnName") { servbusmodel.CnName = strarr[1]; }
                        if (strarr[0] == "FeeCode") { servbusmodel.FeeCode = strarr[1]; }
                        if (strarr[0] == "BusMonth") { servbusmodel.BusMonth = Convert.ToInt32(strarr[1]); }
                        if (strarr[0] == "BusNote") { servbusmodel.BusNote = strarr[1]; }
                        if (strarr[0] == "BusArea") { servbusmodel.BusArea = strarr[1]; }
                        if (strarr[0] == "BusUtype") { servbusmodel.BusUtype = Convert.ToInt32(strarr[1]); }
                        if (strarr[0] == "Mbusid") { servbusmodel.Mbusid = Convert.ToInt32(strarr[1]); }
                        if (strarr[0] == "ThdMonth") { servbusmodel.ThdMonth = Convert.ToInt32(strarr[1]); }
                        if (strarr[0] == "Note") { servbusmodel.Note = strarr[1]; }
                    }
                    try
                    {
                        if (servbusbll.Update(servbusmodel))
                        {
                            ret = "success";
                        }
                    }
                    catch (Exception ex)
                    {
                        ret = ex.Message;
                    }
                }
                return ret;
            
        }
        #endregion
    }
}