using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebServ
{
    public partial class PlcData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region 省市区联动下拉框
        [WebMethod]
        public static Com.DataPack.DataRsp<string> getarea(string typecode, string pcode, string uareano,bool addall)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            if (Com.Session.userid == null)
            {
                rsp.code = "expire";
                rsp.msg = "你现在登录已过期，请重新登录！";
            }
            else
            {
                try
                {
                    string selp = "";
                    if (typecode != "6")
                    {
                        selp = uareano;
                        rsp.RspData = Com.Public.GetDrpArea(typecode, pcode, ref selp, addall, "1");
                    }
                    else
                    {
                        rsp.RspData = Com.Public.GetDrp("dpt", pcode, "1", addall, "", "");
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
    }
}