using AutoMapper;
using Service1.Cache.Contracts;
using Service1.Repositories.Contracts;
using Service1.Services.Contracts;

namespace Service1.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IEmployeeServices> _lazyEmployeeServices;

    public ServiceManager(ICacheManager cacheManager,
        IRepositoryManager repositoryManager,
        IMapper mapper)
    {
        _lazyEmployeeServices =
            new Lazy<IEmployeeServices>(() => new EmployeeServices(cacheManager, repositoryManager, mapper));
    }

    public IEmployeeServices EmployeeServices => _lazyEmployeeServices.Value;
}