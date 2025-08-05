using dotnet03_ebay.Infrastructure.Models;

public interface IRatingRepository : IRepository<Rating>
{
    // Add custom methods for Entity here if needed
}

public class RatingRepository : Repository<Rating>, IRatingRepository
{
    public RatingRepository(EbayContext context) : base(context)
    {
    }
} 