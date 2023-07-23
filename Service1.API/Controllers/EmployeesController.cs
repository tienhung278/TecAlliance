using Microsoft.AspNetCore.Mvc;
using Service1.API.Models.Dtos;
using Service1.API.Services.Contracts;

namespace Service1.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : Controller
{
    private readonly IEmployeeServices _employeeServices;
    private readonly ILogger<EmployeesController> _logger;

    public EmployeesController(IServiceManager serviceManager,
        ILogger<EmployeesController> logger)
    {
        _logger = logger;
        _employeeServices = serviceManager.EmployeeServices;
    }

    [HttpGet]
    public ActionResult Get()
    {
        var employees = _employeeServices.GetEmployees();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public ActionResult Get(Guid id)
    {
        try
        {
            var employee = _employeeServices.GetEmployee(id);
            return Ok(employee);
        }
        catch (ArgumentException e)
        {
            _logger.LogInformation(e, e.Message, id);
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public ActionResult Post([FromBody] EmployeeWriteDto employeeWriteDto)
    {
        var id = _employeeServices.CreateEmployee(employeeWriteDto);
        var employeeReadDto = new EmployeeReadDto
        {
            HiringDate = employeeWriteDto.HiringDate,
            Id = id,
            Name = employeeWriteDto.Name,
            Position = employeeWriteDto.Position,
            Salary = employeeWriteDto.Salary
        };

        return Created($"/employees/{id}", employeeReadDto);
    }

    [HttpPut("{id}")]
    public ActionResult Put([FromRoute] Guid id, [FromBody] EmployeeWriteDto employeeWriteDto)
    {
        try
        {
            _employeeServices.UpdateEmployee(id, employeeWriteDto);
            return NoContent();
        }
        catch (ArgumentException e)
        {
            _logger.LogInformation(e, e.Message, id, employeeWriteDto);
            return NotFound(e.Message);
        }
        catch (NullReferenceException e)
        {
            _logger.LogInformation(e, e.Message, id, employeeWriteDto);
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        try
        {
            _employeeServices.DeleteEmployee(id);
            return NoContent();
        }
        catch (ArgumentException e)
        {
            _logger.LogInformation(e, e.Message, id);
            return NotFound(e.Message);
        }
    }
}