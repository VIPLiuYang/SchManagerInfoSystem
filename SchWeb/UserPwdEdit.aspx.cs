using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWeb
{
    public partial class UserPwdEdit : System.Web.UI.Page
    {
        public string dotype = "UpdatePw";//操作类型,修改或者是添加,a添加,e修改,UpdatePw修改密码
        public string schid = "0";//需要建立的学校ID
        public string systype = "2";
        public string usertname = "";
        public string usertid = "";
        public string username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            usertname = Com.Session.uname;
            username = Com.Session.userid;
            usertid = Com.Session.usertid;
            schid = Com.Session.schid;
        }
        [WebMethod]
        public static string schsave(string dotype, string schid, string username, string usertid, string password)
        {
            string ret = "";
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

                        if (Com.Session.userpw != password)
                        {
                            SchSystem.BLL.SchUserInfo schbll = new SchSystem.BLL.SchUserInfo();
                            bool result = schbll.UpdatePw(int.Parse(usertid), Com.Public.StrToMD5(password));
                            Com.Session.userpw = password;
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
            return ret;

        }
    }
}