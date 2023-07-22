using Microsoft.Extensions.Caching.Memory;

namespace Service1.Cache.Contracts;

public interface ICacheContext
{
    T? GetCache<T>(string key) where T : class;
    void SetCache<T>(string key, T value, MemoryCacheEntryOptions options) where T : class;
    void ClearCache(string key);
}