using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeterSystem.SecondApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        // GET: api/test
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(new { Message = "Merhaba, .NET Core!" });
        //}

        // GET: api/test/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(new { Message = $"İstenen ID: {id}" });
        }

        // POST: api/test
        [HttpPost]
        public IActionResult Post([FromBody] TestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // İşlem başarılıysa
            return Ok(new { Message = "Veri başarıyla alındı", Data = model });
        }
    }

    public class TestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
