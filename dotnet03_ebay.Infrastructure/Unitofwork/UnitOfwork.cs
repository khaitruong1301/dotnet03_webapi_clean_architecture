using dotnet03_ebay.Infrastructure.Models;

public interface IUnitOfWork : IAsyncDisposable
{

    Task BeginTransactionAsync();
    Task CommitTransactionAsync();

    Task<int> SaveChangesAsync();
    Task<int> SaveChanges();

    Task  RollBackTransactionAsync();
}

public class UnitOfWork: IUnitOfWork
{

    private readonly EbayContext _context;
    

    public UnitOfWork(EbayContext context)
    {
        _context = context;

    }
    //2 phương thức sử dụng cho LinQ
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
    public async Task<int> SaveChanges()
    {
        return  _context.SaveChanges();
    }
    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }


    //3 phương thức bên dưới sử dụng cho SQLRaw
    public async Task BeginTransactionAsync()
    {
        await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await _context.Database.CommitTransactionAsync();

    }

    public async Task RollBackTransactionAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }
}