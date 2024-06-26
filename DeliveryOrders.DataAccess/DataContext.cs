using DeliveryOrders.DataAccess.Configurations;
using DeliveryOrders.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.DataAccess
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }
        public DbSet<CityModel> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
