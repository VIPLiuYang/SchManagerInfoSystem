using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchWebApi.Controllers
{
    /// <summary>
    /// 管理平台接口
    /// </summary>
    public class DataController : ApiController
    {
        /// <summary>
        /// 加密信息接口
        /// </summary>
        /// <param name="pokeys">POST的数据</param>
        /// <returns>返回包</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.RSAKeyValue> ShakeHand([FromBody]Com.DataPack.ShakeKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.RSAKeyValue> rsp = new Com.DataPack.DataRsp<Com.DataPack.RSAKeyValue>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "shaketype=" + pokeys.shaketype };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //将uuid用'|'加特征字符shaketype组成key,判断该类型的公钥key是否存在,
                //公钥key
                string shakeplckey = pokeys.uuid + "|" + pokeys.shaketype + "|shakeplc";
                //私钥key
                string shakeprakey = pokeys.uuid + "|" + pokeys.shaketype + "|shakepra";
                //私钥值
                string shakeprakeyvalue = Com.Public.GetCacheKey(shakeprakey);
                //公钥值
                string shakeplckeyvalue = Com.Public.GetCacheKey(shakeplckey);

                //Comm.DataPack.RSAKeyValue plckey = new Comm.DataPack.RSAKeyValue();
                //如果不存在,则重新生成并保存该key,并设置过期时间
                if (string.IsNullOrEmpty(shakeplckeyvalue))
                {
                    //生成RSA密码对
                    string[] scrersa = Com.RsaV.GenerateKeys();
                    //缓存公钥和私钥,并加过期时间
                    shakeplckeyvalue = scrersa[1];

                    Com.Public.SetCacheKey(shakeplckey, scrersa[1], DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                    Com.Public.SetCacheKey(shakeprakey, scrersa[0], DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                }
                else//如果存在,重置过期时间
                {
                    Com.Public.SetCacheKeyExp(shakeplckey, DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                    Com.Public.SetCacheKeyExp(shakeprakey, DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                }
                Com.DataPack.RSAKeyValue plckey = (Com.DataPack.RSAKeyValue)Com.XmlSerializeUtil.Deserialize(typeof(Com.DataPack.RSAKeyValue), shakeplckeyvalue);
                plckey.Exponent = Com.Public.BytesToHexString(Convert.FromBase64String(plckey.Exponent));
                plckey.Modulus = Com.Public.BytesToHexString(Convert.FromBase64String(plckey.Modulus));
                rsp.RspData = plckey;
            }
            catch (Exception ex)
            {
                Com.Public.WriteLog("ShakeHand", "", ex.ToString());
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            return rsp;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="pokeys">登录的信息</param>
        /// <returns>登录返回的信息</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.UserInfo> Login([FromBody]Com.DataPack.LoginKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = new Com.DataPack.DataRsp<Com.DataPack.UserInfo>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "shaketype=" + pokeys.shaketype, "schid=" + pokeys.schid, "utp=" + pokeys.utp, "uid=" + pokeys.uid, "pw=" + pokeys.pw };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //获取私钥
                //私钥key
                string shakeprakey = pokeys.uuid + "|" + pokeys.shaketype + "|shakepra";
                //string shakeplckey = uuid + "|" + shaketype + "|shakeplc";
                //私钥值
                string shakeprakeyvalue = Com.Public.GetCacheKey(shakeprakey);
                //返回用户信息包,并跳到完成昵称及修改登陆密码页面
                Com.DataPack.UserInfo uinfo = new Com.DataPack.UserInfo();
                //游客身份
                //解密UID,可能是手机号或账号,邮箱等
                string decuid = Com.RsaV.RSADec(shakeprakeyvalue, pokeys.uid);
                SchSystem.BLL.SchInfo schbll = new SchSystem.BLL.SchInfo();
                SchSystem.Model.SchInfo schmodel;
                if (decuid == "00000000000")
                {
                    string uuidutid = pokeys.uuid + ":0:" + pokeys.schid + ":游客:0";
                    string token = Com.Public.MadeToken(uuidutid, "0");
                    //存储令牌,令牌值为uuid:uid:utid,可以根据令牌识别用户和设备号和用户表ID
                    Com.Public.SetCacheKey(token, uuidutid, DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                    //存储用户登录hash,以便以后多设备同用户登录逻辑用,可根据token获取到uuid及uid,utid,根据这两个值操作对应的hash及对比,删除等操作
                    Com.Public.SetCacheKeyHash("userlogin:0", pokeys.uuid, token, DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                    schmodel = schbll.GetModel(int.Parse(pokeys.schid));
                    uinfo.schname = schmodel.SchName;
                    uinfo.areano = schmodel.AreaNo;
                    uinfo.appxxtdouser = schmodel.HomeSchBasicStat;
                    uinfo.appxxtservstat = schmodel.HomeschServStat;
                    uinfo.appxxtname = schmodel.HomeSchPlatName;
                    if (!string.IsNullOrEmpty(schmodel.HomeSchPlatIco))
                    {
                        uinfo.appxxtico = Com.Public.GetKey("adminurl") + schmodel.HomeSchPlatIco.Replace("\\", "/");
                    }
                    //获取子系统编辑状态
                    uinfo.appeditstat = Convert.ToInt32(schmodel.SonSysStat);
                    uinfo.uid = "00000000000";
                    uinfo.utid = 0;
                    uinfo.utname = "游客";
                    uinfo.utp = int.Parse(pokeys.utp);
                    uinfo.utoken = token;
                    rsp.RspData = uinfo;
                    return rsp;
                }


                //公钥值
                //string shakeplckeyvalue = Redis.Get<string>(shakeplckey);
                //如果私钥不存在,需要重新握手
                if (string.IsNullOrEmpty(shakeprakeyvalue))
                {
                    rsp.RspCode = "0002";
                    rsp.RspTxt = "时间过期需要重新握手";
                }
                else//私钥有效期还在,则开始验证
                {
                    int schid = int.Parse(pokeys.schid);
                    //解密密码
                    string decpw = Com.RsaV.RSADec(shakeprakeyvalue, pokeys.pw);
                    //MD5编码pw
                    string md5pw = Com.Public.StrToMD5(decpw);

                    //判断uid是否已存在,不存在则提示用户不存在
                    SchSystem.BLL.SchUserInfo userbll = new SchSystem.BLL.SchUserInfo();
                    bool result = false;
                    if (schid == 0)
                    {
                        result = userbll.Exists(decuid, md5pw);
                    }
                    else
                    {
                        result = userbll.ExistsSchUser(decuid, md5pw, schid);
                    }
                    //如果不是教师用户
                    if (!result)
                    {
                        //查找注册用户
                        SchSystem.BLL.ServUser servuserbll = new SchSystem.BLL.ServUser();
                        if (servuserbll.Exists(decuid, md5pw))//有对应的注册用户,则获取用户信息
                        {
                            SchSystem.Model.ServUser servusermodel = servuserbll.GetModel(decuid);
                            uinfo.schid = 0;
                            uinfo.sex = servusermodel.Usex;
                            uinfo.uid = decuid;
                            uinfo.utid = servusermodel.AutoId;
                            uinfo.utname = servusermodel.UTname;
                            uinfo.utp = 1;
                            uinfo.imgurl = servusermodel.Uico;
                            //用户uid存在,生成Token并存储,设2个小时过期
                            string uuidutid = pokeys.uuid + ":" + servusermodel.AutoId.ToString() + ":0:" + servusermodel.UTname + ":1";
                            string token = Com.Public.MadeToken(uuidutid, servusermodel.AutoId.ToString());
                            //存储令牌,令牌值为uuid:uid:utid,可以根据令牌识别用户和设备号和用户表ID
                            Com.Public.SetCacheKey(token, uuidutid, DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                            //存储用户登录hash,以便以后多设备同用户登录逻辑用,可根据token获取到uuid及uid,utid,根据这两个值操作对应的hash及对比,删除等操作
                            Com.Public.SetCacheKeyHash("servuserlogin:" + servusermodel.AutoId.ToString(), pokeys.uuid, token, DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                            uinfo.utoken = token;
                            rsp.RspData = uinfo;
                        }
                        else//查找学生用户
                        {
                            SchSystem.BLL.SchStuInfo stuinfobll = new SchSystem.BLL.SchStuInfo();
                            if (stuinfobll.Exists(decuid, md5pw))//有对应的学生用户,则获取用户信息
                            {
                                SchSystem.Model.SchStuInfo stumodel = stuinfobll.GetModel(decuid);
                                uinfo.schid = stumodel.SchId;
                                uinfo.sex = stumodel.Sex;
                                uinfo.uid = decuid;
                                uinfo.utid = stumodel.StuId;
                                uinfo.utname = stumodel.StuName;
                                uinfo.utp = 2;
                                uinfo.imgurl = stumodel.ImgUrl;
                                //用户uid存在,生成Token并存储,设2个小时过期
                                string uuidutid = pokeys.uuid + ":" + stumodel.StuId.ToString() + ":" + stumodel.SchId.ToString() + ":" + stumodel.StuName + ":2";
                                string token = Com.Public.MadeToken(uuidutid, stumodel.StuId.ToString());
                                //存储令牌,令牌值为uuid:uid:utid,可以根据令牌识别用户和设备号和用户表ID
                                Com.Public.SetCacheKey(token, uuidutid, DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                                //存储用户登录hash,以便以后多设备同用户登录逻辑用,可根据token获取到uuid及uid,utid,根据这两个值操作对应的hash及对比,删除等操作
                                Com.Public.SetCacheKeyHash("servstulogin:" + stumodel.StuId.ToString(), pokeys.uuid, token, DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                                uinfo.utoken = token;
                                rsp.RspData = uinfo;
                            }
                            else
                            {
                                rsp.RspCode = "0005";
                                rsp.RspTxt = "用户名或密码不正确:" + decuid;
                            }
                        }

                    }
                    else//密码正确
                    {

                        //获取用户信息
                        SchSystem.Model.SchUserInfo usermodel = userbll.GetModelByUname(decuid);
                        if (usermodel != null && usermodel.UserId > 0)
                        {
                            uinfo.isadmin = usermodel.SysType;
                            //用户执教班级
                            SchSystem.BLL.SchClassUser schclassuserbll = new SchSystem.BLL.SchClassUser();
                            DataTable dtcls = schclassuserbll.GetListV("GradeId grdid,GradeCode grdcode,ClassName clsname,ClassId clsid,SubCode subcode,IsMs isms,IsFinish isfinish", "UserName=" + usermodel.UserId + " Order by GradeCode,ClassName").Tables[0];
                            if (dtcls != null && dtcls.Rows.Count > 0)
                            {
                                uinfo.clss = Com.Public.DataTableToList<Com.DataPack.ClassSub>(dtcls);
                            }
                            //用户所在部门
                            SchSystem.BLL.SchUserDeptV userdptbll = new SchSystem.BLL.SchUserDeptV();
                            DataTable dtdpt = userdptbll.GetList("DeptId dptid,DepartName dptname", "Stat=1 and UserId=" + usermodel.UserId).Tables[0];
                            if (dtdpt != null && dtdpt.Rows.Count > 0)
                            {
                                uinfo.dpts = Com.Public.DataTableToList<Com.DataPack.Depart>(dtdpt);
                            }
                            //用户管理年级
                            SchSystem.BLL.SchGradeUserV usergradebll = new SchSystem.BLL.SchGradeUserV();
                            DataTable dtgrade = usergradebll.GetList("GradeId grdid,GradeCode grdcode,GradeName grdname,IsFinish isfinish", "UserName=" + usermodel.UserId + " Order by GradeCode").Tables[0];
                            if (dtgrade != null && dtgrade.Rows.Count > 0)
                            {
                                uinfo.grds = Com.Public.DataTableToList<Com.DataPack.GradeBoss>(dtgrade);
                            }

                            //用户学科组长
                            SchSystem.BLL.SchUserSubV usersubbll = new SchSystem.BLL.SchUserSubV();
                            DataTable dtsubs = usersubbll.GetList("SubCode subcode,SubName subname", "UserName=" + usermodel.UserId + " Order by SubCode").Tables[0];
                            if (dtsubs != null && dtsubs.Rows.Count > 0)
                            {
                                uinfo.subs = Com.Public.DataTableToList<Com.DataPack.SubBoss>(dtsubs);
                            }
                            uinfo.schid = usermodel.SchId;
                            if (!string.IsNullOrEmpty(usermodel.ImgUrl))
                            {
                                uinfo.imgurl = Com.Public.GetKey("adminurl") + "/" + usermodel.ImgUrl.Replace("\\", "/");
                            }
                            schmodel = schbll.GetModel(usermodel.SchId);

                            uinfo.schname = schmodel.SchName;
                            uinfo.areano = schmodel.AreaNo;
                            uinfo.appxxtdouser = schmodel.HomeSchBasicStat;
                            uinfo.appxxtservstat = schmodel.HomeschServStat;
                            uinfo.appxxtname = schmodel.HomeSchPlatName;
                            if (!string.IsNullOrEmpty(schmodel.HomeSchPlatIco))
                            {
                                uinfo.appxxtico = Com.Public.GetKey("adminurl") + schmodel.HomeSchPlatIco.Replace("\\", "/");
                            }
                            //获取子系统编辑状态
                            uinfo.appeditstat = Convert.ToInt32(schmodel.SonSysStat);
                            uinfo.sex = usermodel.Sex;
                            uinfo.uid = decuid;
                            //权限合并
                            SchSystem.BLL.SchUserRoleV userroleV = new SchSystem.BLL.SchUserRoleV();
                            DataTable dtroles = userroleV.GetList("UserName='" + Com.Public.SqlEncStr(decuid) + "' and Stat=1 and SchId=" + usermodel.SchId).Tables[0];
                            if (dtroles != null && dtroles.Rows.Count > 0)
                            {
                                uinfo.urolestr = Com.Public.UserRoleStr(dtroles, "RoleStr");
                                uinfo.urolestrext = Com.Public.UserRoleStr(dtroles, "RoleStrExt");
                            }
                            uinfo.utid = usermodel.UserId;
                            uinfo.utname = usermodel.UserTname;
                            uinfo.utp = 0;
                            //资源平台权限
                            SchSystem.BLL.SchUserRoleSoureV userrolesoureV = new SchSystem.BLL.SchUserRoleSoureV();
                            DataTable dtrolesoures = userrolesoureV.GetList("UserName='" + Com.Public.SqlEncStr(decuid) + "' and Stat=1 and SchId=" + usermodel.SchId).Tables[0];
                            if (dtrolesoures != null && dtrolesoures.Rows.Count > 0)
                            {
                                uinfo.urolestrsoure = Com.Public.UserRoleStr(dtrolesoures, "RoleStr");
                            }
                            //校讯通平台权限
                            SchSystem.BLL.SchUserRoleXXTV userrolexxtV = new SchSystem.BLL.SchUserRoleXXTV();
                            DataTable dtrolexxt = userrolexxtV.GetList("UserName='" + Com.Public.SqlEncStr(decuid) + "' and Stat=1 and SchId=" + usermodel.SchId).Tables[0];
                            if (dtrolexxt != null && dtrolexxt.Rows.Count > 0)
                            {
                                uinfo.urolestrxxt = Com.Public.UserRoleStr(dtrolexxt, "RoleStr");
                            }
                            //用户uid存在,生成Token并存储,设2个小时过期
                            string uuidutid = pokeys.uuid + ":" + usermodel.UserId.ToString() + ":" + usermodel.SchId + ":" + usermodel.UserTname + ":0";
                            string token = Com.Public.MadeToken(uuidutid, usermodel.UserId.ToString());
                            //存储令牌,令牌值为uuid:uid:utid,可以根据令牌识别用户和设备号和用户表ID
                            Com.Public.SetCacheKey(token, uuidutid, DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                            //存储用户登录hash,以便以后多设备同用户登录逻辑用,可根据token获取到uuid及uid,utid,根据这两个值操作对应的hash及对比,删除等操作
                            Com.Public.SetCacheKeyHash("userlogin:" + usermodel.UserId.ToString(), pokeys.uuid, token, DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                            uinfo.utoken = token;
                            rsp.RspData = uinfo;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Com.Public.WriteLog("Login", "", ex.ToString());

                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }

            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="pokeys"></param>
        /// <returns></returns>
        [HttpPost]
        public Com.DataPack.DataRsp<string> GetCode([FromBody]Com.DataPack.CodeKey pokeys)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "shaketype=" + pokeys.shaketype, "uid=" + pokeys.uid, "appid=" + pokeys.appid };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //私钥key
                string shakeprakey = pokeys.uuid + "|" + pokeys.shaketype + "|shakepra";
                string shakeplckey = pokeys.uuid + "|" + pokeys.shaketype + "|shakeplc";
                //私钥值
                string shakeprakeyvalue = Com.Public.GetCacheKey(shakeprakey);
                //公钥值
                string shakeplckeyvalue = Com.Public.GetCacheKey(shakeplckey);
                //如果私钥不存在,需要重新握手
                if (string.IsNullOrEmpty(shakeprakeyvalue))
                {
                    rsp.RspCode = "0002";
                    rsp.RspTxt = "时间过期需要重新握手";
                }
                else//密码有效期还在,则可以生成验证码
                {
                    //将uuid用'|'加特征字符shaketype'|code|'+uid,判断该类型的key是否存在,如果存在,返回该key的value;如果不存在
                    string decuid = Com.RsaV.RSADec(shakeprakeyvalue, pokeys.uid);
                    //codekey
                    string codekey = pokeys.uuid + "|" + pokeys.shaketype + "|code|" + decuid;
                    //codevalue
                    string codekeyvalue = Com.Public.GetCacheKey(codekey);
                    //如果不存在,则重新生成并保存该key,并设置过期时间
                    if (string.IsNullOrEmpty(codekeyvalue))
                    {
                        //生成code
                        codekeyvalue = Com.Public.RandCode(decuid, pokeys.shaketype);
                        //缓存code
                        Com.Public.SetCacheKey(codekey, codekeyvalue, DateTime.Now.AddSeconds(300));
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 手机验证码验证
        /// </summary>
        /// <param name="pokeys"></param>
        /// <returns></returns>
        [HttpPost]
        public Com.DataPack.DataRsp<string> ValCode([FromBody]Com.DataPack.CodeKey pokeys)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "shaketype=" + pokeys.shaketype, "uid=" + pokeys.uid, "code=" + pokeys.code, "appid=" + pokeys.appid };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //私钥key
                string shakeprakey = pokeys.uuid + "|" + pokeys.shaketype + "|shakepra";
                string shakeplckey = pokeys.uuid + "|" + pokeys.shaketype + "|shakeplc";
                //私钥值
                string shakeprakeyvalue = Com.Public.GetCacheKey(shakeprakey);
                //公钥值
                string shakeplckeyvalue = Com.Public.GetCacheKey(shakeplckey);
                //如果私钥不存在,需要重新握手
                if (string.IsNullOrEmpty(shakeprakeyvalue))
                {
                    rsp.RspCode = "0002";
                    rsp.RspTxt = "时间过期需要重新握手";
                }
                else//密码有效期还在,则可以生成验证码
                {
                    //将uuid用'|'加特征字符shaketype'|code|'+uid,判断该类型的key是否存在,如果存在,返回该key的value;如果不存在
                    string decuid = Com.RsaV.RSADec(shakeprakeyvalue, pokeys.uid);
                    //codekey
                    string codekey = pokeys.uuid + "|" + pokeys.shaketype + "|code|" + decuid;
                    //codevalue
                    string codekeyvalue = Com.Public.GetCacheKey(codekey);
                    //解密验证码
                    string deccode = Com.RsaV.RSADec(shakeprakeyvalue, pokeys.code);
                    if (deccode != codekeyvalue)
                    {
                        rsp.RspCode = "0003";
                        rsp.RspTxt = "验证码不正确或者已过期";
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="pokeys"></param>
        /// <returns></returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.UserInfo> UserReg([FromBody]Com.DataPack.UserRegKey pokeys)
        {
            //根据key判断code是否存在,不存在提示重新获取(调获取验证码接口),存在进入下一步
            //判断code是否正确,不正确,返回提示重新输入,正确进入下一步;
            //判断用户名已存在,返回提示用户是否登录,登录则进入生成token进入使用;(填写昵称,设置登录密码)
            //用户名不存在,注册登记,返回并生成token进入成功使用;
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = new Com.DataPack.DataRsp<Com.DataPack.UserInfo>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "shaketype=" + pokeys.shaketype, "uid=" + pokeys.uid, "appid=" + pokeys.appid, "code=" + pokeys.code, "pw=" + pokeys.pw, "utn=" + pokeys.utn, "usex=" + pokeys.usex };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //私钥key
                string shakeprakey = pokeys.uuid + "|" + pokeys.shaketype + "|shakepra";
                //string shakeplckey = uuid + "|" + shaketype + "|shakeplc";
                //私钥值
                string shakeprakeyvalue = Com.Public.GetCacheKey(shakeprakey);
                //公钥值
                //string shakeplckeyvalue = Redis.Get<string>(shakeplckey);
                //如果私钥不存在,需要重新握手
                if (string.IsNullOrEmpty(shakeprakeyvalue))
                {
                    rsp.RspCode = "0002";
                    rsp.RspTxt = "时间过期需要重新握手";
                }
                else//密码有效期还在,则开始验证
                {
                    //解密UID
                    string decuid = Com.RsaV.RSADec(shakeprakeyvalue, pokeys.uid);
                    //codekey
                    string codekey = pokeys.uuid + "|" + pokeys.shaketype + "|code|" + decuid;
                    //codevalue
                    string codekeyvalue = Com.Public.GetCacheKey(codekey);
                    //解密验证码
                    string deccode = Com.RsaV.RSADec(shakeprakeyvalue, pokeys.code);
                    //如果验证码不匹配
                    if (deccode != codekeyvalue)
                    {
                        //rsp.RspData = "sendcode:" + deccode + "|savecode:" + codekeyvalue;
                        rsp.RspCode = "0003";
                        rsp.RspTxt = "验证码不正确,请重新输入";
                    }
                    else//验证码正确
                    {

                        //将uid用'|'加特征字符shaketype'|code',判断该类型的key是否存在,如果存在,返回该key的value;如果不存在
                        //解密密码
                        string decpw = Com.RsaV.RSADec(shakeprakeyvalue, pokeys.pw);
                        //MD5编码pw
                        string md5pw = Com.Public.StrToMD5(decpw);

                        //判断手机号是否已存在,不存在则添加记录,再验证码登陆
                        SchSystem.BLL.ServUser userbll = new SchSystem.BLL.ServUser();
                        bool bok = userbll.Exists(decuid);
                        if (!bok)//如果没有该账户
                        {
                            SchSystem.Model.ServUser usermodel = new SchSystem.Model.ServUser();
                            usermodel.Pwd = md5pw;
                            usermodel.UserName = decuid;
                            //要有严格的算法,唯一及两者之间保证严密的关系
                            usermodel.Usex = pokeys.usex;
                            usermodel.UTname = pokeys.utn;
                            userbll.Add(usermodel);
                        }
                        else
                        {
                            rsp.RspCode = "0005";
                            rsp.RspTxt = "该账号已经被注册";
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }

            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 获取学校下的年级信息
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.GradeList> SchGrade([FromBody]Com.DataPack.SchKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.GradeList> rsp = new Com.DataPack.DataRsp<Com.DataPack.GradeList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "isfinish=" + pokeys.isfinish, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    string isfinishw = "";
                    if (pokeys.isfinish != -1)
                    {
                        isfinishw = "isfinish=" + pokeys.isfinish + " and ";
                    }
                    else
                    {
                        isfinishw = "(isfinish=1 or isfinish=0) and ";
                    }
                    SchSystem.BLL.SchGradeInfo schgradebll = new SchSystem.BLL.SchGradeInfo();
                    DataTable dtgrade = schgradebll.GetList(" left(GradeCode,1) pcode,GradeCode grdcode,GradeName grdname,GradeYear grdyear,GradeId grdid,isfinish", isfinishw + "SchId=" + schid + " order by GradeCode").Tables[0];
                    if (dtgrade != null && dtgrade.Rows.Count > 0)
                    {
                        DataView dv = dtgrade.DefaultView;
                        DataTable dtcode = dv.ToTable(true, "pcode");
                        for (int i = 0; i < dtcode.Rows.Count; i++)
                        {
                            DataRow dry = dtgrade.NewRow();
                            if (dtcode.Rows[i]["pcode"].ToString() == "1")
                            {
                                dry["pcode"] = "0";
                                dry["grdcode"] = "1";
                                dry["grdname"] = "幼儿园";
                                dtgrade.Rows.Add(dry);
                            }
                            else if (dtcode.Rows[i]["pcode"].ToString() == "2")
                            {
                                dry["pcode"] = "0";
                                dry["grdcode"] = "2";
                                dry["grdname"] = "小学";
                                dtgrade.Rows.Add(dry);
                            }
                            else if (dtcode.Rows[i]["pcode"].ToString() == "3")
                            {
                                dry["pcode"] = "0";
                                dry["grdcode"] = "3";
                                dry["grdname"] = "初中";
                                dtgrade.Rows.Add(dry);
                            }
                            else if (dtcode.Rows[i]["pcode"].ToString() == "4")
                            {
                                dry["pcode"] = "0";
                                dry["grdcode"] = "4";
                                dry["grdname"] = "高中";
                                dtgrade.Rows.Add(dry);
                            }
                        }
                        Com.DataPack.GradeList gradelist = new Com.DataPack.GradeList();
                        gradelist.grds = Com.Public.DataTableToList<Com.DataPack.GradeInfo>(dtgrade);
                        rsp.RspData = gradelist;
                    }

                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 获取学校下班级数据
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.ClassList> SchClass([FromBody]Com.DataPack.SchKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.ClassList> rsp = new Com.DataPack.DataRsp<Com.DataPack.ClassList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "isfinish=" + pokeys.isfinish, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    string isfinishw = "SchId=" + schid;
                    if (pokeys.isfinish != -1)
                    {
                        isfinishw += " and isfinish=" + pokeys.isfinish;
                    }
                    else
                    {
                        isfinishw += " and (isfinish=1 or isfinish=0) ";
                    }
                    SchSystem.BLL.SchClassInfo schclassbll = new SchSystem.BLL.SchClassInfo();
                    DataTable dtclass = schclassbll.GetList(" GradeCode grdcode,ClassName clsname,ClassId clsid,GradeId grdid,isfinish", isfinishw + " order by GradeCode,ClassName").Tables[0];
                    if (dtclass != null && dtclass.Rows.Count > 0)
                    {
                        Com.DataPack.ClassList classlist = new Com.DataPack.ClassList();
                        classlist.clss = Com.Public.DataTableToList<Com.DataPack.ClassInfo>(dtclass);
                        rsp.RspData = classlist;
                    }

                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 获取学校下科目数据
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.SubList> SchSub([FromBody]Com.DataPack.SchKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.SubList> rsp = new Com.DataPack.DataRsp<Com.DataPack.SubList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    SchSystem.BLL.SchSub schsubbll = new SchSystem.BLL.SchSub();
                    DataTable dtsub = schsubbll.GetList(" SubCode subcode,SubName subname", "stat=1 and SchId=" + schid + " order by SubCode ").Tables[0];
                    if (dtsub != null && dtsub.Rows.Count > 0)
                    {
                        Com.DataPack.SubList sublist = new Com.DataPack.SubList();
                        sublist.subs = Com.Public.DataTableToList<Com.DataPack.SubInfo>(dtsub);
                        rsp.RspData = sublist;
                    }


                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 学校部门
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.DepartList> SchDepart([FromBody]Com.DataPack.SchKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.DepartList> rsp = new Com.DataPack.DataRsp<Com.DataPack.DepartList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    SchSystem.BLL.SchDepartInfo schdptbll = new SchSystem.BLL.SchDepartInfo();
                    DataTable dtdpt = schdptbll.GetList(" Pid pid,DepartId dptid,DepartName dptname,OrderId orderid", "stat=1 and SchId=" + schid + " order by Pid,OrderId").Tables[0];
                    if (dtdpt != null && dtdpt.Rows.Count > 0)
                    {
                        Com.DataPack.DepartList dptlist = new Com.DataPack.DepartList();
                        dptlist.dpts = Com.Public.DataTableToList<Com.DataPack.DepartInfo>(dtdpt);
                        rsp.RspData = dptlist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 年级主任
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.GradeBossList> GradeBoss([FromBody]Com.DataPack.GradeKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.GradeBossList> rsp = new Com.DataPack.DataRsp<Com.DataPack.GradeBossList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "gradeids=" + pokeys.gradeids, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    string gradeids = Com.Public.SqlEncStr(pokeys.gradeids);
                    SchSystem.BLL.SchGradeUserV schgrdbossbll = new SchSystem.BLL.SchGradeUserV();
                    DataTable dtgrdboss = schgrdbossbll.GetList(" GradeCode grdcode,convert(int,UserName) utid,UserTname utname,GradeId grdid,CASE WHEN len(ImgUrl)>0 THEN '" + Com.Public.GetKey("adminurl") + "/" + "'+replace(ImgUrl,'\\','/') ELSE '' END  imgurl,Mobile mobile", "GradeId in (" + gradeids + ")").Tables[0];
                    if (dtgrdboss != null && dtgrdboss.Rows.Count > 0)
                    {
                        Com.DataPack.GradeBossList dptlist = new Com.DataPack.GradeBossList();
                        dptlist.grdbosss = Com.Public.DataTableToList<Com.DataPack.GradeBossInfo>(dtgrdboss);
                        rsp.RspData = dptlist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 年级下班级
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.ClassList> GradeClass([FromBody]Com.DataPack.GradeKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.ClassList> rsp = new Com.DataPack.DataRsp<Com.DataPack.ClassList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "gradeids=" + pokeys.gradeids, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    string gradeids = Com.Public.SqlEncStr(pokeys.gradeids);
                    SchSystem.BLL.SchClassInfo schgrdclassbll = new SchSystem.BLL.SchClassInfo();
                    DataTable dtgrdclass = schgrdclassbll.GetListV(" GradeCode grdcode,ClassName clsname,ClassId clsid,GradeId grdid,ClassStat isfinish", "(IsFinish=0 or IsFinish=1) and (ClassStat=0 or ClassStat=1) and GradeId in (" + gradeids + ") order by GradeCode,ClassName").Tables[0];
                    if (dtgrdclass != null && dtgrdclass.Rows.Count > 0)
                    {
                        Com.DataPack.ClassList dptlist = new Com.DataPack.ClassList();
                        dptlist.clss = Com.Public.DataTableToList<Com.DataPack.ClassInfo>(dtgrdclass);
                        rsp.RspData = dptlist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 班级下任课老师
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.ClassUserList> ClassTec([FromBody]Com.DataPack.ClassKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.ClassUserList> rsp = new Com.DataPack.DataRsp<Com.DataPack.ClassUserList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "classids=" + pokeys.classids, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    string classids = Com.Public.SqlEncStr(pokeys.classids);
                    SchSystem.BLL.SchClassUser schgrdclassbll = new SchSystem.BLL.SchClassUser();
                    DataTable dtclassuser = schgrdclassbll.GetListV(" GradeCode grdcode,ClassName clsname,ClassId clsid,SubCode subcode,IsMs isms,convert(int,UserName) utid,UserTname utname,subname,CASE WHEN len(ImgUrl)>0 THEN '" + Com.Public.GetKey("adminurl") + "/" + "'+replace(ImgUrl,'\\','/') ELSE '' END imgurl,Mobile mobile ", "ClassId in (" + classids + ") order by GradeCode,ClassName,UserTname").Tables[0];
                    if (dtclassuser != null && dtclassuser.Rows.Count > 0)
                    {
                        Com.DataPack.ClassUserList dptlist = new Com.DataPack.ClassUserList();
                        dptlist.clssusers = Com.Public.DataTableToList<Com.DataPack.ClassUserInfo>(dtclassuser);
                        rsp.RspData = dptlist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 班级下学生
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.StuList> ClassStu([FromBody]Com.DataPack.ClassKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.StuList> rsp = new Com.DataPack.DataRsp<Com.DataPack.StuList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "classids=" + pokeys.classids, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    string classids = Com.Public.SqlEncStr(pokeys.classids);
                    SchSystem.BLL.SchStuInfoV schgrdclassbll = new SchSystem.BLL.SchStuInfoV();
                    DataTable dtclassuser = schgrdclassbll.GetList(" GradeCode grdcode,GradeName grdname,ClassId clsid,ClassName clsname,StuId stuid,StuName stuname,StuNo stuno,Sex sex,CardNo cardno", "StuStat=1 and ClassId in (" + classids + ") order by GradeCode,ClassName,StuName").Tables[0];
                    if (dtclassuser != null && dtclassuser.Rows.Count > 0)
                    {
                        Com.DataPack.StuList dptlist = new Com.DataPack.StuList();
                        dptlist.clssstus = Com.Public.DataTableToList<Com.DataPack.StuInfo>(dtclassuser);
                        rsp.RspData = dptlist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 部门下老师
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.UserList> DepartUser([FromBody]Com.DataPack.DepartKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.UserList> rsp = new Com.DataPack.DataRsp<Com.DataPack.UserList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "dptids=" + pokeys.dptids, "uidstat=" + pokeys.uidstat, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    string dptids = Com.Public.SqlEncStr(pokeys.dptids);
                    SchSystem.BLL.SchUserDeptV schgrdclassbll = new SchSystem.BLL.SchUserDeptV();
                    string uidstat = "";
                    if (pokeys.uidstat != -1)
                    {
                        if (pokeys.uidstat == 1)
                        {
                            uidstat += " and len(UserName)>0";
                        }
                        if (pokeys.uidstat == 0)
                        {
                            uidstat += " and len(UserName)=0";
                        }
                    }
                    DataTable dtclassuser = schgrdclassbll.GetList(" DeptId dptid,UserId utid,UserTname utname,UserName uid,Sex sex,ImgUrl imgurl,Mobile mobile", "Ustat=1 and DeptId in (" + dptids + ")" + uidstat + " order by DeptId,UserTname").Tables[0];

                    if (dtclassuser != null && dtclassuser.Rows.Count > 0)
                    {
                        Com.DataPack.UserList dptlist = new Com.DataPack.UserList();
                        dptlist.users = Com.Public.DataTableToList<Com.DataPack.UserDeptInfo>(dtclassuser);
                        for (int i = 0; i < dptlist.users.Count; i++)
                        {
                            //头像
                            if (!string.IsNullOrEmpty(dptlist.users[i].imgurl))
                            {
                                dptlist.users[i].imgurl = Com.Public.GetKey("adminurl") + "/" + dptlist.users[i].imgurl.Replace("\\", "/");
                            }
                            //用户所在部门
                            SchSystem.BLL.SchUserDeptV userdptbll = new SchSystem.BLL.SchUserDeptV();
                            DataTable dtdpt = userdptbll.GetList("DeptId dptid,DepartName dptname", "Stat=1 and UserId=" + dptlist.users[i].utid).Tables[0];
                            if (dtdpt != null && dtdpt.Rows.Count > 0)
                            {
                                dptlist.users[i].udpts = Com.Public.DataTableToList<Com.DataPack.Depart>(dtdpt);
                            }
                        }

                        rsp.RspData = dptlist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }

        /// <summary>
        /// 令牌续订
        /// </summary>
        /// <param name="pokeys">uuid,utid,appid</param>
        /// <returns>返回值</returns>
        public Com.DataPack.DataRsp<string> TokenReset([FromBody]Com.DataPack.TokenKeys pokeys)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "utid=" + pokeys.utid, "schid=" + pokeys.schid, "utname=" + pokeys.utname, "appid=" + pokeys.appid, "utp=" + pokeys.utp, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                //用户uid存在,生成Token并存储,设2个小时过期

                //用户uid存在,生成Token并存储,设2个小时过期
                string uuidutid = pokeys.uuid + ":" + pokeys.utid + ":" + pokeys.schid + ":" + pokeys.utname + ":" + pokeys.utp;

                //string uuidutid = pokeys.uuid + ":" + pokeys.utid + ":" + pokeys.schid + ":" + pokeys.utname;
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    //判断之前的用户表中是否存在,如果存在则允许重置,否则失败,提示重新登录
                    bool bok = false;
                    if (pokeys.utp == 0)
                    {
                        bok = Com.Public.ExistKeyHash("userlogin:" + pokeys.utid, pokeys.uuid);
                    }
                    else if (pokeys.utp == 1)
                    {
                        //servuserlogin
                        bok = Com.Public.ExistKeyHash("servuserlogin:" + pokeys.utid, pokeys.uuid);

                    }
                    else if (pokeys.utp == 2)
                    {
                        bok = Com.Public.ExistKeyHash("servstulogin:" + pokeys.utid, pokeys.uuid);
                    }
                    if (bok)
                    {
                        string token = Com.Public.MadeToken(uuidutid, pokeys.utid.ToString());
                        //存储令牌,令牌值为uuid:uid:utid,可以根据令牌识别用户和设备号和用户表ID
                        Com.Public.SetCacheKey(token, uuidutid, DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                        //存储用户登录hash,以便以后多设备同用户登录逻辑用,可根据token获取到uuid及utid,根据这两个值操作对应的hash及对比,删除等操作
                        bool results = false;
                        if (pokeys.utp == 0)
                        {
                            results = Com.Public.SetCacheKeyHash("userlogin:" + pokeys.utid, pokeys.uuid, token, DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                        }
                        else if (pokeys.utp == 1)
                        {
                            //servuserlogin
                            results = Com.Public.SetCacheKeyHash("servuserlogin:" + pokeys.utid, pokeys.uuid, token, DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                        }
                        else if (pokeys.utp == 2)
                        {
                            results = Com.Public.SetCacheKeyHash("servstulogin:" + pokeys.utid, pokeys.uuid, token, DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                        }
                        rsp.RspData = token;
                    }
                    else
                    {
                        rsp.RspCode = "0010";
                        rsp.RspTxt = "需要重新登录";
                    }
                }
                else//token存在,判断用户是否正常
                {
                    if (tokenvalue != uuidutid)
                    {
                        rsp.RspCode = "0007";
                        rsp.RspTxt = "无操作权限";
                    }
                    else
                    {
                        rsp.RspData = pokeys.utoken;
                    }
                }

            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }

            //私钥加密
            return rsp;
        }

        /// <summary>
        /// token用户信息
        /// </summary>
        /// <param name="pokeys">uuid,utid,appid</param>
        /// <returns>返回值</returns>
        public Com.DataPack.DataRsp<string> TokenUser([FromBody]Com.DataPack.TokenUserKey pokeys)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "token过期或需要重新登录";
                }
                else//token存在,判断用户是否正常
                {
                    rsp.RspData = tokenvalue;
                }

            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }

            //私钥加密
            return rsp;
        }

        /// <summary>
        /// 获取区域信息
        /// </summary>
        /// <param name="pokeys">uuid,utid,appid</param>
        /// <returns>返回值</returns>
        public Com.DataPack.DataRsp<Com.DataPack.AreaList> AreaSch([FromBody]Com.DataPack.AreaKey pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.AreaList> rsp = new Com.DataPack.DataRsp<Com.DataPack.AreaList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "atp=" + pokeys.atp, "pcode=" + pokeys.pcode, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    DataTable dt = new DataTable();
                    SchSystem.BLL.SysArea bll = new SchSystem.BLL.SysArea();
                    SchSystem.BLL.SchInfo bllsch = new SchSystem.BLL.SchInfo();
                    string pcode = Com.Public.SqlEncStr(pokeys.pcode);

                    string sqlstr = "";
                    if (pokeys.atp == "0")//取省份
                    {
                        sqlstr = "";
                    }
                    else if (pokeys.atp == "1" && pcode != "")//取城市
                    {
                        if (pcode.Length == 6)
                            sqlstr = " and left(AreaCode,2)='" + pcode.Substring(0, 2) + "'";
                        else sqlstr = " and AreaCode='" + pcode + "'";

                    }
                    else if (pokeys.atp == "2" && pcode != "")//取区县
                    {
                        if (pcode.Length == 6)
                            sqlstr = " and left(AreaCode,4)='" + pcode.Substring(0, 4) + "'";
                        else sqlstr = " and AreaCode='" + pcode + "'";
                    }
                    if (pokeys.atp == "0" || pokeys.atp == "1" || pokeys.atp == "2")
                    {
                        //dt = bll.GetList("AreaCode ID,AreaName Name", "Stat=1 and TypeCode='" + TypeCode + "' " + sqlstr + " Order by AreaName").Tables[0];
                        dt = bll.GetList("AreaCode code,AreaName name", "TypeCode='" + pokeys.atp + "' " + sqlstr + " Order by AreaName").Tables[0];//获取全部省份
                    }
                    else if (pokeys.atp == "3")//学校
                    {
                        dt = bllsch.GetList("Convert(varchar(10),SchId) code,SchName name", "Stat=1 and AreaNo='" + pcode + "' Order by SchName").Tables[0];
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Com.DataPack.AreaList arealist = new Com.DataPack.AreaList();
                        arealist.areas = Com.Public.DataTableToList<Com.DataPack.AreaInfo>(dt);
                        rsp.RspData = arealist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }

            //私钥加密
            return rsp;
        }
        public Com.DataPack.DataRsp<Com.DataPack.AreaList> UnvSch([FromBody]Com.DataPack.AreaKey pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.AreaList> rsp = new Com.DataPack.DataRsp<Com.DataPack.AreaList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "atp=" + pokeys.atp, "pcode=" + pokeys.pcode, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    DataTable dt = new DataTable();                    
                    SchSystem.BLL.SchInfo bllsch = new SchSystem.BLL.SchInfo();
                    string pcode = Com.Public.SqlEncStr(pokeys.pcode);
                    if (pokeys.atp == "3")//学校
                    {
                        dt = bllsch.GetList("Convert(varchar(10),SchId) code,SchName name", "Stat=1 and left(AreaNo," + pcode.Length + ")='" + pcode + "' and SchType=1 Order by SchName").Tables[0];
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Com.DataPack.AreaList arealist = new Com.DataPack.AreaList();
                        arealist.areas = Com.Public.DataTableToList<Com.DataPack.AreaInfo>(dt);
                        rsp.RspData = arealist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }

            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 科目组长
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.SubBossList> SubBoss([FromBody]Com.DataPack.SubKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.SubBossList> rsp = new Com.DataPack.DataRsp<Com.DataPack.SubBossList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "subcodes=" + pokeys.subcodes, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    string subcodes = Com.Public.SqlEncStr(pokeys.subcodes);
                    SchSystem.BLL.SchUserSubV schsubbossbll = new SchSystem.BLL.SchUserSubV();
                    DataTable dtsubboss = schsubbossbll.GetList(" SubCode subcode,convert(int,UserName) utid,UserTname utname", "SchId=" + schid + " and SubCode in (" + subcodes + ") order by SubCode,UserTname").Tables[0];
                    if (dtsubboss != null && dtsubboss.Rows.Count > 0)
                    {
                        Com.DataPack.SubBossList dptlist = new Com.DataPack.SubBossList();
                        dptlist.subboss = Com.Public.DataTableToList<Com.DataPack.SubBossInfo>(dtsubboss);
                        rsp.RspData = dptlist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 学期
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.SysTermList> SysTerm([FromBody]Com.DataPack.TermKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.SysTermList> rsp = new Com.DataPack.DataRsp<Com.DataPack.SysTermList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    SchSystem.BLL.SysTerm systermbll = new SchSystem.BLL.SysTerm();
                    DataTable dtterm = systermbll.GetList(" TermName termname,TermCode termcode", " 1=1 order by TermCode").Tables[0];
                    if (dtterm != null && dtterm.Rows.Count > 0)
                    {
                        Com.DataPack.SysTermList termlist = new Com.DataPack.SysTermList();
                        termlist.systerm = Com.Public.DataTableToList<Com.DataPack.SysTermInfo>(dtterm);
                        rsp.RspData = termlist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 学段
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.SysPerList> SysPer([FromBody]Com.DataPack.PerKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.SysPerList> rsp = new Com.DataPack.DataRsp<Com.DataPack.SysPerList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    SchSystem.BLL.SysPer sysperbll = new SchSystem.BLL.SysPer();
                    DataTable dtper = sysperbll.GetList(" PerName pername,PerCode percode", " Stat=1 order by PerCode").Tables[0];
                    if (dtper != null && dtper.Rows.Count > 0)
                    {
                        Com.DataPack.SysPerList perlist = new Com.DataPack.SysPerList();
                        perlist.sysper = Com.Public.DataTableToList<Com.DataPack.SysPerInfo>(dtper);
                        rsp.RspData = perlist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }

        /// <summary>
        /// 分册
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.SysFascList> SysFasc([FromBody]Com.DataPack.FascKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.SysFascList> rsp = new Com.DataPack.DataRsp<Com.DataPack.SysFascList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    SchSystem.BLL.SysFasc sysfascbll = new SchSystem.BLL.SysFasc();
                    DataTable dtfasc = sysfascbll.GetList(" FascName fascname,FascCode fasccode", " Stat=1 order by FascCode").Tables[0];
                    if (dtfasc != null && dtfasc.Rows.Count > 0)
                    {
                        Com.DataPack.SysFascList fasclist = new Com.DataPack.SysFascList();
                        fasclist.sysfasc = Com.Public.DataTableToList<Com.DataPack.SysFascInfo>(dtfasc);
                        rsp.RspData = fasclist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }

        /// <summary>
        /// 教版
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.SysMaterList> SysMater([FromBody]Com.DataPack.MaterKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.SysMaterList> rsp = new Com.DataPack.DataRsp<Com.DataPack.SysMaterList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    SchSystem.BLL.SysMater sysmaterbll = new SchSystem.BLL.SysMater();
                    DataTable dtmat = sysmaterbll.GetList(" MaterName matername,MaterCode matercode", " Stat=1 order by MaterCode").Tables[0];
                    if (dtmat != null && dtmat.Rows.Count > 0)
                    {
                        Com.DataPack.SysMaterList materlist = new Com.DataPack.SysMaterList();
                        materlist.sysmater = Com.Public.DataTableToList<Com.DataPack.SysMaterInfo>(dtmat);
                        rsp.RspData = materlist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }

        /// <summary>
        /// 科别
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.SysArtList> SysArts([FromBody]Com.DataPack.ArtKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.SysArtList> rsp = new Com.DataPack.DataRsp<Com.DataPack.SysArtList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    SchSystem.BLL.SysArts sysartbll = new SchSystem.BLL.SysArts();
                    DataTable dtart = sysartbll.GetList(" ArtsName artname,ArtsCode artcode", " Stat=1 order by ArtsCode").Tables[0];
                    if (dtart != null && dtart.Rows.Count > 0)
                    {
                        Com.DataPack.SysArtList artlist = new Com.DataPack.SysArtList();
                        artlist.sysarts = Com.Public.DataTableToList<Com.DataPack.SysArtInfo>(dtart);
                        rsp.RspData = artlist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }

        /// <summary>
        /// 科目
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.SysSubList> SysSub([FromBody]Com.DataPack.SysSubKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.SysSubList> rsp = new Com.DataPack.DataRsp<Com.DataPack.SysSubList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    SchSystem.BLL.SysSub syssubbll = new SchSystem.BLL.SysSub();
                    DataTable dtsub = syssubbll.GetList(" SubName subname,SubCode subcode", " Stat=1 order by SubCode").Tables[0];
                    if (dtsub != null && dtsub.Rows.Count > 0)
                    {
                        Com.DataPack.SysSubList sublist = new Com.DataPack.SysSubList();
                        sublist.syssub = Com.Public.DataTableToList<Com.DataPack.SysSubInfo>(dtsub);
                        rsp.RspData = sublist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 系统年级
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.SysGradeList> SysGrade([FromBody]Com.DataPack.SysGradeKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.SysGradeList> rsp = new Com.DataPack.DataRsp<Com.DataPack.SysGradeList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    SchSystem.BLL.SysGrade sysgrdbll = new SchSystem.BLL.SysGrade();
                    DataTable dtgrd = sysgrdbll.GetList(" GradeType grdpercode,GradeCode grdcode,GradeName grdname", " 1=1 order by convert(int,GradeCode)").Tables[0];
                    if (dtgrd != null && dtgrd.Rows.Count > 0)
                    {
                        Com.DataPack.SysGradeList grdlist = new Com.DataPack.SysGradeList();
                        grdlist.sysgrd = Com.Public.DataTableToList<Com.DataPack.SysGradeInfo>(dtgrd);
                        rsp.RspData = grdlist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }

        /// <summary>
        /// 大学校园年级信息
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<string> UnvClassDo([FromBody]Com.DataPack.UnvClassKeys pokeys)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "gradeid=" + pokeys.gradeid, "classno=" + pokeys.classno, "classname=" + pokeys.classname, "schid=" + pokeys.schid, "isfinish=" + pokeys.isfinish,"dotype=" + pokeys.dotype, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    string utname = tokenvalue.Split(':')[3];
                    SchSystem.BLL.SchClassInfo bll = new SchSystem.BLL.SchClassInfo();
                    SchSystem.Model.SchClassInfo model = new SchSystem.Model.SchClassInfo();
                    if (pokeys.dotype == "e")//修改将删除归于其中
                    {
                        if (!bll.ExistsClass(pokeys.classid,pokeys.classno, pokeys.gradeid, pokeys.schid))
                        {
                            //获取gradeid对应的gradecode
                            SchSystem.BLL.SchGradeInfo bllgrade = new SchSystem.BLL.SchGradeInfo();
                            DataTable dt = bll.GetList(" top 1 GradeCode", "GradeId='" + pokeys.gradeid + "'").Tables[0];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                model.GradeCode = dt.Rows[0]["GradeCode"].ToString();
                            }
                            model.ClassId = pokeys.classid;
                            model.ClassName = pokeys.classname;
                            model.ClassNo = pokeys.classno;
                            model.GradeId = pokeys.gradeid;
                            model.IsFinish = pokeys.isfinish;
                            model.LastRecTime = DateTime.Now;
                            model.LastRecUser = utname;
                            model.RecTime = DateTime.Now;
                            model.RecUser = utname;
                            model.SchId = pokeys.schid;
                            if (bll.UpdateUnv(model))
                            {
                                rsp.RspData = "修改成功!";
                            }
                            else
                            {
                                rsp.RspCode = "0007";
                                rsp.RspTxt = "无此记录";
                            }
                        }
                        else
                        {
                            rsp.RspCode = "0007";
                            rsp.RspTxt = "已有对应代码的年级!";
                        }
                    }
                    else if (pokeys.dotype == "a")//添加
                    {
                        if (!bll.ExistsClass(0, pokeys.classno, pokeys.gradeid, pokeys.schid))
                        {
                            model.ClassId = pokeys.classid;
                            model.ClassName = pokeys.classname;
                            model.ClassNo = pokeys.classno;
                            model.GradeId = pokeys.gradeid;
                            SchSystem.BLL.SchGradeInfo bllgrade = new SchSystem.BLL.SchGradeInfo();
                            DataTable dt = bll.GetList(" top 1 GradeCode", "GradeId='" + pokeys.gradeid + "'").Tables[0];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                model.GradeCode = dt.Rows[0]["GradeCode"].ToString();
                            }
                            model.IsFinish = pokeys.isfinish;
                            model.LastRecTime = DateTime.Now;
                            model.LastRecUser = utname;
                            model.RecTime = DateTime.Now;
                            model.RecUser = utname;
                            model.SchId = pokeys.schid;
                            int rid = bll.Add(model);
                            if (rid > 0)
                            {
                                rsp.RspData = rid.ToString();
                            }
                            else
                            {
                                rsp.RspCode = "0007";
                                rsp.RspTxt = "添加失败";
                            }
                        }
                        else
                        {
                            //获取对应的班级ID
                            int id = bll.GetClassId(pokeys.classno, pokeys.gradeid, pokeys.schid);
                            if (id > 0)
                            {
                                //获取gradeid对应的gradecode
                                SchSystem.BLL.SchGradeInfo bllgrade = new SchSystem.BLL.SchGradeInfo();
                                DataTable dt = bll.GetList(" top 1 GradeCode", "GradeId='" + pokeys.gradeid + "'").Tables[0];
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    model.GradeCode = dt.Rows[0]["GradeCode"].ToString();
                                }
                                model.ClassId = id;
                                model.ClassName = pokeys.classname;
                                model.ClassNo = pokeys.classno;
                                model.GradeId = pokeys.gradeid;
                                model.IsFinish = pokeys.isfinish;
                                model.LastRecTime = DateTime.Now;
                                model.LastRecUser = utname;
                                model.RecTime = DateTime.Now;
                                model.RecUser = utname;
                                model.SchId = pokeys.schid;
                                if (bll.UpdateUnv(model))
                                {
                                    rsp.RspData = "添加成功!";
                                }
                            }
                            else
                            {
                                rsp.RspCode = "0007";
                                rsp.RspTxt = "已有对应代码的年级!";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pokeys"></param>
        /// <returns></returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.ClassList> UnvSchClass([FromBody]Com.DataPack.UnvSchClassKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.ClassList> rsp = new Com.DataPack.DataRsp<Com.DataPack.ClassList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "schid=" + pokeys.schid, "majorcode=" + pokeys.majorcode, "collcode=" + pokeys.collcode, "gradeid=" + pokeys.gradeid, "isfinish=" + pokeys.isfinish, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    //int schid = int.Parse(tokenvalue.Split(':')[2]);
                    string sqlstr = "schid=" + pokeys.schid;
                    if (pokeys.gradeid != 0)
                    {
                        sqlstr += " and gradeid=" + pokeys.gradeid;
                    }
                    if (pokeys.collcode != "")//院系
                    {
                        sqlstr += " and collcode='" + pokeys.collcode+"'";
                    }
                    if (pokeys.majorcode != "")//专业
                    {
                        sqlstr += " and majorcode='" + pokeys.majorcode+"'";
                    }
                    if (pokeys.isfinish != -1)
                    {
                        sqlstr += " and isfinish=" + pokeys.isfinish;
                    }
                    else
                    {
                        sqlstr += " and (isfinish=1 or isfinish=0) ";
                    }

                    SchSystem.BLL.SchClassInfo bll = new SchSystem.BLL.SchClassInfo();
                    DataTable dt = bll.GetListV(" CollCode collcode,MajorCode majorcode,GradeId grdid,GradeCode grdcode,ClassId clsid,ClassNo classno,ClassName clsname,isfinish", sqlstr + " order by GradeCode,ClassNo").Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Com.DataPack.ClassList list = new Com.DataPack.ClassList();
                        list.clss = Com.Public.DataTableToList<Com.DataPack.ClassInfo>(dt);
                        rsp.RspData = list;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        [HttpPost]
        public Com.DataPack.DataRsp<string> UnvGradeDo([FromBody]Com.DataPack.UnvGradeKeys pokeys)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "gradeid=" + pokeys.gradeid, "gradeyear=" + pokeys.gradeyear, "gradecode=" + pokeys.gradecode, "gradename=" + pokeys.gradename, "schid=" + pokeys.schid, "isfinish=" + pokeys.isfinish, "collcode=" + pokeys.collcode, "majorcode=" + pokeys.majorcode, "dotype=" + pokeys.dotype, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    string utname = tokenvalue.Split(':')[3];
                    SchSystem.BLL.SchGradeInfo bll = new SchSystem.BLL.SchGradeInfo();
                    SchSystem.Model.SchGradeInfo model = new SchSystem.Model.SchGradeInfo();
                    if (pokeys.dotype == "e")//修改将删除归于其中
                    {
                        if (!bll.ExistsUnvGrade(pokeys.gradeid, pokeys.collcode, pokeys.majorcode, pokeys.gradecode, pokeys.schid))
                        {
                            model.CollCode = pokeys.collcode;
                            model.GradeCode = pokeys.gradecode;
                            model.GradeId = pokeys.gradeid;
                            model.GradeName = pokeys.gradename;
                            model.GradeYear = pokeys.gradeyear;
                            model.IsFinish = pokeys.isfinish;
                            model.LastRecTime = DateTime.Now;
                            model.LastRecUser = utname;
                            model.MajorCode = pokeys.majorcode;
                            model.RecTime = DateTime.Now;
                            model.RecUser = utname;
                            model.SchId = pokeys.schid;
                            if (bll.UpdateUnv(model))
                            {
                                rsp.RspData = "修改成功!";
                            }
                            else
                            {
                                rsp.RspCode = "0007";
                                rsp.RspTxt = "无此记录";
                            }
                        }
                        else
                        {
                            rsp.RspCode = "0007";
                            rsp.RspTxt = "已有对应代码的年级!";
                        }
                    }
                    else if (pokeys.dotype == "a")//添加
                    {
                        if (!bll.ExistsUnvGrade(0, pokeys.collcode, pokeys.majorcode, pokeys.gradecode, pokeys.schid))
                        {
                            model.CollCode = pokeys.collcode;
                            model.GradeCode = pokeys.gradecode;
                            model.GradeId = pokeys.gradeid;
                            model.GradeName = pokeys.gradename;
                            model.GradeYear = pokeys.gradeyear;
                            model.IsFinish = pokeys.isfinish;
                            model.LastRecTime = DateTime.Now;
                            model.LastRecUser = utname;
                            model.MajorCode = pokeys.majorcode;
                            model.RecTime = DateTime.Now;
                            model.RecUser = utname;
                            model.SchId = pokeys.schid;
                            int rid = bll.AddUnv(model);
                            if (rid > 0)
                            {
                                rsp.RspData = rid.ToString();
                            }
                            else
                            {
                                rsp.RspCode = "0007";
                                rsp.RspTxt = "添加失败";
                            }
                        }
                        else//更改相应年级代码的记录
                        {
                            int id = bll.GetGradeId(pokeys.collcode, pokeys.majorcode, pokeys.gradecode, pokeys.schid);
                            if (id > 0)
                            {
                                model.CollCode = pokeys.collcode;
                                model.GradeCode = pokeys.gradecode;
                                model.GradeId = id;
                                model.GradeName = pokeys.gradename;
                                model.GradeYear = pokeys.gradeyear;
                                model.IsFinish = pokeys.isfinish;
                                model.LastRecTime = DateTime.Now;
                                model.LastRecUser = utname;
                                model.MajorCode = pokeys.majorcode;
                                model.RecTime = DateTime.Now;
                                model.RecUser = utname;
                                model.SchId = pokeys.schid;
                                if (bll.UpdateUnv(model))
                                {
                                    rsp.RspData = id.ToString();
                                }
                            }
                            else
                            {
                                rsp.RspCode = "0007";
                                rsp.RspTxt = "已有对应代码的年级!";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }

        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.GradeList> UnvSchGrade([FromBody]Com.DataPack.UnvSchGradeKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.GradeList> rsp = new Com.DataPack.DataRsp<Com.DataPack.GradeList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "schid=" + pokeys.schid, "collcode=" + pokeys.collcode, "majorcode=" + pokeys.majorcode, "isfinish=" + pokeys.isfinish, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    //int schid = int.Parse(tokenvalue.Split(':')[2]);
                    string sqlstr = "schid=" + pokeys.schid;
                    if (pokeys.isfinish != -1)
                    {
                        sqlstr += " and isfinish=" + pokeys.isfinish;
                    }
                    else
                    {
                        sqlstr += " and (isfinish=1 or isfinish=0) ";
                    }
                    if (pokeys.collcode != "")
                    {
                        sqlstr += " and collcode='" + Com.Public.SqlEncStr(pokeys.collcode) + "'";
                    }
                    if (pokeys.majorcode != "")
                    {
                        sqlstr += " and majorcode='" + Com.Public.SqlEncStr(pokeys.majorcode) + "'";
                    }
                    SchSystem.BLL.SchGradeV schgradebll = new SchSystem.BLL.SchGradeV();
                    DataTable dtgrade = schgradebll.GetList(" PerCode pcode,PerName pname,CollCode collcode,MajorCode majorcode,GradeCode grdcode,SysGradeName sysgradename,GradeName grdname,GradeYear grdyear,GradeId grdid,isfinish", sqlstr + " order by GradeCode").Tables[0];
                    if (dtgrade != null && dtgrade.Rows.Count > 0)
                    {
                        Com.DataPack.GradeList gradelist = new Com.DataPack.GradeList();
                        gradelist.grds = Com.Public.DataTableToList<Com.DataPack.GradeInfo>(dtgrade);
                        rsp.RspData = gradelist;
                    }

                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 系统院系
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.SysCollList> SysColl([FromBody]Com.DataPack.SysCollKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.SysCollList> rsp = new Com.DataPack.DataRsp<Com.DataPack.SysCollList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    SchSystem.BLL.SysColl bll = new SchSystem.BLL.SysColl();
                    DataTable dt = bll.GetList(" CollCode collcode,CollName collname", " 1=1 order by convert(int,CollCode)").Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Com.DataPack.SysCollList list = new Com.DataPack.SysCollList();
                        list.syscoll = Com.Public.DataTableToList<Com.DataPack.SysCollInfo>(dt);
                        rsp.RspData = list;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 系统专业
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.SysMajorList> SysMajor([FromBody]Com.DataPack.SysMajorKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.SysMajorList> rsp = new Com.DataPack.DataRsp<Com.DataPack.SysMajorList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    SchSystem.BLL.SysMajor bll = new SchSystem.BLL.SysMajor();
                    DataTable dt = bll.GetList(" MajorCode majorcode,MajorName majorname", " 1=1 order by convert(int,majorcode)").Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Com.DataPack.SysMajorList list = new Com.DataPack.SysMajorList();
                        list.sysmajor = Com.Public.DataTableToList<Com.DataPack.SysMajorInfo>(dt);
                        rsp.RspData = list;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 系统栏目对应表
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.SysItemList> SysItem([FromBody]Com.DataPack.SysItemKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.SysItemList> rsp = new Com.DataPack.DataRsp<Com.DataPack.SysItemList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    SchSystem.BLL.ServSysNape sysnapebll = new SchSystem.BLL.ServSysNape();
                    DataTable dtitem = sysnapebll.GetList(" NapeCode itemcode,NapeName itemname", " Stat=1 order by NapeCode").Tables[0];
                    if (dtitem != null && dtitem.Rows.Count > 0)
                    {
                        Com.DataPack.SysItemList itemlist = new Com.DataPack.SysItemList();
                        itemlist.sysitem = Com.Public.DataTableToList<Com.DataPack.SysItemInfo>(dtitem);
                        rsp.RspData = itemlist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 系统用户对应表
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.SysUtypeList> SysUtype([FromBody]Com.DataPack.SysItemKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.SysUtypeList> rsp = new Com.DataPack.DataRsp<Com.DataPack.SysUtypeList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    SchSystem.BLL.SysUType sysutypebll = new SchSystem.BLL.SysUType();
                    DataTable dtutype = sysutypebll.GetList(" UTypeCode utypecode,UTypeName utypename", " Stat=1 order by UTypeCode").Tables[0];
                    if (dtutype != null && dtutype.Rows.Count > 0)
                    {
                        Com.DataPack.SysUtypeList utypelist = new Com.DataPack.SysUtypeList();
                        utypelist.sysutype = Com.Public.DataTableToList<Com.DataPack.SysUtypeInfo>(dtutype);
                        rsp.RspData = utypelist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }

        /// <summary>
        /// 套餐功能表
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.SysFuncList> SysBusFunc([FromBody]Com.DataPack.SysFuncKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.SysFuncList> rsp = new Com.DataPack.DataRsp<Com.DataPack.SysFuncList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken, "fcodes=" + pokeys.fcodes };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    SchSystem.BLL.ServFunc sysfuncbll = new SchSystem.BLL.ServFunc();
                    string sqlwhere = " 1=1 ";
                    if (pokeys.fcodes != "")
                    {
                        string[] funcs = Com.Public.SqlEncStr(pokeys.fcodes).Split(',');
                        string funcsstr = "'" + String.Join("','", funcs) + "'";
                        sqlwhere += " and FuncCode in (" + funcsstr + ")";
                    }
                    DataTable dtfunc = sysfuncbll.GetList("AutoId fid,FuncName fname,FuncCode fcode,FuncRange frange,FuncSet fset,FuncNote fnote,FuncDes fdes", sqlwhere + " order by FuncName").Tables[0];
                    if (dtfunc != null && dtfunc.Rows.Count > 0)
                    {
                        Com.DataPack.SysFuncList buslist = new Com.DataPack.SysFuncList();
                        buslist.sysfunc = Com.Public.DataTableToList<Com.DataPack.SysFuncInfo>(dtfunc);
                        for (int i = 0; i < buslist.sysfunc.Count; i++)
                        {
                            //用户所在部门
                            SchSystem.BLL.ServFuncExt fextbll = new SchSystem.BLL.ServFuncExt();
                            DataTable dtfext = fextbll.GetListItemV("FuncId fid,NapeCode itemcode,NapeName itemname,NapeCodes itemsons,NapeC itemsonsc", "FuncId=" + buslist.sysfunc[i].fid).Tables[0];
                            if (dtfext != null && dtfext.Rows.Count > 0)
                            {
                                for (int k = 0; k < dtfext.Rows.Count; k++)
                                {
                                    if (dtfext.Rows[k]["itemcode"].ToString() == "prd")
                                    {
                                        string colstr = "";
                                        SchSystem.BLL.SysPer spBll = new SchSystem.BLL.SysPer();
                                        DataTable dtSysPer = spBll.GetList("PerName name,PerCode id", "Stat=1 and PerCode in (" + dtfext.Rows[k]["itemsons"].ToString() + ") order by convert(int,PerCode)").Tables[0];
                                        if (dtSysPer.Rows.Count > 0)
                                        {

                                            for (int j = 0; j < dtSysPer.Rows.Count; j++)
                                            {
                                                colstr += dtSysPer.Rows[j]["id"].ToString() + "|" + dtSysPer.Rows[j]["name"].ToString() + ",";
                                            }
                                            if (colstr != "")
                                            {
                                                colstr = colstr.Remove(colstr.Length - 1);
                                            }
                                        }
                                        dtfext.Rows[k]["itemsons"] = colstr;
                                    }
                                    else if (dtfext.Rows[k]["itemcode"].ToString() == "mat")
                                    {
                                        string colstr = "";
                                        SchSystem.BLL.SysMater smBll = new SchSystem.BLL.SysMater();
                                        DataTable dtSysMat = smBll.GetList("MaterName name,MaterCode id", "Stat=1 and MaterCode in (" + dtfext.Rows[k]["itemsons"].ToString() + ")").Tables[0];
                                        if (dtSysMat.Rows.Count > 0)
                                        {

                                            for (int j = 0; j < dtSysMat.Rows.Count; j++)
                                            {
                                                colstr += dtSysMat.Rows[j]["id"].ToString() + "|" + dtSysMat.Rows[j]["name"].ToString() + ",";
                                            }
                                            if (colstr != "")
                                            {
                                                colstr = colstr.Remove(colstr.Length - 1);
                                            }
                                        }
                                        dtfext.Rows[k]["itemsons"] = colstr;
                                    }
                                    else if (dtfext.Rows[k]["itemcode"].ToString() == "sub")
                                    {
                                        string colstr = "";
                                        SchSystem.BLL.SysSub ssBll = new SchSystem.BLL.SysSub();
                                        DataTable dtSysSub = ssBll.GetList("SubName name,SubCode id", "Stat=1 and SubCode in (" + dtfext.Rows[k]["itemsons"].ToString() + ")").Tables[0];
                                        if (dtSysSub.Rows.Count > 0)
                                        {

                                            for (int j = 0; j < dtSysSub.Rows.Count; j++)
                                            {
                                                colstr += dtSysSub.Rows[j]["id"].ToString() + "|" + dtSysSub.Rows[j]["name"].ToString() + ",";
                                            }
                                            if (colstr != "")
                                            {
                                                colstr = colstr.Remove(colstr.Length - 1);
                                            }
                                        }
                                        dtfext.Rows[k]["itemsons"] = colstr;
                                    }
                                    else if (dtfext.Rows[k]["itemcode"].ToString() == "grd")
                                    {
                                        string colstr = "";
                                        SchSystem.BLL.SysGrade sgBll = new SchSystem.BLL.SysGrade();
                                        DataTable dtSysGrade = sgBll.GetList("'0' pId,GradeName name,GradeCode id,'false' checked", "GradeCode in (" + dtfext.Rows[k]["itemsons"].ToString() + ")").Tables[0];
                                        if (dtSysGrade.Rows.Count > 0)
                                        {

                                            for (int j = 0; j < dtSysGrade.Rows.Count; j++)
                                            {
                                                colstr += dtSysGrade.Rows[j]["id"].ToString() + "|" + dtSysGrade.Rows[j]["name"].ToString() + ",";
                                            }
                                            if (colstr != "")
                                            {
                                                colstr = colstr.Remove(colstr.Length - 1);
                                            }
                                        }
                                        dtfext.Rows[k]["itemsons"] = colstr;
                                    }
                                    else if (dtfext.Rows[k]["itemcode"].ToString() == "utp")
                                    {
                                        string colstr = "";
                                        SchSystem.BLL.SysUType sutBll = new SchSystem.BLL.SysUType();
                                        DataTable dtSysUType = sutBll.GetList("'0' pId,UTypeName name,UTypeCode id,'false' checked", "Stat=1 and UTypeCode in (" + dtfext.Rows[k]["itemsons"].ToString() + ")").Tables[0];
                                        if (dtSysUType.Rows.Count > 0)
                                        {

                                            for (int j = 0; j < dtSysUType.Rows.Count; j++)
                                            {
                                                colstr += dtSysUType.Rows[j]["id"].ToString() + "|" + dtSysUType.Rows[j]["name"].ToString() + ",";
                                            }
                                            if (colstr != "")
                                            {
                                                colstr = colstr.Remove(colstr.Length - 1);
                                            }
                                        }
                                        dtfext.Rows[k]["itemsons"] = colstr;
                                    }
                                }
                                
                                buslist.sysfunc[i].fext = Com.Public.DataTableToList<Com.DataPack.SysFuncExtInfo>(dtfext);
                            }
                        }
                        rsp.RspData = buslist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 系统套餐表
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.SysBusList> SysBus([FromBody]Com.DataPack.SysBusKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.SysBusList> rsp = new Com.DataPack.DataRsp<Com.DataPack.SysBusList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken, "bustp=" + pokeys.bustp };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    SchSystem.BLL.ServBus sysbusbll = new SchSystem.BLL.ServBus();
                    string sqlwhere = " 1=1 ";
                    if (pokeys.bustp != 0)
                    {
                        sqlwhere += " and BusType=" + pokeys.bustp;
                    }
                    //第三方套餐不取,由第三方来,仅取本系统定义的套餐
                    DataTable dtbus = sysbusbll.GetList(" ServiceId serviceid,FeeCode feecode,CnName cnname,FuncStr fcodes,BusMonth busmonth,BusNote busnote,BusType bustype,Note note,CASE WHEN len(BusUrl)>0 THEN '" + Com.Public.GetKey("servurl") + "/" + "'+replace(BusUrl,'\\','/') ELSE '' END   busimg", sqlwhere + " and FrmType=0 order by CnName").Tables[0];
                    if (dtbus != null && dtbus.Rows.Count > 0)
                    {
                        Com.DataPack.SysBusList buslist = new Com.DataPack.SysBusList();
                        buslist.sysbus = Com.Public.DataTableToList<Com.DataPack.SysBusInfo>(dtbus);
                        rsp.RspData = buslist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }

        /// <summary>
        /// 获取用户定制套餐及功能表
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.UserBusList> GetUserBusFunc([FromBody]Com.DataPack.UserBusKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.UserBusList> rsp = new Com.DataPack.DataRsp<Com.DataPack.UserBusList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken, "uid=" + pokeys.uid };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    SchSystem.BLL.ServUserForV userforbll = new SchSystem.BLL.ServUserForV();
                    string sqlwhere = " UserName='" + Com.Public.SqlEncStr(pokeys.uid) + "'";
                    DataTable dtuserbus = userforbll.GetList("AutoId forid,UserName uid,UTname utname,ServiceId servid,BusType servtype,CnName cname,FuncStr fcodes,ServStat serstat,CONVERT(varchar(12),RecTime,102 ) stime,CONVERT(varchar(12),EndTime,102 ) etime,FrmType frmtype", sqlwhere + " order by CnName").Tables[0];
                    if (dtuserbus != null && dtuserbus.Rows.Count > 0)
                    {
                        Com.DataPack.UserBusList userforlist = new Com.DataPack.UserBusList();
                        userforlist.userbus = Com.Public.DataTableToList<Com.DataPack.UserBusInfo>(dtuserbus);
                        for (int i = 0; i < userforlist.userbus.Count; i++)
                        {
                            //用户定制的扩展功能
                            SchSystem.BLL.ServUserForExt userforextbll = new SchSystem.BLL.ServUserForExt();
                            DataTable dtfext = userforextbll.GetList("UserForId forid,Fcode fcode,NapeCode itemcode,NapeCodes itemsons", "UserForId=" + userforlist.userbus[i].forid).Tables[0];
                            if (dtfext != null && dtfext.Rows.Count > 0)
                            {
                                for (int k = 0; k < dtfext.Rows.Count; k++)
                                {
                                    if (dtfext.Rows[k]["itemcode"].ToString() == "prd")
                                    {
                                        string colstr = "";
                                        SchSystem.BLL.SysPer spBll = new SchSystem.BLL.SysPer();
                                        DataTable dtSysPer = spBll.GetList("PerName name,PerCode id", "Stat=1 and PerCode in (" + dtfext.Rows[k]["itemsons"].ToString() + ") Order by convert(int,PerCode)").Tables[0];
                                        if (dtSysPer.Rows.Count > 0)
                                        {

                                            for (int j = 0; j < dtSysPer.Rows.Count; j++)
                                            {
                                                colstr += dtSysPer.Rows[j]["id"].ToString() + "|" + dtSysPer.Rows[j]["name"].ToString() + ",";
                                            }
                                            if (colstr != "")
                                            {
                                                colstr = colstr.Remove(colstr.Length - 1);
                                            }
                                        }
                                        dtfext.Rows[k]["itemsons"] = colstr;
                                    }
                                    else if (dtfext.Rows[k]["itemcode"].ToString() == "mat")
                                    {
                                        string colstr = "";
                                        SchSystem.BLL.SysMater smBll = new SchSystem.BLL.SysMater();
                                        DataTable dtSysMat = smBll.GetList("MaterName name,MaterCode id", "Stat=1 and MaterCode in (" + dtfext.Rows[k]["itemsons"].ToString() + ")").Tables[0];
                                        if (dtSysMat.Rows.Count > 0)
                                        {

                                            for (int j = 0; j < dtSysMat.Rows.Count; j++)
                                            {
                                                colstr += dtSysMat.Rows[j]["id"].ToString() + "|" + dtSysMat.Rows[j]["name"].ToString() + ",";
                                            }
                                            if (colstr != "")
                                            {
                                                colstr = colstr.Remove(colstr.Length - 1);
                                            }
                                        }
                                        dtfext.Rows[k]["itemsons"] = colstr;
                                    }
                                    else if (dtfext.Rows[k]["itemcode"].ToString() == "sub")
                                    {
                                        string colstr = "";
                                        SchSystem.BLL.SysSub ssBll = new SchSystem.BLL.SysSub();
                                        DataTable dtSysSub = ssBll.GetList("SubName name,SubCode id", "Stat=1 and SubCode in (" + dtfext.Rows[k]["itemsons"].ToString() + ")").Tables[0];
                                        if (dtSysSub.Rows.Count > 0)
                                        {

                                            for (int j = 0; j < dtSysSub.Rows.Count; j++)
                                            {
                                                colstr += dtSysSub.Rows[j]["id"].ToString() + "|" + dtSysSub.Rows[j]["name"].ToString() + ",";
                                            }
                                            if (colstr != "")
                                            {
                                                colstr = colstr.Remove(colstr.Length - 1);
                                            }
                                        }
                                        dtfext.Rows[k]["itemsons"] = colstr;
                                    }
                                    else if (dtfext.Rows[k]["itemcode"].ToString() == "grd")
                                    {
                                        string colstr = "";
                                        SchSystem.BLL.SysGrade sgBll = new SchSystem.BLL.SysGrade();
                                        DataTable dtSysGrade = sgBll.GetList("'0' pId,GradeName name,GradeCode id,'false' checked", "GradeCode in (" + dtfext.Rows[k]["itemsons"].ToString() + ")").Tables[0];
                                        if (dtSysGrade.Rows.Count > 0)
                                        {

                                            for (int j = 0; j < dtSysGrade.Rows.Count; j++)
                                            {
                                                colstr += dtSysGrade.Rows[j]["id"].ToString() + "|" + dtSysGrade.Rows[j]["name"].ToString() + ",";
                                            }
                                            if (colstr != "")
                                            {
                                                colstr = colstr.Remove(colstr.Length - 1);
                                            }
                                        }
                                        dtfext.Rows[k]["itemsons"] = colstr;
                                    }
                                    else if (dtfext.Rows[k]["itemcode"].ToString() == "utp")
                                    {
                                        string colstr = "";
                                        SchSystem.BLL.SysUType sutBll = new SchSystem.BLL.SysUType();
                                        DataTable dtSysUType = sutBll.GetList("'0' pId,UTypeName name,UTypeCode id,'false' checked", "Stat=1 and UTypeCode in (" + dtfext.Rows[k]["itemsons"].ToString() + ")").Tables[0];
                                        if (dtSysUType.Rows.Count > 0)
                                        {

                                            for (int j = 0; j < dtSysUType.Rows.Count; j++)
                                            {
                                                colstr += dtSysUType.Rows[j]["id"].ToString() + "|" + dtSysUType.Rows[j]["name"].ToString() + ",";
                                            }
                                            if (colstr != "")
                                            {
                                                colstr = colstr.Remove(colstr.Length - 1);
                                            }
                                        }
                                        dtfext.Rows[k]["itemsons"] = colstr;
                                    }
                                }
                                userforlist.userbus[i].busext = Com.Public.DataTableToList<Com.DataPack.UserBusExt>(dtfext);
                            }
                        }
                        rsp.RspData = userforlist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }

        /// <summary>
        /// 用户续订套餐
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<string> UserReFee([FromBody]Com.DataPack.UserRefeeKeys pokeys)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken, "uid=" + pokeys.uid, "servid=" + pokeys.servid, "servm=" + pokeys.servm, "feem=" + pokeys.feem, "dnote=" + pokeys.dnote, "recutname=" + pokeys.recutname, "frmtype=" + pokeys.frmtype };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    //int schid = int.Parse(tokenvalue.Split(':')[2]);
                    SchSystem.BLL.ServUserFor userforbll = new SchSystem.BLL.ServUserFor();
                    if (userforbll.Exists(pokeys.uid, pokeys.servid))
                    {
                        int rid = userforbll.UserRefee(pokeys.uid, pokeys.servid, pokeys.servm, pokeys.feem, pokeys.dnote, pokeys.recutname, pokeys.frmtype);
                        if (rid > 0)
                        {
                            rsp.RspData = "续费成功!";
                        }

                    }
                    else
                    {
                        rsp.RspCode = "0005";
                        rsp.RspTxt = "该用户没订购该套餐,不能续费!";
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }

        /// <summary>
        /// 用户定制套餐
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<string> UserFee([FromBody]Com.DataPack.UserFeeKeys pokeys)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken, "uid=" + pokeys.uid, "servid=" + pokeys.servid, "servm=" + pokeys.servm, "feem=" + pokeys.feem, "dnote=" + pokeys.dnote, "recutname=" + pokeys.recutname, "frmtype=" + pokeys.frmtype, "funclist=" + Newtonsoft.Json.JsonConvert.SerializeObject(pokeys.funclist) };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    //int schid = int.Parse(tokenvalue.Split(':')[2]);
                    SchSystem.BLL.ServUserFor userforbll = new SchSystem.BLL.ServUserFor();
                    if (userforbll.Exists(pokeys.uid, pokeys.servid))
                    {
                        rsp.RspCode = "0005";
                        rsp.RspTxt = "该用户已订购该套餐!";
                    }
                    else
                    {
                        int rid = userforbll.UserRefee(pokeys.uid, pokeys.servid, pokeys.servm, pokeys.feem, pokeys.dnote, pokeys.recutname, pokeys.frmtype);
                        if (rid > 0)
                        {

                            //添加功能
                            List<SchWebApi.Com.DataPack.UserFeeFuncInfo> listfunc = pokeys.funclist;
                            if (listfunc.Count > 0)
                            {
                                SchSystem.BLL.ServUserForExt userforextbll = new SchSystem.BLL.ServUserForExt();
                                SchSystem.Model.ServUserForExt userforext;
                                for (int i = 0; i < listfunc.Count; i++)
                                {
                                    if (listfunc[i].itemsons != "null")
                                    {
                                        userforext = new SchSystem.Model.ServUserForExt();
                                        userforext.Fcode = listfunc[i].fcode;
                                        userforext.NapeCode = listfunc[i].itemcode;
                                        userforext.NapeCodes = listfunc[i].itemsons;
                                        userforext.UserForId = rid;
                                        userforextbll.Add(userforext);
                                    }
                                }
                            }
                            rsp.RspData = "添加成功!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }

        /// <summary>
        /// 用户定制套餐
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.ServFeeDetailList> UserFeeDetail([FromBody]Com.DataPack.UserFeeDetailKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.ServFeeDetailList> rsp = new Com.DataPack.DataRsp<Com.DataPack.ServFeeDetailList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken, "uid=" + pokeys.uid, "servid=" + pokeys.servid };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    //int schid = int.Parse(tokenvalue.Split(':')[2]);
                    SchSystem.BLL.ServUserForDetail userforbll = new SchSystem.BLL.ServUserForDetail();
                    string sqlwhere = " UserName='" + Com.Public.SqlEncStr(pokeys.uid) + "' and ServiceId='" + Com.Public.SqlEncStr(pokeys.servid) + "' ";

                    DataTable dtbus = userforbll.GetList(" ServiceId servid,ServMonth servm,FeeM feem,CONVERT(varchar(100), RecTime, 120) rectime", sqlwhere + " order by RecTime Desc").Tables[0];
                    if (dtbus != null && dtbus.Rows.Count > 0)
                    {
                        Com.DataPack.ServFeeDetailList buslist = new Com.DataPack.ServFeeDetailList();
                        buslist.servdetail = Com.Public.DataTableToList<Com.DataPack.ServFeeDetailInfo>(dtbus);
                        rsp.RspData = buslist;
                    }

                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }

        /// <summary>
        /// 用户更改套餐功能栏目
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<string> UserRefunc([FromBody]Com.DataPack.UserRefuncKeys pokeys)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken, "forid=" + pokeys.forid, "funclist=" + pokeys.funclist };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    //int schid = int.Parse(tokenvalue.Split(':')[2]);

                    SchSystem.BLL.ServUserForExt userforextbll = new SchSystem.BLL.ServUserForExt();
                    //先删除对应的功能
                    userforextbll.DeleteList(pokeys.forid);
                    //添加功能                                       
                    List<SchWebApi.Com.DataPack.UserFeeFuncInfo> listfunc = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SchWebApi.Com.DataPack.UserFeeFuncInfo>>(pokeys.funclist);
                    if (listfunc.Count > 0)
                    {
                        SchSystem.Model.ServUserForExt userforext;
                        for (int i = 0; i < listfunc.Count; i++)
                        {
                            if (listfunc[i].itemsons != "null")
                            {
                                userforext = new SchSystem.Model.ServUserForExt();
                                userforext.Fcode = listfunc[i].fcode;
                                userforext.NapeCode = listfunc[i].itemcode;
                                userforext.NapeCodes = listfunc[i].itemsons;
                                userforext.UserForId = pokeys.forid;
                                userforextbll.Add(userforext);
                            }
                        }
                    }
                    rsp.RspData = "添加成功!";
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }

        /// <summary>
        /// 获取用户关联的学生列表
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.UserStuList> UserUstu([FromBody]Com.DataPack.UserUstuKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.UserStuList> rsp = new Com.DataPack.DataRsp<Com.DataPack.UserStuList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken, "utid=" + pokeys.utid };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    SchSystem.BLL.SchStuServUserV stuvbll = new SchSystem.BLL.SchStuServUserV();
                    string sqlwhere = "StuStat=1 and ServUserId=" + pokeys.utid;
                    DataTable dtstu = stuvbll.GetList("SchId schid,StuId stuid,SchName schname,GradeName grdname,ClassName clsname,StuName stuname,IsFinish isfinish,LoginName lgname,sex,ForId forid,ServiceId servid,ServStat servstat", sqlwhere + " order by StuName").Tables[0];
                    if (dtstu != null && dtstu.Rows.Count > 0)
                    {
                        Com.DataPack.UserStuList stulist = new Com.DataPack.UserStuList();
                        stulist.stus = Com.Public.DataTableToList<Com.DataPack.UserStuInfo>(dtstu);
                        rsp.RspData = stulist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 班级订购的学生
        /// </summary>
        /// <param name="pokeys"></param>
        /// <returns></returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.ClassUserUstuList> ClassUserUStu([FromBody]Com.DataPack.ClassUserUstuKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.ClassUserUstuList> rsp = new Com.DataPack.DataRsp<Com.DataPack.ClassUserUstuList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "classids=" + pokeys.classids, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    //int schid = int.Parse(tokenvalue.Split(':')[2]);
                    string classids = Com.Public.SqlEncStr(pokeys.classids);
                    SchSystem.BLL.SchStuServUserV schgrdclassbll = new SchSystem.BLL.SchStuServUserV();
                    DataTable dtclassuser = schgrdclassbll.GetList(" SchId schid,SchName schname,GradeId grdid,GradeCode grdcode,GradeName grdname,ClassId clsid,ClassName clsname,StuId stuid,StuName stuname,UserName mobile,ServiceId servid,ForId forid,ServUserId utid,UTname utname,Uico uimg,ustat", "ServStat=1 and ClassId in (" + classids + ") order by GradeCode,ClassName,StuName").Tables[0];
                    if (dtclassuser != null && dtclassuser.Rows.Count > 0)
                    {
                        Com.DataPack.ClassUserUstuList dptlist = new Com.DataPack.ClassUserUstuList();
                        dptlist.classuserustus = Com.Public.DataTableToList<Com.DataPack.UserUstuInfo>(dtclassuser);
                        rsp.RspData = dptlist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 获取用户手机关联的学生列表
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.UserStuList> UserMstu([FromBody]Com.DataPack.UserStuKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.UserStuList> rsp = new Com.DataPack.DataRsp<Com.DataPack.UserStuList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken, "uid=" + pokeys.uid };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    SchSystem.BLL.SchStuGenV stuvbll = new SchSystem.BLL.SchStuGenV();
                    string sqlwhere = "StuStat=1 and isfinish=0 and TelNo ='" + Com.Public.SqlEncStr(pokeys.uid) + "'";
                    DataTable dtstu = stuvbll.GetList("SchId schid,StuId stuid,SchName schname,GradeName grdname,ClassName clsname,StuName stuname,IsFinish isfinish,LoginName lgname,sex", sqlwhere + " order by StuName").Tables[0];
                    if (dtstu != null && dtstu.Rows.Count > 0)
                    {
                        Com.DataPack.UserStuList stulist = new Com.DataPack.UserStuList();
                        stulist.stus = Com.Public.DataTableToList<Com.DataPack.UserStuInfo>(dtstu);
                        rsp.RspData = stulist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }

        /// <summary>
        /// 关联注册用户与学生
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<string> UnUserStu([FromBody]Com.DataPack.UnUserStuKeys pokeys)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken, "forid=" + pokeys.forid, "utid=" + pokeys.utid, "stuid=" + pokeys.stuid };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    SchSystem.BLL.ServUserUstu ustuvbll = new SchSystem.BLL.ServUserUstu();
                    if (ustuvbll.ExistsFor(pokeys.forid))//如果该用户套餐已经有关联,则修改关联
                    {
                        ustuvbll.Update(pokeys.forid, pokeys.stuid);
                    }
                    else
                    {
                        SchSystem.Model.ServUserUstu model = new SchSystem.Model.ServUserUstu();
                        model.ForId = pokeys.forid;
                        model.StuId = pokeys.stuid;
                        model.ServUserId = pokeys.utid;
                        ustuvbll.Add(model);
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 更新学生的资料,账号,密码,头像等
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<string> UpStuInfo([FromBody]Com.DataPack.UpStuKeys pokeys)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken, "stuid=" + pokeys.stuid, "type=" + pokeys.type, "val=" + pokeys.val };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    SchSystem.BLL.SchStuInfo stubll = new SchSystem.BLL.SchStuInfo();
                    switch (pokeys.type)
                    {
                        case "uname":
                            //判断用户名是否已存在
                            if (stubll.ExistsLgname(pokeys.val))
                            {
                                rsp.RspCode = "0005";
                                rsp.RspTxt = "该学生账号已经被注册";
                            }
                            else
                            {
                                stubll.UpdateLoginName(pokeys.stuid, pokeys.val);
                            }
                            break;
                        case "upw":
                            stubll.UpdatePwd(pokeys.stuid, Com.Public.StrToMD5(pokeys.val));
                            break;
                        case "uico":
                            stubll.UpdateIco(pokeys.stuid, pokeys.val);
                            break;
                        default:
                            rsp.RspCode = "0011";
                            rsp.RspTxt = "传输命令不正确";
                            break;
                    }

                    //添加关联,添加或修改账号或密码
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 更新注册用户的资料,账号,密码,头像等
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<string> UpUserInfo([FromBody]Com.DataPack.UpUserKeys pokeys)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken, "utid=" + pokeys.utid, "type=" + pokeys.type, "val=" + pokeys.val };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    SchSystem.BLL.ServUser stubll = new SchSystem.BLL.ServUser();
                    switch (pokeys.type)
                    {
                        case "upw":
                            stubll.UpdatePwd(pokeys.utid, Com.Public.StrToMD5(pokeys.val));
                            break;
                        case "uico":
                            stubll.UpdateIco(pokeys.utid, pokeys.val);
                            break;
                        default:
                            rsp.RspCode = "0011";
                            rsp.RspTxt = "传输命令不正确";
                            break;
                    }

                    //添加关联,添加或修改账号或密码
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 更新教师用户的资料,账号,密码,头像等
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<string> UpTecInfo([FromBody]Com.DataPack.UpTecKeys pokeys)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken, "utid=" + pokeys.utid, "type=" + pokeys.type, "val=" + pokeys.val };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    SchSystem.BLL.SchUserInfo stubll = new SchSystem.BLL.SchUserInfo();
                    switch (pokeys.type)
                    {
                        case "upw":
                            stubll.UpdatePw(pokeys.utid, Com.Public.StrToMD5(pokeys.val));
                            break;
                        default:
                            rsp.RspCode = "0011";
                            rsp.RspTxt = "传输命令不正确";
                            break;
                    }

                    //添加关联,添加或修改账号或密码
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 短信发送
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<string> SendSms([FromBody]Com.DataPack.SendSmsKeys pokeys)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "mobiles=" + pokeys.mobiles, "content=" + pokeys.content, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    Com.Public.SendSmsMs(pokeys.mobiles, pokeys.content);
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 系统区域
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.SysAreaList> SysArea([FromBody]Com.DataPack.SysAreaKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.SysAreaList> rsp = new Com.DataPack.DataRsp<Com.DataPack.SysAreaList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "areano=" + pokeys.areano, "type=" + pokeys.type, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    SchSystem.BLL.SysArea areabll = new SchSystem.BLL.SysArea();
                    DataTable dt = new DataTable();
                    //根据相应的类型修改相应的值
                    switch (pokeys.type)
                    {
                        case "0"://省份
                            dt = areabll.GetAreas("0", "");
                            break;
                        case "1"://城市
                            dt = areabll.GetAreas("1", pokeys.areano.Substring(0, 2));
                            break;
                        case "2"://县区
                            dt = areabll.GetAreas("2", pokeys.areano.Substring(0, 4));
                            break;
                        case "3"://获取所有城市
                            dt = areabll.GetAreas("1", "");
                            break;
                        case "4"://搜索城市
                            dt = areabll.GetAreas("1", pokeys.areano.Substring(0, 4) + "00");
                            break;
                        case "5"://搜索全区域
                            dt = areabll.GetAreas("", "");
                            break;
                        default:
                            break;
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Com.DataPack.SysAreaList list = new Com.DataPack.SysAreaList();
                        list.sysarea = Com.Public.DataTableToList<Com.DataPack.SysAreaInfo>(dt);
                        rsp.RspData = list;
                    }
                    else
                    {
                        rsp.RspCode = "0009";
                        rsp.RspTxt = "查询记录为空";
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }

        /// <summary>
        /// 系统模块:xxt校讯通模块,soure资源模块
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.AppList> SysApp([FromBody]Com.DataPack.AppKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.AppList> rsp = new Com.DataPack.DataRsp<Com.DataPack.AppList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "type=" + pokeys.type, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    DataTable dt = new DataTable();
                    if (pokeys.type == "soure")//资源
                    {
                        SchSystem.BLL.SchAppSoure appsourebll = new SchSystem.BLL.SchAppSoure();
                        dt = appsourebll.GetList(" AppName appsourename,AppCode appsourecode", " Stat=1 order by AppCode").Tables[0];
                    }
                    else if (pokeys.type == "xxt")//校讯通
                    {
                        SchSystem.BLL.SchAppXXT appsourebll = new SchSystem.BLL.SchAppXXT();
                        dt = appsourebll.GetList(" AppName appsourename,AppCode appsourecode", " Stat=1 order by AppCode").Tables[0];
                    }
                    else if (pokeys.type == "base")//基础信息
                    {
                        SchSystem.BLL.SchApp appsourebll = new SchSystem.BLL.SchApp();
                        dt = appsourebll.GetList(" AppName appsourename,AppCode appsourecode", " Stat=1 order by AppCode").Tables[0];
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Com.DataPack.AppList sublist = new Com.DataPack.AppList();
                        sublist.appsoure = Com.Public.DataTableToList<Com.DataPack.AppInfo>(dt);
                        rsp.RspData = sublist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }

        /// <summary>
        /// 学校相关信息
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.SchInfo> SchInfoSoure([FromBody]Com.DataPack.SchInfoKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.SchInfo> rsp = new Com.DataPack.DataRsp<Com.DataPack.SchInfo>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    Com.DataPack.SchInfo schinfo = new Com.DataPack.SchInfo();
                    //获取学校基本信息
                    SchSystem.BLL.SchInfo schbll = new SchSystem.BLL.SchInfo();
                    DataTable dtsch = schbll.GetList(" SchId schid,SchName schname,ResourcePlatformName sourename,ResourcePlatformIco sourelogo,SourceSerStat sourestat", " Stat=1 and schid=" + schid).Tables[0];
                    if (dtsch != null && dtsch.Rows.Count > 0)
                    {
                        schinfo.schid = int.Parse(dtsch.Rows[0]["schid"].ToString());
                        schinfo.schname = dtsch.Rows[0]["schname"].ToString();
                        schinfo.sourename = dtsch.Rows[0]["sourename"].ToString();
                        schinfo.sourelogo = Com.Public.GetKey("adminurl") + dtsch.Rows[0]["sourelogo"].ToString();
                        schinfo.sourestat = int.Parse(dtsch.Rows[0]["sourestat"].ToString());
                    }
                    //管理员信息
                    SchSystem.BLL.SchUserInfo userbll = new SchSystem.BLL.SchUserInfo();
                    DataTable dtuser = userbll.GetList(" UserTname adminname,ImgUrl adminimg,Mobile adminmobile", " Stat=1 and SysType=1 and schid=" + schid).Tables[0];
                    if (dtuser != null && dtuser.Rows.Count > 0)
                    {
                        schinfo.adminname = dtuser.Rows[0]["adminname"].ToString();
                        schinfo.adminimg = Com.Public.GetKey("adminurl") + "/" + dtuser.Rows[0]["adminimg"].ToString().Replace("\\", "/");
                        schinfo.adminmobile = dtuser.Rows[0]["adminmobile"].ToString();
                    }
                    //科目教版信息
                    SchSystem.BLL.SchPerSubMat persubmatbll = new SchSystem.BLL.SchPerSubMat();
                    DataTable dtpersubmat = persubmatbll.GetList(" PerCode percode,SubCode subcode,MaterCode matercodes", "schid=" + schid + " order by convert(int,PerCode),SubCode,MaterCode").Tables[0];
                    if (dtpersubmat != null && dtpersubmat.Rows.Count > 0)
                    {
                        schinfo.persubmat = Com.Public.DataTableToList<Com.DataPack.PerSubMat>(dtpersubmat);
                    }
                    //资源模块信息
                    SchSystem.BLL.SchAppRoleSoure appsourebll = new SchSystem.BLL.SchAppRoleSoure();
                    DataTable dtappsoure = appsourebll.GetList(" AppCode soureappstat", "schid=" + schid).Tables[0];
                    if (dtappsoure != null && dtappsoure.Rows.Count > 0)
                    {
                        schinfo.soureappstat = dtappsoure.Rows[0]["soureappstat"].ToString();
                    }
                    //校讯通模块信息
                    SchSystem.BLL.SchAppRoleXXT appxxtbll = new SchSystem.BLL.SchAppRoleXXT();
                    DataTable dtappxxt = appxxtbll.GetList(" AppStr xxtapps", "schid=" + schid).Tables[0];
                    if (dtappxxt != null && dtappxxt.Rows.Count > 0)
                    {
                        schinfo.xxtapps = dtappxxt.Rows[0]["xxtapps"].ToString();
                    }
                    //基础用户模块
                    SchSystem.BLL.SchAppRole appbasebll = new SchSystem.BLL.SchAppRole();
                    schinfo.baseapps = appbasebll.GetAppStr(schid);

                    rsp.RspData = schinfo;
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        
        /// <summary>
        /// 学期
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.SchStucList> SchStuC([FromBody]Com.DataPack.SchKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.SchStucList> rsp = new Com.DataPack.DataRsp<Com.DataPack.SchStucList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = int.Parse(tokenvalue.Split(':')[2]);
                    SchSystem.BLL.SchStuInfoV stuvbll = new SchSystem.BLL.SchStuInfoV();
                    DataTable dtstuc = stuvbll.GetList(" ClassId clsid,count(*) stuc", "StuStat=1 and IsFinish=0 and SchId=" + schid + " group by ClassId").Tables[0];
                    if (dtstuc != null && dtstuc.Rows.Count > 0)
                    {
                        Com.DataPack.SchStucList stuclist = new Com.DataPack.SchStucList();
                        stuclist.schstuc = Com.Public.DataTableToList<Com.DataPack.SchStucInfo>(dtstuc);
                        rsp.RspData = stuclist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }

        /// <summary>
        /// 小程序用户登录接口
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.UserInfo> WxAuthLogin([FromBody]Com.DataPack.WxAuthKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = new Com.DataPack.DataRsp<Com.DataPack.UserInfo>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "wxid=" + pokeys.wxid, "shaketype=" + pokeys.shaketype };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //获取私钥
                //私钥key
                string shakeprakey = pokeys.uuid + "|" + pokeys.shaketype + "|shakepra";
                //string shakeplckey = uuid + "|" + shaketype + "|shakeplc";
                //私钥值
                string shakeprakeyvalue = Com.Public.GetCacheKey(shakeprakey);
                //如果私钥不存在,需要重新握手
                if (string.IsNullOrEmpty(shakeprakeyvalue))
                {
                    rsp.RspCode = "0002";
                    rsp.RspTxt = "时间过期需要重新握手";
                }
                else//私钥有效期还在,则开始验证
                {
                    //游客身份
                    //解密UID,可能是手机号或账号,邮箱等,微信小程序ID
                    string decwxuid = Com.RsaV.RSADec(shakeprakeyvalue, pokeys.wxid);
                    //看是否有关联,有关联则登录,否则返回为游客或让用户关联
                    SchSystem.BLL.WxMinUnSysUser unbll = new SchSystem.BLL.WxMinUnSysUser();
                    DataTable dtun = unbll.GetList("SysUname,SysType,SchId,Mobile", "WxUid='" + decwxuid + "'").Tables[0];
                    if (dtun != null && dtun.Rows.Count > 0)
                    {
                        string duid = dtun.Rows[0]["SysUname"].ToString();
                        string dutp = dtun.Rows[0]["SysType"].ToString();
                        string duschid = dtun.Rows[0]["SchId"].ToString();
                        string dumb = dtun.Rows[0]["Mobile"].ToString();
                        rsp = DoUserInfo(duid, dutp, pokeys.uuid);
                    }
                    else//游客
                    {
                        rsp = DoUserInfo("00000000000", "9", pokeys.uuid);
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }

        /// <summary>
        /// 小程序用户关联接口
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.UserInfo> WxUserUn([FromBody]Com.DataPack.WxUnKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = new Com.DataPack.DataRsp<Com.DataPack.UserInfo>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "wxid=" + pokeys.wxid, "uid=" + pokeys.uid, "utp=" + pokeys.utp, "mobile=" + pokeys.mobile, "shaketype=" + pokeys.shaketype };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //获取私钥
                //私钥key
                string shakeprakey = pokeys.uuid + "|" + pokeys.shaketype + "|shakepra";
                //string shakeplckey = uuid + "|" + shaketype + "|shakeplc";
                //私钥值
                string shakeprakeyvalue = Com.Public.GetCacheKey(shakeprakey);
                //如果私钥不存在,需要重新握手
                if (string.IsNullOrEmpty(shakeprakeyvalue))
                {
                    rsp.RspCode = "0002";
                    rsp.RspTxt = "时间过期需要重新握手";
                }
                else//私钥有效期还在,则开始验证
                {
                    //解密各个参数
                    string decwxuid = Com.RsaV.RSADec(shakeprakeyvalue, pokeys.wxid);
                    string duid = Com.RsaV.RSADec(shakeprakeyvalue, pokeys.uid);
                    string dumobile = Com.RsaV.RSADec(shakeprakeyvalue, pokeys.mobile);
                    //看是否有关联,有关联则登录,否则返回为游客或让用户关联
                    SchSystem.BLL.WxMinUnSysUser unbll = new SchSystem.BLL.WxMinUnSysUser();
                    DataTable dtun = unbll.GetList("SysUname,SysType,SchId,Mobile", "WxUid='" + decwxuid + "'").Tables[0];
                    SchSystem.Model.WxMinUnSysUser unmodel = new SchSystem.Model.WxMinUnSysUser();
                    if (dtun != null && dtun.Rows.Count > 0)//有关联则修改关联
                    {
                        unmodel.Mobile = dumobile;
                        unmodel.SchId = 0;
                        unmodel.SysType = int.Parse(pokeys.utp);
                        unmodel.SysUname = duid;
                        unmodel.WxUid = decwxuid;
                        unbll.UpdateUn(unmodel);
                    }
                    else//无关联则添加
                    {
                        unmodel.Mobile = dumobile;
                        unmodel.SchId = 0;
                        unmodel.SysType = int.Parse(pokeys.utp);
                        unmodel.SysUname = duid;
                        unmodel.WxUid = decwxuid;
                        unbll.Add(unmodel);
                    }
                    rsp = DoUserInfo(duid, pokeys.utp, pokeys.uuid);
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }

        private Com.DataPack.DataRsp<Com.DataPack.UserInfo> DoUserInfo(string duid, string dutp, string uuid)
        {
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = new Com.DataPack.DataRsp<Com.DataPack.UserInfo>();
            Com.DataPack.UserInfo uinfo = new Com.DataPack.UserInfo();
            if (dutp == "0")
            {
                SchSystem.BLL.SchUserInfo userbll = new SchSystem.BLL.SchUserInfo();
                //获取用户信息
                SchSystem.Model.SchUserInfo usermodel = userbll.GetModelByUname(duid);
                SchSystem.BLL.SchInfo schbll = new SchSystem.BLL.SchInfo();
                SchSystem.Model.SchInfo schmodel;
                if (usermodel != null && usermodel.UserId > 0)
                {
                    uinfo.isadmin = usermodel.SysType;
                    //用户执教班级
                    SchSystem.BLL.SchClassUser schclassuserbll = new SchSystem.BLL.SchClassUser();
                    DataTable dtcls = schclassuserbll.GetListV("GradeId grdid,GradeCode grdcode,ClassName clsname,ClassId clsid,SubCode subcode,IsMs isms,IsFinish isfinish", "UserName=" + usermodel.UserId + " Order by GradeCode,ClassName").Tables[0];
                    if (dtcls != null && dtcls.Rows.Count > 0)
                    {
                        uinfo.clss = Com.Public.DataTableToList<Com.DataPack.ClassSub>(dtcls);
                    }
                    //用户所在部门
                    SchSystem.BLL.SchUserDeptV userdptbll = new SchSystem.BLL.SchUserDeptV();
                    DataTable dtdpt = userdptbll.GetList("DeptId dptid,DepartName dptname", "Stat=1 and UserId=" + usermodel.UserId).Tables[0];
                    if (dtdpt != null && dtdpt.Rows.Count > 0)
                    {
                        uinfo.dpts = Com.Public.DataTableToList<Com.DataPack.Depart>(dtdpt);
                    }
                    //用户管理年级
                    SchSystem.BLL.SchGradeUserV usergradebll = new SchSystem.BLL.SchGradeUserV();
                    DataTable dtgrade = usergradebll.GetList("GradeId grdid,GradeCode grdcode,GradeName grdname,IsFinish isfinish", "UserName=" + usermodel.UserId + " Order by GradeCode").Tables[0];
                    if (dtgrade != null && dtgrade.Rows.Count > 0)
                    {
                        uinfo.grds = Com.Public.DataTableToList<Com.DataPack.GradeBoss>(dtgrade);
                    }

                    //用户学科组长
                    SchSystem.BLL.SchUserSubV usersubbll = new SchSystem.BLL.SchUserSubV();
                    DataTable dtsubs = usersubbll.GetList("SubCode subcode,SubName subname", "UserName=" + usermodel.UserId + " Order by SubCode").Tables[0];
                    if (dtsubs != null && dtsubs.Rows.Count > 0)
                    {
                        uinfo.subs = Com.Public.DataTableToList<Com.DataPack.SubBoss>(dtsubs);
                    }
                    uinfo.schid = usermodel.SchId;
                    if (!string.IsNullOrEmpty(usermodel.ImgUrl))
                    {
                        uinfo.imgurl = Com.Public.GetKey("adminurl") + "/" + usermodel.ImgUrl.Replace("\\", "/");
                    }
                    schmodel = schbll.GetModel(usermodel.SchId);

                    uinfo.schname = schmodel.SchName;
                    uinfo.areano = schmodel.AreaNo;
                    uinfo.appxxtdouser = schmodel.HomeSchBasicStat;
                    uinfo.appxxtservstat = schmodel.HomeschServStat;
                    uinfo.appxxtname = schmodel.HomeSchPlatName;
                    if (!string.IsNullOrEmpty(schmodel.HomeSchPlatIco))
                    {
                        uinfo.appxxtico = Com.Public.GetKey("adminurl") + schmodel.HomeSchPlatIco.Replace("\\", "/");
                    }
                    //获取子系统编辑状态
                    uinfo.appeditstat = Convert.ToInt32(schmodel.SonSysStat);
                    uinfo.sex = usermodel.Sex;
                    uinfo.uid = duid;
                    //权限合并
                    SchSystem.BLL.SchUserRoleV userroleV = new SchSystem.BLL.SchUserRoleV();
                    DataTable dtroles = userroleV.GetList("UserName='" + Com.Public.SqlEncStr(duid) + "' and Stat=1 and SchId=" + usermodel.SchId).Tables[0];
                    if (dtroles != null && dtroles.Rows.Count > 0)
                    {
                        uinfo.urolestr = Com.Public.UserRoleStr(dtroles, "RoleStr");
                        uinfo.urolestrext = Com.Public.UserRoleStr(dtroles, "RoleStrExt");
                    }
                    uinfo.utid = usermodel.UserId;
                    uinfo.utname = usermodel.UserTname;
                    uinfo.utp = 0;
                    //资源平台权限
                    SchSystem.BLL.SchUserRoleSoureV userrolesoureV = new SchSystem.BLL.SchUserRoleSoureV();
                    DataTable dtrolesoures = userrolesoureV.GetList("UserName='" + Com.Public.SqlEncStr(duid) + "' and Stat=1 and SchId=" + usermodel.SchId).Tables[0];
                    if (dtrolesoures != null && dtrolesoures.Rows.Count > 0)
                    {
                        uinfo.urolestrsoure = Com.Public.UserRoleStr(dtrolesoures, "RoleStr");
                    }
                    //校讯通平台权限
                    SchSystem.BLL.SchUserRoleXXTV userrolexxtV = new SchSystem.BLL.SchUserRoleXXTV();
                    DataTable dtrolexxt = userrolexxtV.GetList("UserName='" + Com.Public.SqlEncStr(duid) + "' and Stat=1 and SchId=" + usermodel.SchId).Tables[0];
                    if (dtrolexxt != null && dtrolexxt.Rows.Count > 0)
                    {
                        uinfo.urolestrxxt = Com.Public.UserRoleStr(dtrolexxt, "RoleStr");
                    }
                    //用户uid存在,生成Token并存储,设2个小时过期
                    string uuidutid = uuid + ":" + usermodel.UserId.ToString() + ":" + usermodel.SchId + ":" + usermodel.UserTname + ":0";
                    string token = Com.Public.MadeToken(uuidutid, usermodel.UserId.ToString());
                    //存储令牌,令牌值为uuid:uid:utid,可以根据令牌识别用户和设备号和用户表ID
                    Com.Public.SetCacheKey(token, uuidutid, DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                    //存储用户登录hash,以便以后多设备同用户登录逻辑用,可根据token获取到uuid及uid,utid,根据这两个值操作对应的hash及对比,删除等操作
                    Com.Public.SetCacheKeyHash("userlogin:" + usermodel.UserId.ToString(), uuid, token, DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                    uinfo.utoken = token;
                    rsp.RspData = uinfo;
                }
                else
                {
                    rsp.RspCode = "0005";
                    rsp.RspTxt = "已关联的学校用户不存在";
                }
            }
            else if (dutp == "1")
            {
                SchSystem.BLL.ServUser servuserbll = new SchSystem.BLL.ServUser();
                SchSystem.Model.ServUser servusermodel = servuserbll.GetModel(duid);
                if (servusermodel != null)
                {
                    uinfo.schid = 0;
                    uinfo.sex = servusermodel.Usex;
                    uinfo.uid = duid;
                    uinfo.utid = servusermodel.AutoId;
                    uinfo.utname = servusermodel.UTname;
                    uinfo.utp = 1;
                    uinfo.imgurl = servusermodel.Uico;
                    //用户uid存在,生成Token并存储,设2个小时过期
                    string uuidutid = uuid + ":" + servusermodel.AutoId.ToString() + ":0:" + servusermodel.UTname + ":1";
                    string token = Com.Public.MadeToken(uuidutid, servusermodel.AutoId.ToString());
                    //存储令牌,令牌值为uuid:uid:utid,可以根据令牌识别用户和设备号和用户表ID
                    Com.Public.SetCacheKey(token, uuidutid, DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                    //存储用户登录hash,以便以后多设备同用户登录逻辑用,可根据token获取到uuid及uid,utid,根据这两个值操作对应的hash及对比,删除等操作
                    Com.Public.SetCacheKeyHash("servuserlogin:" + servusermodel.AutoId.ToString(), uuid, token, DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                    uinfo.utoken = token;
                    rsp.RspData = uinfo;
                }
                else
                {
                    rsp.RspCode = "0005";
                    rsp.RspTxt = "已关联的家长用户不存在";
                }
            }
            else if (dutp == "2")
            {
                SchSystem.BLL.SchStuInfo stuinfobll = new SchSystem.BLL.SchStuInfo();
                SchSystem.Model.SchStuInfo stumodel = stuinfobll.GetModel(duid);
                if (stumodel != null)
                {
                    uinfo.schid = stumodel.SchId;
                    uinfo.sex = stumodel.Sex;
                    uinfo.uid = duid;
                    uinfo.utid = stumodel.StuId;
                    uinfo.utname = stumodel.StuName;
                    uinfo.utp = 2;
                    uinfo.imgurl = stumodel.ImgUrl;
                    //用户uid存在,生成Token并存储,设2个小时过期
                    string uuidutid = uuid + ":" + stumodel.StuId.ToString() + ":" + stumodel.SchId.ToString() + ":" + stumodel.StuName + ":2";
                    string token = Com.Public.MadeToken(uuidutid, stumodel.StuId.ToString());
                    //存储令牌,令牌值为uuid:uid:utid,可以根据令牌识别用户和设备号和用户表ID
                    Com.Public.SetCacheKey(token, uuidutid, DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                    //存储用户登录hash,以便以后多设备同用户登录逻辑用,可根据token获取到uuid及uid,utid,根据这两个值操作对应的hash及对比,删除等操作
                    Com.Public.SetCacheKeyHash("servstulogin:" + stumodel.StuId.ToString(), uuid, token, DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                    uinfo.utoken = token;
                    rsp.RspData = uinfo;
                }
                else
                {
                    rsp.RspCode = "0005";
                    rsp.RspTxt = "已关联的学生用户不存在";
                }
            }
            else if (dutp == "9")
            {
                string uuidutid = uuid + ":0:0:游客:0";
                string token = Com.Public.MadeToken(uuidutid, "0");
                //存储令牌,令牌值为uuid:uid:utid,可以根据令牌识别用户和设备号和用户表ID
                Com.Public.SetCacheKey(token, uuidutid, DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                //存储用户登录hash,以便以后多设备同用户登录逻辑用,可根据token获取到uuid及uid,utid,根据这两个值操作对应的hash及对比,删除等操作
                Com.Public.SetCacheKeyHash("userlogin:0", uuid, token, DateTime.Now.AddSeconds(int.Parse(Com.Public.GetKey("KeyCacheSpan"))));
                uinfo.uid = "00000000000";
                uinfo.utid = 0;
                uinfo.utname = "游客";
                uinfo.utp = 0;
                uinfo.utoken = token;
                rsp.RspData = uinfo;
            }
            else//不明身份
            {
                rsp.RspCode = "0005";
                rsp.RspTxt = "身份未明";
            }
            return rsp;
        }

        /// <summary>
        /// 小程序用户手机关联的各种用户资料
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.WxMobileUserList> WxMobileUsers([FromBody]Com.DataPack.WxMobileUserKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.WxMobileUserList> rsp = new Com.DataPack.DataRsp<Com.DataPack.WxMobileUserList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "mobile=" + pokeys.mobile, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    //获取对应的数据
                    //获取教师数据
                    SchSystem.BLL.SchUserInfo userbll = new SchSystem.BLL.SchUserInfo();
                    DataTable dttec = userbll.GetList("UserName uid,UserTname uname,0 utp", "Stat=1 and len(UserName)>0 and Mobile='" + Com.Public.SqlEncStr(pokeys.mobile) + "'").Tables[0];
                    //获取注册用户数据
                    SchSystem.BLL.ServUser servuserbll = new SchSystem.BLL.ServUser();
                    DataTable dtuserser = servuserbll.GetList("UserName uid,UTname uname,1 utp", "Stat=1 and len(UserName)>0 and UserName='" + Com.Public.SqlEncStr(pokeys.mobile) + "'").Tables[0];
                    //获取学生数据
                    SchSystem.BLL.SchStuInfo stubll = new SchSystem.BLL.SchStuInfo();
                    DataTable dtstu = stubll.GetList("LoginName uid,StuName uname,2 utp", "Stat=1 and len(LoginName)>0 and TelNo='" + Com.Public.SqlEncStr(pokeys.mobile) + "'").Tables[0];
                    //合并表格
                    dttec.Merge(dtuserser);
                    dttec.Merge(dtstu);
                    if (dttec != null && dttec.Rows.Count > 0)
                    {
                        Com.DataPack.WxMobileUserList userlist = new Com.DataPack.WxMobileUserList();
                        userlist.wxmusers = Com.Public.DataTableToList<Com.DataPack.WxMobileUserInfo>(dttec);
                        rsp.RspData = userlist;
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }

        /// <summary>
        /// 获取班级栏目新闻,图片
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.ClassNewsList> ClassNewsList([FromBody]Com.DataPack.ClassNewsKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.ClassNewsList> rsp = new Com.DataPack.DataRsp<Com.DataPack.ClassNewsList>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "newslv=" + pokeys.newslv, "newstype=" + pokeys.newstype, "chncode=" + pokeys.chncode, "blandid=" + pokeys.blandid, "blandlv=" + pokeys.blandlv, "psize=" + pokeys.psize, "pindex=" + pokeys.pindex, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    int schid = 0;
                    int gradeid = 0;
                    int clssid = 0;
                    int chnid = 0;
                    string chname = "";
                    Com.DataPack.PageModel pg = new Com.DataPack.PageModel();
                    pg.PageSize = pokeys.psize;
                    pg.PageIndex = pokeys.pindex;

                    string sqlstr = " Stat=1 ";
                    if (pokeys.newstype == 0)//文章按顺序新闻
                    {
                        //sqlstr += " and ";
                    }
                    else if (pokeys.newstype == 1)//仅带图片新闻
                    {
                        sqlstr += " and len(Imgurl)>0";
                    }
                    string schname = "";
                    string gradename = "";
                    string classname = "";
                    SchSystem.BLL.SchGradeInfo gradebll = new SchSystem.BLL.SchGradeInfo();
                    SchSystem.BLL.SchInfo schbll = new SchSystem.BLL.SchInfo();
                    //根据班牌类型,获取对应信息,0班级班牌,1年级牌,2学校牌
                    if (pokeys.blandlv == 0)//班级牌
                    {
                        clssid = pokeys.blandid;
                        SchSystem.BLL.SchClassInfo classbll = new SchSystem.BLL.SchClassInfo();
                        DataTable classdt = classbll.GetList("GradeId,SchId,ClassName", "IsFinish=0 and ClassId=" + clssid).Tables[0];
                        if (classdt != null && classdt.Rows.Count > 0)
                        {
                            classname = classdt.Rows[0]["ClassName"].ToString();
                            gradeid = int.Parse(classdt.Rows[0]["GradeId"].ToString());
                            //获取年级名称
                            DataTable dtg = gradebll.GetList("GradeName", "GradeId=" + gradeid).Tables[0];
                            if(dtg.Rows.Count>0)
                            {
                                gradename = dtg.Rows[0]["GradeName"].ToString();
                            }
                            schid = int.Parse(classdt.Rows[0]["SchId"].ToString());
                            DataTable dtsch = schbll.GetList("SchName", "SchId=" + schid).Tables[0];
                            if (dtsch.Rows.Count > 0)
                            {
                                schname = dtsch.Rows[0]["SchName"].ToString();
                            }
                        }
                        if (pokeys.newslv == 0)//本级
                        {
                            sqlstr += " and lv=0 and ClassId=" + clssid;
                        }
                        else if (pokeys.newslv == 1)//向上不向下级
                        {
                            sqlstr += " and ((lv=0 and ClassId=" + clssid + ") or (lv=1 and GradeId=" + gradeid + ")or (lv=2 and SchId=" + schid + "))";
                        }
                        else if (pokeys.newslv == 2)//所关联的线的全部
                        {
                            sqlstr += " and ((lv=0 and ClassId=" + clssid + ") or (lv=1 and GradeId=" + gradeid + ") or (lv=2 and SchId=" + schid + "))";
                        }
                    }
                    else if (pokeys.blandlv == 1)//年级牌
                    {
                        gradeid = pokeys.blandid;
                        DataTable gradedt = gradebll.GetList("SchId,GradeName", "IsFinish=0 and GradeId=" + gradeid).Tables[0];
                        if (gradedt != null && gradedt.Rows.Count > 0)
                        {
                            gradename = gradedt.Rows[0]["GradeName"].ToString();
                            schid = int.Parse(gradedt.Rows[0]["SchId"].ToString());
                            DataTable dtsch = schbll.GetList("SchName", "SchId=" + schid).Tables[0];
                            if (dtsch.Rows.Count > 0)
                            {
                                schname = dtsch.Rows[0]["SchName"].ToString();
                            }
                        }
                        if (pokeys.newslv == 0)//本级
                        {
                            sqlstr += " and lv=1 and GradeId=" + gradeid;
                        }
                        else if (pokeys.newslv == 1)//向上不向下级
                        {
                            sqlstr += " and ((lv=1 and GradeId=" + gradeid + ") or (lv=2 and SchId=" + schid + "))";
                        }
                        else if (pokeys.newslv == 2)//所关联的线的全部
                        {
                            sqlstr += " and ((lv=0 and GradeId=" + gradeid + ") or (lv=1 and GradeId=" + gradeid + ") or (lv=2 and SchId=" + schid + "))";
                        }
                    }
                    else if (pokeys.blandlv == 2)//学校牌
                    {
                        schid = pokeys.blandid;
                        DataTable dtsch = schbll.GetList("SchName", "SchId=" + schid).Tables[0];
                        if (dtsch.Rows.Count > 0)
                        {
                            schname = dtsch.Rows[0]["SchName"].ToString();
                        }
                        if (pokeys.newslv == 0)//本级
                        {
                            sqlstr += " and lv=2 and SchId=" + schid;
                        }
                        else if (pokeys.newslv == 1)//向上不向下级
                        {
                            sqlstr += " and ((lv=2 and SchId=" + schid + "))";
                        }
                        else if (pokeys.newslv == 2)//所关联的线的全部
                        {
                            sqlstr += " and ((lv=0 and SchId=" + schid + ") or (lv=1 and SchId=" + schid + ") or (lv=2 and SchId=" + schid + "))";
                        }
                    }

                    SchSystem.BLL.WebSchChn chnbll = new SchSystem.BLL.WebSchChn();
                    DataTable chndt = chnbll.GetList("ChnId,ChnName", "Stat=1 and SchId=" + schid + " and ChnCode=" + pokeys.chncode).Tables[0];
                    if (chndt != null && chndt.Rows.Count > 0)
                    {
                        chnid = int.Parse(chndt.Rows[0]["ChnId"].ToString());
                        chname = chndt.Rows[0]["ChnName"].ToString();
                        sqlstr += " and ChnId=" + chnid;
                        SchSystem.BLL.WebSchNews userbll = new SchSystem.BLL.WebSchNews();
                        int pcount = 0;
                        int rowsc = 0;
                        string cols = "" + pokeys.chncode + " chncode,ChnId chnid,NewsId newsid,Topic topic,CONVERT(varchar(12),RecTime,102 ) rectime,Imgurl imgurl,Lv lv,IsTop istop";
                        if (pokeys.newstype == 2)//需要带详情的文章列表
                        {
                            cols += ",Content content";
                        }
                        DataTable dt = userbll.GetListCols(cols, sqlstr, "IsTop Desc,NewsId Desc", "", pg.PageIndex, pg.PageSize, ref rowsc, ref pcount).Tables[0];
                        Com.DataPack.ClassNewsList userlist = new Com.DataPack.ClassNewsList();
                        if (dt.Rows.Count > 0)
                        {
                            pg.PageCount = pcount;
                            pg.RowCount = rowsc;
                            userlist.pg = pg;
                            userlist.newslist = Com.Public.DataTableToList<Com.DataPack.NewsInfo>(dt);
                        }
                        userlist.chname = chname;
                        userlist.gradename = gradename;
                        userlist.classname = classname;
                        userlist.schname = schname;
                        rsp.RspData = userlist;
                    }
                    else
                    {
                        rsp.RspCode = "0009";
                        rsp.RspTxt = "无该栏目";
                    }
                    
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 获取单条新闻详情
        /// </summary>
        /// <param name="pokeys">Post的数据</param>
        /// <returns>返回值</returns>
        [HttpPost]
        public Com.DataPack.DataRsp<Com.DataPack.NewsInfo> ClassNews([FromBody]Com.DataPack.NewsKeys pokeys)
        {
            Com.DataPack.DataRsp<Com.DataPack.NewsInfo> rsp = new Com.DataPack.DataRsp<Com.DataPack.NewsInfo>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "newsid=" + pokeys.newsid, "utoken=" + pokeys.utoken };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    string sqlstr = " Stat=1 and NewsId=" + pokeys.newsid;
                    string cols = "ChnId chnid,NewsId newsid,Topic topic,CONVERT(varchar(12),RecTime,102 ) rectime,Imgurl imgurl,Lv lv,Content content";
                    SchSystem.BLL.WebSchNews userbll = new SchSystem.BLL.WebSchNews();
                    DataTable dt = userbll.GetList(cols, sqlstr).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        Com.DataPack.NewsInfo userlist = new Com.DataPack.NewsInfo();
                        userlist = Com.Public.DataTableToList<Com.DataPack.NewsInfo>(dt)[0];
                        //获取附件列表
                        SchSystem.BLL.WebSchNewsEnc encbll = new SchSystem.BLL.WebSchNewsEnc();
                        string sqlstrenc = " NewsId=" + pokeys.newsid;
                        string colsenc = "EncId encid,NewsId newsid,OldName oldname,SaveUrl saveurl,Imgurl imgurl";
                        DataTable dtenc = userbll.GetList(colsenc, sqlstrenc).Tables[0];
                        if (dtenc.Rows.Count > 0)
                        {
                            userlist.newsenclist = Com.Public.DataTableToList<Com.DataPack.NewsEnc>(dtenc);
                        }
                        rsp.RspData = userlist;
                    }
                    else
                    {
                        rsp.RspCode = "0009";
                        rsp.RspTxt = "查询记录为空";
                    }


                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pokeys"></param>
        /// <returns></returns>
        [HttpPost]
        public Com.DataPack.DataRsp<string> LoginU([FromBody]Com.DataPack.UserFeeKeys pokeys)
        {
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken, "uid=" + pokeys.uid, "servid=" + pokeys.servid, "servm=" + pokeys.servm, "feem=" + pokeys.feem, "dnote=" + pokeys.dnote, "recutname=" + pokeys.recutname, "frmtype=" + pokeys.frmtype, "funclist=" + Newtonsoft.Json.JsonConvert.SerializeObject(pokeys.funclist) };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    //int schid = int.Parse(tokenvalue.Split(':')[2]);
                    SchSystem.BLL.ServUserFor userforbll = new SchSystem.BLL.ServUserFor();
                    int rid = userforbll.UserRefee(pokeys.uid, pokeys.servid, pokeys.servm, pokeys.feem, pokeys.dnote, pokeys.recutname, pokeys.frmtype);
                    if (rid > 0)
                    {

                        //添加功能
                        List<SchWebApi.Com.DataPack.UserFeeFuncInfo> listfunc = pokeys.funclist;
                        if (listfunc.Count > 0)
                        {
                            SchSystem.BLL.ServUserForExt userforextbll = new SchSystem.BLL.ServUserForExt();
                            SchSystem.Model.ServUserForExt userforext;
                            for (int i = 0; i < listfunc.Count; i++)
                            {
                                userforext = new SchSystem.Model.ServUserForExt();
                                userforext.Fcode = listfunc[i].fcode;
                                userforext.NapeCode = listfunc[i].itemcode;
                                userforext.NapeCodes = listfunc[i].itemsons;
                                userforext.UserForId = rid;
                                userforextbll.Add(userforext);
                            }
                        }
                        rsp.RspData = "添加成功!";
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }



        public Com.DataPack.DataRsp<string> LoginUU([FromBody]Com.DataPack.UserFeeKeys pokeys)
        {
            //生成RSA密码对
            string[] scrersa = Com.RsaV.GenerateKeys();
            //缓存公钥和私钥,并加过期时间
            string shakeplckeyvalue = scrersa[1];
            Com.DataPack.RSAKeyValue plckey = (Com.DataPack.RSAKeyValue)Com.XmlSerializeUtil.Deserialize(typeof(Com.DataPack.RSAKeyValue), shakeplckeyvalue);
            plckey.Exponent = Com.Public.BytesToHexString(Convert.FromBase64String(plckey.Exponent));
            plckey.Modulus = Com.Public.BytesToHexString(Convert.FromBase64String(plckey.Modulus));
            Com.DataPack.DataRsp<string> rsp = new Com.DataPack.DataRsp<string>();
            try
            {
                string[] keys = new string[] { "uuid=" + pokeys.uuid, "appid=" + pokeys.appid, "utoken=" + pokeys.utoken, "uid=" + pokeys.uid, "servid=" + pokeys.servid, "servm=" + pokeys.servm, "feem=" + pokeys.feem, "dnote=" + pokeys.dnote, "recutname=" + pokeys.recutname, "frmtype=" + pokeys.frmtype, "funclist=" + Newtonsoft.Json.JsonConvert.SerializeObject(pokeys.funclist) };
                if (!Com.Public.VerifyUrl(keys, pokeys.sign))
                {
                    rsp.RspCode = "0001";
                    rsp.RspTxt = "url被篡改";
                    return rsp;
                }
                //判断token是否已过期
                string tokenvalue = Com.Public.GetCacheKey(pokeys.utoken);
                if (string.IsNullOrEmpty(tokenvalue))//token过期或不存在,提示重新登录
                {
                    rsp.RspCode = "0006";
                    rsp.RspTxt = "令牌过期";
                }
                else
                {
                    //int schid = int.Parse(tokenvalue.Split(':')[2]);
                    SchSystem.BLL.ServUserFor userforbll = new SchSystem.BLL.ServUserFor();
                    if (userforbll.Exists(pokeys.uid, pokeys.servid))
                    {
                        rsp.RspCode = "0005";
                        rsp.RspTxt = "该用户已订购该套餐!";
                    }
                    else
                    {
                        int rid = userforbll.UserRefee(pokeys.uid, pokeys.servid, pokeys.servm, pokeys.feem, pokeys.dnote, pokeys.recutname, pokeys.frmtype);
                        if (rid > 0)
                        {

                            //添加功能
                            List<SchWebApi.Com.DataPack.UserFeeFuncInfo> listfunc = pokeys.funclist;
                            if (listfunc.Count > 0)
                            {
                                SchSystem.BLL.ServUserForExt userforextbll = new SchSystem.BLL.ServUserForExt();
                                SchSystem.Model.ServUserForExt userforext;
                                for (int i = 0; i < listfunc.Count; i++)
                                {
                                    if (listfunc[i].itemsons != "null")
                                    {
                                        userforext = new SchSystem.Model.ServUserForExt();
                                        userforext.Fcode = listfunc[i].fcode;
                                        userforext.NapeCode = listfunc[i].itemcode;
                                        userforext.NapeCodes = listfunc[i].itemsons;
                                        userforext.UserForId = rid;
                                        userforextbll.Add(userforext);
                                    }
                                }
                            }
                            rsp.RspData = "添加成功!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "9999";
                rsp.RspTxt = ex.Message;
            }
            //私钥加密
            return rsp;
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
