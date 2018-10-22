using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin.Web.SysSchbasic
{
    public partial class SysPerA : System.Web.UI.Page
    {
        public string id = "";
        public string code = "";
        public string name = "";
        public string stat = "";
        public string grademodelstr = "";//年级信息
        public string btname = "添加";
        public string year = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            string SysType = Com.Public.SqlEncStr(Request.Params["systype"].ToString());//先得到操作类型
            SchSystem.BLL.SysPer bll = new SchSystem.BLL.SysPer();
            if (SysType == "e")//修改
            {
                btname = "修改";
                id = Request.Params["id"].ToString();
                
                SchSystem.Model.SysPer model = bll.GetModel(int.Parse(id));
                if (model != null)
                {
                    code = model.PerCode;
                    name = model.PerName;
                    stat = model.Stat.ToString();
                    year = model.PerYear.ToString();
                    SchSystem.BLL.SysGrade bllgrade = new SchSystem.BLL.SysGrade();
                    string srtWhere = "GradeType=" + Convert.ToInt32(model.PerCode) + " order by convert(int,GradeCode)";
                    DataTable dt = bllgrade.GetList("AutoId as id,GradeName as name,'true' checked,GradeType", srtWhere).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            grademodelstr += dt.Rows[i]["name"].ToString()+"|";
                        }
                        grademodelstr = grademodelstr.Remove(grademodelstr.Length - 1);
                    }
                }
                else
                {

                    Response.Write("无该名称!");
                    Response.End();
                }
            }
            else
            {
                DataTable dt = bll.GetList(" top 1 PerCode", "  1=1 order by convert(int,PerCode) desc").Tables[0];

                if (dt != null && dt.Rows.Count > 0)
                {
                    string Code = dt.Rows[0]["PerCode"].ToString();
                    code = (int.Parse(Code) + 1).ToString("0");
                }
                else
                {
                    code = "1";
                }
            }


        }
        [WebMethod]
        public static Com.DataPack.DataRsp<string> save(string Name, string GradeNames,string Year,string Code, string stat, string AutoId)
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
                    SchSystem.BLL.SysPer SysPer_bll = new SchSystem.BLL.SysPer();
                    SchSystem.Model.SysPer SysPer_model = new SchSystem.Model.SysPer();
                    SysPer_model.PerName = Com.Public.SqlEncStr(Name).ToString();
                    SysPer_model.Stat = Convert.ToInt32(Com.Public.SqlEncStr(stat));
                    SysPer_model.PerYear = int.Parse(Year);
                    SchSystem.BLL.SysGrade bll = new SchSystem.BLL.SysGrade();
                    SchSystem.Model.SysGrade model = new SchSystem.Model.SysGrade();
                    if (AutoId != "")
                    {
                        SysPer_model.AutoId = int.Parse(AutoId);
                        if (SysPer_bll.Update(SysPer_model))
                        {
                            //删除对应年级,再重新建
                            bll.DeleteList(Com.Public.SqlEncStr(Code));

                            //修改年级
                            string[] grades = GradeNames.Split('|');
                            if (grades.Length > 0)
                            {
                                
                                for (int i = 0; i < grades.Length; i++)
                                {

                                    model.GradeName = Com.Public.SqlEncStr(grades[i]).ToString();
                                    model.GradeType = int.Parse(Code);
                                    model.GradeCode = Code + (i + 1).ToString("000");
                                    bll.Add(model);
                                }
                            }
                            rsp.code = "success";
                            rsp.msg = "修改成功";
                        }
                    }
                    else
                    {
                        DataTable dt = SysPer_bll.GetList(" top 1 PerCode", "  1=1 order by convert(int,PerCode) desc").Tables[0];

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            string iCode = dt.Rows[0]["PerCode"].ToString();
                            SysPer_model.PerCode = (int.Parse(iCode) + 1).ToString("0");
                        }
                        else
                        {
                            SysPer_model.PerCode = "1";
                        }
                        int perid = SysPer_bll.Add(SysPer_model);
                        if (perid > 0)
                        {
                            //添加年级
                            string[] grades = GradeNames.Split('|');
                            if (grades.Length > 0)
                            {
                                for (int i = 0; i < grades.Length; i++)
                                {
                                    model.GradeName = Com.Public.SqlEncStr(grades[i]).ToString();
                                    model.GradeType = int.Parse(SysPer_model.PerCode);
                                    model.GradeCode = SysPer_model.PerCode + (i + 1).ToString("000");
                                    bll.Add(model);
                                }
                            }
                            rsp.code = "success";
                            rsp.msg = "添加成功";
                        }

                    }
                }
                catch (Exception ex)
                {
                    rsp.code = "error";
                    rsp.msg = ex.Message;
                }
            }
            return rsp;

        }
    }
}