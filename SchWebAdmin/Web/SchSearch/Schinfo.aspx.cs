using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebAdmin.Web.SchSearch
{
    public partial class Schinfo : System.Web.UI.Page
    {
        public string dotype = "";//操作类型,修改或者是添加,a添加,e修改
        public string schid = "0";//需要建立的学校ID
        public string areastr = "";
        public string grades = "";//系统年级
        public string subs = "";//系统科目
        public string sonsys = "";//子系统选择
        public string umodelstr = "1";//学校model
        public string subsmat = "";
        public string sysmatertree = "";
        public string souretree = "";
        public string showmatertree = "";
        public string sarxxttree = "";
        public string showmaterxxttree = "";
        public string usermanagerstr = "";
        public string updateGrade = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Params["schid"] != null && Request.Params["schid"].ToString() != "")
            {
                string schid = Com.Public.SqlEncStr(Request.Params["schid"].ToString());
                //先得到操作类型
                SchSystem.BLL.SchInfo schbll = new SchSystem.BLL.SchInfo();
                SchSystem.Model.SchInfo usermodel = new SchSystem.Model.SchInfo();


                if (string.IsNullOrEmpty(schid))
                {
                    Response.Write("无对应修改的记录!");
                    Response.End();
                }
                //获取修改的对应用户的
                usermodel = schbll.GetSupportModel(int.Parse(schid));
                if (usermodel != null && usermodel.SchId > 0)
                {
                    umodelstr = Newtonsoft.Json.JsonConvert.SerializeObject(usermodel);
                }
                else
                {
                    Response.Write("无该学校!");
                    Response.End();
                }


                if (!string.IsNullOrEmpty(schid))
                {
                    //获取管理员账号密码信息
                    SchSystem.BLL.SchUserInfo suiBll = new SchSystem.BLL.SchUserInfo();
                    SchSystem.Model.SchUserInfo modeluserinfo = suiBll.GetSupportModel(int.Parse(schid), 1);
                    if (modeluserinfo != null)
                    {
                        if (modeluserinfo.PassWord == Com.Public.StrToMD5("123456"))
                        {
                            modeluserinfo.PassWord = "1";
                        }
                    }
                    usermanagerstr = Newtonsoft.Json.JsonConvert.SerializeObject(modeluserinfo);
                    //系统科目
                    SchSystem.BLL.SysSub syssubbll = new SchSystem.BLL.SysSub();
                    DataTable dtsub = syssubbll.GetList("'0' pId,SubCode id,SubName name,'false' checked", " 1=1 Order by SubCode").Tables[0];//Stat=1 
                    //获取学校的sub
                    SchSystem.BLL.SchSub schsubbll = new SchSystem.BLL.SchSub();
                    DataTable dtschsub = schsubbll.GetList("'0' pId,SubCode id,SubName name,'false' checked", "Stat=1 and SchId='" + schid + "' Order by SubCode").Tables[0];
                    DataTable dtsubmat = dtsub.Copy();
                    if (dtsub != null && dtschsub != null && dtsub.Rows.Count > 0 && dtschsub.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtsub.Rows.Count; i++)
                        {
                            DataRow[] drs = dtschsub.Select("id='" + dtsub.Rows[i]["id"].ToString() + "'");
                            if (drs.Length > 0)
                            {
                                dtsub.Rows[i]["checked"] = "true";
                            }
                        }
                    }
                    subs = Newtonsoft.Json.JsonConvert.SerializeObject(dtsub);
                    subsmat = Newtonsoft.Json.JsonConvert.SerializeObject(dtsubmat);
                    //获取子系统:AutoId,AppCode,AppName,Stat,RecTime,RecUser,LastRecTime,LastRecUser
                    SchSystem.BLL.SchApp schappBll = new SchSystem.BLL.SchApp();
                    DataTable dtschapp = schappBll.GetList("'0' pId,AutoId id,AppName name,'false' checked,AppCode", "").Tables[0];
                    SchSystem.BLL.SchAppRole schapproleBll = new SchSystem.BLL.SchAppRole();
                    DataTable dtschapprole = schapproleBll.GetList("SchId='" + schid + "'").Tables[0];
                    if (dtschapp.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtschapp.Rows.Count; i++)
                        {
                            DataRow[] drstr = dtschapprole.Select();
                            if (drstr.Length > 0)
                            {
                                string approlestr = drstr[0]["AppStr"].ToString();
                                string[] approlearr = approlestr.Split(',');
                                int approlearrlen = approlearr.Length;
                                for (int j = 0; j < approlearrlen; j++)
                                {
                                    if (dtschapp.Rows[i]["AppCode"].ToString() == approlearr[j])
                                    {
                                        dtschapp.Rows[i]["checked"] = "true";
                                    }
                                }
                            }
                        }
                    }
                    sonsys = Newtonsoft.Json.JsonConvert.SerializeObject(dtschapp);

                    //获取整个系统的年级
                    SchSystem.BLL.SysGrade sysgradebll = new SchSystem.BLL.SysGrade();
                    DataTable dtgrade = sysgradebll.GetList("GradeType pId,GradeCode id,GradeName name,'false' checked,'false' nochecks,'0' IsFinish,'' GradeYear,'' GradeId", " GradeCode<>'3004' and GradeCode<>'4004' Order by GradeType,GradeLv").Tables[0];
                    #region 家校互通平台子模块
                    SchSystem.BLL.SchAppXXT saxxtBll = new SchSystem.BLL.SchAppXXT();
                    DataTable dtsaxxt = saxxtBll.GetList("'0' pId,AppCode id,AppName name,'false' checked,'false' isShar", "Stat=1").Tables[0];
                    SchSystem.BLL.SchAppRoleXXT sarxxtBll = new SchSystem.BLL.SchAppRoleXXT();
                    DataTable dtsarxxt = sarxxtBll.GetList("SchId='" + schid + "'").Tables[0];
                    DataRow[] drsarxxt = dtsarxxt.Select();
                    string[] approlexxtarr = { };
                    if (drsarxxt.Length > 0)
                    {
                        approlexxtarr = drsarxxt[0]["AppStr"].ToString().Split(',');
                        if (dtsaxxt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtsaxxt.Rows.Count; i++)
                            {
                                for (int j = 0; j < approlexxtarr.Length; j++)
                                {
                                    if (dtsaxxt.Rows[i]["id"].ToString() == approlexxtarr[j].ToString())
                                    {
                                        dtsaxxt.Rows[i]["checked"] = "true";
                                    }
                                }
                            }
                        }

                    }
                    sarxxttree = Newtonsoft.Json.JsonConvert.SerializeObject(dtsaxxt);
                    #endregion
                    //家校互通平台学段、科目教版
                    SchSystem.BLL.SchPerSubMatXXT spsmxxtBll = new SchSystem.BLL.SchPerSubMatXXT();
                    DataTable dtspsmxxt = spsmxxtBll.SchPerSubMatXXTV("SchId='" + schid + "' Order by convert(int,PerCode) asc").Tables[0];
                    showmaterxxttree = Newtonsoft.Json.JsonConvert.SerializeObject(dtspsmxxt);

                    //获取学校的年级
                    SchSystem.BLL.SchGradeInfo schgradebll = new SchSystem.BLL.SchGradeInfo();
                    DataTable dtschgrade = schgradebll.GetList("GradeCode id,GradeYear,GradeId", "isfinish='0' and SchId='" + schid + "'").Tables[0];

                    dtgrade.Columns["nochecks"].ColumnName = "nocheck";
                    DataRow dry = dtgrade.NewRow();
                    dry["pId"] = "0";
                    dry["id"] = "1";
                    dry["name"] = "幼儿园";
                    dry["nocheck"] = "false";
                    dry["IsFinish"] = "0";
                    dtgrade.Rows.Add(dry);
                    dry = dtgrade.NewRow();
                    dry["pId"] = "0";
                    dry["id"] = "2";
                    dry["name"] = "小学";
                    dry["nocheck"] = "false";
                    dry["IsFinish"] = "0";
                    dtgrade.Rows.Add(dry);
                    dry = dtgrade.NewRow();
                    dry["pId"] = "0";
                    dry["id"] = "3";
                    dry["name"] = "初中";
                    dry["nocheck"] = "false";
                    dry["IsFinish"] = "0";
                    dtgrade.Rows.Add(dry);
                    dry = dtgrade.NewRow();
                    dry["pId"] = "0";
                    dry["id"] = "4";
                    dry["name"] = "高中";
                    dry["nocheck"] = "false";
                    dry["IsFinish"] = "0";
                    dtgrade.Rows.Add(dry);

                    if (dtgrade != null && dtschgrade != null && dtgrade.Rows.Count > 0 && dtschgrade.Rows.Count > 0)//系统年级和学校年级不等于null
                    {
                        for (int i = 0; i < dtgrade.Rows.Count; i++)//遍历实体年级行数
                        {
                            DataRow[] drs = dtschgrade.Select("id='" + dtgrade.Rows[i]["id"].ToString() + "'");//根据系统年级id查询学校年级
                            if (drs.Length > 0)
                            {
                                dtgrade.Rows[i]["checked"] = "true";
                                dtgrade.Rows[i]["GradeYear"] = drs[0]["GradeYear"];
                                dtgrade.Rows[i]["GradeId"] = drs[0]["GradeId"];
                            }
                        }
                    }

                    //獲取畢業年級的年級名稱和入學年份
                    //DataTable dtres = schgradebll.GetListGradeFinish("GradeCode,GradeName,GradeYear", int.Parse(schid), int.Parse(CurrentYear)).Tables[0];
                    DataTable dtres = schgradebll.Graduated(int.Parse(schid)).Tables[0];
                    updateGrade = Newtonsoft.Json.JsonConvert.SerializeObject(dtres);

                    //获取服务资源:AutoId,AppCode,AppName,Stat,RecTime,RecUser,LastRecTime,LastRecUser
                    #region 获取服务资源
                    SchSystem.BLL.SchAppSoure schappsoureBll = new SchSystem.BLL.SchAppSoure();
                    DataTable dtschappsoure = schappsoureBll.GetList("'0' pId,AppCode id,AppName name,'false' checked,'false' isShar", "Stat=1").Tables[0];
                    SchSystem.BLL.SchAppRoleSoure sarsBll = new SchSystem.BLL.SchAppRoleSoure();
                    DataTable dtsars = sarsBll.GetList("SchId='" + schid + "'").Tables[0];
                    DataRow[] drsarsstr = dtsars.Select();
                    string[] approlesourearr = null;
                    if (drsarsstr.Length > 0)
                    {
                        string appcodestr = drsarsstr[0]["AppCode"].ToString();
                        if (!string.IsNullOrEmpty(appcodestr))
                        {
                            approlesourearr = drsarsstr[0]["AppCode"].ToString().Split('|');
                        }
                        else
                        {
                            approlesourearr = null;
                        }
                    }
                    if (dtschappsoure.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtschappsoure.Rows.Count; i++)
                        {
                            //dtschappsoure.Rows[i]["name"] = dtschappsoure.Rows[i]["name"] + "【不共享】";
                            if (approlesourearr != null)
                            {
                                for (int j = 0; j < approlesourearr.Length; j++)
                                {
                                    if (approlesourearr[j].Split(',').Length > 0)
                                    {
                                        string appsourestr = approlesourearr[j].Split(',')[0];
                                        string appsourestat = approlesourearr[j].Split(',')[1];
                                        if (dtschappsoure.Rows[i]["id"].ToString() == appsourestr)
                                        {
                                            if (appsourestat == "1")
                                            {
                                                dtschappsoure.Rows[i]["name"] = dtschappsoure.Rows[i]["name"] + "【共享】";
                                                //dtschappsoure.Rows[i]["isShar"] = "true";
                                            }
                                            else if (appsourestat == "0")
                                            {
                                                dtschappsoure.Rows[i]["name"] = dtschappsoure.Rows[i]["name"] + "【不共享】";
                                                //dtschappsoure.Rows[i]["isShar"] = "false";
                                            }
                                            dtschappsoure.Rows[i]["checked"] = "true";
                                        }
                                    }
                                }
                            }
                            if (dtschappsoure.Rows[i]["checked"].ToString() == "false")
                            {
                                dtschappsoure.Rows[i]["name"] = dtschappsoure.Rows[i]["name"] + "【不共享】";
                                //dtschappsoure.Rows[i]["isShar"] = "false";
                            }
                        }
                    }
                    souretree = Newtonsoft.Json.JsonConvert.SerializeObject(dtschappsoure);
                    #endregion
                    //获取教版
                    SchSystem.BLL.SysMater smaterBll = new SchSystem.BLL.SysMater();
                    DataTable dtsmater = smaterBll.GetList("'0' pId,MaterCode id,MaterName name,'false' checked,'' subcodechk,MaterCode,'' PerCode,'' SubCode,'' SubName", "Stat=1").Tables[0];
                    SchSystem.BLL.SchPerSubMat spsmBll = new SchSystem.BLL.SchPerSubMat();
                    DataTable dtspsm = spsmBll.SchPerSubMatVMatSub("SchId='" + schid + "' Order by convert(int,PerCode) asc").Tables[0];
                    //if (dtsmater.Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < dtsmater.Rows.Count; i++)
                    //    {
                    //        foreach (DataRow dr in dtspsm.Rows)
                    //        {
                    //            string ss = dtsmater.Rows[i]["MaterCode"].ToString();
                    //            string sss = dr["MaterCode"].ToString();
                    //            if (dtsmater.Rows[i]["MaterCode"].ToString() == dr["MaterCode"].ToString())
                    //            {
                    //                dtsmater.Rows[i]["checked"] = "true";
                    //                dtsmater.Rows[i]["PerCode"] = dr["PerCode"];
                    //                dtsmater.Rows[i]["SubCode"] = dr["SubCode"];
                    //                dtsmater.Rows[i]["SubName"] = dr["SubName"];
                    //            }
                    //        }
                    //    }
                    //}
                    sysmatertree = Newtonsoft.Json.JsonConvert.SerializeObject(dtsmater);
                    showmatertree = Newtonsoft.Json.JsonConvert.SerializeObject(dtspsm);


                    grades = Newtonsoft.Json.JsonConvert.SerializeObject(dtgrade);
                    //获取下拉列表
                    StringBuilder sbarea = new StringBuilder();
                    string[] areanames = Com.Public.GetArea(usermodel.AreaNo.ToString()).Split('|');
                    sbarea.Append(areanames[0]);
                    sbarea.Append(areanames[1]);
                    sbarea.Append(areanames[2]);
                    areastr = sbarea.ToString();
                }




            }
        }

    }
}