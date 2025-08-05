using dotnet03_ebay.Infrastructure.Models;

public interface IGroupRepository : IRepository<Group>
{
    // Add custom methods for Entity here if needed
}

public class GroupRepository : Repository<Group>, IGroupRepository
{
    public GroupRepository(EbayContext context) : base(context)
    {
    }
} 