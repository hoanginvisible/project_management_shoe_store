using System.ComponentModel.DataAnnotations;

namespace QuanLySinhVien.Model;

public class BrandModel
{
    [Required]
    public string Code { get; set; }
    public string Name { get; set; }
}