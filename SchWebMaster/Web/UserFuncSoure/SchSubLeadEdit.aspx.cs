﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebMaster.Web.UserFuncSoure
{
    public partial class SchSubLeadEdit : System.Web.UI.Page
    {
        //进入此页需要确认的三个关键参数
        public string dotype = "";//操作类型,修改或者是添加,a添加,e修改
        public string schid = "";//需要建立的学校ID
        public string systype = "";//需要建立的用户类型,0普通用户,1学校超管,2系统超管
        public string btnname = "添加";

        public string schname = "";
        //根据上面两个参数的不同得到不同的参数
        public string umodelstr = "1";//用户model,json
        public string roles = "";//学校role和相应用户的select
        public string funcstr = "";//功能表,json
        public string depts = "";//相应学校部门及个人部门,json
        public string subs = "";//相应学校科目表及个人科目,json
        public string depart = "";
        public string schuser = "";
        //public string SubLeader = "";
        //需要根据不同情况建立或修改的不同学校用户和不同类型的用户,本学校用户唯一,不需要全系统唯一
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (true)//如果没对应权限,及判断用户类型是否跨界,主要防止非法篡改数据出现
            //{
            //    Response.Write("无对应权限");
            //    Response.End();
            //}
            if (!IsPostBack)
            {
                //不是超管获取本学校的
                if (Com.SoureSession.Souresystype != "2")
                {
                    schid = Com.SoureSession.Soureschid;
                    systype = "0";
                }
                else
                {
                    schid = Request.Params["schid"].ToString();
                    if (string.IsNullOrEmpty(schid))//如果没有对应参数中任意一个
                    {
                        Response.Write("学校ID为空或者添加的类型为空!");
                        Response.End();
                    }
                }
                SchSystem.BLL.SchSub ssBll = new SchSystem.BLL.SchSub();
                //先得到操作类型
                dotype = Com.Public.SqlEncStr(Request.Params["dotype"].ToString());
                string subid = "0";//修改时的用户ID
                string uname = "";//修改时的用户账号
                if (dotype == "e")//修改,不能修改用户的类型及学校参数
                {
                    btnname = "保存";
                    subid = Com.Public.SqlEncStr(Request.Params["subid"].ToString());
                    if (string.IsNullOrEmpty(subid))
                    {
                        Response.Write("无对应修改的用户!");
                        Response.End();
                    }
                    //获取修改的对应用户的
                    SchSystem.Model.SchSub ssModel = ssBll.GetModelSub(subid,schid);
                    if (ssModel != null && ssModel.SubId > 0)
                    {
                        umodelstr = Newtonsoft.Json.JsonConvert.SerializeObject(ssModel);
                        schid = ssModel.SchId.ToString();
                    }
                    else
                    {
                        Response.Write("无该科目!");
                        Response.End();
                    }
                }
                else//不在添加及修改之内,则返回
                {
                    Response.Write("没有可供确认的操作类型!");
                    Response.End();
                }
                //判断跨界操作的可能性
                if (!Com.Public.isVa(schid, systype))
                {
                    Response.Write("出错,用户非法跨界操作!");
                    Response.End();
                }
                #region
                SchSystem.BLL.SchInfo schbll = new SchSystem.BLL.SchInfo();
                schname = schbll.GetSchName(int.Parse(schid));
                SchSystem.BLL.SchDepartInfo sdiBll = new SchSystem.BLL.SchDepartInfo();
                //获取部门列表
                DataTable dtdpt = sdiBll.GetList("Pid pId,convert(varchar(20),DepartId) id,DepartName name,'false' checked,'true' nochecks", "SchId=" + schid + " and Stat=1 Order by OrderId").Tables[0];
                dtdpt.Columns["nochecks"].ColumnName = "nocheck";
                DataTable dtdptuser = dtdpt.Clone();
                if (dtdpt.Rows.Count > 0)
                {
                    //获取该年级组长
                    SchSystem.BLL.SchSubLeader sslBll = new SchSystem.BLL.SchSubLeader();
                    DataTable dtgradeuser = sslBll.GetList("UserName", "SubCode=" + subid).Tables[0];
                    //获取该学校的所有人员
                    SchSystem.BLL.SchUserDeptV userbll = new SchSystem.BLL.SchUserDeptV();
                    DataTable dtuser = userbll.GetList("DeptId ,UserId id,UserTname name,'false' checked,'true' nochecks", "Stat=1 and Ustat=1 and SchId=" + Com.Public.SqlEncStr(schid)).Tables[0];
                    foreach (DataRow item in dtuser.Select())
                    {
                        DataRow[] drsgrade = dtgradeuser.Select("UserName='" + item["id"].ToString() + "'");
                       
                        if (drsgrade.Length > 0)
                            item["checked"] = "true";
                        
                    }
                    //合并人员到部门表
                    /*
                    for (int i = 0; i < dtdpt.Rows.Count; i++)
                    {

                        dtdptuser.Rows.Add(dtdpt.Rows[i].ItemArray);
                        //获取该部门下的人员
                        DataRow[] drs = dtuser.Select("DeptId='" + dtdpt.Rows[i]["id"].ToString() + "'");
                        if (drs.Length > 0)
                        {
                            foreach (DataRow item in drs)
                            {
                                //如果是被绑定了,则勾选
                                DataRow[] drsgrade = dtgradeuser.Select("UserName='" + item["UserId"].ToString() + "'");
                                DataRow dr = dtdptuser.NewRow();
                                dr["id"] = "sub_" + item["UserId"].ToString();
                                dr["name"] = item["UserTname"].ToString();
                                dr["pId"] = item["DeptId"].ToString();
                                if (drsgrade.Length > 0)
                                    dr["checked"] = "true";
                                dtdptuser.Rows.Add(dr);
                            }
                        }
                    }
                    */
                    schuser = Newtonsoft.Json.JsonConvert.SerializeObject(dtuser);
                    //SubLeader = Newtonsoft.Json.JsonConvert.SerializeObject(dtgradeuser);
                }
                depart = Newtonsoft.Json.JsonConvert.SerializeObject(dtdpt);
                #endregion
            }
        }


        [WebMethod]
        public static string gradesave(string dotype, string schid, string gradename, string gradeid, string tagsusers)
        {
            dotype = Com.Public.SqlEncStr(dotype);
            schid = Com.Public.SqlEncStr(schid);
            gradename = Com.Public.SqlEncStr(gradename);//科目名称
            gradeid = Com.Public.SqlEncStr(gradeid);//科目ID
            tagsusers = Com.Public.SqlEncStr(tagsusers);//科目组长ID
            string ret = "";
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(Com.SoureSession.jsid, Com.SoureSession.jstoken);
            if (rsp.code == "ERROR_TOKEN")
            {
                ret = "expire";
            }
            else
            {
                //字符串匹配验证
                if (gradename != "")
                {
                    string PatternStr = @"^[\u4e00-\u9fa5]+$";
                    bool resultStr = Regex.IsMatch(gradename, PatternStr);
                    if (resultStr != true)
                    {
                        return ret = "只能输入中文名称";
                    }
                }
                try
                {
                    if (string.IsNullOrEmpty(schid) || schid == "0")
                        ret += "非法的学校!";
                    //SchSystem.BLL.SchGradeInfo userbll = new SchSystem.BLL.SchGradeInfo();
                    SchSystem.Model.SchSubLeader sslModel = new SchSystem.Model.SchSubLeader();
                    //SchSystem.Model.SchGradeInfo usermodel = new SchSystem.Model.SchGradeInfo();
                    sslModel.LastRecTime = DateTime.Now;
                    sslModel.LastRecUser = Com.SoureSession.Soureuserid;

                    /*
                    //判断编号及账号是否有重复,生成密码加密
                    if (dotype == "e")
                    {
                        if (userbll.ExistsGradeCode(int.Parse(gradeid), Com.Public.SqlEncStr(gradename), int.Parse(schid)))
                        {
                            ret += "年级编号重复!";
                        }

                    }
                    if (dotype == "a")
                    {
                        if (userbll.ExistsGradeCode(0, Com.Public.SqlEncStr(gradename), int.Parse(schid)))
                        {
                            ret += "年级编号重复!";
                        }
                        if (userbll.ExistsGradeCode(0, Com.Public.SqlEncStr(gradename), int.Parse(schid)))
                        {
                            ret += "年级重复!";
                        }

                    }*/
                    if (ret == "")
                    {
                        if (!Com.Public.isVa(schid, ""))
                        {
                            return ret = "无跨界权限";
                        }
                        if (schid == Com.Public.getKey("adminschid"))
                        {
                            ret = "此为系统学校,不允许操作";
                        }
                        else if (dotype == "e")
                        {
                            sslModel.SubCode = gradeid;
                            sslModel.SchId = int.Parse(schid);
                            sslModel.LastRecTime = DateTime.Now;
                            sslModel.LastRecUser = Com.SoureSession.Soureuserid;
                            //userbll.UpdateGrade(sslModel);
                        }
                        //tagsusers = Com.Public.SqlEncStr(tagsusers);
                        //添加或更新关联年级
                        SchSystem.BLL.SchSubLeader sslBll = new SchSystem.BLL.SchSubLeader();
                        //SchSystem.BLL.SchGradeUsers userdeptbll = new SchSystem.BLL.SchGradeUsers();
                        if (tagsusers == null || tagsusers == "") tagsusers = "";
                        else
                            tagsusers = "'" + tagsusers.Replace(",", "','").Replace("sub_", "") + "'";
                        sslBll.DoUserSubLeader(gradeid, Com.SoureSession.Soureuserid, schid, tagsusers);

                        ret = "success";
                    }

                }
                catch (Exception ex)
                {
                    ret = ex.Message;
                }
            }
            return ret;

        }
    }
}