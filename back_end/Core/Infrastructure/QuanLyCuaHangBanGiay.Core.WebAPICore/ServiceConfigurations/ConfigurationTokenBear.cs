using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using QuanLyCuaHangBanGiay.Core.Domain.Repositories;
using QuanLyCuaHangBanGiay.Core.WebAPI.Login;

namespace QuanLyCuaHangBanGiay.Core.WebAPIi.ServiceConfigurations
{
    public static class ConfigurationTokenBear
    {
        public static void RegisterTokenBear(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILoginRepository, LoginRepository>();
            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["JwtSetting:Key"]!)
                        ),
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true
                    };
                });

            services.AddAuthentication();
        }
    }
}