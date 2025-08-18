// {
//       "id": 3,
//       "name": "Camera 1",
//       "productId": 3,
//       "currentPrice": null,
//       "categoryId": 1,
//       "categoryName": "Electronics",
//       "userId": 819,
//       "fullName": "Lisa Smith",
//       "listImageDetail": [
//         {
//           "id": 4,
//           "productId": 3,
//           "imageUrl": "https://fakeimg.pl/350x200/?text=Camera%201"
//         }
//       ]
//     }

public class ProductListingVM
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
        public List<ImageDetailViewModel> ListImageDetail { get; set; } = new List<ImageDetailViewModel>();
}       

public class ImageDetailViewModel
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ImageUrl { get; set; }
}