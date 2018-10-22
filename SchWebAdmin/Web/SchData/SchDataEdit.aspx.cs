using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin.Web.SchData
{
    public partial class SchDataEdit : System.Web.UI.Page
    {
        public string dotype = "";//操作类型,修改或者是添加,a添加,e修改
        public string schid = "0";//需要建立的学校ID
        public string areastr = "";
        public string gradeyear = "";
        public string updateGrade = "";
        public string schname = "";
        public string gradecode = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            SchSystem.BLL.SchGradeInfo schgradebll = new SchSystem.BLL.SchGradeInfo();
            SchSystem.Model.SchGradeInfo schgrademodel = new SchSystem.Model.SchGradeInfo();
            dotype = Request.Params["dotype"].ToString();
            if (dotype == "e")//修改,不能修改用户的类型及学校参数
            {
                schid = Request.Params["schid"].ToString();
                schname = Request.Params["schname"].ToString();
                if (string.IsNullOrEmpty(schid))
                {
                    Response.Write("无对应修改的记录!");
                    Response.End();
                }
                string CurrentYear = "";
                //获取年份
                if (DateTime.Now.Month < 8)//当当前日期在8月份之前
                {
                    CurrentYear = (DateTime.Now.Year - 1).ToString();//系统当前年份-1
                }
                else
                {
                    CurrentYear = DateTime.Now.Year.ToString();//系统当前年份
                }
                //獲取畢業年級的年級名稱和入學年份
                DataTable dtres = schgradebll.GetListGradeFinish("GradeCode,GradeName,GradeYear", int.Parse(schid), int.Parse(CurrentYear)).Tables[0];
                updateGrade = Newtonsoft.Json.JsonConvert.SerializeObject(dtres);
            }
            else//不在添加及修改之内,则返回
            {
                Response.Write("没有可供确认的操作类型!");
                Response.End();
            }

        }
        [WebMethod]
        public static Com.DataPack.DataRsp<string> schDatasave(List<string> arr)
        {
            int schid = 0;
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            if (Com.Session.userid == null)
            {
                rsp.code = "expire";
                rsp.msg = "页面已经过期，请重新登录";
            }
            else
            {
                SchSystem.BLL.SchGradeInfo schgradebll = new SchSystem.BLL.SchGradeInfo();

                foreach (string str in arr)
                {
                    string[] strarr = str.Split('#');
                    if (strarr[0] == "schid") { schid = int.Parse(strarr[1]); }
                }
                schgradebll.SupportSysSchGradeAdd(schid);//添加年级
                rsp.code = "Success";
                rsp.msg = "升级成功";
                
            }
            return rsp;
        }


    }
}