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
    public partial class SysArtsDialog : System.Web.UI.Page
    {
        public string id = "";
        public string code = "";
        public string name = "";
        public string stat = "";
        public string btname = "添加";
        protected void Page_Load(object sender, EventArgs e)
        {

            //先得到操作类型

            string SysType = Request.Params["systype"].ToString();
            if (SysType == "e")//修改,不能修改用户的类型及学校参数
            {
                btname = "修改";
                id = Request.Params["autoid"].ToString();
                SchSystem.BLL.SysArts bll = new SchSystem.BLL.SysArts();
                SchSystem.Model.SysArts model = bll.GetModel(int.Parse(id));
                if (model != null && model.AutoId > 0)
                {
                    code = model.ArtsCode;
                    name = model.ArtsName;
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

                    SchSystem.BLL.SysArts SysArts_bll = new SchSystem.BLL.SysArts();
                    SchSystem.Model.SysArts SysArts_model = new SchSystem.Model.SysArts();
                    SysArts_model.ArtsName = Com.Public.SqlEncStr(Name).ToString();
                    SysArts_model.Stat = Convert.ToInt32(Com.Public.SqlEncStr(stat));
                    if (AutoId != "")
                    {
                        SysArts_model.AutoId = Convert.ToInt32(AutoId);
                        if (SysArts_bll.Update(SysArts_model))
                        {
                            rsp.code = "success";
                            rsp.msg = "修改成功";
                        }
                    }
                    else
                    {
                        DataTable dt = SysArts_bll.GetList(" top 1 ArtsCode", "  1=1 order by ArtsCode desc").Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            string Code = dt.Rows[0]["ArtsCode"].ToString();
                            SysArts_model.ArtsCode = (int.Parse(Code) + 1).ToString("00");
                        }
                        else
                        {
                            SysArts_model.ArtsCode = "01";
                        }
                        if (SysArts_bll.Add(SysArts_model) != 0)
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