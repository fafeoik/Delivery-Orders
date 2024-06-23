using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Repository
{
    public interface IRepository<T> : IReadOnlyRepository<T>
   where T : class
    {
        Task<Guid> AddAsync(T entity);
        Task Update(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
