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
    public partial class UserE : System.Web.UI.Page
    {
        //进入此页需要确认的三个关键参数
        

        public string btnname = "添加";
        public string publicKey = "";//公钥
        public string dotype = "";//操作类型,修改或者是添加,a添加,e修改
        public string uid="0";
        public string uno;
        public string utname;
        public string usex="1";
        public string ups;
        public string ujb;
        public string utl;
        public string uname="";
        public string upw="";
        public string upwname = "初始密码:";
        public string ustat="0";
        public string depts = "";//相应学校部门及个人部门,json

        //需要根据不同情况建立或修改的不同学校用户和不同类型的用户,本学校用户唯一,不需要全系统唯一
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //公钥
                publicKey = PublicProperty.PublicKey.Replace("\r\n", ",");                
                //先得到操作类型
                dotype = Request.Params["dotype"].ToString();
                if (dotype == "e")//修改,不能修改用户的类型及学校参数
                {                    
                    //获取修改的对应用户的
                    uid = Request.Params["uid"].ToString();
                    SchSystem.BLL.SchUserInfo userbll = new SchSystem.BLL.SchUserInfo();
                    SchSystem.Model.SchUserInfo usermodel = userbll.GetModel(int.Parse(uid));
                    if (usermodel != null && usermodel.UserId > 0)
                    {
                        utname = usermodel.UserTname;
                        usex = usermodel.Sex.ToString();
                        ups = usermodel.Postion;
                        ujb = usermodel.Title;
                        utl = usermodel.Mobile.Trim();
                        uname = usermodel.UserName.Trim();
                        if (usermodel.PassWord == Com.Public.StrToMD5("123456"))
                        {
                            upw = "123456";
                            upwname = "初始密码:";
                        }
                        else if (usermodel.PassWord == "")
                        {
                            upw = "";
                            upwname = "初始密码:";
                        }
                        else
                        {
                            upw = "●●●●●●";
                            upwname = "用户密码:";
                        }
                        ustat = usermodel.AccStat.ToString();
                        uno = "00000000".Substring(0, 8 - uid.Length) + uid;
                    }
                    else
                    {                        
                        Response.Write("无该用户!");
                        Response.End();
                    }
                }
                SchSystem.BLL.SchDepartInfo dptbll = new SchSystem.BLL.SchDepartInfo();
                DataTable dtdept = dptbll.GetList("Pid pId,DepartId id,DepartName name,'false' checked", "SchId=" + Com.Session.schid + " and Stat=1 Order by OrderId").Tables[0];
                //获取该用户的关联部门
                SchSystem.BLL.SchUserDeptV udeptvbll = new SchSystem.BLL.SchUserDeptV();
                string udeptids = udeptvbll.GetIds(" UserId='" + uid + "' and stat=1 and schid=" + Com.Session.schid);
                if (!string.IsNullOrEmpty(udeptids) && dtdept != null)
                {
                    string[] ids = udeptids.Split(',');
                    for (int i = 0; i < dtdept.Rows.Count; i++)
                    {
                        string id = dtdept.Rows[i]["id"].ToString();
                        if (ids.Contains(id))
                        {
                            dtdept.Rows[i]["checked"] = "true";
                        }
                    }
                }
                depts = Newtonsoft.Json.JsonConvert.SerializeObject(dtdept);                
            }
        }

        [WebMethod]
        public static string usersave(string dotype, string userid, string usertname, string usertel, string userpst, string usertitle, string usermobile, string username, string userpw, string usersex, string userstat, string userdpts)
        {
            //解密 RSA
            RSACryptoService rsa = new RSACryptoService(PublicProperty.PrivateKey, PublicProperty.PublicKey);
            if (userpw != "")
            {
                userpw = Com.Public.SqlEncStr(rsa.Decrypt(userpw));
            }
            username = Com.Public.SqlEncStr(username);
            string ret = "";
            if (Com.Session.userid == null)
            {
                ret = "expire";
            }
            else
            {
                try
                {
                    
                    SchSystem.BLL.SchUserInfo userbll = new SchSystem.BLL.SchUserInfo();
                    SchSystem.Model.SchUserInfo usermodel = new SchSystem.Model.SchUserInfo();
                    
                    //判断编号及账号是否有重复,生成密码加密
                    if (dotype == "e")
                    {
                        if (username != "")
                        {
                            if (userbll.ExistsUserName(int.Parse(userid), username))
                            {
                                StringBuilder sbExists = new StringBuilder();
                                string utname = "";
                                if (userbll.ExistsUserName(0, username))
                                {
                                    SchSystem.BLL.SchUserDeptV bllusdpt = new SchSystem.BLL.SchUserDeptV();
                                    DataTable dt = bllusdpt.GetList("DepartName,UserTname", "UserName='" + username + "'").Tables[0];
                                    if (dt.Rows.Count > 0)
                                    {
                                        DataRow[] dr = dt.Select();
                                        foreach (DataRow item in dr)
                                        {
                                            sbExists.Append(item["DepartName"].ToString() + "、");
                                            utname = item["UserTname"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        sbExists.Append("学校管理员");
                                        SchSystem.BLL.SchUserInfo suiBll = new SchSystem.BLL.SchUserInfo();
                                        DataTable dtuser = suiBll.GetList("UserTname", "UserName='" + username + "'").Tables[0];
                                        if (dtuser.Rows.Count > 0)
                                        {
                                            utname = dtuser.Rows[0]["UserTname"].ToString();
                                        }
                                        else
                                        {
                                            utname = Com.Session.uname.ToString();
                                        }
                                    }
                                    if (utname == Com.Session.uname.ToString())
                                    {
                                        ret += sbExists.ToString();
                                    }
                                    else
                                    {
                                        ret += sbExists.ToString().Substring(0, sbExists.ToString().Length - 1);
                                    }
                                    ret += "," + utname;
                                }
                            }
                            else if (!userbll.ExistsUserName(0, username))
                            {
                                userbll.UpdateUserName(username, int.Parse(userid));
                            }



                        }
                    }
                    if (dotype == "a")
                    {
                        if (username != "")
                        {
                            StringBuilder sbExists = new StringBuilder();
                            string utname = "";
                            if (userbll.ExistsUserName(0, username))
                            {
                                SchSystem.BLL.SchUserDeptV bllusdpt = new SchSystem.BLL.SchUserDeptV();
                                DataTable dt = bllusdpt.GetList("DepartName,UserTname", "UserName='" + username + "'").Tables[0];//使用的的是视图查询，部门和用户连表，查询需要的部门和真实姓名
                                if (dt.Rows.Count > 0)
                                {
                                    DataRow[] dr = dt.Select();
                                    foreach (DataRow item in dr)
                                    {
                                        sbExists.Append(item["DepartName"].ToString() + "、");
                                        utname = item["UserTname"].ToString();
                                    }
                                }
                                else
                                {
                                    sbExists.Append("学校管理员,");

                                    SchSystem.BLL.SchUserInfo suiBll = new SchSystem.BLL.SchUserInfo();
                                    DataTable dtuser = suiBll.GetList("UserTname", "UserName='" + username + "'").Tables[0];
                                    if (dtuser.Rows.Count > 0)
                                    {
                                        utname = dtuser.Rows[0]["UserTname"].ToString();
                                    }
                                    else
                                    {
                                        utname = Com.Session.uname.ToString();
                                    }
                                }
                                //ret += "账号重复!";
                                if (utname == Com.Session.uname.ToString())
                                {
                                    ret += sbExists.ToString();
                                }
                                else
                                {
                                    ret += sbExists.ToString().Substring(0, sbExists.ToString().Length - 1);
                                }

                                ret += "," + utname;
                            }
                        }
                    }
                    if (ret == "")
                    {
                        usermodel.LastRecTime = DateTime.Now;
                        usermodel.LastRecUser = Com.Session.userid;
                        usermodel.Mobile = usermobile;
                        usermodel.Postion = userpst;
                        usermodel.Sex = int.Parse(usersex);
                        if (!string.IsNullOrEmpty(userstat))
                        {
                            usermodel.AccStat = int.Parse(userstat);
                        }
                        else
                        {
                            usermodel.AccStat = 2;
                        }
                        usermodel.SubCode = "";
                        usermodel.SysType = 0;
                        usermodel.Telno = usertel;
                        usermodel.Title = usertitle;
                        usermodel.UserNo = "";
                        usermodel.UserTname = usertname;
                        if (dotype == "e")
                        {
                            if (!string.IsNullOrEmpty(userpw) && !string.IsNullOrEmpty(username))
                            {
                                userpw = Com.Public.StrToMD5(userpw);
                                if (userpw == Com.Public.StrToMD5("123456"))//如果重置密码时保存
                                {
                                    userbll.UpdatePw(int.Parse(userid), userpw);
                                }
                            }
                            usermodel.UserId = int.Parse(userid);
                            userbll.UpdateUser(usermodel);

                        }
                        if (dotype == "a")
                        {
                            //必须有账号和密码
                            if (!string.IsNullOrEmpty(userpw) && !string.IsNullOrEmpty(username))
                            {
                                usermodel.PassWord = Com.Public.StrToMD5("123456"); //SchManagerInfoSystem.Common.DESEncrypt.Encrypt(userpw) ;添加时均为123456密码
                            }
                            usermodel.RecTime = DateTime.Now;
                            usermodel.RecUser = Com.Session.userid;
                            usermodel.SchId = int.Parse(Com.Session.schid);
                            usermodel.UserName = username;
                            userid = userbll.Add(usermodel).ToString();
                        }
                        //添加或更新关联部门
                        SchSystem.BLL.SchUserDept userdeptbll = new SchSystem.BLL.SchUserDept();
                        if (userdpts == null) userdpts = "0";
                        userdeptbll.DoUserDept(userid, Com.Session.userid, Com.Session.schid, userdpts);
                        ret = "success";
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