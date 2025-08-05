using dotnet03_ebay.Infrastructure.Models;

public interface ICategoryRepository : IRepository<Category>
{
    // Add custom methods for Entity here if needed
}

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(EbayContext context) : base(context)
    {
    }
} 