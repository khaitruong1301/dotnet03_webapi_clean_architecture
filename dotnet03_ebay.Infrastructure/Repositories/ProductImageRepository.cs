using dotnet03_ebay.Infrastructure.Models;

public interface IProductImageRepository : IRepository<ProductImage>
{
    // Add custom methods for Entity here if needed
}

public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
{
    public ProductImageRepository(EbayContext context) : base(context)
    {
    }
} 