using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configurations
{
    public class OrderConfiguration: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder) 
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Status).IsRequired();   
            builder.Property(o => o.TotalAmount).IsRequired();
            builder.Property(o => o.DeliveryAddress).IsRequired();


            builder.HasOne(o => o.Customers)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.DeliveryServices)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.DeliveryServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.DeliveryPersons)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.DeliveryPersonId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(o => o.Vehicles)
               .WithMany(v => v.Orders)
               .HasForeignKey(o => o.VehicleId)
               .OnDelete(DeleteBehavior.Cascade);
                
        }
    }
}
