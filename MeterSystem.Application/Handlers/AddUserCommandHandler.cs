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
    public class AddUserCommandHandler : IRequestHandler<AddUserCommandRequest, AddUserCommandResponse>
    {
        private readonly IUserRepository __userRepository;
        private readonly IMapper _mapper;

        public AddUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            __userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<AddUserCommandResponse> Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            var newUser = await __userRepository.Create(user);
            return await Task.FromResult(_mapper.Map<AddUserCommandResponse>(newUser));
        }
    }
}
