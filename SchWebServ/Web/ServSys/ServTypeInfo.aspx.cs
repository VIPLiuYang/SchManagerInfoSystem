using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebServ.Web.ServSys
{
    public partial class ServTypeInfo : System.Web.UI.Page
    {
        public string schid = ""; 
        protected void Page_Load(object sender, EventArgs e)
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
        [WebMethod]
        public static Com.DataPack.DataRsp<string> page(string PageIndex, string PageSize, string txtname, string ustat, string schid)
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
                        SchSystem.BLL.ServType servtypebll = new SchSystem.BLL.ServType();
                        string strwhere = " ";
                        Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
                        pages.PageIndex = int.Parse(PageIndex);
                        pages.PageSize = int.Parse(PageSize);
                        int rowc = 0; int pc = 0;
                        DataTable dt = servtypebll.GetListCols("AutoId,TypeName,TypeCode", strwhere, "AutoId", "DESC", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
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