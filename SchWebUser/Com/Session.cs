using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchWebUser.Com
{
    public class Session
    {
        public static string userid
        {
            get
            {
                string result = null;//  "guyuansheng"; //
                if (HttpContext.Current.Session["userid"] != null && HttpContext.Current.Session["userid"].ToString() != "")
                    result = HttpContext.Current.Session["userid"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["userid"] = value;
            }
        }
        public static string usertid
        {
            get
            {
                string result = null;//  "guyuansheng"; //
                if (HttpContext.Current.Session["usertid"] != null && HttpContext.Current.Session["usertid"].ToString() != "")
                    result = HttpContext.Current.Session["usertid"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["usertid"] = value;
            }
        }
        public static string userpw
        {
            get
            {
                string result = null;//  "guyuansheng"; //
                if (HttpContext.Current.Session["userpw"] != null && HttpContext.Current.Session["userpw"].ToString() != "")
                    result = HttpContext.Current.Session["userpw"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["userpw"] = value;
            }
        }
        //用户类型:0普通登录账号,1家长账号,2学生账号
        public static string usertp
        {
            get
            {
                string result = null;//  "guyuansheng"; //
                if (HttpContext.Current.Session["usertp"] != null && HttpContext.Current.Session["usertp"].ToString() != "")
                    result = HttpContext.Current.Session["usertp"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["usertp"] = value;
            }
        }
        //普通账号执教类型:1年级主任,2科任组长,3班主任,4科任老师,多个用逗号隔开
        public static string usertectp
        {
            get
            {
                string result = null;//  "guyuansheng"; //
                if (HttpContext.Current.Session["usertectp"] != null && HttpContext.Current.Session["usertectp"].ToString() != "")
                    result = HttpContext.Current.Session["usertectp"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["usertectp"] = value;
            }
        }
        public static string uname
        {
            get
            {
                string result = null;
                if (HttpContext.Current.Session["uname"] != null && HttpContext.Current.Session["uname"].ToString() != "")
                    result = HttpContext.Current.Session["uname"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["uname"] = value;
            }
        }
        public static string schid
        {
            get
            {
                string result = null;
                if (HttpContext.Current.Session["schid"] != null && HttpContext.Current.Session["schid"].ToString() != "")
                    result = HttpContext.Current.Session["schid"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["schid"] = value;
            }
        }
        //账号类型,0学校普通用户,1学校管理员,2系统超管,与权限及菜单Lv一样定义
        public static string systype
        {
            get
            {
                string result = null;
                if (HttpContext.Current.Session["systype"] != null && HttpContext.Current.Session["systype"].ToString() != "")
                    result = HttpContext.Current.Session["systype"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["systype"] = value;
            }
        }
        //普通权限
        public static string userrolestr
        {
            get
            {
                string result = null;
                if (HttpContext.Current.Session["userrolestr"] != null && HttpContext.Current.Session["userrolestr"].ToString() != "")
                    result = HttpContext.Current.Session["userrolestr"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["userrolestr"] = value;
            }
        }
        //特殊权限
        public static string userrolestrext
        {
            get
            {
                string result = null;
                if (HttpContext.Current.Session["userrolestrext"] != null && HttpContext.Current.Session["userrolestrext"].ToString() != "")
                    result = HttpContext.Current.Session["userrolestrext"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["userrolestrext"] = value;
            }
        }
    }
}