using dotnet03_ebay.Infrastructure.Models;

public interface IUserRepository : IRepository<User>
{
    // Add custom methods for Entity here if needed
}

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(EbayContext context) : base(context)
    {
    }
}