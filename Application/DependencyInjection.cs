using Application.Services;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IBaseService<Customer>, CustomerService>();
            services.AddScoped<IBaseService<DeliveryPerson>, DeliveryPersonService>();
            services.AddScoped<IBaseService<DeliveryService>, DeliveryServiceService>();
            services.AddScoped<IBaseService<Order>, OrderService>();
            services.AddScoped<IBaseService<Payment>, PaymentService>();
            services.AddScoped<IBaseService<Vehicle>, VehicleService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
