using Microsoft.AspNetCore.Mvc;
using MediatR;
using TotvsTest_Model;

namespace TotvsTest_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SumController : Controller
    {
        private readonly IMediator _mediator;
        public SumController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "SumNumber")]
        public async Task<IActionResult> SumTwoNumbers([FromQuery] int firstNumber, [FromQuery] int secondNumber)
        {
            var result = await _mediator.Send(new SumRequest() { first_number = firstNumber, second_number = secondNumber });
            
            return Ok(result);
        }
    }
}
