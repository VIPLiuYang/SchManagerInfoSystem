using System;
namespace SchSystem.Model
{
    /// <summary>
    /// ServUserUstu:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ServUserUstu
    {
        public ServUserUstu()
        { }
        #region Model
        private int _autoid;
        private int _stuid;
        private int _forid;
        private int _servuserid;
        /// <summary>
        /// 注册用户与学生关联表
        /// </summary>
        public int AutoId
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 学生ID
        /// </summary>
        public int StuId
        {
            set { _stuid = value; }
            get { return _stuid; }
        }
        /// <summary>
        /// 订购记录ID
        /// </summary>
        public int ForId
        {
            set { _forid = value; }
            get { return _forid; }
        }
        /// <summary>
        /// 注册用户ID
        /// </summary>
        public int ServUserId
        {
            set { _servuserid = value; }
            get { return _servuserid; }
        }
        #endregion Model

    }
}

