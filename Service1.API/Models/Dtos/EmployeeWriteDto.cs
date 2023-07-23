namespace Service1.API.Models.Dtos;

public class EmployeeWriteDto
{
    public string? Name { get; set; }
    public string? Position { get; set; }
    public DateOnly HiringDate { get; set; }
    public decimal Salary { get; set; }
}