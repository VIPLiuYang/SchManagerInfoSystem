using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin.Web.SchSearch
{
    public partial class SchUserinfo : System.Web.UI.Page
    {
        public string dptdrp = "";
        public string areastr = "";
        public string uschid = "0";
        public string systype = "0";
        public string schsubs = "";//对应学校的开设科目
        public string schid = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Params["schid"] != null && Request.Params["schid"].ToString() != "")
            {
                schid = Com.Public.SqlEncStr(Request.Params["schid"].ToString());

            }


            dptdrp = Com.Public.GetDrp("dpt", schid, "1", true, "", "");
            //获取对应学校的科目
            schsubs = Com.Public.GetDrp("sub", schid, "1", true, "", "");


        }

        #region 获取教师账号及权限信息
        [WebMethod]
        public static Com.DataPack.DataRsp<string> pageuser(string PageIndex, string PageSize, string SchId, string txtname, string dptid, string ustat, string schsubs, string childrenids)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            if (Com.Session.userid == null)
            {
                rsp.code = "expire";
                rsp.msg = "页面已经过期，请重新登录";
            }
            else
            {
                try
                {
                    SchSystem.BLL.SchUserInfo userbll = new SchSystem.BLL.SchUserInfo();
                    if (SchId == "")
                        SchId = "0";
                    //Stat:0废弃,1正常,2被删除,正常界面不显示删除,超管界面可以考虑
                    string strwhere = " Stat=1 and SchId='" + Com.Public.SqlEncStr(SchId) + "'";//SysType
                    if (!string.IsNullOrEmpty(txtname))
                    {
                        strwhere += " and UserTname like '%" + Com.Public.SqlEncStr(txtname) + "%'";
                    }
                    if (Com.Session.systype != "2")
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
                        //获取关联的部门 
                        dt.Columns.Add("Dpts");
                        //性别
                        dt.Columns.Add("Sexn");
                        //获取关联的角色
                        dt.Columns.Add("Roles");
                        //获取关联科目
                        dt.Columns.Add("SubName");
                        //获取关联科目
                        dt.Columns.Add("Ustat");
                        SchSystem.BLL.SchUserRoleV rolevbll = new SchSystem.BLL.SchUserRoleV();
                        SchSystem.BLL.SchUserDeptV deptvbll = new SchSystem.BLL.SchUserDeptV();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dt.Rows[i]["Roles"] = rolevbll.GetNames("UserId='" + dt.Rows[i]["UserId"] + "' and Stat=1 and schid=" + dt.Rows[i]["SchId"]);
                            dt.Rows[i]["Dpts"] = deptvbll.GetNames("UserId='" + dt.Rows[i]["UserId"] + "' and Stat=1 and schid=" + dt.Rows[i]["SchId"]);
                            dt.Rows[i]["Sexn"] = dt.Rows[i]["Sex"].ToString() == "1" ? "男" : "女";
                            if (dt.Rows[i]["AccStat"].ToString() == "1")
                            {
                                dt.Rows[i]["Ustat"] = "正常";
                            }
                            else if (dt.Rows[i]["AccStat"].ToString() == "0")
                            {
                                dt.Rows[i]["Ustat"] = "停用";
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[i]["SubCode"].ToString()))
                                dt.Rows[i]["SubName"] = Com.Public.GetSubName(dt.Rows[i]["SubCode"].ToString());
                            else
                                dt.Rows[i]["SubName"] = "";
                        }
                        pages.list = dt;
                    }
                    rsp.data = Newtonsoft.Json.JsonConvert.SerializeObject(pages);
                }
                catch (Exception ex)
                {
                    rsp.code = "error";
                    rsp.msg = ex.Message;
                }
            }

            return rsp;
        }
        #endregion
    }
}