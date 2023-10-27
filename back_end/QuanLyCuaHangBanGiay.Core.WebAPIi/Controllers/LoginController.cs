using System.Net;
using System.Text;
using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QuanLyCuaHangBanGiay.Core.ApplicationService.Login;
using QuanLyCuaHangBanGiay.Core.Domain.Login;
using QuanLyCuaHangBanGiay.Core.WebAPIi.Controllers.V1.Post;
using QuanLyCuaHangBanGiay.Core.WebAPIi.ResponseObjects;

namespace QuanLyCuaHangBanGiay.Core.WebAPIi.Controllers
{
    [Route("api/v1/core/authentication")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IValidator<LoginRequestModel> validator;


        public LoginController(IMediator mediator, IValidator<LoginRequestModel> validator)
        {
            this.mediator = mediator;
            this.validator = validator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel request)
        {
            var validateResult = await validator.ValidateAsync(request);
            if (!validateResult.IsValid)
            {
                var errorMessage = new StringBuilder();
                foreach (var failure in validateResult.Errors)
                {
                    errorMessage.AppendLine(failure.PropertyName + ": " + failure.ErrorMessage);
                }

                throw new ValidationException(errorMessage.ToString());
            }

            var parameter = request.Adapt<LoginParameter>();
            var result = await mediator.Send(new ValidateLoginQuery(parameter));
            if (result.IsNullOrEmpty())
            {
                return Unauthorized(
                    new ErrorResponse(HttpStatusCode.Unauthorized, "Email or password is wrong")
                );
            }
            else
            {
                return Ok(
                    new SuccessReponse(HttpStatusCode.OK, new { token = result }, "Login success")
                );
            }
        }
    }
}