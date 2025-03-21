using MediatR;
using MeterSystem.Application.Commands.Requests;
using MeterSystem.Application.Queries.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MeterSystem.ServerAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetUserByIdQueryRequest { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddUserCommandRequest req)
        {
            return Ok(await _mediator.Send(req));
        }
    }
}
