using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebServ.Web.UserOrderInfo
{
    public partial class UserOrderSearch : System.Web.UI.Page
    {
        public string schid = "0";
        #region 初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Com.Session.userid == null)
                {
                    Response.Redirect("../../Login.aspx");
                    Response.End();
                }
                else
                {
                    schid = Com.Session.schid;
                }

            }
        }
        #endregion
        #region 查询
        [WebMethod]
        public static string page(string PageIndex, string PageSize, string UserName)
        {
            string ret = "";
            if (Com.Session.userid == null)
            {
                ret = "expire";
            }
            else
            {
                SchSystem.BLL.ServUserForDetail servuserfordetailbll = new SchSystem.BLL.ServUserForDetail();
                string strwhere = "1=1 ";
                if (!string.IsNullOrEmpty(UserName))
                {
                    strwhere += " and UserName = '" + Com.Public.SqlEncStr(UserName) + "'";
                }

                Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
                pages.PageIndex = int.Parse(PageIndex);
                pages.PageSize = int.Parse(PageSize);
                int rowc = 0;
                int pc = 0;
                string dbcols = "AutoId,UserName,FromType,RecUser,ServiceId,ServMonth,FeeM,RecTime,EndTime,EditTime,DoNote,CnName,FuncStr,BusType,Usex,UTname,Uareano,Stat";
                DataTable dt = servuserfordetailbll.GetListCols(dbcols, strwhere, "AutoId", "ASC", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
                pages.PageCount = pc;
                pages.RowCount = rowc;
                if (dt.Rows.Count > 0)
                {
                    dt.Columns.Add("SHENG");
                    dt.Columns.Add("SHI");
                    dt.Columns.Add("TServMonth");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["SHENG"] = Com.Public.GetSSQ("0", dt.Rows[i]["Uareano"].ToString());
                        dt.Rows[i]["SHI"] = Com.Public.GetSSQ("1", dt.Rows[i]["Uareano"].ToString());
                        dt.Rows[i]["TServMonth"] = Com.Public.InttoMonth(Convert.ToInt32(dt.Rows[i]["ServMonth"]));

                    }
                    pages.list = dt;
                }
                ret = Newtonsoft.Json.JsonConvert.SerializeObject(pages);
            }
            return ret;
        }
        #endregion
    }
}