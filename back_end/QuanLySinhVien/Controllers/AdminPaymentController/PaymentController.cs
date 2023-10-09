using Microsoft.AspNetCore.Mvc;
using Service.Handlers.Orders.Command;
using Service.Handlers.Orders.Queries;
using Service.Handlers.Products.Queries;

namespace QuanLyCuaHangBanGiay.Controllers.AdminPaymentController
{
    [Route("api/admin/payment")]
    public class PaymentController : ApiControllerBase
    {
        // [HttpPost("create-order")]
        // public async Task<ResponseObject> CreateOrder()
        // {
        //     var result = await Mediator.Send(new CreateOrderCommand());
        //     return new ResponseObject(data: result);
        // }

        [HttpGet("get-order-pending")]
        public async Task<IEnumerable<string>> GetOrderPending()
        {
            var result = await Mediator.Send(new GetIdOrderPendingPaymentQuery());
            return result;
        }

        [HttpGet("get-top-product-hot")]
        public async Task<IEnumerable<ProductTopTwentyHotDto>> GetTopProductHot()
        {
            var result = await Mediator.Send(new GetTopTwentyProductHotQuery());
            return result;
        }

        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder()
        {
            var result = await Mediator.Send(new CreateOrderCommand());
            return Ok(result);
        }

        [HttpDelete("delete-order")]
        public async Task<IActionResult> DeleteOrder([FromQuery] string id)
        {
            var result = await Mediator.Send(new DeleteOrderCommand { IdOrder = id });
            return Ok(result);
        }
    }
}