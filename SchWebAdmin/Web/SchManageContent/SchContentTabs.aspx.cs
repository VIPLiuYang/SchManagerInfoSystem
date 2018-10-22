﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin.Web.SchManageContent
{
    public partial class SchContentTabs : System.Web.UI.Page
    {
        public string schid = "0";//学校ID
        public string areastr = "";
        public string OAnoticestr = "";//通知公告
        public string OAapplystr = "";//审批文件
        public string sessionid = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            schid = Com.Public.SqlEncStr(Request.Params["schid"].ToString());
            SchSystem.Model.SchInfo usermodel = new SchSystem.Model.SchInfo();
            SchSystem.BLL.SchInfo schbll = new SchSystem.BLL.SchInfo();
            usermodel = schbll.GetSupportModel(int.Parse(schid));
            //获取下拉列表
            StringBuilder sbarea = new StringBuilder();
            //获取省份
            sbarea.Append("省：<select id=\"aprov\">");
            string sareacode = "";
            if (usermodel != null && usermodel.SchId > 0 && usermodel.AreaNo.Length == 6)
            {
                sareacode = usermodel.AreaNo.Substring(0, 2) + "0000";
            }
            sbarea.Append(Com.Public.GetDrpArea("0", "", ref sareacode, false, "0"));
            sbarea.Append("</select> &nbsp; &nbsp;");
            //获取城市
            sbarea.Append("市：<select id=\"acity\">");
            string sareacitycode = "";
            if (usermodel != null && usermodel.SchId > 0 && usermodel.AreaNo.Length == 6)
            {
                sareacitycode = usermodel.AreaNo.Substring(0, 4) + "00";
            }
            sbarea.Append(Com.Public.GetDrpArea("1", sareacode, ref sareacitycode, false, "0"));
            sbarea.Append("</select> &nbsp; &nbsp;");
            //获取区县
            sbarea.Append("区县：<select id=\"acoty\">");
            string sareacotycode = "";
            if (usermodel != null && usermodel.SchId > 0 && usermodel.AreaNo.Length == 6)
            {
                sareacotycode = usermodel.AreaNo;
            }
            sbarea.Append(Com.Public.GetDrpArea("2", sareacitycode, ref sareacotycode, false, "0"));
            sbarea.Append("</select> &nbsp; &nbsp;");
            //获取学校
            sbarea.Append("学校：<select id=\"asch\">");
            string sareaschid = "";
            if (usermodel != null && usermodel.SchId > 0 && usermodel.AreaNo.Length == 6)
            {
                sareaschid = usermodel.SchId.ToString();
            }
            sbarea.Append(Com.Public.GetDrpArea("3", sareacotycode, ref sareaschid, false, "0"));
            sbarea.Append("</select>&nbsp; &nbsp; ");
            areastr = sbarea.ToString();
            sessionid = Session.SessionID;
            //OAnoticestr = string.Format(Com.Public.getKey("OAnotice"), Session.SessionID, schid);//通知公告
            OAnoticestr = Com.Public.getKey("OAnotice");
            //OAapplystr = string.Format(Com.Public.getKey("OAapply"), Session.SessionID, schid);//审批文件
            OAapplystr = Com.Public.getKey("OAapply");

        }        

        [WebMethod]
        public static string getsearch(string schid)
        {
            string ret = "";
            string OAnoticestr = Com.Public.getKey("OAnotice");//通知公告
            string OAapplystr = Com.Public.getKey("OAapply");//审批文件
            ret = "{'OAnoticestr':'" + OAnoticestr + "','OAapplystr':'" + OAapplystr + "'}";
            return ret;
        }
    }
}