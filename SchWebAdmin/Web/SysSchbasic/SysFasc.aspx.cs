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
    public partial class SysFasc : System.Web.UI.Page
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

                    SchSystem.BLL.SysFasc sysfasc = new SchSystem.BLL.SysFasc();
                    string strwhere = "Stat<2 ";

                    Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
                    pages.PageIndex = int.Parse(PageIndex);
                    pages.PageSize = int.Parse(PageSize);
                    int rowc = 0;
                    int pc = 0;

                    DataTable dt = sysfasc.GetListCols("AutoId,FascName,FascCode,Stat", strwhere, "FascCode", "ASC", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
                    pages.PageCount = pc;
                    pages.RowCount = rowc;
                    if (dt.Rows.Count > 0)
                    {
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