using dotnet03_ebay.Infrastructure.Models;

public interface IBidRepository : IRepository<Bid>
{
    // Add custom methods for Entity here if needed
}

public class BidRepository : Repository<Bid>, IBidRepository
{
    public BidRepository(EbayContext context) : base(context)
    {
    }
} 