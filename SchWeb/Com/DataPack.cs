using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchWeb.Com
{
    public class DataPack
    {
        /// <summary>
        /// Resp包
        /// </summary>
        [Serializable]
        public class DataRsp<T>
        {
            /// <summary>
            /// 返回状态码
            /// </summary>
            public string code = "0000";//返回代码
            /// <summary>
            /// 返回说明
            /// </summary>
            public string msg = "正常";//返回代码提示
            /// <summary>
            /// 返回数据包
            /// </summary>
            public T RspData;//数据包
        }
        /// <summary>
        /// 用户信息
        /// </summary>
        [Serializable]
        public class UserInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string dpts;
            /// <summary>
            /// 
            /// </summary>
            public string subs;
            /// <summary>
            /// 
            /// </summary>
            public int sex;
            /// <summary>
            /// 
            /// </summary>
            public string clss;
            /// <summary>
            /// 
            /// </summary>
            public string schname;
            /// <summary>
            /// 
            /// </summary>
            public string grds;
            /// <summary>
            /// 
            /// </summary>
            public string urolestrsoure;
            /// <summary>
            /// 
            /// </summary>
            public int utid;
            /// <summary>
            /// 
            /// </summary>
            public int utp;
            /// <summary>
            /// 
            /// </summary>
            public string schid; 
            /// <summary>
            /// 
            /// </summary>
            public string uid;
            /// <summary>
            /// 
            /// </summary>
            public string urolestrext;
            /// <summary>
            /// 
            /// </summary>
            public int isadmin;
            /// <summary>
            /// 
            /// </summary>
            public string utname;
            /// <summary>
            ///  
            /// </summary>
            public string utoken;
            /// <summary>
            ///  
            /// </summary>
            public int appeditstat;
            /// <summary>
            ///  
            /// </summary>
            public string urolestr;

        }
    }
}