using System.Linq.Expressions;
using System.Transactions;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data
{
    public sealed class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        
        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _applicationDbContext.Set<T>().ToListAsync();
            
        }

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return await _applicationDbContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T?> GetById(object id)
        {
            var result = await _applicationDbContext.Set<T>().FindAsync(id);
            return result;
        }

        public async Task Insert(IEnumerable<T> entity)
        {
            await using var transactionScope = await _applicationDbContext.Database.BeginTransactionAsync();
            try
            {
                await _applicationDbContext.Set<T>().AddRangeAsync(entity);
                await transactionScope.CommitAsync();
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                await transactionScope.RollbackAsync();
                throw;
            }
        }

        public async Task Insert(T entity)
        {
            using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                await _applicationDbContext.Set<T>().AddAsync(entity);
                transactionScope.Complete();
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                transactionScope.Dispose();
                throw;
            }
        }

        public void Update(T entity)
        {
            using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                EntityEntry
                    entityEntry = _applicationDbContext.Entry(entity);
                entityEntry.State = EntityState.Modified;
                transactionScope.Complete();
                _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                transactionScope.Dispose();
                throw;
            }
        }

        public void Delete(T entity)
        {
            using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                EntityEntry entityEntry = _applicationDbContext.Entry(entity);
                entityEntry.State = EntityState.Deleted;
                transactionScope.Complete();
                _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                transactionScope.Dispose();
                throw;
            }
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                var entities = _applicationDbContext.Set<T>().Where(expression).ToList();
                if (entities.Count > 0)
                {
                    _applicationDbContext.Set<T>().RemoveRange(entities);
                }

                transactionScope.Complete();
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {
                transactionScope.Dispose();
                throw;
            }
        }

        public IQueryable<T> Table => _applicationDbContext.Set<T>();
    }
}