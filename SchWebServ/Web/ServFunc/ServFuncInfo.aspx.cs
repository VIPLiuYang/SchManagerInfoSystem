using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebServ.Web.ServFunc
{
    public partial class ServFuncInfo : System.Web.UI.Page
    {
        //public string areastr = "";
        public string schid = "";
        public string businessType = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //业务类型
                SchSystem.BLL.ServType stBll = new SchSystem.BLL.ServType();
                DataTable stdt = stBll.GetList("TypeName,TypeCode", "").Tables[0];
                businessType = Newtonsoft.Json.JsonConvert.SerializeObject(stdt);
            }
        }

        [WebMethod]
        public static Com.DataPack.DataRsp<string> page(string PageIndex, string PageSize, string txtname, string BusinessType, string txtcode, string txtrange, string txtbusplat)
        {

            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
                if (Com.Session.userid == null)
                {
                    rsp.code = "expire";
                    rsp.msg = "你现在登录已过期，请重新登录！";
                }
                else
                {
                    SchSystem.BLL.ServFunc sfcBll = new SchSystem.BLL.ServFunc();

                    string strwhere = "1=1";
                    if (!string.IsNullOrEmpty(txtname))
                    {
                        strwhere += " and FuncName='" + txtname + "'";
                    }
                    if (!string.IsNullOrEmpty(txtcode))
                    {
                        strwhere += " and FuncCode='" + txtcode + "'";
                    }
                    if (!string.IsNullOrEmpty(txtrange))
                    {
                        strwhere += "and FuncRange='" + txtrange + "'";
                    }
                    if (!string.IsNullOrEmpty(txtbusplat))
                    {
                        strwhere += " and FuncSyss like '%'+(select SysCode from ServSys where SysName='" + txtbusplat + "')+'%'";
                    }
                    if (!string.IsNullOrEmpty(BusinessType))
                    {
                        strwhere += " and ServType.TypeCode='" + BusinessType + "'";
                    }
                    Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
                    pages.PageIndex = int.Parse(PageIndex);
                    pages.PageSize = int.Parse(PageSize);
                    int rowc = 0;
                    int pc = 0;
                    try
                    {
                        string dbcols = "ServFunc.AutoId,FuncName,FuncCode,ServFunc.TypeCode,FuncRange,FuncSet,FuncNote,FuncSyss,FuncDes,TypeName";
                        DataTable dt = sfcBll.GetListCols(dbcols, strwhere, "ServFunc.AutoId", "DESC", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
                        pages.PageCount = pc;
                        pages.RowCount = rowc;
                        if (dt.Rows.Count > 0)
                        {
                            dt.Columns.Add("FuncSyssName");
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                //所属业务平台
                                string FuncSyss = dt.Rows[i]["FuncSyss"].ToString();
                                if (FuncSyss != "")
                                {
                                    string[] FuncSyssArr = FuncSyss.Split(',');
                                    string FuncSysstr = "";
                                    foreach (string s in FuncSyssArr)
                                    {
                                        FuncSysstr += "'" + s + "',";
                                    }
                                    FuncSyss = FuncSysstr.Substring(0, FuncSysstr.Length - 1);
                                }
                                dt.Rows[i]["FuncSyssName"] = sfcBll.GetFuncNames("SysCode in (" + FuncSyss + ")");
                                //附加设置信息
                                string autoid = dt.Rows[i]["AutoId"].ToString();
                                SchSystem.BLL.ServFuncExt sfeBll = new SchSystem.BLL.ServFuncExt();
                                DataTable dtsfext = sfeBll.GetList("*", "FuncId='" + autoid + "'").Tables[0];
                                StringBuilder sbstr = new StringBuilder();
                                //string perstr = "", substr = "", gradestr = "", utname = "", matstr = "";
                                if (dtsfext.Rows.Count > 0)
                                {
                                    for (int j = 0; j < dtsfext.Rows.Count; j++)
                                    {
                                        if (dtsfext.Rows[j]["NapeCode"].ToString() == "prd")
                                        {
                                            SchSystem.BLL.SysPer spBll = new SchSystem.BLL.SysPer();
                                            DataTable dtres = spBll.GetList("PerName", "PerCode in(" + dtsfext.Rows[j]["NapeCodes"].ToString() + ") order by convert(int,PerCode)").Tables[0];
                                            sbstr.Append("学段：");
                                            for (int z = 0; z < dtres.Rows.Count; z++)
                                            {
                                                sbstr.Append(dtres.Rows[z]["PerName"].ToString() + "，");
                                            }
                                            sbstr.ToString().Substring(0, sbstr.ToString().Length - 1);
                                        }
                                        if (dtsfext.Rows[j]["NapeCode"].ToString() == "grd")
                                        {
                                            SchSystem.BLL.SysGrade sgBll = new SchSystem.BLL.SysGrade();
                                            DataTable dtres = sgBll.GetList("GradeName", "GradeCode in(" + dtsfext.Rows[j]["NapeCodes"].ToString() + ")").Tables[0];
                                            sbstr.Append("年级：");
                                            for (int z = 0; z < dtres.Rows.Count; z++)
                                            {
                                                sbstr.Append(dtres.Rows[z]["GradeName"].ToString() + "，");
                                            }
                                            sbstr.ToString().Substring(0, sbstr.ToString().Length - 1);
                                        }
                                        if (dtsfext.Rows[j]["NapeCode"].ToString() == "sub")
                                        {
                                            SchSystem.BLL.SysSub ssBll = new SchSystem.BLL.SysSub();
                                            DataTable dtres = ssBll.GetList("SubName", "SubCode in(" + dtsfext.Rows[j]["NapeCodes"].ToString() + ")").Tables[0];
                                            sbstr.Append("科目：");
                                            for (int z = 0; z < dtres.Rows.Count; z++)
                                            {
                                                sbstr.Append(dtres.Rows[z]["SubName"].ToString() + "，");
                                            }
                                            sbstr.ToString().Substring(0, sbstr.ToString().Length - 1);
                                        }
                                        if (dtsfext.Rows[j]["NapeCode"].ToString() == "utp")
                                        {
                                            SchSystem.BLL.SysUType sutBll = new SchSystem.BLL.SysUType();
                                            DataTable dtres = sutBll.GetList("UTypeName", "UTypeCode in(" + dtsfext.Rows[j]["NapeCodes"].ToString() + ")").Tables[0];
                                            sbstr.Append("角色：");
                                            for (int z = 0; z < dtres.Rows.Count; z++)
                                            {
                                                sbstr.Append(dtres.Rows[z]["UTypeName"].ToString() + "，");
                                            }
                                            sbstr.ToString().Substring(0, sbstr.ToString().Length - 1);
                                        }
                                        if (dtsfext.Rows[j]["NapeCode"].ToString() == "mat")
                                        {
                                            SchSystem.BLL.SysMater smBll = new SchSystem.BLL.SysMater();
                                            DataTable dtres = smBll.GetList("MaterName", "MaterCode in(" + dtsfext.Rows[j]["NapeCodes"].ToString() + ")").Tables[0];
                                            sbstr.Append("教版：");
                                            for (int z = 0; z < dtres.Rows.Count; z++)
                                            {
                                                sbstr.Append(dtres.Rows[z]["MaterName"].ToString() + "，");
                                            }
                                            sbstr.ToString().Substring(0, sbstr.ToString().Length - 1);
                                        }
                                    }
                                    dt.Rows[i]["FuncSet"] = sbstr.ToString();
                                }
                            }

                            pages.list = dt;
                        }
                    }
                    catch (Exception ex)
                    {
                        rsp.code = "excepError";
                        rsp.msg = ex.Message;
                    }
                    rsp.RspData = Newtonsoft.Json.JsonConvert.SerializeObject(pages);
                }
                return rsp; 
        }
        
    }
}