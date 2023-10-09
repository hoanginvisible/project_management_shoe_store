using MediatR;

namespace Service.Handlers.Orders.Queries
{
    public class GetIdOrderPendingPaymentQuery : IRequest<IEnumerable<string>>
    {
    }
}