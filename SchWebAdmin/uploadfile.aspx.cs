using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWeb
{
    public partial class uploadfile : System.Web.UI.Page
    {
        public static string userid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            userid = Request.Params["userid"].ToString();
        }
        
    }
}