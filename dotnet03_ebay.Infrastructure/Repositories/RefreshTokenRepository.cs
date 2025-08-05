using dotnet03_ebay.Infrastructure.Models;

public interface IRefreshTokenRepository : IRepository<RefreshToken>
{
    // Add custom methods for Entity here if needed
}

public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
{
    public RefreshTokenRepository(EbayContext context) : base(context)
    {
    }
} 