﻿using DeliveryOrders.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Repository
{
    public interface IAddressRepository : IRepository<AddressModel>
    {
        Task<Guid> AddAsync(AddressModel model);
    }
}
