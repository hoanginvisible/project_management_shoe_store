using MediatR;

namespace Service.Handlers.ProductDetails.Command
{
    public record DeleteProductDetailCommand : IRequest<string>
    {
        public string? Id;
    }
}