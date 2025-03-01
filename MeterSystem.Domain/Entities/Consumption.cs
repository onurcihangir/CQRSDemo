using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterSystem.Domain.Entities
{
    [Table("Consumptions")]
    public class Consumption : BaseEntity
    {
        public double Value { get; set; }
        public required string ProductCode { get; set; }
    }
}
