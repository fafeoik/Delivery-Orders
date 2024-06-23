using DeliveryOrders.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.DataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderModel>
    {
        public void Configure(EntityTypeBuilder<OrderModel> builder)
        {
            builder.HasKey(o => o.Id);

            builder
                .HasOne(order => order.RecipientAddress)
                .WithMany(address => address.RecipentOrders)
                .HasForeignKey(order => order.RecipientAddressId);

            builder
                .HasOne(order => order.SenderAddress)
                .WithMany(address => address.SenderOrders)
                .HasForeignKey(order => order.SenderAddressId);
        }
    }
}
