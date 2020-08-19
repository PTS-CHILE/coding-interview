using Paytech.CodingInterview.API.Data.DTOs.Commands;
using Paytech.CodingInterview.API.Data.DTOs.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paytech.CodingInterview.API.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryView> GetCategoryAsync(int id);
        Task<List<CategoryView>> GetCategoriesAsync();
        Task CreateAsync(CreateUpdateCategoryCommand createUpdateCategoryCommand);
        Task UpdateAsync(int id, CreateUpdateCategoryCommand updateCategoryCommand);
        Task DeleteAsync(int id);
    }
}