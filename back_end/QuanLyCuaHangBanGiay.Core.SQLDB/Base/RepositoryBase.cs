using System.ComponentModel.DataAnnotations;
using Dapper;
using QuanLyCuaHangBanGiay.Core.Domain.Repositories;
using QuanLyCuaHangBanGiay.Core.WebAPI.Dapper;

namespace QuanLyCuaHangBanGiay.Core.WebAPI.Base
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DapperContext _context;

        protected RepositoryBase(DapperContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> FindByIdAsync(string sql, DynamicParameters dynamicParameters)
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<TEntity>(sql, dynamicParameters);
        }

        public async Task<IEnumerable<TEntity>> Filter(string sql, DynamicParameters dynamicParameters)
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<TEntity>(sql, dynamicParameters);
        }

        public DynamicParameters SetParameters(object parameter)
        {
            throw new NotImplementedException();
        }

        public Task RunValidator<ValidatingObject>(string queryQueue, DynamicParameters dynamicParameters, List<ValidationResult> validationResults)
        {
            throw new NotImplementedException();
        }
    }
}