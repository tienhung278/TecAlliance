namespace Service1.Models.Dtos;

public class EmployeeWriteDto
{
    public string? Name { get; set; }
    public string? Position { get; set; }
    public DateOnly HiringDate { get; set; }
    public decimal Salary { get; set; }
}