﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWebServ.Web.UserOrderInfo
{
    public partial class UserOrderEdit : System.Web.UI.Page
    {
        public string uname = "";
        public string province = "";
        public string city = "";
        public string servbustree = "";
        public string dotype = "";
        public string servUserForModel = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            //獲取GET參數
            dotype = Request.Params["dotype"].ToString();
            string AutoId = Request.Params["id"].ToString();
            //獲取登錄者的真實姓名
            uname = Com.Session.uname;
            #region 查詢當前AutoId的數據記錄
            SchSystem.BLL.ServUserFor sufBll = new SchSystem.BLL.ServUserFor();
            SchSystem.Model.ServUserForV sufvModel = new SchSystem.Model.ServUserForV();
            string ServiceId = "";
            if (!string.IsNullOrEmpty(AutoId) && !string.IsNullOrEmpty(dotype))
            {
                sufvModel = sufBll.GetModelV("AutoId,UserName,UTname,CnName,FromType,RecUser,ServiceId,ServStat,ServMonth,FeeM,RecTime,EndTime,EditTime,DoNote,Uareano,BusMonth,FeeCode", int.Parse(AutoId));
                ServiceId = sufvModel.ServiceId;
                servUserForModel = Newtonsoft.Json.JsonConvert.SerializeObject(sufvModel);
            }
            #endregion
            #region 獲取資費套餐下拉列表
            SchSystem.BLL.ServBus sbBll = new SchSystem.BLL.ServBus();
            DataTable servbusdt = sbBll.GetList("'0' pId,ServiceId id,FeeCode,CnName name,'false' checked,BusMonth,'true' chkDisabled", "").Tables[0];
            if (servbusdt.Rows.Count > 0)
            {
                for (int i = 0; i < servbusdt.Rows.Count; i++)
                {
                    if (servbusdt.Rows[i]["id"].ToString() == ServiceId)
                    {
                        servbusdt.Rows[i]["checked"] = true;
                    }
                }
            }
            servbustree = Newtonsoft.Json.JsonConvert.SerializeObject(servbusdt);
            #endregion

            #region 獲取省市區
            //获取省份
            StringBuilder areaProvince = new StringBuilder();
            string sareacode = "";
            areaProvince.Append(Com.Public.GetDrpArea("0", "", ref sareacode, false, "0"));
            province = areaProvince.ToString();
            //获取城市
            StringBuilder areaCity = new StringBuilder();
            string sareacitycode = "";
            areaCity.Append(Com.Public.GetDrpArea("1", sareacode, ref sareacitycode, false, "0"));
            city = areaCity.ToString();
            #endregion
        }
        
        #region 判斷賬號是否存在。如果不存在可以添加；否則，不可用添加
        [WebMethod]
        public static Com.DataPack.DataRsp<string> AccountIsExist(string account)
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
                    SchSystem.BLL.ServUser suBll = new SchSystem.BLL.ServUser();
                    bool result = suBll.Exists(account);//判斷手機號碼是否存在
                    if (!result)
                    {
                        rsp.code = "success";
                        rsp.msg = "可以添加";
                    }
                    else
                    {
                        rsp.code = "error";
                        rsp.msg = "已存在";
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
        #region 查詢附加功能
        [WebMethod]
        public static string getServFunc(string ordpack, string acount)
        {
            string ret = "";
            if (Com.Session.userid == null)
            {
                ret = "expire";
            }
            else
            {
                retprompt retobj = new retprompt();
                //根據套餐代碼查詢功能代碼
                SchSystem.BLL.ServBus sbBll = new SchSystem.BLL.ServBus();
                string funcstr = sbBll.GetList("FuncStr", "ServiceId='" + ordpack + "'").Tables[0].Rows[0]["FuncStr"].ToString();
                string funcs = "";
                if (!string.IsNullOrEmpty(funcstr))
                {
                    string[] funcstrarr = funcstr.Split(',');
                    foreach (string str in funcstrarr)
                    {
                        funcs += "'" + str + "',";
                    }
                }

                SchSystem.BLL.ServFuncExt sfeBll = new SchSystem.BLL.ServFuncExt();
                //根據功能代碼查詢功能名稱以及編號
                DataTable dtServFunc = sfeBll.GetListV("distinct ServFuncAutoId as AutoId,FuncName,FuncCode", "FuncCode in (" + funcs.Substring(0, funcs.Length - 1) + ")").Tables[0];
                retobj.retxt = "servfunc";
                retobj.retobj = dtServFunc;
                //根據功能AutoId查詢功能擴展數據
                DataTable dtServFuncExt = sfeBll.GetListV("FuncId,NapeCode,NapeCodes,NapeC,'' Title", "FuncId in(select AutoId from ServFunc where FuncCode in(" + funcs.Substring(0, funcs.Length - 1) + "))").Tables[0];
                retobj.servfuncext = dtServFuncExt;
                //根据UserForId查询用户定制扩展信息表
                SchSystem.BLL.ServUserForExt sufeBll = new SchSystem.BLL.ServUserForExt();
                DataTable dtsufe = sufeBll.GetList("Fcode,NapeCode,NapeCodes", "UserForId in (select AutoId from ServUserFor where ServiceId='" + ordpack + "' and UserName='" + acount + "')").Tables[0];

                Dictionary<string, object> listDic = new Dictionary<string, object>();


                //根據功能代碼查詢功能名稱以及編號
                //SchSystem.BLL.ServFunc sfBll = new SchSystem.BLL.ServFunc();
                //DataTable dtServFunc = sfBll.GetList("AutoId,FuncName,FuncCode", "FuncCode in (" + funcs.Substring(0,funcs.Length-1) + ")").Tables[0];
                //retobj.retxt = "servfunc";
                //retobj.retobj = dtServFunc;
                //根據功能AutoId查詢功能擴展數據
                //SchSystem.BLL.ServFuncExt sfeBll = new SchSystem.BLL.ServFuncExt();
                //DataTable dtServFuncExt = sfeBll.GetList("FuncId,NapeCode,NapeCodes,NapeC,'' Title", "FuncId in(select AutoId from ServFunc where FuncCode in(" + funcs.Substring(0, funcs.Length - 1) + "))").Tables[0];
                //retobj.servfuncext = dtServFuncExt;
                //Dictionary<string, object> listDic = new Dictionary<string, object>();
                if (dtServFuncExt.Rows.Count > 0)
                {
                    for (int i = 0; i < dtServFuncExt.Rows.Count; i++)
                    {
                        for (int j = 0; j < dtServFunc.Rows.Count; j++)
                        {
                            if (dtServFuncExt.Rows[i]["FuncId"].ToString() == dtServFunc.Rows[j]["AutoId"].ToString())
                            {
                                if (dtServFuncExt.Rows[i]["NapeCode"].ToString() == "prd")
                                {
                                    SchSystem.BLL.SysPer spBll = new SchSystem.BLL.SysPer();
                                    DataTable dtSysPer = spBll.GetList("'0' pId,PerName name,PerCode id,'false' checked", "Stat=1 and PerCode in (" + dtServFuncExt.Rows[i]["NapeCodes"].ToString() + ") order by convert(int,PerCode)").Tables[0];
                                    dtServFuncExt.Rows[i]["Title"] = "学段";
                                    string prdtxt = "prd_" + dtServFuncExt.Rows[i]["FuncId"].ToString();
                                    //
                                    if (dtSysPer.Rows.Count > 0)
                                    {
                                        for (int y = 0; y < dtSysPer.Rows.Count; y++)
                                        {
                                            if (dtsufe.Rows.Count > 0)
                                            {
                                                for (int z = 0; z < dtsufe.Rows.Count; z++)
                                                {
                                                    if (dtsufe.Rows[z]["Fcode"].ToString() == dtServFunc.Rows[j]["FuncCode"].ToString() && dtServFuncExt.Rows[i]["NapeCode"].ToString() == dtsufe.Rows[z]["NapeCode"].ToString())
                                                    {
                                                        if (!string.IsNullOrEmpty(dtsufe.Rows[z]["NapeCodes"].ToString()))
                                                        {
                                                            string[] ncarr = dtsufe.Rows[z]["NapeCodes"].ToString().Split(',');
                                                            for (int x = 0; x < ncarr.Length; x++)
                                                            {
                                                                if (ncarr[x].ToString() == dtSysPer.Rows[y]["id"].ToString())
                                                                {
                                                                    dtSysPer.Rows[y]["checked"] = true;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    //
                                    listDic.Add(prdtxt, dtSysPer);
                                }
                                if (dtServFuncExt.Rows[i]["NapeCode"].ToString() == "mat")
                                {
                                    SchSystem.BLL.SysMater smBll = new SchSystem.BLL.SysMater();
                                    DataTable dtSysMat = smBll.GetList("'0' pId,MaterName name,MaterCode id,'false' checked", "Stat=1 and MaterCode in (" + dtServFuncExt.Rows[i]["NapeCodes"].ToString() + ")").Tables[0];
                                    dtServFuncExt.Rows[i]["Title"] = "教版";
                                    string prdtxt = "mat_" + dtServFuncExt.Rows[i]["FuncId"].ToString();
                                    //
                                    if (dtSysMat.Rows.Count > 0)
                                    {
                                        for (int y = 0; y < dtSysMat.Rows.Count; y++)
                                        {
                                            if (dtsufe.Rows.Count > 0)
                                            {
                                                for (int z = 0; z < dtsufe.Rows.Count; z++)
                                                {
                                                    if (dtsufe.Rows[z]["Fcode"].ToString() == dtServFunc.Rows[j]["FuncCode"].ToString() && dtServFuncExt.Rows[i]["NapeCode"].ToString() == dtsufe.Rows[z]["NapeCode"].ToString())
                                                    {
                                                        if (!string.IsNullOrEmpty(dtsufe.Rows[z]["NapeCodes"].ToString()))
                                                        {
                                                            string[] ncarr = dtsufe.Rows[z]["NapeCodes"].ToString().Split(',');
                                                            for (int x = 0; x < ncarr.Length; x++)
                                                            {
                                                                if (ncarr[x].ToString() == dtSysMat.Rows[y]["id"].ToString())
                                                                {
                                                                    dtSysMat.Rows[y]["checked"] = true;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    //
                                    listDic.Add(prdtxt, dtSysMat);
                                }
                                if (dtServFuncExt.Rows[i]["NapeCode"].ToString() == "sub")
                                {
                                    SchSystem.BLL.SysSub ssBll = new SchSystem.BLL.SysSub();
                                    DataTable dtSysSub = ssBll.GetList("'0' pId,SubName name,SubCode id,'false' checked", "Stat=1 and SubCode in (" + dtServFuncExt.Rows[i]["NapeCodes"].ToString() + ")").Tables[0];
                                    dtServFuncExt.Rows[i]["Title"] = "科目";
                                    string prdtxt = "sub_" + dtServFuncExt.Rows[i]["FuncId"].ToString();
                                    //
                                    if (dtSysSub.Rows.Count > 0)
                                    {
                                        for (int y = 0; y < dtSysSub.Rows.Count; y++)
                                        {
                                            if (dtsufe.Rows.Count > 0)
                                            {
                                                for (int z = 0; z < dtsufe.Rows.Count; z++)
                                                {
                                                    if (dtsufe.Rows[z]["Fcode"].ToString() == dtServFunc.Rows[j]["FuncCode"].ToString() && dtServFuncExt.Rows[i]["NapeCode"].ToString() == dtsufe.Rows[z]["NapeCode"].ToString())
                                                    {
                                                        if (!string.IsNullOrEmpty(dtsufe.Rows[z]["NapeCodes"].ToString()))
                                                        {
                                                            string[] ncarr = dtsufe.Rows[z]["NapeCodes"].ToString().Split(',');
                                                            for (int x = 0; x < ncarr.Length; x++)
                                                            {
                                                                if (ncarr[x].ToString() == dtSysSub.Rows[y]["id"].ToString())
                                                                {
                                                                    dtSysSub.Rows[y]["checked"] = true;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    //
                                    listDic.Add(prdtxt, dtSysSub);
                                }
                                if (dtServFuncExt.Rows[i]["NapeCode"].ToString() == "grd")
                                {
                                    SchSystem.BLL.SysGrade sgBll = new SchSystem.BLL.SysGrade();
                                    DataTable dtSysGrade = sgBll.GetList("'0' pId,GradeName name,GradeCode id,'false' checked", "GradeCode in (" + dtServFuncExt.Rows[i]["NapeCodes"].ToString() + ")").Tables[0];
                                    dtServFuncExt.Rows[i]["Title"] = "年级";
                                    string prdtxt = "grd_" + dtServFuncExt.Rows[i]["FuncId"].ToString();
                                    //
                                    if (dtSysGrade.Rows.Count > 0)
                                    {
                                        for (int y = 0; y < dtSysGrade.Rows.Count; y++)
                                        {
                                            if (dtsufe.Rows.Count > 0)
                                            {
                                                for (int z = 0; z < dtsufe.Rows.Count; z++)
                                                {
                                                    if (dtsufe.Rows[z]["Fcode"].ToString() == dtServFunc.Rows[j]["FuncCode"].ToString() && dtServFuncExt.Rows[i]["NapeCode"].ToString() == dtsufe.Rows[z]["NapeCode"].ToString())
                                                    {
                                                        if (!string.IsNullOrEmpty(dtsufe.Rows[z]["NapeCodes"].ToString()))
                                                        {
                                                            string[] ncarr = dtsufe.Rows[z]["NapeCodes"].ToString().Split(',');
                                                            for (int x = 0; x < ncarr.Length; x++)
                                                            {
                                                                if (ncarr[x].ToString() == dtSysGrade.Rows[y]["id"].ToString())
                                                                {
                                                                    dtSysGrade.Rows[y]["checked"] = true;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    //
                                    listDic.Add(prdtxt, dtSysGrade);
                                }
                                if (dtServFuncExt.Rows[i]["NapeCode"].ToString() == "utp")
                                {
                                    SchSystem.BLL.SysUType sutBll = new SchSystem.BLL.SysUType();
                                    DataTable dtSysUType = sutBll.GetList("'0' pId,UTypeName name,UTypeCode id,'false' checked", "Stat=1 and UTypeCode in (" + dtServFuncExt.Rows[i]["NapeCodes"].ToString() + ")").Tables[0];
                                    dtServFuncExt.Rows[i]["Title"] = "角色";
                                    string prdtxt = "utp_" + dtServFuncExt.Rows[i]["FuncId"].ToString();
                                    //
                                    if (dtSysUType.Rows.Count > 0)
                                    {
                                        for (int y = 0; y < dtSysUType.Rows.Count; y++)
                                        {
                                            if (dtsufe.Rows.Count > 0)
                                            {
                                                for (int z = 0; z < dtsufe.Rows.Count; z++)
                                                {
                                                    if (dtsufe.Rows[z]["Fcode"].ToString() == dtServFunc.Rows[j]["FuncCode"].ToString() && dtServFuncExt.Rows[i]["NapeCode"].ToString() == dtsufe.Rows[z]["NapeCode"].ToString())
                                                    {
                                                        if (!string.IsNullOrEmpty(dtsufe.Rows[z]["NapeCodes"].ToString()))
                                                        {
                                                            string[] ncarr = dtsufe.Rows[z]["NapeCodes"].ToString().Split(',');
                                                            for (int x = 0; x < ncarr.Length; x++)
                                                            {
                                                                if (ncarr[x].ToString() == dtSysUType.Rows[y]["id"].ToString())
                                                                {
                                                                    dtSysUType.Rows[y]["checked"] = true;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    //
                                    listDic.Add(prdtxt, dtSysUType);
                                }
                            }
                        }
                    }
                    retobj.sysext = listDic;
                }
                ret = Newtonsoft.Json.JsonConvert.SerializeObject(retobj);
            }
            return ret;
        }
        #endregion
/*
        #region 數據收集並且存儲數據庫
        [WebMethod]
        public static Com.DataPack.DataRsp<string> UserOrderEditSave(List<string> arr)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            if (Com.Session.userid == null)
            {
                rsp.code = "expire";
                rsp.msg = "你现在登录已过期，请重新登录！";
            }
            else
            {
                string orderpackagestr = "";
                try
                {
                    SchSystem.BLL.ServUserFor sufBll = new SchSystem.BLL.ServUserFor();
                    SchSystem.Model.ServUserFor sufModel = new SchSystem.Model.ServUserFor();
                    foreach (string str in arr)
                    {
                        string[] strarr = str.Split('#');
                        if (strarr[0] == "account") { sufModel.UserName = strarr[1]; }
                        else if (strarr[0] == "additional") { sufModel.RecUser = strarr[1]; }
                        else if (strarr[0] == "usersource") { sufModel.FromType = strarr[1]; }
                        else if (strarr[0] == "tagsorderpackage") { sufModel.ServiceId = strarr[1]; }
                        else if (strarr[0] == "orderlength") { sufModel.ServMonth = int.Parse(strarr[1]); }
                        else if (strarr[0] == "payamount") { sufModel.FeeM = int.Parse(strarr[1]); }
                        else if (strarr[0] == "orderendtime") { sufModel.EndTime = DateTime.Parse(strarr[1]); }
                        else if (strarr[0] == "orderpackagestr") { orderpackagestr = strarr[1]; }
                    }
                    
                    int result = sufBll.ProcAdd(sufModel.UserName, sufModel.RecUser, sufModel.FromType, sufModel.ServiceId, sufModel.ServMonth, sufModel.FeeM, sufModel.EndTime);
                    if (result > 0)
                    {
                        SchSystem.BLL.ServUserForExt sufeBll = new SchSystem.BLL.ServUserForExt();
                        //sufeBll.DeleteId(result);
                        SchSystem.Model.ServUserForExt sufeModel = new SchSystem.Model.ServUserForExt();
                        if (!string.IsNullOrEmpty(orderpackagestr))
                        {
                            string[] orderpackagearr = orderpackagestr.Split('$');
                            int orderpackagearrLen = orderpackagearr.Length;
                            for (int i = 0; i < orderpackagearrLen; i++)//遍歷實體（記錄）
                            {
                                string[] ordpackarr = orderpackagearr[i].Split('|');
                                int ordpackarrlen = ordpackarr.Length;
                                sufeModel.UserForId = result;//遍歷屬性（字段）：對應的訂購ID
                                sufeModel.Fcode = ordpackarr[0];//遍歷屬性（字段）：功能碼
                                sufeModel.NapeCode = ordpackarr[1];//遍歷屬性（字段）：下拉列表代碼
                                sufeModel.NapeCodes = ordpackarr[2];//遍歷屬性（字段）：對應的下拉列表代碼串
                                if ((sufeModel.NapeCodes).ToString() != "null")
                                {
                                    sufeBll.Add(sufeModel);
                                }
                            }
                        }
                        rsp.code = "success";
                        rsp.msg = "操作成功";
                    }
                    else
                    {
                        rsp.code = "error";
                        rsp.msg = "操作失败";
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
*/
        [WebMethod]
        public static Com.DataPack.DataRsp<string> UserOrderSave(List<string> arr)
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
                    SchSystem.BLL.ServUserFor ssBll = new SchSystem.BLL.ServUserFor();
                    SchSystem.Model.ServUserFor ssModel = new SchSystem.Model.ServUserFor();
                    ssModel.FromType = "客服修改";
                    foreach (string str in arr)
                    {
                        string[] strarr = str.Split('#');
                        if (strarr[0] == "autoid") { ssModel.AutoId = int.Parse(strarr[1]); }
                        if (strarr[0] == "Stat") { ssModel.ServStat = int.Parse(strarr[1]); }
                        if (strarr[0] == "Note") { ssModel.DoNote = strarr[1]; }
                        
                    }
                    //bool resbool = ssBll.Exists(ssModel.SysCode);
                    //if (!resbool)
                    //{
                        bool result = ssBll.Update(ssModel);
                       if (result)  
                        {
                            rsp.code = "success";
                            rsp.msg = "操作成功";
                        }
                        else
                        {
                            rsp.code = "error";
                            rsp.msg = "操作失败";
                        }
                    //}
                    //else
                    //{
                    //    rsp.code = "PlatCodeRepeat";
                    //    rsp.msg = "平台代码不允许重复";
                    //}
                }
                catch (Exception ex)
                {
                    rsp.code = "ExcepError";
                    rsp.msg = ex.Message;
                }
            }
            return rsp;

        }
        #region 返回URL结果
        //public static string GetURLResult(string strUrl)  
        //{  
        //    string strMsg = "";
        //    try
        //    {
        //        WebRequest request = WebRequest.Create(strUrl);
        //        WebResponse response = request.GetResponse();
        //        StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312"));
        //        strMsg = reader.ReadToEnd();
        //        reader.Close();
        //        reader.Dispose();
        //        response.Close();
        //    }
        //    catch(Exception e)
        //    { }
        //    return strMsg;
        //}  
        #endregion 
        [Serializable]
        private class retprompt
        {
            public string retxt;
            public object retobj;//servfunc
            public object servfuncext;//servfuncext
            public object sysext;
        }
        //[Serializable]
        //private class BackToTips
        //{
        //    public string retxt;
        //    public object retobj;
        //}
    }
}