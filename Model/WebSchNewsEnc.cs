using System;
namespace SchSystem.Model
{
    /// <summary>
    /// WebSchNewsEnc:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class WebSchNewsEnc
    {
        public WebSchNewsEnc()
        { }
        #region Model
        private int _encid;
        private int _newsid;
        private string _oldname;
        private string _newname;
        private string _saveurl;
        private int _clicked;
        private DateTime? _rectime;
        private string _recip;
        private int _filesize;
        private string _imgurl;
        /// <summary>
        /// 学校新闻附件表
        /// </summary>
        public int EncId
        {
            set { _encid = value; }
            get { return _encid; }
        }
        /// <summary>
        /// 新闻ID
        /// </summary>
        public int NewsId
        {
            set { _newsid = value; }
            get { return _newsid; }
        }
        /// <summary>
        /// 原文件名
        /// </summary>
        public string OldName
        {
            set { _oldname = value; }
            get { return _oldname; }
        }
        /// <summary>
        /// 新文件名
        /// </summary>
        public string NewName
        {
            set { _newname = value; }
            get { return _newname; }
        }
        /// <summary>
        /// 保存地址
        /// </summary>
        public string SaveUrl
        {
            set { _saveurl = value; }
            get { return _saveurl; }
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
        /// 上传时间
        /// </summary>
        public DateTime? RecTime
        {
            set { _rectime = value; }
            get { return _rectime; }
        }
        /// <summary>
        /// 上传IP
        /// </summary>
        public string RecIP
        {
            set { _recip = value; }
            get { return _recip; }
        }
        /// <summary>
        /// 文件大小
        /// </summary>
        public int FileSize
        {
            set { _filesize = value; }
            get { return _filesize; }
        }
        /// <summary>
        /// 缩略图地址
        /// </summary>
        public string ImgUrl
        {
            set { _imgurl = value; }
            get { return _imgurl; }
        }
        #endregion Model

    }
}

