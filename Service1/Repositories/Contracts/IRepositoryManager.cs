namespace Service1.Repositories.Contracts;

public interface IRepositoryManager
{
    public IEmployeeRepository EmployeeRepository { get; }
    public IUnitOfWork UnitOfWork { get; }
}