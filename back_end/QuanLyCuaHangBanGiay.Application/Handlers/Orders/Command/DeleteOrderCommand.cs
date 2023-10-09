using MediatR;

namespace Service.Handlers.Orders.Command
{
    public record DeleteOrderCommand : IRequest<string>
    {
        public string? IdOrder { get; set; }
    }
}