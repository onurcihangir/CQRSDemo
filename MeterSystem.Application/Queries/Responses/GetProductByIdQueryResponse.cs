using MeterSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterSystem.Application.Queries.Responses
{
    public class GetProductByIdQueryResponse
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string Code { get; set; }
        public ICollection<Consumption>? Consumptions { get; set; }
    }
}
