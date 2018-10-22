using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWeb.SchoolBaxicInfo.SchNews
{
    public partial class NewsList : System.Web.UI.Page
    {
        public string chndrp = "";
        public string newstype = "";
        public bool isadd=false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Com.Session.appeditstat == "1")// && Com.Session.systype == "1"
            {
                isadd = true;
            }
            chndrp = Com.Public.GetDrp("chn", Com.Session.schid, "1", true, "", "");
            string newlv = "";
            newstype = Com.Public.NewsCope("",ref newlv);
        }
        [WebMethod]
        public static Com.DataPack.DataRsp<string> page(string PageIndex, string PageSize, string txtname, string ustat, string txtcode, string drptype)
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
                    //Stat:0废弃,1正常,2被删除,正常界面不显示删除,超管界面可以考虑
                    string strwhere = "Stat<2 and SchId='" + Com.Session.schid + "' ";

                    if (!string.IsNullOrEmpty(txtname))
                    {
                        strwhere += " and Topic like '%" + Com.Public.SqlEncStr(txtname) + "%'";
                    }
                    if (!string.IsNullOrEmpty(ustat))
                    {
                        strwhere += " and Stat='" + Com.Public.SqlEncStr(ustat) + "'";
                    }
                    if (txtcode!="0")
                    {
                        strwhere += " and ChnId='" + Com.Public.SqlEncStr(txtcode) + "'";
                    }
                    if (drptype != "")
                    {
                        strwhere += " and Lv='" + Com.Public.SqlEncStr(drptype) + "'";
                    }
                    Com.Public.PageModelResp pages = new Com.Public.PageModelResp();
                    pages.PageIndex = int.Parse(PageIndex);
                    pages.PageSize = int.Parse(PageSize);
                    int rowc = 0;
                    int pc = 0;
                    SchSystem.BLL.WebSchChnNewsV userbll = new SchSystem.BLL.WebSchChnNewsV();
                    string dbcols = "NewsId,ChnName,ChnId,Topic,RecTime,GradeId,ClassId,Lv,'' GradeName,'' ClassName,'' LvName,'0' isdel,'0' isedit,'1' islook,Stat,IsTop";
                    DataTable dt = userbll.GetListCols(dbcols, strwhere, "IsTop Desc,RecTime DESC", "", pages.PageIndex, pages.PageSize, ref rowc, ref pc).Tables[0];
                    pages.PageCount = pc;
                    pages.RowCount = rowc;
                    if (dt.Rows.Count > 0)
                    {
                        SchSystem.BLL.SchClassUser bllclassuser = new SchSystem.BLL.SchClassUser();
                        SchSystem.BLL.SchGradeUsers bllgradeuser = new SchSystem.BLL.SchGradeUsers();
                        SchSystem.BLL.SchClassInfo bllclass=new SchSystem.BLL.SchClassInfo();
                        SchSystem.BLL.SchGradeInfo bllgrade=new SchSystem.BLL.SchGradeInfo();
                        //权限
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            if (Com.Session.appeditstat == "1")//允许编辑
                            {
                                if (dt.Rows[i]["Lv"].ToString() == "0")//班级新闻
                                {
                                    if (Com.Public.IsUserVal(Com.Session.userrolestr, 14)||bllclassuser.ExistsIsMs(dt.Rows[i]["ClassId"].ToString(), Com.Session.usertid, Com.Session.schid, 1) == true)//如果有所有班级权限或是班主任
                                    {
                                        dt.Rows[i]["isdel"] = "1";
                                        dt.Rows[i]["isedit"] = "1";
                                    }
                                    //获取年级,班级,类型
                                    dt.Rows[i]["GradeName"] = bllgrade.GetName(int.Parse(dt.Rows[i]["GradeId"].ToString()));
                                    dt.Rows[i]["ClassName"] = bllclass.GetName(int.Parse(dt.Rows[i]["ClassId"].ToString()));
                                    dt.Rows[i]["LvName"] ="班级";
                                }
                                else if (dt.Rows[i]["Lv"].ToString() == "1")//年级新闻
                                {
                                    if (Com.Public.IsUserVal(Com.Session.userrolestr, 13)||bllgradeuser.ExistsGrade(dt.Rows[i]["GradeId"].ToString(), Com.Session.schid, Com.Session.usertid) == true)//如果有全校权限或是年级组长
                                    {
                                        dt.Rows[i]["isdel"] = "1";
                                        dt.Rows[i]["isedit"] = "1";
                                    }
                                    //获取年级
                                    dt.Rows[i]["GradeName"] = bllgrade.GetName(int.Parse(dt.Rows[i]["GradeId"].ToString()));
                                    dt.Rows[i]["LvName"] = "年级";
                                }
                                else if (dt.Rows[i]["Lv"].ToString() == "2")//学校新闻
                                {
                                    if (Com.Public.IsUserVal(Com.Session.userrolestr, 13))//如果有全校权限
                                    {
                                        dt.Rows[i]["isdel"] = "1";
                                        dt.Rows[i]["isedit"] = "1";
                                    }
                                    dt.Rows[i]["LvName"] = "学校";
                                }
                            }
                        }
                        pages.list = dt;
                    }
                    rsp.RspData = Newtonsoft.Json.JsonConvert.SerializeObject(pages).Replace("\n\r", "");
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
        public static Com.DataPack.DataRsp<string> udel(string id,string stat)
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
                    bool rel = false;
                    SchSystem.BLL.WebSchNews schnewsbll = new SchSystem.BLL.WebSchNews();
                    if (stat == "1" || stat == "2" || stat == "0")
                    {
                        rel = schnewsbll.Update(int.Parse(id), int.Parse(stat));//软删除
                    }
                    else
                    {
                        if (stat == "5")
                        {
                            stat = "1";
                        }
                        else
                        {
                            stat = "0";
                        }
                        rel = schnewsbll.UpdateIsTop(int.Parse(id), int.Parse(stat));//软删除
                    }
                    if (!rel)
                    {
                        rsp.code = "error";
                        rsp.msg = "操作失败";
                    }
                    else
                    {
                        rsp.code = "success";
                        rsp.msg = "操作成功";
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