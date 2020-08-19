using Microsoft.AspNetCore.Mvc;
using Paytech.CodingInterview.API.Services.Interfaces;

namespace Paytech.CodingInterview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumsController : ControllerBase
    {
        private readonly ICommonService _service;

        public EnumsController(ICommonService commonService)
        {
            _service = commonService;
        }

        [HttpGet]
        [Route("customerstatustypes")]
        public IActionResult GetCustomerStatusValues()
        {
            return Ok(_service.GetCustomerStatusValues());
        }
    }
}
