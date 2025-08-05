using dotnet03_ebay.Infrastructure.Models;

public interface IOrderDetailRepository : IRepository<OrderDetail>
{
    // Add custom methods for Entity here if needed
}

public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
{
    public OrderDetailRepository(EbayContext context) : base(context)
    {
    }
} 