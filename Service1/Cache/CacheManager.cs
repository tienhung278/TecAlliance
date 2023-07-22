using Microsoft.Extensions.Options;
using Service1.Cache.Contracts;
using Service1.Models;

namespace Service1.Cache;

public class CacheManager : ICacheManager
{
    private readonly Lazy<IEmployeeCache> _lazyEmployeeCache;

    public CacheManager(ICacheContext cacheContext,
        IOptions<CacheConfigure> configure)
    {
        _lazyEmployeeCache = new Lazy<IEmployeeCache>(() => new EmployeeCache(cacheContext, configure));
    }

    public IEmployeeCache EmployeeCache => _lazyEmployeeCache.Value;
}