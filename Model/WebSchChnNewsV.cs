using System;
namespace SchSystem.Model
{
    /// <summary>
    /// WebSchChnNewsV:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class WebSchChnNewsV
    {
        public WebSchChnNewsV()
        { }
        #region Model
        private string _chnname;
        private int _chnid;
        private string _topic;
        private DateTime _rectime;
        private int _stat;
        private int _schid;
        private int _newsid;
        private int _lv;
        private int _classid;
        private int _gradeid;
        private int _isreply;
        private int _isquo;
        private string _quourl;
        private string _content;
        private int _istop;
        /// <summary>
        /// 
        /// </summary>
        public string ChnName
        {
            set { _chnname = value; }
            get { return _chnname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ChnId
        {
            set { _chnid = value; }
            get { return _chnid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Topic
        {
            set { _topic = value; }
            get { return _topic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime RecTime
        {
            set { _rectime = value; }
            get { return _rectime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Stat
        {
            set { _stat = value; }
            get { return _stat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SchId
        {
            set { _schid = value; }
            get { return _schid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int NewsId
        {
            set { _newsid = value; }
            get { return _newsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Lv
        {
            set { _lv = value; }
            get { return _lv; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ClassId
        {
            set { _classid = value; }
            get { return _classid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int GradeId
        {
            set { _gradeid = value; }
            get { return _gradeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsReply
        {
            set { _isreply = value; }
            get { return _isreply; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsQuo
        {
            set { _isquo = value; }
            get { return _isquo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QuoUrl
        {
            set { _quourl = value; }
            get { return _quourl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsTop
        {
            set { _istop = value; }
            get { return _istop; }
        }
        #endregion Model

    }
}

