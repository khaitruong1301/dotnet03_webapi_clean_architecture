using dotnet03_ebay.Infrastructure.Models;

public interface IOrderby2025Repository : IRepository<Orderby2025>
{
    // Add custom methods for Entity here if needed
}

public class Orderby2025Repository : Repository<Orderby2025>, IOrderby2025Repository
{
    public Orderby2025Repository(EbayContext context) : base(context)
    {
    }
} 