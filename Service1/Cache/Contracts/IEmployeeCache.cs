using Service1.Entities;

namespace Service1.Cache.Contracts;

public interface IEmployeeCache
{
    ICollection<Employee>? GetEmployees();
    void SetEmployees(ICollection<Employee> employees);
    void ClearCache();
}