using FluentValidation;
using QuanLyCuaHangBanGiay.Core.ApplicationService.Login;
using QuanLyCuaHangBanGiay.Core.WebAPI.Dapper;
using QuanLyCuaHangBanGiay.Core.WebAPIi.Controllers.V1.Mapster;
using QuanLyCuaHangBanGiay.Core.WebAPIi.Controllers.V1.Post;

namespace QuanLyCuaHangBanGiay.Core.WebAPIi.ServiceConfigurations
{
    public static class BaseServiceConfigurations
    {
        private static void RegisterDatabase(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
        }
        
        private static void RegisterBaseMediatr(this IServiceCollection services)
        {
            services.AddMediatR(
                cfg => cfg.RegisterServicesFromAssemblies(typeof(ValidateLoginQuery).Assembly)
            );
        }
        
        private static void RegisterBaseFluentValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<LoginRequestModel>, LoginRequestModelValidator>();
            // services.AddTransient<FluentValidationProcessor>();
        }
        
        public static void RegisterCoreConfigurations(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.RegisterBaseFluentValidator();
            services.RegisterBaseMediatr();
            // services.RegisterCors();
            services.RegisterDatabase();
            MappingConfig.ConfigureMappings();
        }
    }
}