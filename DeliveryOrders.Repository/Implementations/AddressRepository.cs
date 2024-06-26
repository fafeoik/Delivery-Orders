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

        public override async Task<Guid> AddAsync(AddressModel addressModel)
        {
            if (_context.Set<AddressModel>().Any(a => a.AddressLine == addressModel.AddressLine) && _context.Set<AddressModel>().Any(a => a.CityId == addressModel.CityId))
            {
                var context = _context.Set<AddressModel>();
                var test = context.Where(a => a.AddressLine == addressModel.AddressLine).Where(a => a.CityId == addressModel.CityId).ToList();
                return test.SingleOrDefault().Id;
            }

            await _context.Set<AddressModel>().AddAsync(addressModel);
            _ = await _context.SaveChangesAsync();
            return addressModel.Id;
        }
    }
}
