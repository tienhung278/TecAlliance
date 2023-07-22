namespace Service1.Repositories.Contracts;

public class UnitOfWork : IUnitOfWork
{
    private readonly IRepositoryContext _context;

    public UnitOfWork(IRepositoryContext context)
    {
        _context = context;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}