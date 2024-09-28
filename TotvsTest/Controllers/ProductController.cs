using Microsoft.AspNetCore.Mvc;
using MediatR;
using TotvsTest_Model;

namespace TotvsTest_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "DoProcess")]
        public async Task<IActionResult> Process()
        {
            var result = await _mediator.Send(new ProductRequest());

            return Ok(result);
        }
    }
}
