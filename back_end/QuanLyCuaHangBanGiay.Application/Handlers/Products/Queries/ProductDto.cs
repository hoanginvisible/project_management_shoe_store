using Service.Handlers.Common;

namespace Service.Handlers.Products.Queries
{
    public class ProductDto : BaseDto
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
}