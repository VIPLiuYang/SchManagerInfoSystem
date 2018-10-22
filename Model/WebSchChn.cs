using System;
namespace SchSystem.Model
{
    /// <summary>
    /// WebSchChn:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class WebSchChn
    {
        public WebSchChn()
        { }
        #region Model
        private int _chnid;
        private int _pid;
        private int _schid;
        private string _chnname;
        private int _chncode;
        private int _orderid;
        private int _stat = 1;
        private int _istop;
        private string _note;
        private int _iswrite = 1;
        private int _isplc = 1;
        private string _recuser;
        private string _recname;
        private DateTime? _rectime;
        private string _recip;
        private int _islink = 0;
        private string _linkurl;
        /// <summary>
        /// 频道表
        /// </summary>
        public int ChnId
        {
            set { _chnid = value; }
            get { return _chnid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Pid
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 单位ID
        /// </summary>
        public int SchId
        {
            set { _schid = value; }
            get { return _schid; }
        }
        /// <summary>
        /// 频道名称
        /// </summary>
        public string ChnName
        {
            set { _chnname = value; }
            get { return _chnname; }
        }
        /// <summary>
        /// 频道代码
        /// </summary>
        public int ChnCode
        {
            set { _chncode = value; }
            get { return _chncode; }
        }
        /// <summary>
        /// 排序id
        /// </summary>
        public int OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 频道状态
        /// </summary>
        public int Stat
        {
            set { _stat = value; }
            get { return _stat; }
        }
        /// <summary>
        /// 是否置顶
        /// </summary>
        public int IsTop
        {
            set { _istop = value; }
            get { return _istop; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Note
        {
            set { _note = value; }
            get { return _note; }
        }
        /// <summary>
        /// 是否允许投稿
        /// </summary>
        public int IsWrite
        {
            set { _iswrite = value; }
            get { return _iswrite; }
        }
        /// <summary>
        /// 是否公开
        /// </summary>
        public int IsPlc
        {
            set { _isplc = value; }
            get { return _isplc; }
        }
        /// <summary>
        /// 添加人登录名
        /// </summary>
        public string RecUser
        {
            set { _recuser = value; }
            get { return _recuser; }
        }
        /// <summary>
        /// 添加人真名
        /// </summary>
        public string RecName
        {
            set { _recname = value; }
            get { return _recname; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? RecTime
        {
            set { _rectime = value; }
            get { return _rectime; }
        }
        /// <summary>
        /// 添加者IP
        /// </summary>
        public string RecIp
        {
            set { _recip = value; }
            get { return _recip; }
        }
        /// <summary>
        /// 是否为链接
        /// </summary>
        public int IsLink
        {
            set { _islink = value; }
            get { return _islink; }
        }
        /// <summary>
        /// 如果为链接,则链接的url为
        /// </summary>
        public string LinkUrl
        {
            set { _linkurl = value; }
            get { return _linkurl; }
        }
        #endregion Model

    }
}

