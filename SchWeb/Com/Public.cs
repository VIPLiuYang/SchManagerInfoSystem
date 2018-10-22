using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace SchWeb.Com
{
    public class Public
    {
        //新闻拥有的发布范围,0班级,1年级,2学校
        public static string NewsCope(string selid,ref string lv)
        {
            StringBuilder sb = new StringBuilder();
            if (Com.Public.IsUserVal(Com.Session.userrolestr, 13))//有全校性权限
            {
                if (selid == "2")
                {
                    lv = "2";
                    sb.Append("<option value=\"2\" selected=\"selected\">学校</option>");
                }
                else
                {
                    sb.Append("<option value=\"2\">学校</option>");
                }
                if (lv == "")
                {
                    lv = "2";
                }
            }
            SchSystem.BLL.SchGradeUserV bllgrade = new SchSystem.BLL.SchGradeUserV();
            if (Com.Public.IsUserVal(Com.Session.userrolestr, 13) || bllgrade.Exists(Com.Session.usertid))//有全校性权限或是年级主任
            {
                if (selid == "1")
                {
                    lv = "1";
                    sb.Append("<option value=\"1\" selected=\"selected\">年级</option>");
                }
                else
                {
                    sb.Append("<option value=\"1\">年级</option>");
                }
                if (lv == "")
                {
                    lv = "1";
                }
            }
            SchSystem.BLL.SchClassUser bllclasssub = new SchSystem.BLL.SchClassUser();                    
            if (Com.Public.IsUserVal(Com.Session.userrolestr, 14) || bllclasssub.ExistsV(0, 1, Com.Session.usertid, 1))//有全校性权限或是年级主任
            {
                if (selid == "0")
                {
                    lv = "0";
                    sb.Append("<option value=\"0\" selected=\"selected\">班级</option>");
                }
                else
                {
                    sb.Append("<option value=\"0\">班级</option>");
                }
                if (lv == "")
                {
                    lv = "0";
                }
            }
            return sb.ToString();
        }
        //根据要求取相应的列表,lv=0根据年级pid取班级,lv=1是取年级
        public static string NewsCopeDrp(string pid,int lv,string newlv,string selid,ref string selv)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            SchSystem.BLL.SchGradeInfo bllgrade = new SchSystem.BLL.SchGradeInfo();
            SchSystem.BLL.SchGradeUserV bllgradeuserv = new SchSystem.BLL.SchGradeUserV();
            SchSystem.BLL.SchClassInfo bllclass = new SchSystem.BLL.SchClassInfo();
            if (lv == 1)//取年级
            {
                if (Com.Public.IsUserVal(Com.Session.userrolestr, 13) || Com.Public.IsUserVal(Com.Session.userrolestr, 14))//有全校性权限,或全校班级性则获取所有年级
                {
                    dt = bllgrade.GetList("GradeId ID ,GradeName Name", "IsFinish=0 and SchId='" + Com.Session.schid + "' Order by GradeCode").Tables[0];
                }
                else//为年级组长或者班主任,则取管理的对应年级
                {
                    if (newlv == "0")//如果取班级新闻,则取对应班主任对应的年级
                    {
                        dt = bllgrade.GetList("GradeId ID ,GradeName Name", "IsFinish=0 and SchId='" + Com.Session.schid + "' and GradeId in (select GradeId from SchClassInfo where ClassId in (select ClassId from SchClassUser where UserName=" + Com.Session.usertid + " and IsMs=1) and IsFinish=0) Order by GradeCode").Tables[0];
                    }
                    else if (newlv == "1")//如果发布的是年级新闻,则取能发布的年级
                    {
                        dt = bllgrade.GetList("GradeId ID ,GradeName Name", "IsFinish=0 and SchId='" + Com.Session.schid + "' and GradeId in (select GradeId FROM SchGradeUsers where UserName=" + Com.Session.usertid + ") Order by GradeCode").Tables[0];
                    }
                }
            }
            else if (lv == 0)//取班级,根据上级ID取班级,全校性的不能取班级,只能管理到年级,年级领导也不能管理到班级
            {
                if (Com.Public.IsUserVal(Com.Session.userrolestr, 14))//如果有所有班级权限,则取所有班级
                {
                    dt = bllclass.GetList("ClassId ID, ClassName Name", "IsFinish=0 and GradeId='" + Com.Public.SqlEncStr(pid) + "' Order by ClassName").Tables[0];
                }
                else//其余则取对应的班主任管理班级
                {
                    dt = bllclass.GetList("ClassId ID, ClassName Name", "IsFinish=0 and GradeId='" + Com.Public.SqlEncStr(pid) + "' and ClassId in (select ClassId FROM SchClassUserV where UserName=" + Com.Session.usertid + " and isms=1) Order by ClassName").Tables[0];
                }
            }
            if (dt.Rows.Count > 0)
            {
                if (selid == "")
                {
                    selv = dt.Rows[0]["ID"].ToString();
                }
                else
                {
                    selv = selid; 
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["ID"].ToString() == selid)
                    {
                        sb.Append("<option value=\"" + dt.Rows[i]["ID"].ToString() + "\" selected=\"selected\">" + dt.Rows[i]["Name"].ToString() + "</option>");
                    }
                    else
                    {
                        sb.Append("<option value=\"" + dt.Rows[i]["ID"].ToString() + "\">" + dt.Rows[i]["Name"].ToString() + "</option>");                    
                    }
                }
            }
            return sb.ToString();
        }
        public static bool IsNum(string str)
        {
            Regex reg = new Regex("^[0-9]+$");
            Match ma = reg.Match(str);
            return ma.Success;
            //return Regex.IsMatch(str, "^[0-9]*$");
        }
        [Serializable]
        public class OAPack<T>
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
            public T RspData;//数据包
        }
        [Serializable]
        public class OANoRead
        {
            public int NoReadCnt { get; set; }
            public int NoApproveCnt { get; set; }
        }
        public static DataTable MenuData(string thstr)
        {
            DataTable dt = new DataTable();
            SchSystem.BLL.SchAppRole schapprolebll = new SchSystem.BLL.SchAppRole();
            string appstr = schapprolebll.GetAppStr(int.Parse(Com.Session.schid));
            if (appstr != "")
            {
                appstr = " and (AppCode=1 or AppCode=2 or AppCode in (" + appstr + ")) ";
            }
            //根据登录的用户身份获取菜单,0学校普通用户,1学校管理员,2系统超管
            if (Com.Session.systype == "0")
            {
                //再判断用户类型:0普通登录账号,1家长账号,2学生账号
                if (Com.Session.usertp == "0")//普通老师
                {
                    string sqlstr = " Stat=1 ";
                    //根据不同执教类型并集用户菜单,拼凑用户菜单查询条件

                    //普通账号执教类型:0普通老师,1年级主任,2科任组长,3班主任,4科任老师,多个用逗号隔开,在用户登录时根据用户情况赋值
                    //根据Com.Session.usertectp拆分数组,获取该用户能够获取的菜单 ((FuncLv like or FuncLv like )FuncLv:有逗号做查询最好,因现在暂不会重复,则先不做逗号间隔的查询
                    string funclv = "FuncLv like '%0%'";
                    if (!string.IsNullOrEmpty(Com.Session.usertectp))
                    {
                        string[] tp = Com.Session.usertectp.Split(',');
                        if (tp.Length > 0)
                        {
                            foreach (var item in tp)
                            {
                                funclv += " or FuncLv like '%" + item + "%'";
                            }
                        }
                    }
                    //再根据合并的权限串,根据节点调取菜单组funccode串并组合,OR,并集用户权限 or (FuncCode in )) --如果有
                    string func = "0";
                    //菜单组节点,获取菜单组
                    string sqlfuncg = "0";
                    for (int i = 0; i < 4000; i++)//权限串长度
                    {
                        bool bf = Com.Public.IsOne(Com.Session.userrolestr, i + 1);
                        if (bf)
                        {
                            sqlfuncg += "," + (i + 1);
                        }
                    }
                    if (sqlfuncg.Length > 2)//有相应的菜单组,获取菜单组
                    {
                        //读取菜单组表
                        SchSystem.BLL.SchMenuInfoUserFunc menubll = new SchSystem.BLL.SchMenuInfoUserFunc();
                        func += "," + menubll.GetMenug("FuncCode in (" + sqlfuncg + ")");
                    }

                    sqlstr += " and (" + funclv + " or FuncCode in (" + func + thstr + ")" + ")";
                    //再组装屏蔽菜单权限串SQL查询串,之前的条件均为并集,最后为差集.and (FuncCode not in )
                    string nfunc = "0";
                    for (int i = 0; i < 4000; i++)//权限串长度
                    {
                        bool bf = Com.Public.IsOne(Com.Session.userrolestrext, i + 1);
                        if (bf)
                        {
                            nfunc += "," + (i + 1);
                        }
                    }
                    sqlstr += " and FuncCode not in (" + nfunc + ")";
                    //获取该学校的子系统
                    sqlstr += appstr;
                    //获取菜单表
                    SchSystem.BLL.SchMenuInfoUser menuuserbll = new SchSystem.BLL.SchMenuInfoUser();
                    dt = menuuserbll.GetList(sqlstr + "order by OrderId").Tables[0];

                }
                else if (Com.Session.usertp == "1")//家长
                {

                }
                else if (Com.Session.usertp == "2")//学生
                {

                }

            }
            else//超管和学校超管共用菜单表,0学校普通用户,1学校管理员,2系统超管
            {
                string sqlstr = " Stat=1 and FuncLv like '%" + Com.Session.systype + "%' ";
                if (Com.Session.systype == "1")//学校超管,则要加上该学校的控制子系统菜单
                {
                    sqlstr += appstr;
                }
                SchSystem.BLL.SchMenuInfoAdmin menuuserbll = new SchSystem.BLL.SchMenuInfoAdmin();
                dt = menuuserbll.GetList(sqlstr + "order by OrderId").Tables[0];
            }

            return dt;
        }
        //防止跨学校操作,跨用户操作.
        //超管学校ID一定,超管系统学校(100000)用户均为超管,超管可以操作其他学校用户,可以产生低于超管级别的用户,如学校超管(唯一)和普通用户
        //,但不能在其他学校产生超管类型的用户及权限;
        //;普通学校仅能在本学校操作,并且不能产生超管类型的用户和权限,也不能产生超过1的权限
        public static bool isVa(string schid, string systype)
        {
            bool bok = true;
            if (Com.Session.systype != "2")//不是超管,则不允许跨界操作,只允许在本学校,也不允许跨用户类型操作
            {
                if (schid != Com.Session.schid)//不能跨学校
                {
                    bok = false;
                }
                if (systype != "0" && systype != "")//学校用户只能建普通用户,学校仅能建普通用户
                {
                    bok = false;
                }
            }
            else//如果为系统超管,则不能在其他学校产生超管
            {
                if (schid != Com.Public.getKey("adminschid") && systype == "2")//不在超管学校,可在webcfg中配置
                {
                    bok = false;
                }
                if (schid == Com.Public.getKey("adminschid") && systype != "2" && systype != "")//系统超管学校不允许建普通人员
                {
                    bok = false;
                }
            }
            return bok;
        }
        //获取年级
        public static string GetGradeSelect(string typecode, int classid, ref string id, string gradeid)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            SchSystem.BLL.SchGradeInfo bllgrade = new SchSystem.BLL.SchGradeInfo();
            SchSystem.BLL.SchClassInfo bllclass = new SchSystem.BLL.SchClassInfo();
            StringBuilder sbClasswhere = new StringBuilder();//获取班级条件
            StringBuilder sbGradewhere = new StringBuilder();//获取年级条件
            SchSystem.BLL.SchClassUser bllclassuser = new SchSystem.BLL.SchClassUser();
            bool isMs=false;
            if (classid == 0 && id == "")
            {
                isMs = bllclassuser.ExistsIsMs(Com.Session.usertid, Com.Session.schid,1);
            }
            else
            {
               isMs = bllclassuser.ExistsIsMs(Com.Public.SqlEncStr(classid.ToString()), Com.Session.usertid, Com.Session.schid, 1);
            }
            if (isMs == true)//班主任
            {
                //年级条件
                sbGradewhere.Append("GradeId in (select GradeId from SchClassInfo where ClassId in (select ClassId from SchClassUser where UserName=" + Com.Session.usertid + " and IsMs=1 and SchId="+gradeid+") and IsFinish=0 group by GradeId)");
                //班级条件
                sbClasswhere.Append("IsFinish=0 and GradeId='" + gradeid + "' and ClassId in (select ClassId FROM SchClassUser where UserName=" + Com.Session.usertid + ") ");
                DataTable dtSelect = null;
                if (typecode == "1")//年级
                {
                    dtSelect = bllgrade.GetList("GradeId id,GradeName name", sbGradewhere.ToString()).Tables[0];
                }
                else if (typecode == "2")//班级
                {
                    dtSelect = bllclass.GetList("ClassId id, ClassName name", sbClasswhere.ToString()).Tables[0];
                }
                for (int i = 0; i < dtSelect.Rows.Count; i++)
                {
                    if (id == dtSelect.Rows[i]["id"].ToString())
                    {
                        sb.Append("<option value=\"" + dtSelect.Rows[i]["id"].ToString() + "\" selected=\"selected\">" + dtSelect.Rows[i]["name"].ToString() + "</option>");
                    }
                    else
                    {
                        sb.Append("<option value=\"" + dtSelect.Rows[i]["id"].ToString() + "\">" + dtSelect.Rows[i]["name"].ToString() + "</option>");
                    }
                }
            }
            return sb.ToString();
        }
        //TypeCode,0省,1市,2区/县;pAreaCode父节点的AreaCode,查询子节点的条件;sAreaCode要选中的节点AreaCode,可输入或输出,addall 节点是否添加全部
        public static string schids = "";
        public static string GetDrpArea(string TypeCode, string pAreaCode, ref string sAreaCode, bool addall)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            SchSystem.BLL.SysArea bll = new SchSystem.BLL.SysArea();
            SchSystem.BLL.SchInfo bllsch = new SchSystem.BLL.SchInfo();
            SchSystem.BLL.SchGradeInfo bllgrade = new SchSystem.BLL.SchGradeInfo();
            SchSystem.BLL.SchClassInfo bllclass = new SchSystem.BLL.SchClassInfo();

            string sqlstr = "";
            if (TypeCode == "0")//取省份
            {
                sqlstr = "";
            }
            else if (TypeCode == "1" && pAreaCode != "")//取城市
            {
                if (pAreaCode.Length == 6)
                    sqlstr = " and left(AreaCode,2)='" + pAreaCode.Substring(0, 2) + "'";
                else sqlstr = " and AreaCode='" + Com.Public.SqlEncStr(pAreaCode) + "'";

            }
            else if (TypeCode == "2" && pAreaCode != "")//取区县
            {
                if (pAreaCode.Length == 6)
                    sqlstr = " and left(AreaCode,4)='" + pAreaCode.Substring(0, 4) + "'";
                else sqlstr = " and AreaCode='" + Com.Public.SqlEncStr(pAreaCode) + "'";
            }
            if (addall)
            {
                sb.Append("<option value=\"-1\">全部</option>");
            }
            if (TypeCode == "0" || TypeCode == "1" || TypeCode == "2")
            {
                //dt = bll.GetList("AreaCode ID,AreaName Name", "Stat=1 and TypeCode='" + TypeCode + "' " + sqlstr + " Order by AreaName").Tables[0];
                dt = bll.GetList("AreaCode ID,AreaName Name", "TypeCode='" + Com.Public.SqlEncStr(TypeCode) + "' " + sqlstr + " Order by AreaName").Tables[0];//获取全部省份
            }
            else if (TypeCode == "3")//学校
            {
                dt = bllsch.GetList("SchId ID,SchName Name", "Stat=1 and AreaNo='" + Com.Public.SqlEncStr(pAreaCode) + "' Order by SchName").Tables[0];

            }
            else if (TypeCode == "4")//年级
            {

                //普通老师
                if (Com.Session.systype == "0")
                {
                    dt = bllgrade.GetList("GradeId ID ,GradeName Name", "IsFinish=0 and SchId='" + Com.Session.schid + "' and (GradeId in (select GradeId FROM SchGradeUsers where UserName=" + Com.Session.usertid + ") or GradeId in (select GradeId FROM SchClassUserV where UserName=" + Com.Session.usertid + ")) Order by GradeCode").Tables[0];
                }
                else//学校超管
                {
                    dt = bllgrade.GetList("GradeId ID ,GradeName Name", "IsFinish=0 and SchId='" + Com.Public.SqlEncStr(pAreaCode) + "' Order by GradeCode").Tables[0];
                }
            }
            else if (TypeCode == "5")//班级
            {
                if (pAreaCode == "")
                {
                    pAreaCode = "0";
                }
                //普通老师
                if (Com.Session.systype == "0")
                {
                    dt = bllclass.GetList("ClassId ID, ClassName Name", "IsFinish=0 and GradeId='" + Com.Public.SqlEncStr(pAreaCode) + "' and (GradeId in (select GradeId FROM SchGradeUsers where UserName=" + Com.Session.usertid + ") or ClassId in (select ClassId FROM SchClassUserV where UserName=" + Com.Session.usertid + ")) Order by ClassName").Tables[0];
                }
                else//学校超管
                {
                    dt = bllclass.GetList("ClassId ID, ClassName Name", "IsFinish=0 and GradeId='" + Com.Public.SqlEncStr(pAreaCode) + "' Order by ClassName").Tables[0];
                }
            }
            if (dt.Rows.Count > 0)
            {
                if (sAreaCode == "")//输出第一个节点
                {
                    sAreaCode = dt.Rows[0]["ID"].ToString();
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (sAreaCode == "" && i == 0)
                    {
                        sb.Append("<option value=\"" + dt.Rows[i]["ID"].ToString() + "\" selected=\"selected\">" + dt.Rows[i]["Name"].ToString() + "</option>");
                    }
                    else
                    {
                        // selected="selected"
                        if (dt.Rows[i]["ID"].ToString() == sAreaCode)
                        {
                            sb.Append("<option value=\"" + dt.Rows[i]["ID"].ToString() + "\" selected=\"selected\">" + dt.Rows[i]["Name"].ToString() + "</option>");

                        }
                        else
                        {
                            sb.Append("<option value=\"" + dt.Rows[i]["ID"].ToString() + "\">" + dt.Rows[i]["Name"].ToString() + "</option>");
                        }
                    }
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 学校前台：学生家长基本信息查看页面使用的年级和班级查询
        /// </summary>
        /// <param name="TypeCode"></param>
        /// <param name="pAreaCode"></param>
        /// <param name="sAreaCode"></param>
        /// <param name="addall"></param>
        /// <returns></returns>
        public static string GetDrpAreaShow(string TypeCode, string pAreaCode, ref string sAreaCode, bool addall)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            SchSystem.BLL.SysArea bll = new SchSystem.BLL.SysArea();
            SchSystem.BLL.SchInfo bllsch = new SchSystem.BLL.SchInfo();
            SchSystem.BLL.SchGradeInfo bllgrade = new SchSystem.BLL.SchGradeInfo();
            SchSystem.BLL.SchClassInfo bllclass = new SchSystem.BLL.SchClassInfo();

            string sqlstr = "";
            if (TypeCode == "0")//取省份
            {
                sqlstr = "";
            }
            else if (TypeCode == "1" && pAreaCode != "")//取城市
            {
                if (pAreaCode.Length == 6)
                    sqlstr = " and left(AreaCode,2)='" + pAreaCode.Substring(0, 2) + "'";
                else sqlstr = " and AreaCode='" + Com.Public.SqlEncStr(pAreaCode) + "'";

            }
            else if (TypeCode == "2" && pAreaCode != "")//取区县
            {
                if (pAreaCode.Length == 6)
                    sqlstr = " and left(AreaCode,4)='" + pAreaCode.Substring(0, 4) + "'";
                else sqlstr = " and AreaCode='" + Com.Public.SqlEncStr(pAreaCode) + "'";
            }
            if (addall)
            {
                sb.Append("<option value=\"-1\">全部</option>");
            }
            if (TypeCode == "0" || TypeCode == "1" || TypeCode == "2")
            {
                //dt = bll.GetList("AreaCode ID,AreaName Name", "Stat=1 and TypeCode='" + TypeCode + "' " + sqlstr + " Order by AreaName").Tables[0];
                dt = bll.GetList("AreaCode ID,AreaName Name", "TypeCode='" + Com.Public.SqlEncStr(TypeCode) + "' " + sqlstr + " Order by AreaName").Tables[0];//获取全部省份
            }
            else if (TypeCode == "3")//学校
            {
                dt = bllsch.GetList("SchId ID,SchName Name", "Stat=1 and AreaNo='" + Com.Public.SqlEncStr(pAreaCode) + "' Order by SchName").Tables[0];

            }
            else if (TypeCode == "4")//年级
            {

                dt = bllgrade.GetList("GradeId ID ,GradeName Name", "IsFinish=0 and SchId='"+pAreaCode+"' and GradeId='"+sAreaCode+"'").Tables[0];
            }
            else if (TypeCode == "5")//班级
            {
                if (pAreaCode == "")
                {
                    pAreaCode = "0";
                }
                dt = bllclass.GetList("ClassId ID, ClassName Name", "IsFinish=0 and GradeId='" + Com.Public.SqlEncStr(pAreaCode) + "'  and ClassId='" + Com.Public.SqlEncStr(sAreaCode) + "'").Tables[0];
            }
            if (dt.Rows.Count > 0)
            {
                if (sAreaCode == "")//输出第一个节点
                {
                    sAreaCode = dt.Rows[0]["ID"].ToString();
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (sAreaCode == "" && i == 0)
                    {
                        sb.Append("<option value=\"" + dt.Rows[i]["ID"].ToString() + "\" selected=\"selected\">" + dt.Rows[i]["Name"].ToString() + "</option>");
                    }
                    else
                    {
                        // selected="selected"
                        if (dt.Rows[i]["ID"].ToString() == sAreaCode)
                        {
                            sb.Append("<option value=\"" + dt.Rows[i]["ID"].ToString() + "\" selected=\"selected\">" + dt.Rows[i]["Name"].ToString() + "</option>");

                        }
                        else
                        {
                            sb.Append("<option value=\"" + dt.Rows[i]["ID"].ToString() + "\">" + dt.Rows[i]["Name"].ToString() + "</option>");
                        }
                    }
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 获取班主任执教年级和班级
        /// </summary>
        /// <param name="TypeCode"></param>
        /// <param name="pAreaCode"></param>
        /// <param name="sAreaCode"></param>
        /// <param name="addall"></param>
        /// <returns></returns>
        public static string GetDrpAreaClassMaster(string TypeCode, string pAreaCode, ref string sAreaCode, bool addall)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            SchSystem.BLL.SysArea bll = new SchSystem.BLL.SysArea();
            SchSystem.BLL.SchInfo bllsch = new SchSystem.BLL.SchInfo();
            SchSystem.BLL.SchGradeInfo bllgrade = new SchSystem.BLL.SchGradeInfo();
            SchSystem.BLL.SchClassInfo bllclass = new SchSystem.BLL.SchClassInfo();

            string sqlstr = "";
            if (TypeCode == "0")//取省份
            {
                sqlstr = "";
            }
            else if (TypeCode == "1" && pAreaCode != "")//取城市
            {
                if (pAreaCode.Length == 6)
                    sqlstr = " and left(AreaCode,2)='" + pAreaCode.Substring(0, 2) + "'";
                else sqlstr = " and AreaCode='" + Com.Public.SqlEncStr(pAreaCode) + "'";

            }
            else if (TypeCode == "2" && pAreaCode != "")//取区县
            {
                if (pAreaCode.Length == 6)
                    sqlstr = " and left(AreaCode,4)='" + pAreaCode.Substring(0, 4) + "'";
                else sqlstr = " and AreaCode='" + Com.Public.SqlEncStr(pAreaCode) + "'";
            }
            if (addall)
            {
                sb.Append("<option value=\"-1\">全部</option>");
            }
            if (TypeCode == "0" || TypeCode == "1" || TypeCode == "2")
            {
                //dt = bll.GetList("AreaCode ID,AreaName Name", "Stat=1 and TypeCode='" + TypeCode + "' " + sqlstr + " Order by AreaName").Tables[0];
                dt = bll.GetList("AreaCode ID,AreaName Name", "TypeCode='" + Com.Public.SqlEncStr(TypeCode) + "' " + sqlstr + " Order by AreaName").Tables[0];//获取全部省份
            }
            else if (TypeCode == "3")//学校
            {
                dt = bllsch.GetList("SchId ID,SchName Name", "Stat=1 and AreaNo='" + Com.Public.SqlEncStr(pAreaCode) + "' Order by SchName").Tables[0];

            }
            else if (TypeCode == "4")//年级
            {

                //普通老师
                if (Com.Session.systype == "0")
                {
                    dt = bllgrade.GetList("GradeId ID ,GradeName Name", "IsFinish=0 and SchId='" + Com.Session.schid + "' and GradeId in (select GradeId FROM SchClassUserV where UserName=" + Com.Session.usertid + " and isms=1) Order by GradeCode").Tables[0];
                }
                else//学校超管
                {
                    dt = bllgrade.GetList("GradeId ID ,GradeName Name", "IsFinish=0 and SchId='" + Com.Public.SqlEncStr(pAreaCode) + "' Order by GradeCode").Tables[0];
                }
                //测试
                //dt = bllgrade.GetList("GradeId ID ,GradeName Name", "IsFinish=0 and SchId='" + Com.Public.SqlEncStr(pAreaCode) + "' Order by GradeCode").Tables[0];
            }
            else if (TypeCode == "5")//班级
            {
                if (pAreaCode == "")
                {
                    pAreaCode = "0";
                }
                //普通老师
                if (Com.Session.systype == "0")
                {
                    dt = bllclass.GetList("ClassId ID, ClassName Name", "IsFinish=0 and GradeId='" + Com.Public.SqlEncStr(pAreaCode) + "' and ClassId in (select ClassId FROM SchClassUserV where UserName=" + Com.Session.usertid + " and isms=1) Order by ClassName").Tables[0];
                }
                else//学校超管
                {
                    dt = bllclass.GetList("ClassId ID, ClassName Name", "IsFinish=0 and GradeId='" + Com.Public.SqlEncStr(pAreaCode) + "' Order by ClassName").Tables[0];
                }
                //测试
                //dt = bllclass.GetList("ClassId ID, ClassName Name", "IsFinish=0 and GradeId='" + Com.Public.SqlEncStr(pAreaCode) + "' Order by ClassName").Tables[0];
            }
            if (dt.Rows.Count > 0)
            {
                if (sAreaCode == "")//输出第一个节点
                {
                    sAreaCode = dt.Rows[0]["ID"].ToString();
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (sAreaCode == "" && i == 0)
                    {
                        sb.Append("<option value=\"" + dt.Rows[i]["ID"].ToString() + "\" selected=\"selected\">" + dt.Rows[i]["Name"].ToString() + "</option>");
                    }
                    else
                    {
                        // selected="selected"
                        if (dt.Rows[i]["ID"].ToString() == sAreaCode)
                        {
                            sb.Append("<option value=\"" + dt.Rows[i]["ID"].ToString() + "\" selected=\"selected\">" + dt.Rows[i]["Name"].ToString() + "</option>");

                        }
                        else
                        {
                            sb.Append("<option value=\"" + dt.Rows[i]["ID"].ToString() + "\">" + dt.Rows[i]["Name"].ToString() + "</option>");
                        }
                    }
                }
            }
            return sb.ToString();
        }
        public static string GetIdsAllStu(string TypeCode, string pAreaCode)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder("0");
            SchSystem.BLL.SchGradeInfo bllgrade = new SchSystem.BLL.SchGradeInfo();
            SchSystem.BLL.SchClassInfo bllclass = new SchSystem.BLL.SchClassInfo();
            if (TypeCode == "4")//年级
            {
                //普通老师
                if (Com.Session.systype == "0")
                {
                    if (Com.Public.IsUserVal(Com.Session.userrolestr, 2))//有查询权限,则全校
                    {
                        dt = bllgrade.GetList("GradeId ID", "IsFinish=0 and SchId='" + Com.Public.SqlEncStr(pAreaCode) + "'").Tables[0];
                    }
                    else//年级主任或者普通老师
                    {
                        dt = bllgrade.GetList("GradeId ID", "IsFinish=0 and SchId='" + Com.Public.SqlEncStr(pAreaCode) + "' and (GradeId in (select GradeId FROM SchGradeUsers where UserName=" + Com.Session.usertid + ") or GradeId in (select GradeId FROM SchClassUserV where UserName=" + Com.Session.usertid + "))").Tables[0];
                    }
                }
                else//学校超管
                {
                    dt = bllgrade.GetList("GradeId ID", "IsFinish=0 and SchId='" + Com.Public.SqlEncStr(pAreaCode) + "'").Tables[0];
                }
            }
            else if (TypeCode == "5")//班级
            {
                if (pAreaCode == "")
                {
                    pAreaCode = "0";
                }
                if (pAreaCode == "-1")
                {
                    //普通老师
                    if (Com.Session.systype == "0")
                    {
                        if (Com.Public.IsUserVal(Com.Session.userrolestr, 2))//有查询权限,则全校
                        {
                            dt = bllclass.GetList("ClassId ID", "IsFinish=0 and SchId='" + Com.Session.schid + "'").Tables[0];
                        }
                        else//年级主任或者普通老师
                        {
                            dt = bllclass.GetList("ClassId ID", "IsFinish=0 and SchId='" + Com.Session.schid + "' and (GradeId in (select GradeId FROM SchGradeUsers where UserName=" + Com.Session.usertid + ") or ClassId in (select ClassId FROM SchClassUserV where UserName=" + Com.Session.usertid + "))").Tables[0];
                        }
                    }
                    else//学校超管
                    {
                        dt = bllclass.GetList("ClassId ID", "IsFinish=0 and SchId='" + Com.Session.schid + "'").Tables[0];
                    }
                }
                else
                {
                    //普通老师
                    if (Com.Session.systype == "0")
                    {
                        if (Com.Public.IsUserVal(Com.Session.userrolestr, 2))//有查询权限,则全校
                        {
                            dt = bllclass.GetList("ClassId ID", "IsFinish=0 and GradeId='" + Com.Public.SqlEncStr(pAreaCode) + "'").Tables[0];
                        }
                        else//年级主任或者普通老师
                        {
                            dt = bllclass.GetList("ClassId ID", "IsFinish=0 and GradeId='" + Com.Public.SqlEncStr(pAreaCode) + "' and (GradeId in (select GradeId FROM SchGradeUsers where UserName=" + Com.Session.usertid + ") or ClassId in (select ClassId FROM SchClassUserV where UserName=" + Com.Session.usertid + "))").Tables[0];
                        }
                    }
                    else//学校超管
                    {
                        dt = bllclass.GetList("ClassId ID", "IsFinish=0 and GradeId='" + Com.Public.SqlEncStr(pAreaCode) + "'").Tables[0];
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("," + dt.Rows[i]["ID"].ToString());
                }
            }
            return sb.ToString();
        }
        public static string GetDrpAreaStu(string TypeCode, string pAreaCode, ref string sAreaCode, bool addall)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            SchSystem.BLL.SysArea bll = new SchSystem.BLL.SysArea();
            SchSystem.BLL.SchInfo bllsch = new SchSystem.BLL.SchInfo();
            SchSystem.BLL.SchGradeInfo bllgrade = new SchSystem.BLL.SchGradeInfo();
            SchSystem.BLL.SchClassInfo bllclass = new SchSystem.BLL.SchClassInfo();

            string sqlstr = "";
            if (TypeCode == "0")//取省份
            {
                sqlstr = "";
            }
            else if (TypeCode == "1" && pAreaCode != "")//取城市
            {
                if (pAreaCode.Length == 6)
                    sqlstr = " and left(AreaCode,2)='" + pAreaCode.Substring(0, 2) + "'";
                else sqlstr = " and AreaCode='" + Com.Public.SqlEncStr(pAreaCode) + "'";

            }
            else if (TypeCode == "2" && pAreaCode != "")//取区县
            {
                if (pAreaCode.Length == 6)
                    sqlstr = " and left(AreaCode,4)='" + pAreaCode.Substring(0, 4) + "'";
                else sqlstr = " and AreaCode='" + Com.Public.SqlEncStr(pAreaCode) + "'";
            }
            if (addall)
            {
                sb.Append("<option value=\"-1\"  selected=\"selected\">全部</option>");
            }
            if (TypeCode == "0" || TypeCode == "1" || TypeCode == "2")
            {
                //dt = bll.GetList("AreaCode ID,AreaName Name", "Stat=1 and TypeCode='" + TypeCode + "' " + sqlstr + " Order by AreaName").Tables[0];
                dt = bll.GetList("AreaCode ID,AreaName Name", "TypeCode='" + Com.Public.SqlEncStr(TypeCode) + "' " + sqlstr + " Order by AreaName").Tables[0];//获取全部省份
            }
            else if (TypeCode == "3")//学校
            {
                dt = bllsch.GetList("SchId ID,SchName Name", "Stat=1 and AreaNo='" + Com.Public.SqlEncStr(pAreaCode) + "' Order by SchName").Tables[0];

            }
            else if (TypeCode == "4")//年级
            {
                //普通老师
                if (Com.Session.systype == "0")
                {
                    if (Com.Public.IsUserVal(Com.Session.userrolestr, 2))//有查询权限,则全校
                    {
                        dt = bllgrade.GetList("GradeId ID ,GradeName Name", "IsFinish=0 and SchId='" + Com.Public.SqlEncStr(pAreaCode) + "' Order by GradeCode").Tables[0];
                    }
                    else
                    {
                        dt = bllgrade.GetList("GradeId ID ,GradeName Name", "IsFinish=0 and SchId='" + Com.Public.SqlEncStr(pAreaCode) + "' and (GradeId in (select GradeId FROM SchGradeUsers where UserName=" + Com.Session.usertid + ") or GradeId in (select GradeId FROM SchClassUserV where UserName=" + Com.Session.usertid + ")) Order by GradeCode").Tables[0];
                    }
                }
                else//学校超管
                {
                    dt = bllgrade.GetList("GradeId ID ,GradeName Name", "IsFinish=0 and SchId='" + Com.Public.SqlEncStr(pAreaCode) + "' Order by GradeCode").Tables[0];
                }
            }
            else if (TypeCode == "5")//班级
            {
                if (pAreaCode == "")
                {
                    pAreaCode = "0";
                }
                //普通老师
                if (Com.Session.systype == "0")
                {
                    if (Com.Public.IsUserVal(Com.Session.userrolestr, 2))//有查询权限,则全校
                    {
                        dt = bllclass.GetList("ClassId ID, ClassName Name", "SchId="+Com.Session.schid+" and IsFinish=0 and GradeId='" + Com.Public.SqlEncStr(pAreaCode) + "' Order by ClassName").Tables[0];
                    }
                    else
                    {
                        dt = bllclass.GetList("ClassId ID, ClassName Name", "SchId=" + Com.Session.schid + " and IsFinish=0 and GradeId='" + Com.Public.SqlEncStr(pAreaCode) + "' and (GradeId in (select GradeId FROM SchGradeUsers where UserName=" + Com.Session.usertid + ") or ClassId in (select ClassId FROM SchClassUserV where UserName=" + Com.Session.usertid + ")) Order by ClassName").Tables[0];
                    }
                }
                else//学校超管
                {
                    dt = bllclass.GetList("ClassId ID, ClassName Name", "IsFinish=0 and GradeId='" + Com.Public.SqlEncStr(pAreaCode) + "' Order by ClassName").Tables[0];
                }
            }
            if (dt.Rows.Count > 0)
            {
                if (sAreaCode == "")//输出第一个节点
                {
                    sAreaCode = dt.Rows[0]["ID"].ToString();
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (sAreaCode == "" && i == 0)
                    {
                        sb.Append("<option value=\"" + dt.Rows[i]["ID"].ToString() + "\" selected=\"selected\">" + dt.Rows[i]["Name"].ToString() + "</option>");
                    }
                    else
                    {
                        // selected="selected"
                        if (dt.Rows[i]["ID"].ToString() == sAreaCode)
                        {
                            sb.Append("<option value=\"" + dt.Rows[i]["ID"].ToString() + "\">" + dt.Rows[i]["Name"].ToString() + "</option>");

                        }
                        else
                        {
                            sb.Append("<option value=\"" + dt.Rows[i]["ID"].ToString() + "\">" + dt.Rows[i]["Name"].ToString() + "</option>");
                        }
                    }
                }
            }
            return sb.ToString();
        }

        public static string GetDrp(string drptype, string schid, string stat, bool addall, string selfid, string selid)
        {
            drptype = SqlEncStr(drptype);
            schid = SqlEncStr(schid);
            stat = SqlEncStr(stat);
            selfid = SqlEncStr(selfid);
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            if (schid == "") schid = "0";
            //获取部门
            if (drptype == "dpt")
            {
                SchSystem.BLL.SchDepartInfo dptbll = new SchSystem.BLL.SchDepartInfo();
                dt = dptbll.GetList("Pid,DepartId ID,DepartName Name", "SchId=" + schid + " and Stat=" + stat + " Order by OrderId,DepartName").Tables[0];
            }
            else if (drptype == "sub")
            {
                SchSystem.BLL.SchSub subbll = new SchSystem.BLL.SchSub();
                dt = subbll.GetList("0 Pid,SubCode ID,SubName Name", "SchId=" + schid + " and Stat=" + stat + " Order by OrderId,SubName").Tables[0];
            }
            else if (drptype == "grade")
            {
                SchSystem.BLL.SchGradeInfo subbll = new SchSystem.BLL.SchGradeInfo();
                if (stat == "")
                {
                    dt = subbll.GetList("0 Pid,GradeId ID,GradeName Name", "SchId=" + schid + " Order by GradeId").Tables[0];
                }
                else
                {
                    dt = subbll.GetList("0 Pid,GradeId ID,GradeName Name", "SchId=" + schid + " and IsFinish=" + stat + " Order by GradeId").Tables[0];
                }
            }
            else if (drptype == "chn")
            {
                SchSystem.BLL.WebSchChn SchChn = new SchSystem.BLL.WebSchChn();
                dt = SchChn.GetList("Pid,ChnId ID,ChnName Name", "Stat=1 and SchId=" + schid).Tables[0];
                //dt = subbll.GetSubList("0 Pid,SchSub.SubCode ID,SysSub.SubName Name", "SchSub.SchId=" + schid + " and SchSub.Stat=" + stat + " Order by SysSub.SubName").Tables[0];
            }
            if (addall)
            {
                sb.Append("<option value=\'0\'>全部</option>");
            }
            if (dt.Rows.Count > 0)
            {
                DataRow[] drs = dt.Select("Pid=0");
                foreach (DataRow dr in drs)
                {
                    string nodeID = dr["ID"].ToString();
                    string nodeText = dr["Name"].ToString();
                    if (nodeID != selfid)
                    {
                        //GetSonId(nodeID, dt, ref childrenids);
                        if (drptype == "dpt" || drptype == "chn")
                        {
                            nodeText = "├" + nodeText;
                        }
                        if (dr["ID"].ToString() == selid)
                        {
                            sb.Append("<option value=\"" + nodeID + "\" selected=\"selected\" childrenids=\"\">" + nodeText + "</option>");

                        }
                        else
                        {
                            sb.Append("<option value=\"" + nodeID + "\" childrenids=\"\">" + nodeText + "</option>");
                        }
                        if (drptype == "dpt" || drptype == "chn")
                        {
                            string blank = "&nbsp;&nbsp;&nbsp;&nbsp;";

                            BindSon(sb, nodeID, dt, blank, selid, selfid);

                        }
                    }
                }
            }
            return sb.ToString();
        }
        //绑定子节点
        public static void BindSon(StringBuilder sb, string pid, DataTable dt, string blank, string selid, string selfid)
        {
            string childrenids = "";
            DataRow[] drs = dt.Select("Pid=" + pid);
            foreach (DataRow dr in drs)
            {
                string nodeID = dr["ID"].ToString();
                string nodeText = dr["Name"].ToString();
                //GetSonId(nodeID, dt, ref childrenids);
                nodeText = blank + "|--" + nodeText;
                if (nodeID != selfid)
                {
                    if (dr["ID"].ToString() == selid)
                    {
                        sb.Append("<option value=\"" + nodeID + "\" selected=\"selected\" childrenids=\"" + childrenids + "\">" + nodeText + "</option>");

                    }
                    else
                    {
                        sb.Append("<option value=\"" + nodeID + "\" childrenids=\"" + childrenids + "\">" + nodeText + "</option>");
                    }
                    string blank2 = blank + "&nbsp;&nbsp;&nbsp;&nbsp;";

                    BindSon(sb, nodeID, dt, blank2, selid, selfid);
                }
            }
        }
        //递归获取子节点
        public static void GetSonId(string pid, DataTable dt, ref string childrenids)
        {
            DataRow[] drs = dt.Select("Pid=" + pid);
            if (drs != null)
            {
                foreach (DataRow dr in drs)
                {
                    string nodeID = dr["ID"].ToString();
                    childrenids += nodeID + ",";
                    GetSonId(nodeID, dt, ref childrenids);
                }
            }
            else
            {
                childrenids = "";
            }
        }
        //分页获取包
        [Serializable]
        public class GradeInfo
        {
            public DataTable gradelist;
            public DataTable gradebosslist;
        }
        //分页获取包
        [Serializable]
        public class PageModelResp
        {
            /// <summary>
            /// 分页索引页-第几页
            /// </summary>
            public int PageIndex { get; set; }
            /// <summary>
            /// 总记录数
            /// </summary>
            public int RowCount { get; set; }
            /// <summary>
            /// 总页数
            /// </summary>
            public int PageCount { get; set; }
            /// <summary>
            /// 分页大小-以多少条分页
            /// </summary>
            public int PageSize { get; set; }
            public bool isadd { get; set; }

            public DataTable list;
        }
        //用户登录判断
        public static string UserLoginDo(string uname, bool iscookies, string schid)
        {
            string str = "";
            SchSystem.BLL.SchUserInfo userbll = new SchSystem.BLL.SchUserInfo();
            //查询登录用户记录数据
            DataTable SchUserInfoDs = userbll.GetList("UserId,UserName,UserTname,SchId,SysType,ImgUrl", "UserName='" + Com.Public.SqlEncStr(uname) + "' and Stat=1 and AccStat=1").Tables[0];// and SchId=" + schid
            if (SchUserInfoDs.Rows.Count > 0)
            {
                SchSystem.BLL.SchUserRoleV userroleV = new SchSystem.BLL.SchUserRoleV();
                DataTable dtroles = userroleV.GetList("UserName='" + uname + "' and Stat=1 and AccStat=1").Tables[0];// and SchId=" + schid
                //if (dtroles.Rows.Count > 0)
                //{
                //设置Session信息
                Com.Session.usertid = SchUserInfoDs.Rows[0]["UserId"].ToString();
                Com.Session.userid = SchUserInfoDs.Rows[0]["UserName"].ToString();
                Com.Session.uname = SchUserInfoDs.Rows[0]["UserTname"].ToString();
                Com.Session.schid = SchUserInfoDs.Rows[0]["SchId"].ToString();
                Com.Session.systype = SchUserInfoDs.Rows[0]["SysType"].ToString();
                Com.Session.imgurl = SchUserInfoDs.Rows[0]["ImgUrl"].ToString();
                Com.Session.ulogintime = DateTime.Now.ToString("yyyyMMddHHmmss");
                //合并普通权限串
                Com.Session.userrolestr = Com.Public.UserRoleStr(dtroles);
                //合并特殊权限串
                Com.Session.userrolestrext = Com.Public.UserRoleExtStr(dtroles);
                //设置cookies
                if (iscookies)
                {
                    CookieHelper.SetCookie("uname", uname, DateTime.Now.AddDays(7));
                }
                //获取老师身份
                if (Com.Session.usertp == "0")
                {
                    string tectype = "0";
                    //1年级主任,2科任组长,3班主任,4科任老师
                    SchSystem.BLL.SchGradeUserV bllgrade = new SchSystem.BLL.SchGradeUserV();
                    if (bllgrade.Exists(Com.Session.usertid))
                    {
                        tectype += ",1";
                    }
                    SchSystem.BLL.SchUserSubV bllsub = new SchSystem.BLL.SchUserSubV();
                    if (bllsub.Exists(Com.Session.usertid))
                    {
                        tectype += ",2";
                    }
                    SchSystem.BLL.SchClassUser bllclasssub = new SchSystem.BLL.SchClassUser();
                    if (bllclasssub.ExistsV(0, 1, Com.Session.usertid, 1))
                    {
                        tectype += ",3";
                    }
                    if (bllclasssub.ExistsV(0, 1, Com.Session.usertid, 0))
                    {
                        tectype += ",4";
                    }
                    Com.Session.usertectp = tectype;
                }
                //获取该学校的系统编辑状态
                SchSystem.BLL.SchInfo schbll = new SchSystem.BLL.SchInfo();
                SchSystem.Model.SchInfo schmodel = schbll.GetModel(int.Parse(Com.Session.schid));
                if (schmodel != null)
                {
                    Com.Session.appeditstat = schmodel.SonSysStat.ToString();
                }
                else
                {
                    Com.Session.appeditstat = "";
                }
                str = "1";
                //}
                // else
                // {
                //     str = "该账号没有相应的权限或者对应角色被屏蔽,请联系管理员进行分配处理";
                //  }
            }
            else
            {
                str = "该账号被屏蔽或不存在";
            }

            return str;
        }



        //用户信息
        public static Com.DataPack.DataRsp<Com.DataPack.UserInfo> UserFuncSoure(string jsid, string token)
        { 
            WebClient wbc = new WebClient();
            wbc.Encoding = Encoding.UTF8;
            wbc.Headers.Add("X-Requested-With", "XMLHttpRequest");
            wbc.Headers.Add("Cookie", "JSID=" + jsid + "; token=" + token);
            string thdstr = wbc.DownloadString(Com.Public.getKey("Userapi"));
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> Rsp = new DataPack.DataRsp<DataPack.UserInfo>();
            if (thdstr != "ERROR_TOKEN")
            {
                Com.DataPack.UserInfo userinfo = JsonConvert.DeserializeObject<Com.DataPack.UserInfo>(thdstr);
                Rsp = JsonConvert.DeserializeObject<Com.DataPack.DataRsp<Com.DataPack.UserInfo>>(thdstr);
                Rsp.RspData = userinfo;
                //设置Session信息
                if (userinfo.uid != "" && userinfo.schid != "")
                {
                    Com.SoureSession.Soureschid = userinfo.schid;
                    Com.SoureSession.Soureuserid = userinfo.uid;
                    Com.SoureSession.Soureusertid = userinfo.utid.ToString();
                    Com.SoureSession.Soureisadmin = userinfo.isadmin.ToString();
                    Com.SoureSession.Soureutname = userinfo.utname;
                    Com.SoureSession.Souredpts = userinfo.dpts;
                    Com.SoureSession.Souresubs = userinfo.subs;
                    Com.SoureSession.Soureclss = userinfo.clss;
                    Com.SoureSession.Souresex = userinfo.sex.ToString();
                    Com.SoureSession.Soureschname = userinfo.schname;
                    Com.SoureSession.Soureurolestrext = userinfo.urolestrext;
                    Com.SoureSession.Souresystype = userinfo.isadmin.ToString();
                }
            }
            else
            {
                Rsp.code = "ERROR_TOKEN";
            }

            return Rsp;
        }



        //合并用户权限串,dt为角色表集
        public static string UserRoleStr(DataTable dt)
        {
            //先生成一个4000字长的字符串
            string rolestr = "";
            for (int i = 0; i < 4000; i++)
            {
                bool iok = false;
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        iok = IsOne(dr["RoleStr"].ToString(), i + 1);
                        if (iok) break;
                    }
                }
                rolestr += Convert.ToInt32(iok).ToString();
            }
            return rolestr;
        }
        //合并用户特殊权限串,dt为角色表集
        public static string UserRoleExtStr(DataTable dt)
        {
            //先生成一个50字长的字符串
            string roleextstr = "";
            for (int i = 0; i < 50; i++)
            {
                bool iok = false;
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        iok = IsOne(dr["RoleStrExt"].ToString(), i + 1);
                        if (iok) break;
                    }
                }
                roleextstr += Convert.ToInt32(iok).ToString();
            }
            return roleextstr;
        }
        //字符串对应位置处是否为1
        public static bool IsOne(string str, int i)
        {
            bool isok = false;
            if (str.Length > i - 1)
            {
                string istr = str.Substring(i - 1, 1);
                if (istr == "1")
                {
                    isok = true;
                }
            }
            return isok;
        }
        public static bool IsUserVal(string str, int i)
        {
            bool isok = false;
            if (Com.Session.systype == "0")
            {
                if (str.Length > i - 1)
                {
                    string istr = str.Substring(i - 1, 1);
                    if (istr == "1")
                    {
                        isok = true;
                    }
                }
            }
            else
            {
                isok = true;
            }
            return isok;
        }

        //SQL注入过滤
        public static string SqlEncStr(string inputString)
        {
            //要替换的敏感字
            string SqlStr = @"and|or|exec|execute|insert|select|delete|update|alter|create|drop|count|\*|chr|char|asc|mid|substring|master|truncate|declare|xp_cmdshell|restore|backup|net +user|net +localgroup +administrators";
            try
            {
                if ((inputString != null) && (inputString != String.Empty))
                {
                    string str_Regex = @"\b(" + SqlStr + @")\b";

                    Regex Regex = new Regex(str_Regex, RegexOptions.IgnoreCase);
                    //string s = Regex.Match(inputString).Value; 
                    MatchCollection matches = Regex.Matches(inputString);
                    for (int i = 0; i < matches.Count; i++)
                        inputString = inputString.Replace(matches[i].Value, "[" + matches[i].Value + "]");

                }
            }
            catch
            {
                return "";
            }
            return inputString;

        }
        public static string getKey(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
        //日志路径
        public static string path = HttpContext.Current.Request.PhysicalApplicationPath + "logs";
        //写日志
        public static void WriteLog(string type, string className, string content)
        {
            if (!Directory.Exists(path))//如果日志目录不存在就创建
            {
                Directory.CreateDirectory(path);
            }

            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");//获取当前系统时间
            string filename = path + "/" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";//用日期对日志文件命名

            //向日志文件写入内容
            string write_content = time + " " + type + " " + className + ": \r\n" + content;
            FileStream fs = null;
            try
            {
                //if (SourceAddress.ToString() == "60.28.196.5" || DestinationAddress.ToString() == "60.28.196.5")
                //{
                fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.Write);
                //(Filename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                byte[] filebyte = Encoding.Default.GetBytes(write_content + "\r\n_______________________________________\r\n\r\n");
                fs.Write(filebyte, 0, filebyte.Length);
                fs.Flush();
                //}
            }
            catch
            {

            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }
 



        //获取科目信息
        public static string GetSubName(string subcode, string schid)
        {
            string ret = "";
            SchSystem.BLL.SchSub subbll = new SchSystem.BLL.SchSub();
            DataTable dt = subbll.GetList("SubName", "SchId=" + Com.Public.SqlEncStr(schid) + " and stat=1 and subcode=" + Com.Public.SqlEncStr(subcode)).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                ret = dt.Rows[0]["SubName"].ToString();
            }
            return ret;
        }
        public static string StrToMD5(string str)
        {
            str = str + getKey("SecretKey");
            byte[] data = Encoding.UTF8.GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] OutBytes = md5.ComputeHash(data);
            string OutString = "";
            for (int i = 0; i < OutBytes.Length; i++)
            {
                OutString += OutBytes[i].ToString("x2");
            }
            // return OutString.ToUpper();
            return OutString.ToLower();
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Encrypt(string Text)
        {
            return Encrypt(Text, getKey("SecretKey"));
        }
        /// <summary> 
        /// 加密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Encrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.UTF8.GetBytes(Text);
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        /// <summary>
        /// 获取本地IP
        /// </summary>
        /// <returns></returns>
        public static Com.DataPack.DataRsp<string> GetLocalIP()
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            if (Com.Session.userid == null)
            {
                rsp.code = "expire";
                rsp.msg = "页面已经过期，请重新登录";
            }
            else
            {
                try
                {
                    string HostName = Dns.GetHostName(); //得到主机名
                    IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                    for (int i = 0; i < IpEntry.AddressList.Length; i++)
                    {
                        //从IP地址列表中筛选出IPv4类型的IP地址
                        //AddressFamily.InterNetwork表示此IP为IPv4,
                        //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                        if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                        {
                            rsp.RspData = IpEntry.AddressList[i].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    rsp.code = "ExcepError";
                    rsp.msg = ex.Message;
                }
            }
            return rsp;
        }

        #region ========解密========


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Decrypt(string Text)
        {
            return Decrypt(Text, getKey("SecretKey"));
        }
        /// <summary> 
        /// 解密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Decrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = Text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.UTF8.GetString(ms.ToArray());
        }

        #endregion
    }
}