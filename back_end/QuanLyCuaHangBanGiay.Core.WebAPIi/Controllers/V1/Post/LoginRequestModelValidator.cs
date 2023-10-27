using FluentValidation;

namespace QuanLyCuaHangBanGiay.Core.WebAPIi.Controllers.V1.Post
{
    public class LoginRequestModelValidator : AbstractValidator<LoginRequestModel>
    {
        public LoginRequestModelValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be null");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be null");
        }
    }
}