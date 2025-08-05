using dotnet03_ebay.Infrastructure.Models;

public interface INhanVienRepository : IRepository<NhanVien>
{
    // Add custom methods for Entity here if needed
}

public class NhanVienRepository : Repository<NhanVien>, INhanVienRepository
{
    public NhanVienRepository(EbayContext context) : base(context)
    {
    }
} 