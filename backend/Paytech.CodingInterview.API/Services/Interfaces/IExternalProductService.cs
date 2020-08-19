using Paytech.CodingInterview.API.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paytech.CodingInterview.API.Services.Interfaces
{
    public interface IExternalProductService
    {
        Task<List<ExternalProduct>> GetProductsAsync();
        Task CreateUpdateProductsAsync();
    }
}
