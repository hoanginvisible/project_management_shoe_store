using MediatR;

namespace Service.Handlers.ProductDetails.Command
{
    public record UpdateProductDetailCommand : IRequest<bool>
    {
        public string? Id { get; set; }
        public string? IdProduct { get; set; }
        public string? IdBrand { get; set; }
        public string? IdCategory { get; set; }
        public string? IdColor { get; set; }
        public string? Image { get; set; }
        public string? IdMaterial { get; set; }
        public string? IdSize { get; set; }
        public double? Price { get; set; }
        public long? Quantity { get; set; }
    }
}