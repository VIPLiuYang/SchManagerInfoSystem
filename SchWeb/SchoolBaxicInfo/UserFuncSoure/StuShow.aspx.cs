using SchManagerInfoSystem.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWeb.SchoolBaxicInfo.UserFuncSoure
{
    public partial class StuShow : System.Web.UI.Page
    {
        public string umodelstr = "1";//学校model
        public static string oldClassName = "";//原班级名称
        public string Stubh;
        SchManagerInfoSystem.Common.DttoJson dttojson = new SchManagerInfoSystem.Common.DttoJson();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                string dotype = Request.Params["dotype"].ToString();
                if (dotype == "c")
                {
                    Stubh = Request.Params["Stubh"].ToString();
                    string stuid = Request.Params["id"].ToString();
                    string sql = "select * from SchStuInfoV where StuId='" + stuid + "' ";//根据学生ID查询出学校，年级，班级等信息
                    dt = DbHelperSQL.Query(sql).Tables[0];
                    DataRow[] dr = dt.Select();
                    string oldclassname = dr[0]["OldClassId"].ToString();
                    if (!string.IsNullOrEmpty(oldclassname) || oldclassname != "")
                    {
                        oldClassName = oldclassname;
                    }
                    else
                    {
                        oldClassName = "";
                    }
                    SchSystem.BLL.SchStuInfo bll_stu = new SchSystem.BLL.SchStuInfo();
                    string strWhere = " a.StuId=" + stuid;
                    DataSet ds = bll_stu.GetList(strWhere);//修改绑定需要的数据
                    ds.Tables[0].Columns.Add("jzGenName2");
                    ds.Tables[0].Columns.Add("jzLoginName2");
                    ds.Tables[0].Columns.Add("jzTelNo2");
                    ds.Tables[0].Columns.Add("jzPwd2");
                    ds.Tables[0].Columns.Add("jzStat2");
                    ds.Tables[0].Columns.Add("jzRelation2");
                    ds.Tables[0].Columns.Add("jzGenId2");
                    ds.Tables[0].Columns.Add("jzUnId2");
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            for (int j = i + 1; j < ds.Tables[0].Rows.Count; j++)
                            {
                                if (ds.Tables[0].Rows[i]["StuId"].ToString() == ds.Tables[0].Rows[j]["StuId"].ToString())
                                {
                                    ds.Tables[0].Rows[i]["jzGenName2"] = ds.Tables[0].Rows[j]["jzGenName1"].ToString();
                                    ds.Tables[0].Rows[i]["jzLoginName2"] = ds.Tables[0].Rows[j]["jzLoginName1"].ToString();
                                    ds.Tables[0].Rows[i]["jzTelNo2"] = ds.Tables[0].Rows[j]["jzTelNo1"].ToString();
                                    ds.Tables[0].Rows[i]["jzPwd2"] = ds.Tables[0].Rows[j]["jzPwd1"].ToString();
                                    ds.Tables[0].Rows[i]["jzStat2"] = ds.Tables[0].Rows[j]["jzStat1"].ToString();
                                    ds.Tables[0].Rows[i]["jzRelation2"] = ds.Tables[0].Rows[j]["jzRelation1"].ToString();
                                    ds.Tables[0].Rows[i]["jzGenId2"] = ds.Tables[0].Rows[j]["jzGenId1"].ToString();
                                    ds.Tables[0].Rows[i]["jzUnId2"] = ds.Tables[0].Rows[j]["jzUnId1"].ToString();
                                    ds.Tables[0].Rows.RemoveAt(j);
                                }
                            }
                        }
                    }
                    umodelstr = dttojson.DatSetToJSON2(ds); ;
                }
            }
        }
    }
}