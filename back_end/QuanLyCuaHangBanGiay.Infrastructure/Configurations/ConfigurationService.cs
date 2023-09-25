using System.Reflection;
using Data;
using Data.Interfaces;
using Infrastructure.Login;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Handlers.Employer.Queries;
using Service.Handlers.ProductDetail.Queries;
using Service.Services.Implementations;
using Service.Services.Interfaces;

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

        public static void RegisterDI(this IServiceCollection service)
        {
            service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            service.AddScoped<IDapperHelper, DapperHelper>();
            service.AddScoped<IBrandService, BrandService>();
            service.AddScoped<IProductDetailService, ProductDetailService>();
            service.AddScoped<IEmployerService, EmployerService>();
            service.AddScoped<ITokenHandler, TokenHandler>();
        }

        public static void RegisterMediatR(this IServiceCollection service)
        {
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            service
                .AddScoped<IRequestHandler<GetProductDetailsQuery, IEnumerable<ProductDetailDto>>,
                    GetProductDetailsQueryHandler>();
            service
                .AddScoped<IRequestHandler<GetEmployerQuery, EmployerDto>,
                    GetEmployerQueryHandle>();
        }
    }
}