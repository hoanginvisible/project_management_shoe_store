using Microsoft.AspNetCore.Mvc;
using QuanLyCuaHangBanGiay.Commons;
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
        public async Task<IActionResult> GetOrderPending()
        {
            var result = await Mediator.Send(new GetIdOrderPendingPaymentQuery());
            return Ok(new ResponseObject(result));
        }

        [HttpGet("get-top-product-hot")]
        public async Task<IActionResult> GetTopProductHot()
        {
            var result = await Mediator.Send(new GetTopTwentyProductHotQuery());
            return Ok(new ResponseObject(result));
        }

        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder()
        {
            var result = await Mediator.Send(new CreateOrderCommand());
            return Ok(new ResponseObject(result));
        }

        [HttpDelete("delete-order")]
        public async Task<IActionResult> DeleteOrder([FromQuery] string id)
        {
            var result = await Mediator.Send(new DeleteOrderCommand { IdOrder = id });
            return Ok(result);
        }
    }
}