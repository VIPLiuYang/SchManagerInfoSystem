using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Redis;

namespace RedisStudy
{
    /// <summary>
    /// RedisManager类主要是创建链接池管理对象的
    /// </summary>
    public class RedisManager
    {
        /// <summary>
        /// redis配置文件信息
        /// </summary>
        private static string RedisPath = System.Configuration.ConfigurationManager.AppSettings["RedisPath"];
        private static int RedisDb = int.Parse(System.Configuration.ConfigurationManager.AppSettings["RedisDb"]);
        private static PooledRedisClientManager _prcm;
        
        /// <summary>
        /// 静态构造方法，初始化链接池管理对象
        /// </summary>
        static RedisManager()
        {
            CreateManager();
        }

        /// <summary>
        /// 创建链接池管理对象
        /// </summary>
        private static void CreateManager()
        {
            _prcm = CreateManager(new string[] { RedisPath }, new string[] { RedisPath });
        }


        private static PooledRedisClientManager CreateManager(string[] readWriteHosts, string[] readOnlyHosts)
        {
            //WriteServerList：可写的Redis链接地址。
            //ReadServerList：可读的Redis链接地址。
            //MaxWritePoolSize：最大写链接数。
            //MaxReadPoolSize：最大读链接数。
            //AutoStart：自动重启。
            //LocalCacheTime：本地缓存到期时间，单位:秒。
            //RecordeLog：是否记录日志,该设置仅用于排查redis运行时出现的问题,如redis工作正常,请关闭该项。
            //RedisConfigInfo类是记录redis连接信息，此信息和配置文件中的RedisConfig相呼应
            IEnumerable<string> writes = readWriteHosts;
            IEnumerable<string> reads = readOnlyHosts;
            // 支持读写分离，均衡负载 
            return new PooledRedisClientManager(writes, reads, new RedisClientManagerConfig
            {
                MaxWritePoolSize = 500, // “写”链接池链接数 
                MaxReadPoolSize = 500, // “读”链接池链接数 
                AutoStart = true,
                DefaultDb = RedisDb
                //DefaultDb=3,在这里配置也可以使用哪个DB
            });//在此配置也可以指定使用哪个数据库
        }

        private static IEnumerable<string> SplitString(string strSource, string split)
        {
            return strSource.Split(split.ToArray());
           
        }

        /// <summary>
        /// 客户端缓存操作对象
        /// </summary>
        public static IRedisClient GetClient()
        {
            if (_prcm == null)
            {
                CreateManager();
            }
            return _prcm.GetClient();
        }
        //如果要写，我们可以调用clientManager.GetClient() 来获取writeHosts的redis实例。

        //如果要读，我们可以调用clientManager.GetReadOnlyClient()来获取仅仅是readonlyHost的redis实例。

        //如果你嫌麻烦，那么完全可以使用clientManager.GetCacheClient() 来获取一个连接，他会在写的时候调用GetClient获取连接，读的时候调用GetReadOnlyClient获取连接，这样可以做到读写分离，从而利用redis的主从复制功能。
    }
}
