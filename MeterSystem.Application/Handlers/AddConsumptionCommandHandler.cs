using AutoMapper;
using MediatR;
using MeterSystem.Application.Commands.Requests;
using MeterSystem.Application.Commands.Responses;
using MeterSystem.Domain.Entities;
using MeterSystem.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterSystem.Application.Handlers
{
    public class AddConsumptionCommandHandler : IRequestHandler<AddConsumptionCommandRequest, AddConsumptionCommandResponse>
    {
        private readonly IConsumptionRepository _consumptionRepository;
        private readonly IMapper _mapper;

        public AddConsumptionCommandHandler(IConsumptionRepository consumptionRepository, IMapper mapper)
        {
            _consumptionRepository = consumptionRepository;
            _mapper = mapper;
        }

        public async Task<AddConsumptionCommandResponse> Handle(AddConsumptionCommandRequest request, CancellationToken cancellationToken)
        {
            var consumption = _mapper.Map<Consumption>(request);
            var newConsumption = await _consumptionRepository.Create(consumption);
            return await Task.FromResult(_mapper.Map<AddConsumptionCommandResponse>(newConsumption));
        }
    }
}
