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
    public partial class SysPerDialog : System.Web.UI.Page
    {
        public string id = "";
        public string code = "";
        public string name = "";
        public string stat = "";
        public string grademodelstr = "1";//年级信息
        public string btname = "添加";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string SysType = Com.Public.SqlEncStr(Request.Params["systype"].ToString());//先得到操作类型
            if (SysType == "e")//修改
            {
                btname = "修改";
                id = Request.Params["id"].ToString();
                SchSystem.BLL.SysPer bll = new SchSystem.BLL.SysPer();
                SchSystem.Model.SysPer model = bll.GetModel(int.Parse(id));
                if (model != null)
                {
                    code = model.PerCode;
                    name = model.PerName;
                    stat = model.Stat.ToString();
                    SchSystem.BLL.SysGrade bllgrade = new SchSystem.BLL.SysGrade();
                    string srtWhere = "GradeType=" + Convert.ToInt32(model.PerCode);
                    DataTable dt = bllgrade.GetList("AutoId as id,GradeName as name,'true' checked,GradeType", srtWhere).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        grademodelstr = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
                    }                    
                }
                else
                {

                    Response.Write("无该名称!");
                    Response.End();
                }
            }
            else
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
                    SchSystem.BLL.SysPer SysPer_bll = new SchSystem.BLL.SysPer();
                    SchSystem.Model.SysPer SysPer_model = new SchSystem.Model.SysPer();
                    SysPer_model.PerName = Com.Public.SqlEncStr(Name).ToString();
                    SysPer_model.Stat = Convert.ToInt32(Com.Public.SqlEncStr(stat));
                    if (AutoId != "")
                    {
                        SysPer_model.AutoId = int.Parse(AutoId);
                        if (SysPer_bll.Update(SysPer_model))
                        {
                            rsp.code = "success";
                            rsp.msg = "修改成功";
                        }
                    }
                    else
                    {
                        DataTable dt = SysPer_bll.GetList(" top 1 PerCode", "  1=1 order by convert(int,PerCode) desc").Tables[0];
                        
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            string Code = dt.Rows[0]["PerCode"].ToString();
                            SysPer_model.PerCode = (int.Parse(Code) + 1).ToString("0");
                        }
                        else
                        {
                            SysPer_model.PerCode = "1";
                        }
                        if (SysPer_bll.Add(SysPer_model) != 0)
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