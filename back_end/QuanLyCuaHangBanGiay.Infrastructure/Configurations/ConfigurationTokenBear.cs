using System.Text;
using Infrastructure.Login;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Configurations
{
    public static class ConfigurationTokenBear
    {
        public static void RegisterTokenBear(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
                {
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = configuration["TokenBear:Issuer"], //Domain name
                        ValidateIssuer = false,
                        ValidAudience = configuration["TokenBear:Audience"], //nguoi phat hanh
                        ValidateAudience = false,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(
                                    configuration["TokenBear:SignatureKey"])), //key private de validate token
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            var tokenHandler = context.HttpContext.RequestServices.GetRequiredService<ITokenHandler>();
                            return tokenHandler.ValidationToken(context);
                        },
                        OnAuthenticationFailed = context => { return Task.CompletedTask; },
                        OnMessageReceived = context => { return Task.CompletedTask; },
                        OnChallenge = context => { return Task.CompletedTask; }
                    };
                });
        }
    }
}