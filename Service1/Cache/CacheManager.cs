using Microsoft.Extensions.Options;
using Service1.Cache.Contracts;
using Service1.Models;
using Service1.Repositories.Contracts;

namespace Service1.Cache;

public class CacheManager : ICacheManager
{
    private readonly Lazy<IEmployeeCache> _lazyEmployeeCache;
    
    public IEmployeeCache EmployeeCache => _lazyEmployeeCache.Value;

    public CacheManager(IRepositoryManager repositoryManager, 
        ICacheBase cacheBase, 
        IOptions<CacheConfigure> configure)
    {
        _lazyEmployeeCache = new Lazy<IEmployeeCache>(() => new EmployeeCache(repositoryManager, cacheBase, configure));
    }
}