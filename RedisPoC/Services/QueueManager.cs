using System;
using System.Collections.Generic;
using System.Threading.Tasks; 
using BookSleeve;

namespace Services
{
    public class QueueManager
    {
        private const int db = 12;

        public void Set(string key, string value)
        {
            using (var conn = new RedisConnection("localhost"))
            {
                conn.Open();
                conn.Set(db, key, value);
            }
        }

        public async Task<string> Get(string key)
        {
            using (var conn = new RedisConnection("localhost"))
            {
                await conn.Open();
                var value = await conn.GetString(db, key);
                return value;
            }


            
        }



    }
}
