using dotnet03_ebay.Infrastructure.Models;

public interface IGetListOrderDetailByOrderIdRepository : IRepository<GetListOrderDetailByOrderId>
{
    // Add custom methods for Entity here if needed
}

public class GetListOrderDetailByOrderIdRepository : Repository<GetListOrderDetailByOrderId>, IGetListOrderDetailByOrderIdRepository
{
    public GetListOrderDetailByOrderIdRepository(EbayContext context) : base(context)
    {
    }
} 