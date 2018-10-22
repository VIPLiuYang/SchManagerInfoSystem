using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWeb
{
    public partial class index : System.Web.UI.Page
    {
        public string treestr = "";
        public string indexpage = "";
        //public string indexpage = "./SchoolBaxicInfo/School/SchInfo.aspx";
        public string uskin = "#438EB9";
        public string usertname = "";
        public string thurl = "";
        public string utitlename = "智慧校园管理后台";
        public string imgurl = "assets/avatars/user.jpg";//默认头像地址
        public string username = "";
        public string systype = "";
        public string SchMasterstr = "";
        public string PlatformName = "";
        public string PlatformIco = "";
        public string UploadHeadPic = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Com.Session.schid == null) { Response.Redirect("Login.aspx", false); return; }
            string thstr = "";//是否有第三方菜单权限
            if (Com.Session.systype == "0")
            {
                systype = Com.Session.systype;
                utitlename = "智慧校园平台";
                UploadHeadPic = Com.Public.getKey("adminurl") + "/uploadfile.aspx?userid=" + Com.Session.usertid;//schtype:值为0代表普通老师后台，1代表学校管理员后台

            }
            SysListBind(thstr);
            usertname = Com.Session.uname;
            username = Com.Session.userid;
            if (!string.IsNullOrEmpty(Com.Session.imgurl))
            {
                imgurl = Com.Public.getKey("adminurl") + "\\" + Com.Session.imgurl;
            }
            //获取学校基本数据
            SchSystem.BLL.SchInfo siBll = new SchSystem.BLL.SchInfo();
            DataTable dtschinfo = siBll.GetList("SchMaster,PlatformName,PlatformIco", "SchId='" + Com.Session.schid + "'").Tables[0];
            if (dtschinfo.Rows.Count > 0)
            {
                SchMasterstr = dtschinfo.Rows[0]["SchMaster"].ToString();
                if (Com.Session.systype != "0")
                {
                    PlatformName = dtschinfo.Rows[0]["PlatformName"].ToString() + "管理后台";
                }
                else
                {
                    PlatformName = dtschinfo.Rows[0]["PlatformName"].ToString();
                }
                PlatformIco = Com.Public.getKey("adminurl") + dtschinfo.Rows[0]["PlatformIco"].ToString();
            }
            if (PlatformName == "管理后台")
            {
                PlatformName = utitlename;
            }
            if (PlatformIco == "")
            {
                PlatformIco = "<i class=\"icon-leaf\"></i>";
            }
            else
            {
                PlatformIco = "<img style=\"width:20px;\" src='" + PlatformIco + "' />";
            }
        }
        //绑定系统列表
        public void SysListBind(string thstr)
        {
            StringBuilder sb = new StringBuilder();
            DataTable menuDt = Com.Public.MenuData(thstr);
            //第三方升级为模块后
            if (menuDt.Rows.Count > 0)
            {
                DataRow[] drsth = menuDt.Select("FuncCode='22'");//看是否有第三方菜单
                if (drsth.Length > 0)
                {
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
                        else
                        {
                            menuDt.Rows.Remove(drsth[0]);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            //如果为单独部署,则获取学校特殊配置的子系统菜单
            if (Com.Public.getKey("issch") == "1")
            {
                string schid = Com.Public.getKey("appschid");
                //获取该学校的配置菜单                
                SchSystem.BLL.SchMenuInfoRouter smrBll = new SchSystem.BLL.SchMenuInfoRouter();
                DataTable dtmenusch = smrBll.GetList("NavUrl,TextName,FuncCode", " SchId='" + schid + "' and SysType=0").Tables[0];
                if (dtmenusch.Rows.Count > 0)
                {
                    if (menuDt.Rows.Count > 0)
                    {
                        for (int j = 0; j < menuDt.Rows.Count; j++)
                        {
                            DataRow[] drsm = dtmenusch.Select("FuncCode='" + menuDt.Rows[j]["FuncCode"].ToString() + "'");
                            if (drsm.Length > 0)
                            {
                                menuDt.Rows[j]["NavUrl"] = drsm[0]["NavUrl"].ToString();
                                menuDt.Rows[j]["TextName"] = drsm[0]["TextName"].ToString();
                            }
                        }
                    }
                }
            }
            if (Com.Session.systype == "0")//普通老师,插入首页
            {
                uskin = "#C6487E";
                DataRow dtr = menuDt.NewRow();
                dtr["OrderId"] = "0";
                dtr["MenuId"] = "0";
                dtr["FuncCode"] = "0";
                dtr["PID"] = "0";
                dtr["Ico"] = "icon-home";
                if (Com.Public.getKey("isyssch") == "1")
                {
                    dtr["TextName"] = "资源管理";
                    dtr["NavUrl"] = Com.Public.getKey("isysschurl").Replace("/sid/sessionid", "/sid/" + Session.SessionID);
                    string request_url = HttpContext.Current.Request.Url.ToString();
                    if (request_url.ToLower().IndexOf("localhost") < 0)
                    {
                        indexpage = Com.Public.getKey("isysschurl").Replace("/sid/sessionid", "/sid/" + Session.SessionID);
                    }
                    menuDt.Rows.InsertAt(dtr, 0);//普通用户不加,只调定位到通知
                }
                else
                {
                    dtr["TextName"] = "首页";
                    dtr["NavUrl"] = "jsywebindex.html";
                    indexpage = "jsywebindex.html";
                }

            }
            DataRow[] drs = menuDt.Select("PID=0", "OrderId");
            int i = 0;
            foreach (DataRow dr in drs)
            {
                //获取OA未读数
                string oac = "";
                if (dr["FuncCode"].ToString() == "8" || dr["FuncCode"].ToString() == "9")
                {

                    try
                    {
                        //判断是否有第三方菜单
                        WebClient wbc = new WebClient();
                        //string thdstr = wbc.DownloadString(string.Format(Com.Public.getKey("OAInfo"), "100005", "115").Replace("||", "&"));
                        string thdstr = wbc.DownloadString(string.Format(Com.Public.getKey("OAInfo"), Com.Session.schid, Com.Session.usertid).Replace("||", "&"));
                        Com.Public.OAPack<Com.Public.OANoRead> oas = (Com.Public.OAPack<Com.Public.OANoRead>)Newtonsoft.Json.JsonConvert.DeserializeObject(thdstr, typeof(Com.Public.OAPack<Com.Public.OANoRead>));
                        if (dr["FuncCode"].ToString() == "8")
                        {
                            oac = oas.RspData.NoReadCnt.ToString();
                        }
                        else
                        {
                            oac = oas.RspData.NoApproveCnt.ToString();
                        }
                        if (oac != "0")
                        {
                            oac = "<div class=\"notice\">" + oac + "</div>";
                            //oac = "<span class=\"badge badge-primary \">" + oac + "</span>";
                        }
                        else
                        {
                            oac = "";
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (string.IsNullOrEmpty(dr["NavUrl"].ToString()))
                {
                    //if (i == 0)
                    //{
                    //    sb.Append("<li class=\"active atg\">");
                    //}
                    //else
                    //{
                    //    sb.Append("<li>");
                    //}
                    sb.Append("<li>");
                    sb.Append("<a href=\"#\" class=\"dropdown-toggle\">");
                    sb.Append("<i class=\"" + dr["Ico"].ToString() + "\"></i>");
                    sb.Append("<span class=\"menu-text\">" + dr["TextName"].ToString() + oac + "</span>");
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
                    if (dr["FuncCode"].ToString() == "8")//(i == 0)
                    {
                        sb.Append("<li class=\"active atg\">");
                        string request_url = HttpContext.Current.Request.Url.ToString();
                        if (request_url.ToLower().IndexOf("localhost") < 0)
                        {
                            indexpage = dr["NavUrl"].ToString().Replace("/sid/sessionid", "/sid/" + Session.SessionID);
                        }
                    }
                    else
                    {
                        sb.Append("<li class=\"atg\">");
                    }

                    sb.Append("<a href=\"" + dr["NavUrl"].ToString().Replace("/sid/sessionid", "/sid/" + Session.SessionID) + "\" onclick=\"strolltop();\" target=\"iframe0\">");
                    sb.Append("<i class=\"" + dr["Ico"].ToString() + "\"></i>");
                    sb.Append("<span class=\"menu-text wrap\">" + dr["TextName"].ToString() + oac + "</span>");
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
                    sb.Append("<span class=\"menu-text\">" + "&nbsp;&nbsp;&nbsp;&nbsp;" + dr["TextName"].ToString() + "</span>");
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
                    if (dr["FuncCode"].ToString() == "8")//(i == 0)
                    {
                        sb.Append("<li class=\"active atg\">");
                        string request_url = HttpContext.Current.Request.Url.ToString();
                        if (request_url.ToLower().IndexOf("localhost") < 0)
                        {
                            indexpage = dr["NavUrl"].ToString().Replace("/sid/sessionid", "/sid/" + Session.SessionID);
                        }
                    }
                    else
                    {
                        sb.Append("<li class=\"atg\">");
                    }
                    sb.Append("<a href=\"" + dr["NavUrl"].ToString().Replace("/sid/sessionid", "/sid/" + Session.SessionID) + "\" onclick=\"strolltop();\" target=\"iframe0\">");
                    sb.Append("<i class=\"" + dr["Ico"].ToString() + "\"></i>");
                    sb.Append("<span class=\"menu-text\">" + "&nbsp;&nbsp;&nbsp;&nbsp;" + dr["TextName"].ToString() + "</span>");
                    sb.Append("</a>");
                    sb.Append("</li>");
                }

            }
        }
    }
}