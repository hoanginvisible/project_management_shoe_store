using System.ComponentModel.DataAnnotations;

namespace QuanLySinhVien.ViewModel;

public class AccountModel
{
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
}