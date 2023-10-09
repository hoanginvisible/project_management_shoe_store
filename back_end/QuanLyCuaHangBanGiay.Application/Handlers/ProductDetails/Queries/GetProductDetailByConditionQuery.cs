using MediatR;

namespace Service.Handlers.ProductDetails.Queries
{
    public record GetProductDetailByConditionQuery : IRequest<IEnumerable<ProductDetailDto>>
    {
        public string? Product { get; set; }
        public string? Brand { get; set; }
        public string? Category { get; set; }
        public string? Color { get; set; }
        public string? Material { get; set; }
        public string? Size { get; set; }
        public double? PriceMin { get; set; }
        public double? PriceMax { get; set; }
        public long? QuantityMin { get; set; }
        public long? QuantityMax { get; set; }
    }
}