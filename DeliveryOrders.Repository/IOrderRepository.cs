using DeliveryOrders.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Repository
{
    public interface IOrderRepository : IRepository<OrderModel>
    {
        Task<List<OrderModel>> GetAllAsync(Expression<Func<OrderModel, bool>>?[] predicates = null,
                                         int? take = null,
                                         params Expression<Func<OrderModel, object?>>[] includes);

        Task<OrderModel?> GetByIdAsync(Guid Id);
    }
}
