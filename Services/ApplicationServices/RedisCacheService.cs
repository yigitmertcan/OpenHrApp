using HrApp.Interfaces.ApplicationServices;
using StackExchange.Redis;
using System.Collections.Generic;

namespace HrApp.Services.ApplicationServices
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IConnectionMultiplexer _redisConnection;
        private readonly IDatabase _cache;

        public RedisCacheService(IConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection;
            _cache = redisConnection.GetDatabase();
        }

        public async Task Clear(string key)
        {
            await _cache.KeyDeleteAsync(key);
        }

        public void ClearAll()
        {
            var redisEndpoints = _redisConnection.GetEndPoints(true);
            foreach (var redisEndpoint in redisEndpoints)
            {
                var redisServer = _redisConnection.GetServer(redisEndpoint);
                redisServer.FlushAllDatabases();
            }
        }

        public async Task<string> GetValueAsync(string key)
        {
            return await _cache.StringGetAsync(key);
        }

        public async Task<bool> SetValueAsync(string key, string value)
        {
            return await _cache.StringSetAsync(key, value, TimeSpan.FromHours(1));
        }

        public async Task<string> GetHashValueAsync(string key,string subkey)
        {
            return await _cache.HashGetAsync(key,subkey);
        }

        public async Task<bool> SetHashValueAsync(string key,string subkey ,string value)
        {
            return await _cache.HashSetAsync(key, subkey, value);
        }
    }
}
