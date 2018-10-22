using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchWebAdmin.Com
{
    public class SoureSession
    {
        //用户账号
        public static string jsid
        {
            get
            {
                string result = null;
                if (HttpContext.Current.Session["jsid"] != null && HttpContext.Current.Session["jsid"].ToString() != "")
                    result = HttpContext.Current.Session["jsid"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["jsid"] = value;
            }
        }
        //用户账号
        public static string jstoken
        {
            get
            {
                string result = null;
                if (HttpContext.Current.Session["jstoken"] != null && HttpContext.Current.Session["jstoken"].ToString() != "")
                    result = HttpContext.Current.Session["jstoken"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["jstoken"] = value;
            }
        }
        //用户账号
        public static string Soureuserid
        {
            get
            {
                string result = null;
                if (HttpContext.Current.Session["Soureuserid"] != null && HttpContext.Current.Session["Soureuserid"].ToString() != "")
                    result = HttpContext.Current.Session["Soureuserid"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["Soureuserid"] = value;
            }
        }
        //用户账号
        public static string Soureisadmin
        {
            get
            {
                string result = null;
                if (HttpContext.Current.Session["Soureisadmin"] != null && HttpContext.Current.Session["Soureisadmin"].ToString() != "")
                    result = HttpContext.Current.Session["Soureisadmin"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["Soureisadmin"] = value;
            }
        }

        //用户ID
        public static string Soureusertid
        {
            get
            {
                string result = null;//  "guyuansheng"; //
                if (HttpContext.Current.Session["Soureusertid"] != null && HttpContext.Current.Session["Soureusertid"].ToString() != "")
                    result = HttpContext.Current.Session["Soureusertid"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["Soureusertid"] = value;
            }
        }

        //用户密码
        public static string Soureuserpw
        {
            get
            {
                string result = null;//  "guyuansheng"; //
                if (HttpContext.Current.Session["Soureuserpw"] != null && HttpContext.Current.Session["Soureuserpw"].ToString() != "")
                    result = HttpContext.Current.Session["Soureuserpw"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["Soureuserpw"] = value;
            }
        }
        //学校id
        public static string Soureschid
        {
            get
            {
                string result = null;
                if (HttpContext.Current.Session["Soureschid"] != null && HttpContext.Current.Session["Soureschid"].ToString() != "")
                    result = HttpContext.Current.Session["Soureschid"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["Soureschid"] = value;
            }
        }
        //学校id
        public static string Soureutname
        {
            get
            {
                string result = null;
                if (HttpContext.Current.Session["Soureutname"] != null && HttpContext.Current.Session["Soureutname"].ToString() != "")
                    result = HttpContext.Current.Session["Soureutname"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["Soureutname"] = value;
            }
        }
        public static string Souredpts
        {
            get
            {
                string result = null;
                if (HttpContext.Current.Session["Souredpts"] != null && HttpContext.Current.Session["Souredpts"].ToString() != "")
                    result = HttpContext.Current.Session["Souredpts"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["Souredpts"] = value;
            }
        }
        public static string Souresubs
        {
            get
            {
                string result = null;
                if (HttpContext.Current.Session["Souresubs"] != null && HttpContext.Current.Session["Souresubs"].ToString() != "")
                    result = HttpContext.Current.Session["Souresubs"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["Souresubs"] = value;
            }
        }
        public static string Soureclss
        {
            get
            {
                string result = null;
                if (HttpContext.Current.Session["Soureclss"] != null && HttpContext.Current.Session["Soureclss"].ToString() != "")
                    result = HttpContext.Current.Session["Soureclss"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["Soureclss"] = value;
            }
        }
        public static string Soureschname
        {
            get
            {
                string result = null;
                if (HttpContext.Current.Session["Soureschname"] != null && HttpContext.Current.Session["Soureschname"].ToString() != "")
                    result = HttpContext.Current.Session["Soureschname"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["Soureschname"] = value;
            }
        }
        public static string Souresex
        {
            get
            {
                string result = null;
                if (HttpContext.Current.Session["Souresex"] != null && HttpContext.Current.Session["Souresex"].ToString() != "")
                    result = HttpContext.Current.Session["Souresex"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["Souresex"] = value;
            }
        }
        public static string Soureurolestrext
        {
            get
            {
                string result = null;
                if (HttpContext.Current.Session["Soureurolestrext"] != null && HttpContext.Current.Session["Soureurolestrext"].ToString() != "")
                    result = HttpContext.Current.Session["Soureurolestrext"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["Soureurolestrext"] = value;
            }
        }
        public static string Soureutoken
        {
            get
            {
                string result = null;
                if (HttpContext.Current.Session["Soureutoken"] != null && HttpContext.Current.Session["Soureutoken"].ToString() != "")
                    result = HttpContext.Current.Session["Soureutoken"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["Soureutoken"] = value;
            }
        }
        //账号类型,0学校普通用户,1学校管理员,2系统超管,与权限及菜单Lv一样定义
        public static string Souresystype
        {
            get
            {
                string result = null;
                if (HttpContext.Current.Session["Souresystype"] != null && HttpContext.Current.Session["Souresystype"].ToString() != "")
                    result = HttpContext.Current.Session["Souresystype"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["Souresystype"] = value;
            }
        }
        public static string Soureimgurl
        {
            get
            {
                string result = null;
                if (HttpContext.Current.Session["Soureimgurl"] != null && HttpContext.Current.Session["Soureimgurl"].ToString() != "")
                    result = HttpContext.Current.Session["Soureimgurl"].ToString();
                return result;
            }
            set
            {
                HttpContext.Current.Session["Soureimgurl"] = value;
            }
        }

    }
}