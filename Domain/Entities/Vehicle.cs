using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Vehicle: BaseEntity
    {
        public string Type { get; set; }
        public string NumberPlate { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
