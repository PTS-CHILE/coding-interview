using Microsoft.EntityFrameworkCore;
using Paytech.CodingInterview.API.Data;
using Paytech.CodingInterview.API.Data.DTOs.Commands;
using Paytech.CodingInterview.API.Data.DTOs.Views;
using Paytech.CodingInterview.API.Data.Entities;
using Paytech.CodingInterview.API.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paytech.CodingInterview.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CodingInterviewContext _context;
        private readonly INotificationService _notificationService;

        public CategoryService(CodingInterviewContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task CreateAsync(CreateUpdateCategoryCommand createUpdateCategoryCommand)
        {
            if (!createUpdateCategoryCommand.IsValid())
            {
                _notificationService.AddValidation("Campos obrigatórios devem ser preenchidos.");
                return;
            }

            var category = new Category
            {
                Name = createUpdateCategoryCommand.Name,
                IsRemoved = false
            };

            _context.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Set<Category>().FirstOrDefaultAsync(p => p.Id == id && !p.IsRemoved);
            if (category == null)
            {
                _notificationService.AddValidation("Categoria não encontrada.");
                return;
            }

            category.IsRemoved = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryView>> GetCategoriesAsync()
        {
            return await _context
                .Set<Category>()
                .Where(p => !p.IsRemoved)
                .Select(p => new CategoryView
                {
                    Id = p.Id,
                    Name = p.Name,
                    CustomersCount = p.Customers.Count,
                    CreationDate = p.CreationDate
                })
                .ToListAsync();
        }

        public async Task<CategoryView> GetCategoryAsync(int id)
        {
            return await _context
                .Set<Category>()
                .Where(p => !p.IsRemoved && p.Id == id)
                .Select(p => new CategoryView
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(int id, CreateUpdateCategoryCommand updateCategoryCommand)
        {
            if (!updateCategoryCommand.IsValid())
            {
                _notificationService.AddValidation("Campos obrigatórios devem ser preenchidos.");
                return;
            }

            var category = await _context.Set<Category>().AsNoTracking().FirstOrDefaultAsync(p => p.Id == id && !p.IsRemoved);
            if (category == null)
            {
                _notificationService.AddValidation("Categoria não encontrada.");
                return;
            }

            category.Name = updateCategoryCommand.Name;
            await _context.SaveChangesAsync();
        }
    }
}
