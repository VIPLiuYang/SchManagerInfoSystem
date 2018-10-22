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
    public partial class SysGrade : System.Web.UI.Page
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
                    SchSystem.BLL.SysGrade sysarts = new SchSystem.BLL.SysGrade();
                    string strwhere = "1=1 ";
                    Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
                    pages.PageIndex = int.Parse(PageIndex);
                    pages.PageSize = int.Parse(PageSize);
                    int rowc = 0;
                    int pc = 0;
                    DataTable dt = sysarts.GetListCols("AutoId,GradeName,GradeCode,GradeType,'' PerName", strwhere, "GradeType,GradeCode", "ASC", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
                    pages.PageCount = pc;
                    pages.RowCount = rowc;
                    if (dt.Rows.Count > 0)
                    {
                        SchSystem.BLL.SysPer bllper = new SchSystem.BLL.SysPer();
                        DataTable dtper = bllper.GetList("PerName,PerCode", " Stat=1 ").Tables[0];
                        if (dtper.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dt.Rows[i]["GradeCode"] = dt.Rows[i]["GradeCode"].ToString() + "(" + Com.Public.NumberToChinese(int.Parse(dt.Rows[i]["GradeCode"].ToString().Substring(dt.Rows[i]["GradeCode"].ToString().Length-3))) + "年级)";
                                DataRow[] dtr = dtper.Select("PerCode='" + dt.Rows[i]["GradeType"].ToString() + "'");
                                if (dtr.Length > 0)
                                {
                                    dt.Rows[i]["PerName"] = dtr[0]["PerName"].ToString();
                                }
                            }
                        }
                        //转换所属学段
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