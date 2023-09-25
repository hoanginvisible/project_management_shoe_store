using System.ComponentModel.DataAnnotations;

namespace Service.Services.Interfaces
{
    public class BrandModel
    {
        [Required] public string Code { get; set; }
        public string Name { get; set; }
    }
}