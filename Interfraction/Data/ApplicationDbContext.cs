using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
        DbSet<Customer> customers { get; set; }
        DbSet<DeliveryPerson> deliveryPersons { get; set;}
        DbSet<Order> orders { get; set; }
        DbSet<DeliveryService> deliveryServices { get; set; }
        DbSet<Payment> payments { get; set; }
        DbSet<Vehicle> vehicles { get; set; }

    }
 }
