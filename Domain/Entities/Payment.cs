using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Payment: BaseEntity
    {
        public Order Orders { get; set; }
        public int OrderId { get; set; }


        public string Amount { get; set; }
        public string Status { get; set; }
    }
}
