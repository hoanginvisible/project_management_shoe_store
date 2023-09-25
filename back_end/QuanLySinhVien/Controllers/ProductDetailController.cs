using Application.Handlers.ProductDetail.Queries;
using Infrastructure.Login;
using Microsoft.AspNetCore.Mvc;
using Service.Handlers.ProductDetail.Queries;

namespace QuanLyCuaHangBanGiay.Controllers
{
    // [Authorize]
    [Route("api/admin/product-management")]
    public class ProductDetailController : ApiControllerBase
    {
        // private static string URL = Constans.UrlPath.URL_API_ADMIN.ToString() + "/product-management";
        private string URL = "api/admin/product-management";
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