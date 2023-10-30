using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace QuanLyCuaHangBanGiay.Core.ApplicationService;

public static class ServiceCollectionExtensions
{
    public static void AddCoreApplicationService(this IServiceCollection services)
    {
        services.AddMediator();
    }
    private static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}