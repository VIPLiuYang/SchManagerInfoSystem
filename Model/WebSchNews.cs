using System;
namespace SchSystem.Model
{
    /// <summary>
    /// WebSchNews:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class WebSchNews
    {
        public WebSchNews()
        { }
        #region Model
        private int _newsid;
        private int _schid;
        private int _chnid;
        private string _topic;
        private string _subtopic;
        private string _summas;
        private string _content;
        private string _recuser;
        private string _rectname;
        private DateTime _rectime;
        private string _recip;
        private int _stat = 1;
        private int _clicked = 0;
        private int _isquo = 0;
        private string _quourl;
        private string _keyword;
        private int _isreply = 1;
        private string _chkuser;
        private DateTime? _chktime;
        private string _chkip;
        private string _chktname;
        private int _istop = 0;
        private int _isenc = 0;
        private string _imgurl;
        private int _gradeid = 0;
        private int _classid = 0;
        private int _lv = 0;
        /// <summary>
        /// 学校新闻表
        /// </summary>
        public int NewsId
        {
            set { _newsid = value; }
            get { return _newsid; }
        }
        /// <summary>
        /// 单位id
        /// </summary>
        public int SchId
        {
            set { _schid = value; }
            get { return _schid; }
        }
        /// <summary>
        /// 频道ID
        /// </summary>
        public int ChnId
        {
            set { _chnid = value; }
            get { return _chnid; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Topic
        {
            set { _topic = value; }
            get { return _topic; }
        }
        /// <summary>
        /// 副标题
        /// </summary>
        public string SubTopic
        {
            set { _subtopic = value; }
            get { return _subtopic; }
        }
        /// <summary>
        /// 新闻描述
        /// </summary>
        public string Summas
        {
            set { _summas = value; }
            get { return _summas; }
        }
        /// <summary>
        /// 新闻内容
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 发布人登录名
        /// </summary>
        public string RecUser
        {
            set { _recuser = value; }
            get { return _recuser; }
        }
        /// <summary>
        /// 发布人真名
        /// </summary>
        public string RecTname
        {
            set { _rectname = value; }
            get { return _rectname; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime RecTime
        {
            set { _rectime = value; }
            get { return _rectime; }
        }
        /// <summary>
        /// 发布者IP
        /// </summary>
        public string RecIP
        {
            set { _recip = value; }
            get { return _recip; }
        }
        /// <summary>
        /// 状态,1显示,0屏蔽
        /// </summary>
        public int Stat
        {
            set { _stat = value; }
            get { return _stat; }
        }
        /// <summary>
        /// 点击量
        /// </summary>
        public int Clicked
        {
            set { _clicked = value; }
            get { return _clicked; }
        }
        /// <summary>
        /// 是否引用
        /// </summary>
        public int IsQuo
        {
            set { _isquo = value; }
            get { return _isquo; }
        }
        /// <summary>
        /// 引用地址
        /// </summary>
        public string QuoUrl
        {
            set { _quourl = value; }
            get { return _quourl; }
        }
        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWord
        {
            set { _keyword = value; }
            get { return _keyword; }
        }
        /// <summary>
        /// 是否允许回复
        /// </summary>
        public int IsReply
        {
            set { _isreply = value; }
            get { return _isreply; }
        }
        /// <summary>
        /// 审核人登录名
        /// </summary>
        public string ChkUser
        {
            set { _chkuser = value; }
            get { return _chkuser; }
        }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? ChkTime
        {
            set { _chktime = value; }
            get { return _chktime; }
        }
        /// <summary>
        /// 审核人IP
        /// </summary>
        public string ChkIP
        {
            set { _chkip = value; }
            get { return _chkip; }
        }
        /// <summary>
        /// 审核人姓名
        /// </summary>
        public string ChkTname
        {
            set { _chktname = value; }
            get { return _chktname; }
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
        /// 是否含有附件
        /// </summary>
        public int IsEnc
        {
            set { _isenc = value; }
            get { return _isenc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Imgurl
        {
            set { _imgurl = value; }
            get { return _imgurl; }
        }
        /// <summary>
        /// 年级ID
        /// </summary>
        public int GradeId
        {
            set { _gradeid = value; }
            get { return _gradeid; }
        }
        /// <summary>
        /// 班级ID,0为学校级
        /// </summary>
        public int ClassId
        {
            set { _classid = value; }
            get { return _classid; }
        }
        /// <summary>
        /// 新闻级别,0:班主任可发;1:年级主任可发;2:全校,授权可发
        /// </summary>
        public int Lv
        {
            set { _lv = value; }
            get { return _lv; }
        }
        #endregion Model

    }
}

