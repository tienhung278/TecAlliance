using AutoMapper;
using Service1.Repositories.Contracts;
using Service1.Services.Contracts;

namespace Service1.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IEmployeeServices> _lazyEmployeeServices;
    
    public IEmployeeServices EmployeeServices => _lazyEmployeeServices.Value;

    public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _lazyEmployeeServices = new Lazy<IEmployeeServices>(() => new EmployeeServices(repositoryManager, mapper));
    }
}