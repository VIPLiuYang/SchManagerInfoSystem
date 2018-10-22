using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin.Web.SchXXTServ
{
    public partial class SchXXTServEdit : System.Web.UI.Page
    {
        public string dotype = "";//操作类型,修改或者是添加,a添加,e修改
        public string schid = "0";//需要建立的学校ID
        public string areastr = "";
        public string grades = "";//系统年级
        public string subs = "";//系统科目
        public string sonsys = "";//子系统选择
        public string umodelstr = "1";//学校model
        protected void Page_Load(object sender, EventArgs e)
        {

            //先得到操作类型
            SchSystem.BLL.SchInfo schbll = new SchSystem.BLL.SchInfo();
            SchSystem.Model.SchInfo usermodel = new SchSystem.Model.SchInfo();
            dotype = Request.Params["dotype"].ToString();
            if (dotype == "e")//修改,不能修改用户的类型及学校参数
            {
                schid = Request.Params["schid"].ToString();
                if (string.IsNullOrEmpty(schid))
                {
                    Response.Write("无对应修改的记录!");
                    Response.End();
                }
                //获取修改的对应用户的
                usermodel = schbll.GetSupportModel(int.Parse(schid));
                if (usermodel != null && usermodel.SchId > 0)
                {
                    if (usermodel.HomeSchEndTime == null)
                    {
                        usermodel.HomeSchEndTime = DateTime.Parse("2100-1-1");
                    }
                    umodelstr = Newtonsoft.Json.JsonConvert.SerializeObject(usermodel);
                }
                else
                {
                    Response.Write("无该学校!");
                    Response.End();
                }
            }
            else//不在添加及修改之内,则返回
            {
                Response.Write("没有可供确认的操作类型!");
                Response.End();
            }

        }

        [WebMethod]
        public static Com.DataPack.DataRsp<string> schsubsave(string arr)
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
                    string[] datas = arr.Split('|');
                    if (datas[1] == "1" && DateTime.Parse(datas[2]) < DateTime.Now.AddDays(-1))//开启状态,则判断时间是否准确
                    {
                        rsp.code = "error";
                        rsp.msg = "时间选择不正确";
                    }
                    else
                    {
                        SchSystem.BLL.SchInfo schbll = new SchSystem.BLL.SchInfo();
                        if (datas[1] == "1")
                        {
                            schbll.UpdateSchXXTOpen(int.Parse(datas[0]), DateTime.Parse(datas[2]), "支撑操作开启");
                        }
                        else
                        {
                            schbll.UpdateSchXXTClose(int.Parse(datas[0]), "支撑操作关闭");
                        }
                        rsp.code = "success";
                        rsp.msg = "操作成功";
                    }
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