using Paytech.CodingInterview.API.Data.DTOs.Commands;
using Paytech.CodingInterview.API.Data.DTOs.Views;
using Paytech.CodingInterview.API.Data.Enumerators;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paytech.CodingInterview.API.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerView> GetCustomerAsync(int id);
        Task<List<CustomerView>> GetCustomersAsync(CustomerStatusType? status);
        Task CreateAsync(CreateUpdateCustomerCommand createUpdateCustomerCommand);
        Task UpdateAsync(int id, CreateUpdateCustomerCommand createUpdateCustomerCommand);
        Task DeleteAsync(int id);
    }
}
