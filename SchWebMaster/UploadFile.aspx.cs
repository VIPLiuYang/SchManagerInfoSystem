using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebMaster
{
    public partial class UploadFile : System.Web.UI.Page
    {
        public string indexpage = "./SchoolBaxicInfo/SchStructureSet/SchStructureSet.aspx";
        public string systype = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            systype = Com.Session.systype;
        }
        [WebMethod]
        public string uploadfile(string uploadfileinput)
        {
            
            
            string ret = "";

            return ret;
        }
    }
}