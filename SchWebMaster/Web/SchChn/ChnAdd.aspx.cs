using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebMaster.Web.SchChn
{
    public partial class ChnAdd : System.Web.UI.Page
    {
        string SysType = "";
        string ChnId = "";
        public string umodelstr = "1";//学校model
        public string chndrp = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            //先得到操作类型
            SchSystem.BLL.WebSchChn schchn_bll = new SchSystem.BLL.WebSchChn();
            SchSystem.Model.WebSchChn schchn_model = new SchSystem.Model.WebSchChn();
            SysType = Com.Public.SqlEncStr(Request.Params["dotype"].ToString());


            if (SysType == "e")//修改,不能修改用户的类型及学校参数
            {
                //获取修改的对应用户的

                ChnId = Com.Public.SqlEncStr(Request.Params["id"].ToString());
                schchn_model = schchn_bll.GetModel(int.Parse(ChnId));
                if (schchn_model != null && schchn_model.ChnId > 0)
                {
                    umodelstr = Newtonsoft.Json.JsonConvert.SerializeObject(schchn_model);
                }
                else
                {
                    Response.Write("无该名称!");
                    Response.End();
                }
                chndrp = Com.Public.GetDrp("chn", Com.Session.schid, "1", false, ChnId, schchn_model.Pid.ToString());
            }
            else//不在添加及修改之内,则返回
            {
                chndrp = Com.Public.GetDrp("chn", Com.Session.schid, "1", false, "", "");
            }
        }
        [WebMethod]
        public static Com.DataPack.DataRsp<string> save(string Chnid, string ChnName, string ChnCode, string Note, string Stat, string Pid)
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
                    SchSystem.BLL.WebSchChn schchn_bll = new SchSystem.BLL.WebSchChn();
                    SchSystem.Model.WebSchChn schchn_model = new SchSystem.Model.WebSchChn();
                    schchn_model.ChnName = Com.Public.SqlEncStr(ChnName).ToString();
                    schchn_model.Stat = Convert.ToInt32(Com.Public.SqlEncStr(Stat));
                    schchn_model.ChnCode = Convert.ToInt32(Com.Public.SqlEncStr(ChnCode));
                    schchn_model.Note = Com.Public.SqlEncStr(Note).ToString();
                    schchn_model.Pid = Convert.ToInt32(Pid);
                    schchn_model.SchId = Convert.ToInt32(Com.Session.schid.ToString());
                    if (Chnid != "")
                    {
                        schchn_model.ChnId = Convert.ToInt32(Chnid);
                        //判断栏目代码不允许重复
                        if (!schchn_bll.ExistsChnCode(schchn_model.ChnId, schchn_model.ChnCode, schchn_model.SchId))
                        {
                            if (schchn_bll.CUpdate(schchn_model))
                            {
                                rsp.code = "success";
                                rsp.msg = "修改成功";
                            }
                        }
                        else
                        {
                            rsp.code = "error";
                            rsp.msg = "代码重复";
                        }

                    }
                    else
                    {
                        schchn_model.RecName = Com.Session.uname.ToString();
                        schchn_model.RecTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString());
                        schchn_model.RecUser = Com.Session.userid.ToString();
                        //判断栏目代码不允许重复
                        if (!schchn_bll.ExistsChnCode(schchn_model.ChnId, schchn_model.ChnCode, schchn_model.SchId))
                        {
                            if (schchn_bll.Add(schchn_model) != 0)
                            {
                                rsp.code = "success";
                                rsp.msg = "添加成功";
                            }
                        }
                        else
                        {
                            rsp.code = "error";
                            rsp.msg = "代码重复";
                        }
                       
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