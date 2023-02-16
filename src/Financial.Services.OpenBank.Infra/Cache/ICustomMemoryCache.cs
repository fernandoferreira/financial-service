
using System;
namespace Financial.Services.OpenBank.Infra.Cache
{
    public interface ICustomMemoryCache
    {
        void SetCache(string cacheKey, object values);

        object ReadFromCache(string cacheKey);
    }
}

