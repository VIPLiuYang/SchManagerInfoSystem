using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebMaster.Web.Users
{
    public partial class ShowUser : System.Web.UI.Page
    {
        public string uid;
        public string utname;
        public string usex;
        public string udpts;//
        public string ups;
        public string ujb;
        public string utl;
        public string uname;
        public string upw;
        public string upwname;
        public string ustat;

        //需要根据不同情况建立或修改的不同学校用户和不同类型的用户,本学校用户唯一,不需要全系统唯一
        protected void Page_Load(object sender, EventArgs e)
        {
            uid = Request.Params["uid"].ToString();
            SchSystem.BLL.SchUserInfo userbll = new SchSystem.BLL.SchUserInfo();
            SchSystem.Model.SchUserInfo usermodel = userbll.GetModel(int.Parse(uid));
            if (usermodel != null && usermodel.UserId > 0)
            {
                utname = usermodel.UserTname;
                usex = usermodel.Sex == 0 ? "女" : "男";
                ups = usermodel.Postion;
                ujb = usermodel.Title;
                utl = usermodel.Mobile;
                uname = usermodel.UserName;
                if (usermodel.PassWord == Com.Public.StrToMD5("123456"))
                {
                    upw = "123456";
                    upwname = "初始密码";
                }
                else if (usermodel.PassWord == "")
                {
                    upw = "";
                    upwname = "初始密码";
                }
                else
                {
                    upw = "●●●●●●";
                    upwname = "用户密码";
                }
                ustat = usermodel.AccStat == 0 ? "禁用" : "正常";
                SchSystem.BLL.SchUserDeptV dpvbll = new SchSystem.BLL.SchUserDeptV();
                udpts = dpvbll.GetNames("UserId=" + uid);
                uid = "00000000".Substring(0, 8 - uid.Length) + uid;
            }
        }
    }
}