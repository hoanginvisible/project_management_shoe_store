using Microsoft.AspNetCore.Authentication.JwtBearer;
using Service.Handlers.Employers.Queries;

namespace Service.Login
{
    public interface ITokenHandler
    {
        Task<string> CreateToken(EmployerDto employerDto);
        Task ValidationToken(TokenValidatedContext context);
    }
}