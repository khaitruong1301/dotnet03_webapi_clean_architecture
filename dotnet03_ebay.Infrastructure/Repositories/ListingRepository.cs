using dotnet03_ebay.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

public interface IListingRepository : IRepository<Listing>
{
    // Add custom methods for Entity here if needed

    // Task<GetListingProductDetail> GetListingProductDetail();
}

public class ListingRepository : Repository<Listing>, IListingRepository
{
    public ListingRepository(EbayContext context) : base(context)
    {
    }

    // public async Task<GetListingProductDetail> GetListingProductDetail()
    // {
    //     // var listingDetails = await _context.Listings.Include(n => n.Product).Include(n => n.Category).Include(n => n.Seller).Include(n => n.Product.ProductImages).ToListAsync();
    //     // return listingDetails.Select(x => new GetListingProductDetail { })
    // }
} 