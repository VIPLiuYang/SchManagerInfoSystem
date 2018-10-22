using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchWebServ
{
    public class ValidateLogin : IHttpModule
    {
        public void Dispose()
        {

        }
        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += new EventHandler(context_PreRequestHandlerExecute);
        }
        void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication ha = (HttpApplication)sender;
            string path = ha.Context.Request.Url.ToString().ToLower(); 
            if (path.IndexOf("'") > 0 || path.IndexOf("\"") > 0)
            {
                ha.Response.Write("非法访问!");
                ha.Response.End();
            }
            int tag = path.ToLower().IndexOf(".aspx");
            if (path.IndexOf("viewimg.aspx") > 0 || path.IndexOf("default.aspx") > 0 || path.IndexOf("login") > 0 || path.IndexOf("index.aspx") > 0 || path.IndexOf("userapi.aspx") > 0 || path.IndexOf("userfuncsoureinfo.aspx") > 0 || path.IndexOf("uploadfile.aspx") > 0 || path.IndexOf("upuserimg.ashx") > 0 || path.IndexOf("uploadfileapp.aspx") > 0 || path.IndexOf("userpwdapp.aspx") > 0)
            {
                return;
            }
            if (tag != -1)
            {
                if (Com.Session.userid == null) //是否Session中有用户名，若是空的话，转向登录页。
                {
                    int n = path.ToLower().IndexOf("login.aspx");
                    int m = path.ToLower().IndexOf("sessionexception.aspx");
                    if (n == -1) //是否是登录页面，不是登录页面的话则进入{}
                    {
                        //判断是否是SessionException.aspx页面,不是则跳转到SessionException.aspx
                        if (m == -1)
                        {
                            ha.Context.Response.Redirect("~/loginexc.aspx");
                            ha.Context.Response.End();
                            //ha.Context.Response.Redirect("~/Login.aspx");
                            ////从COOkie中取得schno
                            //string schNo = "";
                            //HttpCookie cookie = HttpContext.Current.Request.Cookies["SCH_NO_COOKIE"];
                            //if (cookie!=null)
                            //{
                            //    if (cookie["schno"]!=null)
                            //    {
                            //         schNo = cookie["schno"];
                            //    }

                            //}
                            //ha.Context.Response.Redirect("~/SessionException.aspx");
                        }
                    }

                }
            }

        }
    }
}