using Newtonsoft.Json;
using SchWeb.Com;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SchWeb.SchoolBaxicInfo.SchNews
{
    public partial class NewsShow : System.Web.UI.Page
    {

        public string newlv = "";
        public string chnname = "";
        public string gradename = "";
        public string classname = "";
        public string content = "";
        public string isqur = "";
        public string qurl = "";
        public string topic = "";
        public string isrep = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //
            string newsid = Request.Params["newsid"].ToString();
            SchSystem.BLL.WebSchChnNewsV bll = new SchSystem.BLL.WebSchChnNewsV();//
            SchSystem.Model.WebSchChnNewsV model = bll.GetModel(int.Parse(newsid));
            if (model != null)
            {
                newlv = model.Lv.ToString();
                chnname = model.ChnName;
                SchSystem.BLL.SchGradeInfo bllgrade = new SchSystem.BLL.SchGradeInfo();
                gradename = bllgrade.GetName(model.GradeId);
                SchSystem.BLL.SchClassInfo bllclass = new SchSystem.BLL.SchClassInfo();
                classname =bllclass.GetName(model.ClassId);
                content = model.Content;
                isqur = model.IsQuo.ToString();
                qurl = model.QuoUrl;
                topic = model.Topic;
                isrep = model.IsReply.ToString();
            }        

        }
    }
}