using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWeb.SchoolBaxicInfo.School
{
    public partial class SchInfo : System.Web.UI.Page
    {
        public string areastr = "";
        public string schid = "0";
        public string cotycode = "";
        public bool isadd;
        public bool isedit;
        public bool isdel;
        public bool islook;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                islook = true;
                if (Com.Session.appeditstat == "0" && Com.Session.systype == "1")
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
                //不是超管获取本学校的
                if (Com.Session.systype != "2")
                {
                    schid = Com.Session.schid;
                    Response.Redirect("SchEdit.aspx?dotype=e&schid=" + schid);
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
                    cotycode = sareacotycode;
                    sbarea.Append("</select>");
                    areastr = sbarea.ToString();
                }

            }
        }
        
        [WebMethod]
        public static string page(string PageIndex, string PageSize, string txtname, string ustat, string cotycode, string schid)
        {
            string ret = "";
            if (Com.Session.userid == null)
            {
                ret = "expire";
            }
            else
            {
                SchSystem.BLL.SchInfo userbll = new SchSystem.BLL.SchInfo();
                if (schid == "")
                    schid = "0";
                //Stat:0废弃,1正常,2被删除,正常界面不显示删除,超管界面可以考虑
                string strwhere = "Stat<2 ";
                if (!string.IsNullOrEmpty(cotycode))
                {
                    strwhere += " and AreaNo = '" + Com.Public.SqlEncStr(cotycode) + "'";
                }
                if (schid != "0")
                {
                    strwhere += " and SchId = '" + Com.Public.SqlEncStr(schid) + "'";
                }
                if (!string.IsNullOrEmpty(txtname))
                {
                    strwhere += " and SchName like '%" + Com.Public.SqlEncStr(txtname) + "%'";
                }
                if (!string.IsNullOrEmpty(ustat))
                {
                    strwhere += " and Stat=" + Com.Public.SqlEncStr(ustat);
                }
                Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
                pages.PageIndex = int.Parse(PageIndex);
                pages.PageSize = int.Parse(PageSize);
                int rowc = 0;
                int pc = 0;

                DataTable dt = userbll.GetListCols("*", strwhere, "SchName", "ASC", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
                pages.PageCount = pc;
                pages.RowCount = rowc;
                if (dt.Rows.Count > 0)
                {
                    dt.Columns.Add("Ustat");
                    dt.Columns.Add("Ucity");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["Ustat"] = dt.Rows[i]["Stat"].ToString() == "1" ? "正常" : "停用";
                        dt.Rows[i]["Ucity"] = dt.Rows[i]["iscity"].ToString() == "1" ? "城区" : "非城区";
                    }
                    pages.list = dt;
                }
                //Newtonsoft.Json.JsonConvert();
                string ddd = Newtonsoft.Json.JsonConvert.SerializeObject(pages);
                ret = Newtonsoft.Json.JsonConvert.SerializeObject(pages);
            }
            return ret;
        }
        [WebMethod]
        public static string udel(string id)
        {
            string ret = "";
            if (Com.Session.userid == null)
            {
                ret = "expire";
            }
            else
            {
                try
                {
                    if (!Com.Public.isVa(id, ""))
                    {
                        return ret = "无跨界权限";
                    }
                    if (id == Com.Public.getKey("adminschid"))
                    {
                        ret = "此为系统学校,不允许操作";
                    }
                    else
                    {
                        SchSystem.BLL.SchInfo bll = new SchSystem.BLL.SchInfo();
                        SchSystem.Model.SchInfo model = new SchSystem.Model.SchInfo();
                        model.SchId = int.Parse(id);
                        model.Stat = 2;
                        model.LastRecTime = DateTime.Now;
                        model.LastRecUser = Com.Session.userid;
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
                catch (Exception ex)
                {
                    ret = ex.Message;
                }
            }
            return ret;
        }
    }
}