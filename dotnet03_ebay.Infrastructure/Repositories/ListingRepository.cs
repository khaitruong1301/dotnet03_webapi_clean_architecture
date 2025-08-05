using dotnet03_ebay.Infrastructure.Models;

public interface IListingRepository : IRepository<Listing>
{
    // Add custom methods for Entity here if needed
}

public class ListingRepository : Repository<Listing>, IListingRepository
{
    public ListingRepository(EbayContext context) : base(context)
    {
    }
} 