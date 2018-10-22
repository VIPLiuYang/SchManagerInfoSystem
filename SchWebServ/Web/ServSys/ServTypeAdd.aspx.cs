using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebServ.Web.ServSys
{
    public partial class ServTypeAdd : System.Web.UI.Page
    {
        public string schid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            schid = Com.Session.schid;
        }

        [WebMethod]
        public static Com.DataPack.DataRsp<string> ServTypeAddSave(List<string> arr)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            if (Com.Session.userid == null)
            {
                rsp.code = "expire";
                rsp.msg = "你现在登录已过期，请重新登录！";
            }
            else
            {
                try
                {
                    SchSystem.BLL.ServType servtypebll = new SchSystem.BLL.ServType();
                    SchSystem.Model.ServType servtypemodel = new SchSystem.Model.ServType();
                    foreach (string str in arr)
                    {
                        string[] strarr = str.Split('#');
                        if (strarr[0] == "code") { servtypemodel.TypeCode = strarr[1].Trim(); }
                        if (strarr[0] == "type") { servtypemodel.TypeName = strarr[1].Trim(); }
                    }
                    if (servtypemodel.TypeCode == "" || servtypemodel.TypeName == "")
                    {
                        rsp.code = "error";
                        rsp.msg = "操作失败！不允许输入空格";
                    }
                    else
                    {
                        bool resbool = servtypebll.Exists(servtypemodel.TypeCode);
                        if (!resbool)
                        {
                            int result = servtypebll.Add(servtypemodel);
                            if (result > 0)
                            {
                                rsp.code = "success";
                                rsp.msg = "操作成功";
                            }
                            else
                            {
                                rsp.code = "error";
                                rsp.msg = "操作失败";
                            }
                        }
                        else
                        {
                            rsp.code = "PlatCodeRepeat";
                            rsp.msg = "平台代码不允许重复";
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