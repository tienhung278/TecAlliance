namespace Service1.Repositories.Contracts;

public interface IUnitOfWork
{
    void SaveChanges();
}