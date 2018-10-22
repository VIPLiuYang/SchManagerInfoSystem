using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebServ.Web.UserOrderInfo
{
    public partial class UserOrderInfo : System.Web.UI.Page
    {
        public string province = "";
        public string city = "";
        public string ServBusJson = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            #region 获取套餐名称和代码
            SchSystem.BLL.ServBus sbBll = new SchSystem.BLL.ServBus();
            DataTable dtServBus = sbBll.GetList("ServiceId,CnName", "").Tables[0];
            ServBusJson = Newtonsoft.Json.JsonConvert.SerializeObject(dtServBus);
            #endregion
            #region 獲取省市區
            //获取省份
            StringBuilder areaProvince = new StringBuilder();
            string sareacode = "";
            areaProvince.Append(Com.Public.GetDrpArea("0", "", ref sareacode, true, "1"));
            province = areaProvince.ToString();
            //获取城市
            StringBuilder areaCity = new StringBuilder();
            string sareacitycode = "";
            areaCity.Append(Com.Public.GetDrpArea("1", sareacode, ref sareacitycode, true, "1"));
            city = areaCity.ToString();
            #endregion
        }
        [WebMethod]
        public static Com.DataPack.DataRsp<string> page(List<string> arr)
        {
            //变量声明区域
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            if (Com.Session.userid == null)
            {
                rsp.code = "expire";
                rsp.msg = "你现在登录已过期，请重新登录！";
            }
            else
            {
                string PageIndex = ""; string PageSize = "";
                string txtAccount = "", txtUserTname = "", txtProvince = "", txtCity = "", txtUserType = "", txtAdditional = "", txtPackage = "", txtStat = "";
                string txtSource = "", txtStartTime01 = "", txtStartTime02 = "", txtEndTime01 = "", txtEndTime02 = "";
                //分解前台传递过来的参数并给变量赋值
                foreach (string str in arr)
                {
                    string[] strarr = str.Split('#');
                    if (strarr[0] == "PageIndex") { PageIndex = strarr[1]; }
                    else if (strarr[0] == "PageSize") { PageSize = strarr[1]; }
                    else if (strarr[0] == "txtAccount") { txtAccount = strarr[1]; }
                    else if (strarr[0] == "txtUserTname") { txtUserTname = strarr[1]; }
                    else if (strarr[0] == "txtProvince") { txtProvince = strarr[1]; }
                    else if (strarr[0] == "txtCity") { txtCity = strarr[1]; }
                    else if (strarr[0] == "txtUserType") { txtUserType = strarr[1]; }
                    else if (strarr[0] == "txtAdditional") { txtAdditional = strarr[1]; }
                    else if (strarr[0] == "txtPackage") { txtPackage = strarr[1]; }
                    else if (strarr[0] == "txtStat") { txtStat = strarr[1]; }
                    else if (strarr[0] == "txtStartTime01") { txtStartTime01 = strarr[1]; }
                    else if (strarr[0] == "txtStartTime02") { txtStartTime02 = strarr[1]; }
                    else if (strarr[0] == "txtEndTime01") { txtEndTime01 = strarr[1]; }
                    else if (strarr[0] == "txtEndTime02") { txtEndTime02 = strarr[1]; }
                    else if (strarr[0] == "txtSource") { txtSource = strarr[1]; }

                }
                //实例化对象
                SchSystem.BLL.ServUserFor sufBll = new SchSystem.BLL.ServUserFor();
                //声明SQL拼接变量
                StringBuilder strwhere = new StringBuilder();
                //条件SQL拼接
                strwhere.Append("1=1");
                if (!string.IsNullOrEmpty(txtAccount))
                {
                    strwhere.Append(" and UserName='" + txtAccount + "'");
                }
                if (!string.IsNullOrEmpty(txtUserTname))
                {
                    strwhere.Append(" and UTname='" + txtUserTname + "'");
                }
                if (!string.IsNullOrEmpty(txtProvince))
                {
                    strwhere.Append(" and left(Uareano,2)='" + Com.Public.SqlEncStr(txtProvince.Substring(0, 2)) + "'");
                }
                if (!string.IsNullOrEmpty(txtCity))
                {
                    strwhere.Append(" and left(Uareano,4)='" + Com.Public.SqlEncStr(txtCity.Substring(0, 4)) + "'");
                }
                if (!string.IsNullOrEmpty(txtStat))
                {
                    strwhere.Append(" and ServStat='" + txtStat + "'");
                }
                if (!string.IsNullOrEmpty(txtStartTime01) && !string.IsNullOrEmpty(txtStartTime02))
                {
                    strwhere.Append(" and RecTime between '" + DateTime.Parse(txtStartTime01) + "' and '" + DateTime.Parse(txtStartTime02) + "'");
                }
                if (!string.IsNullOrEmpty(txtSource))
                {
                    strwhere.Append(" and FromType='" + txtSource + "'");
                }
                if (!string.IsNullOrEmpty(txtEndTime01) && !string.IsNullOrEmpty(txtEndTime02))
                {
                    strwhere.Append(" and EndTime between '" + DateTime.Parse(txtEndTime01) + "' and '" + DateTime.Parse(txtEndTime02) + "'");
                }
                if (!string.IsNullOrEmpty(txtPackage))
                {
                    strwhere.Append(" and ServiceId='" + txtPackage + "'");
                }

                Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
                pages.PageIndex = int.Parse(PageIndex);
                pages.PageSize = int.Parse(PageSize);
                int rowc = 0;
                int pc = 0;
                try
                {
                    string dbcols = "AutoId,UserName,UTname,Uareano,FromType,RecUser,CnName,FeeM,ServMonth,RecTime,EndTime,EditTime,ServStat,DoNote";
                    DataTable dt = sufBll.GetListColsV(dbcols, strwhere.ToString(), "AutoId", "DESC", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        dt.Columns.Add("Province");
                        dt.Columns.Add("City");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["Uareano"].ToString() != "")
                            {
                                dt.Rows[i]["Province"] = Com.Public.GetSSQ("0", dt.Rows[i]["Uareano"].ToString());
                                dt.Rows[i]["City"] = Com.Public.GetSSQ("1", dt.Rows[i]["Uareano"].ToString());
                            }
                            else
                            {
                                dt.Rows[i]["Province"] = "";
                                dt.Rows[i]["City"] = "";
                            }
                        }
                    }
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
        //[Serializable]
        //private class dptsub
        //{
        //    public string dpt;
        //    public string sub;
        //}
        //[WebMethod]
        //public static string getarea(string typecode, string pcode)
        //{
        //    string ret = "";
        //    if (Com.Session.userid == null)
        //    {
        //        ret = "expire";
        //    }
        //    else
        //    {
        //        try
        //        {
        //            string selp = "";
        //            if (typecode != "4")
        //                ret = Com.Public.GetDrpArea(Com.Public.SqlEncStr(typecode), Com.Public.SqlEncStr(pcode), ref selp, true);
        //            else
        //            {
        //                dptsub ds = new dptsub();
        //                ds.dpt = Com.Public.GetDrp("dpt", Com.Public.SqlEncStr(pcode), "1", true, "", "");
        //                ds.sub = Com.Public.GetDrp("sub", Com.Public.SqlEncStr(pcode), "1", true, "", "");
        //                ret = Newtonsoft.Json.JsonConvert.SerializeObject(ds);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            ret = "";
        //        }
        //    }
        //    return ret;
        //}
    }
}