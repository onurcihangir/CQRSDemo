using MediatR;
using MeterSystem.Application.Commands.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterSystem.Application.Commands.Requests
{
    public class AddConsumptionCommandRequest : IRequest<AddConsumptionCommandResponse>
    {
        public required string ProductCode { get; set; }
        public double Value { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
