using RedisStudy;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace SchWebApi.Com
{
    public class Public
    {
        public static string RandCode(string uid, string shaketype)
        {
            Random rm = new Random();
            //发送验证码通知短信
            string code = Convert.ToString(rm.Next(100000, 999999));

            string sk = "";
            if (shaketype == "reg")
            {
                sk = "注册";
            }
            else if (shaketype == "login")
            {
                sk = "登录";
            }
            else if (shaketype == "repw")
            {
                sk = "修改密码";
            }
            else if (shaketype == "bind")
            {
                sk = "绑定手机";
            }
            string msgc = sk + "验证码:" + code + "(" + DateTime.Now.ToString("HH:mm") + "有效期5分钟,请勿泄露)【智慧校园】";
            SendSms(uid, msgc);
            //JBCloud.BLL.AppSms appsmsbll = new JBCloud.BLL.AppSms();
            //JBCloud.Model.AppSms appmodel = new JBCloud.Model.AppSms();
            //appmodel.FEEMOBILE = uid;
            //appmodel.FROM_PRO = "ACloud";
            //appmodel.MSG_CONTENT = msgc;
            //appmodel.MSG_LEVEL = 1;
            //appsmsbll.Add(appmodel);
            return code;
            //发送验证码,待定
            //return "123456";
        }
        public static void SendSmsMs(string mobiles, string content)
        {
            //分发数据
            //移动号码段
            string[] cmcc = ConfigurationManager.AppSettings["Cmcc"].Split(',');
            //联通号码段
            string[] umcc = ConfigurationManager.AppSettings["Umcc"].Split(',');
            string sendsql = "";
            string[] mobileg = SqlEncStr(mobiles).Split(',');
            foreach (var item in mobileg)
            {
                string sendm="";
                //判断是联通还是移动
                string mbth = item.Substring(0, 3);
                string mbf = item.Substring(0, 4);
                sendm = " insert into JSY_WSMS(SMSID,DESTADDR,MESSAGE,PRIORTY,FROM_PRO) values(0,'" + item + "','" + SqlEncStr(content) + "【智慧校园】',1,'Asch') ";
                if (Array.IndexOf(cmcc, mbth) > -1 || Array.IndexOf(cmcc, mbf) > -1)
                {
                    sendm = " insert into JSY_WSMSYD(SMSID,DESTADDR,MESSAGE,PRIORTY,FROM_PRO) values(0,'" + item + "','" + SqlEncStr(content) + "【智慧校园】',1,'Asch') ";
                }
                sendsql += sendm;
            }
            
            ExecuteSql(sendsql);
        }
        public static void SendSms(string mobile, string content)
        {
            //分发数据
            //移动号码段
            string[] cmcc = ConfigurationManager.AppSettings["Cmcc"].Split(',');
            //联通号码段
            string[] umcc = ConfigurationManager.AppSettings["Umcc"].Split(',');
            //判断是联通还是移动
            string mbth = mobile.Substring(0, 3);
            string mbf = mobile.Substring(0, 4);
            string sendsql = "insert into JSY_WSMS(SMSID,DESTADDR,MESSAGE,PRIORTY,FROM_PRO) values(0,'" + mobile + "','" + content + "',1,'Asch')";
            if (Array.IndexOf(cmcc, mbth) > -1 || Array.IndexOf(cmcc, mbf) > -1)
            {
                sendsql = "insert into JSY_WSMSYD(SMSID,DESTADDR,MESSAGE,PRIORTY,FROM_PRO) values(0,'" + mobile + "','" + content + "',1,'Asch')";
            }
            ExecuteSql(sendsql);
        }
        public static int ExecuteSql(string SQLString)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["APPSMS"].ToString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }
        public static string DoSms(string msg,string mobile)
        {
            //分发数据
            //移动号码段
            string[] cmcc = ConfigurationManager.AppSettings["Cmcc"].Split(',');
            //联通号码段
            string[] umcc = ConfigurationManager.AppSettings["Umcc"].Split(',');
            //判断是联通还是移动
            string mbth = mobile.Substring(0, 3);
            string mbf = mobile.Substring(0, 4);
            string sendsql = "insert into JSY_WSMS(SMSID,DESTADDR,MESSAGE,PRIORTY,FROM_PRO) values(0,'" + mobile + "','" + msg + "',1,'ACloud')";
            if (Array.IndexOf(cmcc, mbth) > -1 || Array.IndexOf(cmcc, mbf) > -1)
            {
                sendsql = "insert into JSY_WSMSYD(SMSID,DESTADDR,MESSAGE,PRIORTY,FROM_PRO) values(0,'" + mobile + "','" + msg + "',1,'ACloud')";
            }
            ExecuteSql(sendsql);
            return "";
        }
        //SQL注入过滤
        public static string SqlEncStr(string inputString)
        {
            //要替换的敏感字
            string SqlStr = @"and|or|exec|execute|insert|select|delete|update|alter|create|drop|count|\*|chr|char|asc|mid|substring|master|truncate|declare|xp_cmdshell|restore|backup|net +user|net +localgroup +administrators";
            try
            {
                if ((inputString != null) && (inputString != String.Empty))
                {
                    string str_Regex = @"\b(" + SqlStr + @")\b";

                    Regex Regex = new Regex(str_Regex, RegexOptions.IgnoreCase);
                    //string s = Regex.Match(inputString).Value; 
                    MatchCollection matches = Regex.Matches(inputString);
                    for (int i = 0; i < matches.Count; i++)
                        inputString = inputString.Replace(matches[i].Value, "[" + matches[i].Value + "]");

                }
            }
            catch
            {
                return "";
            }
            return inputString;

        }
        //合并用户权限串,dt为角色表集
        public static string UserRoleStr(DataTable dt,string col)
        {
            //先生成一个4000字长的字符串
            string rolestr = "";
            for (int i = 0; i < 4000; i++)
            {
                bool iok = false;
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        iok = IsOne(dr[col].ToString(), i + 1);
                        if (iok) break;
                    }
                }
                rolestr += Convert.ToInt32(iok).ToString();
            }
            return rolestr;
        }
        //字符串对应位置处是否为1
        public static bool IsOne(string str, int i)
        {
            bool isok = false;
            if (str.Length > i - 1)
            {
                string istr = str.Substring(i - 1, 1);
                if (istr == "1")
                {
                    isok = true;
                }
            }
            return isok;
        }
        public static List<T> DataTableToList<T>(DataTable dt) where T : class,new()
        {
            // 定义集合 
            List<T> ts = new List<T>();
            //定义一个临时变量 
            string tempName = string.Empty;
            //遍历DataTable中所有的数据行 
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                // 获得此模型的公共属性 
                PropertyInfo[] propertys = t.GetType().GetProperties();
                //遍历该对象的所有属性 
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;//将属性名称赋值给临时变量 
                    //检查DataTable是否包含此列（列名==对象的属性名）  
                    if (dt.Columns.Contains(tempName))
                    {
                        //取值 
                        object value = dr[tempName];
                        //如果非空，则赋给对象的属性 
                        if (value != DBNull.Value)
                        {
                            pi.SetValue(t, value, null);
                        }
                    }
                }
                //对象添加到泛型集合中 
                ts.Add(t);
            }
            return ts;
        }
        public static bool IsNum(string str)
        {
            return Regex.IsMatch(str, "^[0-9]*$");
        }
        /// <summary>
        /// 移除hash中的某值
        /// </summary>
        public static bool RemoveHashKey(string hashId, string key)
        {
            HashOperator operators = new HashOperator();
            bool results = operators.Remove(hashId, key);
            operators.Dispose();
            return results;

        }
        //记录登录信息和更新相应的用户登录次数和时间等
        public static void LoginRec(string appid, string utid, string uip, string uuid)
        {


        }
        public static string BytesToHexString(byte[] input)
        {
            StringBuilder hexString = new StringBuilder(64);

            for (int i = 0; i < input.Length; i++)
            {
                hexString.Append(String.Format("{0:X2}", input[i]));
            }
            return hexString.ToString();
        }

        public static byte[] HexStringToBytes(string hex)
        {
            if (hex.Length == 0)
            {
                return new byte[] { 0 };
            }

            if (hex.Length % 2 == 1)
            {
                hex = "0" + hex;
            }

            byte[] result = new byte[hex.Length / 2];

            for (int i = 0; i < hex.Length / 2; i++)
            {
                result[i] = byte.Parse(hex.Substring(2 * i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }

            return result;
        }

        /// <summary>
        /// 判断某个数据是否已经被缓存
        /// </summary>
        public static bool ExistKeyHash(string hashId, string key)
        {
            HashOperator operators = new HashOperator();
            bool results = operators.Exist<string>(hashId, key);
            operators.Dispose();
            return results;
        }

        public static bool SetCacheKeyHash(string hashid, string Key, string Value, DateTime expiretime)
        {
            HashOperator operators = new HashOperator();
            bool results = operators.Set<string>(hashid, Key, Value);
            operators.Dispose();
            return results;
        }

        public static string GetCacheKey(string Key)
        {
            IRedisClient Redis = RedisManager.GetClient();
            string keyvalue = Redis.Get<string>(Key);
            Redis.Dispose();
            return keyvalue;
        }

        public static bool SetCacheKey(string Key, string Value, DateTime expiretime)
        {
            IRedisClient Redis = RedisManager.GetClient();
            bool bok = Redis.Set<string>(Key, Value, expiretime);
            Redis.Dispose();
            return bok;
        }

        public static bool SetCacheKeyExp(string Key, DateTime expiretime)
        {
            IRedisClient Redis = RedisManager.GetClient();
            bool bok = Redis.ExpireEntryAt(Key, expiretime);
            Redis.Dispose();
            return bok;
        }
        public static bool RemoveCacheKey(string Key)
        {
            IRedisClient Redis = RedisManager.GetClient();
            bool bok = Redis.Remove(Key);
            Redis.Dispose();
            return bok;
        }

        public static bool VerifyToken(string token)
        {
            bool bok = false;
            string tokenvalue = GetCacheKey(token);
            if (!string.IsNullOrEmpty(tokenvalue))
            {
                bok = true;
            }
            return bok;
        }
        //url签名算法
        public static string UrlSign(string urls, string key)
        {
            string rstr = "";
            try
            {
                byte[] SecretKey = Encoding.UTF8.GetBytes(key);
                HMACSHA1 hmac = new HMACSHA1(SecretKey);
                //urls="a=0&b=4&c=9";参数顺序排列组合
                byte[] digest = hmac.ComputeHash(Encoding.UTF8.GetBytes(urls));
                rstr = Convert.ToBase64String(digest);
            }
            catch (Exception ex)
            {
                throw;
            }
            return rstr;
        }
        public static bool VerifyUrl(string[] keys, string sign)
        {
            bool bok = false;
            try
            {
                byte[] SecretKey = Encoding.UTF8.GetBytes(GetKey("SignKey"));
                //IEnumerable<String> query = keys.OrderBy(x => x);
                //string urlbody = string.Join("&", query.ToArray<string>());
                Array.Sort(keys, new OrdinalComparer());
                string urlbody = string.Join("&", keys);
                //用秘钥生成摘要
                HMACSHA1 hmac = new HMACSHA1(SecretKey);
                byte[] digest = hmac.ComputeHash(Encoding.UTF8.GetBytes(urlbody));
                string apisign = Convert.ToBase64String(digest);
                if (apisign == sign)
                {
                    bok = true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return bok;

        }
        public class OrdinalComparer : System.Collections.Generic.IComparer<String>
        {
            public int Compare(String x, String y)
            {
                return string.CompareOrdinal(x, y);
            }
        }
        public static string SignStr(string SourStr, string key)
        {
            byte[] SecretKey = Encoding.UTF8.GetBytes(key);
            //用秘钥生成摘要d
            HMACSHA1 hmac = new HMACSHA1(SecretKey);
            byte[] digest = hmac.ComputeHash(Encoding.UTF8.GetBytes(SourStr));
            return Convert.ToBase64String(digest);
        }
        //令牌创建,每个令牌周期算一次登录
        public static string MadeToken(string SignStr, string utid)
        {
            //更新登录次数

            byte[] SecretKey = Encoding.UTF8.GetBytes(GetKey("TokenKey"));
            //用秘钥生成摘要
            HMACSHA1 hmac = new HMACSHA1(SecretKey);
            byte[] digest = hmac.ComputeHash(Encoding.UTF8.GetBytes(SignStr + GenerateNonceStr()));
            //进行64位编码
            return Convert.ToBase64String(digest);
        }
        public static string GenerateNonceStr()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
        public static string GetKey(string Key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[Key];
        }
        public static string StringToMD5Hash(string inputString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encryptedBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(inputString));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                sb.AppendFormat("{0:x2}", encryptedBytes[i]);
            }
            return sb.ToString();
        }
        public static string StrToMD5(string str)
        {
            str = str + GetKey("SecretKey");
            byte[] data = Encoding.UTF8.GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] OutBytes = md5.ComputeHash(data);
            string OutString = "";
            for (int i = 0; i < OutBytes.Length; i++)
            {
                OutString += OutBytes[i].ToString("x2");
            }
            // return OutString.ToUpper();
            return OutString.ToLower();
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Encrypt(string Text)
        {
            return Encrypt(Text, GetKey("SecretKey"));
        }
        /// <summary> 
        /// 加密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Encrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(Text);
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }


        #region ========解密========


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Decrypt(string Text)
        {
            return Decrypt(Text, GetKey("SecretKey"));
        }
        /// <summary> 
        /// 解密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Decrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = Text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }

        #endregion
        //日志路径
        public static string path = HttpContext.Current.Request.PhysicalApplicationPath + "logs";
        //写日志
        public static void WriteLog(string type, string className, string content)
        {
            if (!Directory.Exists(path))//如果日志目录不存在就创建
            {
                Directory.CreateDirectory(path);
            }

            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");//获取当前系统时间
            string filename = path + "/" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";//用日期对日志文件命名

            //向日志文件写入内容
            string write_content = time + " " + type + " " + className + ": \r\n" + content;
            FileStream fs = null;
            try
            {
                //if (SourceAddress.ToString() == "60.28.196.5" || DestinationAddress.ToString() == "60.28.196.5")
                //{
                fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.Write);
                //(Filename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                byte[] filebyte = Encoding.Default.GetBytes(write_content + "\r\n_______________________________________\r\n\r\n");
                fs.Write(filebyte, 0, filebyte.Length);
                fs.Flush();
                //}
            }
            catch
            {

            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }
    }
}