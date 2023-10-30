using Dapper;
using QuanLyCuaHangBanGiay.Core.Domain.Login;
using QuanLyCuaHangBanGiay.Core.Domain.Repositories;
using QuanLyCuaHangBanGiay.Core.WebAPI.Dapper;

namespace QuanLyCuaHangBanGiay.Core.WebAPI.Login
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DapperContext dapperContext;

        public LoginRepository(DapperContext dapperContext)
        {
            this.dapperContext = dapperContext;
        }

        public async Task<T?> ValidateLogin<T>(LoginParameter parameter)
        {
            string query = LoginQueries.LOGIN;
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Email", parameter.Email);
            dynamicParameters.Add("@Password", parameter.Password);
            using var connection = dapperContext.CreateConnection();
            var result = await connection.QueryFirstOrDefaultAsync<T?>(query, parameter);
            return result;
        }
    }
}

