using Microsoft.AspNetCore.Mvc;
using QuanLyCuaHangBanGiay.Commons;
using Service.Common.Validators.ProductDetails;
using Service.Handlers.Brands.Queries;
using Service.Handlers.Categorys.Queries;
using Service.Handlers.Colors.Queries;
using Service.Handlers.Materials.Queries;
using Service.Handlers.ProductDetails.Command;
using Service.Handlers.ProductDetails.Queries;
using Service.Handlers.Products.Queries;
using Service.Handlers.Sizes.Queries;

namespace QuanLyCuaHangBanGiay.Controllers.AdminManagementProductDetailController
{
    // [Authorize]
    [Route("api/admin/product-management")]
    public class ProductDetailController : ApiControllerBase
    {
        // private readonly ITokenHandler _tokenHandler;
        //
        // public ProductDetailController(ITokenHandler tokenHandler)
        // {
        //     _tokenHandler = tokenHandler;
        // }

        [HttpGet("get-page-product-detail")]
        public async Task<IEnumerable<ProductDetailDto>> GetProductDetails([FromQuery] int page = 1)
        {
            return await Mediator.Send(new GetPageProductDetailsQuery { PageNumber = page });
        }

        [HttpGet("get-all-product-detail")]
        public async Task<IEnumerable<ProductDetailDto>> GetAllProductDetails()
        {
            return await Mediator.Send(new GetAllProductDetailQuery());
        }

        [HttpGet("get-all-brand")]
        public async Task<IEnumerable<BrandDto>> GetAllBrands()
        {
            return await Mediator.Send(new GetAllBrandQuery());
        }

        [HttpGet("get-all-product")]
        public async Task<IEnumerable<ProductDto>> GetAllProdcuts()
        {
            return await Mediator.Send(new GetAllProductQuery());
        }

        [HttpGet("get-all-category")]
        public async Task<IEnumerable<CategoryDto>> GetAllCategory()
        {
            return await Mediator.Send(new GetAllCategoryQuery());
        }

        [HttpGet("get-all-color")]
        public async Task<IEnumerable<ColorDto>> GetAllColor()
        {
            return await Mediator.Send(new GetAllColorQuery());
        }

        [HttpGet("get-all-material")]
        public async Task<IEnumerable<MaterialDto>> GetAllMaterial()
        {
            return await Mediator.Send(new GetAllMaterialQuery());
        }

        [HttpGet("get-all-size")]
        public async Task<IEnumerable<SizeDto>> GetAllSize()
        {
            return await Mediator.Send(new GetAllSizeQuery());
        }

        [HttpPost("create-product")]
        public async Task<IActionResult> Insert([FromBody] CreateProductDetailCommand productDetailCommand)
        {
            AddProductDetailCommandValidator validation = new();
            var results = await validation.ValidateAsync(productDetailCommand);
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    return BadRequest(new ResponseObject(failure.ErrorMessage));
                }
            }

            await Mediator.Send(productDetailCommand);
            return Ok();
        }

        [HttpPut("update-product")]
        public async Task<IActionResult> Update([FromBody] UpdateProductDetailCommand updateProductDetailCommand)
        {
            UpdateProductDetailCommandValidator validator = new();
            var result = await validator.ValidateAsync(updateProductDetailCommand);
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    return BadRequest(new ResponseObject(failure.ErrorMessage));
                }
            }

            await Mediator.Send(updateProductDetailCommand);
            return Ok();
        }

        [HttpDelete("delete-product")]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            var result = await Mediator.Send(new DeleteProductDetailCommand { Id = id });
            return Ok(result);
        }


        [HttpPost("search-product-detail")]
        public async Task<IEnumerable<ProductDetailDto>> SearchProductDetail(
            [FromBody] GetProductDetailByConditionQuery query)
        {
            return await Mediator.Send(new GetProductDetailByConditionQuery());
        }

        // [HttpPost("login")]
        // [AllowAnonymous]
        // public async Task<IActionResult> Login([FromBody] AccountModel accountModel)
        // {
        //     if (accountModel == null)
        //     {
        //         return await Task.FromResult(BadRequest("User is not exist"));
        //     }
        //
        //     var user = await _employerService.GetEmployer(accountModel.Email, accountModel.Password);
        //     if (user == null)
        //     {
        //         return Unauthorized();
        //     }
        //
        //     return await Task.Factory.StartNew(() => { return Ok(_tokenHandler.CreateToken(user)); });
        // }
    }
}