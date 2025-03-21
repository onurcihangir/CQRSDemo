using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterSystem.Domain.Entities
{
    public class User : BaseEntity
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required List<string> Permissions { get; set; }
    }
}
