﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.DataAccess.Models
{
    public class CityModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string? Name { get; set; }
        public List<AddressModel>? Addresses { get; set; }
    }
}
