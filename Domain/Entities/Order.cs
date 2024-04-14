using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Status { get; set; }
        public string TotalAmount { get; set; }
        public string DeliveryAddress { get; set; }


        public Customer Customers { get; set; }
        public int CustomerId { get; set; }
   


        public DeliveryService DeliveryServices { get; set; }
        public int DeliveryServiceId { get; set; }



        public DeliveryPerson DeliveryPersons { get; set; }
        public int DeliveryPersonId { get; set; }


        public Vehicle Vehicles { get; set; }
        public int VehicleId { get; set; }


        public virtual ICollection<Payment> Payments { get; set; }
}
}
