using Service1.Repositories.Contracts;

namespace Service1.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IEmployeeRepository> _lazyEmployeeRepository;
    private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
    
    public IEmployeeRepository EmployeeRepository => _lazyEmployeeRepository.Value;
    public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;

    public RepositoryManager(RepositoryContext context)
    {
        _lazyEmployeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(context));
        _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(context));
    }
}