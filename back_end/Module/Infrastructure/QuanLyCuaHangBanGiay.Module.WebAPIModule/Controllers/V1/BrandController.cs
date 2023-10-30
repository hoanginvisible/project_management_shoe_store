using System.Net;
using ClassLibrary1.Brand.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuanLyCuaHangBanGiay.Core.WebAPIi.ResponseObjects;

namespace QuanLyCuaHangBanGiay.Module.WebAPIu.Controllers.V1
{
    [Route("api/v1/module/brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator Mediator;

        public BrandController(IMediator mediator)
        {
            this.Mediator = mediator;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllBrand()
        {
            var result = await Mediator.Send(new GetAllBrandQuery());
            return Ok(new SuccessReponse(HttpStatusCode.OK, result, "Get all brand success"));
        }
    }
}