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
    public partial class GetUserInfo : System.Web.UI.Page
    {
        public string servuserinfo = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        [WebMethod]
        public static Com.DataPack.DataRsp<string> page(string PageIndex, string PageSize, string ustat, string txttel)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            if (Com.Session.userid == null)
            {
                rsp.code = "expire";
                rsp.msg = "你现在登录已过期，请重新登录！";
            }
            else
            {
                try
                {
                    SchSystem.BLL.ServUser suBll = new SchSystem.BLL.ServUser();
                    string strwhere = "Stat=1 ";
                    if (!string.IsNullOrEmpty(txttel))
                    {
                        strwhere += " and UserName = '" + Com.Public.SqlEncStr(txttel) + "'";
                    }
                    Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
                    pages.PageIndex = int.Parse(PageIndex);
                    pages.PageSize = int.Parse(PageSize);
                    int rowc = 0;
                    int pc = 0;
                    string dbcols = "UserName,UTname,Uareano";
                    DataTable dt = suBll.GetListCols(dbcols, strwhere, "AutoId", "ASC", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
                    pages.PageCount = pc;
                    pages.RowCount = rowc;
                    if (dt.Rows.Count > 0)
                    {
                        pages.list = dt;
                    }

                    rsp.RspData = Newtonsoft.Json.JsonConvert.SerializeObject(pages);
                }
                catch (Exception ex)
                {
                    rsp.code = "excepError";
                    rsp.msg = ex.Message;
                }
            }
            return rsp;
        }
    }
}