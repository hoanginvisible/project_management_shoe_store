using Service.Handlers.Common;

namespace Service.Handlers.Products.Queries
{
    public class ProductTopTwentyHotDto : BaseDto
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? Quantity { get; set; }
        public string? Image { get; set; }
        public string? Color { get; set; }
    }
}