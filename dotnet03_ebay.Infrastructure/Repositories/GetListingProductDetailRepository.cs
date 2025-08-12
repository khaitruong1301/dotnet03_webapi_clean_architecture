

using dotnet03_ebay.Infrastructure.Models;

public interface IGetListingProductDetailRepository : IRepository<GetListingProductDetail>
{
    // Add custom methods for GetListingProductDetail if needed
}

public class GetListingProductDetailRepository : Repository<GetListingProductDetail>, IGetListingProductDetailRepository
{
    public GetListingProductDetailRepository(EbayContext context) : base(context)
    {
    }
}
