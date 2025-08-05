using dotnet03_ebay.Infrastructure.Models;

public interface IOrderby2024Repository : IRepository<Orderby2024>
{
    // Add custom methods for Entity here if needed
}

public class Orderby2024Repository : Repository<Orderby2024>, IOrderby2024Repository
{
    public Orderby2024Repository(EbayContext context) : base(context)
    {
    }
} 