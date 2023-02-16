using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Financial.Services.OpenBank.Infra.Cache
{
    public class CustomMemoryCache : ICustomMemoryCache
    {
        public MemoryCache Cache { get; set; }

        public CustomMemoryCache()
        {
            Cache = new MemoryCache(new MemoryCacheOptions
            {
                SizeLimit = 1024,
                ExpirationScanFrequency = TimeSpan.FromSeconds(30),

            });
        }

        public void SetCache(string cacheKey, object values)
        {
            Cache.Set(cacheKey, values, new MemoryCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(20),
                SlidingExpiration = TimeSpan.FromSeconds(10),
                Size = 1
            });
        }

        public object ReadFromCache(string cacheKey)
        {
            if (Cache.TryGetValue(cacheKey, out object valuesFromCache))
            {
                return valuesFromCache!;
            }

            return null;
        }
    }
}
