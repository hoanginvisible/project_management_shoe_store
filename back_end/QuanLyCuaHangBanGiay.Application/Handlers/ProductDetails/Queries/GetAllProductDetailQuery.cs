using MediatR;

namespace Service.Handlers.ProductDetails.Queries
{
    public record GetAllProductDetailQuery : IRequest<IEnumerable<ProductDetailDto>>;
}