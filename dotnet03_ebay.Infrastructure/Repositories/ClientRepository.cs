using dotnet03_ebay.Infrastructure.Models;

public interface IClientRepository : IRepository<Client>
{
    // Add custom methods for Entity here if needed
}

public class ClientRepository : Repository<Client>, IClientRepository
{
    public ClientRepository(EbayContext context) : base(context)
    {
    }
} 