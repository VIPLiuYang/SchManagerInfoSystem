using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchSystem.Model
{
    /// <summary>
    /// SysArts:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SysArts
    {
        public SysArts()
        { }
        #region Model
        private int _autoid;
        private string _artsname;
        private string _artscode;
        private int _stat = 1;
        /// <summary>
        /// 分科表
        /// </summary>
        public int AutoId
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 分科名称
        /// </summary>
        public string ArtsName
        {
            set { _artsname = value; }
            get { return _artsname; }
        }
        /// <summary>
        /// 分科代码
        /// </summary>
        public string ArtsCode
        {
            set { _artscode = value; }
            get { return _artscode; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int Stat
        {
            set { _stat = value; }
            get { return _stat; }
        }
        #endregion Model

    }
}
