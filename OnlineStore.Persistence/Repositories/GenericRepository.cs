using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Persistence.Contexts;

namespace OnlineStore.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly OnlineStoreContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(OnlineStoreContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IQueryable<T> query = _dbSet;
            query = IncludeAll(query, typeof(T));
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            IQueryable<T> query = _dbSet;
            query = IncludeAll(query, typeof(T));
            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        private IQueryable<T> IncludeAll(IQueryable<T> query, Type type, string parentProperty = null)
        {
            var navigationProperties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                           .Where(p => p.PropertyType.IsGenericType &&
                                                       p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>));

            foreach (var property in navigationProperties)
            {
                var propertyName = parentProperty == null ? property.Name : $"{parentProperty}.{property.Name}";
                query = query.Include(propertyName);

                var genericArgument = property.PropertyType.GetGenericArguments().First();
                query = IncludeAll(query, genericArgument, propertyName);
            }

            return query;
        }
    }
}
