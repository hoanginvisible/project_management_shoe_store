using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyCuaHangBanGiay.Controllers; 

[Authorize(Roles = "ADMIN")]
public class testcontroller : ApiControllerBase
{
    [HttpGet("tesst")]
    public Task<IActionResult> getTesst()
    {
        throw new RestApiException("Ok đăng nhập thành công!");
    }
}