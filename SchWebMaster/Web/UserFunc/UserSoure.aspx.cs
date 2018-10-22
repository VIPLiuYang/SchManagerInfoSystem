using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebMaster.Web.UserFunc
{
    public partial class UserSoure : System.Web.UI.Page
    {
        public string uid;
        public string uno;
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
        public string schid;
        public string roles = "";//学校role和相应用户的select
        public string funcstr = "";//功能表,json
        public string MenuInfoExt = "";//特殊权限功能数据，json

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
                utl = usermodel.Telno;
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
                uno = "00000000".Substring(0, 8 - uid.Length) + uid;
                schid = usermodel.SchId.ToString();
                SchSystem.BLL.SchRoleSoure rolebll = new SchSystem.BLL.SchRoleSoure();
                DataTable dtrole = rolebll.GetList("RoleId id,null pId,RoleName name,'false' checked", "Stat=1 and SchId=" + schid + " and SysType='0'  Order by RoleName").Tables[0];

                //获取该用户关联的角色
                SchSystem.BLL.SchUserRoleSoureV urolevbll = new SchSystem.BLL.SchUserRoleSoureV();
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
                roles = Newtonsoft.Json.JsonConvert.SerializeObject(dtrole);
                //获取功能树,查询条件需要根据用户种类和状态等,后面需要改
                //根据学校拥有的子系统
                SchSystem.BLL.SchAppRole schapprolebll = new SchSystem.BLL.SchAppRole();
                string appstr = schapprolebll.GetAppStr(int.Parse(schid));
                if (appstr != "")
                {
                    appstr = " and (AppCode=1 or AppCode=2 or AppCode in (" + appstr + ")) ";
                }
                SchSystem.BLL.SchMenuInfoUserFuncSoure funcbll = new SchSystem.BLL.SchMenuInfoUserFuncSoure();

                DataTable dtfunc = funcbll.GetList("MenuId id,Pid pId,TextName name,FuncCode funcode,'false' checked", " Stat=1 " + appstr + " Order by OrderId").Tables[0];
                funcstr = Newtonsoft.Json.JsonConvert.SerializeObject(dtfunc);
            }
        }

        [WebMethod]
        public static string getrole(string schid, string roleid)
        {
            if (!Com.Public.isVa(schid, ""))
            {
                return "无跨界权限;";
            }
            SchSystem.BLL.SchRoleSoure bll = new SchSystem.BLL.SchRoleSoure();
            DataTable dtrole = bll.GetList("RoleId id,0 pId,RoleName name,RoleStr rolestr,RoleStrExt roleextstr", "RoleId=" + Com.Public.SqlEncStr(roleid)).Tables[0];
            return Newtonsoft.Json.JsonConvert.SerializeObject(dtrole);
        }
        [WebMethod]
        public static string roledel(string schid, string roleid)
        {
            if (!Com.Public.isVa(schid, ""))
            {
                return "无跨界权限;";
            }
            string ret = "success";
            if (Com.Session.userid== null)
            {
                ret = "expire";
            }
            else
            {
                try
                {
                    SchSystem.BLL.SchUserRoleSoure surBll = new SchSystem.BLL.SchUserRoleSoure();
                    bool surBool = surBll.ExistsRoleData(schid, roleid);
                    if (surBool)
                    {
                        ret = "success01";
                    }
                    else
                    {
                        SchSystem.BLL.SchRoleSoure bll = new SchSystem.BLL.SchRoleSoure();
                        SchSystem.Model.SchRoleSoure model = new SchSystem.Model.SchRoleSoure();
                        model.RoleId = int.Parse(roleid);
                        model.Stat = 2;
                        model.LastRecTime = DateTime.Now;
                        model.LastRecUser = Com.Session.userid;
                        if (bll.UpdateStat(model))
                        {
                            ret = "success";
                        }
                        else
                        {
                            ret = "操作失败";
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
        [WebMethod]
        public static string uprole(string schid, string roleid, string rolename, string rolestr, string rolextstr)
        {
            if (!Com.Public.isVa(schid, ""))
            {
                return "无跨界权限;";
            }
            string ret = "success";
            if (Com.Session.userid == null)
            {
                ret = "expire";
            }
            else
            {
                try
                {
                    SchSystem.BLL.SchRoleSoure bll = new SchSystem.BLL.SchRoleSoure();
                    SchSystem.Model.SchRoleSoure model = new SchSystem.Model.SchRoleSoure();
                    model.RoleId = int.Parse(roleid);
                    model.RoleName = Com.Public.SqlEncStr(rolename);
                    model.RoleStr = rolestr;
                    model.RoleStrExt = rolextstr;
                    model.Stat = 1;
                    model.LastRecTime = DateTime.Now;
                    model.LastRecUser = Com.Session.userid;
                    model.SchId =Convert.ToInt32( schid);
                    model.SysType = 0;
                    bll.Update(model);



                }
                catch (Exception ex)
                {
                    ret = ex.Message;
                }
            }
            return ret;

        }
        [WebMethod]
        public static string addrole(string schid, string rolename, string rolestr, string roleextstr)
        {
            if (!Com.Public.isVa(schid, ""))
            {
                return "无跨界权限;";
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
                    SchSystem.BLL.SchRoleSoure bll = new SchSystem.BLL.SchRoleSoure();
                    SchSystem.Model.SchRoleSoure model = new SchSystem.Model.SchRoleSoure();
                    model.RecTime = DateTime.Now;
                    model.RecUser = Com.Session.userid;
                    model.SchId = int.Parse(schid);
                    model.SysType = 0;
                    model.RoleName = Com.Public.SqlEncStr(rolename);
                    model.RoleStr = rolestr;
                        //model.RoleExtStr = roleextstr;
                    model.RoleStrExt = roleextstr;
                    model.Stat = 1;
                    model.LastRecTime = DateTime.Now;
                    model.LastRecUser = Com.Session.userid;
                    int id = bll.Add(model);
                    ret = id.ToString();
                }
                catch (Exception ex)
                {
                    ret = ex.Message;
                }
            }
            return ret;

        }

        [WebMethod]
        public static string usersave(string schid, string userid, string userroles)
        {
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
                    if (!Com.Public.isVa(schid, ""))
                    {
                        ret += "无跨界权限;";
                    }
                    
                    if (ret == "")
                    {
                        //添加或更新关联部门
                        //SchSystem.BLL.SchUserDept userdeptbll = new SchSystem.BLL.SchUserDept();
                        //if (userdpts == null) userdpts = "0";
                        //userdeptbll.DoUserDept(userid, Com.Session.userid, schid, userdpts);
                        //添加或更新关联角色
                        SchSystem.BLL.SchUserRoleSoure userrolebll = new SchSystem.BLL.SchUserRoleSoure();
                        if (userroles == null) userroles = "0";
                        userrolebll.DoUserRole(userid,  Com.Session.userid, schid, userroles);
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