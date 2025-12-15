using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinalProjectV2.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbset;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public IQueryable<T> List(Expression<Func<T, bool>>? where = null)
            => where == null ? _dbset : _dbset.Where(where);

        public T? Get(Expression<Func<T, bool>> where)
            => _dbset.FirstOrDefault(where);

        public void Insert(T entity) => _dbset.Add(entity);
        public void Update(T entity) => _dbset.Update(entity);
        public void Delete(T entity) => _dbset.Remove(entity);
        public void Save() => _context.SaveChanges();
    }
}
