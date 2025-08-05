using dotnet03_ebay.Infrastructure.Models;

public interface IUserRoleRepository : IRepository<UserRole>
{
    // Add custom methods for Entity here if needed
}

public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(EbayContext context) : base(context)
    {
    }
} 