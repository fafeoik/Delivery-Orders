using DeliveryOrders.DataAccess;
using DeliveryOrders.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Repository.Implementations
{
    public class CityRepository : DataContextRepository<CityModel>, ICityRepository
    {
        public CityRepository(DataContext context) : base(context)
        {
        }

        public override async Task<Guid> AddAsync(CityModel model)
        {
            if(_context.Set<CityModel>().Any(c => c.Name == model.Name))
            {
                return _context.Set<CityModel>().Where(c => c.Name == model.Name).SingleOrDefault().Id;
            }

            await _context.Set<CityModel>().AddAsync(model);
            _ = await _context.SaveChangesAsync();
            return model.Id;
        }
    }
}
