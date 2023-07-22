using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Service1.Cache.Contracts;
using Service1.Entities;
using Service1.Models;

namespace Service1.Cache;

public class EmployeeCache : IEmployeeCache
{
    private readonly ICacheBase _cacheBase;
    private readonly MemoryCacheEntryOptions _cacheEntryOptions;

    public EmployeeCache(ICacheBase cacheBase, IOptions<CacheConfigure> configuration)
    {
        _cacheBase = cacheBase;
        var cacheConfigure = configuration.Value;
        _cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(cacheConfigure.SlidingExpiration))
            .SetAbsoluteExpiration(TimeSpan.FromSeconds(cacheConfigure.AbsoluteExpiration));
    }

    public ICollection<Employee>? GetEmployees()
    {
        return _cacheBase.GetCache<ICollection<Employee>>(CacheKeys.Employees);
    }

    public void SetEmployees(ICollection<Employee> employees)
    {
        _cacheBase.SetCache(CacheKeys.Employees, employees, _cacheEntryOptions);
    }

    public void ClearCache()
    {
        _cacheBase.ClearCache(CacheKeys.Employees);
    }
}