using Service.Handlers.Common;

namespace Service.Handlers.Colors.Queries
{
    public class ColorDto : BaseDto
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
}