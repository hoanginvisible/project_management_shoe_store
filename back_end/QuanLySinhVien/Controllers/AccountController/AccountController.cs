using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service.Handlers.Employers.Queries;
using Service.Login;

namespace QuanLyCuaHangBanGiay.Controllers.AccountController;

public class AccountController : ApiControllerBase
{
    private readonly ITokenHandler _tokenHandler;

    public AccountController(ITokenHandler tokenHandler)
    {
        _tokenHandler = tokenHandler;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Index([FromBody] GetEmployerByEmailAndPasswordQuery employer)
    {
        var result = await Mediator.Send(employer);

        if (result == null)
        {
            throw new RestApiException("Account not found!");
        }

        return await Task.Factory.StartNew(() => { return Ok(_tokenHandler.CreateToken(employer)); });
    }
}