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

namespace SchWebServ.Web.ServBus
{
    public partial class ServBusEdit : System.Web.UI.Page
    {
        public string umodelstr = "1";//model
        public string BusId = "";//套餐id
        public string businessPlatfrom = "";
        public string province = "";
        public string city = "";
        #region 初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            SchSystem.BLL.ServBus servbusbll = new SchSystem.BLL.ServBus();
            SchSystem.Model.ServBus servbusmodel = new SchSystem.Model.ServBus();
            BusId = Request.Params["BusId"].ToString();
            servbusmodel = servbusbll.GetModel(int.Parse(BusId));
            string FuncStr = ""; string sareacode = ""; string sareacitycode = "";
            if (servbusmodel != null && servbusmodel.BusId > 0)
            {
                FuncStr = servbusmodel.FuncStr;
                if (!string.IsNullOrEmpty(servbusmodel.BusArea))
                {
                    sareacode = servbusmodel.BusArea.Substring(0, 2) + "0000";
                    sareacitycode = servbusmodel.BusArea;
                }
                umodelstr = Newtonsoft.Json.JsonConvert.SerializeObject(servbusmodel);
            }
            else
            {
                Response.Write("无该套餐!");
                Response.End();
            }
            //业务功能
            SchSystem.BLL.ServFunc servfuncBll = new SchSystem.BLL.ServFunc();
            DataTable servfuncdt = servfuncBll.GetList("'0' pId,FuncName name,FuncCode id,TypeCode,'false' checked", "").Tables[0];
            if (servfuncdt.Rows.Count > 0)
            {
                if (FuncStr != "")
                {
                    string[] ServFuncArr = FuncStr.Split(',');
                    foreach (string s in ServFuncArr)
                    {
                        for (int i = 0; i < servfuncdt.Rows.Count; i++)
                        {
                            if (servfuncdt.Rows[i]["id"].ToString() == s)
                            {
                                servfuncdt.Rows[i]["checked"] = "true";
                            }
                        }
                    }
                }
            }
            businessPlatfrom = Newtonsoft.Json.JsonConvert.SerializeObject(servfuncdt);
            #region 獲取省市區
            //获取省份
            StringBuilder areaProvince = new StringBuilder();

            areaProvince.Append(Com.Public.GetDrpArea("0", "", ref sareacode, true, "0"));
            province = areaProvince.ToString();
            //获取城市
            StringBuilder areaCity = new StringBuilder();

            areaCity.Append(Com.Public.GetDrpArea("1", sareacode, ref sareacitycode, true, "0"));
            city = areaCity.ToString();
            #endregion
        }
        #endregion
        #region 编辑保存
        [WebMethod]
        public static Com.DataPack.DataRsp<string> ServBusEditSave(List<string> arr)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            if (Com.Session.userid == null)
            {
                rsp.code = "expire";
                rsp.msg = "你现在登录已过期，请重新登录！";
            }
            else
            {
                string currentCnName = ""; string currentCode = "";
                try
                {
                    SchSystem.BLL.ServBus servbusbll = new SchSystem.BLL.ServBus();
                    SchSystem.Model.ServBus servbusmodel = new SchSystem.Model.ServBus();
                    foreach (string str in arr)
                    {
                        string[] strarr = str.Split('#');
                        if (strarr[0] == "BusId") { servbusmodel.BusId = Convert.ToInt32(strarr[1]); }
                        else if (strarr[0] == "ServiceId") { servbusmodel.ServiceId = strarr[1]; }
                        else if (strarr[0] == "CnName") { servbusmodel.CnName = strarr[1].Trim(); }
                        else if (strarr[0] == "BusType") { servbusmodel.BusType = Convert.ToInt32(strarr[1]); }
                        else if (strarr[0] == "FeeCode") { servbusmodel.FeeCode = strarr[1].Trim(); }
                        else if (strarr[0] == "BusMonth") { servbusmodel.BusMonth = Convert.ToInt32(strarr[1]); }
                        else if (strarr[0] == "FuncStr") { servbusmodel.FuncStr = strarr[1].Trim(); }
                        else if (strarr[0] == "BusNote") { servbusmodel.BusNote = strarr[1].Trim(); }
                        else if (strarr[0] == "Note") { servbusmodel.Note = strarr[1].Trim(); }
                        else if (strarr[0] == "cnname") { currentCnName = strarr[1].Trim(); }
                        else if (strarr[0] == "code") { currentCode = strarr[1].Trim(); }
                        else if (strarr[0] == "BusUrl") { servbusmodel.BusUrl = strarr[1].Trim(); }
                        else if (strarr[0] == "CapName") { servbusmodel.CapName = strarr[1].Trim(); }
                        else if (strarr[0] == "acity") { servbusmodel.BusArea = strarr[1].Trim(); }
                        else if (strarr[0] == "FrmType") { servbusmodel.FrmType = int.Parse(strarr[1]); }
                    }
                    DataTable cnnamedt = servbusbll.ExistsCnNameUpdate(servbusmodel.CnName, 0, currentCnName).Tables[0];
                    DataTable codedt = servbusbll.ExistsCodeUpdate(servbusmodel.ServiceId, 0, currentCode).Tables[0];
                    if (servbusmodel.CnName == "" || servbusmodel.CapName == "")
                    {
                        rsp.code = "error";
                        rsp.msg = "操作失败！不允许输入空格";
                    }
                    else if (cnnamedt.Rows.Count > 0)
                    {
                        rsp.code = "namecf";
                        rsp.msg = "套餐名称不允许重复！";
                    }
                    else if (codedt.Rows.Count > 0)
                    {
                        rsp.code = "codecf";
                        rsp.msg = "套餐代码不允许重复！";
                    }
                    else if (servbusbll.ExistsCapNameRepeat(servbusmodel.BusId, servbusmodel.CapName))
                    {
                        rsp.code = "capname";
                        rsp.msg = "系统显示名称不允许重复";
                    }
                    else
                    {
                        if (servbusbll.Update(servbusmodel))
                        {
                            rsp.code = "success";
                            rsp.msg = "操作成功！";
                        }
                        else
                        {
                            rsp.code = "error";
                            rsp.msg = "操作失败！";
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
        #endregion
        //#region 省市区联动下拉框
        //[WebMethod]
        //public static string getarea(string typecode, string pcode, string uareano)
        //{
        //    string ret = "";
        //    if (Com.Session.userid == null)
        //    {
        //        ret = "expire";
        //    }
        //    else
        //    {
        //        try
        //        {
        //            string selp = "";
        //            if (typecode != "6")
        //            {
        //                selp = uareano;
        //                ret = Com.Public.GetDrpArea(typecode, pcode, ref selp, true, "1");
        //            }
        //            else ret = Com.Public.GetDrp("dpt", pcode, "1", true, "", "");
        //        }
        //        catch (Exception ex)
        //        {
        //            ret = ex.Message;
        //        }
        //    }
        //    return ret;
        //}
        //#endregion
    }
}