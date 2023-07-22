namespace Service1.Cache.Contracts;

public interface ICacheManager
{
    public IEmployeeCache EmployeeCache { get; }
}