using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebMaster.Web.UserFuncSoure
{
    public partial class UploadFile : System.Web.UI.Page
    {
        public string indexpage = "./SchoolBaxicInfo/SchStructureSet/SchStructureSet.aspx";
        public string systype = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string jsid = Request.Params["sid"].ToString();
            string jstoken = Request.Params["token"].ToString();
            Com.SoureSession.jsid = jsid;
            Com.SoureSession.jstoken = jstoken;
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(jsid, jstoken);
            if (rsp.code == "ERROR_TOKEN")
            {
                Response.Write("登录已失效!");
                Response.End();
            }
            else if (!IsPostBack)
            {
                systype = Com.SoureSession.Souresystype;
            }

        }
        [WebMethod]
        public string uploadfile(string uploadfileinput)
        {


            string ret = "";

            return ret;
        }
    }
}