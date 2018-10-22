using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebServ
{
    public partial class UserApi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataRsp rsp = new DataRsp();
            if (Com.Session.userid != null)
            {
                rsp.RspData = Com.Public.Encrypt("schid:" + Com.Session.schid + "|uid:" + Com.Session.userid + "|upw:" + Com.Session.userpw + "|utp:" + Com.Session.usertp + "|usystp:" + Com.Session.systype + "|utid:" + Com.Session.usertid + "|ulgt:" + Com.Session.ulogintime, Com.Public.getKey("ApiSecretKey"));
                //string dddd = Com.Public.Decrypt(rsp.RspData.ToString());
                //根据用户名获取用户密码并解密
            }
            else
            {
                rsp.RspCode = "0010";
                rsp.RspTxt = "验证信息不存在需要重新登录";
            }
            Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(rsp));
            Response.End();
        }
        [Serializable]
        public class DataRsp
        {
            /// <summary>
            /// 返回状态码
            /// </summary>
            public string RspCode = "0000";//返回代码
            /// <summary>
            /// 返回说明
            /// </summary>
            public string RspTxt = "正常";//返回代码提示
            /// <summary>
            /// 返回数据包
            /// </summary>
            public Object RspData;//数据包
        }
    }
}