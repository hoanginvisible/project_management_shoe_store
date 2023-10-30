using ClassLibrary1.Brand.Query;
using Common.Brand;
using Common.Repositories.Brand.Command;
using Common.Repositories.Brand.Query;
using QuanLyCuaHangBanGiay.Module.SQLDB.Brand.Query;

namespace QuanLyCuaHangBanGiay.Module.WebAPIu.ServiceConfigurations
{
    public static class ModuleManagerServiceConfiguration
    {
        private static void RegisterDomainServices(this IServiceCollection service)
        {
            service.AddTransient<BrandService>();
        }

        public static void RegisterBrandManagerFluentValidator(this IServiceCollection service)
        {
        }

        public static void RegisterRepositories(this IServiceCollection service)
        {
            // service.AddScoped<IBrandCommandRepository, BrandCommandRepository>();
            service.AddScoped<IBrandQueryRepository, BrandQueryRepository>();
            service.AddMediatR(
                cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllBrandQueryHandler).Assembly));
        }

        public static void RegisterBrandManagerConfigurations(this IServiceCollection service)
        {
            service.RegisterDomainServices();
            service.RegisterBrandManagerFluentValidator();
            service.RegisterRepositories();
        }
    }
}