namespace QuanLyCuaHangBanGiay.Core.Domain.Login
{
    public class LoginParameter
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginParameter(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}