using dotnet03_ebay.Infrastructure.Models;

public interface ILoginLogRepository : IRepository<LoginLog>
{
    // Add custom methods for Entity here if needed
}

public class LoginLogRepository : Repository<LoginLog>, ILoginLogRepository
{
    public LoginLogRepository(EbayContext context) : base(context)
    {
    }
} 