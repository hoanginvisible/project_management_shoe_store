using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace QuanLyCuaHangBanGiay.Core.WebAPI.Dapper
{
    public class DapperContext
    {
        private readonly string connectString;

        public DapperContext(IConfiguration configuration)
        {
            connectString = configuration.GetConnectionString("ApplicationDbContext");
        }
        public IDbConnection CreateConnection() => new SqlConnection(connectString);
    }
}

