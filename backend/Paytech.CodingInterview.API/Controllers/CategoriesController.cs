using Microsoft.AspNetCore.Mvc;
using Paytech.CodingInterview.API.Data.DTOs.Commands;
using Paytech.CodingInterview.API.Services.Interfaces;
using System.Threading.Tasks;

namespace Paytech.CodingInterview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService categoryService)
        {
            _service = categoryService;
        }        

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _service.GetCategoriesAsync());
        }

        [HttpGet]
        [Route("{categoryId:int}")]
        public async Task<IActionResult> GetAsync(int categoryId)
        {
            return Ok(await _service.GetCategoryAsync(categoryId));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateUpdateCategoryCommand createUpdateCategoryCommand)
        {
            await _service.CreateAsync(createUpdateCategoryCommand);
            return Ok();
        }

        [HttpPut]
        [Route("{categoryId:int}")]
        public async Task<IActionResult> PutAsync(int categoryId, CreateUpdateCategoryCommand createUpdateCategoryCommand)
        {
            await _service.UpdateAsync(categoryId, createUpdateCategoryCommand);
            return Ok();
        }

        [HttpDelete]
        [Route("{categoryId:int}")]
        public async Task<IActionResult> DeleteAsync(int categoryId)
        {
            await _service.DeleteAsync(categoryId);
            return Ok();
        }
    }
}
