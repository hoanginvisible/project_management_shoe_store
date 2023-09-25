using System.Linq.Expressions;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ApplicationDbContext _ApplicationDbContext;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            _ApplicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _ApplicationDbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return await _ApplicationDbContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            var result = await _ApplicationDbContext.Set<T>().FindAsync(id);
            if (result == null)
            {
                throw new NullReferenceException();
            }

            return result;
        }

        public async Task Insert(IEnumerable<T> entity)
        {
            // _ApplicationDbContext.Set<T>() dung de tra ve cac doi tuong duoc insert
            // AddAsync(entity) tao ra cac cau insert vao co so du lieu
            await _ApplicationDbContext.Set<T>().AddRangeAsync(entity);
            await Commit();
        }

        public void Update(T entity)
        {
            EntityEntry
                entityEntry = _ApplicationDbContext.Entry<T>(entity); // lay ra entity tuong ung voi entity truyen vao
            entityEntry.State = EntityState.Modified; // danh dau entity nay da bi thay doi
            _ApplicationDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            EntityEntry entityEntry = _ApplicationDbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            _ApplicationDbContext.SaveChanges();
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            var entitis = _ApplicationDbContext.Set<T>().Where(expression).ToList();
            if (entitis.Count > 0)
            {
                _ApplicationDbContext.Set<T>().RemoveRange(entitis);
            }

            _ApplicationDbContext.SaveChanges();
        }

        public virtual IQueryable<T> Table => _ApplicationDbContext.Set<T>();

        public async Task Commit()
        {
            await _ApplicationDbContext.SaveChangesAsync();
        }
    }
}