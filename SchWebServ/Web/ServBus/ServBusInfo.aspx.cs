using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebServ.Web.ServBus
{
    public partial class ServBusInfo : System.Web.UI.Page
    {
        public string schid = "0";
        public string cnnamefeecode = "";
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
                    schid = Com.Session.schid;

                    //套餐名称和资费金额
                    SchSystem.BLL.ServBus servbusbll = new SchSystem.BLL.ServBus();
                    DataTable stdt = servbusbll.GetList("CnName,FeeCode", "").Tables[0];
                    cnnamefeecode = Newtonsoft.Json.JsonConvert.SerializeObject(stdt);
                }
            }
        }
        #endregion
        #region 查询
        [WebMethod]
        public static Com.DataPack.DataRsp<string> page(string PageIndex, string PageSize, string ServiceId, string CnName, string FeeCode, string BusMonth)
        { 
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            if (Com.Session.userid == null)
            {
                rsp.code = "expire";
                rsp.msg="你现在登录已过期，请重新登录！";
            }
            else
            {
                SchSystem.BLL.ServBus servbusbll = new SchSystem.BLL.ServBus();
                string strwhere = "1=1 ";
                if (!string.IsNullOrEmpty(ServiceId))
                {
                    strwhere += " and ServiceId = '" + Com.Public.SqlEncStr(ServiceId) + "'";
                }
                if (!string.IsNullOrEmpty(CnName))
                {
                    strwhere += " and CnName = '" + Com.Public.SqlEncStr(CnName) + "'";
                }
                if (!string.IsNullOrEmpty(FeeCode))
                {
                    strwhere += " and FeeCode = '" + Com.Public.SqlEncStr(FeeCode) + "'";
                }
                if (!string.IsNullOrEmpty(BusMonth))
                {
                    strwhere += " and BusMonth = '" + Com.Public.SqlEncStr(BusMonth) + "'";
                }
                Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
                pages.PageIndex = int.Parse(PageIndex);
                pages.PageSize = int.Parse(PageSize);
                int rowc = 0;
                int pc = 0;
                try
                {
                    string dbcols = "BusId,ServiceId,FeeCode,CnName,FuncStr,BusMonth,BusNote,BusType,BusUrl,Note,CapName,BusArea,FrmType";
                    DataTable dt = servbusbll.GetListCols(dbcols, strwhere, "BusId", "DESC", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
                    pages.PageCount = pc;
                    pages.RowCount = rowc;
                    if (dt.Rows.Count > 0)
                    {
                        dt.Columns.Add("TBusType");
                        dt.Columns.Add("TBusMonth");
                        dt.Columns.Add("TServFuncName");
                        dt.Columns.Add("Province");
                        dt.Columns.Add("City");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string FuncStr = dt.Rows[i]["FuncStr"].ToString();
                            if (FuncStr != "")
                            {
                                string[] FuncStrArr = FuncStr.Split(',');
                                string FuncStrstr = "";
                                foreach (string s in FuncStrArr)
                                {
                                    FuncStrstr += "'" + s + "',";
                                }
                                FuncStr = FuncStrstr.Substring(0, FuncStrstr.Length - 1);
                            }
                            dt.Rows[i]["TServFuncName"] = servbusbll.GetFuncNames("FuncCode in (" + FuncStr + ")");
                            dt.Rows[i]["TBusType"] = dt.Rows[i]["BusType"].ToString() == "1" ? " 自定义套餐" : "CP套餐";
                            dt.Rows[i]["TBusMonth"] = Com.Public.InttoMonth(Convert.ToInt32(dt.Rows[i]["BusMonth"]));
                            if (!string.IsNullOrEmpty(dt.Rows[i]["BusArea"].ToString()))
                            {
                                dt.Rows[i]["Province"] = Com.Public.GetSSQ("0", dt.Rows[i]["BusArea"].ToString());
                                dt.Rows[i]["City"] = Com.Public.GetSSQ("1", dt.Rows[i]["BusArea"].ToString());
                            }
                            else
                            {
                                dt.Rows[i]["Province"] = "";
                                dt.Rows[i]["City"] = "";
                            }
                        }
                        pages.list = dt;
                    }
                }
                catch(Exception ex)
                {
                    rsp.code="ExcepError";
                    rsp.msg=ex.Message;
                }
                rsp.RspData = Newtonsoft.Json.JsonConvert.SerializeObject(pages);
            }
            return rsp; 
        }
        #endregion
    }
}