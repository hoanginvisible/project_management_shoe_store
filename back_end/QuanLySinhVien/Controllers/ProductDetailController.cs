using Application.Handlers.ProductDetail.Command;
using Application.Handlers.ProductDetail.Queries;
using Infrastructure.Login;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Validator;
using Service.Handlers.ProductDetail.Queries;

namespace QuanLyCuaHangBanGiay.Controllers
{
    // [Authorize]
    [Route("api/admin/product-management")]
    public class ProductDetailController : ApiControllerBase
    {
        private readonly ITokenHandler _tokenHandler;

        public ProductDetailController(ITokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;
        }

        [HttpGet("get-page-product")]
        public async Task<IEnumerable<ProductDetailDto>> GetProductDetails([FromQuery] int page = 1)
        {
            return await Mediator.Send(new GetProductDetailsQuery { PageNumber = page });
        }

        [HttpGet("get-all-product")]
        public async Task<IEnumerable<ProductDetailDto>> GetAllProductDetails()
        {
            return await Mediator.Send(new GetAllProductDetailQuery());
        }

        [HttpPost("create-product")]
        public async Task<IActionResult> Insert([FromBody] CreateProductDetailCommand productDetailCommand)
        {
            AddProductDetailCommandValidator validation = new();
            var results = await validation.ValidateAsync(productDetailCommand);
            if (!results.IsValid)
            {
                string builder = "";
                foreach (var failure in results.Errors)
                {
                    builder += (failure.PropertyName + failure.ErrorMessage + "\n");
                }
                return BadRequest(builder);
                // return BadRequest(new Reponse("dau buoi", false));
            }
            await Mediator.Send(productDetailCommand);
            return Ok();
        }

        [HttpDelete("delete-product")]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            return Ok(await Mediator.Send(new DeleteProductDetailCommand { id = id }));
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