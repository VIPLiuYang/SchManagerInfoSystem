using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebServ.Web.ServFunc
{
    public partial class ServFuncAdd : System.Web.UI.Page
    {
        public string schid = "";
        public string businessType = "";
        public string businessPlatfrom = "";
        public string addinfo = "";
        public string selectprdcontent = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            schid = Com.Session.schid;
            //业务类型
            SchSystem.BLL.ServType stBll = new SchSystem.BLL.ServType();
            DataTable stdt = stBll.GetList("TypeName,TypeCode", "").Tables[0];
            businessType = Newtonsoft.Json.JsonConvert.SerializeObject(stdt);
            //业务平台
            SchSystem.BLL.ServSys ssBll = new SchSystem.BLL.ServSys();
            DataTable ssdt = ssBll.GetList("'0' pId,SysName name,SysCode id,SysUrl,'false' checked", "").Tables[0];
            businessPlatfrom = Newtonsoft.Json.JsonConvert.SerializeObject(ssdt);
            //附加設置信息
            SchSystem.BLL.ServSysNape ssnBll = new SchSystem.BLL.ServSysNape();
            DataTable ssndt = ssnBll.GetList("Stat=1").Tables[0];
            addinfo = Newtonsoft.Json.JsonConvert.SerializeObject(ssndt);
            //附加設置信息之附加信息聯動內容默認下拉列表
            SchSystem.BLL.SysPer spBll = new SchSystem.BLL.SysPer();
            DataTable dtsp = spBll.GetList("'0' pId,PerName name,PerCode id", "Stat=1 order by convert(int,PerCode)").Tables[0];
            selectprdcontent = Newtonsoft.Json.JsonConvert.SerializeObject(dtsp);
        }
        #region 數據收集並且存儲數據庫
        [WebMethod]
        public static Com.DataPack.DataRsp<string> FuncAddSave(List<string> arr)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            if (Com.Session.userid == null)
            {
                rsp.code = "expire";
                rsp.msg = "你现在登录已过期，请重新登录！";
            }
            else
            {
                try
                {
                    SchSystem.BLL.ServFunc sfcBll = new SchSystem.BLL.ServFunc();
                    SchSystem.Model.ServFunc sfcModel = new SchSystem.Model.ServFunc();
                    foreach (string str in arr)
                    {
                        string[] strarr = str.Split('#');
                        if (strarr[0] == "businesstype") { sfcModel.TypeCode = strarr[1].Trim(); }
                        else if (strarr[0] == "businesscode") { sfcModel.FuncCode = strarr[1].Trim(); }
                        else if (strarr[0] == "funcname") { sfcModel.FuncName = strarr[1].Trim(); }
                        else if (strarr[0] == "userange") { sfcModel.FuncRange = strarr[1].Trim(); }
                        else if (strarr[0] == "addsetinfo") { sfcModel.FuncSet = strarr[1].Trim(); }
                        else if (strarr[0] == "businessdesc") { sfcModel.FuncDes = strarr[1].Trim(); }
                        else if (strarr[0] == "tagsbusplatfrom") { sfcModel.FuncSyss = strarr[1].Trim(); }
                        else if (strarr[0] == "note") { sfcModel.FuncNote = strarr[1].Trim(); }
                    }
                    if (sfcModel.TypeCode == "" || sfcModel.FuncCode == "" || sfcModel.FuncName == "" || sfcModel.FuncRange == "" || sfcModel.FuncSet == "" || sfcModel.FuncSyss == "" )
                    {
                        rsp.code = "error";
                        rsp.msg = "操作失败！不允许输入空格";
                    }
                    else
                    {

                        bool resbool = sfcBll.Exists(sfcModel.FuncCode);
                        if (!resbool)
                        {
                            int result = sfcBll.Add(sfcModel);
                            if (result > 0)
                            {
                                string FuncSet = sfcModel.FuncSet;
                                string[] FuncSetRecArr = FuncSet.Split('|');//英文半角“|”
                                DataTable dt = new DataTable();
                                dt.Columns.Add("FuncId");
                                dt.Columns.Add("NapeCode");
                                dt.Columns.Add("NapeCodes");
                                dt.Columns.Add("NapeC");
                                SchSystem.BLL.ServFuncExt sfeBll = new SchSystem.BLL.ServFuncExt();
                                for (int i = 0; i < FuncSetRecArr.Length; i++)
                                {
                                    string[] FuncSetItemArr = FuncSetRecArr[i].Split('!');//英文半角“！”
                                    //SchSystem.BLL.ServFuncExt sfeBll = new SchSystem.BLL.ServFuncExt();
                                    //SchSystem.Model.ServFuncExt sfeModel = new SchSystem.Model.ServFuncExt();
                                    //sfeModel.FuncId = result;
                                    //sfeModel.NapeCode = FuncSetItemArr[0];
                                    //sfeModel.NapeCodes = FuncSetItemArr[1];
                                    //sfeModel.NapeC = int.Parse(FuncSetItemArr[2]);
                                    //sfeBll.Add(sfeModel);
                                    DataRow dry = dt.NewRow();
                                    dry["FuncId"] = result;
                                    dry["NapeCode"] = Com.Public.SqlEncStr(FuncSetItemArr[0]);
                                    dry["NapeCodes"] = Com.Public.SqlEncStr(FuncSetItemArr[1]);
                                    dry["NapeC"] = int.Parse(Com.Public.SqlEncStr(FuncSetItemArr[2]));
                                    dt.Rows.Add(dry);
                                }
                                rsp.code = "success";
                                rsp.msg = sfeBll.ExecuteSqlBulkCopy(dt, "ServFuncExt");
                            }
                            else
                            {
                                rsp.code = "error";
                                rsp.msg = "操作失败";
                            }
                        }
                        else
                        {
                            rsp.code = "codeRepeat";
                            rsp.msg = "功能代码不允许重复";
                        }

                    }
                }
                catch (Exception ex)
                {
                    rsp.code = "excepError";
                    rsp.msg = ex.Message;
                }
            }
            return rsp;
        }
        #endregion
        [WebMethod]
        public static string getaddcont(string napecode)
        {
            string ret = "";
            if (Com.Session.userid == null)
            {
                ret = "expire";
            }
            else
            {
                retprompt retobj = new retprompt();
                if (napecode == "prd")//學段
                {
                    SchSystem.BLL.SysPer spBll = new SchSystem.BLL.SysPer();
                    DataTable dt = spBll.GetList("'0' pId,PerName name,PerCode id", "Stat=1 order by convert(int,PerCode)").Tables[0];
                    retobj.retxt = napecode;
                    retobj.retobj = dt;
                    ret = Newtonsoft.Json.JsonConvert.SerializeObject(retobj);
                }
                else if (napecode == "grd")//年級
                {
                    SchSystem.BLL.SysGrade spBll = new SchSystem.BLL.SysGrade();
                    DataTable dt = spBll.GetList("'0' pId,GradeName name,GradeCode id", "").Tables[0];
                    retobj.retxt = napecode;
                    retobj.retobj = dt;
                    ret = Newtonsoft.Json.JsonConvert.SerializeObject(retobj);
                }
                else if (napecode == "sub")//科目
                {
                    SchSystem.BLL.SysSub spBll = new SchSystem.BLL.SysSub();
                    DataTable dt = spBll.GetList("'0' pId,SubName name,SubCode id", "Stat=1 Order by SubCode").Tables[0];
                    retobj.retxt = napecode;
                    retobj.retobj = dt;
                    ret = Newtonsoft.Json.JsonConvert.SerializeObject(retobj);
                }
                else if (napecode == "utp")//角色
                {
                    SchSystem.BLL.SysUType spBll = new SchSystem.BLL.SysUType();
                    DataTable dt = spBll.GetList("'0' pId,UTypeName name,UTypeCOde id", "Stat=1").Tables[0];
                    retobj.retxt = napecode;
                    retobj.retobj = dt;
                    ret = Newtonsoft.Json.JsonConvert.SerializeObject(retobj);
                }
                else if (napecode == "mat")//教版
                {
                    SchSystem.BLL.SysMater spBll = new SchSystem.BLL.SysMater();
                    DataTable dt = spBll.GetList("'0' pId,MaterName name,MaterCode id", "Stat=1").Tables[0];
                    retobj.retxt = napecode;
                    retobj.retobj = dt;
                    ret = Newtonsoft.Json.JsonConvert.SerializeObject(retobj);
                }
                else
                {
                    retobj.retxt = napecode;
                    retobj.retobj = "";
                    ret = Newtonsoft.Json.JsonConvert.SerializeObject(retobj);
                }
            }
            return ret;
        }
        [Serializable]
        private class retprompt
        {
            public string retxt;
            public object retobj;
        }
    }
}