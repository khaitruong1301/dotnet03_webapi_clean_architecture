using dotnet03_ebay.Infrastructure.Models;

public interface IRoleRepository : IRepository<Role>
{
    // Add custom methods for Entity here if needed
}

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(EbayContext context) : base(context)
    {
    }
} 