﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebMaster.Web.UserFuncSoure
{
    public partial class UserInfo : System.Web.UI.Page
    {
        public string dptdrp = "";
        public string areastr = "";
        public string uschid = "0";
        public string systype = "0";
        public string schsubs = "";//对应学校的开设科目
        public bool isadd;
        public bool isedit;
        public bool isdel;
        public bool islook;
        protected void Page_Load(object sender, EventArgs e)
        {
            string jsid = Request.Params["sid"].ToString();
            string jstoken = Request.Params["token"].ToString();
            Com.SoureSession.jsid = jsid;
            Com.SoureSession.jstoken = jstoken;
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(jsid, jstoken);
            if (rsp.code == "ERROR_TOKEN")
            {
                Response.Write("登录已失效!");
                Response.End();
            }
            else if (!IsPostBack)
            {

                if (Com.SoureSession.Souresystype == "1" || Com.SoureSession.Souresystype == "2")//超级管理员和学校管理员
                {
                    islook = true;
                    if (Com.SoureSession.Souresystype == "1")
                    {
                        isadd = false;
                        isedit = false;
                        isdel = false;
                    }
                    else
                    {
                        isadd = true;
                        isedit = true;
                        isdel = true;
                    }
                }
                else//普通老师
                {
                    isadd = false;
                    isedit = false;
                    isdel = false;
                    //教师执教类型判断
                    islook = false;
                    
                }

                systype = Com.SoureSession.Souresystype;
                //不是超管获取本学校的
                if (Com.SoureSession.Souresystype != "2")
                {
                    uschid = Com.SoureSession.Soureschid;
                    //获取对应学校的ID
                    dptdrp = Com.Public.GetDrp("dpt", Com.SoureSession.Soureschid, "1", true, "", "");
                    //获取对应学校的科目
                    schsubs = Com.Public.GetDrp("sub", Com.SoureSession.Soureschid, "1", true, "", "");
                }
                else//超管还要加省市区学校下拉,后面需要更改
                {
                    //第一次加载,获取省市区,获取第一个省份下的所有学校
                    StringBuilder sbarea = new StringBuilder();
                    //获取省份
                    sbarea.Append("省:<select id=\"aprov\">");
                    string sareacode = "";
                    sbarea.Append(Com.Public.GetDrpArea("0", "", ref sareacode, false));
                    sbarea.Append("</select>");
                    //获取城市
                    sbarea.Append("市:<select id=\"acity\">");
                    string sareacitycode = "";
                    sbarea.Append(Com.Public.GetDrpArea("1", sareacode, ref sareacitycode, false));
                    sbarea.Append("</select>");
                    //获取区县
                    sbarea.Append("区:<select id=\"acoty\">");
                    string sareacotycode = "";
                    sbarea.Append(Com.Public.GetDrpArea("2", sareacitycode, ref sareacotycode, false));
                    sbarea.Append("</select>");
                    sbarea.Append("学校:<select id=\"asch\">");
                    string sareaschid = "";
                    sbarea.Append(Com.Public.GetDrpArea("3", sareacotycode, ref sareaschid, false));
                    if (sareaschid != "")
                    {
                        uschid = sareaschid;
                    }
                    sbarea.Append("</select>");
                    areastr = sbarea.ToString();
                    dptdrp = Com.Public.GetDrp("dpt", sareaschid, "1", true, "", "");
                    //获取对应学校的科目
                    schsubs = Com.Public.GetDrp("sub", sareaschid, "1", true, "", "");
                }

            }
        }
        [WebMethod]
        public static string page(string PageIndex, string PageSize, string txtname, string dptid, string ustat, string schid, string schsubs, string childrenids)
        {
            string ret = "";
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(Com.SoureSession.jsid, Com.SoureSession.jstoken);
            if (rsp.code == "ERROR_TOKEN")
            {
                ret = "expire";
            }
            else
            {
                SchSystem.BLL.SchUserInfo userbll = new SchSystem.BLL.SchUserInfo();
                if (schid == "")
                    schid = "0";
                //Stat:0废弃,1正常,2被删除,正常界面不显示删除,超管界面可以考虑
                string strwhere = " Stat=1 and SchId='" + Com.Public.SqlEncStr(schid) + "'";//SysType
                if (!string.IsNullOrEmpty(txtname))
                {
                    strwhere += " and UserTname like '%" + Com.Public.SqlEncStr(txtname) + "%'";
                }
                if (Com.SoureSession.Souresystype != "2")
                {
                    strwhere += " and SysType=0 ";
                }
                if (!string.IsNullOrEmpty(ustat))
                {
                    if (ustat != "3")
                    {
                        strwhere += " and AccStat='" + Com.Public.SqlEncStr(ustat) + "' and len(UserName)>0 ";
                    }
                    else
                    {
                        strwhere += " and (len(UserName)=0 or UserName=NULL) ";
                    }
                }
                if (!string.IsNullOrEmpty(schsubs) && schsubs != "0")
                {
                    strwhere += " and SubCode='" + Com.Public.SqlEncStr(schsubs) + "'";
                }
                if (!string.IsNullOrEmpty(dptid) && dptid != "0")
                {
                    if (!string.IsNullOrEmpty(childrenids))
                    {
                        childrenids = childrenids.Substring(0, childrenids.Length - 1);
                        strwhere += " and UserId in (select UserName from SchUserDept where DeptId in (" + Com.Public.SqlEncStr(childrenids) + "))";
                    }
                    else
                    {
                        strwhere += " and UserId in (select UserName from SchUserDept where DeptId=" + Com.Public.SqlEncStr(dptid) + ")";
                    }
                }
                Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
                pages.PageIndex = int.Parse(PageIndex);
                pages.PageSize = int.Parse(PageSize);
                int rowc = 0;
                int pc = 0;

                DataTable dt = userbll.GetListCols("*", strwhere, "UserTname", "ASC", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
                pages.PageCount = pc;
                pages.RowCount = rowc;
                if (dt.Rows.Count > 0)
                {
                    dt.Columns.Add("Dpts");
                    //获取关联的部门

                    //性别
                    dt.Columns.Add("Sexn");
                    //获取关联的角色
                    //dt.Columns.Add("Roles");

                    //获取关联科目
                    dt.Columns.Add("SubName");
                    //获取关联科目
                    dt.Columns.Add("Ustat");

                    SchSystem.BLL.SchUserRoleV rolevbll = new SchSystem.BLL.SchUserRoleV();
                    SchSystem.BLL.SchUserDeptV deptvbll = new SchSystem.BLL.SchUserDeptV();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //dt.Rows[i]["Roles"] = rolevbll.GetNames("UserName='" + dt.Rows[i]["UserName"] + "' and Stat=1 and schid=" + dt.Rows[i]["SchId"]);
                        //dt.Rows[i]["Roles"] = rolevbll.GetNames("UserId='" + dt.Rows[i]["UserId"] + "' and Stat=1 and schid=" + dt.Rows[i]["SchId"]);
                        dt.Rows[i]["Dpts"] = deptvbll.GetNames("UserId='" + dt.Rows[i]["UserId"] + "' and Stat=1 and schid=" + dt.Rows[i]["SchId"]);
                        dt.Rows[i]["Sexn"] = dt.Rows[i]["Sex"].ToString() == "1" ? "男" : "女";
                        //dt.Rows[i]["Ustat"] = dt.Rows[i]["Stat"].ToString() == "1" ? "正常" : "停用";
                        if (dt.Rows[i]["AccStat"].ToString() == "1")
                        {
                            dt.Rows[i]["Ustat"] = "正常";
                        }
                        else if (dt.Rows[i]["AccStat"].ToString() == "0")
                        {
                            dt.Rows[i]["Ustat"] = "停用";
                        }
                        //if (!string.IsNullOrEmpty(dt.Rows[i]["SubCode"].ToString()))
                        //    dt.Rows[i]["SubName"] = Com.Public.GetSubName(dt.Rows[i]["SubCode"].ToString(), dt.Rows[i]["SchId"].ToString());
                        //else
                        //    dt.Rows[i]["SubName"] = "";
                    }
                    pages.list = dt;
                }
                ret = Newtonsoft.Json.JsonConvert.SerializeObject(pages);
            }
            return ret;
        }
        [WebMethod]
        public static string udel(string schid, string id)
        {

            if (!Com.Public.isVa(schid, ""))
            {
                return "无跨界权限";
            }
            string ret = "";
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(Com.SoureSession.jsid, Com.SoureSession.jstoken);
            if (rsp.code == "ERROR_TOKEN")
            {
                ret = "expire";
            }
            else
            {
                try
                {
                    SchSystem.BLL.SchSubLeader sslBll = new SchSystem.BLL.SchSubLeader();
                    bool sslBool = sslBll.ExistsClassSubLeader(schid, id);
                    if (sslBool)
                    {
                        ret = "success01";
                    }
                    else
                    {
                        SchSystem.BLL.SchGradeUsers sguBll = new SchSystem.BLL.SchGradeUsers();
                        bool sguBool = sguBll.ExistsGradeUser(schid, id);
                        if (sguBool)
                        {
                            ret = "success02";
                        }
                        else
                        {
                            SchSystem.BLL.SchClassUser scuBll = new SchSystem.BLL.SchClassUser();
                            bool scuBooll = scuBll.ExistsClassUser(schid, id);
                            if (scuBooll)
                            {
                                ret = "success03";
                            }
                            else
                            {
                                SchSystem.BLL.SchUserInfo bll = new SchSystem.BLL.SchUserInfo();
                                SchSystem.Model.SchUserInfo model = new SchSystem.Model.SchUserInfo();
                                model.UserId = int.Parse(id);
                                model.Stat = 2;
                                model.LastRecTime = DateTime.Now;
                                model.LastRecUser = Com.SoureSession.Soureuserid;
                                if (bll.UpdateStat(model))
                                {
                                    ret = "success";
                                }
                                else
                                {
                                    ret = "操作失败";
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ret = ex.Message;
                }
            }
            return ret;
        }
        [Serializable]
        private class dptsub
        {
            public string dpt;
            public string sub;
        }
        [WebMethod]
        public static string getarea(string typecode, string pcode)
        {
            string ret = "";
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(Com.SoureSession.jsid, Com.SoureSession.jstoken);
            if (rsp.code == "ERROR_TOKEN")
            {
                ret = "expire";
            }
            else
            {
                try
                {
                    string selp = "";
                    if (typecode != "4")
                        ret = Com.Public.GetDrpArea(Com.Public.SqlEncStr(typecode), Com.Public.SqlEncStr(pcode), ref selp, false);
                    else
                    {
                        dptsub ds = new dptsub();
                        ds.dpt = Com.Public.GetDrp("dpt", Com.Public.SqlEncStr(pcode), "1", true, "", "");
                        ds.sub = Com.Public.GetDrp("sub", Com.Public.SqlEncStr(pcode), "1", true, "", "");
                        ret = Newtonsoft.Json.JsonConvert.SerializeObject(ds);
                    }
                }
                catch (Exception ex)
                {
                    ret = "";
                }
            }
            return ret;
        }
    }
}