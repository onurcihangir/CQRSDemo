using MediatR;
using MeterSystem.Application.Commands.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterSystem.Application.Commands.Requests
{
    public class AddProductCommandRequest : IRequest<AddProductCommandResponse>
    {
        public required string Code { get; set; }
    }
}
