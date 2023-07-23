using Service1.API.Models.Dtos;

namespace Service1.API.Services.Contracts;

public interface IEmployeeServices
{
    ICollection<EmployeeReadDto> GetEmployees();
    EmployeeReadDto? GetEmployee(Guid id);
    Guid CreateEmployee(EmployeeWriteDto employee);
    void UpdateEmployee(Guid id, EmployeeWriteDto employee);
    void DeleteEmployee(Guid id);
}