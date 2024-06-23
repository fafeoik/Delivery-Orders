using DeliveryOrders.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Repository.Implementations
{
    public class DataContextRepository<T> : Repository<T, DataContext>
     where T : class
    {
        public DataContextRepository(DataContext context) : base(context)
        {
        }
    }
}
