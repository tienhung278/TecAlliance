using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Service1.Cache.Contracts;
using Service1.Entities;
using Service1.Models;
using Service1.Repositories.Contracts;

namespace Service1.Cache;

public class EmployeeCache : IEmployeeCache
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ICacheBase _cacheBase;
    private readonly MemoryCacheEntryOptions _cacheEntryOptions;
    private static readonly object lockObj = new object();

    public EmployeeCache(IRepositoryManager repositoryManager, ICacheBase cacheBase, IOptions<CacheConfigure> configuration)
    {
        _employeeRepository = repositoryManager.EmployeeRepository;
        _cacheBase = cacheBase;
        var cacheConfigure = configuration.Value;
        _cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(cacheConfigure.SlidingExpiration))
            .SetAbsoluteExpiration(TimeSpan.FromSeconds(cacheConfigure.AbsoluteExpiration));
    }
    
    public ICollection<Employee>? GetEmployees()
    {
        var employees = _cacheBase.GetCache<ICollection<Employee>>(CacheKeys.Employees);
        if (employees != null)
        {
            return employees;
        }
        
        try
        {
            Monitor.Enter(lockObj);
            employees = _employeeRepository.GetEmployees();
            _cacheBase.SetCache(CacheKeys.Employees, employees, _cacheEntryOptions);
        }
        finally
        {
            Monitor.Exit(lockObj);
        }

        return employees;
    }

    public void ClearCache()
    {
        _cacheBase.ClearCache(CacheKeys.Employees);
    }
}