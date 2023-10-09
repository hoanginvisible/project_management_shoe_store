using Service.Handlers.Common;

namespace Service.Handlers.Brands.Queries
{
    public class BrandDto : BaseDto
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
}