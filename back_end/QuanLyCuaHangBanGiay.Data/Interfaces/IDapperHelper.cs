using System.Data;
using Dapper;

namespace Data.Interfaces
{
    public interface IDapperHelper
    {
        Task ExecuteNoReturn(string query, DynamicParameters? parameters = null, IDbTransaction? dbTransaction = null);

        Task<T> ExecuteReturnScalar<T>(string query, DynamicParameters? parameters = null,
            IDbTransaction? dbTransaction = null);

        Task<IEnumerable<T>> ExecuteSqlReturnList<T>(string query, DynamicParameters? parameters = null,
            IDbTransaction? dbTransaction = null);

        Task<IEnumerable<T>> ExecuteStoreProcedureReturnList<T>(string query, DynamicParameters? parameters = null,
            IDbTransaction? dbTransaction = null);
    }
}