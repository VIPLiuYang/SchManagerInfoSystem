using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin
{
    public partial class uploadfileapp : System.Web.UI.Page
    {
        public static string userid = "";
        public string appurl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            appurl =System.Web.HttpUtility.UrlDecode(Request.Params["appuserapiurl"].ToString());
            string jsid = Request.Params["sid"].ToString();
            string jstoken = Request.Params["token"].ToString();
            
            Com.SoureSession.jsid = jsid;
            Com.SoureSession.jstoken = jstoken;
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(jsid, jstoken, appurl);
            if (rsp.code == "ERROR_TOKEN")
            {
                Response.Write("登录已失效!");
                Response.End();
            }
            else if (!IsPostBack)
            {
                userid = Com.SoureSession.Soureusertid;
            }

        }
    }
}