using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchWeb.SchoolBaxicInfo.SchNews
{
    /// <summary>
    /// 添加新闻属性类
    /// </summary>
    public class schnews
    {
        public int newsid { get; set; }
        public string title { get; set; }
        public string column { get; set; }
        public string range { get; set; }
        public string gradeid { get; set; }
        public string grdclassid { get; set; }
        public string content { get; set; }
        public string annex { get; set; }
        public string isreference { get; set; }
        public string textreference { get; set; }
        public string isreply { get; set; }
        public List<encclass> encs { get; set; }
    }
    /// <summary>
    /// 附件属性类
    /// </summary>
    public class encclass
    {
        public string imgurl{get;set;}
        public string saveurl{ get; set; }
        public string oldname{get;set;}
        public string newname{get;set;}
        public string filesize{get;set;}
    }
}