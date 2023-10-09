using Service.Handlers.Common;

namespace Service.Handlers.Materials.Queries
{
    public class MaterialDto : BaseDto
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
}