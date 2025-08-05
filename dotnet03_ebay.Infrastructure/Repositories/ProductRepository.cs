

using dotnet03_ebay.Infrastructure.Models;

public interface IProductRepository : IRepository<Product>
{
    // Add custom methods for Entity here if needed
}

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(EbayContext context) : base(context)
    {
    }
}