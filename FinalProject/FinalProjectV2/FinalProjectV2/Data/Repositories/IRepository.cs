using System.Linq.Expressions;

namespace FinalProjectV2.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> List(Expression<Func<T, bool>>? where = null);
        T? Get(Expression<Func<T, bool>> where);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}

