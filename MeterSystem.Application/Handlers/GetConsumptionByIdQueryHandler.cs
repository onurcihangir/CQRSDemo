using AutoMapper;
using MediatR;
using MeterSystem.Application.Queries.Requests;
using MeterSystem.Application.Queries.Responses;
using MeterSystem.Domain.Entities;
using MeterSystem.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionService.Application.Handlers
{
    public class GetConsumptionByIdQueryHandler : IRequestHandler<GetConsumptionByIdQueryRequest, GetConsumptionByIdQueryResponse>
    {
        private readonly IConsumptionRepository _consumptionRepository;
        private readonly IMapper _mapper;
        public GetConsumptionByIdQueryHandler(IConsumptionRepository consumptionRepository, IMapper mapper)
        {
            _consumptionRepository = consumptionRepository;
            _mapper = mapper;
        }

        public async Task<GetConsumptionByIdQueryResponse> Handle(GetConsumptionByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var consumption = await _consumptionRepository.GetById(request.Id);
            var mapConsumption = _mapper.Map<GetConsumptionByIdQueryResponse>(consumption);
            return await Task.FromResult(mapConsumption);
        }
    }
}
