// [
public class ProductListingDetailDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ProductId { get; set; }
    public decimal? CurrentPrice { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public int UserId { get; set; }
    public string FullName { get; set; }
    public IEnumerable<ProductImageDTO> ListImageDetail { get; set; }
}



public class ProductImageDTO
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ImageUrl { get; set; }

}