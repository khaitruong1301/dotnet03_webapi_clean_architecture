using dotnet03_ebay.Infrastructure.Models;

public interface IOrderRepository : IRepository<Order>
{
    // Add custom methods for Entity here if needed
}

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(EbayContext context) : base(context)
    {
    }
} 