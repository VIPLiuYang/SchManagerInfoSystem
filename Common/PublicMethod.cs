using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace Common
{
    public class PublicMethod:IRequiresSessionState
    {
        public PublicMethod()
        {

        }
        private static HttpSessionState _session = HttpContext.Current.Session;
        /// <summary>
        /// 判断session是否存在
        /// </summary>
        /// <returns></returns>
        public static bool IsLoginExists()
        {
            if (_session == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 设置Session
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetSession(string key, object value)
        {
            _session[key] = value;
        }
        /// <summary>
        /// 获取session
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetSessionNumber(string key)
        {
            int result = 0;
            if (_session[key] != null)
            {
                int.TryParse(_session[key].ToString(), out result);
            }
            return result;
        }
        /// <summary>
        /// 设置session
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSessionString(string key)
        {
            string result = "";
            if (_session[key] != null)
            {
                result = _session[key].ToString();
            }
            return result;
        }
        /// <summary>
        /// 清除session
        /// </summary>
        public static void Clear()
        {
            _session.Clear();
        }
    }
}
