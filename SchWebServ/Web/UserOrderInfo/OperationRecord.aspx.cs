using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebServ.Web.UserOrderInfo
{
    public partial class OperationRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Com.Session.userid == null)
            {
                Response.Redirect("../../Login.aspx");
                Response.End();
            }
            else
            {

            }
        }
    }
}