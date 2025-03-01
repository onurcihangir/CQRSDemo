using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterSystem.Application.Commands.Responses
{
    public class AddConsumptionCommandResponse
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public double Value { get; set; }
        public required string ProductCode { get; set; }
    }
}
