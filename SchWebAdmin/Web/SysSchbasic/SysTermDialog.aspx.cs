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
    public partial class SysTermDialog : System.Web.UI.Page
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
                SchSystem.BLL.SysTerm bll = new SchSystem.BLL.SysTerm();
                SchSystem.Model.SysTerm model = bll.GetModel(int.Parse(id));
                if (model != null && model.AutoId > 0)
                {
                    code = model.TermCode;
                    name = model.TermName;
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
        public static Com.DataPack.DataRsp<string> save(string Name, string AutoId)
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
                    SchSystem.BLL.SysTerm SysTerm_bll = new SchSystem.BLL.SysTerm();
                    SchSystem.Model.SysTerm SysTerm_model = new SchSystem.Model.SysTerm();
                    SysTerm_model.TermName = Com.Public.SqlEncStr(Name).ToString();
                    if (AutoId != "")
                    {
                        SysTerm_model.AutoId = Convert.ToInt32(AutoId);
                        if (SysTerm_bll.Update(SysTerm_model))
                        {
                            rsp.code = "success";
                            rsp.msg = "修改成功";
                        }
                    }
                    else
                    {
                        DataTable dt = SysTerm_bll.GetList("top 1 TermCode", " 1=1 order by TermCode DESC").Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            string Code = dt.Rows[0]["TermCode"].ToString();
                            SysTerm_model.TermCode = (int.Parse(Code) + 1).ToString("00");
                        }
                        else
                        {
                            SysTerm_model.TermCode = "01";
                        }
                        if (SysTerm_bll.Add(SysTerm_model) != 0)
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