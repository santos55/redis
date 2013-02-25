using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSleeve;

namespace Services
{
    /// <summary>
    /// RedisConnectionProvider is the static provider for RedisConnection objects.
    /// It give us the ability to reuse a connection implementing a Singleton.
    /// </summary>
    public static class RedisConnectionProvider
    {
        #region Config

        private static string host = "localhost";

        #endregion

        #region Private Members
        private static RedisConnection redisConnection;
        private static Object connLock = new Object();
        #endregion
        
        #region Public Methods
        /// <summary>
        /// Gets the opened connection, or creates a new one if needed.
        /// </summary>
        /// <returns></returns>
        public static RedisConnection GetConnection()
        {
            lock (connLock)
            {
                if (redisConnection == null)
                    CreateConnection();
                switch (redisConnection.State)
                {
                    case RedisConnectionBase.ConnectionState.Open:
                    case RedisConnectionBase.ConnectionState.Opening:
                        break;
                    case RedisConnectionBase.ConnectionState.Closing:
                    case RedisConnectionBase.ConnectionState.Closed:
                        CreateConnection();
                        break;
                    case RedisConnectionBase.ConnectionState.Shiny:
                        OpenConnection();
                        break;
                }
            }

            return redisConnection;

        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Creates a new connection, and opens it.
        /// </summary>
        private static void CreateConnection()
        {
            redisConnection = new RedisConnection(host, allowAdmin: true);
            OpenConnection();
        }

        /// <summary>
        /// Opens the connection.
        /// </summary>
        private static async void OpenConnection()
        {
            await redisConnection.Open();
        }
        #endregion
    }
}
