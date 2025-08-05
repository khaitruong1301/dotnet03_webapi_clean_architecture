using dotnet03_ebay.Infrastructure.Models;

public interface IConnectionCountLogRepository : IRepository<ConnectionCountLog>
{
    // Add custom methods for Entity here if needed
}

public class ConnectionCountLogRepository : Repository<ConnectionCountLog>, IConnectionCountLogRepository
{
    public ConnectionCountLogRepository(EbayContext context) : base(context)
    {
    }
} 