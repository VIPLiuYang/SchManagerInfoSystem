using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebMaster.Web.UserFuncSoure
{
    public partial class SchStructureSet : System.Web.UI.Page
    {
        public string schid = "0";
        public string systype = "2";
        public string schsubname = "";
        public string areastr = "";
        //public string uschid = "0";
        public string cotycode = "";
        public string schgradeinfo = "";
        //public string schclassinfo = "";
        public bool isadd;
        public bool isedit;
        public bool isdel;
        public bool islook;
        protected void Page_Load(object sender, EventArgs e)
        {

            string jsid = Request.Params["sid"].ToString();
            string jstoken = Request.Params["token"].ToString();
            Com.SoureSession.jsid = jsid;
            Com.SoureSession.jstoken = jstoken;
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(jsid, jstoken);
            if (rsp.code == "ERROR_TOKEN")
            {
                Response.Write("登录已失效!");
                Response.End();
            }
            else if (!IsPostBack)
            {
                islook = true;
                if (Com.SoureSession.Souresystype == "1")
                {
                    isadd = false;
                    isedit = false;
                    isdel = false;
                }
                else
                {
                    isadd = true;
                    isedit = true;
                    isdel = true;
                }
                //不是超管获取本学校的
                if (Com.SoureSession.Souresystype != "2")
                {
                    schid = Com.SoureSession.Soureschid;
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
                        schid = sareaschid;
                    }
                    sbarea.Append("</select>");
                    areastr = sbarea.ToString();
                }

                //获取学校的科目
                SchSystem.BLL.SchSub SchSubBll = new SchSystem.BLL.SchSub();
                DataTable dtschsub = SchSubBll.GetList("SubName", "Stat=1 and SchId='" + schid + "'").Tables[0];
                if (dtschsub.Rows.Count > 0)
                {
                    StringBuilder sbSubName = new StringBuilder();
                    foreach (DataRow drSubName in dtschsub.Rows)
                    {
                        sbSubName.Append(drSubName["SubName"] + "、");
                    }
                    schsubname = sbSubName.ToString().Substring(0, sbSubName.Length - 1);
                }

                //获取学校年级
                SchSystem.BLL.SchGradeInfo SchGradeBll = new SchSystem.BLL.SchGradeInfo();
                DataTable dtschgrade = SchGradeBll.GetList("GradeId,GradeYear,GradeName", "IsFinish=0 and SchId='" + schid + "' Order by GradeCode ASC").Tables[0];
                schgradeinfo = Newtonsoft.Json.JsonConvert.SerializeObject(dtschgrade);

                //获取学校班级
                //SchSystem.BLL.SchClassInfo SchClassBll = new SchSystem.BLL.SchClassInfo();
                //DataTable dtschclass = SchClassBll.GetList("ClassId,GradeId,ClassName", "IsFinish=0 and SchId='" + schid + "'").Tables[0];
                //schclassinfo = Newtonsoft.Json.JsonConvert.SerializeObject(dtschclass);
            }

        }

        [WebMethod]
        public static string getdpt(string schid, string stat, string selfid, string selid)
        {

            string ret = "";
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(Com.SoureSession.jsid, Com.SoureSession.jstoken);
            if (rsp.code == "ERROR_TOKEN")
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
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(Com.SoureSession.jsid, Com.SoureSession.jstoken);
            if (rsp.code == "ERROR_TOKEN")
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
                    model.RecUser = Com.SoureSession.Soureuserid;
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
                    model.LastRecUser = Com.SoureSession.Soureuserid;
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
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(Com.SoureSession.jsid, Com.SoureSession.jstoken);
            if (rsp.code == "ERROR_TOKEN")
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
                    model.LastRecUser = Com.SoureSession.Soureuserid;
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
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(Com.SoureSession.jsid, Com.SoureSession.jstoken);
            if (rsp.code == "ERROR_TOKEN")
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
                        model.LastRecUser = Com.SoureSession.Soureuserid;
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
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(Com.SoureSession.jsid, Com.SoureSession.jstoken);
            if (rsp.code == "ERROR_TOKEN")
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
        [WebMethod]
        public static int ClassNameSave(string schid, int gradeid, string classnamestr)
        {
            int ret = 0;//默认返回值为0，数字1代表成功
            SchSystem.BLL.SchClassInfo sciBll = new SchSystem.BLL.SchClassInfo();
            SchSystem.Model.SchClassInfo sciModel = new SchSystem.Model.SchClassInfo();
            string[] classnamearr = classnamestr.Split(',');
            int classnamearrlen = classnamearr.Length;
            foreach (string classname in classnamearr)
            {
                DataTable dtRes = sciBll.Exists(schid, gradeid, classname).Tables[0];
                if (dtRes.Rows.Count > 0)//如果班级已经存在，则修改状态
                {
                    DataRow dr = dtRes.Select()[0];
                    string classid = dr["ClassId"].ToString();
                    sciModel.ClassId = int.Parse(classid);
                    sciModel.LastRecTime = DateTime.Now;
                    sciModel.LastRecUser = Com.SoureSession.Soureuserid;
                    sciModel.IsFinish = 0;
                    bool resret = sciBll.UpdateStat(sciModel);
                    if (resret)
                    {
                        ret = 1;
                    }
                }
                else//否则，添加新班级
                {
                    sciModel.SchId = Convert.ToInt32(schid);
                    sciModel.GradeId = gradeid;
                    sciModel.ClassName = classname;
                    sciModel.RecTime = DateTime.Now;
                    sciModel.RecUser = Com.SoureSession.Soureuserid;
                    sciModel.IsFinish = 0;
                    int resret = sciBll.Add(sciModel);
                    if (resret > 0)
                    {
                        ret = 1;
                    }
                }
            }
            return ret;
        }
        [WebMethod]
        public static int ClassDelete(string schid, string schclassid)
        {
            int ret = 0;
            SchSystem.BLL.SchClassInfo classbll = new SchSystem.BLL.SchClassInfo();
            bool resultBool = classbll.ExistsClassStuData(int.Parse(schclassid));
            SchSystem.BLL.SchClassUser classuserbll = new SchSystem.BLL.SchClassUser();
            bool resultBoolUser = classuserbll.ExistsClassUser(schid, schclassid);
            if (resultBool || resultBoolUser)//如果为true说明是班级内有数据
            {
                ret = 0;
            }
            else//否则即可删除班级记录
            {
                SchSystem.Model.SchClassInfo classmodel = new SchSystem.Model.SchClassInfo();
                classmodel.ClassId = int.Parse(schclassid);
                classmodel.IsFinish = 2;
                classmodel.LastRecTime = DateTime.Now;
                classmodel.LastRecUser = Com.SoureSession.Soureuserid;
                if (classbll.UpdateStat(classmodel))
                {
                    //SchSystem.BLL.SchClassUser scuBll = new SchSystem.BLL.SchClassUser();
                    // bool ecu = scuBll.ExistsClassUser(int.Parse(schid), int.Parse(classid));
                    //bool scubool = scuBll.Delete(classid, schid);
                    //if (scubool)
                    // {
                    ret = 1;
                    //}
                }
                else
                {
                    ret = 0;
                }
            }
            return ret;
        }
        [WebMethod]
        public static string getclassdatas(string schid)
        {
            string ret = "";
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(Com.SoureSession.jsid, Com.SoureSession.jstoken);
            if (rsp.code == "ERROR_TOKEN")
            {
                ret = "expire";
            }
            else
            {
                SchSystem.BLL.SchClassInfo SchClassBll = new SchSystem.BLL.SchClassInfo();
                DataTable dtschclass = SchClassBll.GetList("ClassId,GradeId,ClassName", "IsFinish=0 and SchId='" + schid + "' order by ClassName asc").Tables[0];
                ret = Newtonsoft.Json.JsonConvert.SerializeObject(dtschclass);
            }
            return ret;
        }
        [WebMethod]
        public static string getschsub(string schid)
        {
            string ret = "";
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(Com.SoureSession.jsid, Com.SoureSession.jstoken);
            if (rsp.code == "ERROR_TOKEN")
            {
                ret = "expire";
            }
            else
            {
                //获取学校的科目
                SchSystem.BLL.SchSub SchSubBll = new SchSystem.BLL.SchSub();
                DataTable dtschsub = SchSubBll.GetList("SubName", "Stat=1 and SchId='" + schid + "'").Tables[0];
                if (dtschsub.Rows.Count > 0)
                {
                    StringBuilder sbSubName = new StringBuilder();
                    foreach (DataRow drSubName in dtschsub.Rows)
                    {
                        sbSubName.Append(drSubName["SubName"] + "、");
                    }
                    ret = sbSubName.ToString().Substring(0, sbSubName.Length - 1);
                }
            }
            return ret;
        }
        [WebMethod]
        public static string getschgrade(string schid)
        {
            string ret = "";
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(Com.SoureSession.jsid, Com.SoureSession.jstoken);
            if (rsp.code == "ERROR_TOKEN")
            {
                ret = "expire";
            }
            else
            {
                //获取学校年级
                SchSystem.BLL.SchGradeInfo SchGradeBll = new SchSystem.BLL.SchGradeInfo();
                DataTable dtschgrade = SchGradeBll.GetList("GradeId,GradeYear,GradeName", "IsFinish=0 and SchId='" + schid + "'").Tables[0];
                ret = Newtonsoft.Json.JsonConvert.SerializeObject(dtschgrade);
            }
            return ret;
        }
    }
}