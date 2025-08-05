using dotnet03_ebay.Infrastructure.Models;

public interface IRoleGroupRepository : IRepository<RoleGroup>
{
    // Add custom methods for Entity here if needed
}

public class RoleGroupRepository : Repository<RoleGroup>, IRoleGroupRepository
{
    public RoleGroupRepository(EbayContext context) : base(context)
    {
    }
} 