


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

namespace SchWebAdmin
{
    /// <summary>
    /// Login1 的摘要说明,用户为学校内唯一,不为全系统唯一
    /// </summary>
    public class Login1 : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

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
                    string pwdEncode = context.Request.Form["PassWord"];
                    string txtCode = context.Request.Form["TxtCode"];//IsCookies
                    //string IsCookies = context.Request.Form["IsCookies"];                    
                    string txtcode = rsa.Decrypt(txtCode);
                    //string iscookies = rsa.Decrypt(IsCookies);
                    //bool iscook =false;
                    //if (iscookies == "1") iscook = true;                  
                    if (recode(txtcode, context))
                    {
                        string uname = Com.Public.SqlEncStr(rsa.Decrypt(usernameEncode));
                        if (!string.IsNullOrEmpty(uname))
                        {
                            string pwd = Com.Public.SqlEncStr(rsa.Decrypt(pwdEncode));
                            Com.Session.userpw = pwd;
                            Com.Session.usertp = "0";
                            string pwdmd5 = Com.Public.StrToMD5(pwd);
                            //查询所登录的用户名和密码是否一致。如果一致，则返回true；否则，返回false。
                            SchSystem.BLL.SchUserInfo userbll = new SchSystem.BLL.SchUserInfo();
                            bool result = userbll.Exists("UserName='" + uname + "' and PassWord='" + pwdmd5 + "' and Stat=1 and AccStat=1 and SysType=2 and schid=" + Com.Public.getKey("adminschid"));
                            if (result == true)
                            {
                                //用户登录处理函数
                                str = Com.Public.UserLoginDo(uname, false, Com.Public.getKey("appschid"));
                                if (str == "1" && pwd == "123456")
                                {
                                    str = "2";
                                }
                            }
                            else
                            {
                                str = "3";//账号或密码错误,或者被停用，请联系管理员
                            }
                        }
                        else
                        {
                            str = "4";//用户名不能为空
                        }
                    }
                    else
                    {
                        str = "5";//验证码错误
                    }
                }
                catch (Exception ex)
                {
                    str = ex.Message;
                }
                context.Response.Write(str);
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
            string chkcode = context.Request.Cookies["validateCookie"].Values["ChkCode"].ToString();//获得系统生成的验证码
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
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}