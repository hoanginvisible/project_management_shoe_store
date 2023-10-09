using MediatR;

namespace Service.Handlers.ProductDetails.Queries
{
    public record GetPageProductDetailsQuery : IRequest<IEnumerable<ProductDetailDto>> // Tham số trong IRequest là kiểu
        // dữ liệu mà nó trả về
    {
        public int PageSize { get; } = 4;
        public int PageNumber { get; init; } = 1;
    }
}