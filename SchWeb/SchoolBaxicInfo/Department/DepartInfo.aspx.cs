using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWeb.SchoolBaxicInfo.Department
{
    public partial class DepartInfo : System.Web.UI.Page
    {
        public string areastr = "";
        public string uschid = "0";
        public string cotycode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //不是超管获取本学校的
                if (Com.Session.systype != "2")
                {
                    uschid = Com.Session.schid;
                }
                else//超管还要加省市区学校下拉,后面需要更改
                {
                    //第一次加载,获取省市区,获取第一个省份下的所有学校
                    StringBuilder sbarea = new StringBuilder();
                    //获取省份
                    sbarea.Append("省:<select id=\"aprov\">");
                    string sareacode = "";
                    sbarea.Append(Com.Public.GetDrpArea("0", "", ref sareacode, false));
                    sbarea.Append("</select>");
                    //获取城市
                    sbarea.Append("市:<select id=\"acity\">");
                    string sareacitycode = "";
                    sbarea.Append(Com.Public.GetDrpArea("1", sareacode, ref sareacitycode, false));
                    sbarea.Append("</select>");
                    //获取区县
                    sbarea.Append("区:<select id=\"acoty\">");
                    string sareacotycode = "";
                    sbarea.Append(Com.Public.GetDrpArea("2", sareacitycode, ref sareacotycode, false));
                    cotycode = sareacotycode;
                    sbarea.Append("</select>");
                    sbarea.Append("学校:<select id=\"asch\">");
                    string sareaschid = "";
                    sbarea.Append(Com.Public.GetDrpArea("3", sareacotycode, ref sareaschid, false));
                    if (sareaschid != "")
                    {
                        uschid = sareaschid;
                    }
                    sbarea.Append("</select>");
                    areastr = sbarea.ToString();
                }

            }
        }

        [WebMethod]
        public static string getdpt(string schid, string stat, string selfid, string selid)
        {
            string ret = "";
            if (Com.Session.userid == null)
            {
                ret = "expire";
            }
            else
            {
                schid = Com.Public.SqlEncStr(schid);
                stat = Com.Public.SqlEncStr(stat);
                selfid = Com.Public.SqlEncStr(selfid);
                selid = Com.Public.SqlEncStr(selid);

                try
                {
                    if (selfid == "")
                    {
                        SchSystem.BLL.SchDepartInfo dptbll = new SchSystem.BLL.SchDepartInfo();
                        string sqlstr = "stat=1 and SchId=" + Com.Public.SqlEncStr(schid);
                        //if (stat != "")
                        //{
                        //    sqlstr += " and Stat=" + Com.Public.SqlEncStr(stat);
                        //}
                        DataTable dtdept = dptbll.GetList("Pid pId,DepartId id,DepartName name,'false' checked,stat,OrderId ", sqlstr + " Order by OrderId").Tables[0];
                        if (dtdept.Rows.Count == 0)
                        {
                            //给个默认根节点
                            //DataRow dr = dtdept.NewRow();
                            //dr["id"] = "0";
                            //dr["pId"] = DBNull.Value;
                            //dr["name"] = "顶级部门";
                            //dr["checked"] = "false";
                            //dtdept.Rows.Add(dr);
                        }
                        ret = Newtonsoft.Json.JsonConvert.SerializeObject(dtdept);
                    }
                    else if (selfid == "0")//添加时取全部节点的部门树
                    {
                        ret = Com.Public.GetDrp("dpt", schid, "1", true, "", selid);
                    }
                    else//修改时,取没有该节点下的所有子节点的树
                    {
                        ret = Com.Public.GetDrp("dpt", schid, "1", true, selfid, selid);
                    }
                }
                catch (Exception ex)
                {
                    ret = "";
                }
            }
            return ret.Replace("全部", "顶级部门");
        }
        [WebMethod]
        public static string adddpt(string schid, string dptname, string pid, string stat)
        {
            schid = Com.Public.SqlEncStr(schid);
            dptname = Com.Public.SqlEncStr(dptname);
            pid = Com.Public.SqlEncStr(pid);
            stat = Com.Public.SqlEncStr(stat);
            string ret = "";
            if (Com.Session.userid == null)
            {
                ret = "expire";
            }
            else
            {
                try
                {
                    SchSystem.BLL.SchDepartInfo bll = new SchSystem.BLL.SchDepartInfo();
                    DataTable dtTopOrderOne = bll.GetList("top 1 OrderId", "Schid='" + schid + "' and Pid='" + pid + "' Order By OrderId Desc").Tables[0];
                    DataRow[] drTopOrderOne = dtTopOrderOne.Select();
                    int OrderId = 0;
                    if (dtTopOrderOne.Rows.Count == 0)//如果子类为空，设置OrderId默认值为0；
                    {
                        OrderId = 0;
                    }
                    else//否则，获取最大值并加1
                    {
                        foreach (DataRow item in drTopOrderOne)
                        {
                            OrderId = Convert.ToInt32(item["OrderId"]) + 1;
                        }
                    }
                    SchSystem.Model.SchDepartInfo model = new SchSystem.Model.SchDepartInfo();
                    model.RecTime = DateTime.Now;
                    model.RecUser = Com.Session.userid;
                    model.SchId = int.Parse(schid);

                    model.OrderId = OrderId;

                    if (pid.ToString() == "null")
                    {
                        model.Pid = Convert.ToInt32(0);
                    }
                    else
                    {
                        model.Pid = int.Parse(pid);
                    }
                    model.Stat = int.Parse(stat);
                    model.DepartName = Com.Public.SqlEncStr(dptname);
                    model.LastRecTime = DateTime.Now;
                    model.LastRecUser = Com.Session.userid;
                    int id = bll.Add(model);
                    ret = id.ToString();
                }
                catch (Exception ex)
                {
                    ret = ex.Message;
                }
            }
            return ret;

        }
        [WebMethod]
        public static string updpt(string schid, string id, string dptname, string pid, string stat)
        {
            string ret = "";
            if (Com.Session.userid == null)
            {
                ret = "expire";
            }
            else
            {
                try
                {
                    SchSystem.BLL.SchDepartInfo bll = new SchSystem.BLL.SchDepartInfo();
                    SchSystem.Model.SchDepartInfo model = new SchSystem.Model.SchDepartInfo();
                    model.DepartId = int.Parse(id);
                    model.Pid = int.Parse(pid);
                    model.Stat = int.Parse(stat);
                    model.DepartName = Com.Public.SqlEncStr(dptname);
                    model.LastRecTime = DateTime.Now;
                    model.LastRecUser = Com.Session.userid;
                    bll.Update(model);
                    ret = "success";
                }
                catch (Exception ex)
                {
                    ret = ex.Message;
                }
            }
            return ret;

        }
        [WebMethod]
        public static string deldpt(string schid, string id)
        {
            string ret = "";
            if (Com.Session.userid == null)
            {
                ret = "expire";
            }
            else
            {
                try
                {
                    SchSystem.BLL.SchDepartInfo bll = new SchSystem.BLL.SchDepartInfo();
                    //判断是否有正常的子部门和人员
                    if (bll.ExistsUser(int.Parse(id)))
                    {
                        ret += "该部门下还有人员,不允许删除!";
                    }
                    if (bll.ExistsPid(int.Parse(id)))
                    {
                        ret += "该部门下有子部门,不允许删除!";
                    }
                    if (ret == "")
                    {
                        SchSystem.Model.SchDepartInfo model = new SchSystem.Model.SchDepartInfo();
                        model.DepartId = int.Parse(id);
                        model.LastRecTime = DateTime.Now;
                        model.LastRecUser = Com.Session.userid;
                        model.Stat = 2;
                        bll.UpdateStat(model);
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
        [WebMethod]
        public static string MoveUpDown(string dptid, string moveType)
        {
            dptid = Com.Public.SqlEncStr(dptid);
            moveType = Com.Public.SqlEncStr(moveType);
            string ret = "";
            if (Com.Session.userid == null)
            {
                ret = "expire";
            }
            else
            {
                if (moveType == "up")//上移
                {
                    moveType = "1";
                }
                else if (moveType == "down")//下移
                {
                    moveType = "0";
                }
                SchSystem.BLL.SchDepartInfo dptbll = new SchSystem.BLL.SchDepartInfo();
                int s = dptbll.ChangeOrderBy(dptid, moveType);
                if (s > 0)
                    ret = "success";
                else if (s == 0)
                {
                    ret = "success01";
                }
            }
            return ret;
        }
    }
}