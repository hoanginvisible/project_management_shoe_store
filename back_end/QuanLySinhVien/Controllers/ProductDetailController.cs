using Infrastructure.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.ViewModel;
using Service.Handlers.ProductDetail.Queries;
using Service.Services.Interfaces;

namespace QuanLyCuaHangBanGiay.Controllers
{
    // [Authorize]
    [ApiController]
    public class ProductDetailController : Controller
    {
        // private static string URL = Constans.UrlPath.URL_API_ADMIN.ToString() + "/product-management";
        private string URL = "api/admin/product-management";
        private IProductDetailService _ProductDetailService;
        private IEmployerService _employerService;
        private readonly IMediator _mediator;
        private readonly ITokenHandler _tokenHandler;

        public ProductDetailController(IProductDetailService productDetailService, IEmployerService employerService,
            ITokenHandler tokenHandler)
        {
            _ProductDetailService = productDetailService;
            _employerService = employerService;
            _tokenHandler = tokenHandler;
        }

        [HttpGet("api/admin/product-management/get-all-product")]
        public async Task<IEnumerable<ProductDetailDto>> GetProductDetails([FromQuery] int page = 1)
        {
            return await _ProductDetailService.GetAllProductDetail(page);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] AccountModel accountModel)
        {
            if (accountModel == null)
            {
                return await Task.FromResult(BadRequest("User is not exist"));
            }

            var user = await _employerService.GetEmployer(accountModel.Email, accountModel.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            return await Task.Factory.StartNew(() => { return Ok(_tokenHandler.CreateToken(user)); });
        }
    }
}