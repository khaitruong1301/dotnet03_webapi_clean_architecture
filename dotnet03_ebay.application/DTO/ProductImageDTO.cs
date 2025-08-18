// [
public class ProductListingDetailDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ProductId { get; set; }
    public decimal? CurrentPrice { get; set; } = 1000;
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public int UserId { get; set; }
    public string FullName { get; set; }
    public string? Description { get; set; }
    public string? Avatar { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public bool? Deleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public IEnumerable<ProductImageDTO> ListImageDetail { get; set; }
}

public class ProductImageDTO
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ImageUrl { get; set; }

}