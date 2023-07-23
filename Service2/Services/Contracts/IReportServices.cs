using Service1.Models.Dtos;

namespace Service2.Services.Contracts;

public interface IReportServices
{
    Task<ICollection<EmployeeResponse>?> GetEmployeesAsync();
    void CreateEmployeesReport(ICollection<EmployeeResponse>? employee);
}