using MediatR;
using MeterSystem.Application.Commands.Requests;
using MeterSystem.Application.Queries.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MeterSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConsumptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Task.Delay(4000).Wait(); // for ocelot caching test
            return Ok(await _mediator.Send(new GetConsumptionByIdQueryRequest { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddConsumptionCommandRequest req)
        {
            return Ok(await _mediator.Send(req));
        }
    }
}
