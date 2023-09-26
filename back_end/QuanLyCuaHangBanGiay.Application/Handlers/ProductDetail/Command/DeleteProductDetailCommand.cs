using MediatR;

namespace Application.Handlers.ProductDetail.Command
{
    public record DeleteProductDetail(Guid id) : IRequest;
    
}

