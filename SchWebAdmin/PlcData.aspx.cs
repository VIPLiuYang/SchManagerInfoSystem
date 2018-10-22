using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin
{
    public partial class PlcData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static Com.DataPack.DataRsp<string> getarea(string typecode, string pcode, string isall)
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
                    string selp = "";
                    if (isall == "1")
                    {
                        rsp.data = Com.Public.GetDrpArea(Com.Public.SqlEncStr(typecode), Com.Public.SqlEncStr(pcode), ref selp, true);
                    }
                    else
                    {
                        rsp.data = Com.Public.GetDrpArea(Com.Public.SqlEncStr(typecode), Com.Public.SqlEncStr(pcode), ref selp, false);
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
    }
}