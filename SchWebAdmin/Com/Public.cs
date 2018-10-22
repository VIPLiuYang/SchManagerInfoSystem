using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace SchWebAdmin.Com
{
    public class Public
    {
        /// <summary>
        /// 数字转中文
        /// </summary>
        /// <param name="number">eg: 22</param>
        /// <returns></returns>
        public static string NumberToChinese(int number)
        {
            string res = string.Empty;
            string str = number.ToString();
            string schar = str.Substring(0, 1);
            switch (schar)
            {
                case "1":
                    res = "一";
                    break;
                case "2":
                    res = "二";
                    break;
                case "3":
                    res = "三";
                    break;
                case "4":
                    res = "四";
                    break;
                case "5":
                    res = "五";
                    break;
                case "6":
                    res = "六";
                    break;
                case "7":
                    res = "七";
                    break;
                case "8":
                    res = "八";
                    break;
                case "9":
                    res = "九";
                    break;
                default:
                    res = "零";
                    break;
            }
            if (str.Length > 1)
            {
                switch (str.Length)
                {
                    case 2:
                    case 6:
                        res += "十";
                        break;
                    case 3:
                    case 7:
                        res += "百";
                        break;
                    case 4:
                        res += "千";
                        break;
                    case 5:
                        res += "万";
                        break;
                    default:
                        res += "";
                        break;
                }
                res += NumberToChinese(int.Parse(str.Substring(1, str.Length - 1)));
            }
            return res;
        }
        public static bool PerClassExist(string schid,string percode)
        {
            bool bl = false;

            return bl;
        }
        public static bool IsNum(string str)
        {
            Regex reg = new Regex("^[0-9]+$");
            Match ma = reg.Match(str);
            return ma.Success;
        }
        public static DataTable MenuData(string thstr)
        {
            DataTable dt = new DataTable();
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
            else//超管菜单表,0学校普通用户,1学校管理员,2系统超管
            {
                string sqlstr = " Stat=2 and FuncLv like '%" + Com.Session.systype + "%' ";
                SchSystem.BLL.SchMenuInfoTop menuuserbll = new SchSystem.BLL.SchMenuInfoTop();
                dt = menuuserbll.GetList(sqlstr + "order by OrderId").Tables[0];
            }

            return dt;
        }
        //获取学校系统管理或者普通应用菜单列表
        public static DataTable SchMenuData(string cols, string thstr, string schid, string systype)
        {
            if (schid == "")
            {
                schid = Com.Session.schid;
            }
            //查询学校的子系统、资源服务模块状态
            SchSystem.BLL.SchInfo siBll = new SchSystem.BLL.SchInfo();
            DataTable dtschinfo = siBll.GetList("SonSysStat,SourceSerStat,HomeschServStat", "SchId='" + schid + "'").Tables[0];
            string SonSysStat = dtschinfo.Rows[0]["SonSysStat"].ToString();
            string SourceSerStat = dtschinfo.Rows[0]["SourceSerStat"].ToString();
            string SourceXXTStat = dtschinfo.Rows[0]["HomeschServStat"].ToString();

            DataTable dt = new DataTable();
            SchSystem.BLL.SchAppRole schapprolebll = new SchSystem.BLL.SchAppRole();
            string appstr = schapprolebll.GetAppStr(int.Parse(schid));

            if (appstr != "")
            {
                appstr = "  AppCode in (" + appstr + ")";
            }
         
            //0普通前台通用菜单,1学校管理后台菜单
            if (systype == "0")
            {
                string sqlstr = "";
                //获取正常的
                if (appstr == "")
                {
                    sqlstr = " Stat=1 and (AppCode=1 or AppCode=2  " + thstr + ")";
                }
                else
                {
                    sqlstr = " Stat=1 and (AppCode=1 or AppCode=2 or " + appstr + " " + thstr + ")";
                }

                //获取菜单表
                SchSystem.BLL.SchMenuInfoUser menuuserbll = new SchSystem.BLL.SchMenuInfoUser();
                dt = menuuserbll.GetList(cols, sqlstr + " order by OrderId ").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.NewRow();
                    row["id"] = 1;
                    row["pId"] = 0;
                    row["name"] = "首页";
                    dt.Rows.InsertAt(row,0);
                }
            }
            else if (systype == "1")
            {
                string sqlstr = "";
                //获取正常的
                if (appstr == "")
                {
                     sqlstr = " Stat=1 and (AppCode=0 or AppCode=1 or AppCode=2 " + thstr + ") ";
                }
                else
                {
                     sqlstr = " Stat=1 and (AppCode=0 or AppCode=1 or AppCode=2 or " + appstr + "" + thstr + ") ";
                }

                //if (SonSysStat == "0" || SonSysStat == "")//子系统状态为0时，不显示管理平台菜单
                //{
                //    sqlstr += " and FuncCode<>22 and Pid<> (select MenuId from SchMenuInfoAdmin where FuncCode=22) and Pid not in (select MenuId from SchMenuInfoAdmin where Pid = (select MenuId from SchMenuInfoAdmin where FuncCode=22)) ";//id是MenuId的别名
                //}
                //if (SourceSerStat == "0" || SourceSerStat == "")//资源服务状态为0时，不显示资源平台菜单
                //{
                //    sqlstr += " and FuncCode<>23 and Pid<> (select MenuId from SchMenuInfoAdmin where FuncCode=23) and Pid not in (select MenuId from SchMenuInfoAdmin where Pid = (select MenuId from SchMenuInfoAdmin where FuncCode=23)) ";
                //}
                //if (SourceXXTStat == "0" || SourceXXTStat == "")//家校互通服务状态为0时，不显示资源平台菜单
                //{
                //    sqlstr += " and FuncCode<>29 and Pid<> (select MenuId from SchMenuInfoAdmin where FuncCode=29) and Pid not in(select MenuId from SchMenuInfoAdmin where Pid = (select MenuId from SchMenuInfoAdmin where FuncCode=29))  ";
                //}

                SchSystem.BLL.SchMenuInfoAdmin menuuserbll = new SchSystem.BLL.SchMenuInfoAdmin();
                dt = menuuserbll.GetList(cols, sqlstr + " order by OrderId").Tables[0];
               
            }
            else
            {
                //获取子系统 
                if (appstr != "")
                {

                    string sqlstr = "Stat=1 and (" + appstr + ")";
                    SchSystem.BLL.SchApp schappbll = new SchSystem.BLL.SchApp();
                    dt = schappbll.GetList(cols, sqlstr).Tables[0];

                }
            }

            return dt;
        }
        /// <summary>
        /// DataRow转换为DataTable
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="strWhere">筛选的条件</param>
        /// <returns></returns>
        public static DataTable DataRowToDataTable(DataTable dt, string strWhere)
        {
            if (dt.Rows.Count <= 0) return dt;        //当数据为空时返回
            DataTable dtNew = dt.Clone();         //复制数据源的表结构
            DataRow[] dr = dt.Select(strWhere);  //strWhere条件筛选出需要的数据！
            for (int i = 0; i < dr.Length; i++)
            {
                dtNew.Rows.Add(dr[i].ItemArray);  // 将DataRow添加到DataTable中
            }
            return dtNew;
        }

        //用户信息
        public static Com.DataPack.DataRsp<Com.DataPack.UserInfo> UserFuncSoure(string jsid, string token,string appurl)
        {
            WebClient wbc = new WebClient();
            wbc.Encoding = Encoding.UTF8;
            wbc.Headers.Add("X-Requested-With", "XMLHttpRequest");
            wbc.Headers.Add("Cookie", "JSID=" + jsid + "; JSESSIONID=" + jsid + "; token=" + token);
            string thdstr = wbc.DownloadString(appurl);
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> Rsp = new DataPack.DataRsp<DataPack.UserInfo>();
            if (thdstr != "ERROR_TOKEN")
            {
                WriteLog("user", "getuser", thdstr);
                Com.DataPack.UserInfo userinfo = JsonConvert.DeserializeObject<Com.DataPack.UserInfo>(thdstr);
                Rsp = JsonConvert.DeserializeObject<Com.DataPack.DataRsp<Com.DataPack.UserInfo>>(thdstr);
                Rsp.data = userinfo;
                //设置Session信息
                if (userinfo.uid != "" && userinfo.schid != "")
                {
                    Com.SoureSession.Soureschid = userinfo.schid;
                    Com.SoureSession.Soureuserid = userinfo.uid;
                    Com.SoureSession.Soureusertid = userinfo.utid.ToString();
                    Com.SoureSession.Soureisadmin = userinfo.isadmin.ToString();
                    Com.SoureSession.Soureutname = userinfo.utname;
                    //Com.SoureSession.Souredpts = userinfo.dpts;
                    //Com.SoureSession.Souresubs = userinfo.subs;
                    //Com.SoureSession.Soureclss = userinfo.clss;
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
        //TypeCode,0省,1市,2区/县;pAreaCode父节点的AreaCode,查询子节点的条件;sAreaCode要选中的节点AreaCode,可输入或输出,addall 节点是否添加全部

        public static string GetSSQ(string TypeCode, string pAreaCode)
        {
            DataTable dt = new DataTable();
            string rstr = "";
            SchSystem.BLL.SysArea bll = new SchSystem.BLL.SysArea();
            string sqlstr = "TypeCode='" + TypeCode + "' ";
            if (TypeCode == "0")//取省份
            {
                sqlstr += " and left(AreaCode,2)='" + pAreaCode.Substring(0, 2) + "'";
            }
            else if (TypeCode == "1")//取城市
            {
                sqlstr += " and left(AreaCode,4)='" + pAreaCode.Substring(0, 4) + "'";

            }
            else if (TypeCode == "2")//取区县
            {
                sqlstr += " and AreaCode='" + pAreaCode + "'";
            }
            dt = bll.GetList("AreaName Name",sqlstr).Tables[0];           

            if (dt.Rows.Count > 0)
            {
                rstr = dt.Rows[0]["Name"].ToString();
            }
            return rstr;
        }
        public static string GetArea(string AreaCode)
        {
            DataTable dt = new DataTable();
            string rstr = "省|市|区";
            SchSystem.BLL.SysArea bll = new SchSystem.BLL.SysArea();
            string sqlstr = "(AreaCode='" + AreaCode.Substring(0, 2) + "0000' and TypeCode=0) or (AreaCode='" + AreaCode.Substring(0, 4) + "00' and TypeCode=1) or (AreaCode='" + AreaCode + "' and TypeCode=2)";
            
            dt = bll.GetList("AreaName,TypeCode", sqlstr).Tables[0];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["TypeCode"].ToString() == "0")
                    {
                        rstr=rstr.Replace("省", dt.Rows[i]["AreaName"].ToString());
                    }
                    else if (dt.Rows[i]["TypeCode"].ToString() == "1")
                    {
                        rstr = rstr.Replace("市", dt.Rows[i]["AreaName"].ToString());
                    }
                    else if (dt.Rows[i]["TypeCode"].ToString() == "2")
                    {
                        rstr = rstr.Replace("区", dt.Rows[i]["AreaName"].ToString());
                    }
                }
            }
            return rstr;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="TypeCode"></param>
        /// <param name="pAreaCode"></param>
        /// <param name="sAreaCode"></param>
        /// <param name="addall"></param>
        /// <param name="listoredit">區分是否為列表頁面和編輯頁面（1代表列表頁面；0代表編輯頁面）</param>
        /// <returns></returns>
        public static string GetDrpArea(string TypeCode, string pAreaCode, ref string sAreaCode, bool addall,string listoredit="1")
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
            else if (TypeCode == "1")//取城市
            {
                if (pAreaCode.Length == 6)
                    sqlstr = " and left(AreaCode,2)='" + pAreaCode.Substring(0, 2) + "'";
                else sqlstr = " and AreaCode='" + pAreaCode + "'";

            }
            else if (TypeCode == "2")//取区县
            {
                if (pAreaCode.Length == 6)
                    sqlstr = " and left(AreaCode,4)='" + pAreaCode.Substring(0, 4) + "'";
                else sqlstr = " and AreaCode='" + pAreaCode + "'";
            }
            if (addall)
            {
                sb.Append("<option value=\"\" selected=\"selected\">全部</option>");
            }
            if (TypeCode == "0" || TypeCode == "1" || TypeCode == "2")
            {
                //dt = bll.GetList("AreaCode ID,AreaName Name", "Stat=1 and TypeCode='" + TypeCode + "' " + sqlstr + " Order by AreaName").Tables[0];
                dt = bll.GetList("AreaCode ID,AreaName Name", "TypeCode='" + TypeCode + "' " + sqlstr + " Order by AreaName").Tables[0];//获取全部省份
            }
            else if (TypeCode == "3")//学校
            {
                dt = bllsch.GetList("SchId ID,SchName Name", "Stat=1 and AreaNo='" + pAreaCode + "' Order by SchName").Tables[0];

            }
            else if (TypeCode == "4")//年级
            {
                dt = bllgrade.GetList("GradeId ID ,GradeName Name", "IsFinish=0 and SchId='" + pAreaCode + "' Order by GradeCode").Tables[0];

            }
            else if (TypeCode == "5")//班级
            {
                string strWhere = "";
                dt = bllclass.GetList("ClassId ID, ClassName Name", "IsFinish=0 and GradeId='" + pAreaCode + "'" + strWhere + " Order by ClassName").Tables[0];

            }
            if (dt.Rows.Count > 0)
            {
                if (addall && listoredit=="1")
                {
                    sAreaCode = "";
                }
                else
                {
                    if (string.IsNullOrEmpty(sAreaCode))
                    {
                        sAreaCode = dt.Rows[0]["ID"].ToString();
                    }
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //if (sAreaCode == "" && i == 0)
                    //{
                    //    sb.Append("<option value=\"" + dt.Rows[i]["ID"].ToString() + "\" selected=\"selected\">" + dt.Rows[i]["Name"].ToString() + "</option>");
                    //}
                    //else
                    //{
                        // selected="selected"
                    
                        if (dt.Rows[i]["ID"].ToString() == sAreaCode)
                        {
                            sb.Append("<option value=\"" + dt.Rows[i]["ID"].ToString() + "\" selected=\"selected\">" + dt.Rows[i]["Name"].ToString() + "</option>");

                        }
                        else
                        {
                            sb.Append("<option value=\"" + dt.Rows[i]["ID"].ToString() + "\">" + dt.Rows[i]["Name"].ToString() + "</option>");
                        }
                    //}
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
                        dt = bllclass.GetList("ClassId ID, ClassName Name", "IsFinish=0 and GradeId='" + Com.Public.SqlEncStr(pAreaCode) + "' Order by ClassName").Tables[0];
                    }
                    else
                    {
                        dt = bllclass.GetList("ClassId ID, ClassName Name", "IsFinish=0 and GradeId='" + Com.Public.SqlEncStr(pAreaCode) + "' and (GradeId in (select GradeId FROM SchGradeUsers where UserName=" + Com.Session.usertid + ") or ClassId in (select ClassId FROM SchClassUserV where UserName=" + Com.Session.usertid + ")) Order by ClassName").Tables[0];
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
                    dt = subbll.GetList("0 Pid,GradeId ID,GradeName Name", "SchId=" + schid + " Order by GradeCode").Tables[0];
                }
                else
                {
                    dt = subbll.GetList("0 Pid,GradeId ID,GradeName Name", "SchId=" + schid + " and IsFinish=" + stat + " Order by GradeCode").Tables[0];
                }
            }
            if (addall)
            {
                sb.Append("<option value=\'0\'>全部</option>");
            }
            if (dt.Rows.Count > 0)
            {
                string childrenids = "";
                DataRow[] drs = dt.Select("Pid=0");
                foreach (DataRow dr in drs)
                {
                    string nodeID = dr["ID"].ToString();
                    string nodeText = dr["Name"].ToString();
                    if (nodeID != selfid)
                    {
                        //GetSonId(nodeID, dt, ref childrenids);
                        if (drptype == "dpt")
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
                        if (drptype == "dpt")
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
            public bool isedit { get; set; }
            public bool isdel { get; set; }
            public bool islook { get; set; }

            public DataTable list;
        }
        //用户登录判断
        public static string UserLoginDo(string uname, bool iscookies, string schid)
        {
            string str = "";
            SchSystem.BLL.SchUserInfo userbll = new SchSystem.BLL.SchUserInfo();
            //查询登录用户记录数据
            DataTable SchUserInfoDs = userbll.GetList("UserId,UserName,UserTname,SchId,SysType,ImgUrl", "UserName='" + Com.Public.SqlEncStr(uname) + "' and Stat=1 and AccStat=1 and SchId=" + schid).Tables[0];
            if (SchUserInfoDs.Rows.Count > 0)
            {
                SchSystem.BLL.SchUserRoleV userroleV = new SchSystem.BLL.SchUserRoleV();
                DataTable dtroles = userroleV.GetList("UserName='" + uname + "' and Stat=1 and AccStat=1 and SchId=" + schid).Tables[0];
                //if (dtroles.Rows.Count > 0)
                //{
                //设置Session信息
                Com.Session.usertid = SchUserInfoDs.Rows[0]["UserId"].ToString();
                Com.Session.userid = SchUserInfoDs.Rows[0]["UserName"].ToString();
                Com.Session.uname = SchUserInfoDs.Rows[0]["UserTname"].ToString();
                Com.Session.schid = SchUserInfoDs.Rows[0]["SchId"].ToString();
                Com.Session.systype = SchUserInfoDs.Rows[0]["SysType"].ToString();
                Com.Session.imgurl = SchUserInfoDs.Rows[0]["ImgUrl"].ToString();
                //合并普通权限串
                Com.Session.userrolestr = Com.Public.UserRoleStr(dtroles);
                //合并特殊权限串
                Com.Session.userrolestrext = Com.Public.UserRoleExtStr(dtroles);
                Com.Session.ulogintime = DateTime.Now.ToString("yyyyMMddHHmmss");
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
                Com.Session.appeditstat = schmodel.SonSysStat.ToString();
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
        //写日志
        public static void WriteLog(string type, string className, string content)
        {
            string path = HttpContext.Current.Request.PhysicalApplicationPath + "logs";
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
        public static string GetSubName(string subcode)
        {
            string ret = "";
            SchSystem.BLL.SysSub subbll = new SchSystem.BLL.SysSub();
            DataTable dt = subbll.GetList("SubName", "subcode='" + subcode + "'").Tables[0];
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