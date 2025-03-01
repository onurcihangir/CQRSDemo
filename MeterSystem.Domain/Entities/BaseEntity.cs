using MeterSystem.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterSystem.Domain.Entities
{
    public class BaseEntity : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
