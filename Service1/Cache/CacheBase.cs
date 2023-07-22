using Microsoft.Extensions.Caching.Memory;
using Service1.Cache.Contracts;

namespace Service1.Cache;

public class CacheBase : ICacheBase
{
    private readonly IMemoryCache _cache;

    public CacheBase(IMemoryCache cache)
    {
        _cache = cache;
    }
    
    public T? GetCache<T>(string key) where T : class
    {
        _cache.TryGetValue(key, out T? cachedResponse);
        return cachedResponse as T;
    }

    public void SetCache<T>(string key, T value, MemoryCacheEntryOptions options) where T : class
    {
        _cache.Set(key, value, options);
    }

    public void ClearCache(string key)
    {
        _cache.Remove(key);
    }
}