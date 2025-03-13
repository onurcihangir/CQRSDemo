using MeterSystem.Domain.Entities;
using MeterSystem.SecondApi.Controllers;

namespace GraphQL.Gateway.Model
{
    public class AggregatedData
    {
        public Consumption? Consumption { get; set; }
        public TestModel? Test { get; set; }
    }
}
