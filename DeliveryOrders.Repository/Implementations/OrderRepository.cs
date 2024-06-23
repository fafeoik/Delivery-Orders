using DeliveryOrders.DataAccess;
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
    public class OrderRepository : DataContextRepository<OrderModel>, IOrderRepository
    {
        public OrderRepository(DataContext context) : base(context)
        {

        }

        public override Task<List<OrderModel>> GetAllAsync(Expression<Func<OrderModel, bool>>?[] predicates = null,
                                         int? take = null,
                                         params Expression<Func<OrderModel, object?>>[] includes)
        {
            IQueryable<OrderModel> query = _context.Set<OrderModel>();

            query = query
                .Include(o => o.SenderAddress)
                    .ThenInclude(a => a.City)
                    .Include(o => o.RecipientAddress)
                    .ThenInclude(a => a.City);

            if (predicates != null)
                query = predicates.Aggregate(query, (currentQuery, predicate) => currentQuery.Where(predicate));

            if (take is not null)
                query = query.Take(take.Value);

            return query.ToListAsync();
        }

        public override async Task<OrderModel?> GetByIdAsync(Guid Id)
        {
            IQueryable<OrderModel> query = _context.Set<OrderModel>();
            query = query
                .Include(o => o.SenderAddress)
                    .ThenInclude(a => a.City)
                    .Include(o => o.RecipientAddress)
                    .ThenInclude(a => a.City);

            return await query.SingleOrDefaultAsync(order => order.Id == Id);
        }
    }
}
