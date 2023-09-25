using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyCuaHangBanGiay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BaseApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}