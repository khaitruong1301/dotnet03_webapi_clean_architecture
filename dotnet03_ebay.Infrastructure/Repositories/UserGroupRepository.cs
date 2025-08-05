using dotnet03_ebay.Infrastructure.Models;

public interface IUserGroupRepository : IRepository<UserGroup>
{
    // Add custom methods for Entity here if needed
}

public class UserGroupRepository : Repository<UserGroup>, IUserGroupRepository
{
    public UserGroupRepository(EbayContext context) : base(context)
    {
    }
} 