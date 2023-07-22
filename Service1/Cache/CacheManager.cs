using Microsoft.Extensions.Options;
using Service1.Cache.Contracts;
using Service1.Models;

namespace Service1.Cache;

public class CacheManager : ICacheManager
{
    private readonly Lazy<IEmployeeCache> _lazyEmployeeCache;

    public CacheManager(ICacheBase cacheBase,
        IOptions<CacheConfigure> configure)
    {
        _lazyEmployeeCache = new Lazy<IEmployeeCache>(() => new EmployeeCache(cacheBase, configure));
    }

    public IEmployeeCache EmployeeCache => _lazyEmployeeCache.Value;
}