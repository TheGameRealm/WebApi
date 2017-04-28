namespace Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.Caching;
    using System.Text;
    using System.Threading.Tasks;
    using NLog;

    public abstract class RepositoryBase
    {
        protected static ILogger logger = LogManager.GetCurrentClassLogger();
        ObjectCache cache = MemoryCache.Default;
        private static readonly Object objLock = new Object();

        public void AddCache<T1>(string key, object data)
        {
            logger.Trace($"AddCache<{typeof(T1)}>(key = {key})");

            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(60)
            };

            lock (objLock)
            {
                cache.Set(key, data, policy);
            }
        }

        public T1 GetCache<T1>(string key)
        {
            logger.Trace($"GetCache<{typeof(T1)}>(key = {key})");
            lock (objLock)
            {
                var result = (T1)cache[key];

                return result;
            }

        }
    }
}
