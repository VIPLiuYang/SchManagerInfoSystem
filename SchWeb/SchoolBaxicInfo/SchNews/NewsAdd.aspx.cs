using Newtonsoft.Json;
using SchWeb.Com;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWeb.SchoolBaxicInfo.SchNews
{
    public partial class NewsAdd : System.Web.UI.Page
    {
        public string chndrp = "";
        public static string SchId = "";
        public static string NewsCope = "";
        public static string NewsCopeDrp = "";
        public static string NewsCopeDrpClass = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            SchId = Com.Session.schid;
            //栏目初始化
            chndrp = Com.Public.GetDrp("chn", Com.Session.schid, "1", false, "", "");
            string newlv = "";
            //範圍
            NewsCope = Public.NewsCope("",ref newlv);
            string selg = "";
            string selc = "";
            if (newlv == "1")//第一个选中的是年级类型,则获取能发的年级
            {               
                //年级
                NewsCopeDrp = Public.NewsCopeDrp("", 1, newlv,"", ref selg);
            }
            else if (newlv == "0")//选中的是班级
            {
                //年级
                NewsCopeDrp = Public.NewsCopeDrp("", 1, newlv,"", ref selg);

                //班级
                NewsCopeDrpClass = Public.NewsCopeDrp(selg, 0, newlv,"", ref selc);
            }

        }

        [WebMethod]
        public static Com.DataPack.DataRsp<string> newsaddsave(string arr)
        {
            SchSystem.Model.WebSchNews schnewsmodel = new SchSystem.Model.WebSchNews();
            SchSystem.BLL.WebSchNews schnewsbll = new SchSystem.BLL.WebSchNews();
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
                    schnews newsresult = JsonConvert.DeserializeObject<schnews>(arr);
                    if (newsresult.range == "0" && newsresult.gradeid == "")
                    {
                        rsp.code = "ExcepError";
                        rsp.msg = "年级不允许为空";
                        return rsp;
                    }
                    if (newsresult.range == "0" && newsresult.grdclassid == "")
                    {
                        rsp.code = "ExcepError";
                        rsp.msg = "班级不允许为空";
                        return rsp;
                    }
                    if (newsresult.range == "1" && newsresult.gradeid == "")
                    {
                        rsp.code = "ExcepError";
                        rsp.msg = "年级不允许为空";
                        return rsp;
                    }
                    string sss = newsresult.title;
                    schnewsmodel.Topic = newsresult.title;//標題
                    schnewsmodel.ChnId = int.Parse(newsresult.column);//欄目
                    schnewsmodel.Lv = int.Parse(newsresult.range);//範圍
                    if ((newsresult.range == "1" || newsresult.range == "0" )&& !string.IsNullOrEmpty(newsresult.gradeid))//年級ID
                    {
                        schnewsmodel.GradeId = int.Parse(newsresult.gradeid);
                    }
                    if (newsresult.range=="0"&&!string.IsNullOrEmpty(newsresult.grdclassid))//班級ID
                    {
                        schnewsmodel.ClassId = int.Parse(newsresult.grdclassid);
                    }
                    StringBuilder sbContent = new StringBuilder();
                    string contents = newsresult.content;
                    if (!string.IsNullOrEmpty(contents))
                    {
                        string[] contentarr = contents.Split('|');
                        int contentslen = contentarr.Length;
                        for (int i = 0; i < contentslen; i++)
                        {
                            string[] contarr = contentarr[i].Split(',');
                            sbContent.Append("<section><p class=\"paragraph\">" + contarr[0] + "</p><p class=\"picture\"><img src=\"" + contarr[1] + "\" alt=\"\" /></p></section>");
                        }
                        schnewsmodel.Content = sbContent.ToString();//內容
                    }

                    if (newsresult.encs.Count > 0)//附件
                    {
                        schnewsmodel.IsEnc = 1;
                        schnewsmodel.Imgurl = newsresult.encs[0].imgurl;
                    }

                    if(newsresult.isreference=="True")//是否引用
                    {
                        schnewsmodel.IsQuo = 1;
                        schnewsmodel.QuoUrl = newsresult.textreference;//引用地址
                    }
                    else
                    {
                        schnewsmodel.IsQuo = 0;
                    }
                    if (newsresult.isreply == "True")//是否回復
                    {
                        schnewsmodel.IsReply = 1;
                    }
                    else
                    {
                        schnewsmodel.IsReply = 0;
                    }
                    schnewsmodel.SchId = int.Parse(SchId);
                    schnewsmodel.RecTime = DateTime.Now;
                    schnewsmodel.RecIP = Public.GetLocalIP().RspData;
                    schnewsmodel.Stat = 1;
                    schnewsmodel.Clicked = 0;
                    schnewsmodel.ChkTime = DateTime.Now;

                    int resid = schnewsbll.Add(schnewsmodel);//添加新闻
                    if (resid > 0)
                    {
                        SchSystem.Model.WebSchNewsEnc schnewencModel = new SchSystem.Model.WebSchNewsEnc();
                        SchSystem.BLL.WebSchNewsEnc schnewencBll = new SchSystem.BLL.WebSchNewsEnc();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("NewsId");
                        dt.Columns.Add("OldName");
                        dt.Columns.Add("NewName");
                        dt.Columns.Add("SaveUrl");
                        dt.Columns.Add("Clicked");
                        dt.Columns.Add("RecTime");
                        dt.Columns.Add("RecIP");
                        dt.Columns.Add("FileSize");
                        dt.Columns.Add("ImgUrl");
                        int encCount = newsresult.encs.Count;
                        for (int i = 0; i < encCount; i++)
                        {
                            DataRow dr = dt.NewRow();
                            dr["NewsId"] = resid;
                            dr["OldName"] = newsresult.encs[i].oldname;
                            dr["NewName"] = newsresult.encs[i].newname;
                            dr["SaveUrl"] = newsresult.encs[i].saveurl;
                            dr["Clicked"] = 1;
                            dr["RecTime"] = DateTime.Now;
                            dr["RecIP"] = Public.GetLocalIP().RspData;
                            dr["FileSize"] = int.Parse(newsresult.encs[i].filesize);
                            dr["ImgUrl"] = newsresult.encs[i].imgurl;
                            dt.Rows.Add(dr);
                        }
                        rsp.code = "success";
                        rsp.msg = schnewencBll.ExecuteSqlBulkCopy(dt, "WebSchNewsEnc");//添加附件
                    }

                }
                catch (Exception ex)
                {
                    rsp.code = "ExcepError";
                    rsp.msg = ex.Message;
                }
            }
            return rsp;
        }

        [WebMethod]
        public static Com.DataPack.DataRsp<string> getclass(string gradeid,string newlv,int lv)
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
                    string selv = "";
                    rsp.RspData = Public.NewsCopeDrp(gradeid, lv, newlv,"", ref selv);
                }
                catch (Exception ex)
                {
                    rsp.code = "ExcepError";
                    rsp.msg = ex.Message;
                }
            }
            return rsp;
        }
        
    }
}