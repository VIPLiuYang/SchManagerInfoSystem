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

namespace SchWeb.SchoolBaxicInfo.UserFuncSoure
{
    public partial class ShowUser : System.Web.UI.Page
    {
        //进入此页需要确认的三个关键参数
        public string dotype = "";//操作类型,修改或者是添加,a添加,e修改
        public string schid = "";//需要建立的学校ID
        public string systype = "";//需要建立的用户类型,0普通用户,1学校超管,2系统超管
        public string btnname = "添加";

        public string schname = "";
        //根据上面两个参数的不同得到不同的参数
        public string umodelstr = "1";//用户model,json
        public string roles = "";//学校role和相应用户的select
        public string funcstr = "";//功能表,json
        public string MenuInfoExt = "";//特殊权限功能数据，json
        public string depts = "";//相应学校部门及个人部门,json
        public string subs = "";//相应学校科目表及个人科目,json
        public bool isadd;
        public bool isedit;
        public bool isdel;
        public bool islook;
        public string publicKey = "";//公钥

        //需要根据不同情况建立或修改的不同学校用户和不同类型的用户,本学校用户唯一,不需要全系统唯一
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (true)//如果没对应权限,及判断用户类型是否跨界,主要防止非法篡改数据出现
            //{
            //    Response.Write("无对应权限");
            //    Response.End();
            //}
            if (!IsPostBack)
            {
                //公钥
                //publicKey = PublicProperty.PublicKey.Replace("\r\n", ",");
                //权限组的增删改
                isadd = true;
                isedit = true;
                isdel = true;
                islook = true;
                //先得到操作类型
                dotype = Request.Params["dotype"].ToString();
                string uid = "0";//修改时的用户ID
                string uname = "";//修改时的用户账号
                if (dotype == "a")//添加
                {
                    //根据登录人员的身份,需要得到不同的参数
                    if (Com.SoureSession.Souresystype == "2")//超管,两个关键参数均需要确认
                    {
                        schid = Request.Params["schid"].ToString();
                        systype = Request.Params["systype"].ToString();
                        if (string.IsNullOrEmpty(schid) || string.IsNullOrEmpty(systype))//如果没有对应参数中任意一个
                        {
                            Response.Write("学校ID为空或者添加的类型为空!");
                            Response.End();
                        }
                    }
                    else//本学校超管或本学校有权限的用户,只能操作普通用户
                    {
                        schid = Com.SoureSession.Soureschid;
                        systype = "0";
                    }
                }
                else if (dotype == "e")//修改,不能修改用户的类型及学校参数
                {
                    btnname = "修改";
                    uid = Request.Params["uid"].ToString();
                    if (string.IsNullOrEmpty(uid))
                    {
                        Response.Write("无对应修改的用户!");
                        Response.End();
                    }
                    //获取修改的对应用户的
                    SchSystem.BLL.SchUserInfo userbll = new SchSystem.BLL.SchUserInfo();
                    SchSystem.Model.SchUserInfo usermodel = userbll.GetModel(int.Parse(uid));
                    if (usermodel != null && usermodel.UserId > 0)
                    {
                        //给默认的屏蔽密码,管理员不能随便修改,只能重置为123456
                        if (!string.IsNullOrEmpty(usermodel.PassWord))//密码不为空
                        {
                            if (usermodel.PassWord == Com.Public.StrToMD5("123456"))//初始密码
                            {
                                usermodel.PassWord = "******";
                            }
                            else//非初始密码
                            {
                                usermodel.PassWord = "●●●●●●";
                            }
                        }
                        else//密码为空
                        {
                            usermodel.PassWord = "";
                        }
                        umodelstr = Newtonsoft.Json.JsonConvert.SerializeObject(usermodel);
                        schid = usermodel.SchId.ToString();
                        systype = usermodel.SysType.ToString();
                        uname = usermodel.UserName;
                    }
                    else
                    {
                        Response.Write("无该用户!");
                        Response.End();
                    }
                }
                else//不在添加及修改之内,则返回
                {
                    Response.Write("没有可供确认的操作类型!");
                    Response.End();
                }
                //判断跨界操作的可能性
                /*if (!Com.Public.isVa(schid, systype))
                {
                    Response.Write("出错,用户非法跨界操作!");
                    Response.End();
                }*/
                SchSystem.BLL.SchInfo schbll = new SchSystem.BLL.SchInfo();
                schname = schbll.GetSchName(int.Parse(schid));
                if (!string.IsNullOrEmpty(schid) && !string.IsNullOrEmpty(systype))
                {
                    //获取整个学校的科目
                    subs = Com.Public.GetDrp("sub", schid, "1", false, "", "");

                    //获取整个学校的部门
                    SchSystem.BLL.SchDepartInfo dptbll = new SchSystem.BLL.SchDepartInfo();
                    DataTable dtdept = dptbll.GetList("Pid pId,DepartId id,DepartName name,'false' checked", "SchId=" + schid + " and Stat=1 Order by OrderId").Tables[0];
                    //获取该用户的关联部门
                    SchSystem.BLL.SchUserDeptV udeptvbll = new SchSystem.BLL.SchUserDeptV();
                    string udeptids = udeptvbll.GetIds(" UserId='" + uid + "' and stat=1 and schid=" + schid);
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
                    /*//获取角色菜单
                    SchSystem.BLL.SchRole rolebll = new SchSystem.BLL.SchRole();
                    DataTable dtrole = rolebll.GetList("RoleId id,null pId,RoleName name,'false' checked", "Stat=1 and SchId=" + schid + " and SysType='" + systype + "'  Order by RoleName").Tables[0];
                    if (dtrole.Rows.Count == 0)
                    {
                        //给个默认根节点
                        //DataRow dr = dtrole.NewRow();
                        //dr["id"] = "0";
                        //dr["pId"] = DBNull.Value;
                        //dr["name"] = "权限组";
                        //dr["checked"] = "false";
                        //dtrole.Rows.Add(dr);
                    }
                    //获取该用户关联的角色
                    SchSystem.BLL.SchUserRoleV urolevbll = new SchSystem.BLL.SchUserRoleV();
                    string uroleids = urolevbll.GetIds(" UserId='" + uid + "' and stat=1 and schid=" + schid);
                    if (!string.IsNullOrEmpty(uroleids) && dtrole != null)
                    {
                        string[] ids = uroleids.Split(',');
                        for (int i = 0; i < dtrole.Rows.Count; i++)
                        {
                            string id = dtrole.Rows[i]["id"].ToString();
                            if (ids.Contains(id))
                            {
                                dtrole.Rows[i]["checked"] = "true";
                            }
                        }
                    }
                    roles = Newtonsoft.Json.JsonConvert.SerializeObject(dtrole);*/
                    //获取功能树,查询条件需要根据用户种类和状态等,后面需要改
                    //根据学校拥有的子系统
                    //SchSystem.BLL.SchAppRole schapprolebll = new SchSystem.BLL.SchAppRole();
                    //string appstr = schapprolebll.GetAppStr(int.Parse(schid));
                    //if (appstr != "")
                    //{
                    //    appstr = " and (AppCode=1 or AppCode=2 or AppCode in (" + appstr + ")) ";
                    //}
                    //SchSystem.BLL.SchMenuInfoUserFunc funcbll = new SchSystem.BLL.SchMenuInfoUserFunc();

                    //DataTable dtfunc = funcbll.GetList("MenuId id,Pid pId,TextName name,FuncCode funcode,'false' checked", " Stat=1 " + appstr + " Order by OrderId").Tables[0];
                    //funcstr = Newtonsoft.Json.JsonConvert.SerializeObject(dtfunc);
                    //获取特殊权限功能树
                    //SchSystem.BLL.SchMenuInfoUser smieBll = new SchSystem.BLL.SchMenuInfoUser();
                    //DataTable dtsmie = smieBll.GetList("MenuId id,Pid pId,TextName name,FuncCode funcode,'false' checked", " Stat=1 " + appstr + "  Order by OrderId").Tables[0];
                    //MenuInfoExt = Newtonsoft.Json.JsonConvert.SerializeObject(dtsmie);
                }
            }
        }
        /*
        [WebMethod]
        public static string usersave(string dotype, string schid, string systype, string userid, string usercode, string usertname, string usertel, string userpst, string usertitle, string usermobile, string username, string userpw, string usersex, string userstat, string usersub, string userdpts, string userroles)
        {
            //解密 RSA
            RSACryptoService rsa = new RSACryptoService(PublicProperty.PrivateKey, PublicProperty.PublicKey);
            if (userpw != "")
            {
                userpw = Com.Public.SqlEncStr(rsa.Decrypt(userpw));
            }
            string ret = "";
            if (Com.Session.userid == null)
            {
                ret = "expire";
            }
            else
            {
                try
                {
                    if (string.IsNullOrEmpty(schid) || schid == "0")
                        ret += "非法的学校!";
                    SchSystem.BLL.SchUserInfo userbll = new SchSystem.BLL.SchUserInfo();
                    SchSystem.Model.SchUserInfo usermodel = new SchSystem.Model.SchUserInfo();
                    if (!Com.Public.isVa(schid, ""))
                    {
                        ret += "无跨界权限;";
                    }
                    //判断编号及账号是否有重复,生成密码加密
                    if (dotype == "e")
                    {
                        if (username != "")
                        {
                            StringBuilder sbExists = new StringBuilder();
                            string utname = "";
                            DataTable dt = userbll.ExistsUserName(username, int.Parse(schid));
                            if (dt.Rows.Count > 0)
                            {
                                DataRow[] dr = dt.Select();
                                foreach (DataRow item in dr)
                                {
                                    sbExists.Append(item["DepartName"].ToString() + "、");
                                    utname = item["UserTname"].ToString();
                                }
                                //ret += "账号重复!";
                                ret += sbExists.ToString().Substring(0, sbExists.ToString().Length - 1);
                                ret += "," + utname;
                            }
                            else if (!userbll.ExistsUserName(0, username, int.Parse(schid)))
                            {
                                userbll.UpdateUserName(username, int.Parse(userid));
                            }
                            
                            if (userbll.ExistsUserName(int.Parse(userid), username, int.Parse(schid)))
                            {
                                ret += "账号重复!";
                            }
                            else if (!userbll.ExistsUserName(0, username, int.Parse(schid)))
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
                            DataTable dt = userbll.ExistsUserName(username, int.Parse(schid));
                            if (dt.Rows.Count > 0)
                            {
                                DataRow[] dr = dt.Select();
                                foreach (DataRow item in dr)
                                {
                                    sbExists.Append(item["DepartName"].ToString() + "、");
                                    utname = item["UserTname"].ToString();
                                }
                                //ret += "账号重复!";
                                ret += sbExists.ToString().Substring(0, sbExists.ToString().Length - 1);
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
                        usermodel.SubCode = usersub;
                        usermodel.SysType = int.Parse(systype);
                        usermodel.Telno = usertel;
                        usermodel.Title = usertitle;
                        usermodel.UserNo = usercode;
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
                            usermodel.SchId = int.Parse(schid);
                            usermodel.UserName = username;
                            userid = userbll.Add(usermodel).ToString();
                        }
                        //添加或更新关联部门
                        SchSystem.BLL.SchUserDept userdeptbll = new SchSystem.BLL.SchUserDept();
                        if (userdpts == null) userdpts = "0";
                        userdeptbll.DoUserDept(userid, Com.Session.userid, schid, userdpts);
                        //添加或更新关联角色
                        //SchSystem.BLL.SchUserRole userrolebll = new SchSystem.BLL.SchUserRole();
                        //if (userroles == null) userroles = "0";
                        //userrolebll.DoUserRole(userid, Com.Session.userid, schid, userroles);
                        ret = "success";
                    }

                }
                catch (Exception ex)
                {
                    ret = ex.Message;
                }
            }
            return ret;

        }*/
    }
}