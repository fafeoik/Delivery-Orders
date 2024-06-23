using DeliveryOrders.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.DataAccess.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<AddressModel>
    {
        public void Configure(EntityTypeBuilder<AddressModel> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.City)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CityId);

            builder.HasMany(a => a.Orders)
                .WithOne(o => o.RecipientAddress)
                .HasForeignKey(o => o.RecipientAddressId);

            builder.HasMany(a => a.Orders)
               .WithOne(o => o.SenderAddress)
               .HasForeignKey(o => o.SenderAddressId);
        }
    }
}
