using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using QuanLyCuaHangBanGiay.Data.Abstract;

namespace QuanLyCuaHangBanGiay.Data;

public class DapperHelper : IDapperHelper
{
    private readonly string ConnectString = string.Empty;

    public DapperHelper(IConfiguration configuration)
    {
        ConnectString = configuration.GetConnectionString("ApplicationDbContext");
    }

    public async Task ExecuteNoReturn(string query, DynamicParameters? parameters = null,
        IDbTransaction? dbTransaction = null)
    {
        using (var dbConnection = new SqlConnection(ConnectString))
        {
            await dbConnection.ExecuteAsync(query, parameters, dbTransaction, commandType: CommandType.Text);
        }
    }

    public async Task<T> ExecuteReturnScalar<T>(string query, DynamicParameters? parameters,
        IDbTransaction? dbTransaction = null)
    {
        using (var dbConnection = new SqlConnection(ConnectString))
        {
            return await dbConnection.QueryFirstOrDefaultAsync<T>(query, parameters, dbTransaction,
                commandType: CommandType.Text);
        }
    }

    public async Task<IEnumerable<T>> ExecuteSqlReturnList<T>(string query, DynamicParameters? parameters = null,
        IDbTransaction? dbTransaction = null)
    {
        using (var dbConnection = new SqlConnection(ConnectString))
        {
            return await dbConnection.QueryAsync<T>(query, parameters, dbTransaction, commandType: CommandType.Text);
        }
    }

    public async Task<IEnumerable<T>> ExecuteStoreProcedureReturnList<T>(string query,
        DynamicParameters? parameters = null, IDbTransaction? dbTransaction = null)
    {
        using (var dbConnection = new SqlConnection(ConnectString))
        {
            return await dbConnection.QueryAsync<T>(query, parameters, dbTransaction,
                commandType: CommandType.StoredProcedure);
        }
    }
}