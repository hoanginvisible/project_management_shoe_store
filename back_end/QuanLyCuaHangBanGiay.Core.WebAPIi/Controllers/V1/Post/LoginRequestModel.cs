namespace QuanLyCuaHangBanGiay.Core.WebAPIi.Controllers.V1.Post
{
    public class LoginRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginRequestModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}