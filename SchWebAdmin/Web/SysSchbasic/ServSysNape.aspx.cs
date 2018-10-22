using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin.Web.SysSchbasic
{
    public partial class ServSysNape : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static Com.DataPack.DataRsp<string> page(string PageIndex, string PageSize)
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
                    SchSystem.BLL.ServSysNape servsysnape = new SchSystem.BLL.ServSysNape();
                    string strwhere = "Stat<2 ";
                    Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
                    pages.PageIndex = int.Parse(PageIndex);
                    pages.PageSize = int.Parse(PageSize);
                    int rowc = 0;
                    int pc = 0;

                    DataTable dt = servsysnape.GetListCols("AutoId,NapeName,NapeCode,Stat", strwhere, "NapeCode", "ASC", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
                    pages.PageCount = pc;
                    pages.RowCount = rowc;
                    if (dt.Rows.Count > 0)
                    {
                        //dt.Columns.Add("Ustat");
                        //dt.Columns.Add("Ucity");
                        //for (int i = 0; i < dt.Rows.Count; i++)
                        //{
                        //    dt.Rows[i]["Ustat"] = dt.Rows[i]["Stat"].ToString() == "1" ? "正常" : "停用";
                        //    dt.Rows[i]["Ucity"] = dt.Rows[i]["iscity"].ToString() == "1" ? "城区" : "非城区";
                        //}
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
    }
}