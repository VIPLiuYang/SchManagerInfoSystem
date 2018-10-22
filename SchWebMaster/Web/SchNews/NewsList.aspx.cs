using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebMaster.Web.SchNews
{
    public partial class NewsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static Com.DataPack.DataRsp<string> page(string PageIndex, string PageSize, string txtname, string ustat, string txtcode)
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
                    //Stat:0废弃,1正常,2被删除,正常界面不显示删除,超管界面可以考虑
                    string strwhere = "Stat<2 and SchId='" + Com.Session.schid + "' ";

                    if (!string.IsNullOrEmpty(txtname))
                    {
                        strwhere += " and Topic like '%" + Com.Public.SqlEncStr(txtname) + "%'";
                    }
                    if (!string.IsNullOrEmpty(ustat))
                    {
                        strwhere += " and Stat='" + Com.Public.SqlEncStr(ustat) + "'";
                    }
                    Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
                    pages.PageIndex = int.Parse(PageIndex);
                    pages.PageSize = int.Parse(PageSize);
                    int rowc = 0;
                    int pc = 0;
                    SchSystem.BLL.WebSchNews userbll = new SchSystem.BLL.WebSchNews();
                    string dbcols = "ChnId,Topic,RecTime";
                    DataTable dt = userbll.GetListCols(dbcols, strwhere, "RecTime", "DESC", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
                    pages.PageCount = pc;
                    pages.RowCount = rowc;
                    if (dt.Rows.Count > 0)
                    {
                        pages.list = dt;
                    }
                    rsp.data = Newtonsoft.Json.JsonConvert.SerializeObject(pages).Replace("\n\r", "");
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
        public static Com.DataPack.DataRsp<string> udel(string id)
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
                    //看是否已有新闻关联,需要补

                    /*
                    SchSystem.BLL.WebSchChn bll = new SchSystem.BLL.WebSchChn();
                    SchSystem.Model.WebSchChn model = new SchSystem.Model.WebSchChn();
                    model.ChnId = int.Parse(id);
                    model.Stat = 2;
                    if (bll.UpdateStat(model))
                    {
                        rsp.code = "success";
                        rsp.msg = "操作成功";
                    }
                    else
                    {
                        rsp.code = "error";
                        rsp.msg = "操作失败";
                    }
                    */

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