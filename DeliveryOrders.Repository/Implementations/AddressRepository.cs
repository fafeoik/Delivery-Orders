using DeliveryOrders.DataAccess;
using DeliveryOrders.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Repository.Implementations
{
    public class AddressRepository : DataContextRepository<AddressModel>, IAddressRepository
    {
        public AddressRepository(DataContext context) : base(context)
        {
        }

        public override async Task<Guid> AddAsync(AddressModel model)
        {
            if (_context.Set<AddressModel>().Any(a => a.AddressLine == model.AddressLine) && _context.Set<AddressModel>().Any(a => a.CityId == model.CityId))
            {
                var context = _context.Set<AddressModel>();
                var test = context.Where(a => a.AddressLine == model.AddressLine).Where(a => a.CityId == model.CityId).ToList();
                return test.SingleOrDefault().Id;
            }

            await _context.Set<AddressModel>().AddAsync(model);
            _ = await _context.SaveChangesAsync();
            return model.Id;
        }
    }
}
