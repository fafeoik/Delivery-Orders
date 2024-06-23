using DeliveryOrders.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Repository.Implementations
{
    public class Repository<T, TContext> : IRepository<T>
    where T : class
    where TContext : DbContext
    {
        protected readonly TContext _context;

        public Repository(TContext dbContext) => _context = dbContext;

        public virtual Task<List<T>> GetAllAsync(Expression<Func<T, bool>>[]? predicates = null,  
                                            int? take = null,
                                            params Expression<Func<T, object?>>[] includes)       
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                query = includes.Aggregate(query, (currentQuery, include) => currentQuery.Include(include));

            if (predicates != null)
                query = predicates.Aggregate(query, (currentQuery, predicate) => currentQuery.Where(predicate));

            if (take != null)
                query = query.Take(take.Value);

            return query.ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(Guid Id) => await _context.Set<T>().FindAsync(Id);

        public virtual async Task<Guid> AddAsync(T entity)
        {
            var addedEntity = await _context.Set<T>().AddAsync(entity);
            _ = await _context.SaveChangesAsync();
            Guid id = Guid.Parse(addedEntity.Property("Id").CurrentValue.ToString());
            return id;
        }

        public virtual Task Update(T entity)
        {
            _ = _context.Set<T>().Update(entity);
            return _context.SaveChangesAsync();
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            _ = _context.Set<T>().Remove(entity);
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
