using System.Linq.Expressions;

namespace Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression);
        Task<T> GetById(object id);
        Task Insert(IEnumerable<T> entity);
        Task Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

        /// <summary>
        /// Delete by id 
        /// </summary>
        /// <param name="expression"></param>
        void Delete(Expression<Func<T, bool>> expression);
    }
}