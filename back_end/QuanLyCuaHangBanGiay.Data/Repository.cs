using System.Linq.Expressions;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ApplicationDbContext _applicationDbContext;

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

        public async Task<T> GetById(object id)
        {
            var result = await _applicationDbContext.Set<T>().FindAsync(id);
            if (result == null)
            {
                return null;
            }

            return result;
        }

        public async Task Insert(IEnumerable<T> entity)
        {
            // _ApplicationDbContext.Set<T>() dung de tra ve cac doi tuong duoc insert
            // AddAsync(entity) tao ra cac cau insert vao co so du lieu
            await _applicationDbContext.Set<T>().AddRangeAsync(entity);
            _applicationDbContext.SaveChanges();
        }

        public async Task Insert(T entity)
        {
            // _ApplicationDbContext.Set<T>() dung de tra ve cac doi tuong duoc insert
            // AddAsync(entity) tao ra cac cau insert vao co so du lieu
            await _applicationDbContext.Set<T>().AddAsync(entity);
            _applicationDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            EntityEntry
                entityEntry = _applicationDbContext.Entry<T>(entity); // lay ra entity tuong ung voi entity truyen vao
            entityEntry.State = EntityState.Modified; // danh dau entity nay da bi thay doi
            _applicationDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            EntityEntry entityEntry = _applicationDbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            _applicationDbContext.SaveChanges();
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            var entitis = _applicationDbContext.Set<T>().Where(expression).ToList();
            if (entitis.Count > 0)
            {
                _applicationDbContext.Set<T>().RemoveRange(entitis);
            }

            _applicationDbContext.SaveChanges();
        }

        public virtual IQueryable<T> Table => _applicationDbContext.Set<T>();
    }
}

