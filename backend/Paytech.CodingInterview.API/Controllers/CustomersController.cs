using Microsoft.AspNetCore.Mvc;
using Paytech.CodingInterview.API.Data.DTOs.Commands;
using Paytech.CodingInterview.API.Data.Enumerators;
using Paytech.CodingInterview.API.Services.Interfaces;
using System.Threading.Tasks;

namespace Paytech.CodingInterview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService customerService)
        {
            _service = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(CustomerStatusType? status)
        {
            return Ok(await _service.GetCustomersAsync(status));
        }

        [HttpGet]
        [Route("{customerId:int}")]
        public async Task<IActionResult> GetAsync(int customerId)
        {
            return Ok(await _service.GetCustomerAsync(customerId));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateUpdateCustomerCommand createUpdateCustomerCommand)
        {
            await _service.CreateAsync(createUpdateCustomerCommand);
            return Ok();
        }

        [HttpPut]
        [Route("{customerId:int}")]
        public async Task<IActionResult> PutAsync(int customerId, CreateUpdateCustomerCommand createUpdateCustomerCommand)
        {
            await _service.UpdateAsync(customerId, createUpdateCustomerCommand);
            return Ok();
        }

        [HttpDelete]
        [Route("{customerId:int}")]
        public async Task<IActionResult> DeleteAsync(int customerId)
        {
            await _service.DeleteAsync(customerId);
            return Ok();
        }
    }
}
