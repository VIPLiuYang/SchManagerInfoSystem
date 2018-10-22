using System;
namespace SchSystem.Model
{
    /// <summary>
    /// SchGradeInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SchGradeInfo
    {
        public SchGradeInfo()
        { }
        #region Model
        private int _gradeid;
        private string _gradeyear;
        private string _gradecode;
        private string _gradename;
        private int _schid;
        private int _isfinish = 0;
        private DateTime? _rectime;
        private string _recuser;
        private DateTime? _lastrectime;
        private string _lastrecuser;
        private string _collcode;
        private string _majorcode;
        /// <summary>
        /// 年级表,年级ID
        /// </summary>
        public int GradeId
        {
            set { _gradeid = value; }
            get { return _gradeid; }
        }
        /// <summary>
        /// 年级入学年份
        /// </summary>
        public string GradeYear
        {
            set { _gradeyear = value; }
            get { return _gradeyear; }
        }
        /// <summary>
        /// 系统年级代码
        /// </summary>
        public string GradeCode
        {
            set { _gradecode = value; }
            get { return _gradecode; }
        }
        /// <summary>
        /// 年级名称
        /// </summary>
        public string GradeName
        {
            set { _gradename = value; }
            get { return _gradename; }
        }
        /// <summary>
        /// 学校ID
        /// </summary>
        public int SchId
        {
            set { _schid = value; }
            get { return _schid; }
        }
        /// <summary>
        /// 是否已毕业,1毕业,0为毕业
        /// </summary>
        public int IsFinish
        {
            set { _isfinish = value; }
            get { return _isfinish; }
        }
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime? RecTime
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
        /// 院系代码
        /// </summary>
        public string CollCode
        {
            set { _collcode = value; }
            get { return _collcode; }
        }
        /// <summary>
        /// 专业代码
        /// </summary>
        public string MajorCode
        {
            set { _majorcode = value; }
            get { return _majorcode; }
        }
        #endregion Model

    }
}

