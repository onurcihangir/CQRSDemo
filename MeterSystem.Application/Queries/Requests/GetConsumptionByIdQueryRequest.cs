using MediatR;
using MeterSystem.Application.Queries.Responses;

namespace MeterSystem.Application.Queries.Requests
{
    public class GetConsumptionByIdQueryRequest : IRequest<GetConsumptionByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
