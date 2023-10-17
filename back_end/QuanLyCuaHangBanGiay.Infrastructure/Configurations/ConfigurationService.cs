using Data;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Handlers.ProductDetails.Queries.Handler;

// using QuanLyCuaHangBanGiay.Service.Common.Behaviors;
// using QuanLyCuaHangBanGiay.Service.Common.Validators.ProductDetails;

// using QuanLyCuaHangBanGiay.Service.Common.Behaviors;

namespace Infrastructure.Configurations
{
    public static class ConfigurationService
    {
        // tu khoa this đăng kí RegisterContextDb với IServiceCollection
        // giup cho no tro thanh mot phan cua IServiceCollection
        public static void RegisterContextDb(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ApplicationDbContext"));
            });
        }

        public static void RegisterDi(this IServiceCollection service)
        {
            service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            service.AddScoped<IDapperHelper, DapperHelper>();
            // service.AddScoped<IBrandService, BrandService>();
            // service.AddScoped<IProductDetailService, ProductDetailService>();
            // service.AddScoped<IEmployerService, EmployerService>();
            // service.AddScoped<ITokenHandler, TokenHandler>();
        }

        public static void RegisterMediatR(this IServiceCollection service)
        {
            service.AddMediatR(
                cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllProductDetailQueryHandler).Assembly));
            // service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProductDetailCommand).Assembly));
        }

        public static void RegisterFluentValidation(this IServiceCollection service)
        {
            // service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            // service.AddTransient<IValidator<CreateProductDetailCommand>, AddProductDetailCommandValidator>();        }
            // service.AddTransient<IValidator<CreateProductDetailCommand>, AddProductDetailCommandValidator>();
        }
    }
}