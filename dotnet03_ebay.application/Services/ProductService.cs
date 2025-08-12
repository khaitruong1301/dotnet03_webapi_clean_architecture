using System.Text.Json;
using dotnet03_ebay.Infrastructure.Models;

public interface IProductService
{
    Task<IEnumerable<Category>> GetAllCategoryAsync();
    Task<IEnumerable<GetListingProductDetail>> GetAllProductListing();
    Task<IEnumerable<ProductListingDetailDTO>> GetProductListingByCategoryId(int categoryId);

}

public class ProductService : IProductService
{
    public IProductRepository _productRepo;
    public IUnitOfWork _dbu;
    public ICategoryRepository _categoryRepo;
    public IListingRepository _listingRepository;
    public IGetListingProductDetailRepository _getListingProductDetailRepository;
    public ProductService(IProductRepository productRepo, IUnitOfWork dbu, ICategoryRepository categoryRepo, IListingRepository listingRepository,
        IGetListingProductDetailRepository getListingProductDetailRepository)
    {
        _productRepo = productRepo;
        _dbu = dbu;
        _categoryRepo = categoryRepo;
        _listingRepository = listingRepository;
         _getListingProductDetailRepository= getListingProductDetailRepository;

    }

    public async Task<IEnumerable<Category>> GetAllCategoryAsync()
    {
        return await _categoryRepo.GetAllAsync();
    }

    public async Task<IEnumerable<GetListingProductDetail>> GetAllProductListing()
    {


        return await _getListingProductDetailRepository.GetAllAsync();
    }

    public async Task<IEnumerable<ProductListingDetailDTO>> GetProductListingByCategoryId(int categoryId)
    {
        var lstListing = await _getListingProductDetailRepository.WhereAsync(x => x.CategoryId == categoryId);
        var data = lstListing.Select( n => new ProductListingDetailDTO
        {
            Id = n.Id,
            Name = n.Name,
            ProductId = n.ProductId,
            CurrentPrice = n.CurrentPrice,
            CategoryId = n.CategoryId,
            CategoryName = n.CategoryName,
            UserId = n.UserId,
            FullName = n.FullName,
            ListImageDetail =  JsonSerializer.Deserialize<IEnumerable<ProductImageDTO>>(n.ListImageDetail)
        });
        return data;
    }
}