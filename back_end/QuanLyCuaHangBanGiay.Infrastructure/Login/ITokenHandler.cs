using Microsoft.AspNetCore.Authentication.JwtBearer;
using QuanLyCuaHangBanGiay.Domain.Entities;
using Service.Employer.Queries;

namespace Infrastructure.Login;

public interface ITokenHandler
{
    Task<string> CreateToken(EmployerDto employerDto);
    Task ValidationToken(TokenValidatedContext context);
}