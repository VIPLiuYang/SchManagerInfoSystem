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
    public partial class SysMaterDialog : System.Web.UI.Page
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
                SchSystem.BLL.SysMater bll = new SchSystem.BLL.SysMater();
                SchSystem.Model.SysMater model = bll.GetModel(int.Parse(id));
                if (model != null && model.AutoId > 0)
                {
                    code = model.MaterCode;
                    name = model.MaterName;
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
                    SchSystem.BLL.SysMater SysMater_bll = new SchSystem.BLL.SysMater();
                    SchSystem.Model.SysMater SysMater_model = new SchSystem.Model.SysMater();
                    SysMater_model.MaterName = Com.Public.SqlEncStr(Name).ToString();
                    SysMater_model.Stat = Convert.ToInt32(Com.Public.SqlEncStr(stat));
                    if (AutoId != "")
                    {
                        SysMater_model.AutoId = Convert.ToInt32(AutoId);
                        if (SysMater_bll.Update(SysMater_model))
                        {
                            rsp.code = "success";
                            rsp.msg = "修改成功";
                        }
                    }
                    else
                    {
                        DataTable dt = SysMater_bll.GetList("top 1 MaterCode", "  1=1 order by MaterCode DESC").Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            string Code = dt.Rows[0]["MaterCode"].ToString();
                            SysMater_model.MaterCode = (int.Parse(Code) + 1).ToString("00");
                        }
                        else
                        {
                            SysMater_model.MaterCode = "01";
                        }
                        if (SysMater_bll.Add(SysMater_model) != 0)
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