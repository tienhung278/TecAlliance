using AutoMapper;
using Service1.Entities;
using Service1.Models.Dtos;
using Service1.Repositories.Contracts;
using Service1.Services.Contracts;

namespace Service1.Services;

public class EmployeeServices : IEmployeeServices
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmployeeServices(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _employeeRepository = repositoryManager.EmployeeRepository;
        _unitOfWork = repositoryManager.UnitOfWork;
        _mapper = mapper;
    }
    
    public ICollection<EmployeeReadDto> GetEmployees()
    {
        var employees = _employeeRepository.GetEmployees();
        return _mapper.Map<ICollection<EmployeeReadDto>>(employees);
    }

    public EmployeeReadDto? GetEmployee(Guid id)
    {
        var employee = _employeeRepository.GetEmployee(id);
        if (employee == null)
        {
            throw new ArgumentException("Employee Id was not found");
        }
        return _mapper.Map<EmployeeReadDto>(employee);
    }

    public Guid CreateEmployee(EmployeeWriteDto employee)
    {
        var empl = _mapper.Map<Employee>(employee);
        empl.Id = Guid.NewGuid();
        _employeeRepository.CreateEmployee(empl);
        _unitOfWork.SaveChanges();
        return empl.Id;
    }

    public void UpdateEmployee(Guid id, EmployeeWriteDto employee)
    {
        var curEmpl = _employeeRepository.GetEmployee(id);
        if (curEmpl == null)
        {
            throw new ArgumentException("Employee Id was not found");
        }
        if (employee == null)
        {
            throw new ArgumentException("Employee is required");
        }
        var empl = _mapper.Map<Employee>(employee);
        empl.Id = id;
        _employeeRepository.UpdateEmployee(empl);
        _unitOfWork.SaveChanges();
    }

    public void DeleteEmployee(Guid id)
    {
        var empl = _employeeRepository.GetEmployee(id);
        if (empl == null)
        {
            throw new ArgumentException("Employee Id was not found");
        }
        _employeeRepository.DeleteEmployee(empl);
        _unitOfWork.SaveChanges();
    }
}