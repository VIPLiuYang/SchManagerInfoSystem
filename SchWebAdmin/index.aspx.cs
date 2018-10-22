using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin
{
    public partial class index : System.Web.UI.Page
    {
        public string treestr = "";
        public string indexpage = "./Web/SchInfo/SchInfo.aspx";
        //public string indexpage = "./SchoolBaxicInfo/School/SchInfo.aspx";
        public string uskin = "#438EB9";
        public string usertname = "";
        public string thurl = "";
        public string uname = "";
        public string utitlename = "智慧校园支撑管理系统";
        public string imgurl = "assets/avatars/user.jpg";//默认头像地址
        public string systype = "";
        public string schinfostr = "";
        public string schid = "";
        public string usertid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Com.Session.userid == null)
            {
                Response.Redirect("Login.aspx");
                Response.End(); 
            }
            else
            {
                schid = Com.Session.schid;
                usertid = Com.Session.usertid;
                string thstr = "";//是否有第三方菜单权限
                try
                {
                    //判断是否有第三方菜单
                    WebClient wbc = new WebClient();
                    string thdstr = wbc.DownloadString(Com.Public.getKey("ThdInfo") + Com.Session.schid);
                    if (thdstr.IndexOf("\"appNum\":0") == -1)//有第三方系统菜单
                    {
                        thstr = ",22";
                        StringBuilder ss = new StringBuilder();
                        ss.Append("<li class=\"divider\"></li>");
                        ss.Append("<li>");
                        ss.Append("<a href=\"" + Com.Public.getKey("ThdUinfo").Replace("/sid/sessionid", "/sid/" + Session.SessionID) + "\" target=\"iframe0\" class=\"text_color\">");
                        ss.Append("<i class=\"icon-cog\" style=\"margin-left: -2px\"></i>");
                        ss.Append("第三方系统账号");
                        ss.Append("</a>");
                        ss.Append("</li>");
                        thurl = ss.ToString();
                    }
                }
                catch (Exception ex)
                {

                }
                SysListBind(thstr);
                usertname = Com.Session.uname;//真实姓名
                uname = Com.Session.userid;//登录账号
                if (!string.IsNullOrEmpty(Com.Session.imgurl))
                {
                    imgurl = Com.Public.getKey("adminurl") + "\\" + Com.Session.imgurl;
                }
                
            }
        }

        //绑定系统列表
        public void SysListBind(string thstr)
        {
            StringBuilder sb = new StringBuilder();

            DataTable menuDt = Com.Public.MenuData(thstr);

            DataRow[] drs = menuDt.Select("PID=0", "OrderId");
            int i = 0;
            foreach (DataRow dr in drs)
            {

                if (string.IsNullOrEmpty(dr["NavUrl"].ToString()))
                {
                    if (i == 0)
                    {
                        sb.Append("<li class=\"active atg\">");
                    }
                    else
                    {
                        sb.Append("<li>");
                    }
                    sb.Append("<a href=\"#\" class=\"dropdown-toggle\" title=\"" + dr["TextName"].ToString() +"\">");
                    sb.Append("<i class=\"" + dr["Ico"].ToString() + "\"></i>");
                    sb.Append("<span class=\"menu-text\">" + dr["TextName"].ToString() + "</span>");
                    sb.Append("<b class=\"arrow icon-angle-down\"></b>");
                    sb.Append("</a>");
                    sb.Append("<ul class=\"submenu\">");
                    int menuID1 = int.Parse(dr["MenuId"].ToString());
                    TreeViewChildAdd(menuID1, sb, menuDt);
                    sb.Append("</ul>");
                    sb.Append("</li>");
                }
                else
                {
                    if (i == 0)
                    {
                        sb.Append("<li class=\"active atg\">");
                    }
                    else
                    {
                        sb.Append("<li class=\"atg\">");
                    }

                    sb.Append("<a href=\"" + dr["NavUrl"].ToString().Replace("/sid/sessionid", "/sid/" + Session.SessionID) + "\" target=\"iframe0\" title=\"" + dr["TextName"].ToString() + "\">");
                    sb.Append("<i class=\"" + dr["Ico"].ToString() + "\"></i>");
                    sb.Append("<span class=\"menu-text\">" + dr["TextName"].ToString() + "</span>");
                    sb.Append("</a>");
                    sb.Append("</li>");
                }
                i++;

            }

            treestr = sb.ToString();
        }

        public void TreeViewChildAdd(int menuID, StringBuilder sb, DataTable menuDt)
        {
            //得到该节点的所有子节点
            DataRow[] drs = menuDt.Select("PID= " + menuID.ToString());

            foreach (DataRow dr in drs)
            {
                //有下级子节点的
                if (string.IsNullOrEmpty(dr["NavUrl"].ToString()))
                {
                    sb.Append("<li>");
                    sb.Append("<a href=\"#\" class=\"dropdown-toggle\">");
                    sb.Append("<i class=\"" + dr["Ico"].ToString() + "\"></i>");
                    sb.Append("<span class=\"menu-text\">" + dr["TextName"].ToString() + "</span>");
                    sb.Append("<b class=\"arrow icon-angle-down\"></b>");
                    sb.Append("</a>");
                    sb.Append("<ul class=\"submenu\">");
                    int menuID1 = int.Parse(dr["MenuId"].ToString());
                    TreeViewChildAdd(menuID1, sb, menuDt);
                    sb.Append("</ul>");
                    sb.Append("</li>");
                }
                else
                {
                    sb.Append("<li class=\"atg\">");
                    sb.Append("<a href=\"" + dr["NavUrl"].ToString().Replace("/sid/sessionid", "/sid/" + Session.SessionID) + "\" target=\"iframe0\">");
                    sb.Append("<i class=\"" + dr["Ico"].ToString() + "\"></i>");
                    sb.Append("<span class=\"menu-text\">" +  dr["TextName"].ToString() + "</span>");
                    sb.Append("</a>");
                    sb.Append("</li>");
                }

            }
        }
    }
}