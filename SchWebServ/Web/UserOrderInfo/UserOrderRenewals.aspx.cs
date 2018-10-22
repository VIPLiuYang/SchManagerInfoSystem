using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebServ.Web.UserOrderInfo
{
    public partial class UserOrderRenewals : System.Web.UI.Page
    {
        public string uname = "";
        public string province = "";
        public string city = "";
        public string servbustree = "";
        public string dotype = "";
        public string servUserForModel = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            //獲取GET參數
            dotype = Request.Params["dotype"].ToString();
            string AutoId = Request.Params["id"].ToString();
            //獲取登錄者的真實姓名
            uname = Com.Session.uname;
            #region 查詢當前AutoId的數據記錄
            SchSystem.BLL.ServUserFor sufBll = new SchSystem.BLL.ServUserFor();
            SchSystem.Model.ServUserForV sufvModel = new SchSystem.Model.ServUserForV();
            string ServiceId = "";
            if (!string.IsNullOrEmpty(AutoId) && !string.IsNullOrEmpty(dotype))
            {
                sufvModel = sufBll.GetModelV("AutoId,UserName,UTname,FromType,CnName,RecUser,ServiceId,ServStat,ServMonth,FeeM,RecTime,EndTime,EditTime,DoNote,Uareano,BusMonth,FeeCode", int.Parse(AutoId));
                ServiceId = sufvModel.ServiceId;
                servUserForModel = Newtonsoft.Json.JsonConvert.SerializeObject(sufvModel);
            }
            #endregion
        }
        
        #region 數據收集並且存儲數據庫
        [WebMethod]
        public static Com.DataPack.DataRsp<string> UserOrderRenSave(List<string> arr)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            if (Com.Session.userid == null)
            {
                rsp.code = "expire";
                rsp.msg = "你现在登录已过期，请重新登录！";
            }
            else
            {
                SchSystem.BLL.ServUserFor sufBll = new SchSystem.BLL.ServUserFor();
                string autoid = "";
                string servm = "";
                string feem = "";
                string donote = "";
                foreach (string str in arr)
                {
                    string[] strarr = str.Split('#');
                    if (strarr[0] == "autoid") { autoid = strarr[1]; }
                    else if (strarr[0] == "ordertimelen") { servm = strarr[1]; }
                    else if (strarr[0] == "payamountren") { feem = strarr[1]; }
                    else if (strarr[0] == "note") { donote = strarr[1]; }
                }
                SchSystem.Model.ServUserFor sufModel = sufBll.GetModel(int.Parse(autoid));
                try
                {
                    int result = sufBll.ProcAdd(sufModel.UserName, Com.Session.userid, "客服续订", sufModel.ServiceId, int.Parse(servm), int.Parse(feem), donote);
                    //bool result = sufBll.UpdateRenewals(sufModel);
                    if (result>0)
                    {
                        rsp.code = "success";
                        rsp.msg = "操作成功";
                    }
                    else
                    {
                        rsp.code = "error";
                        rsp.msg = "操作失败";
                    }
                }
                catch (Exception ex)
                {
                    rsp.code = "excepError";
                    rsp.msg = ex.Message;
                }
                    
            }
            return rsp;
        }
        #endregion
    }
}