using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin.Web.SchSearch
{
    public partial class SchMenuSys : System.Web.UI.Page
    {
        public string usermenu;
        public string adminmenu;
        public string zxt;
        public string stat;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Params["schid"] != null && Request.Params["schid"].ToString() != "")
            {
                string schid = Com.Public.SqlEncStr(Request.Params["schid"].ToString());
                string thstr = "";
                try
                {

                    //判断是否有第三方菜单
                    WebClient wbc = new WebClient();
                    string thdstr = wbc.DownloadString(Com.Public.getKey("ThdInfo") + Com.Session.schid);
                    if (thdstr.IndexOf("\"appNum\":0") == -1)//有第三方系统菜单
                    {
                        thstr = " or FuncCode='22'";
                    }
                }
                catch (Exception ex)
                {

                }
                SchSystem.BLL.SchInfo schinfobll = new SchSystem.BLL.SchInfo();
                DataTable statDt = schinfobll.GetStat("schid=" + schid + "").Tables[0];
                stat = Convert.ToInt32(statDt.Rows[0]["SonSysStat"]) == 1 ? " 正常 " : " 停用 ";
                //获取前台应 
                DataTable useryyDt = Com.Public.SchMenuData("AutoId,AppCode,AppName", "", schid, "2");
                zxt = Newtonsoft.Json.JsonConvert.SerializeObject(useryyDt);
                //获取前台应用子菜单
                DataTable usermenuDt = Com.Public.SchMenuData("MenuId id,Pid pId,TextName name", thstr, schid, "0");
                usermenu = Newtonsoft.Json.JsonConvert.SerializeObject(usermenuDt);
                //获取后台管理子菜单
                DataTable adminmenuDt = Com.Public.SchMenuData("MenuId id,Pid pId,TextName name,FuncCode", thstr, schid, "1");
                adminmenu = Newtonsoft.Json.JsonConvert.SerializeObject(adminmenuDt);
            }

        }
    }
}