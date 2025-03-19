using MediatR;
using MeterSystem.Application.Queries.Responses;

namespace MeterSystem.Application.Queries.Requests
{
    public class GetProductByIdQueryRequest : IRequest<GetProductByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
