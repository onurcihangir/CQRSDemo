using HotChocolate;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MeterSystem.Domain.Entities
{
    [Table("Consumptions")]
    public class Consumption : BaseEntity
    {
        public double Value { get; set; }
        [GraphQLIgnore]
        public required string ProductCode { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
    }
}
