using AutoMapper;
using MediatR;
using MeterSystem.Application.Queries.Requests;
using MeterSystem.Application.Queries.Responses;
using MeterSystem.Infrastructure.Abstract;

namespace MeterSystem.Application.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);
            var mapUser = _mapper.Map<GetUserByIdQueryResponse>(user);
            return await Task.FromResult(mapUser);
        }
    }
}
