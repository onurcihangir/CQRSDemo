using MeterSystem.Domain.Entities;
using MeterSystem.SecondApi.Controllers;

namespace GraphQL.Gateway.Model
{
    [GraphQLDescription("AggregatedData")]
    public class AggregatedData
    {
        [GraphQLDescription("Consumption")]
        public Consumption? Consumption { get; set; }
        [GraphQLDescription("Test")]
        public TestModel? Test { get; set; }
    }
}
