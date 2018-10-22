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
    public partial class ServBusThdAdd : System.Web.UI.Page
    {
        public string businessPlatfrom = "";
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
                //对应套餐
                SchSystem.BLL.ServBus stBll = new SchSystem.BLL.ServBus();
                DataTable stdt = stBll.GetList("BusId,CnName", "").Tables[0];
                servbus = Newtonsoft.Json.JsonConvert.SerializeObject(stdt);

                //获取下拉列表
                StringBuilder sbarea = new StringBuilder();
                //获取省份
                sbarea.Append(" <div class=\"row\">");
                sbarea.Append("<div class=\"col-xs-3 text-right\">默认归属地(省):</div>");
                sbarea.Append("<div class=\"col-xs-2 text-left\">");
                sbarea.Append("<select id=\"aprov\">");
                string sareacode = "";
                sbarea.Append(Com.Public.GetDrpArea("0", "", ref sareacode, false, "0"));
                sbarea.Append("</select> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;");
                sbarea.Append(" </div>");
                //获取城市
                sbarea.Append("<div class=\"col-xs-3 text-right\">默认归属地(市):</div>");
                sbarea.Append("<div class=\"col-xs-3 text-left\">");
                sbarea.Append("<select id=\"acity\">");
                string sareacitycode = "";
                sbarea.Append(Com.Public.GetDrpArea("1", sareacode, ref sareacitycode, false, "0"));
                sbarea.Append("</select> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;");
                sbarea.Append(" </div>");
                sbarea.Append(" </div>");
                areastr = sbarea.ToString();

            }
        }
        #endregion
        #region 添加保存
        [WebMethod]
        public static string ServBusThdAddSave(List<string> arr)
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
                        int result = servbusbll.Add(servbusmodel);
                        if (result > 0)
                        {
                            ret = "success";
                        }
                        else
                        {
                            ret = "error";
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
        #region 联动下拉框
        [WebMethod]
        public static string getarea(string typecode, string pcode)
        {
            string ret = "";
            try
            {
                string selp = "";
                if (typecode != "6")
                    ret = Com.Public.GetDrpArea(typecode, pcode, ref selp, false);
                else ret = Com.Public.GetDrp("dpt", pcode, "1", true, "", "");
            }
            catch (Exception ex)
            {
                ret = "";
            }
            return ret;
        }
        #endregion
    }
}