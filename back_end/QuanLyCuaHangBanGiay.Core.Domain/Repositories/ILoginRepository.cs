using QuanLyCuaHangBanGiay.Core.Domain.Login;

namespace QuanLyCuaHangBanGiay.Core.Domain.Repositories
{
    public interface ILoginRepository
    {
        Task<T?> ValidateLogin<T>(LoginParameter parameter);
    }
}