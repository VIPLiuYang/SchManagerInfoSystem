using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SchWebApi.Com
{
    /// <summary>
    /// 数据包定义
    /// </summary>
    public class DataPack
    {
        /// <summary>
        /// Resp包
        /// </summary>
        [Serializable]
        public class DataRsp<T>
        {
            /// <summary>
            /// 返回状态码
            /// </summary>
            public string RspCode = "0000";//返回代码
            /// <summary>
            /// 返回说明
            /// </summary>
            public string RspTxt = "正常";//返回代码提示
            /// <summary>
            /// 返回数据包
            /// </summary>
            public T RspData;//数据包
        }
        [Serializable]
        public class PageModel
        {
            public int PageSize { get; set; }
            public int PageIndex { get; set; }
            public int RowCount { get; set; }
            public int PageCount { get; set; }
        }
        /// <summary>
        /// 用户Data
        /// </summary>
        [Serializable]
        public class UserInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public int schid;
            /// <summary>
            /// 
            /// </summary>
            public string schname;
            /// <summary>
            /// 区域代码
            /// </summary>
            public string areano;
            /// <summary>
            /// 
            /// </summary>
            public int utid;
            /// <summary>
            /// 
            /// </summary>
            public string uid;
            /// <summary>
            /// 
            /// </summary>
            public string utname;
            /// <summary>
            /// 
            /// </summary>
            public int sex;
            /// <summary>
            /// 
            /// </summary>
            public string imgurl;
            /// <summary>
            /// 
            /// </summary>
            public List<Depart> dpts;
            /// <summary>
            /// 
            /// </summary>
           
            public List<GradeBoss> grds;
            /// <summary>
            /// 
            /// </summary>
            public List<ClassSub> clss;
            /// <summary>
            /// 
            /// </summary>
            public List<SubBoss> subs;
            /// <summary>
            /// 
            /// </summary>
            public int utp;
            /// <summary>
            /// 
            /// </summary>
            public string urolestr;
            /// <summary>
            /// 
            /// </summary>
            public string urolestrext;
            /// <summary>
            /// 
            /// </summary>
            public string utoken;
            /// <summary>
            /// 子系统编辑状态:0不允许编辑或增加,删除;1开启
            /// </summary>
            public int appeditstat;
            /// <summary>
            /// 校讯通服务状态:0停用,1正常
            /// </summary>
            public int appxxtservstat;
            /// <summary>
            /// 校讯通平台名称;
            /// </summary>
            public string appxxtname;
            /// <summary>
            /// 校讯通平台图标;
            /// </summary>
            public string appxxtico;
            /// <summary>
            /// 校讯通操作者:0支撑系统,1学校
            /// </summary>
            public int appxxtdouser;
            /// <summary>
            /// 是否为学校管理员:0非;1是;
            /// </summary>
            public int isadmin;
            /// <summary>
            /// 资源平台权限串:对应权限位0,1代表拥有状态;
            /// </summary>
            public string urolestrsoure;
            /// <summary>
            /// 校讯通权限串:对应权限位0,1代表拥有状态;
            /// </summary>
            public string urolestrxxt;

        }
        /// <summary>
        /// 用户Data
        /// </summary>
        [Serializable]
        public class SchInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public int schid;
            /// <summary>
            /// 
            /// </summary>
            public string schname;
            /// <summary>
            /// 
            /// </summary>
            public string adminname;
            /// <summary>
            /// 
            /// </summary>
            public string adminimg;
            /// <summary>
            /// 
            /// </summary>
            public string adminmobile;

            /// <summary>
            /// 
            /// </summary>
            public string sourename;

            /// <summary>
            /// 
            /// </summary>
            public string sourelogo;

            /// <summary>
            /// 资源平台模块屏蔽状态
            /// </summary>
            public int sourestat;
            /// <summary>
            /// 3,1|4,1|5,0,模块,模块共享状态(1共享,0私有)
            /// </summary>
            public string soureappstat;
            /// <summary>
            /// 1,2,3,4基础信息模块
            /// </summary>
            public string baseapps;
            /// <summary>
            /// 1,2,3,4校讯通模块
            /// </summary>
            public string xxtapps;
            /// <summary>
            /// 
            /// </summary>
            public List<PerSubMat> persubmat;

        }
        /// <summary>
        /// 所在部门
        /// </summary>
        [Serializable]
        public class PerSubMat
        {
            /// <summary>
            /// 
            /// </summary>
            public string percode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string subcode { get; set; }
            /// <summary>
            /// 一个科目多个教版
            /// </summary>
            public string matercodes { get; set; }
        }
        /// <summary>
        /// 所在部门
        /// </summary>
        [Serializable]
        public class Depart
        {
            /// <summary>
            /// 
            /// </summary>
            public int dptid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string dptname{ get; set; }
        }
        /// <summary>
        /// 年级主任的年级
        /// </summary>
        [Serializable]
        public class GradeBoss
        {
            /// <summary>
            /// 
            /// </summary>
            public int grdid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string grdcode{ get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string grdname { get; set; }//isfinish
            /// <summary>
            /// 
            /// </summary>
            public int isfinish { get; set; }
        }
        /// <summary>
        /// 班级任课
        /// </summary>
        [Serializable]
        public class ClassSub
        {
            /// <summary>
            /// 
            /// </summary>
            public int grdid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string grdcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string subcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int clsid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int isms { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string clsname { get; set; }//isfinish
            /// <summary>
            /// 
            /// </summary>
            public int isfinish { get; set; }
        }

        /// <summary>
        /// 科任组长
        /// </summary>
        [Serializable]
        public class SubBoss
        {
            /// <summary>
            /// 
            /// </summary>
            public string subcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string subname { get; set; }
        }

        /// <summary>
        /// 学校学段和年级信息
        /// </summary>
        [Serializable]
        public class GradeList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<GradeInfo> grds;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class GradeInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public int grdid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string pcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string pname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string sysgradename { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string collcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string majorcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string grdcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string grdname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string grdyear { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int isfinish { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class ClassList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<ClassInfo> clss;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class ClassInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public int grdid { get; set; }
            /// <summary>
            /// collcode
            /// </summary>
            public string collcode;
            /// <summary>
            /// majorcode
            /// </summary>
            public string majorcode;
            /// <summary>
            /// 
            /// </summary>
            public string grdcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int clsid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string clsno { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string clsname { get; set; }           
            
            /// <summary>
            /// 
            /// </summary>
            public int isfinish { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SubList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<SubInfo> subs;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SubInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string subcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string subname { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class DepartList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<DepartInfo> dpts;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class DepartInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public int pid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int dptid { get; set; }//orderid
            /// <summary>
            /// 
            /// </summary>
            public string dptname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int orderid { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class GradeBossList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<GradeBossInfo> grdbosss;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class GradeBossInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public int grdid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string grdcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int utid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string utname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string imgurl { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string mobile { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SubBossList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<SubBossInfo> subboss;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SubBossInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string subcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int utid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string utname { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysTermList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<SysTermInfo> systerm;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysTermInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string termcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string termname { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SchStucList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<SchStucInfo> schstuc;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SchStucInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public int clsid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int stuc { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class ClassUserList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<ClassUserInfo> clssusers;
        }

        [Serializable]
        public class ClassUserInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string grdcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int clsid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string clsname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int utid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string utname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string subcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string subname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int isms { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string imgurl { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string mobile { get; set; }
            
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class StuList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<StuInfo> clssstus;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class StuInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string grdcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string grdname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int clsid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string clsname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int stuid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int sex { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string stuname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string stuno { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string cardno { get; set; }

        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class ClassUserUstuList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<UserUstuInfo> classuserustus;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class UserUstuInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public int schid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string schname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int grdid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string grdcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string grdname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int clsid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string clsname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int stuid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string stuname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int forid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int utid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int ustat { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string mobile { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string servname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string utname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string uimg { get; set; }

        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class UserList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<UserDeptInfo> users;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class UserDeptInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public int utid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int dptid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string utname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string imgurl { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string mobile { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int sex { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<Depart> udpts;
        }
        [Serializable]
        public class AreaList
        {
            /// <summary>
            /// 区域或学校列表
            /// </summary>
            public List<AreaInfo> areas;
        }
        public class AreaInfo
        {
            /// <summary>
            /// 代码
            /// </summary>
            public string code { get; set; }
            /// <summary>
            /// 名称
            /// </summary>
            public string name { get; set; }
        }
        /// <summary>
        /// RsaKeys
        /// </summary>
        [Serializable]
        public class RSAKeyValue
        {
            /// <summary>
            /// 模数
            /// </summary>
            public string Exponent;
            /// <summary>
            /// 指数
            /// </summary>
            public string Modulus;
        }
        /// <summary>
        /// Post的基础数据
        /// </summary>
        public class PostKeysBase
        {
            /// <summary>
            /// 设备ID
            /// </summary>
            public string uuid;
            /// <summary>
            /// 应用ID
            /// </summary>
            public string appid;

            /// <summary>
            /// url签名
            /// </summary>
            public string sign;
        }
        /// <summary>
        /// 握手Keys
        /// </summary>
        [Serializable]
        public class ShakeKeys : PostKeysBase
        {
            /// <summary>
            /// 握手类型
            /// </summary>
            public string shaketype;
        }
        /// <summary>
        /// 获取验证码Keys
        /// </summary>
        [Serializable]
        public class CodeKey : PostKeysBase
        {
            /// <summary>
            /// 握手类型
            /// </summary>
            public string shaketype;
            /// <summary>
            /// 账号,公钥加密
            /// </summary>
            public string uid;
            /// <summary>
            /// 验证码,公钥加密
            /// </summary>
            public string code;
        }
        /// <summary>
        /// 普通用户注册Keys
        /// </summary>
        [Serializable]
        public class UserRegKey : PostKeysBase
        {
            /// <summary>
            /// 握手类型
            /// </summary>
            public string shaketype;
            /// <summary>
            /// 账号,公钥加密
            /// </summary>
            public string uid;
            /// <summary>
            /// 验证码,公钥加密
            /// </summary>
            public string code;
            /// <summary>
            /// 密码,公钥加密
            /// </summary>
            public string pw;
            /// <summary>
            /// 昵称,姓名
            /// </summary>
            public string utn;
            /// <summary>
            /// 性别
            /// </summary>
            public int usex;
        }
        /// <summary>
        /// 登录Keys
        /// </summary>
        [Serializable]
        public class LoginKeys : PostKeysBase
        {
            /// <summary>
            /// 学校ID
            /// </summary>
            public string schid;
            /// <summary>
            /// 握手类型
            /// </summary>
            public string shaketype;
            /// <summary>
            /// 账号,公钥加密
            /// </summary>
            public string uid;
            /// <summary>
            /// 密码,公钥加密
            /// </summary>
            public string pw;
            /// <summary>
            /// 用户类型,0校园用户,1注册用户
            /// </summary>
            public string utp;
        }
        /// <summary>
        /// 后续取学校部分数据
        /// </summary>
        [Serializable]
        public class SchKeys : PostKeysBase
        {
            /// <summary>
            /// isfinish
            /// </summary>
            public int isfinish;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 后续取学校部分数据
        /// </summary>
        [Serializable]
        public class UnvSchGradeKeys : PostKeysBase
        {
            /// <summary>
            /// isfinish
            /// </summary>
            public int schid;
            /// <summary>
            /// isfinish
            /// </summary>
            public string collcode;
            /// <summary>
            /// isfinish
            /// </summary>
            public string majorcode;
            /// <summary>
            /// isfinish
            /// </summary>
            public int isfinish;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 后续取学校部分数据
        /// </summary>
        [Serializable]
        public class UnvSchClassKeys : PostKeysBase
        {
            /// <summary>
            /// isfinish
            /// </summary>
            public int schid;
            /// <summary>
            /// isfinish
            /// </summary>
            public string collcode;
            /// <summary>
            /// isfinish
            /// </summary>
            public string majorcode;
            /// <summary>
            /// isfinish
            /// </summary>
            public int gradeid;            
            /// <summary>
            /// isfinish
            /// </summary>
            public int isfinish;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 后续取年级部分数据
        /// </summary>
        [Serializable]
        public class GradeKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string gradeids;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 后续取科目组长
        /// </summary>
        [Serializable]
        public class SubKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string subcodes;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 学期数据
        /// </summary>
        [Serializable]
        public class TermKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 后续取班级部分数据
        /// </summary>
        [Serializable]
        public class ClassKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string classids;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 后续取班级部分数据
        /// </summary>
        [Serializable]
        public class ClassUserUstuKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string classids;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 后续取班级部分数据
        /// </summary>
        [Serializable]
        public class SendSmsKeys : PostKeysBase
        {
            /// <summary>
            /// mobiles
            /// </summary>
            public string mobiles;
            /// <summary>
            /// content
            /// </summary>
            public string content;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 后续取班级部分数据
        /// </summary>
        [Serializable]
        public class DepartKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string dptids;
            /// <summary>
            /// uidstat -1,全部人员,0,无账号,1有账号
            /// </summary>
            public int uidstat;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 后续取班级部分数据
        /// </summary>
        [Serializable]
        public class TokenKeys : PostKeysBase
        {
            /// <summary>
            /// utid
            /// </summary>
            public int utid;
            /// <summary>
            /// utid
            /// </summary>
            public int utp;
            /// <summary>
            /// utname
            /// </summary>
            public string utname;
            /// <summary>
            /// utid
            /// </summary>
            public string schid;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 续订token
        /// </summary>
        [Serializable]
        public class TokenUserKey : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 获取区域信息
        /// </summary>
        [Serializable]
        public class AreaKey : PostKeysBase
        {
            /// <summary>
            /// 取数据类型,0省份,1城市,2区县,3学校
            /// </summary>
            public string atp;
            /// <summary>
            /// 父节点代码
            /// </summary>
            public string pcode;
            /// <summary>
            /// 父节点代码
            /// </summary>
            public string utoken;
        }
        [Serializable]
        public class FascKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysFascList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<SysFascInfo> sysfasc;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysFascInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string fasccode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string fascname { get; set; }
        }
        [Serializable]
        public class ArtKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        [Serializable]
        public class WxAuthKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string shaketype;
            /// <summary>
            /// token
            /// </summary>
            public string wxid;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        [Serializable]
        public class WxUnKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string shaketype;
            /// <summary>
            /// token
            /// </summary>
            public string wxid;
            /// <summary>
            /// token
            /// </summary>
            public string uid;
            /// <summary>
            /// token
            /// </summary>
            public string utp;
            /// <summary>
            /// token
            /// </summary>
            public string mobile;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        [Serializable]
        public class WxMobileUserKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string wxid;
            /// <summary>
            /// token
            /// </summary>
            public string mobile;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysArtList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<SysArtInfo> sysarts;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysArtInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string artcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string artname { get; set; }
        }
        [Serializable]
        public class MaterKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysMaterList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<SysMaterInfo> sysmater;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysMaterInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string matercode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string matername { get; set; }
        }
        [Serializable]
        public class PerKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysPerList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<SysPerInfo> sysper;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysPerInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string percode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string pername { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class WxMobileUserList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<WxMobileUserInfo> wxmusers;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class WxMobileUserInfo
        {
            
            /// <summary>
            /// 
            /// </summary>
            public string uid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string uname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int utp { get; set; }            
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class UserStuList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<UserStuInfo> stus;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class UserStuInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public int schid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int stuid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string schname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string grdname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string clsname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string stuname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string lgname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int isfinish { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int sex { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int forid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string servid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int servstat { get; set; }
        }
        
        [Serializable]
        public class SysSubKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        [Serializable]
        public class SysGradeKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        [Serializable]
        public class UnvGradeKeys : PostKeysBase
        {
            /// <summary>
            /// gradeid
            /// </summary>
            public int gradeid;
            /// <summary>
            /// gradeyear
            /// </summary>
            public string gradeyear;
            /// <summary>
            /// gradecode
            /// </summary>
            public string gradecode;
            /// <summary>
            /// gradename
            /// </summary>
            public string gradename;
            /// <summary>
            /// schid
            /// </summary>
            public int schid;
            /// <summary>
            /// isfinish
            /// </summary>
            public int isfinish;
            /// <summary>
            /// collcode
            /// </summary>
            public string collcode;
            /// <summary>
            /// majorcode
            /// </summary>
            public string majorcode;
            /// <summary>
            /// dotype:e修改,a添加
            /// </summary>
            public string dotype;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        [Serializable]
        public class UnvClassKeys : PostKeysBase
        {
            /// <summary>
            /// classid
            /// </summary>
            public int classid;
            /// <summary>
            /// schid
            /// </summary>
            public int schid;
            /// <summary>
            /// gradeid
            /// </summary>
            public int gradeid;
            /// <summary>
            /// classno
            /// </summary>
            public string classno;
            /// <summary>
            /// classname
            /// </summary>
            public string classname;
            /// <summary>
            /// isfinish
            /// </summary>
            public int isfinish;            
            /// <summary>
            /// dotype:e修改,a添加
            /// </summary>
            public string dotype;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        [Serializable]
        public class SysCollKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        [Serializable]
        public class SysMajorKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        [Serializable]
        public class SysItemKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        [Serializable]
        public class SysBusKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public int bustp;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        [Serializable]
        public class SysFuncKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string fcodes;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        [Serializable]
        public class UserUstuKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public int utid;
            /// <summary>
            /// token
            /// </summary>
            public int forid;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        [Serializable]
        public class UserStuKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string uid;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        [Serializable]
        public class UnUserStuKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public int utid;
            /// <summary>
            /// token
            /// </summary>
            public int forid;
            /// <summary>
            /// token
            /// </summary>
            public int stuid;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        [Serializable]
        public class UpUserKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public int utid;
            /// <summary>
            /// type
            /// </summary>
            public string type;
            /// <summary>
            /// token
            /// </summary>
            public string val;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        [Serializable]
        public class UpTecKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public int utid;
            /// <summary>
            /// type
            /// </summary>
            public string type;
            /// <summary>
            /// token
            /// </summary>
            public string val;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        [Serializable]
        public class UpStuKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public int stuid;
            /// <summary>
            /// type
            /// </summary>
            public string type;
            /// <summary>
            /// token
            /// </summary>
            public string val;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        [Serializable]
        public class UserBusKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string uid;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class UserRefeeKeys : PostKeysBase
        {
            /// <summary>
            /// 续订用户
            /// </summary>
            public string uid;
            /// <summary>
            /// 续订套餐
            /// </summary>
            public string servid;
            /// <summary>
            /// 续订月数
            /// </summary>
            public int servm;
            /// <summary>
            /// 交费数
            /// </summary>
            public int feem;
            /// <summary>
            /// 备注
            /// </summary>
            public string dnote;
            /// <summary>
            /// 登记用户
            /// </summary>
            public string recutname;
            /// <summary>
            /// 来自订购类型
            /// </summary>
            public string frmtype;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class UserFeeKeys : PostKeysBase
        {
            /// <summary>
            /// 续订用户
            /// </summary>
            public string uid;
            /// <summary>
            /// 续订套餐
            /// </summary>
            public string servid;
            /// <summary>
            /// 续订月数
            /// </summary>
            public int servm;
            /// <summary>
            /// 交费数
            /// </summary>
            public int feem;
            /// <summary>
            /// 备注
            /// </summary>
            public string dnote;
            /// <summary>
            /// 登记用户
            /// </summary>
            public string recutname;
            /// <summary>
            /// 来自订购类型
            /// </summary>
            public string frmtype;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
            /// <summary>
            /// 该套餐订购的功能列表(json格式化的UserFeeFuncInfo列表)
            /// </summary>
            public List<UserFeeFuncInfo> funclist;

        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class UserFeeFuncInfo
        {
            /// <summary>
            /// 功能代码
            /// </summary>
            public string fcode;
            /// <summary>
            /// 栏目代码
            /// </summary>
            public string itemcode;
            /// <summary>
            /// 栏目所选节点
            /// </summary>
            public string itemsons;           

        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class UserFeeDetailKeys : PostKeysBase
        {
            /// <summary>
            /// 用户账号
            /// </summary>
            public string uid;
            /// <summary>
            /// 用户账号
            /// </summary>
            public string servid;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class UserRefuncKeys : PostKeysBase
        {
            /// <summary>
            /// 续订用户
            /// </summary>
            public int forid;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
            /// <summary>
            /// 该套餐订购的功能列表(json格式化的UserFeeFuncInfo列表)
            /// </summary>
            public string funclist;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysSubList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<SysSubInfo> syssub;
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysSubInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string subcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string subname { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysGradeList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<SysGradeInfo> sysgrd;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysGradeInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string grdcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string grdname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int grdpercode { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysCollList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<SysCollInfo> syscoll;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysCollInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string collcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string collname { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysMajorList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<SysMajorInfo> sysmajor;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysMajorInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string majorcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string majorname { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysItemList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<SysItemInfo> sysitem;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysItemInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string itemcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string itemname { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysUtypeList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<SysUtypeInfo> sysutype;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysUtypeInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string utypecode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string utypename { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysBusList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<SysBusInfo> sysbus;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysBusInfo
        {
            /// <summary>
            /// 套餐代码
            /// </summary>
            public string serviceid { get; set; }
            /// <summary>
            /// 费率
            /// </summary>
            public string feecode { get; set; }
            /// <summary>
            /// 套餐名称
            /// </summary>
            public string cnname { get; set; }
            /// <summary>
            /// 包含的功能串:多个用逗号隔开
            /// </summary>
            public string fcodes { get; set; }
            /// <summary>
            /// 持续月数
            /// </summary>
            public int busmonth { get; set; }
            /// <summary>
            /// 套餐类型:1基本套餐,2CP套餐
            /// </summary>
            public int bustype { get; set; }
            /// <summary>
            /// 功能描述
            /// </summary>
            public string busnote { get; set; }
            /// <summary>
            /// 备注
            /// </summary>
            public string note { get; set; }
            /// <summary>
            /// 套餐图片
            /// </summary>
            public string busimg { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysFuncList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<SysFuncInfo> sysfunc;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysFuncInfo
        {
            /// <summary>
            /// 功能ID
            /// </summary>
            public int fid { get; set; }
            /// <summary>
            /// 功能代码
            /// </summary>
            public string fcode { get; set; }
            /// <summary>
            /// 功能名称
            /// </summary>
            public string fname { get; set; }
            /// <summary>
            /// 范围说明
            /// </summary>
            public string frange { get; set; }
            /// <summary>
            /// 设置说明
            /// </summary>
            public string fset { get; set; }
            /// <summary>
            /// 功能备注
            /// </summary>
            public string fnote { get; set; }
            /// <summary>
            /// 功能描述
            /// </summary>
            public string fdes { get; set; }
            /// <summary>
            /// 功能扩展
            /// </summary>
            public List<SysFuncExtInfo> fext;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysFuncExtInfo
        {
            /// <summary>
            /// 栏目代码
            /// </summary>
            public string itemcode { get; set; }
            /// <summary>
            /// 栏目代码
            /// </summary>
            public string itemname { get; set; }
            /// <summary>
            /// 栏目子节点串
            /// </summary>
            public string itemsons { get; set; }
            /// <summary>
            /// 子节点选择个数
            /// </summary>
            public int itemsonsc { get; set; }

        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class ServFeeDetailList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<ServFeeDetailInfo> servdetail;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class ServFeeDetailInfo
        {
            /// <summary>
            /// 套餐代码
            /// </summary>
            public string servid { get; set; }
            /// <summary>
            /// 结束时间
            /// </summary>
            public string rectime { get; set; }
            /// <summary>
            /// 服务状态
            /// </summary>
            public int servm { get; set; }
            /// <summary>
            /// 服务状态
            /// </summary>
            public int feem { get; set; }

        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class UserBusList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<UserBusInfo> userbus;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class UserBusInfo
        {
            /// <summary>
            /// 定制ID
            /// </summary>
            public int forid { get; set; }
            /// <summary>
            /// 用户账号
            /// </summary>
            public string uid { get; set; }
            /// <summary>
            /// 用户名称
            /// </summary>
            public string utname { get; set; }
            /// <summary>
            /// 套餐代码
            /// </summary>
            public string servid { get; set; }
            /// <summary>
            /// 套餐类型
            /// </summary>
            public int servtype { get; set; }
            /// <summary>
            /// 套餐名称
            /// </summary>
            public string cname { get; set; }
            /// <summary>
            /// 包含功能集合
            /// </summary>
            public string fcodes { get; set; }
            /// <summary>
            /// 开始时间
            /// </summary>
            public string stime { get; set; }
            /// <summary>
            /// 结束时间
            /// </summary>
            public string etime { get; set; }
            /// <summary>
            /// 来自系统或第三方
            /// </summary>
            public int frmtype { get; set; }
            /// <summary>
            /// 服务状态
            /// </summary>
            public int serstat { get; set; }
            /// <summary>
            /// 已定制的功能扩展
            /// </summary>
            public List<UserBusExt> busext;

        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class UserBusExt
        {
            /// <summary>
            /// 定制ID
            /// </summary>
            public int forid { get; set; }
            /// <summary>
            /// 功能代码
            /// </summary>
            public string fcode { get; set; }
            /// <summary>
            /// 栏目代码
            /// </summary>
            public string itemcode { get; set; }
            /// <summary>
            /// 栏目代码对应集合
            /// </summary>
            public string itemsons { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class AppKeys : PostKeysBase
        {
            /// <summary>
            /// type xxt校讯通,soure资源
            /// </summary>
            public string type;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class AppList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<AppInfo> appsoure;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class AppInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string appsourecode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string appsourename { get; set; }
        }
        [Serializable]
        public class ClassNewsKeys : PostKeysBase
        {

            /// <summary>
            /// 展牌类型,根据blandtype传送不同的级别ID,班级牌传班级ID,年级牌传年级ID,学校牌传学校ID
            /// </summary>
            public int blandid;
            /// <summary>
            /// 展牌类型,0,班级牌,1年级牌,2,学校牌
            /// </summary>
            public int blandlv;
            /// <summary>
            /// 栏目代码
            /// </summary>
            public int chncode;
            /// <summary>
            /// 获取新闻级别类型,0本级别栏目文章,1向上获取文章类型(如班级,则获取对应年级及学校;如年级则获取年级及学校,学校则仅获取学校),2全获取(如班级,获取对应年级和班级的,年级获取底下班级及以上学校的,学校的,则获取所有的该学校的)
            /// </summary>
            public int newslv;
            /// <summary>
            /// 获取类型newstype 0文章标题列表,1图片(一标题一图片)
            /// </summary>
            public int newstype;
            /// <summary>
            /// type xxt校讯通,soure资源
            /// </summary>
            public int psize;
            /// <summary>
            /// type xxt校讯通,soure资源
            /// </summary>
            public int pindex;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class ClassNewsList
        {
            public string schname;
            public string gradename;
            public string classname;
            public string chname;
            public PageModel pg;
            /// <summary>
            /// 新闻列表
            /// </summary>
            public List<NewsInfo> newslist;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class NewsInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public int chncode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int chnid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int newsid { get; set; }
            
            /// <summary>
            /// 
            /// </summary>
            public string topic { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string rectime { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string imgurl { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string content { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int lv { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int istop { get; set; }
            /// <summary>
            /// 新闻列表
            /// </summary>
            public List<NewsEnc> newsenclist;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class NewsKeys : PostKeysBase
        {
            /// <summary>
            /// 班牌ID
            /// </summary>
            public int newsid;            
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        [Serializable]
        public class NewsEnc
        {
            /// <summary>
            /// 附件ID
            /// </summary>
            public int encid { get; set; }
            /// <summary>
            /// 对应新闻ID
            /// </summary>
            public int newsid { get; set; }
            /// <summary>
            /// 原文件名
            /// </summary>
            public string oldname { get; set; }
            /// <summary>
            /// 原图地址
            /// </summary>
            public string saveurl { get; set; }
            /// <summary>
            /// 缩略图地址
            /// </summary>
            public string imgurl { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SchInfoKeys : PostKeysBase
        {
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysAreaKeys : PostKeysBase
        {
            /// <summary>
            /// type
            /// </summary>
            public string areano;
            /// <summary>
            /// type
            /// </summary>
            public string type;
            /// <summary>
            /// token
            /// </summary>
            public string utoken;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysAreaList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<SysAreaInfo> sysarea;
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class SysAreaInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string acode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string aname { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int atype { get; set; }
        }
    }
}