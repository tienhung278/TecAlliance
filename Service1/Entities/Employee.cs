namespace Service1.Entities;

public class Employee
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Position { get; set; }
    public DateOnly HiringDate { get; set; }
    public decimal Salary { get; set; }
}