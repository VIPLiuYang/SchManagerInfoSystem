using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin.Web.SchStuCard
{
    public partial class StuCardList : System.Web.UI.Page
    {
        public string areastr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //第一次加载,获取省市区,获取第一个省份下的所有学校
                StringBuilder sbarea = new StringBuilder();
                //获取省份
                sbarea.Append("<span>省:</span><select id=\"aprov\">");
                string sareacode = "";
                sbarea.Append(Com.Public.GetDrpArea("0", "", ref sareacode, true));
                sbarea.Append("</select>");
                //获取城市
                sbarea.Append("<span>市:</span><select id=\"acity\">");
                string sareacitycode = "";
                sbarea.Append(Com.Public.GetDrpArea("1", sareacode, ref sareacitycode, true));
                sbarea.Append("</select>");
                //获取区县
                sbarea.Append("<span>区:</span><select id=\"acoty\">");
                string sareacotycode = "";
                sbarea.Append(Com.Public.GetDrpArea("2", sareacitycode, ref sareacotycode, true));
                sbarea.Append("</select>");
                //获取学校
                sbarea.Append("<span>学校:</span><select id=\"asch\">");
                string sareaschid = "";
                sbarea.Append(Com.Public.GetDrpArea("3", sareacotycode, ref sareaschid, true, "0"));
                sbarea.Append("</select>");
                //获取年级
                sbarea.Append("<span>年级:</span><select id=\"nj\">");
                string sareagradeid = "";
                sbarea.Append(Com.Public.GetDrpArea("4", sareaschid, ref sareagradeid, true));
                sbarea.Append("</select>");
                //获取班级
                sbarea.Append("<span>班级:</span><select id=\"bj\">");
                string sareaclassid = "";
                sbarea.Append(Com.Public.GetDrpArea("5", sareagradeid, ref sareaclassid, true));
                sbarea.Append("</select>");
                areastr = sbarea.ToString();
            }
        }
        [WebMethod]
        public static Com.DataPack.DataRsp<string> page(string PageIndex, string PageSize, string txtname, string txtcard, string clssid, string gradeid, string schid, string cotyid, string cityid, string provid, string iscard)
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
                    SchSystem.BLL.SchStuInfoV userbll = new SchSystem.BLL.SchStuInfoV();

                    //Stat:0废弃,1正常,2被删除,正常界面不显示删除,超管界面可以考虑
                    string strwhere = " 1=1 ";//SysType
                    if (!string.IsNullOrEmpty(txtname))//按学生姓名查询
                    {
                        strwhere += " and StuName like '%" + Com.Public.SqlEncStr(txtname) + "%'";
                    }
                    if (!string.IsNullOrEmpty(txtcard))//按卡地址查
                    {
                        strwhere += " and CardNo like '%" + Com.Public.SqlEncStr(txtcard) + "%'";
                    }
                    if (iscard == "1")//已有卡
                    {
                        strwhere += " and len(CardNo)>7 ";
                    }
                    else if (iscard == "0")//无卡
                    {
                        strwhere += " and len(CardNo)<8 ";
                    }
                    if (!string.IsNullOrEmpty(clssid))
                    {

                        strwhere += " and ClassId= " + Com.Public.SqlEncStr(clssid);

                    }
                    if (!string.IsNullOrEmpty(gradeid))
                    {

                        strwhere += " and GradeId= " + Com.Public.SqlEncStr(gradeid);

                    }
                    if (!string.IsNullOrEmpty(schid))
                    {

                        strwhere += " and SchId= " + Com.Public.SqlEncStr(schid);

                    }
                    if (!string.IsNullOrEmpty(cotyid))
                    {

                        strwhere += " and AreaNo= '" + Com.Public.SqlEncStr(cotyid)+"'";

                    }
                    if (!string.IsNullOrEmpty(cityid))
                    {

                        strwhere += " and left(AreaNo,4)= '" + Com.Public.SqlEncStr(cityid.Substring(0, 4)) + "'";

                    }
                    if (!string.IsNullOrEmpty(provid))
                    {

                        strwhere += " and left(AreaNo,2)= '" + Com.Public.SqlEncStr(provid.Substring(0,2)) + "'";

                    }
                    Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
                    pages.PageIndex = int.Parse(PageIndex);
                    pages.PageSize = int.Parse(PageSize);
                    int rowc = 0;
                    int pc = 0;

                    DataTable dt = userbll.GetListCols("AreaNo,SchName,GradeName,ClassName,StuId,StuName,CardNo", strwhere, "StuName", "ASC", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
                    pages.PageCount = pc;
                    pages.RowCount = rowc;
                    if (dt.Rows.Count > 0)
                    {
                        dt.Columns.Add("SHENG");
                        dt.Columns.Add("SHI");
                        dt.Columns.Add("QU");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string[] areanames = Com.Public.GetArea(dt.Rows[i]["AreaNo"].ToString()).Split('|');
                            dt.Rows[i]["SHENG"] = areanames[0];
                            dt.Rows[i]["SHI"] = areanames[1];
                            dt.Rows[i]["QU"] = areanames[2];
                        }
                        //dt.Columns.Add("Dpts");
                        //获取关联的部门                   
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
        [WebMethod]
        public static Com.DataPack.DataRsp<string> stup(string stuid, string cardno)
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
                    SchSystem.BLL.SchStuInfo stubll = new SchSystem.BLL.SchStuInfo();
                    if (cardno == "")//清掉卡地址
                    {
                        if (stubll.UpdateCard(int.Parse(stuid), cardno))
                        {
                            rsp.code = "success";
                            rsp.msg = "修改成功";
                        }
                        else
                        {
                            rsp.code = "error";
                            rsp.msg = "操作失败";
                        }
                    }
                    else
                    {
                        if (cardno.Length > 7)
                        {
                            if (stubll.ExistsCard(int.Parse(stuid), cardno))
                            {
                                rsp.code = "error";
                                rsp.msg = "该卡已被其他学生占用";
                            }
                            else
                            {
                                if (stubll.UpdateCard(int.Parse(stuid), cardno))
                                {
                                    rsp.code = "success";
                                    rsp.msg = "修改成功";
                                }
                                else
                                {
                                    rsp.code = "error";
                                    rsp.msg = "操作失败";
                                }
                            }
                        }
                        else
                        {
                            rsp.code = "error";
                            rsp.msg = "卡地址非法";
                        }
                    }
                }
                catch (Exception ex)
                {
                    rsp.code = "error";
                    rsp.msg = ex.Message;
                }
            }
            return rsp;
        }
    }
}