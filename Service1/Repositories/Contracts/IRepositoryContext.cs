namespace Service1.Repositories.Contracts;

public interface IRepositoryContext
{
    List<T>? Set<T>() where T : class;
    void SaveChanges();
}