using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace SchWeb.SchoolBaxicInfo.GradeClassSet.ashx
{
    /// <summary>
    /// GradeClassSet 的摘要说明
    /// </summary>
    public class GradeClassSet : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string Action = context.Request.Form["Action"];
            string SchId =context.Request.Form["SchId"];
            if (string.IsNullOrEmpty(SchId))
                SchId = "0";
            else
                SchId = Com.Public.SqlEncStr(SchId);


            if (Action == "GradeClassInfo")
            {
                //年级
                SchSystem.BLL.SchGradeInfo sgiBLL = new SchSystem.BLL.SchGradeInfo();
                DataTable dt = sgiBLL.GetList(" IsFinish=0 and SchId=" + SchId + " order by GradeCode").Tables[0];//得到年级数据列表,并且是为非毕业的年级
                //年级领导
                SchSystem.BLL.SchGradeUsers sguBLL = new SchSystem.BLL.SchGradeUsers();
                dt.Columns.Add("GradeBoss");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["GradeBoss"] = sguBLL.GetNames("GradeId=" + dt.Rows[i]["GradeId"].ToString());
                    }
                }
                context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(dt));

            }
            /*if (Action == "GradeClassList")
            {
                //string UserId = Com.Session.userid;//获取session中的username

                //int SchId = int.Parse(Com.Session.schid);//获取session中的schid

                SchSystem.BLL.SchUserInfo suiBll = new SchSystem.BLL.SchUserInfo();
                DataSet UserDs = suiBll.GetList("*", "Stat=1 and SchId=" + SchId);//获取当前学校的用户
                string UserStr = SchManagerInfoSystem.Common.Function.DatSetToJSON2(UserDs, "UserRows");

                StringBuilder sb = new StringBuilder();
                sb.Append("{");
                sb.Append(UserStr);
                sb.Append("}");
                context.Response.Write(sb.ToString());
            }
            else if (Action == "GradeEdit")
            {
                int GradeId = int.Parse(context.Request.Form["GradeId"]);
                string nameval = context.Request.Form["name"];
                nameval = nameval.Substring(0, nameval.Length - 1);
                string[] NameArr = nameval.Split(',');
                int NameArrLenght = NameArr.Length;

                SchSystem.BLL.SchGradeUsers sguBll = new SchSystem.BLL.SchGradeUsers();
                //先删除原有年级领导，仅供测试之用
                DataSet ds = sguBll.GetList("AutoId","GradeId="+GradeId);
                
                StringBuilder sb = new StringBuilder();
                 //遍历一个表多行多列
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        sb.Append(row[0].ToString() + ",");
                    }
                    string str = sb.ToString();
                    str = str.Substring(0, str.Length - 1);
                    sguBll.DeleteList(str);
                }
                //下面的少量数据批量插入数据，仅供测试之用
                int iStr = 0;
                for (int i=0; i < NameArrLenght; i++)
                {
                    SchSystem.Model.SchGradeUsers sgi = new SchSystem.Model.SchGradeUsers();
                    sgi.GradeId = GradeId;
                    sgi.UserName = NameArr[i];
                    sgi.UserTname = NameArr[i];
                    iStr = sguBll.Add(sgi);
                }
                if(iStr>=0)
                    context.Response.Write("1");
                else
                    context.Response.Write("0");
            }*/
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}