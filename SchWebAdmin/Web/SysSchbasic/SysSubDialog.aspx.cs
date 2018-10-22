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
    public partial class SysSubDialog : System.Web.UI.Page
    {

        public string id = "";
        public string code = "";
        public string name = "";
        public string stat = "";
        public string btname = "添加";
        protected void Page_Load(object sender, EventArgs e)
        {

            
            string SysType = Request.Params["systype"].ToString();
            if (SysType == "e")//修改,不能修改用户的类型及学校参数
            {
                btname = "修改";
                id = Request.Params["autoid"].ToString();
                //先得到操作类型
                SchSystem.BLL.SysSub bll = new SchSystem.BLL.SysSub();
                SchSystem.Model.SysSub model = bll.GetModel(int.Parse(id));
                if (model != null && model.AutoId > 0)
                {
                    code = model.SubCode;
                    name = model.SubName;
                    stat = model.Stat.ToString();
                }
                else
                {
                    Response.Write("无该名称!");
                    Response.End();
                }
            }
            else//不在添加及修改之内,则返回
            {

            }


        }
        [WebMethod]
        public static Com.DataPack.DataRsp<string> save(string Name, string stat, string AutoId)
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
                    SchSystem.BLL.SysSub SysSub_bll = new SchSystem.BLL.SysSub();
                    SchSystem.Model.SysSub SysSub_model = new SchSystem.Model.SysSub();
                    SysSub_model.SubName = Com.Public.SqlEncStr(Name).ToString();
                    SysSub_model.Stat = Convert.ToInt32(Com.Public.SqlEncStr(stat));
                    if (AutoId != "")
                    {
                        SysSub_model.AutoId = Convert.ToInt32(AutoId);
                        if (SysSub_bll.Update(SysSub_model))
                        {
                            rsp.code = "success";
                            rsp.msg = "修改成功";
                        }
                    }
                    else
                    {
                        DataTable dt = SysSub_bll.GetList("top 1 SubCode", " 1=1 order by SubCode DESC").Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            string Code = dt.Rows[0]["SubCode"].ToString();
                            int scode = int.Parse(Code) + 1;
                            if (scode < 100)
                            {
                                SysSub_model.SubCode = (int.Parse(Code) + 1).ToString("00");
                            }
                            else
                            {
                                SysSub_model.SubCode = (int.Parse(Code) + 1).ToString("0000");
                            }
                        }
                        else
                        {
                            SysSub_model.SubCode = "01";
                        }
                        if (SysSub_bll.Add(SysSub_model) != 0)
                        {
                            rsp.code = "success";
                            rsp.msg = "添加成功";
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