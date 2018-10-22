using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebMaster.Web.SchNews
{
    public partial class NewsAdd : System.Web.UI.Page
    {
        public static string SchChnJsonStr = "";
        public static string SchGradeJsonStr = "";
        public static string SchClassJsonStr = "";
        public static string SchId = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            SchId = Com.Session.schid;
            //栏目初始化
            SchSystem.BLL.WebSchChn SchChn = new SchSystem.BLL.WebSchChn();
            DataTable dtSchChn =  SchChn.GetList("ChnName,ChnCode", "Stat=1").Tables[0];
            SchChnJsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(dtSchChn);
            //年级
            SchSystem.BLL.SchGradeInfo schgrade = new SchSystem.BLL.SchGradeInfo();
            DataTable dtSchGrade = schgrade.GetList("GradeName,GradeCode", "IsFinish=0 and SchId=" + SchId).Tables[0];
            string GradeCode = dtSchGrade.Rows[0]["GradeCode"].ToString();
            SchGradeJsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(dtSchGrade);
            //班级
            SchSystem.BLL.SchClassInfo schclass = new SchSystem.BLL.SchClassInfo();
            DataTable dtSchClass = schclass.GetList("ClassName,ClassId", "IsFinish=0 and GradeCode='" + GradeCode + "' and SchId='" + SchId + "'").Tables[0];
            SchClassJsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(dtSchClass);

        }

        [WebMethod]
        public static Com.DataPack.DataRsp<string> newsaddsave(List<string> arr)
        {
            SchSystem.Model.WebSchNews shcnewsmodel = new SchSystem.Model.WebSchNews();
            SchSystem.BLL.WebSchNews schnewsbll = new SchSystem.BLL.WebSchNews();
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
                    foreach (string str in arr)
                    {
                        string[] strarr = str.Split('#');
                        if (strarr[0] == "title") { shcnewsmodel.Topic = strarr[1]; }
                        if (strarr[0] == "column") { shcnewsmodel.ChnId = int.Parse(strarr[1]); }
                        if (strarr[0] == "range") { shcnewsmodel.Lv = int.Parse(strarr[1]); }
                        if (strarr[0] == "grdclass") { shcnewsmodel.LvId = int.Parse(strarr[1]); }
                        if (strarr[0] == "content") { shcnewsmodel.Content = strarr[1]; }
                        //if (strarr[0] == "annex") { shcnewsmodel.Topic = strarr[1]; }
                    }
                    
                    shcnewsmodel.SchId = SchId;
                    shcnewsmodel.RecTime = DateTime.Now;
                    shcnewsmodel.RecIP = GetLocalIP().data;
                    shcnewsmodel.Stat = 1;
                    shcnewsmodel.Clicked = 1;
                    shcnewsmodel.IsQuo = 1;
                    shcnewsmodel.IsReply = 1;
                    shcnewsmodel.IsTop = 1;
                    shcnewsmodel.IsEnc = 1;
                    shcnewsmodel.ChkTime = DateTime.Now;
                    //int res = schnewsbll.Add(shcnewsmodel);
                    //if (res > 0)
                    //{
                    //    rsp.code = "success";
                    //    rsp.msg = "操作成功";
                    //}
                }
                catch (Exception ex)
                {
                    rsp.code = "ExcepError";
                    rsp.msg = ex.Message;
                }
            }
            return rsp;
        }

        [WebMethod]
        public static Com.DataPack.DataRsp<string> getclass(string gradecode)
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
                    SchSystem.BLL.SchClassInfo schclass = new SchSystem.BLL.SchClassInfo();
                    DataTable dtSchClass = schclass.GetList("ClassName,ClassId", "IsFinish=0 and GradeCode='" + gradecode + "' and SchId='" + SchId + "'").Tables[0];
                    string optionSchClass = "";
                    for (int i = 0; i < dtSchClass.Rows.Count; i++)
                    {
                        optionSchClass += "<option value=\"" + dtSchClass.Rows[i]["ClassId"].ToString() + "\">" + dtSchClass.Rows[i]["ClassName"].ToString() + "</option>";
                    }
                    rsp.data = optionSchClass.ToString();
                }
                catch (Exception ex)
                {
                    rsp.code = "ExcepError";
                    rsp.msg = ex.Message;
                }
            }
            return rsp;
        }
        /// <summary>
        /// 获取本地IP
        /// </summary>
        /// <returns></returns>
        public static Com.DataPack.DataRsp<string> GetLocalIP()
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
                    string HostName = Dns.GetHostName(); //得到主机名
                    IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                    for (int i = 0; i < IpEntry.AddressList.Length; i++)
                    {
                        //从IP地址列表中筛选出IPv4类型的IP地址
                        //AddressFamily.InterNetwork表示此IP为IPv4,
                        //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                        if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                        {
                            rsp.data = IpEntry.AddressList[i].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    rsp.code = "ExcepError";
                    rsp.msg = ex.Message;
                }
            }
            return rsp;
        }

    }
}