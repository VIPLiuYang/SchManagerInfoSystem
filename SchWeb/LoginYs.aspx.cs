using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWeb
{
    public partial class LoginYs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取cookie,如果有则自登录
            string uname = Com.CookieHelper.GetCookieValue("uname");
            if (uname.Length > 0)
            {
                string str = Com.Public.UserLoginDo(uname, false, Com.Public.getKey("adminschid"));
                if (str == "1")
                {
                    Response.Redirect("index.aspx");
                    Response.End();
                }
                else//出错,清除cookie
                {
                    Com.CookieHelper.ClearCookie("uname");
                }
            }
        }
    }
}