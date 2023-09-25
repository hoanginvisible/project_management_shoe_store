using Microsoft.AspNetCore.Authentication.JwtBearer;
using Service.Handlers.Employer.Queries;

namespace Infrastructure.Login
{
    public interface ITokenHandler
    {
        Task<string> CreateToken(EmployerDto employerDto);
        Task ValidationToken(TokenValidatedContext context);
    }
}