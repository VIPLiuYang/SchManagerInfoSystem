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
    public partial class ServBusAdd : System.Web.UI.Page
    {
        public string businessPlatfrom = "";
        public string province = "";
        public string city = "";

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
                //业务功能
                SchSystem.BLL.ServFunc servfuncbll = new SchSystem.BLL.ServFunc();
                DataTable servfuncdt = servfuncbll.GetList("'0' pId,FuncName name,FuncCode id,TypeCode,'false' checked", "").Tables[0];
                businessPlatfrom = Newtonsoft.Json.JsonConvert.SerializeObject(servfuncdt);
                #region 獲取省市區
                //获取省份
                StringBuilder areaProvince = new StringBuilder();
                string sareacode = "";
                areaProvince.Append(Com.Public.GetDrpArea("0", "", ref sareacode, true, "1"));
                province = areaProvince.ToString();
                //获取城市
                StringBuilder areaCity = new StringBuilder();
                string sareacitycode = "";
                areaCity.Append(Com.Public.GetDrpArea("1", sareacode, ref sareacitycode, true, "1"));
                city = areaCity.ToString();
                #endregion
            }
        }
        #endregion
        #region 添加保存
        [WebMethod]
        public static Com.DataPack.DataRsp<string> ServBusAddSave(List<string> arr)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            if (Com.Session.userid == null)
            {
                rsp.code = "expire";
                rsp.msg = "你现在登录已过期，请重新登录！";
            }
            else
            {
                SchSystem.BLL.ServBus servbusbll = new SchSystem.BLL.ServBus();
                SchSystem.Model.ServBus servbusmodel = new SchSystem.Model.ServBus();
                try
                {
                    foreach (string str in arr)
                    {
                        string[] strarr = str.Split('#');
                        if (strarr[0] == "ServiceId") { servbusmodel.ServiceId = strarr[1]; }
                        else if (strarr[0] == "CnName") { servbusmodel.CnName = strarr[1].Trim(); }
                        else if (strarr[0] == "BusType") { servbusmodel.BusType = Convert.ToInt32(strarr[1]); }
                        else if (strarr[0] == "FeeCode") { servbusmodel.FeeCode = strarr[1].Trim(); }
                        else if (strarr[0] == "BusMonth") { servbusmodel.BusMonth = Convert.ToInt32(strarr[1]); }
                        else if (strarr[0] == "FuncStr") { servbusmodel.FuncStr = strarr[1].Trim(); }
                        else if (strarr[0] == "BusNote") { servbusmodel.BusNote = strarr[1].Trim(); }
                        else if (strarr[0] == "Note") { servbusmodel.Note = strarr[1].Trim(); }
                        else if (strarr[0] == "BusUrl") { servbusmodel.BusUrl = strarr[1].Trim(); }
                        else if (strarr[0] == "CapName") { servbusmodel.CapName = strarr[1].Trim(); }
                        else if (strarr[0] == "acity") { servbusmodel.BusArea = strarr[1].Trim(); }
                        else if (strarr[0] == "FrmType") { servbusmodel.FrmType = int.Parse(strarr[1]); }
                    }
                    if (servbusmodel.CnName == "" || servbusmodel.CapName == ""  )
                    {
                        rsp.code = "error";
                        rsp.msg = "操作失败！不允许输入空格";
                    }
                    else if (servbusbll.ExistsServiceId(0, servbusmodel.ServiceId))
                    {
                        rsp.code = "code";
                        rsp.msg = "套餐代码不允许重复";
                    }
                    else if (servbusbll.ExistsCnName(0, servbusmodel.CnName))
                    {
                        rsp.code = "zhcf";
                        rsp.msg = "套餐名称不允许重复";
                    }
                    else if (servbusbll.ExistsCapNameRepeat(servbusmodel.CapName))
                    {
                        rsp.code = "capname";
                        rsp.msg = "系统显示名称不允许重复";
                    }
                    else
                    {
                        int result = servbusbll.Add(servbusmodel);
                        if (result > 0)
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
        //                ret = Com.Public.GetDrpArea(typecode, pcode, ref selp, true,"1");
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