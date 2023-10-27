using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using QuanLyCuaHangBanGiay.Core.Domain.Repositories;

namespace QuanLyCuaHangBanGiay.Core.ApplicationService.Login
{
    public class ValidateLoginQueryHandler : IRequestHandler<ValidateLoginQuery, string?>
    {
        private readonly ILoginRepository loginRepository;

        public ValidateLoginQueryHandler(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        public async Task<string?> Handle(ValidateLoginQuery request, CancellationToken cancellationToken)
        {
            var result = await loginRepository.ValidateLogin<string?>(request.parameter);
            if (!result.IsNullOrEmpty())
            {
                return GenerateJwtToken(request.parameter.Email, result, "12hfhlsiwrlnlfkjain");
            }
            throw new NotImplementedException();
        }

        public static string GenerateJwtToken(string email, string role, string? id)
        {
            var key = Encoding.UTF8.GetBytes("TestSuperSecretKeyToKeepSecurely"); // Change this to your secret key
            var tokenHandler = new JwtSecurityTokenHandler();
            id ??= "";
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Email, email), // Add user-specific claims as needed
                        new Claim(ClaimTypes.Role, role),
                        new Claim(ClaimTypes.NameIdentifier, id)
                    }
                ),
                Expires = DateTime.UtcNow.AddHours(3), // Token expires in 3 hour
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}