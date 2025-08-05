using dotnet03_ebay.Infrastructure.Models;

public interface IEbayProductRepository : IRepository<EbayProduct>
{
    // Add custom methods for Entity here if needed
}

public class EbayProductRepository : Repository<EbayProduct>, IEbayProductRepository
{
    public EbayProductRepository(EbayContext context) : base(context)
    {
    }
} 