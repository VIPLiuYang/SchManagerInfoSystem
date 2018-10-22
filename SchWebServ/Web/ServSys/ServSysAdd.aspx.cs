using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebServ.Web.ServSys
{
    public partial class ServSysAdd : System.Web.UI.Page
    {
        public string schid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            schid = Com.Session.schid;
        }
        [WebMethod]
        public static Com.DataPack.DataRsp<string> ServSysAddSave(List<string> arr)
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
                    SchSystem.BLL.ServSys ssBll = new SchSystem.BLL.ServSys();
                    SchSystem.Model.ServSys ssModel = new SchSystem.Model.ServSys();
                    foreach (string str in arr)
                    {
                        string[] strarr = str.Split('#');
                        //if (strarr[0] == "schid") { schid = int.Parse(strarr[1]); }
                        if (strarr[0] == "code") { ssModel.SysCode = strarr[1].Trim(); }
                        if (strarr[0] == "type") { ssModel.SysName = strarr[1].Trim(); }
                        if (strarr[0] == "url") { ssModel.SysUrl = strarr[1].Trim(); }

                    }
                    if (ssModel.SysCode == "" || ssModel.SysName == "" || ssModel.SysUrl == "")
                    {
                        rsp.code = "error";
                        rsp.msg = "操作失败！不允许输入空格";
                    }
                    else
                    {
                        if (getStringLength(ssModel.SysUrl) > 300)
                        {
                            rsp.code = "error";
                            rsp.msg = "平台域名不允许超过30个字符";
                        }
                        else
                        {
                            bool resbool = ssBll.Exists(ssModel.SysCode);
                            if (!resbool)
                            {
                                int result = ssBll.Add(ssModel);
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
                }
                catch (Exception ex)
                {
                    rsp.code = "ExcepError";
                    rsp.msg = ex.Message;
                }
            }
            return rsp;

        }

        /// <summary>
        /// 获取中英文混排字符串的实际长度(字节数)
        /// </summary>
        /// <param name="str">要获取长度的字符串</param>
        /// <returns>字符串的实际长度值（字节数）</returns>
        public static int getStringLength(string str)
        {
            if (str.Equals(string.Empty))
                return 0;
            int strlen = 0;
            ASCIIEncoding strData = new ASCIIEncoding();
            //将字符串转换为ASCII编码的字节数字
            byte[] strBytes = strData.GetBytes(str);
            for (int i = 0; i <= strBytes.Length - 1; i++)
            {
                if (strBytes[i] == 63)  //中文都将编码为ASCII编码63,即"?"号
                    strlen++;
                strlen++;
            }
            return strlen;
        }

    }
}