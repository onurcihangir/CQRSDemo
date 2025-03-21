using MediatR;
using MeterSystem.Application.Commands.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterSystem.Application.Commands.Requests
{
    public class AddUserCommandRequest : IRequest<AddUserCommandResponse>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Permissions { get; set; }
    }
}
