using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using NLog;
using QuanLyCuaHangBanGiay.Commons;
using QuanLyCuaHangBanGiay.Commons.Validators.ProductDetails;
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
        private readonly Logger _logger = LogManager.GetLogger("MainLogger");

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
        public async Task<IActionResult> GetAllProductDetails()
        {
            var result = await Mediator.Send(new GetAllProductDetailQuery());
            return Ok(new ResponseObject(result));
        }

        [HttpGet("get-all-brand")]
        public async Task<IActionResult> GetAllBrands()
        {
            var result = await Mediator.Send(new GetAllBrandQuery());
            return Ok(new ResponseObject(result));
        }

        [HttpGet("get-all-product")]
        public async Task<IActionResult> GetAllProdcuts()
        {
            var result = await Mediator.Send(new GetAllProductQuery());
            return Ok(new ResponseObject(result));
        }

        [HttpGet("get-all-category")]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await Mediator.Send(new GetAllCategoryQuery());
            return Ok(new ResponseObject(result));
        }

        [HttpGet("get-all-color")]
        public async Task<IActionResult> GetAllColor()
        {
            var result = await Mediator.Send(new GetAllColorQuery());
            return Ok(new ResponseObject(result));
        }

        [HttpGet("get-all-material")]
        public async Task<IActionResult> GetAllMaterial()
        {
            var result = await Mediator.Send(new GetAllMaterialQuery());
            return Ok(new ResponseObject(result));
        }

        [HttpGet("get-all-size")]
        public async Task<IActionResult> GetAllSize()
        {
            var result = await Mediator.Send(new GetAllSizeQuery());
            return Ok(new ResponseObject(result));
        }

        [HttpPost("create-product")]
        public async Task<IActionResult> Insert([FromBody] CreateProductDetailCommand productDetailCommand)
        {
            AddProductDetailCommandValidator validation = new();
            var results = await validation.ValidateAsync(productDetailCommand);
            if (!results.IsValid)
            {
                // _logger.Info("Bug API Create Product File ProductDetailController in AdminManagementProductDetailController");
                // _logger.Debug("Lỗi ở chỗ này này anh em");
                _logger.Error(results.Errors.FirstOrDefault()?.ErrorMessage!);
                throw new RestApiException(results.Errors.FirstOrDefault()?.ErrorMessage!);
            }
            await Mediator.Send(productDetailCommand);
            return Ok();
        }

        [HttpPut("update-product")]
        public async Task<IActionResult> Update([FromBody] UpdateProductDetailCommand updateProductDetailCommand)
        {
            UpdateProductDetailCommandValidator validator = new();
            var results = await validator.ValidateAsync(updateProductDetailCommand);
            if (!results.IsValid) throw new RestApiException(results.Errors.FirstOrDefault()?.ErrorMessage!);
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
        public async Task<IActionResult> SearchProductDetail(
            [FromBody] GetProductDetailByConditionQuery query)
        {
            var result = await Mediator.Send(new GetProductDetailByConditionQuery());
            return Ok(new ResponseObject(result));
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