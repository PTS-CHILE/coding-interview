using Microsoft.AspNetCore.Mvc;
using Paytech.CodingInterview.API.Services.Interfaces;

namespace Paytech.CodingInterview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalProductsController : ControllerBase
    {
        private readonly IExternalProductService _service;

        public ExternalProductsController(IExternalProductService externalProductService)
        {
            _service = externalProductService;
        }

        [HttpGet]
        public IActionResult GetAsync()
        {
            return Ok(_service.GetProductsAsync());
        }
    }
}
