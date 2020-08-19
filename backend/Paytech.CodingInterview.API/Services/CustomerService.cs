using Microsoft.EntityFrameworkCore;
using Paytech.CodingInterview.API.Data;
using Paytech.CodingInterview.API.Data.DTOs.Commands;
using Paytech.CodingInterview.API.Data.DTOs.Views;
using Paytech.CodingInterview.API.Data.Entities;
using Paytech.CodingInterview.API.Data.Enumerators;
using Paytech.CodingInterview.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paytech.CodingInterview.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CodingInterviewContext _context;
        private readonly INotificationService _notificationService;

        public CustomerService(CodingInterviewContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<List<CustomerView>> GetCustomersAsync(CustomerStatusType? status)
        {
            return await _context
                .Set<Customer>()
                .Where(p => !p.IsRemoved && (!status.HasValue || p.Status == status.Value))
                .Select(p => new CustomerView
                {
                    Id = p.Id,
                    DocumentNumber = p.DocumentNumber,
                    Name = p.Name,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.Name,
                    Status = p.Status                    
                })
                .ToListAsync();
        }

        public async Task CreateAsync(CreateUpdateCustomerCommand createUpdateCustomerCommand)
        {
            if (!createUpdateCustomerCommand.IsValid())
            {
                _notificationService.AddValidation("Campos obrigatórios devem ser preenchidos.");
                return;
            }

            var categoryExists = await _context.Set<Category>().AnyAsync(p => p.Id == createUpdateCustomerCommand.CategoryId);
            if (!categoryExists)
            {
                _notificationService.AddValidation("Categoria não encontrada.");
                return;
            }

            var customer = new Customer
            {
                Name = createUpdateCustomerCommand.Name,
                DocumentNumber = createUpdateCustomerCommand.DocumentNumber,
                CategoryId = createUpdateCustomerCommand.CategoryId,
                IsRemoved = false,
                Status = CustomerStatusType.WaitingForApproval,
                CreationDate = DateTime.Now
            };

            _context.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Set<Customer>().FirstOrDefaultAsync(p => p.Id == id && !p.IsRemoved);
            if (customer == null)
            {
                _notificationService.AddValidation("Cliente não encontrado.");
                return;
            }

            customer.IsRemoved = true;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, CreateUpdateCustomerCommand createUpdateCustomerCommand)
        {
            if (!createUpdateCustomerCommand.IsValid())
            {
                _notificationService.AddValidation("Campos obrigatórios devem ser preenchidos.");
                return;
            }

            var customer = await _context.Set<Customer>().FirstOrDefaultAsync(p => p.Id == id && !p.IsRemoved);
            if (customer == null)
            {
                _notificationService.AddValidation("Cliente não encontrado.");
                return;
            }

            var categoryExists = await _context.Set<Category>().AnyAsync(p => p.Id == createUpdateCustomerCommand.CategoryId);
            if (!categoryExists)
            {
                _notificationService.AddValidation("Categoria não encontrada.");
                return;
            }

            customer.DocumentNumber = createUpdateCustomerCommand.DocumentNumber;
            customer.Name = createUpdateCustomerCommand.Name;
            customer.CategoryId = createUpdateCustomerCommand.CategoryId;

            await _context.SaveChangesAsync();
        }

        public async Task<CustomerView> GetCustomerAsync(int id)
        {
            return await _context
                .Set<Customer>()
                .Where(p => !p.IsRemoved && p.Id == id)
                .Select(p => new CustomerView
                {
                    Id = p.Id,
                    DocumentNumber = p.DocumentNumber,
                    CategoryId = p.CategoryId,
                    Name = p.Name,
                    CategoryName = p.Category.Name,
                    Status = p.Status
                })
                .FirstOrDefaultAsync();
        }
    }
}
