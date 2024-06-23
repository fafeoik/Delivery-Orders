using DeliveryOrders.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Repository
{
    public interface ICityRepository : IRepository<CityModel>
    {
        Task<Guid> AddAsync(CityModel model);
    }
}
