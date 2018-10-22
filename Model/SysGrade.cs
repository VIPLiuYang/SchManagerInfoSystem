using System;
namespace SchSystem.Model
{
    /// <summary>
    /// SysGrade:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SysGrade
    {
        public SysGrade()
        { }
        #region Model
        private int _autoid;
        private int _gradetype;
        private string _gradetypename;
        private string _gradename;
        private int _gradelv;
        private string _gradelvname;
        private string _gradecode;
        /// <summary>
        /// 系统年级表
        /// </summary>
        public int AutoId
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 年级类型,1幼儿园,2小学,3初中,4高中
        /// </summary>
        public int GradeType
        {
            set { _gradetype = value; }
            get { return _gradetype; }
        }
        /// <summary>
        /// 年级类型名称
        /// </summary>
        public string GradeTypeName
        {
            set { _gradetypename = value; }
            get { return _gradetypename; }
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
        /// 年级级别
        /// </summary>
        public int GradeLv
        {
            set { _gradelv = value; }
            get { return _gradelv; }
        }
        /// <summary>
        /// 年级级别名称
        /// </summary>
        public string GradeLvName
        {
            set { _gradelvname = value; }
            get { return _gradelvname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GradeCode
        {
            set { _gradecode = value; }
            get { return _gradecode; }
        }
        #endregion Model

    }
}

