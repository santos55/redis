using System;
using System.Collections.Generic;
using System.Threading.Tasks; 
using BookSleeve;

namespace Services
{
    public class QueueManager
    {
        private const int db = 12;

        #region Common Operations

        /// <summary>
        /// Checks if key exists.
        /// </summary>
        public async Task<bool> Exists(string key)
        {
            RedisConnection redisConn = RedisConnectionProvider.GetConnection();
            return await redisConn.Keys.Exists(db, key);
        }

        public void FlushDb()
        {
            RedisConnection redisConn = RedisConnectionProvider.GetConnection();
            redisConn.Server.FlushDb(db);
        }

        #endregion

        #region String Operations
        /// <summary>
        /// Sets a single value for a key.
        /// </summary>
        public void Set(string key, string value)
        {
            RedisConnection redisConn = RedisConnectionProvider.GetConnection();
            redisConn.Strings.Set(db, key, value);          
        }

        /// <summary>
        /// Gets a single value for the specified key.
        /// </summary>
        public async Task<string> GetAsync(string key)
        {
            RedisConnection redisConn = RedisConnectionProvider.GetConnection();
            var value = await redisConn.Strings.GetString(db, key);
            return value;
        }

        #endregion

        #region List Operations

        public async Task<int> GetListLenghAsync(string key)
        {
            RedisConnection redisConn = RedisConnectionProvider.GetConnection();
            return (int)await redisConn.Lists.GetLength(db, key);
        }

        public void AddListHead(string key, string value)
        {
            RedisConnection redisConn = RedisConnectionProvider.GetConnection();
            redisConn.Lists.AddFirst(db, key, value);
        }

        public void AddListTail(string key, string value)
        {
            RedisConnection redisConn = RedisConnectionProvider.GetConnection();
            redisConn.Lists.AddLast(db, key, value);
        }

        /// <summary>
        /// Gets a single value for the specified key.
        /// </summary>
        public async Task<string> GetListHeadAsync(string key)
        {
            RedisConnection redisConn = RedisConnectionProvider.GetConnection();
            var value = await redisConn.Lists.GetString(db, key, 0);
            return value;
        }

        /// <summary>
        /// Gets a single value for the specified key.
        /// </summary>
        public async Task<string> GetListTailAsync(string key)
        {
            RedisConnection redisConn = RedisConnectionProvider.GetConnection();
            var value = await redisConn.Lists.GetString(db, key, await GetListLenghAsync(key) - 1);
            return value;
        }

        /// <summary>
        /// Gets a single value for the specified key.
        /// </summary>
        public async Task<string[]> GetListAsync(string key)
        {
            RedisConnection redisConn = RedisConnectionProvider.GetConnection();
            var value = await redisConn.Lists.RangeString(db, key, 0, await GetListLenghAsync(key) - 1);
            return value;
        }
        #endregion
    }
}
