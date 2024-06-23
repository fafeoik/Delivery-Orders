using DeliveryOrders.DataAccess;
using DeliveryOrders.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Repository.Implementations
{
    public class OrderRepository : DataContextRepository<OrderModel>, IOrderRepository
    {
        public OrderRepository(DataContext context) : base(context)
        {

        }
    }
}
