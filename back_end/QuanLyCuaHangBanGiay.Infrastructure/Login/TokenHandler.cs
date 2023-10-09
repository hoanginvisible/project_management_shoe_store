using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Handlers.Employers.Queries;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Infrastructure.Login
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> CreateToken(EmployerDto employer)
        {
            var claims = new[]
            {
                // Primary key chinh cua token
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String,
                    _configuration["TokenBear:Issuer"]),
                // Server cap phat token
                new Claim(JwtRegisteredClaimNames.Iss, _configuration["TokenBear:Issuer"], ClaimValueTypes.String,
                    _configuration["TokenBear:Issuer"]),
                //  Time cap phat token
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToString(), ClaimValueTypes.Integer64,
                    _configuration["TokenBear:Issuer"]),
                // Tac gia chinh cua token
                new Claim(JwtRegisteredClaimNames.Aud, "WebApiRestful - .NetChannel", ClaimValueTypes.String,
                    _configuration["TokenBear:Issuer"]),
                // Time ton tai cua token
                new Claim(JwtRegisteredClaimNames.Exp, DateTime.Now.AddHours(3).ToString("yyyy/MM/dd hh:mm:ss"),
                    ClaimValueTypes.String, _configuration["TokenBear:Issuer"]),
                // new Claim(ClaimTypes.NameIdentifier, employer.Id.ToString(), ClaimValueTypes.String, ""),
                new Claim(ClaimTypes.Name, employer.Email!, ClaimValueTypes.String, _configuration["TokenBear:Issuer"]),
                new Claim("Username", employer.Email!, ClaimValueTypes.String, "")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenBear:SignatureKey"]));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenInfo = new JwtSecurityToken
            (
                issuer: _configuration["TokenBear:Issuer"],
                audience: _configuration["TokenBear:Audience"],
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(3),
                credential
            );
            string token = new JwtSecurityTokenHandler().WriteToken(tokenInfo);
            return await Task.FromResult(token);
        }

        public Task ValidationToken(TokenValidatedContext context)
        {
            var claims = context.Principal?.Claims.ToList();
            if (claims != null && claims.Count == 0)
            {
                context.Fail("This token contains no infomation");
                return Task.CompletedTask;
            }

            var identity = (ClaimsIdentity)context.Principal?.Identities!;
            if (identity.FindFirst(JwtRegisteredClaimNames.Iss) == null)
            {
                context.Fail("This  token is not issued by point entry");
                return Task.CompletedTask;
            }

            if (identity.FindFirst("Username") == null)
            {
                // string? username = identity.FindFirst("Username")?.Value;
            }

            return Task.CompletedTask;
        }
    }
}