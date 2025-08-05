using dotnet03_ebay.Infrastructure.Models;

public interface IOrdersBy2025Repository : IRepository<OrdersBy2025>
{
    // Add custom methods for Entity here if needed
}

public class OrdersBy2025Repository : Repository<OrdersBy2025>, IOrdersBy2025Repository
{
    public OrdersBy2025Repository(EbayContext context) : base(context)
    {
    }
} 