using Service.Handlers.Common;

namespace Service.Handlers.ProductDetails.Queries
{
    public abstract class ProductDetailDto : BaseDto
    {
        public string? NameProduct { get; set; }
        public string? NameBrand { get; set; }
        public string? NameCategory { get; set; }
        public string? NameColor { get; set; }
        public string? Image { get; set; }
        public string? NameMaterial { get; set; }
        public string? NameSize { get; set; }
        public string? Price { get; set; }
        public string? Quantity { get; set; }
    }
}