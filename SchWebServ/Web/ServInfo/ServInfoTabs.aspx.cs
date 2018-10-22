using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebServ.Web.ServInfo
{
    public partial class ServInfoTabs : System.Web.UI.Page
    {
        public string schid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            schid = Com.Session.schid;
        }
    }
}