using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterSystem.Application.Commands.Responses
{
    public class AddProductCommandResponse
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string Code { get; set; }
    }
}
