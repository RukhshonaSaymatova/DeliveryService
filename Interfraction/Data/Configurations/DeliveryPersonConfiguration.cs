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
    public class DeliveryPersonConfiguration : IEntityTypeConfiguration<DeliveryPerson>
    {
        public void Configure(EntityTypeBuilder<DeliveryPerson> builder) 
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name)
                .IsRequired();
            builder.Property(d => d.Email)
                .IsRequired();
            builder.Property(d => d.ContactInfo)
                .IsRequired();
        }
    }
}
