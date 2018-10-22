using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin.Web.SchSignin
{
    public partial class SchSigninDialog : System.Web.UI.Page
    {
        public string schid = "0";//学校ID
        public string areastr = "";
        #region 初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            schid = Com.Public.SqlEncStr(Request.Params["schid"].ToString());
            SchSystem.Model.SchInfo usermodel = new SchSystem.Model.SchInfo();
            SchSystem.BLL.SchInfo schbll = new SchSystem.BLL.SchInfo();
            usermodel = schbll.GetSupportModel(int.Parse(schid));
            //获取下拉列表
            StringBuilder sbarea = new StringBuilder();
            //获取省份
            sbarea.Append("省：<select id=\"aprov\">");
            string sareacode = "";
            if (usermodel != null && usermodel.SchId > 0 && usermodel.AreaNo.Length == 6)
            {
                sareacode = usermodel.AreaNo.Substring(0, 2) + "0000";
            }
            sbarea.Append(Com.Public.GetDrpArea("0", "", ref sareacode, false, "0"));
            sbarea.Append("</select> &nbsp; &nbsp;");
            //获取城市
            sbarea.Append("市：<select id=\"acity\">");
            string sareacitycode = "";
            if (usermodel != null && usermodel.SchId > 0 && usermodel.AreaNo.Length == 6)
            {
                sareacitycode = usermodel.AreaNo.Substring(0, 4) + "00";
            }
            sbarea.Append(Com.Public.GetDrpArea("1", sareacode, ref sareacitycode, false, "0"));
            sbarea.Append("</select> &nbsp; &nbsp;");
            //获取区县
            sbarea.Append("区县：<select id=\"acoty\">");
            string sareacotycode = "";
            if (usermodel != null && usermodel.SchId > 0 && usermodel.AreaNo.Length == 6)
            {
                sareacotycode = usermodel.AreaNo;
            }
            sbarea.Append(Com.Public.GetDrpArea("2", sareacitycode, ref sareacotycode, false, "0"));
            sbarea.Append("</select> &nbsp; &nbsp;");
            //获取学校
            sbarea.Append("学校：<select id=\"asch\">");
            string sareaschid = "";
            if (usermodel != null && usermodel.SchId > 0 && usermodel.AreaNo.Length == 6)
            {
                sareaschid = usermodel.SchId.ToString();
            }
            sbarea.Append(Com.Public.GetDrpArea("3", sareacotycode, ref sareaschid, false, "0"));
            sbarea.Append("</select>&nbsp; &nbsp; ");
            areastr = sbarea.ToString();
        }
        #endregion
        #region 查询
        [WebMethod]
        public static Com.DataPack.DataRsp<string> page(string PageIndex, string PageSize, string txtname, string cotycode, string schid)
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
                    SchSystem.BLL.SchThdInfo thdbll = new SchSystem.BLL.SchThdInfo();
                    string strwhere = " ";
                    if (!string.IsNullOrEmpty(schid))
                    {
                        strwhere += " SchId = '" + Com.Public.SqlEncStr(schid) + "'";
                    }
                    Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
                    pages.PageIndex = int.Parse(PageIndex);
                    pages.PageSize = int.Parse(PageSize);
                    int rowc = 0; int pc = 0;
                    DataTable dt = thdbll.GetListCols("*", strwhere, "", "", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
                    pages.PageCount = pc;
                    pages.RowCount = rowc;
                    pages.list = dt;
                    rsp.data = Newtonsoft.Json.JsonConvert.SerializeObject(pages);
                }
                catch (Exception ex)
                {
                    rsp.code = "error";
                    rsp.msg = ex.Message;
                }
            }
            return rsp;
        }
        #endregion
        #region 添加保存和修改保存
        [WebMethod]
        public static Com.DataPack.DataRsp<string> Save(string sendstr, string delAutoId, string schid)
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
                    SchSystem.BLL.SchThdInfo bll_th = new SchSystem.BLL.SchThdInfo();
                    SchSystem.Model.SchThdInfo model_th = new SchSystem.Model.SchThdInfo();
                    sendstr = Com.Public.SqlEncStr(sendstr);
                    if (delAutoId != "")//要删除的AutoId
                    {
                        string[] aid = delAutoId.Split(',');
                        if (aid.Length > 0)
                        {
                            for (int i = 0; i < aid.Length; i++)
                            {
                                bll_th.Delete(Convert.ToInt32(aid[i]));
                            }
                        }
                    }
                    sendstr = sendstr.Replace("u_", "");//UID,UTNAME,SUB,ISMS
                    string[] uss = sendstr.Split('|');
                    if (uss.Length > 0)
                    {
                        foreach (string item in uss)
                        {
                            string[] its = item.Split(',');
                            if (its.Length == 7)
                            {

                                if (its[0] == "0")//its[0]为AutoId 0添加 否则编辑
                                {
                                    model_th.SysName = its[1];
                                    model_th.SysUrl = its[2];
                                    model_th.SysUserNameTips = its[3];
                                    model_th.SysUserPwTips = its[4];
                                    model_th.SysLoginUrl = its[5];
                                    model_th.RecUser = Com.Session.userid;
                                    model_th.RecTime = DateTime.Now;
                                    model_th.SchId = Convert.ToInt32(schid);
                                    if (bll_th.ExistsSysUrl(its[2].ToString(), Convert.ToInt32(schid)))
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        bll_th.Add(model_th);
                                    }
                                }
                                else
                                {
                                    model_th.AutoId = Convert.ToInt32(its[0]);
                                    model_th.SysName = its[1];
                                    model_th.SysUrl = its[2];
                                    model_th.SysUserNameTips = its[3];
                                    model_th.SysUserPwTips = its[4];
                                    model_th.SysLoginUrl = its[5];
                                    model_th.RecTime = System.DateTime.Now;
                                    model_th.RecUser = Com.Session.userid.ToString();
                                    model_th.SchId = Convert.ToInt32(schid);
                                    bll_th.Update(model_th);
                                }
                            }
                        }
                    }
                    rsp.code = "success";
                    rsp.msg = "操作成功!";
                }
                catch (Exception ex)
                {
                    rsp.code = "error";
                    rsp.msg = ex.Message;
                }
            }
            return rsp;
        }
        #endregion
        #region 删除
        [WebMethod]
        public static Com.DataPack.DataRsp<string> thdel(string AutoId)
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
                    SchSystem.BLL.SchThdInfo bll_th = new SchSystem.BLL.SchThdInfo();
                    if (bll_th.Delete(Convert.ToInt32(AutoId)))
                    {
                        rsp.code = "success";
                        rsp.msg = "页面已经过期，请重新登录";
                    }
                    else
                    {
                        rsp.code = "error";
                        rsp.msg = "操作失败";
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

        #endregion

    }
}