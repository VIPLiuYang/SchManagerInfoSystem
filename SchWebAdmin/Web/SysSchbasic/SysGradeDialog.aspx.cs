using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin.Web.SysSchbasic
{
    public partial class SysGradeDialog : System.Web.UI.Page
    {
        public string id = "";
        public string name = "";
        public string percode = "0";
        public string percodes = "";
        public string gradecode = "";
        public string btname = "添加";
        protected void Page_Load(object sender, EventArgs e)
        {
            string SysType = Request.Params["systype"].ToString();
            SchSystem.BLL.SysGrade bll = new SchSystem.BLL.SysGrade();
            SchSystem.BLL.SysPer sysperbll = new SchSystem.BLL.SysPer();
            DataTable dt = sysperbll.GetList("PerName Name,PerCode ID", " Stat=1 Order by convert(int,PerCode)").Tables[0];
            if (SysType == "e")//修改,不能修改用户的类型及学校参数
            {
                btname = "修改";
                id = Request.Params["autoid"].ToString();
                //先得到操作类型                
                SchSystem.Model.SysGrade model = bll.GetModel(int.Parse(id));
                if (model != null && model.AutoId > 0)
                {
                    name = model.GradeName;
                    percode = model.GradeType.ToString();
                    gradecode = model.GradeCode + "(" + Com.Public.NumberToChinese(int.Parse(model.GradeCode.Substring(model.GradeCode.Length - 3))) + "年级)";
                }
                else
                {
                    Response.Write("无该名称!");
                    Response.End();
                }
            }
            else//不在添加及修改之内,则返回
            {
                if (dt.Rows.Count > 0)
                {
                    percode = dt.Rows[0]["ID"].ToString();
                }
                DataTable dtg = bll.GetList(" top 1 GradeCode", "  GradeType=" + int.Parse(percode) + " order by GradeCode desc").Tables[0];
                if (dtg != null && dtg.Rows.Count > 0)
                {
                    string Code = dtg.Rows[0]["GradeCode"].ToString().Substring(dtg.Rows[0]["GradeCode"].ToString().Length - 3);
                    string docode = percode + (int.Parse(Code) + 1).ToString("000");
                    gradecode = docode + "(" + Com.Public.NumberToChinese(int.Parse(Code) + 1) + "年级)";
                }
                else
                {
                    gradecode = percode + "001" + "(一年级)";
                }
            }
            
            if (dt.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["ID"].ToString() == percode)
                    {
                        sb.Append("<option value=\"" + dt.Rows[i]["ID"].ToString() + "\" selected=\"selected\">" + dt.Rows[i]["Name"].ToString() + "</option>");

                    }
                    else
                    {
                        sb.Append("<option value=\"" + dt.Rows[i]["ID"].ToString() + "\">" + dt.Rows[i]["Name"].ToString() + "</option>");
                    }
                    //}
                }
                percodes = sb.ToString();
            }

        }
        [WebMethod]
        public static Com.DataPack.DataRsp<string> save(string Name, string AutoId, string PerCode, string OldPerCode)
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
                    SchSystem.BLL.SysGrade bll = new SchSystem.BLL.SysGrade();
                    SchSystem.Model.SysGrade model = new SchSystem.Model.SysGrade();
                    model.GradeName = Com.Public.SqlEncStr(Name.Trim()).ToString();
                    model.GradeType = int.Parse(PerCode);
                    if (AutoId != "")//如果为修改,则判断是否更改了学段,更改学段则需要更改代码
                    {
                        model.AutoId = Convert.ToInt32(AutoId);
                        if (PerCode != OldPerCode)//更改了学段
                        {
                            DataTable dt = bll.GetList(" top 1 GradeCode", "  GradeType=" + int.Parse(PerCode) + " order by GradeCode desc").Tables[0];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                string Code = dt.Rows[0]["GradeCode"].ToString().Substring(dt.Rows[0]["GradeCode"].ToString().Length-3);
                                model.GradeCode = PerCode+(int.Parse(Code) + 1).ToString("000");
                            }
                            else
                            {
                                model.GradeCode = PerCode + "001";
                            }
                            bll.UpdateCode(model);
                        }
                        else
                        {
                            bll.Update(model);
                        }
                        rsp.code = "success";
                        rsp.msg = "修改成功";
                    }
                    else
                    {
                        DataTable dt = bll.GetList(" top 1 GradeCode", "  GradeType=" + int.Parse(PerCode) + " order by GradeCode desc").Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            string Code = dt.Rows[0]["GradeCode"].ToString().Substring(dt.Rows[0]["GradeCode"].ToString().Length - 3);
                            model.GradeCode = PerCode + (int.Parse(Code) + 1).ToString("000");
                        }
                        else
                        {
                            model.GradeCode = PerCode + "001";
                        }
                        bll.Add(model);
                        rsp.code = "success";
                        rsp.msg = "添加成功";
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

        [WebMethod]
        public static Com.DataPack.DataRsp<string> getcode(string PerCode)
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
                    SchSystem.BLL.SysGrade bll = new SchSystem.BLL.SysGrade();
                    DataTable dt = bll.GetList(" top 1 GradeCode", "  GradeType=" + int.Parse(PerCode) + " order by GradeCode desc").Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        string Code = dt.Rows[0]["GradeCode"].ToString().Substring(dt.Rows[0]["GradeCode"].ToString().Length - 3);
                        string docode = PerCode + (int.Parse(Code) + 1).ToString("000");
                        rsp.data = docode + "(" + Com.Public.NumberToChinese(int.Parse(Code) + 1) + "年级)";
                    }
                    else
                    {
                        rsp.data = PerCode + "001" + "(一年级)";
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