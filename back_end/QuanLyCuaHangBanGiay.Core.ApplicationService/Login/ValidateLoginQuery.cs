using MediatR;
using QuanLyCuaHangBanGiay.Core.Domain.Login;

namespace QuanLyCuaHangBanGiay.Core.ApplicationService.Login
{
    public record ValidateLoginQuery(LoginParameter parameter) : IRequest<string?>
    {
    }
}