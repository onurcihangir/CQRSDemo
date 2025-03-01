using AutoMapper;
using MeterSystem.Application.Commands.Requests;
using MeterSystem.Application.Commands.Responses;
using MeterSystem.Application.Queries.Requests;
using MeterSystem.Application.Queries.Responses;
using MeterSystem.Domain.Entities;

namespace CqrsMediatR.Mapper
{
    public class RegisterMapper : Profile
    {
        public RegisterMapper()
        {
            CreateMap<GetConsumptionByIdQueryRequest, Consumption>();
            CreateMap<Consumption, GetConsumptionByIdQueryResponse>();
            CreateMap<AddConsumptionCommandRequest, Consumption>();
            CreateMap<Consumption, AddConsumptionCommandResponse>();
        }
    }
}