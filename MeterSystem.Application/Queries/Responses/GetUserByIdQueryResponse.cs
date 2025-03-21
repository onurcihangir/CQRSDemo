using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterSystem.Application.Queries.Responses
{
    public class GetUserByIdQueryResponse
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Permissions { get; set; }
    }
}
