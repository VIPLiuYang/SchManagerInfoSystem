using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin.Web.SchResourceSharSet
{
    public partial class SchSourceSharEdit : System.Web.UI.Page
    {
        public string dotype = "";//操作类型,修改或者是添加,a添加,e修改
        public string schid = "0";//需要建立的学校ID
        public string areastr = "";
        public string grades = "";//系统年级
        public string subs = "";//系统科目
        public string sonsys = "";//子系统选择
        public string umodelstr = "1";//学校model
        public string umodelsarstr = "1";//学校资源模块
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
                    umodelstr = Newtonsoft.Json.JsonConvert.SerializeObject(usermodel);

                    //
                    SchSystem.BLL.SchAppSoure sasBll = new SchSystem.BLL.SchAppSoure();
                    DataTable dtsar = sasBll.GetList("AppCode,AppName,'false' checked", "Stat=1").Tables[0];

                    if (dtsar.Rows.Count > 0)
                    {
                        dtsar.Columns.Add("UsharStat");
                        for (int j = 0; j < dtsar.Rows.Count; j++)
                        {
                            SchSystem.BLL.SchAppRoleSoure sarsBll = new SchSystem.BLL.SchAppRoleSoure();
                            DataTable dtsars = sarsBll.GetList("SchId='" + schid + "'").Tables[0];
                            if (dtsars.Rows.Count > 0)
                            {
                                string[] sarsarr = dtsars.Rows[0]["AppCode"].ToString().Split('|');
                                for (int i = 0; i < sarsarr.Length; i++)
                                {
                                    int len = sarsarr[i].Split(',').Length;
                                    if (len > 1)
                                    {
                                        string issharstr = sarsarr[i].Split(',')[0];
                                        string isshar = sarsarr[i].Split(',')[1];
                                        //string sss = dtsar.Rows[j]["AppCode"].ToString();
                                        if (isshar == "1" && issharstr == dtsar.Rows[j]["AppCode"].ToString())
                                        {
                                            dtsar.Rows[j]["UsharStat"] = isshar;
                                            dtsar.Rows[j]["checked"] = "true";
                                        }
                                        else if (dtsar.Rows[j]["AppCode"].ToString() == issharstr)
                                        {
                                            dtsar.Rows[j]["checked"] = "true";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    umodelsarstr = Newtonsoft.Json.JsonConvert.SerializeObject(dtsar);
                    //

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
                string[] datas = arr.Split('#');
                if (datas[0] == "")
                {
                    rsp.code = "tips";
                    rsp.msg = "没有相关学校数据";
                }
                else
                {
                    try
                    {
                        SchSystem.BLL.SchAppRoleSoure srsBll = new SchSystem.BLL.SchAppRoleSoure();
                        SchSystem.Model.SchAppRoleSoure srsModel = new SchSystem.Model.SchAppRoleSoure();
                        srsModel.SchId = int.Parse(datas[0]);
                        srsModel.AppCode = datas[1];
                        if (srsBll.SchAppExists(int.Parse(datas[0])))
                        {
                            srsModel.LastRecTime = DateTime.Now;
                            srsModel.LastRecUser = Com.Session.uname;
                            srsBll.Update(srsModel);
                        }
                        else
                        {
                            srsModel.RecTime = DateTime.Now;
                            srsModel.RecUser = Com.Session.uname;
                            srsBll.Add(srsModel);
                        }
                        rsp.code = "success";
                        rsp.msg = "修改成功!";

                    }
                    catch (Exception ex)
                    {
                        rsp.code = "error";
                        rsp.msg = ex.Message;
                    }
                }
            }
            return rsp;

        }
    }
}