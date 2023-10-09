using System.Data;
using Dapper;
using Data.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class DapperHelper : IDapperHelper
    {
        private readonly string _connectString;

        public DapperHelper(IConfiguration configuration)
        {
            _connectString = configuration.GetConnectionString("ApplicationDbContext");
        }

        public async Task ExecuteNoReturn(string query, DynamicParameters? parameters = null,
            IDbTransaction? dbTransaction = null)
        {
            await using var dbConnection = new SqlConnection(_connectString);
            await dbConnection.OpenAsync();
            await using var transaction = dbConnection.BeginTransaction();
            try
            {
                await dbConnection.ExecuteAsync(query, parameters, dbTransaction,
                    commandType: CommandType.Text);
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }


        public async Task<T> ExecuteReturnScalar<T>(string query, DynamicParameters? parameters,
            IDbTransaction? dbTransaction = null)
        {
            await using var dbConnection = new SqlConnection(_connectString);
            await dbConnection.OpenAsync();
            await using var transaction = dbConnection.BeginTransaction();
            try
            {
                var result = await dbConnection.QueryFirstOrDefaultAsync<T>(query, parameters, dbTransaction,
                    commandType: CommandType.Text);
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<IEnumerable<T>> ExecuteSqlReturnList<T>(string query, DynamicParameters? parameters = null,
            IDbTransaction? dbTransaction = null)
        {
            await using var dbConnection = new SqlConnection(_connectString);
            await dbConnection.OpenAsync();
            await using var transaction = dbConnection.BeginTransaction();
            try
            {
                var result = await dbConnection.QueryAsync<T>(query, parameters, dbTransaction,
                    commandType: CommandType.Text);
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<IEnumerable<T>> ExecuteStoreProcedureReturnList<T>(string query,
            DynamicParameters? parameters = null, IDbTransaction? dbTransaction = null)
        {
            await using var dbConnection = new SqlConnection(_connectString);
            await dbConnection.OpenAsync();
            await using var transaction = dbConnection.BeginTransaction();
            try
            {
                var result = await dbConnection.QueryAsync<T>(query, parameters, dbTransaction,
                    commandType: CommandType.StoredProcedure);
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}