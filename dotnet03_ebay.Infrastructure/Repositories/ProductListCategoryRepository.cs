using dotnet03_ebay.Infrastructure.Models;

public interface IProductListCategoryRepository : IRepository<ProductListCategory>
{
    // Add custom methods for Entity here if needed
}

public class ProductListCategoryRepository : Repository<ProductListCategory>, IProductListCategoryRepository
{
    public ProductListCategoryRepository(EbayContext context) : base(context)
    {
    }
} 