using System.Reflection;
using Infrastructure.Login;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuanLyCuaHangBanGiay.Data;
using QuanLyCuaHangBanGiay.Data.Abstract;
using QuanLySinhVien.Model.ProductDetail.Queries;
using Service;
using Service.Employer.Queries;
using Service.Impl;

namespace Infrastructure.Configurations;

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