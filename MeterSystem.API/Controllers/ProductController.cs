using MediatR;
using MeterSystem.Application.Commands.Requests;
using MeterSystem.Application.Queries.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MeterSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetProductByIdQueryRequest { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProductCommandRequest req)
        {
            return Ok(await _mediator.Send(req));
        }
    }
}
