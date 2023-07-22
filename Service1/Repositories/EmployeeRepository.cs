using Service1.Entities;
using Service1.Repositories.Contracts;

namespace Service1.Repositories;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(IRepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public ICollection<Employee> GetEmployees()
    {
        return (FindAll() ?? Array.Empty<Employee>()).ToList();
    }

    public Employee? GetEmployee(Guid id)
    {
        return (FindByCondition(e => e.Id == id) ?? Array.Empty<Employee>())
            .SingleOrDefault();
    }

    public void CreateEmployee(Employee employee)
    {
        Create(employee);
    }

    public void UpdateEmployee(Employee employee)
    {
        Update(employee);
    }

    public void DeleteEmployee(Employee employee)
    {
        Delete(employee);
    }
}