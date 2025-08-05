using dotnet03_ebay.Infrastructure.Models;

public interface IPhongBanRepository : IRepository<PhongBan>
{
    // Add custom methods for Entity here if needed
}

public class PhongBanRepository : Repository<PhongBan>, IPhongBanRepository
{
    public PhongBanRepository(EbayContext context) : base(context)
    {
    }
} 