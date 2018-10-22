using Common;
using Model;
using SchManagerInfoSystem.Common;
using SchSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace SchWebMaster
{
    /// <summary>
    /// Login1 的摘要说明,用户为学校内唯一,不为全系统唯一
    /// </summary>
    public class Login1 : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //判断跨域白名单,这里暂简单做
            string ddd = context.Request.Headers.Get("Origin");
            if (ddd != null)
            {
                context.Response.AddHeader("Access-Control-Allow-Origin", ddd);
            }
            context.Response.AddHeader("Access-Control-Allow-Credentials", "true");
            DataRsp rsp = new DataRsp();
            string Action = context.Request.Form["Action"];
            if (Action == "null")
            {
                context.Response.Write(PublicProperty.PublicKey);
            }
            else if (Action == "Login")//登录
            {
                string str = "";
                //解密 RSA
                RSACryptoService rsa = new RSACryptoService(PublicProperty.PrivateKey, PublicProperty.PublicKey);
                try
                {
                    string usernameEncode = context.Request.Form["UserName"];
                    string uname = Com.Public.SqlEncStr(rsa.Decrypt(usernameEncode));
                    //获取到学校ID,判断该学校是否正常
                    //bool isschcor = false;
                    SchSystem.BLL.SchUserInfo userbll = new SchSystem.BLL.SchUserInfo();
                    SchSystem.BLL.SchInfo schbll = new SchSystem.BLL.SchInfo();
                    //if (Com.Public.getKey("issch") == "1")//单学校登录
                    //{
                    //    string appschid = Com.Public.getKey("appschid");
                    //    //判断该学校是否正常                        
                    //    isschcor = schbll.Exists(int.Parse(appschid), 1);                        
                    //}
                    //else//统一登录
                    //{
                    //    SchSystem.Model.SchUserInfo usermodel = userbll.GetModelByUname(uname);
                    //    if (usermodel != null && usermodel.UserId > 0)
                    //    {
                    //        isschcor = schbll.Exists(usermodel.SchId, 1);
                    //    }
                    //    else
                    //    { 
                        
                    //    }
                    //}
                    //if (!isschcor)
                    //{
                    //    rsp.RspCode = "6";
                    //    rsp.RspTxt = "该学校已经被关闭或者账号不存在,请联系系统管理人员!";
                    //}
                    //else
                    //{
                        string pwdEncode = context.Request.Form["PassWord"];
                        string txtCode = context.Request.Form["TxtCode"];//IsCookies
                        //string IsCookies = context.Request.Form["IsCookies"];                    
                        string txtcode = rsa.Decrypt(txtCode);
                        //string iscookies = rsa.Decrypt(IsCookies);
                        //bool iscook =false;
                        //if (iscookies == "1") iscook = true;                  
                        if (recode(txtcode, context))
                        {
                            if (!string.IsNullOrEmpty(uname))
                            {
                                string pwd = Com.Public.SqlEncStr(rsa.Decrypt(pwdEncode));
                                Com.Session.userpw = pwd;
                                Com.Session.usertp = "0";
                                string pwdmd5 = Com.Public.StrToMD5(pwd);
                                //查询所登录的用户名和密码是否一致。如果一致，则返回true；否则，返回false。
                                bool result = false;
                                if (Com.Public.getKey("issch") == "1")//分学校部署,需要在本学校中
                                {
                                    result = userbll.Exists("UserName='" + uname + "' and PassWord='" + pwdmd5 + "' and Stat=1 and AccStat=1 and SysType=1 and schid=" + Com.Public.getKey("appschid"));
                                }
                                else
                                {
                                    result = userbll.Exists("UserName='" + uname + "' and PassWord='" + pwdmd5 + "' and Stat=1 and AccStat=1 and SysType=1 and schid not in (select schid from SchInfo where IsAlone=1)");
                                }
                                if (result == true)
                                {

                                    //用户登录处理函数
                                    str = Com.Public.UserLoginDo(uname, false, Com.Public.getKey("appschid"));

                                    if (str == "1" && pwd == "123456")
                                    {
                                        rsp.RspCode = "2";
                                        rsp.RspTxt = context.Request.Url.Authority + context.Request.ApplicationPath + "/userpwdedit.aspx";
                                        //str = "2";//默认初始化密码，需要先修改密码
                                    }
                                    else
                                    {
                                        rsp.RspCode = "1";
                                        rsp.RspTxt = context.Request.Url.Authority + context.Request.ApplicationPath + "/index.aspx";
                                    }
                                }
                                else
                                {
                                    rsp.RspCode = "3";
                                    rsp.RspTxt = "账号或密码错误,请联系系统管理员!";
                                    //str = "3";//账号或密码错误,或者被停用，请联系管理员
                                }
                            }
                            else
                            {
                                rsp.RspCode = "4";
                                rsp.RspTxt = "用户名不能为空";
                                //str = "4";//用户名不能为空
                            }
                        }
                        else
                        {
                            rsp.RspCode = "5";
                            rsp.RspTxt = "验证码错误";
                            //str = "5";//验证码错误
                        }
                    }                 
                    
                //}
                catch (Exception ex)
                {
                    rsp.RspCode = "9";
                    rsp.RspTxt = ex.Message;
                }
                context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(rsp));
            }
            else if (Action == "out")//退出
            {
                /*PublicMethod.Clear();*/

                context.Session.Clear();
                context.Session.Abandon();
                context.Response.Clear();
                //清除cookies
                Com.CookieHelper.ClearCookie("uname");
                context.Response.Write("out");
            }
        }
        protected bool recode(string txtcode, HttpContext context)
        {
            string text = txtcode;//获得用户输入的验证码
            string chkcode =Com.Session.usercode;//获得系统生成的验证码
            bool bok = false;
            if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(chkcode))
            {
                if (!chkcode.Equals(chkcode.ToUpper()))//如果系统生成的不为大写则转换成大写形式
                    chkcode.ToUpper();
                if (text.ToUpper().Trim().Equals(chkcode.Trim())) //将输入的验证码转换成大写并与系统生成的比较
                    bok = true;
            }
            else if (string.IsNullOrEmpty(text))
            {

            }
            return bok;
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
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}