using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterSystem.Application.Queries.Responses
{
    public class GetConsumptionByIdQueryResponse
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public double Value { get; set; }
        public required string ProductCode { get; set; }
    }
}
