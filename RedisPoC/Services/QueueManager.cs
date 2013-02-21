using System;
using System.Collections.Generic;
using System.Threading.Tasks; 
using BookSleeve;

namespace Services
{
    public class QueueManager
    {
        private const int db = 12;


        public void Flush()
        {
            using (var conn = new RedisConnection("localhost"))
            {
                throw new NotImplementedException();
            }

        }
        /// <summary>
        /// Sets a single value for a key.
        /// </summary>
        public void Set(string key, string value)
        {
            using (var conn = new RedisConnection("localhost"))
            {
                conn.Open();
                conn.Strings.Set(db, key, value);
            }
            
        }

        /// <summary>
        /// Checks if key exists.
        /// </summary>
        public async Task<bool> Exists(string key)
        {
            using (var conn = new RedisConnection("localhost"))
            {
                await conn.Open();
                return await conn.Keys.Exists(db, key);
            }
        }

        public async Task<int> GetListLenghAsync(string key)
        {
            using (var conn = new RedisConnection("localhost"))
            {
                await conn.Open();
                return (int)await conn.Lists.GetLength(db, key);
            }
        }
        
        /// <summary>
        /// Gets a single value for the specified key.
        /// </summary>
        public async Task<string> GetAsync(string key)
        {
            using (var conn = new RedisConnection("localhost"))
            {
                await conn.Open();
                var value = await conn.Strings.GetString(db, key);
                return value;
            }
        }

        public void AddListHead(string key, string value)
        {
            using (var conn = new RedisConnection("localhost"))
            {
                conn.Open();
                conn.Lists.AddFirst(db, key, value);
            }
        }

        public void AddListTail(string key, string value)
        {
            using (var conn = new RedisConnection("localhost"))
            {
                conn.Open();
                conn.Lists.AddLast(db, key, value);
            }
        }

        /// <summary>
        /// Gets a single value for the specified key.
        /// </summary>
        public async Task<string> GetListHeadAsync(string key)
        {
            using (var conn = new RedisConnection("localhost"))
            {
                await conn.Open();
                var value = await conn.Lists.GetString(db, key, 0);
                return value;
            }
        }

        /// <summary>
        /// Gets a single value for the specified key.
        /// </summary>
        public async Task<string> GetListTailAsync(string key)
        {
            using (var conn = new RedisConnection("localhost"))
            {
                await conn.Open();
                var value = await conn.Lists.GetString(db, key, await GetListLenghAsync(key)-1);
                return value;
            }
        }

        /// <summary>
        /// Gets a single value for the specified key.
        /// </summary>
        public async Task<string[]> GetListAsync(string key)
        {
            using (var conn = new RedisConnection("localhost"))
            {
                await conn.Open();
                var value = await conn.Lists.RangeString(db, key, 0, await GetListLenghAsync(key) - 1);
                return value;
            }
        }
    }
}
