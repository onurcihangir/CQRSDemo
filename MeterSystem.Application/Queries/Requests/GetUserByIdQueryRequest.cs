using MediatR;
using MeterSystem.Application.Queries.Responses;

namespace MeterSystem.Application.Queries.Requests
{
    public class GetUserByIdQueryRequest : IRequest<GetUserByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
