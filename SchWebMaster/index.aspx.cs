using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebMaster
{
    public partial class index : System.Web.UI.Page
    {
        public string treestr = "";
        public string indexpage = "./Web/SchStructureSet/SchStructureSet.aspx";
        //public string indexpage = "./SchoolBaxicInfo/School/SchInfo.aspx";
        public string uskin = "#438EB9";
        public string usertname = "";
        public string thurl = "";
        public string utitlename = "智慧校园管理后台";
        public string imgurl = "assets/avatars/user.jpg";//默认头像地址
        public string username = "";
        public string systype = "";
        //public string SchMasterstr = "";//系统管理员
        public string PlatformName = "";
        public string PlatformIco = "";
        public string UploadHeadPic = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Com.Session.schid == null) { Response.Redirect("Login.aspx", false); return; }
            UploadHeadPic = Com.Public.getKey("adminurl") + "/UploadFile.aspx?schid=" + Com.Session.schid + "&userid=" + Com.Session.usertid + "&schtype=1";//schtype:值为0代表普通老师后台，1代表学校管理员后台
            string thstr = "";//是否有第三方菜单权限
            if (Com.Session.systype == "0")
            {
                systype = Com.Session.systype;
                utitlename = "智慧校园平台";
                indexpage = "jsywebindex.html";
                
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
                //SchMasterstr = dtschinfo.Rows[0]["SchMaster"].ToString();
                if (Com.Session.systype != "0")
                {
                    PlatformName = dtschinfo.Rows[0]["PlatformName"].ToString() + "管理后台<span style=\"font-size:75%;font-weight:normal;\">【" + Com.Session.schid + "】</span>";
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
                PlatformIco = "<img style='width:20px;' src='" + PlatformIco + "' />";
            }
        }
        //绑定系统列表
        public void SysListBind(string thstr)
        {
            StringBuilder sb = new StringBuilder();
            DataTable menuDt = Com.Public.MenuData(thstr);
            if (Com.Public.getKey("issch") == "1")
            {
                string schid = Com.Public.getKey("appschid");
                //获取该学校的配置菜单                
                SchSystem.BLL.SchMenuInfoRouter smrBll = new SchSystem.BLL.SchMenuInfoRouter();
                DataTable dtmenusch = smrBll.GetList("NavUrl,TextName,FuncCode", " SchId='" + schid + "' and SysType=1").Tables[0];
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
                uskin = "#222A2D";
                DataRow dtr = menuDt.NewRow();
                dtr["OrderId"] = "0";
                dtr["MenuId"] = "0";
                dtr["FuncCode"] = "0";
                dtr["PID"] = "0";
                dtr["TextName"] = "首页";
                dtr["Ico"] = "icon-home";
                dtr["NavUrl"] = "jsywebindex.html";
                indexpage = "jsywebindex.html";
                menuDt.Rows.InsertAt(dtr, 0);
            }

            StringBuilder sbMenuWhere = new StringBuilder();
            sbMenuWhere.Append("PID=0");
            DataRow[] drs;
            drs = menuDt.Select(sbMenuWhere.ToString(), "OrderId");

            int i = 0;
            foreach (DataRow dr in drs)
            {
                //获取OA未读数
                string oac = "";
                if (string.IsNullOrEmpty(dr["NavUrl"].ToString()) && menuDt.Select("PID=" + dr["MenuId"].ToString()).Length==0)
                {
                    continue;
                }
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
                            oac = "<b style=\"color: #ff0000\">(" + oac + ")</b>";
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
                    if (i == 0)
                    {
                        sb.Append("<li class=\"active atg\">");
                    }
                    else
                    {
                        sb.Append("<li>");
                    }
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
                    if (i == 0)
                    {
                        sb.Append("<li class=\"active atg\">");
                    }
                    else
                    {
                        sb.Append("<li class=\"atg\">");
                    }

                    sb.Append("<a href=\"" + dr["NavUrl"].ToString().Replace("/sid/sessionid", "/sid/" + Session.SessionID) + "\" onclick=\"strolltop();\" target=\"iframe0\">");
                    sb.Append("<i class=\"" + dr["Ico"].ToString() + "\"></i>");
                    sb.Append("<span class=\"menu-text\">" + dr["TextName"].ToString() + oac + "</span>");
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
                    sb.Append("<a href=\"" + dr["NavUrl"].ToString().Replace("/sid/sessionid", "/sid/" + Session.SessionID) + "\" onclick=\"strolltop();\" target=\"iframe0\">");
                    sb.Append("<i class=\"" + dr["Ico"].ToString() + "\"></i>");
                    sb.Append("<span class=\"menu-text\">" + dr["TextName"].ToString() + "</span>");
                    sb.Append("</a>");
                    sb.Append("</li>");
                }

            }
        }
    }
}