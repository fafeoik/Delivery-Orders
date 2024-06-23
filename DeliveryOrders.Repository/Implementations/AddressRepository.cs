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
            if (_context.Set<AddressModel>().Any(a => a.AddressLine == model.AddressLine))
            {
                return _context.Set<AddressModel>().Where(a => a.AddressLine == model.AddressLine).SingleOrDefault().Id;
            }

            await _context.Set<AddressModel>().AddAsync(model);
            _ = await _context.SaveChangesAsync();
            return model.Id;
        }
    }
}
