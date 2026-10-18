using Microsoft.EntityFrameworkCore;
using UberMS.Data;
using UberMS.Repositorires.Interfaces;

namespace UberMS.Repositorires.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var result = await _dbSet.ToListAsync();

            return result;
        }

        public virtual async Task<T> GetById(int id)
        {
            var result = await _dbSet.FindAsync(id);

            return result;
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
