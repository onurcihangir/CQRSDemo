using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterSystem.Domain.Entities
{
    public class Product : BaseEntity
    {
        public required string Code { get; set; }
        public ICollection<Consumption>? Consumptions { get; set; }
    }
}
