//Tạo api controller cho productController
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet03_ebay.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
//using dotnet03_ebay.api.Models;

namespace dotnet03_ebay.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var res = await _productService.GetAllCategoryAsync();
            var data = res.Where(n => n.Deleted != true).Select(c => new
            {
                c.Id,
                c.Name,
                c.Description
            });
            //Đưa dữ liệu vào response
            HTTPResponseValue<IEnumerable<object>> response = new HTTPResponseValue<IEnumerable<object>>(data, MessageResponse.Success, StatusResponse.Success);

            return Ok(response);
        }

        [HttpGet("GetProductListingByCategoryId/{categoryId}")]
        [OutputCache(Duration = 300, VaryByRouteValueNames = new[] { "categoryId" })]
        public async Task<IActionResult> GetProductListingByCategoryId(int categoryId)
        {
            var res = await _productService.GetProductListingByCategoryId(categoryId);
            if (res.Count() == 0)
            {
                return NotFound(new HTTPResponseValue<string>(MessageResponse.NotFound, MessageResponse.NotFound, StatusResponse.NotFound));
            }
            return Ok(new HTTPResponseValue<IEnumerable<ProductListingDetailDTO>>(res, MessageResponse.Success, StatusResponse.Success));
        }
    }
}