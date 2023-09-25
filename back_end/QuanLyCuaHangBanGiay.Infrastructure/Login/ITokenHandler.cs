using Application.Handlers.Employer.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Infrastructure.Login
{
    public interface ITokenHandler
    {
        Task<string> CreateToken(EmployerDto employerDto);
        Task ValidationToken(TokenValidatedContext context);
    }
}