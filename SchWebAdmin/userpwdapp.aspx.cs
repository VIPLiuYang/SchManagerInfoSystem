﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin
{
    public partial class userpwdapp : System.Web.UI.Page
    {
        public string dotype = "UpdatePw";//操作类型,修改或者是添加,a添加,e修改,UpdatePw修改密码
        public string schid = "0";//需要建立的学校ID
        public string systype = "2";
        public string usertname = "";
        public string usertid = "";
        public string username = "";
        public string appurl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string userid = Request.Params["userid"];
            string aurl=Request.Params["appuserapiurl"];
            if (!string.IsNullOrEmpty(aurl))
            {
                appurl = System.Web.HttpUtility.UrlDecode(aurl);
            }
            if (string.IsNullOrEmpty(userid))//包含userid
            {                
                string jsid = Request.Params["sid"].ToString();
                string jstoken = Request.Params["token"].ToString();

                Com.SoureSession.jsid = jsid;
                Com.SoureSession.jstoken = jstoken;
                Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(jsid, jstoken, appurl);
                if (rsp.code == "ERROR_TOKEN")
                {
                    Response.Write("登录已失效!");
                    Response.End();
                }
                else if (!IsPostBack)
                {
                    usertname = Com.SoureSession.Soureusertid;
                    username = Com.SoureSession.Soureuserid;
                    usertid = Com.SoureSession.Soureusertid;
                    schid = Com.SoureSession.Soureschid;
                }
            }
            else
            {
                SchSystem.BLL.SchUserInfo userbll = new SchSystem.BLL.SchUserInfo();
                SchSystem.Model.SchUserInfo usermodel = userbll.GetModel(int.Parse(userid));
                if (usermodel != null)
                {
                    usertname = usermodel.UserTname;
                    username =usermodel.UserName;
                    usertid = usermodel.UserId.ToString();
                    schid = usermodel.SchId.ToString();
                }
            }
        }
        [WebMethod]
        public static string schsave(string dotype, string schid, string username, string usertid, string password)
        {
            string ret = "";
            //Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(Com.SoureSession.jsid, Com.SoureSession.jstoken);
            //if (rsp.code == "ERROR_TOKEN")
            //{
            //    ret = "expire";
            //}
            if (Com.SoureSession.Soureuserid==null)
            {
                ret = "expire";
            }
            else
            {
                try
                {
                    //学校名不能为空,
                    if (string.IsNullOrEmpty(username))
                    {
                        ret += "名称不能为空!";
                    }
                    //学校名不能为空,
                    if (password == "123456")
                    {
                        ret += "修改的密码不能为初始密码!";
                    }
                    if (ret == "")
                    {
                        if (dotype == "UpdatePw")
                        {

                            if (Com.SoureSession.Soureuserpw != password)
                            {
                                SchSystem.BLL.SchUserInfo schbll = new SchSystem.BLL.SchUserInfo();
                                bool result = schbll.UpdatePw(int.Parse(usertid), Com.Public.StrToMD5(password));
                                Com.SoureSession.Soureuserpw = password;
                                if (result)
                                {
                                    ret = "success";
                                }
                                else
                                {
                                    ret = "error";
                                }
                            }
                            else
                            {
                                ret = "与原来密码一样";
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    ret = ex.Message;
                }
            }
            return ret;

        }
    }
}