using System;
namespace SchSystem.Model
{
    /// <summary>
    /// SchInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SchInfo
    {
        public SchInfo()
        { }
        #region Model
        private int _schid;
        private string _schno;
        private string _schname;
        private int? _schtype;
        private string _areano;
        private string _schmaster;
        private string _masterpostion;
        private int? _schyear;
        private string _schaddr;
        private string _schtel;
        private int? _schlv;
        private int _iscity = 1;
        private string _artisan;
        private string _principalname;
        private string _principaltel;
        private string _servicename;
        private string _servicetel;
        private string _platformname;
        private string _platformico;
        private string _platformurl;
        private string _platformip;
        private string _schnote;
        private int _stat;
        private DateTime _rectime;
        private string _recuser;
        private DateTime? _lastrectime;
        private string _lastrecuser;
        private int? _sonsysstat = 0;
        private int _openmonth=8;
        private string _resourceplatformname;
        private string _resourceplatformico;
        private string _resourceplatformurl;
        private string _resourceplatformip;
        private string _schoolsection;
        private string _schcreator;
        private DateTime _schsonsysenddtetime;
        private DateTime _schsonsysenabletime;
        private DateTime _schsnsyscreatetme;
        private string _manageracount;
        private int _sourceserstat;
        private string _initialpwd;
        private string _issonarrears;
        private DateTime _sourcesrendtime;

        public int IsAlone { get; set; } //单独部署状态,0集体部署,1单独部署
        public DateTime AloneTime { get; set; } //独立部署操作时间
        public string AloneUser { get; set; } //独立部署操作人

        //家校互通平台属性
        private int _homeschservstat;
        /// <summary>
        /// 家校互通服务状态
        /// </summary>
        public int HomeschServStat
        {
            get { return _homeschservstat; }
            set { _homeschservstat = value; }
        }
        private int _homeschbasicuser;
        /// <summary>
        /// 家校互通基础维护人
        /// </summary>
        public int HomeSchBasicStat
        {
            get { return _homeschbasicuser; }
            set { _homeschbasicuser = value; }
        }
        private string _homeschplatname;

        public string HomeSchPlatName
        {
            get { return _homeschplatname; }
            set { _homeschplatname = value; }
        }
        private string _homeschplatico;

        public string HomeSchPlatIco
        {
            get { return _homeschplatico; }
            set { _homeschplatico = value; }
        }
        private string _homeschplaturl;

        public string HomeSchPlatUrl
        {
            get { return _homeschplaturl; }
            set { _homeschplaturl = value; }
        }
        private string _homeschplatip;

        public string HomeSchPlatIP
        {
            get { return _homeschplatip; }
            set { _homeschplatip = value; }
        }
        private DateTime _homeschcreatetime;

        public DateTime HomeSchCreateTime
        {
            get { return _homeschcreatetime; }
            set { _homeschcreatetime = value; }
        }
        private DateTime _homeschenabletime;

        public DateTime HomeSchEnableTime
        {
            get { return _homeschenabletime; }
            set { _homeschenabletime = value; }
        }
        private DateTime _homeschendtime;

        public DateTime HomeSchEndTime
        {
            get { return _homeschendtime; }
            set { _homeschendtime = value; }
        }
        
        /// <summary>
        /// 学校信息表,区域代码+4位顺序码
        /// </summary>
        public int SchId
        {
            set { _schid = value; }
            get { return _schid; }
        }
        /// <summary>
        /// 学校代码
        /// </summary>
        public string SchNo
        {
            set { _schno = value; }
            get { return _schno; }
        }
        /// <summary>
        /// 学校名称
        /// </summary>
        public string SchName
        {
            set { _schname = value; }
            get { return _schname; }
        }
        /// <summary>
        /// 学校类型:学校类型表代码
        /// </summary>
        public int? SchType
        {
            set { _schtype = value; }
            get { return _schtype; }
        }
        /// <summary>
        /// 区域编码,此决定学校所在区域等级,省级市级或者区县级
        /// </summary>
        public string AreaNo
        {
            set { _areano = value; }
            get { return _areano; }
        }
        /// <summary>
        /// 学校联系人
        /// </summary>
        public string SchMaster
        {
            set { _schmaster = value; }
            get { return _schmaster; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MasterPostion
        {
            set { _masterpostion = value; }
            get { return _masterpostion; }
        }
        /// <summary>
        /// 学年制
        /// </summary>
        public int? SchYear
        {
            set { _schyear = value; }
            get { return _schyear; }
        }
        /// <summary>
        /// 学校地址
        /// </summary>
        public string SchAddr
        {
            set { _schaddr = value; }
            get { return _schaddr; }
        }
        /// <summary>
        /// 学校联系电话
        /// </summary>
        public string SchTel
        {
            set { _schtel = value; }
            get { return _schtel; }
        }
        /// <summary>
        /// 学校类型:0普通学校,1教育局
        /// </summary>
        public int? SchLv
        {
            set { _schlv = value; }
            get { return _schlv; }
        }
        /// <summary>
        /// 是否为城区学校,1是,0否,2未知
        /// </summary>
        public int IsCity
        {
            set { _iscity = value; }
            get { return _iscity; }
        }
        /// <summary>
        /// 一线技术人员
        /// </summary>
        public string Artisan
        {
            set { _artisan = value; }
            get { return _artisan; }
        }
        /// <summary>
        /// 校长姓名
        /// </summary>
        public string PrincipalName
        {
            set { _principalname = value; }
            get { return _principalname; }
        }
        /// <summary>
        /// 校长手机
        /// </summary>
        public string PrincipalTel
        {
            set { _principaltel = value; }
            get { return _principaltel; }
        }
        /// <summary>
        /// 客服人员姓名
        /// </summary>
        public string ServiceName
        {
            set { _servicename = value; }
            get { return _servicename; }
        }
        /// <summary>
        /// 客服人员电话
        /// </summary>
        public string ServiceTel
        {
            set { _servicetel = value; }
            get { return _servicetel; }
        }
        /// <summary>
        /// 管理平台名称
        /// </summary>
        public string PlatformName
        {
            set { _platformname = value; }
            get { return _platformname; }
        }
        /// <summary>
        /// 管理平台图标
        /// </summary>
        public string PlatformIco
        {
            set { _platformico = value; }
            get { return _platformico; }
        }
        /// <summary>
        /// 管理平台地址
        /// </summary>
        public string PlatformUrl
        {
            set { _platformurl = value; }
            get { return _platformurl; }
        }
        /// <summary>
        /// 管理平台IP地址
        /// </summary>
        public string PlatformIP
        {
            set { _platformip = value; }
            get { return _platformip; }
        }
        /// <summary>
        /// 其他说明
        /// </summary>
        public string SchNote
        {
            set { _schnote = value; }
            get { return _schnote; }
        }
        /// <summary>
        /// 状态,0废弃,1正常
        /// </summary>
        public int Stat
        {
            set { _stat = value; }
            get { return _stat; }
        }
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime RecTime
        {
            set { _rectime = value; }
            get { return _rectime; }
        }
        /// <summary>
        /// 记录者
        /// </summary>
        public string RecUser
        {
            set { _recuser = value; }
            get { return _recuser; }
        }
        /// <summary>
        /// 最后编辑时间
        /// </summary>
        public DateTime? LastRecTime
        {
            set { _lastrectime = value; }
            get { return _lastrectime; }
        }
        /// <summary>
        /// 最后编辑人
        /// </summary>
        public string LastRecUser
        {
            set { _lastrecuser = value; }
            get { return _lastrecuser; }
        }
        /// <summary>
        /// 子系统状态：0代表正常，1代表停用，2代表删除
        /// </summary>
        public int? SonSysStat
        {
            set { _sonsysstat = value; }
            get { return _sonsysstat; }
        }
        /// <summary>
        /// 资源平台名称
        /// </summary>
        public string ResourcePlatformName
        {
            set { _resourceplatformname = value; }
            get { return _resourceplatformname; }
        }
        /// <summary>
        /// 资源平台图标
        /// </summary>
        public string ResourcePlatformIco
        {
            set { _resourceplatformico = value; }
            get { return _resourceplatformico; }
        }
        /// <summary>
        /// 资源平台域名
        /// </summary>
        public string ResourcePlatformUrl
        {
            set { _resourceplatformurl = value; }
            get { return _resourceplatformurl; }
        }
        /// <summary>
        /// 资源平台IP
        /// </summary>
        public string ResourcePlatformIP
        {
            set { _resourceplatformip = value; }
            get { return _resourceplatformip; }
        }
        /// <summary>
        /// 学段：1代表幼儿园；2代表小学；3代表初中；4代表高中
        /// </summary>
        public string SchoolSection
        {
            set { _schoolsection = value; }
            get { return _schoolsection; }
        }
        public string SchCreator
        {
            set { _schcreator = value; }
            get { return _schcreator; }
        }
        public DateTime SchSonSysEndDateTime
        {
            set { _schsonsysenddtetime = value; }
            get { return _schsonsysenddtetime; }
        }
        public DateTime SchSonSysEnableTime
        {
            set { _schsonsysenabletime = value; }
            get { return _schsonsysenabletime; }
        }
        public DateTime SchSonSysCreateTime
        {
            set { _schsnsyscreatetme = value; }
            get { return _schsnsyscreatetme; }
        }
        public int SourceSerStat
        {
            get { return _sourceserstat; }
            set { _sourceserstat = value; }
        }

        public string Manageracount
        {
            get { return _manageracount; }
            set { _manageracount = value; }
        }


        public string Initialpwd
        {
            get { return _initialpwd; }
            set { _initialpwd = value; }
        }


        public string IsSonArrears
        {
            get { return _issonarrears; }
            set { _issonarrears = value; }
        }


        public DateTime Sourcesrendtime
        {
            get { return _sourcesrendtime; }
            set { _sourcesrendtime = value; }
        }
        /// <summary>
        /// 开学月份
        /// </summary>
        public int OpenMonth
        {
            set { _openmonth = value; }
            get { return _openmonth; }
        }
        #endregion Model

    }
}

