using Service1.Entities;

namespace Service1.Repositories.Contracts;

public interface IEmployeeRepository
{
    ICollection<Employee> GetEmployees();
    Employee? GetEmployee(Guid id);
    void CreateEmployee(Employee employee);
    void UpdateEmployee(Employee employee);
    void DeleteEmployee(Employee employee);
}